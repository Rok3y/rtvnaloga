# Setup instructions

### Docker

* Install docker
* docker pull mcr.microsoft.com/mssql/server:2019-latest
* docker run -e "ACCEPT_EULA=Y" \
           -e "SA_PASSWORD=MyStrongPassword123" \
           -p 1433:1433 \
           --name sqlserver \
           -d mcr.microsoft.com/mssql/server:2019-latest

### Add EF Core and Configure DbContext

In package manager console install:
'''
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
'''

#### Create initial migration

> Add-Migration InitialCreate
> Update-Database