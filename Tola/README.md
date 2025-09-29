# Tola

## Solution

```powershell
dotnet new sln --format slnx --name Tola
```

## WebUI

```powershell
dotnet new mvc --framework net9.0 --no-https --use-program-main --auth Individual --use-local-db --output src/WebUI --name Tola.WebUI
dotnet sln add src/WebUI
dotnet add src/WebUI package Duende.IdentityServer
dotnet add src/WebUI package OpenTelemetry.Exporter.OpenTelemetryProtocol
dotnet add src/WebUI package OpenTelemetry.Extensions.Hosting
dotnet add src/WebUI package OpenTelemetry.Instrumentation.AspNetCore
dotnet add src/WebUI package OpenTelemetry.Instrumentation.Http
dotnet add package OpenTelemetry.Instrumentation.SqlClient --version 1.12.0-beta.3
```
