# Windows Code Coverage

This documents the commands that work in this repository on Windows with Visual Studio tooling.

## Prerequisites

- Visual Studio 2022 with MSBuild and the VSTest platform installed.
- The repo's NuGet packages restored under `packages\`.
- The local `Microsoft.CodeCoverage` package cache available at `C:\Users\koust\.nuget\packages\microsoft.codecoverage\17.12.0`.

## Build

Build the test project with the Visual Studio MSBuild executable, not `dotnet build`:

```powershell
& 'C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe' `
  'C:\Work\EPPlusSK\EPPlusTest\EPPlusTest.csproj' `
  /p:Configuration=Debug `
  /p:Platform=AnyCPU `
  /t:Build `
  /m
```

## Run Coverage

For this repo, the coverage collector needs the MSTest adapter and the `Microsoft.CodeCoverage` package path on `TestAdapterPath`. The test output also needs the coverage shim DLL beside `EPPlusTest.dll`.

```powershell
Copy-Item `
  'C:\Users\koust\.nuget\packages\microsoft.codecoverage\17.12.0\lib\net462\Microsoft.VisualStudio.CodeCoverage.Shim.dll' `
  'C:\Work\EPPlusSK\EPPlusTest\bin\Debug\Microsoft.VisualStudio.CodeCoverage.Shim.dll' `
  -Force

& 'C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe' `
  'C:\Work\EPPlusSK\EPPlusTest\bin\Debug\EPPlusTest.dll' `
  /TestAdapterPath:'C:\Work\EPPlusSK\packages\MSTest.TestAdapter.1.1.18\build\_common;C:\Users\koust\.nuget\packages\microsoft.codecoverage\17.12.0\build\netstandard2.0' `
  /TestCaseFilter:"ClassName=EPPlusTest.WorkSheetTest" `
  /Collect:"Code Coverage;Format=Cobertura" `
  /ResultsDirectory:'C:\Work\EPPlusSK\TestResults\CoverageRun'
```

To run just the background-image test, narrow the filter:

```powershell
/TestCaseFilter:"Name=SetBackground"
```

## Find The Report

The collector writes a Cobertura attachment into the results directory. Find it with:

```powershell
Get-ChildItem 'C:\Work\EPPlusSK\TestResults\CoverageRun' -Recurse -Filter *.cobertura.xml
```

To inspect coverage for `ExcelBackgroundImage.cs`, use:

```powershell
$report = Get-ChildItem 'C:\Work\EPPlusSK\TestResults\CoverageRun' -Recurse -Filter *.cobertura.xml | Select-Object -First 1
Select-String -Path $report.FullName -SimpleMatch -Pattern 'filename="C:\Work\EPPlusSK\EPPlus\ExcelBackgroundImage.cs"' -Context 0,40
```

## Notes

- `dotnet build` does not work cleanly for this legacy .NET Framework test project.
- The coverage run can still produce a report even if unrelated tests fail, so use a focused test filter when validating changed lines.
