My realization of Myob take-home project for calculating salary

**Prerequisites**
Please, install .Net Core 1.1.2 runtime from here [https://www.microsoft.com/net/download/core#/runtime](https://www.microsoft.com/net/download/core#/runtime)

**Build and run** 
Go to src/MyobChallenge folder
For build: 
1. dotnet restore
2. dotnet build

For run:
1. Build first (if not built)
2. dotnet run %inputsFile% %outputsFile%

You need to pass inputs csv file with data. Also desired name of the output csv file should be passed

You can find inputs example in file ['inputs.csv'](src/MyobChallenge/inputs.csv)

Inputs format: FirstName,LastName,Salary,Super%,01 Month - LasDayOfMonth Month

Outputs format: FullName,01 Month - LasDayOfMonth Month,Gross,Tax,Net,Super

**Test**
To run unit tests:

1. Go to src/MyobChallenge.Tests folder
2. dotnet restore
3. dotnet build
4. dotnet test