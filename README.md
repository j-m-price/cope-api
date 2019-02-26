# Docker container with VUE SPA served by Dotnet Core 2.2
------
## Installation
------
  - git clone [repository] 
  - Naviagate to the root folder of the main App
### Local dotnet server run
------
```sh
> dotnet publish
> dotnet run
```
  - In browser navigate to `localhost:5001`
### Docker container application run
------
From lcoation where `Dockerfile` is, run these commands:
  - Build Docker image with your custom name and from current location files. 
```sh
> docker build -t <name_of_the_image_you_prefer> .
```
  - Run container from the image we just created
```sh
> docker run -p 1111:80 --name <name_of_the_CONTAINER_you_prefer> <name_of_the_IMAGE_we_created_before>
```
Once container is running, we should be able to access it from the browser by navigating to
`localhost:1111`

### Additional docker commands
------
```sh
> docker ps # List all runnig container
> docker images # List all available images
> docker kill <container_name/ID> # Kills container. Not destroy, just stops it.
> docker rm <container_name> # Deletes container 
> docker rmi <image_name> # Deletes iamge
```
