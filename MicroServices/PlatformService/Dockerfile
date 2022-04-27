# Using .net as base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env

# Set Working directory
WORKDIR /app

# Copy projet files to working directory
COPY *.csproj ./
RUN dotnet restore

# Copy everything else from source to destination(working dir)
COPY . ./

RUN dotnet publish -c Release -o out

# use run time image of .net
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]