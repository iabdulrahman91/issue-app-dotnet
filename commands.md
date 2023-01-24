```shell

dotnet new sln -o IssueDemo

cd IssueDemo/

dotnet new webapi -o IssueDemo.Api

dotnet new classlib -o IssueDemo.Contracts

dotnet new classlib -o IssueDemo.Infrastructure

dotnet new classlib -o IssueDemo.Application

dotnet new classlib -o IssueDemo.Domain

dotnet sln add $(ls **/*.csproj)

dotnet build

dotnet add IssueDemo.Api/ reference IssueDemo.Contracts/ IssueDemo.Application/

dotnet add IssueDemo.Infrastructure/ reference IssueDemo.Application/

dotnet add IssueDemo.Application/ reference IssueDemo.Domain/

dotnet add IssueDemo.Api/ reference IssueDemo.Infrastructure/

dotnet build

dotnet dev-certs https --trust

dotnet watch run

dotnet run --project IssueDemo.Api