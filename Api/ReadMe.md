Run "func start" at Api project root folder.

For run locally, you need to: 
Istall Azure Functions Core Tools - https://functionscdn.azureedge.net/public/artifacts/v4/latest/func-cli-x86.msi
	or read more here - https://learn.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio

If needed - Configure HTTPS - https://damienbod.com/2019/03/14/running-local-azure-functions-in-visual-studio-with-https/

local.settings.json file should be in .gitignore file and didn't be pushed to the repository.

Create local.settings.json file in the root of the project with the following content:
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "GOOGLE_MAP_API_KEY": "GOOGLE_MAP_API_KEY"
  },
  "Host": {
    "CORS": "*",
    "CORSCredentials": false
  }
}
```

Update host.json file in the root of the project with the following content:
```json
{
  "version": "2.0",
  "extensionBundle": {
    "id": "Microsoft.Azure.Functions.ExtensionBundle",
    "version": "[3.*, 4.0.0)"
  },
  "logging": {
    "applicationInsights": {
      "samplingSettings": {
        "isEnabled": true,
        "excludedTypes": "Request"
      },
      "enableLiveMetricsFilters": true
    },
    "logLevel": {
      "Function": "Information",
      "Host.Results": "Information",
      "Host.Aggregator": "Information",
      "Host.Startup": "Information",
      "Function.HttpTrigger": "Information"
    }
  }
}
```