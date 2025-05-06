# my-test-plugins

## Parameter
Parameter Name|Value
---|---
mode|test or deploy
test-path|/backend/tests/UnitTest
api-path|/backend/src/PublicApi
jobworker-path|/backend/src/HangfireJobWorker
frontend-path|/frontend
command-before|???
command-build-api|dotnet restore --no-cache && dotnet build
command-build-jobworker|dotnet restore --no-cache && dotnet build
command-run-test|dotnet restore --no-cache && dotnet build
command-frontend|npm install && npm run build
command-after|???


```yml
```yml
jobs:
  sample-job:
    runs-on: my-server
    env:
      DOTNET_INSTALL_DIR: /home/gitaction/.dotnet
      DOTNET_ROOT: /home/gitaction/.dotnet
    steps:
      - name: Checkout Repository
        uses: actions/checkout@v3
      - name: Run Test
        uses: amn/appsettings-transformer@v1
        with:
          appsettings-path: /backend/tests/UnitTest/appsettings.json
          transformer:
            {
                ConnectionStrings.default: "server=192.168.1.150,2019;database=bsiasset; user id=sa;password=AMNDev@2019;TrustServerCertificate=True",
                PathConfig.BaseURI: "value",
            }

```

# Test Mode
```yml
jobs:
  sample-job:
    runs-on: my-server
    env:
      DOTNET_INSTALL_DIR: /home/gitaction/.dotnet
      DOTNET_ROOT: /home/gitaction/.dotnet
    steps:
      - name: Checkout Repository
        uses: actions/checkout@v3
      - name: Run Test
        uses: azka26/my-test-plugins@main
        with:
          mode: 'test'
          test-path: /backend/tests/UnitTest
          coomand-test:
            dotnet clean &&
            dotnet restore --no-cache &&
            dotnet test
```

# Build Mode
```yml
jobs:
  sample-job:
    runs-on: my-server
    env:
      DOTNET_INSTALL_DIR: /home/gitaction/.dotnet
      DOTNET_ROOT: /home/gitaction/.dotnet
    steps:
      - name: Checkout Repository
        uses: actions/checkout@v3
      - name: Run Test
        uses: azka26/my-test-plugins@main
        with:
          mode: 'test'
          backend-path: /backend/src/PublicApi
          background-path: /backend/src/HangfireJobWorker
          frontend-path: /frontend
          command-backend:
            dotnet clean &&
            dotnet restore --no-cache &&
            dotnet build -r win-x64 PublicApi.csproj --no-restore --configuration Release --self-contained false &&
            dotnet publish -r win-x64 --configuration Release PublicApi.csproj -o ./bin/published --self-contained false
          command-background:
            dotnet clean &&
            dotnet restore --no-cache &&
            dotnet build -r win-x64 PublicApi.csproj --no-restore --configuration Release --self-contained false &&
            dotnet publish -r win-x64 --configuration Release PublicApi.csproj -o ./bin/published --self-contained false

```