FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app


FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MicaExtension_EGI.csproj", "Edelweiss/Services/"]
RUN dotnet restore "Edelweiss/Services/MicaExtension_EGI.csproj"
COPY . "Edelweiss/Services/"
WORKDIR "/src/Edelweiss/Services"
RUN dotnet build "MicaExtension_EGI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MicaExtension_EGI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicaExtension_EGI.dll"]