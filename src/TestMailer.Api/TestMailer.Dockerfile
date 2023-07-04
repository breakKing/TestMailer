FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TestMailer.Api/TestMailer.Api.csproj", "src/TestMailer.Api/"]
RUN dotnet restore "src/TestMailer.Api/TestMailer.Api.csproj"
COPY . .
WORKDIR "/src/src/TestMailer.Api"
RUN dotnet build "TestMailer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestMailer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestMailer.Api.dll"]
