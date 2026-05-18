---
description: Workflow for test-driven verification of branch differences and porting test cases from stable (Mono) to dotnetport (.NET 9)
---

# Workflow: Create Test Cases for Branch Differences

This workflow guides the process of verifying a method/behavior difference identified in `Differences.md` by writing test cases on the `stable` branch (Mono), verifying code coverage, committing the stable branch, and porting/cherry-picking those test cases to the `dotnetport` branch (.NET 9).

---

## // turbo-all

## Step 1: Select the Top Pending Difference
1. Open the [Differences.md](file:///srv/devshare/projects/EPPlus/Differences.md) file.
2. Identify the first row in the table that has a Status of `Pending`.
3. Locate the target class and method(s) referenced in the row.

## Step 2: Implement Test Cases on the Stable Branch (Mono)
1. Switch to the stable branch directory: `/srv/devshare/projects/EPPlus-stable`.
2. Locate the corresponding test class in `EPPlusTest` (e.g., `ExcelRangeBaseTest.cs`, `Address.cs`, or `WorkSheet.cs`). If a suitable test class does not exist, add a new one and register it in `EPPlusTest.csproj`.
3. Write test cases that fully exercise all execution paths and lines of code of the target method(s).
4. Rebuild the stable solution to compile the new tests:
   ```bash
   xbuild /verbosity:minimal /p:Configuration=Debug EPPlus.sln
   ```
5. Run the new tests under Mono using the VSTest console runner:
   ```bash
   mono /home/vscode/.local/share/dotnet-runners/vstest-runner/Microsoft.TestPlatform.16.11.0/tools/net451/Common7/IDE/Extensions/TestPlatform/vstest.console.exe \
     EPPlusTest/bin/Debug/EPPlusTest.dll \
     /TestAdapterPath:packages/MSTest.TestAdapter.1.1.18/build/_common \
     /TestCaseFilter:FullyQualifiedName=EPPlusTest.[TestClass].[TestMethod]
   ```

## Step 3: Verify Code Coverage
1. Instrument the assemblies and run the targeted test cases using AltCover:
   ```bash
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
     /TestAdapterPath:packages/MSTest.TestAdapter.1.1.18/build/_common \
     /TestCaseFilter:FullyQualifiedName=EPPlusTest.[TestClass].[TestMethod]
   ```
2. Generate the coverage report using ReportGenerator:
   ```bash
   mono /home/vscode/.local/share/dotnet-runners/reportgenerator/ReportGenerator.5.2.0/tools/net47/ReportGenerator.exe \
     -reports:coverage.xml \
     -targetdir:coverage_report \
     -reporttypes:"Html;TextSummary"
   ```
3. Open `coverage_report/Summary.txt` (or HTML files) and verify that the target method has 100% (or maximum possible) code coverage.

## Step 4: Commit to Stable and Cherry-Pick to dotnetport
1. Once all tests pass and coverage is verified, check in the changes on the `stable` branch:
   ```bash
   git add EPPlusTest/[TestFile].cs
   git commit -m "Add tests for [ClassName].[MethodName]"
   ```
2. Retrieve the commit hash of your new commit:
   ```bash
   git rev-parse HEAD
   ```
3. Navigate to the `dotnetport` workspace directory: `/srv/devshare/projects/EPPlus`.
4. Cherry-pick the stable commit:
   ```bash
   git cherry-pick [COMMIT_HASH]
   ```
5. Resolve any compilation or merge conflicts if they arise.

## Step 5: Verify on dotnetport (.NET 9)
1. Build the .NET 9 test project:
   ```bash
   dotnet build EPPlusTest/EPPlusTest.Core.csproj
   ```
2. Run the newly ported tests:
   ```bash
   dotnet test EPPlusTest/EPPlusTest.Core.csproj --filter "FullyQualifiedName=EPPlusTest.[TestClass].[TestMethod]"
   ```
3. If the tests fail:
   - **Feature / Bugfix Divergence**: Document the behavioral differences within the test file itself.
   - **Platform Difference (Mono vs .NET 9)**: Fix the implementation inside the `dotnetport` branch to restore parity. Code in the `stable` branch should generally remain unchanged.

## Step 6: Update Tracking Documentation
1. Edit [Differences.md](file:///srv/devshare/projects/EPPlus/Differences.md):
   - Locate the row for the verified difference.
   - Replace the `Pending` status with the name of the test cases file (e.g., `ExcelRangeBaseTest.cs`).
2. Edit [PortingProgress.md](file:///srv/devshare/projects/EPPlus/PortingProgress.md):
   - Log the verified task and date in the Task Log section.
3. Commit and push the document updates on the `dotnetport` branch:
   ```bash
   git commit -am "Update Differences.md and PortingProgress.md with [ClassName].[MethodName] status"
   ```
4. Both branches should be committed and the working trees should be clean.