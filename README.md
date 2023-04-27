# AZ-204 CoHack : Application Configuration Management

## Introduction

Cloud-based applications often run on multiple virtual machines or containers in multiple regions and use multiple external services. Creating a robust and scalable application in a distributed environment presents a significant challenge.

Various programming methodologies help developers deal with the increasing complexity of building applications. An application’s configuration settings should be kept external to its executable and read in from its runtime environment or an external source.

In this challenge based hackathon, we will deploy an application that use Azure App Configuration and Azure Key Vault to manage its settings.

## Requirements

- A [Microsoft Azure Subscription](http://portal.azure.com) per team

## Learning Objectives

This hack will help you learn:

- How to use Azure App Configuration to externalize storage and management of your app settings
- How to use Azure Key Vault to securely store and access secrets
- How to use Azure Managed Identity to connect Azure resources
- [Optional] How to use Azure API Management to create and manage modern API gateways

## Success Criteria

### Challenge 1

- Deply the [CoHack App](/src) to an Azure App Service
- Manage the [CoHack App settings](/src/appsettings.json) using Azure App Configuration
- Manage the [CoHack App secrets](/src/appsettings.json) using Azure Key Vault
- Show the [Details Page](/src/Pages/Details.cshtml) using Feature Flags

#### Resources

- [Deploy an ASP.NET web app](https://learn.microsoft.com/azure/app-service/quickstart-dotnetcore?tabs=net60&pivots=development-environment-cli)
- [Create an ASP.NET Core app with Azure App Configuration](https://learn.microsoft.com/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core6x)
- [Use dynamic configuration in an ASP.NET Core app](https://learn.microsoft.com/azure/azure-app-configuration/enable-dynamic-configuration-aspnet-core?tabs=core6x)
- [Add feature flags to an ASP.NET Core app](https://learn.microsoft.com/azure/azure-app-configuration/quickstart-feature-flag-aspnet-core?tabs=core6x)
- [Use Key Vault references in an ASP.NET Core app](https://learn.microsoft.com/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=core5x)

### [Optional] Challenge 2

- Import and publish the [Demo Conference API](https://conferenceapi.azurewebsites.net/?format=json) using Azure API Managment
- Have a HTTP repsonse that contains only the Gateway URLs
- Show the API URL in [CoHack App home page](/src/Pages/Index.cshtml) without updating the code

#### Resources

- [Import and publish your first API](https://learn.microsoft.com/azure/api-management/import-and-publish)
- [Find and replace string in body](https://learn.microsoft.com/azure/api-management/find-and-replace-policy)
