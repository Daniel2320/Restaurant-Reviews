#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RestuarantAPI/RestuarantAPI.csproj", "RestuarantAPI/"]
COPY ["RestaurantInfo/RestaurantInfo.csproj", "RestaurantInfo/"]
COPY ["RestaurantDL/RestaurantDL.csproj", "RestaurantDL/"]
COPY ["RestaurantBL/RestaurantBL.csproj", "RestaurantBL/"]
RUN dotnet restore "RestuarantAPI/RestuarantAPI.csproj"
COPY . .
WORKDIR "/src/RestuarantAPI"
RUN dotnet build "RestuarantAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestuarantAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestuarantAPI.dll"]
#  make sure you are in Weather api in terminal, 
# Build the image - : docker build -t weather-api-image -f Dockerfile .
# check if the image is available - docker images
# if the image created above is available, the run the image without creating a container (docker daemon is going to assign a container with a random generated name)
# to run the image  - docker run -it --rm -p 5000:80 weather-api-image
# docker images
# docker build -t rest-api -f RestuarantAPI/Dockerfile .
# docker run -it -p 5000:80 rest-api
# docker container ls
# docker ps -a
#
#
#
#