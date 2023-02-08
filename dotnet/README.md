# TitanicAPI for C#

Under the src folder you'll find the dotnet (C#) implementation of the TitanicAPI. 

To run the application locally you must have [dotnet 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) in your environment. 
You'll also need a database with a table called People in it, populated with the provided [csv](https://gitlab.com/ContainerSolutions/API-Exercise/-/blob/master/titanic.csv) file.

This is the structured assumed for the table:
|Name|MySql|Sql Server|Null|Obs
|--|--|--|--|--
|Uuid|varchar|varchar(255)|not null|Default value guid maintained by the database itself. This field is the key of the table.
|Name|varchar|varchar(255)|not null|
|PassengerClass|numeric|int|not null|
|Survived|boolean|bit|not null|
|Sex|varchar|varchar(255)|not null|
|Age|decimal|float|not null|
|SiblingsOrSpousesAboard|int|int|not null|
|ParentsOrChildrenAboard|int|int|not null
|Fare|decimal|float|not null|

This verion of the app has been tested with [SQL Server 2019](https://hub.docker.com/_/microsoft-mssql-server) and [MySql:8-oracle](https://hub.docker.com/_/mysql)

The connection string for the application must be provided via an environment variable called `DATABASE_URL`. Also, SQL Server is assumed unless you set another variable `DBMS` with value `mysql`.

Once your database is up and populates you can run the application as folllows

```bash
DATABASE_URL="Server=localhost;Database=titanic;Uid=sa;Pwd=yourStrong(*)Password;" dotnet run
```

Test the app with 
> curl http://localhost:5000/people
