# EPPlus Porting Project: dotnetport to .NET 9

## Context
This project aims to port EPPlus from the `dotnetport` branch to .NET 9, matching or exceeding the capabilities of the `stable-net472` branch.

- **dotnetport Branch:** Located at `/srv/devshare/projects/EPPlus`. Targets .NET 9. Contains partial work and some divergence.
- **stable-net472 Branch:** Located at `/srv/devshare/projects/EPPlus-stable`. Targets .NET Framework. Needs a Windows environment to build and test.
- **Goal:** Enable `dotnetport` to target .NET 9 and ensure parity with `stable-net472`.

## Strategy: Incremental Porting & Verification
1.  **Branch Comparison:** Perform a comprehensive diff between `dotnetport` and `stable-net472`.
2.  **Documentation:** List all differing methods in `Differences.md` with textual descriptions.
3.  **Progress Tracking:** Maintain `PortingProgress.md` to monitor status.
4.  **Test-Driven Verification:**
    - For each difference, create test cases on the `stable-net472` branch (Mono).
    - Verify coverage using targeted reports.
    - Cherry-pick tests to `dotnetport` (.NET 9).
    - Analyze failures:
        - If it's a bug fix/feature difference: Document in `Differences.md`.
        - If it's a platform difference (Mono vs .NET 9): Fix on `dotnetport`.
5.  **External Assets:** Store XLSX files for tests in a dedicated, non-git-tracked directory organized by test case name.
6.  **Constraint:** Avoid refactoring for testability initially; focus on exercising existing code.

## Workflow Rules
- Always update `PortingProgress.md` and `Differences.md` as work progresses.
- Use `stable-net472` as the source of truth for baseline behavior.
- Validate all changes with tests and coverage.
