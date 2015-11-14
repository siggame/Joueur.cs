
all:
	make dependencies
	make core

dependencies:
	chmod a+x ./.nuget/NuGet.exe

core:
	xbuild /p:Configuration=Release Joueur.cs.sln

clean:
	rm -rf ./bin ./obj ./packages ./nuget.exe ./.nuget/NuGet.exe
