# EPPlus Temp Folder Porting Plan

## Objective
Port the `ExcelPackage` optional `tempFolder` constructor behavior from `stable-net472` into the current `dotnetport` branch targeting .NET 9.

## Current Repository State
- Main working branch: `dotnetport`
- Current worktree root: `/srv/devshare/projects/EPPlus`
- Existing detached/orphan worktree to clean up: `/tmp/epplus-v1.0.22`
- Desired parallel stable worktree: `/srv/devshare/projects/EPPlus-stable`

## Key Branch Context
- `stable-net472` constructors for `ExcelPackage` accept an optional `tempFolder` argument.
- That argument is used to create temporary files instead of `MemoryStream` instances to reduce memory usage.
- The same capability needs to be ported carefully into `dotnetport`.
- There is branch divergence around encrypted package handling, so this cannot be copied blindly.

## Constraints
- The Linux container cannot run the .NET Framework branch directly, but the code can be read for reference.
- There are already known failing tests in the repository.
- Baseline test failures and their exact messages must be captured before any code changes.
- After implementation, rerun the same tests and compare:
  - Previously passing tests should still pass.
  - Previously failing tests should keep the same failure messages unless the port intentionally changes them.

## Work Plan
1. Inspect and clean up the orphan worktree entry if needed.
2. Create the parallel stable worktree at `/srv/devshare/projects/EPPlus-stable` from `stable-net472`.
3. Record the baseline test state on `dotnetport` before making changes.
4. Inspect `stable-net472` implementation of `ExcelPackage` temp-folder handling and compare it with `dotnetport`.
5. Port the feature to `dotnetport`, with special attention to encrypted package creation/opening paths.
6. Rerun the same tests and compare output to the baseline.
7. Update this plan and the repo progress docs with the final status.

## Current Status
- Completed the worktree setup and cleanup.
- Baseline test state recorded before source changes.
- Port applied on `dotnetport`:
  - `ExcelPackage` constructors now accept an optional `tempFolder` argument.
  - Zip package parts now use temp-folder-backed delete-on-close file streams instead of in-memory part buffers.
  - VBA compound-document save path now stages through a temp stream and copies into the package stream.
  - Temp-folder cleanup moved to `ZipPackage.Dispose()` so repeated saves still work.
- Verification completed on `EPPlusTest.Core.csproj`:
  - Baseline: 12 failed, 1423 passed, 211 skipped, 1646 total.
  - Post-change: 12 failed, 1424 passed, 211 skipped, 1647 total.
  - The failing set matches the baseline; the extra passing test is the new temp-folder regression test.
- Persistent documentation updated:
  - Plan document refreshed with the final state.
  - `PortingProgress.md` updated with the 2026-05-27 entry for this port.

## Completion Status
- Objective achieved on `dotnetport`.
- The `ExcelPackage` temp-folder constructor behavior from `stable-net472` has been ported.
- The known failing test set remains unchanged from baseline, aside from the added passing regression test.
- The branch is ready for later follow-up if encrypted-package handling needs additional parity adjustments.

## Notes For Resumption
- The most likely touched areas are `ExcelPackage` constructors, package stream/temp-file lifecycle, and encryption/opening logic.
- Keep the implementation aligned with current .NET 9 patterns in `dotnetport`; do not transplant .NET Framework code mechanically.
- If a later session resumes here, start by reading this file and the latest baseline test log before editing code.
