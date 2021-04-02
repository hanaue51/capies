# python-tensorflow
FROM jupyter/tensorflow-notebook:latest

# java
RUN conda install --quiet --yes -c conda-forge 'scijava-jupyter-kernel'

# .net
ENV DOTNET_ROOT=/user/share/dotnet
ENV PATH=/usr/share/dotnet:/home/$NB_USER/.dotnet/tools:$PATH

RUN wget -O dotnet.tar.gz https://download.visualstudio.microsoft.com/download/pr/a0487784-534a-4912-a4dd-017382083865/be16057043a8f7b6f08c902dc48dd677/dotnet-sdk-5.0.101-linux-x64.tar.gz \
  && wget -O dotnet_runtime.tar.gz https://download.visualstudio.microsoft.com/download/pr/6bea1cea-89e8-4bf7-9fc1-f77380443db1/0fb741b7d587cce798ebee80732196ef/aspnetcore-runtime-5.0.1-linux-x64.tar.gz \
  && dotnet_sha512='398d88099d765b8f5b920a3a2607c2d2d8a946786c1a3e51e73af1e663f0ee770b2b624a630b1bec1ceed43628ea8bc97963ba6c870d42bec064bde1cd1c9edb' \
  && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
  && dotnet_runtime_sha512='fec655aed2e73288e84d940fd356b596e266a3e74c37d9006674c4f923fb7cde5eafe30b7dcb43251528166c02724df5856e7174f1a46fc33036b0f8db92688a' \
  && echo "$dotnet_runtime_sha512  dotnet_runtime.tar.gz" | sha512sum -c \
  && mkdir -p "/home/${NB_USER}/.dotnet/tools"

USER root

RUN mkdir -p "/usr/share/dotnet" \
  && mkdir -p "/usr/bin/dotnet" \
  && tar zxf dotnet.tar.gz -C "/usr/share/dotnet" \
  && rm dotnet.tar.gz \
  && tar zxf dotnet_runtime.tar.gz -C "/usr/share/dotnet" \
  && rm dotnet_runtime.tar.gz \
  && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
  && dotnet help \
  && conda clean --all \
  && apt-get clean \
  && rm -rf /var/lib/apt/lists/* \
  && dotnet tool install -g --add-source "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json" Microsoft.dotnet-interactive

USER $NB_UID

RUN dotnet interactive jupyter install
COPY add_mlagents.sh /home/$NB_USER/add_mlagents.sh

