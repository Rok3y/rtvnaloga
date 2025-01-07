# Setup instructions

### Docker (optional)

* Install docker
* docker pull mcr.microsoft.com/mssql/server:2019-latest
* docker run -e "ACCEPT_EULA=Y" \
           -e "SA_PASSWORD=MyStrongPassword123" \
           -p 1433:1433 \
           --name sqlserver \
           -d mcr.microsoft.com/mssql/server:2019-latest

### SQL Express (Visual studio)

If not, install SQL Server object explorer and make sure it's running

### Add EF Core and Configure DbContext

In visual studio open package manager console and install:
'''
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
'''

### Set connections string

In `appsettings.json` set connection string to target your database. If needed change the `UsedDbConnection` key to 
`ExpressDbConnection` for local db or `DockerDbConnection` for docker database

#### Create Database

In visual studio open package manager console and run:
> Update-Database

### Build & Run

#### API service

Build `rtvnaloga` and run it from command line (rtvnaloga\bin\Debug\net8.0\rtvnaloga.exe) or in visual studio by pressing F5.
To access API documentation open web browser and navigat to:
> http://localhost:5081/swagger/index.html

#### WEB UI

Navigate to `repos\rtvnaloga\WebUI` folder and run:
> ng serve

Open web page at:
> http://localhost:55522
