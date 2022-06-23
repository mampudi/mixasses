# Assessment


# Requirements

* .NET Core 3.1

## Installation

1. Install .NET Core 3.1

if you do not have .NET Core download and install in from below

https://dotnet.microsoft.com/en-us/download/dotnet/3.1

2. Clone this repository and cd into the folder:

```bash
git clone https://github.com/mampudi/mixasses.git
```
```bash
cd mixasses/mixasses/mixasses.console
```
```bash
dotnet build
```
```bash
dotnet run
```
or

Hit the run button in Visual Studio

## Test
Change into the test project directory

This can be used as part of CI/CD as part of the release pipeline
```bash
cd ..
```
```bash
cd mixassess.Integration
```
```bash
dotnet test -v n
```
