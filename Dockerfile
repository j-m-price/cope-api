#FROM microsoft/dotnet:2.1-sdk-alpine AS build <---- this one works fine
FROM microsoft/dotnet:2.2-sdk-alpine AS build

WORKDIR /app

RUN apk add --update yarn

WORKDIR /app/app
COPY ./app ./

RUN yarn install && yarn build

WORKDIR /app
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

#FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime <---- this one works fine
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "core-api.dll"]
