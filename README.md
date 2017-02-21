# Chess C# Client

This is the root of your AI. Stay out of the `Joueur/` folder, it does most of the heavy lifting to play on our game servers. Your AI, and the game objects it manipulates are all in `Games/Chess/`, with your very own AI living in `Games/Chess/ai.cs` for you to make smarter.

## How to Run

This client has been tested and confirmed to work on the Missouri S&T Windows machines loaded with Visual Studio 2013/2015, but it can work on your own Windows/Linux/Mac machines if you desire. It will **not** work on the campus rc##xcs213 Linux machines however, as their version of Mono is out of date.

### Windows

Simply [installing Visual Studio 2013 or newer](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx) should give you everything you need, namely C#. Just open up the sln file in this repo and build + run it.

*Note*: You'll need to add [command line args in visual studio](https://msdn.microsoft.com/en-us/library/cs8hbt1w(v=vs.90).aspx).

The args should be: `Chess -s r99acm.device.mst.edu -r MyOwnGameSession`

### Linux

You'll need the latest version of Mono (v4.0.4 at the moment). Ubuntu's default Mono package is out of date and can't build this project. Luckily if you follow [Mono's own guide](http://www.mono-project.com/docs/getting-started/install/linux/) on Linux installation they walk you through installing the latest version. But if you don't want to follow that guide, then do the following:

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

### Vagrant

Install [Vagrant][vagrant] and [Virtualbox][virtualbox] in order to use the Vagrant configuration we provide which satisfies all build dependencies inside of a virtual machine. This will allow for development with your favorite IDE or editor on your host machine while being able to run the client inside the virtual machine. Vagrant will automatically sync the changes you make into the virtual machine that it creates. In order to use vagrant **after installing the aforementioned requirements** simply run from the root of this client:

```bash
vagrant up
```

and after the build has completed you can ssh into the virtual environment by running:

```bash
vagrant ssh
```

From there you will be in a Linux environment that has all the dependencies you'll need to build and run this client.

When the competition is over, or the virtual environment becomes corrupted in some way, simply execute `vagrant destroy` to delete the virtual machine and its contents.

For a more in depth guide on using vagrant, take a look at [their guide][vagrant-guide]

#### Windows

Using Vagrant with Windows can be a bit of a pain. Here are some tips:

* Use an OpenSSH compatible ssh client. We recommend [Git Bash][gitbash] to serve double duty as your git client and ssh client
* Launch the terminal of your choice (like Git Bash) as an Administrator to ensure the symbolic links can be created when spinning up your Vagrant virtual machine

## Other Notes

Try not to modify the `.csproj` file. The Arena runs this via Mono, and minor changes can break it for seemingly no reason. Every file in the `Games/` directory is told to be auto included for compilation anyways, so if you are just adding code you shouldn't have a need to modify it regardless, though Visual Studio may try to.

It is possible that on your Missouri S&T S-Drive this client will not run properly. This is not a fault with the client, but rather the school's S-Drive implementation changing some file permissions during run time. We cannot control this. Instead, we recommend cloning your repo outside the S-Drive and use an SCP program like [WinSCP](https://winscp.net/eng/download.php) to edit the files in Windows using whatever IDE you want if you want to code in Windows, but compile in Linux.

The only file you should ever modify to create your AI is the `AI.cs` file. All the other files are needed for the game to work. In addition, you should never be creating your own instances of the Game's classes, nor should you ever try to modify their variables. Instead, treat the Game and its members as a read only structure that represents the game state on the game server. You interact with it by calling the game functions.

[vagrant]: https://www.vagrantup.com/
[vagrant-guide]: https://www.vagrantup.com/docs/getting-started/
[virtualbox]: https://www.virtualbox.org/wiki/Downloads
[gitbash]: https://git-scm.com/downloads
