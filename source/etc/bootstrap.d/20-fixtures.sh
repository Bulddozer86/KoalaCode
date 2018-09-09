#!/usr/bin/env bash

#RUN FIXTURES
SCRIPT_DIR=`pwd -P`

cd "${SCRIPT_DIR}/../../"
yes | php bin/console doctrine:fixtures:load