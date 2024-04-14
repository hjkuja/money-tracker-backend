# Money tracker backend

Backend for the money tracker app

## Development

### Configuration

[Default appsettings.json](src/MoneyTracker.Api/appsettings.json)

### Database

Removing and creating container

```shell
docker rm -f db && docker run -dit -e MARIADB_RANDOM_ROOT_PASSWORD=y -e MARIADB_DATABASE=moneytracker -e MARIADB_USER=dev -e MARIADB_PASSWORD=dev -p 3306:3306 --name db mariadb:11.3.2
```

Adding migrations:

```
dotnet ef migrations add -p ./src/MoneyTracker.Application/MoneyTracker.Application.csproj -s ./src/MoneyTracker.Api/MoneyTracker.Api.csproj Initial
```

Running migrations:

```
dotnet ef database update -p ./src/MoneyTracker.Application/MoneyTracker.Application.csproj -s ./src/MoneyTracker.Api/MoneyTracker.Api.csproj
```