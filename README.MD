## ReenWise Backend Server
The ReenWise backend server is an ASP.NET Core application that offers a Web Api. The solution is build upon the following design patterns
- Clean Architecture pattrrn
- Repository  pattern
- CQRS pattern (MediatR)

The implementation also utilizes
- Automapper
- Swagger

#### Swagger
The current released version of Swashbuclke.AspNetCore NuGet package - version 4.4.0 - crashes with ASP.NET Core v3.1.0 and has consequetly been updated to v5.0.0-rc5 (a pre-release).

> PM> Install-Package Swashbuckle.AspNetCore -Version 5.0.0-rc3
