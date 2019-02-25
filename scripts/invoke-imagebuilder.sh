#!/usr/bin/env bash

# Stop script on NZEC
set -e
# Stop script if unbound variable found (use ${var:-} if intentional)
set -u

docker build --rm -t testrunner -f ./tests/Dockerfile.linux.testrunner .
docker run -v /var/run/docker.sock:/var/run/docker.sock testrunner pwsh -File ./scripts/Invoke-ImageBuilder.ps1 $*