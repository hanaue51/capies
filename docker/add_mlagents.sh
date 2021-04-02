#!/bin/bash

pip3 --quiet install mlagents
cd /home/jovyan/work
git clone -b release_15 https://github.com/Unity-Technologies/ml-agents.git 
cd ml-agents
pip3 --quiet install -e ./ml-agents-envs
pip3 --quiet install -e ./ml-agents
