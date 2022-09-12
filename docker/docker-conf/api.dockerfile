ARG ENV_NETCORE
FROM mcr.microsoft.com/dotnet/aspnet:6.0

RUN mkdir /app
WORKDIR /app

ADD ./builds/api /app
ENTRYPOINT [ "dotnet", "Adotepet.Api.dll", "Environment=Production" ]
EXPOSE 80