# Running Playwright NUnit SpecFlow Tests Locally

## Prerequisites

Before you start, ensure you have the following installed:

- **.NET SDK**: [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet) (version 8.0 or later).
- **Node.js**: [Download Node.js](https://nodejs.org/) (version 18.0 or later).
- **Playwright**: Install Playwright globally using npm:
  ```bash
  npm install -g playwright

- ## Clone the repository and navigate to the project directory:

  ```bash
    git clone <repository-url>
    cd <repository-directory>
  
- ## Install Playwright Dependencies:

  ```bash
    npx playwright install

- Build the project so the playwright.ps1 is available inside the bin directory:
  ```bash
  dotnet build

- Install required browsers. This example uses net8.0, if you are using a different version of .NET you will need to adjust the command and change net8.0 to your version. You need PowerShell to run this
  ```bash
  pwsh bin/Debug/net8.0/playwright.ps1 install

- For generating allure report - go into the \bin\Debug\net6.0 directory and run this command
  ```bash
  allure serve allure-results --clear

# Project Structure
```bash
<root-directory>/
│
├── PangoTest/
│   ├── API/
│   │   ├── GraphApi.cs
│   ├── Database/
|       └── DBConnection.cs
│   ├── Drivers/
│   │   └── Driver.cs
│   ├── Features/
│   │   ├── API.feature
│   │   ├── Navigation.feature
│   │   ├── Products.feature
│   │   └── SignIn.feature
│   ├── Hooks/
│   │   └── Hooks.cs
│   ├── Pages/
│   │   ├── BasePage.cs
│   │   ├── Products.cs
│   │   └── SignInSignUp.cs
│   ├── Reports/
│   │   └── Screenshots/
│   ├── Steps/
│   │   ├── ApiSteps.cs
│   │   ├── BaseSteps.cs
│   │   ├── ProductsSteps.cs
│   │   └── SignInSteps.cs
│   ├── allureConfig.json
│   ├── allureConfig.Template.json
│   ├── specflow.json
│   ├── README.md
│   └── PangoTest.csproj
│
├── .github/
│   └── workflows/
│       └── ci.yml
├── .gitignore
└── README.md

