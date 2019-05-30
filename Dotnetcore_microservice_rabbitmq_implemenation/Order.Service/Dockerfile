FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Order.Service/Order.Service.csproj", "Order.Service/"]
RUN dotnet restore "Order.Service/Order.Service.csproj"
COPY . .
WORKDIR "/src/Order.Service"
RUN dotnet build "Order.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Order.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Order.Service.dll"]