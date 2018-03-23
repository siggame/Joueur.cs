import os
import os.path
import subprocess
import shutil
from datetime import date
import sys
import zipfile

def run(*args, **kwargs):
    error_code = subprocess.call(*args, **kwargs)
    if error_code != 0: # an error happened
        sys.exit(error_code)

if os.path.isdir("./output/"):
    shutil.rmtree("./output/")

if not os.path.isdir("./bin"):
    run(["wget https://github.com/dotnet/docfx/releases/download/v2.33.1/docfx.zip"], shell=True)
    # run(["unzip docfx.zip -d docfx"], shell=True)
    with zipfile.ZipFile("./docfx.zip","r") as zip_ref:
        zip_ref.extractall("bin")
    os.remove("./docfx.zip")
    os.chmod("./bin/docfx.exe", 0o777)
    # run(["chmod 777 ./bin/docfx.exe"])

shutil.copyfile("../README.md", "./docs/index.md")
shutil.copyfile("../README.md", "./index.md")

if os.path.isdir("./overwrite"):
    shutil.rmtree("./overwrite")

os.makedirs("./overwrite")

game_names = [f for f in os.listdir("../Games") if os.path.isdir(os.path.join("../Games", f))]

for game_name in game_names:
    with open(os.path.join("../Games/", game_name, "Game.cs"), "r") as file:
        lines = file.read().splitlines()
        summary = False
        for line in lines:
            if summary:
                summary = line.replace("/// ", "")
                break

            if line.strip() == "/// <summary>":
                summary = True

    with open("./overwrite/" + game_name + ".md", "w+") as file:
        file.write("""---
uid: Joueur.cs.Games.{game_name}
---
### Rules

> {summary}

The full game rules for {game_name} can be found on [GitHub][rules].

Additional materials, such as the [story][story] and [game template][creer] can be found on [GitHub][root] as well.

[rules]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/rules.md
[story]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/story.md
[creer]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/creer.yaml
[root]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/
""".format(game_name=game_name, summary=summary))
        file.truncate()

run(["./bin/docfx.exe metadata docfx.json"], shell=True)
run(["./bin/docfx.exe build docfx.json"], shell=True)

with open("./output/docs/toc.html", "r+") as file:
    contents = file.read()
    contents = contents.replace(">Joueur.cs.Games.", ">")

    START_STR = "<li>"
    start = contents.find(START_STR)

    END_STR = "</ul>  </li>"
    end = contents.find(END_STR)

    contents = contents[:(start + len(START_STR))] + contents[(end + len(END_STR)):]
    file.seek(0)
    file.write(contents)
    file.truncate()

# this is hacky, but it basically forces a sub dir to be the root
# it seems some JS built into docfx formats the TOC, so even if we put it
# in the root it will look dumb, and their JS is minified
with open("./output/index.html", "r+") as file:
    contents = file.read()
    STR = "<head>"
    i = contents.find(STR) + len(STR)
    contents = contents[:i] + """
        <meta http-equiv="refresh" content="0; url=docs/">
        <script type="text/javascript">
            window.location.href = "docs/"
        </script>
""" + contents[i:]
    file.write(contents)

print("Done generating C# docs")
