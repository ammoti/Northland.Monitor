# Architecture Alerter

Architecture Alerter is a downtime alerter for sendind query to website using new technologies and best practices.

## Technologies

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core)
* [Entity Framework Core 3.1](https://docs.microsoft.com/en-us/ef/core)
* [C# 8.0](https://docs.microsoft.com/en-us/dotnet/csharp)
* [Angular 10](https://angular.io/docs)
* [UIkit](https://getuikit.com/docs/introduction)
* [Docker](https://docs.docker.com)

## Practices

* Clean Code
* SOLID Principles
* DDD (Domain-Driven Design)
* Separation of Concerns

## Run


#### Steps

1. Open directory **source** in command line and execute **dotnet ef migrations add "Initial" --project .\Database**.
2. Open directory **source\Web** in command line and execute **dotnet run**.
3. Open <https://localhost:8090>.


### RoadMap

- [x] Use Best Practice
- [ ] Add Register Form to Angular
- [ ] Implement some notifications(sending email, sms etc.)
- [x] Add Loger
- [x] Add DI to Worker projects
- [x] Add auth and authrozation
- [ ] xUnit
- [x] Add docker compose

## Layers

**Web:** API and Frontend (Angular).

**Application:** Flow control.

**Domain:** Business rules and domain logic.

**Model:** Data transfer objects.

**Database:** Database persistence.

**Worker:** Handling web site state check

**Notification.Worker:** Handling all notification things 
