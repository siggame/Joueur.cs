# Spiders C# Client

This is the root of your AI. Stay out of the Joueur/ folder, it does most of the heavy lifting to play on our game servers. Your AI, and the game objects it manipulates are all in `Games/Spiders/`, with your very own AI living in `Games/Spiders/ai.cs` for you to make smarter.

## How to Run

This client has been tested and confirmed to work on the Campus Windows machines loaded with Visual Studio 2013/2015, but it can work on your own Windows/Linux/Mac machines if you desire. It will **not** work on the campus rc##xcs213 Linux machines however, as their version of mono is out of date.

### Windows

Simply [installing Visual Studio 2013 or newer](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx) should give you everything you need, namely C#. Just open up the sln file in this repo and build + run it.

*Note*: You'll need to add [command line args in visual studio](https://msdn.microsoft.com/en-us/library/cs8hbt1w(v=vs.90).aspx).

The args should be: `Spiders -s r99acm.device.mst.edu -r MyOwnGameSession`

### Linux

You'll need the latest version of Mono (v4.0.4 at the moment). The package on Ubuntu's default packages it out of date and can't build this project. Luckily if you follow [Mono's own guide](http://www.mono-project.com/docs/getting-started/install/linux/) on Linux installation they walk you through installing the latest version. But if you don't want to follow that guide do the following:

```
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get update
echo "deb http://download.mono-project.com/repo/debian wheezy-apache24-compat main" | sudo tee -a /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get install mono-devel mono-complete referenceassemblies-pcl ca-certificates-mono
```

After those dependencies install, to run the client:

```
make
.\testRun MyOwnGameSession
```

## Other Notes

Try not to modify the `.csproj` file. The Arena runs this via Mono, and minor changes can break it for seemingly no reason. Every file in the `Games/` directory is told to be auto included for compilation anyways, so if you are just adding code you shouldn't have a need to modify it anyways.

It is possible that on your Missouri S&T S-Drive this client will not run properly. This is not a fault with the client, but rather the school's S-Drive implimentation changing some file permissions during run time. We cannot control this. Instead, we recommend cloning your repo outside the S-Drive and use an SCP program like [WinSCP](https://winscp.net/eng/download.php) to edit the files in Windows using whatever IDE you want if you want to code in Windows, but compile in Linux.
