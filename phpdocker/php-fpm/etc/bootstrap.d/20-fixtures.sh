#!/usr/bin/env bash

#RUN FIXTURES
cd "/app/"
yes | php bin/console doctrine:fixtures:load