# CHECKLINK - DOTNET-CORE Introduction Project

Small introductory DOTNET-CORE console application.
This application check health of a link and all it's **href** references than creates a report document.

## Prerequisites
* [docker](https://docs.docker.com/install/)
* [dotnet-core sdk/runtime](https://dotnet.microsoft.com/download) - For local development

## Usage:
```bash
# Build the application
cd checklinksconsole 
make build

# Run the application
cd checklinksconsole 
make run

# SSH to the dotnet container
cd checklinksconsole 
make ssh

# Run unit testing
cd checklinksTests
make test
```

## Useful Commands:
```bash
# Create a new console project
dotnet new console

# Create a new testing project
dotnet new unit

# Run porject:
# Example: dotnet bin/Debug/netcoreapp2.2/checklinksconsole.dll
dotnet /PATH_TO_DLL_FILE

# Install packages into projects
dotnet add package <PACKAGE_NAME> --version <PACKAGE_NAME>

# Install and restaure the dotnet packages referenced in the project .csproj file
dotnet restore

# Packs the application and its dependencies into a folder for deployment to a hosting system.
dotnet publish

# Adds project-to-project (P2P) references.
dotnet add <PROJECT> reference <PROJECT_REFERENCES>
```
