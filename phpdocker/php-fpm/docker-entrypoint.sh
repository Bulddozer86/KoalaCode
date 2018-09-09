#!/usr/bin/env bash

DIR="/entrypoint.d/*.sh"

for f in $DIR; do
     $f
done

