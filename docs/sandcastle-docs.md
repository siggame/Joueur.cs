# How to Generate Documentation for the C# Client

1. Be on Windows, unfortunately the program needed only works in Windows at the moment.
2. Build the C# Client. It will generate the files the documentation program needs to create the docs from.
3. Download the latest release of [Sandcastle Help File Builder](https://github.com/EWSoftware/SHFB/releases) and install it.
4. Restart your computer if you just installed it (otherwise Sandcastle Help File Builder won't start).
5. Open `Joueur.cs.shfbproj` in a text editor. It is just an XML file really.
6. Replace all instances of GAME_NAME with the game you are documenting name. You are basically pointing it at the Game's Namespace and updating the documentation summary mentioning the game. Then save `Joueur.cs.shfbproj` (do not push these changes)
7. Open `Joueur.cs.shfbproj` normally in Sandcastle Help File Builder.
8. Go to Documentation -> Build Project. This should open a new Build tab, and it should succeed. Your documentation should appear in ./Help/.
9. Open Help/index.html to verfiy the documentation is correct. Fix errors if you see them

## Troubleshooting

* Make sure `bin/Release/Joueur.cs.exe` and `bin/Release/Joueur.cs.XML` have been built. Both are required and Sandcastle must find them to work
* Under "Project Properties" in Sandcastle make sure Internal Members is checked, otherwise the game's Namespace will be ignored (and thus there's nothing it will document)
* Under "Summary" in Sandcastle click "Edit Namespace Summaries" to make sure that Joueur.cs.Games.GAME_NAME is found, and has a summary
* If the readme is updated, the html-ified readme in the namespace summary will need to be re-generated. Don't use pre tags for monospaced stuff, just inline style that.
