import os
import os.path
import subprocess
import shutil
from datetime import date
import sys

def run(*args, **kwargs):
    error_code = subprocess.call(*args, **kwargs)
    if error_code != 0: # an error happened
        sys.exit(error_code)

temp_path = "./temp/"
if os.path.isdir(temp_path):
    shutil.rmtree(temp_path)
os.makedirs(temp_path)

with open("../README.md", "r") as file:
    readme = file.read()

game_names = [f for f in os.listdir("../Games") if os.path.isdir(os.path.join("../Games", f))]

games_sections = '##Games\n\n' + (
    '\n'.join(["* [{0}](namespaceJoueur_1_1cs_1_1Games_1_1{0}.html)".format(n) for n in game_names])
+ "\n\n")

insert_at = readme.find("## How to Run")

with open(os.path.join(temp_path, "README.md"), 'w+') as file:
    file.write(readme[:insert_at] + games_sections + readme[insert_at:])

shutil.copyfile("./Doxyfile", os.path.join(temp_path, "Doxyfile"))

shutil.copytree("../Games/", os.path.join(temp_path, "Games/"))

shutil.copyfile("../Joueur/BaseGameObject.cs", os.path.join(temp_path, "BaseGameObject.cs"))

run(["doxygen"], shell=True, cwd=temp_path)

output_path = "./output"
if os.path.isdir(output_path):
    shutil.rmtree(output_path)
shutil.copytree(os.path.join(temp_path, "docs", "html"), output_path)

shutil.rmtree(temp_path)
