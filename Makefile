
all:
	make dependencies
	make core

dependencies: ;

core:
	xbuild /p:Configuration=Release Joueur.cs.sln

clean:
	rm -rf ./bin ./obj ./packages
