# Anarchy C# Client

This is the root of you AI. Stay out of the Joueur/ folder, it does most of the heavy lifting to play on our game servers. Your AI, and the game objects it manipulates are all in `Games/Anarchy/`, with your very own AI living in `games/anarchy/ai.js` for you to make smarter.

## How to Run

This client has been tested and confirmed to work on the Campus machines loaded with Visueal Studio 2013/2015, but it can work on your own Windows/Linux/Mac machines if you desire. It will **not** work on the campus rc##xcs213 Linux machines however, as their version of mono is out of date.

### Windows

Simply [installing Visual Studio 2013 or newer](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx) should give you everything you need, namely C#. Just open up the sln file in this repo and build + run it.

*Note*: You'll need to add [command line args in visual studio](https://msdn.microsoft.com/en-us/library/cs8hbt1w(v=vs.90).aspx).

The args can be: `Anarchy -s r99acm.device.mst.edu -r MyOwnGameSession`

### Linux

You'll need the latest version of Mono (v4.0.4 at the moment). The package on Ubuntu's default packages it out of date and can't build this project. Luckily if you follow [Mono's own guide](http://www.mono-project.com/docs/getting-started/install/linux/) on Linux installation they walk you through installing the latest version.

After that just do:

```
make
.\testRun MyOwnGameSession
```

## Other Notes

Try not to modify the `.csproj` file. The Arena runs this via Mono, and minor changes can break it for seemingly no reason. Every file in the `Games/` directory is told to be auto included for compilation anyways, so if you are just adding code you shouldn't have a need to modify it anyways.
