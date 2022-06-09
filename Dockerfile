FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ./FirstTaskFromDean.sln .
COPY ./FirstTaskFromDean/FirstTaskFromDean.csproj ./FirstTaskFromDean/
RUN dotnet restore

COPY . .
RUN dotnet build -c Release
RUN ls -ll

FROM build as publish 
WORKDIR /app/FirstTaskFromDean
RUN dotnet publish -c Release -o out --no-build
RUN pwd
RUN ls

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
ARG TARGET_ENV=Development
ENV ASPNETCORE_ENVIRONMENT $TARGET_ENV
EXPOSE 80
WORKDIR /app
COPY --from=publish /app/FirstTaskFromDean/out .
ENTRYPOINT ["dotnet", "FirstTaskFromDean.dll"]
