FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish -c Release -o ../../build

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/build .
ENTRYPOINT ["dotnet", "CSVJsonParser.Presentation.dll"]