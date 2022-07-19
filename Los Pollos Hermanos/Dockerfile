#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Los Pollos Hermanos/Los Pollos Hermanos.csproj", "Los Pollos Hermanos/"]
RUN dotnet restore "Los Pollos Hermanos/Los Pollos Hermanos.csproj"
COPY . .
WORKDIR "/src/Los Pollos Hermanos"
RUN dotnet build "Los Pollos Hermanos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Los Pollos Hermanos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Los Pollos Hermanos.dll"]