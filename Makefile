all:
	make dependencies
	make build-debug

release:
	make dependencies
	make build-release

dependencies:
	dotnet restore

build-debug:
	dotnet build -o build --configuration Debug

build-release:
	dotnet build -o build --configuration Release

clean:
	rm -rf build/ obj/ packages/ bin/
