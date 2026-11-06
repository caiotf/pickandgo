# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1) Só os .csproj primeiro: o restore fica em cache enquanto as dependências não mudarem
COPY backend/src/PickAndGo.Api/PickAndGo.Api.csproj                       src/PickAndGo.Api/
COPY backend/src/PickAndGo.Application/PickAndGo.Application.csproj       src/PickAndGo.Application/
COPY backend/src/PickAndGo.Domain/PickAndGo.Domain.csproj                 src/PickAndGo.Domain/
COPY backend/src/PickAndGo.Infrastructure/PickAndGo.Infrastructure.csproj src/PickAndGo.Infrastructure/
RUN dotnet restore src/PickAndGo.Api/PickAndGo.Api.csproj

# 2) Depois o código
COPY backend/ .
RUN dotnet publish src/PickAndGo.Api/PickAndGo.Api.csproj -c Release -o /app/publish --no-restore

# ---------- runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
USER $APP_UID
EXPOSE 8080
ENTRYPOINT ["dotnet", "PickAndGo.Api.dll"]