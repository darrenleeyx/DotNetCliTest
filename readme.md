cd Desktop
cd C#
cd CliTest
dotnet new sln --name CliTest
dotnet new gitignore
dotnet new editorconfig
dotnet new globaljson
dotnet new list // Shows list of project types

dotnet new webapi-o src/CliTest.Api
dotnet new classlib -o src/CliTest.Application
dotnet new classlib -o src/CliTest.Domain
dotnet new classlib -o src/CliTest.Infrastructure

dotnet new xunit -o tests/CliTest.Api.Tests.Integration
dotnet new xunit -o tests/CliTest.Api.Tests.Unit

dotnet add src/CliTest.Api reference src/CliTest.Application
dotnet add src/CliTest.Api reference src/CliTest.Infrastructure
dotnet add src/CliTest.Infrastructure reference src/CliTest.Application
dotnet add src/CliTest.Application reference src/CliTest.Domain

dotnet add tests/CliTest.Api.Tests.Integration reference src/CliTest.Api
dotnet add tests/CliTest.Api.Tests.Unit reference src/CliTest.Api

dotnet sln add (ls -r **/*.csproj) // Adds all projects to solution

dotnet build
dotnet run --project CliTest.Api

dotnet test tests/CliTest.Api.Tests.Unit


docker pull mcr.microsoft.com/mssql/server
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Mypassword#123" -p 1433:1433 -d mcr.microsoft.com/mssql/server