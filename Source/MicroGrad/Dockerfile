FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MicroGrad/MicroGrad.csproj", "MicroGrad/"]
RUN dotnet restore "MicroGrad/MicroGrad.csproj"
COPY . .
WORKDIR "/src/MicroGrad"
RUN dotnet build "MicroGrad.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroGrad.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroGrad.dll"]
