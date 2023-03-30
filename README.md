#   Simple TODO List API

This repository contains a simple C#/.NET application that exposes a CRUD API for TODO items.

The API is documented by Swagger, and can be explored at `/swagger/index.html`.

The `main` branch uses an in-memory database.
The `mysql` branch uses an external MySQL instance either on localhost:<defaultport> or on Cloud Foundry / Tanzu Application Service.

##  Build

    dotnet build

##  Run Locally

    docker run --rm -ti -p 3306:3306 --name mysql -e MYSQL_ROOT_PASSWORD=steeltoe -e MYSQL_DATABASE=steeltoe -e MYSQL_USER=steeltoe -e MYSQL_PASSWORD=steeltoe percona:5.7.35
    dotnet run

##  Run on Tanzu Application Service (Cloud Foundry)

    cf push -f manifest.yaml

##  References
-   https://docs.steeltoe.io/guides/get-to-know-steeltoe/exercise1.html
-   https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api