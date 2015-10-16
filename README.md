# Joueur.cs
The C# game client for the Cadre framework to connect to [Cerveau](https://github.com/JacobFischer/Cerveau) servers.

![{Cadre}](http://i.imgur.com/17wwI3f.png)

All inspiration taken from [MST's SIG-GAME framework](https://github.com/siggame), and most of the terminology is assuming some familiarity with it as this is a spiritual successor to it.

## Features

* Multi-Game:
  * One client can have multiple AIs to play different games.
* Easy generation of new game AIs using the [Creer](https://github.com/JacobFischer/Creer) codegen.
* No game specific logic. All logic is done server side. Here on clients we just merge deltas into the game state, and expose the changes in handle Game and GameObject classes.
* Included are visual studio 2010/13 projects
* All code documented using xmldoc style documentation
* Networking via TCP
  * Communication via json strings with support for cycles within game references
  * Only deltas in states are send over the network

## Requirements

### Windows

Simply [installing Visual Studio 2013 or newer](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx) should give you everything you need, namely C#. Just open up the sln file in this repo and build + run it.

*Note*: You'll need to add [command line args in visual studio](https://msdn.microsoft.com/en-us/library/cs8hbt1w(v=vs.90).aspx).

### Linux

You'll need the latest version of Mono (v4.0.4 at the moment). The package on Ubuntu's default packages it out of date and can't build this project. Luckily if you follow [Mono's own guide](http://www.mono-project.com/docs/getting-started/install/linux/) on Linux installation they walk you through installing the latest version.

## How to Run

Build and run the project using these command line args.
```
make
./run GAME_NAME -s SERVER -p PORT
```

## Missing features

This client does not support multi-dimensional objects (e.g. an array of arrays). And no dictionaries outside the special GameObjects dictionary will merge correctly for similar reasons. The main issue is because we want to keep the delta-merging code as DRY as possible.
