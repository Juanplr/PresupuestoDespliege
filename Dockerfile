from mcr.microsoft.com/dotnet/sdk:latest
copy ./Presupuestos /Presupuestos
workdir /
cmd ["dotnet", "run"]