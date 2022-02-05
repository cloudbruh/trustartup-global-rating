FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CloudBruh.Trustartup.GlobalRating/CloudBruh.Trustartup.GlobalRating.csproj", "CloudBruh.Trustartup.GlobalRating/"]
RUN dotnet restore "CloudBruh.Trustartup.GlobalRating/CloudBruh.Trustartup.GlobalRating.csproj"
COPY . .
WORKDIR "/src/CloudBruh.Trustartup.GlobalRating"
RUN dotnet build "CloudBruh.Trustartup.GlobalRating.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudBruh.Trustartup.GlobalRating.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudBruh.Trustartup.GlobalRating.dll"]
