# Setup instructions

## Requirements

* Visual studio 2022 (17.12.3 - must be at least (v17.11) for .net8 support)
* Visual studio installer components:
  * ASP.NET and web development
* .NET 8.0
  * installation at: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
* nodejs
  * installation at: https://nodejs.org/dist/v22.12.0/node-v22.12.0-x64.msi
* angular
  * when nodejs installed run: `npm install -g @angular/cli`

### Docker (optional)

* Install docker
* docker pull mcr.microsoft.com/mssql/server:2019-latest
* docker run -e "ACCEPT_EULA=Y" \
           -e "SA_PASSWORD=MyStrongPassword123" \
           -p 1433:1433 \
           --name sqlserver \
           -d mcr.microsoft.com/mssql/server:2019-latest

### SQL Express (Visual studio)

If not using docker make sure to install SQL Server object explorer.

### Set connections string

In `appsettings.json` set connection string to target your database. If needed change the `UsedDbConnection` key to 
`ExpressDbConnection` for local db or `DockerDbConnection` for docker database

#### Create Database

In visual studio open package manager console and run:
> Update-Database

### Build & Run

#### API service

Build `rtvnaloga` and run it from command line:

> rtvnaloga\bin\Debug\net8.0\rtvnaloga.exe program.exe --urls "http://localhost:5081"

or in visual studio by pressing F5.

To access API documentation open web browser and navigat to:
> http://localhost:5081/swagger/index.html

#### WEB UI

Navigate to `repos\rtvnaloga\WebUI` folder and run:
> npm install

> ng serve

Open web page at:
> http://localhost:55522
