FROM siggame/joueur:cs-onbuild as build

FROM mono:slim

WORKDIR /client
COPY --from=build /usr/src/client/bin/Release/Joueur.cs.exe cs-client.exe

ENTRYPOINT ["mono", "cs-client.exe", GAME_NAME]
