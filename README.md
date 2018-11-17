### Prerequisites
[.NET Core SDK 2.1](https://www.microsoft.com/net/download)

[Docker for windows](https://docs.docker.com/docker-for-windows/install/)

### Running on windows using docker
- Open the command prompt.

- Go to the solution folder and execute the following command to build the image:

    docker build -t csvjsonparser .

- Execute the following command to generate your json from csv files, replacing the <your_csv_files_path> with the path where your csv files can be found:

    docker run -it -v "<your_csv_files_path>":/data csvjsonparser /data

Docker might ask you to share your drive:

![docker share image](https://github.com/diegohonma/csvjsonparser/blob/master/docker_share.png)

Your json files will be generated on the same folder where your csv files are located.

### Running the tests
- Open the command prompt 
- Go to the solution folder
- Go to test\CSVJsonParser.Tests
- Run dotnet test command
