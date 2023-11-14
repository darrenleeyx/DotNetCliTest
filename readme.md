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

dotnet sln add (ls -r **/*.csproj) // Adds all projects to solution

dotnet build
dotnet run --project CliTest.Api