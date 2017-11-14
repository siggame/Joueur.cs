
all:
	make dependencies
	make core

dependencies: ;

core:
	dotnet restore
	dotnet build -c "Release"

clean:
	rm -rf bin/ obj/ packages/ backup/
