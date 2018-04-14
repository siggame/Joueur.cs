FROM siggame/joueur:cs-onbuild as build

FROM siggame/joueur:cs-base

COPY --from=build --chown=siggame:siggame /usr/src/client/build ./

