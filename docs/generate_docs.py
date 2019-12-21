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
        print("unexpected error")
        sys.exit(error_code)
    return error_code

if os.path.isdir("./output/"):
    shutil.rmtree("./output/")

if not os.path.isdir("./docfx"):
    run(["wget https://github.com/dotnet/docfx/releases/download/v2.48/docfx.zip"], shell=True)
    with zipfile.ZipFile("./docfx.zip","r") as zip_ref:
        zip_ref.extractall("./docfx")
    os.remove("./docfx.zip")
    os.chmod("./docfx/docfx.exe", 0o777)

shutil.copyfile("../README.md", "./index.md")

if os.path.isdir("./overwrite"):
    shutil.rmtree("./overwrite")
os.makedirs("./overwrite")

if os.path.isdir("./games"):
    shutil.rmtree("./games")
os.makedirs("./games")

game_names = list(sorted([f for f in os.listdir("../Games") if os.path.isdir(os.path.join("../Games", f))]))

summaries = {}
for game_name in game_names:
    with open(os.path.join("../Games/", game_name, "Game.cs"), "r") as file:
        lines = file.read().splitlines()
        summary = False
        for line in lines:
            if summary:
                summary = line.replace("/// ", "")
                summaries[game_name] = summary
                break

            if line.strip() == "/// <summary>":
                summary = True

    with open("./overwrite/" + game_name + ".md", "w+") as file:
        file.write("""---
uid: Joueur.cs.Games.{game_name}
---

### Rules

_{summary}_

The full game rules for {game_name} can be found on [GitHub][rules].

Additional materials, such as the [story][story] and [game template][creer] can be found on [GitHub][root] as well.

[rules]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/rules.md
[story]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/story.md
[creer]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/creer.yaml
[root]: https://github.com/siggame/Cadre/blob/master/Games/{game_name}/
""".format(game_name=game_name, summary=summary))
        file.truncate()

with open("./games/index.md", "w+") as file:
    file.write("""
# Games

These are the games that are available to play via the C# Joueur Client. Their source code is stored in the directory: `Games/GAME_NAME/`, where `GAME_NAME` is the name of the game (with the first letter capitalized).

""" + ("\n".join('#### [**{n}**](Joueur.cs.Games.{n}.html)\n{s}\n\n'.format(n=n, s=summaries[n]) for n in game_names)) + """

## Other Notes

### Modifying non AI files

Each class fle inside of `Games/GAME_NAME/`, except for your `AI.cs` should ideally not be modified. They are intended
to be read only constructs that hold the state of that object at the point in time you are reading its properties.

That being is said, if you really wish to add functionality, such as helper functions, ensure they do not directly modify game state information.

### Game Logic

If you are attempting to figure out how the logic is executed for a game, that code is **not** here.
All [cadre](https://github.com/siggame/Cadre) game clients are dumb state tracking programs that facilitate IO between a game server and your AI in whatever language you choose.

If you wish to get the actual code for a game check in the [game server](https://github.com/siggame/Cerveau).
Its directory structure is similar to most clients (such as this one).

""")

run(["mono ./docfx/docfx.exe metadata ./docfx.json"], shell=True)
run(["mono ./docfx/docfx.exe build ./docfx.json"], shell=True)

if False:
    with open("./output/games/toc.html", "r+") as file:
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

print("Done generating C# docs")
