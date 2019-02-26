# Build step container. You can switch between v2.2 and v2.1, both works just fine
FROM microsoft/dotnet:2.2-sdk-alpine AS build

WORKDIR /life_app

# Installing/Updating Yarn on the first Build step.
RUN apk add --update yarn

# Changing Location ont the container to app/ folder, where our FE app is located in the project
WORKDIR /life_app/app

# Copying local app/ files to the build container
COPY ./app ./

# Install and Build FE Application on the first container
RUN yarn install && yarn build

# Switching back to first level app folder
WORKDIR /life_app

# Copying local .csproj file to the container
COPY *.csproj ./

# Running Dotnet command to restore BE app
RUN dotnet restore

# Copying all local files to the first container
COPY . ./

# Running Dotnet publish, to build for production
RUN dotnet publish -c Release -o out

# Runtime Container. You can switch between v2.2 and v2.1, both works just fine
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS runtime

# Switching wokdir on the container to /app
WORKDIR /life_app

# Copying files from Build Container location to Runtime container
COPY --from=build /life_app/out .

ENTRYPOINT ["dotnet", "core-api.dll"]
