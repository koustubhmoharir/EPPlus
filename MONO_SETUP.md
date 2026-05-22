# Mono Build and Test Instructions for EPPlus

This document describes how to build EPPlus and run its tests using Mono on Linux.

For Windows and Visual Studio coverage commands, see [WINDOWS_CODE_COVERAGE.md](WINDOWS_CODE_COVERAGE.md).

## Prerequisites

- Mono (mono-complete)
- MSTest NuGet packages (installed to `./packages`)
- Test runners (moved to `~/.local/share/dotnet-runners/`)

## Build Command

To build the entire solution:

```bash
xbuild /p:Configuration=Debug EPPlus.sln
```

## Test Command

To run the tests using `vstest.console.exe` under Mono:

```bash
mono /home/vscode/.local/share/dotnet-runners/vstest-runner/Microsoft.TestPlatform.16.11.0/tools/net451/Common7/IDE/Extensions/TestPlatform/vstest.console.exe \
  EPPlusTest/bin/Debug/EPPlusTest.dll \
  /TestAdapterPath:packages/MSTest.TestAdapter.1.1.18/build/_common
```

## Running Individual Tests

To run a specific test class or method, use the `/TestCaseFilter` flag:

**Run a specific test method:**
```bash
mono /home/vscode/.local/share/dotnet-runners/vstest-runner/Microsoft.TestPlatform.16.11.0/tools/net451/Common7/IDE/Extensions/TestPlatform/vstest.console.exe \
  EPPlusTest/bin/Debug/EPPlusTest.dll \
  /TestAdapterPath:packages/MSTest.TestAdapter.1.1.18/build/_common \
  /TestCaseFilter:FullyQualifiedName=EPPlusTest.Address.Addresses
```

**Run all tests in a class:**
```bash
mono /home/vscode/.local/share/dotnet-runners/vstest-runner/Microsoft.TestPlatform.16.11.0/tools/net451/Common7/IDE/Extensions/TestPlatform/vstest.console.exe \
  EPPlusTest/bin/Debug/EPPlusTest.dll \
  /TestAdapterPath:packages/MSTest.TestAdapter.1.1.18/build/_common \
  /TestCaseFilter:FullyQualifiedName~EPPlusTest.Address
```

## Code Coverage

To run tests with code coverage using AltCover and generate a report:

1. **Instrument and Run Tests:**
   ```bash
   # Instrument the assemblies and run the tests
   # Note: Some types are excluded to avoid instrumentation issues on Mono
   mono /home/vscode/.local/share/dotnet-runners/altcover/altcover.8.6.14/tools/net472/AltCover.exe \
     -i EPPlusTest/bin/Debug \
     -o EPPlusTest/bin/Debug/__Instrumented \
     -t "OfficeOpenXml\.Packaging\." --linecover && \
   xvfb-run -a mono /home/vscode/.local/share/dotnet-runners/altcover/altcover.8.6.14/tools/net472/AltCover.exe \
     Runner \
     -r EPPlusTest/bin/Debug/__Instrumented \
     -x mono \
     -- /home/vscode/.local/share/dotnet-runners/vstest-runner/Microsoft.TestPlatform.16.11.0/tools/net451/Common7/IDE/Extensions/TestPlatform/vstest.console.exe \
     EPPlusTest/bin/Debug/__Instrumented/EPPlusTest.dll \
     /TestAdapterPath:packages/MSTest.TestAdapter.1.1.18/build/_common
   ```

2. **Generate Report:**
   ```bash
   mono /home/vscode/.local/share/dotnet-runners/reportgenerator/ReportGenerator.5.2.0/tools/net47/ReportGenerator.exe \
     -reports:coverage.xml \
     -targetdir:coverage_report \
     -reporttypes:"Html;TextSummary"
   ```

The coverage report will be available in the `coverage_report` directory.

### Headless Environments (Linux)

If running in a headless environment, some tests involving `System.Drawing` (like chart or picture tests) may fail or hang with "Authorization required" or GDI+ errors. Use `xvfb-run` to provide a virtual frame buffer:

```bash
xvfb-run -a mono /home/vscode/.local/share/dotnet-runners/vstest-runner/Microsoft.TestPlatform.16.11.0/tools/net451/Common7/IDE/Extensions/TestPlatform/vstest.console.exe \
  EPPlusTest/bin/Debug/EPPlusTest.dll \
  /TestAdapterPath:packages/MSTest.TestAdapter.1.1.18/build/_common
```

## Recent Changes for Mono Compatibility

1.  **Case Sensitivity:** Fixed casing for several source files in `EPPlus.csproj` to match the Linux filesystem (e.g., `Dsum.cs` -> `DSum.cs`).
2.  **Target Framework:** Removed `TargetFrameworkProfile` (Client Profile) from project files to avoid assembly resolution issues on Mono.
3.  **Test Framework:** Updated `EPPlusTest` to use NuGet-based MSTest instead of GAC-dependent versions.
4.  **Pathing:** Fixed hardcoded Windows "Desktop" paths in `ValidationTestBase.cs` to use `Path.GetTempPath()`.
