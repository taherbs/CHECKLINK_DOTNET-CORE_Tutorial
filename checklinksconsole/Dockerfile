FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build 
# build app
COPY code /app/code
WORKDIR /app/code

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:2.2 AS runtime
WORKDIR /app
# Copy code from build container
COPY --from=build /app/code/out ./

# Run app
ENTRYPOINT ["dotnet", "checklinksconsole.dll"]

