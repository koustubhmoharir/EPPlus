# Mono Build and Test Instructions for EPPlus

This document describes how to build EPPlus and run its tests using Mono on Linux.

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
