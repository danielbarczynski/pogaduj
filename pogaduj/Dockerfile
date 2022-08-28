#Build Stage

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./pogaduj.csproj" 
RUN dotnet publish -c release -o /app 

#Serve Stage

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR	/app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "pogaduj.dll"]