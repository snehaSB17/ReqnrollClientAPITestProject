# QA API Automation

## Tech Stack
- .NET 8
- C#
- RestSharp 106.15.0
- NUnit
- FluentAssertions
- Reqnroll (Specflow Nunit 3.2.0)

## API Under Test
https://restful-api.dev/

## How to Run Tests
1. Clone the repo (url - https://github.com/snehaSB17/ReqnrollClientAPITestProject)
2. Open solution in Visual Studio
3. Restore NuGet packages
4. Run tests via Test Explorer under Test tab or:
   Open Terminal under view tab and Enter command "dotnet test" to run all test cases 
5. Test result report will be generated under folder /bin/Debug/net8.0/report/living_doc.html . 

## CI Pipeline

This project uses **GitHub Actions** for continuous integration.
[![CI](https://github.com/snehaSB17/ReqnrollClientAPITestProject/actions/workflows/ci.yml/badge.svg)](https://github.com/snehaSB17/ReqnrollClientAPITestProject/actions/workflows/ci.yml)

### 🔄 Workflow
- Runs automatically on every **commit** or **pull request** to the `master` branch.
- Builds the project using .NET.
- Executes all automated tests.
- Publishes test results as artifacts in the Actions tab.

### 📂 Workflow File
The pipeline is defined in `.github/workflows/ci.yml`.

```yaml
name: CI Pipeline
