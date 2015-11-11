
all:
	make dependencies
	make core

dependencies:
	wget -nc http://nuget.org/nuget.exe
	cp nuget.exe ./.nuget/NuGet.exe
	chmod a+x ./.nuget/NuGet.exe

core:
	xbuild /p:Configuration=Release Joueur.cs.sln

clean:
	rm -rf ./bin ./obj ./packages
