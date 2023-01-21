# Money tracker backend

Backend for the money tracker app

## Development

### Configuration

[Default appsettings.json](src/MoneyTracker.Api/appsettings.json)

### Database

```shell
docker run -dit -e MARIADB_RANDOM_ROOT_PASSWORD=y -e MARIADB_DATABASE=moneytracker -e MARIADB_USER=dev -e MARIADB_PASSWORD=dev -p 127.0.0.1:3306:3306 --name moneytrackerdb mariadb:latest
```
