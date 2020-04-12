#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

#копируем зависимости
COPY ["../OrderSystem.Shared/OrderSystem.Shared.csproj", "OrderSystem.Shared/"]
COPY ["../RequestLogMiddleware/RequestLogMiddleware.csproj", "RequestLogMiddleware/"]

COPY ["./OrderSystem.csproj", "OrderSystem/"]
RUN dotnet restore "OrderSystem/OrderSystem.csproj"
WORKDIR "/src/OrderSystem"
COPY . .
RUN dotnet build "OrderSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderSystem.dll"]