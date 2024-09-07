# Money tracker backend

Backend for the money tracker app

## Development

### Configuration

[Default appsettings.json](src/MoneyTracker.Api/appsettings.json)

### Database

Removing and creating container

```shell
docker run -dit -e POSTGRES_USER=dev -e POSTGRES_PASSWORD=dev -e POSTGRES_DB=moneytracker -p 5432:5432 --name db postgres:16.4
```

Adding migrations:

```
dotnet ef migrations add -p ./src/MoneyTracker.Application/MoneyTracker.Application.csproj -s ./src/MoneyTracker.Api/MoneyTracker.Api.csproj Initial
```

Running migrations:

```
dotnet ef database update -p ./src/MoneyTracker.Application/MoneyTracker.Application.csproj -s ./src/MoneyTracker.Api/MoneyTracker.Api.csproj
```