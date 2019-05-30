FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Shipping.Service/Shipping.Service.csproj", "Shipping.Service/"]
RUN dotnet restore "Shipping.Service/Shipping.Service.csproj"
COPY . .
WORKDIR "/src/Shipping.Service"
RUN dotnet build "Shipping.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Shipping.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shipping.Service.dll"]