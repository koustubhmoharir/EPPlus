const fs = require('fs');
const path = require('path');

// Paths to reports
const RELEASED_PATH = path.join(__dirname, 'stable-released-report.json');
const NET472_PATH = path.join(__dirname, 'stable-net472-report.json');

// Output paths
const CSV_PATH = path.join(__dirname, 'test-comparison.csv');
const MD_PATH = path.join(__dirname, 'test-comparison.md');

if (!fs.existsSync(RELEASED_PATH)) {
    console.error(`Error: ${RELEASED_PATH} not found.`);
    process.exit(1);
}
if (!fs.existsSync(NET472_PATH)) {
    console.error(`Error: ${NET472_PATH} not found.`);
    process.exit(1);
}

// Load reports
const releasedTests = JSON.parse(fs.readFileSync(RELEASED_PATH, 'utf8').replace(/^\uFEFF/, ''));
const net472Tests = JSON.parse(fs.readFileSync(NET472_PATH, 'utf8').replace(/^\uFEFF/, ''));

// Helper to normalize outcome
function normalizeOutcome(outcome) {
    if (!outcome) return 'Missing';
    if (outcome === 'NotExecuted') return 'Skipped';
    return outcome;
}

// Maps to hold test outcomes: key is "ClassName|TestName"
const releasedMap = new Map();
const net472Map = new Map();
const allKeys = new Set();

releasedTests.forEach(t => {
    const key = `${t.ClassName}|${t.TestName}`;
    releasedMap.set(key, { ClassName: t.ClassName, TestName: t.TestName, Outcome: normalizeOutcome(t.Outcome) });
    allKeys.add(key);
});

net472Tests.forEach(t => {
    const key = `${t.ClassName}|${t.TestName}`;
    net472Map.set(key, { ClassName: t.ClassName, TestName: t.TestName, Outcome: normalizeOutcome(t.Outcome) });
    allKeys.add(key);
});

// Compare results
const comparisonResults = [];
const stats = {
    totalUnique: allKeys.size,
    releasedCount: releasedTests.length,
    net472Count: net472Tests.length,
    passed_to_passed: 0,
    passed_to_failed: 0,
    passed_to_skipped: 0,
    passed_to_missing: 0,
    failed_to_passed: 0,
    failed_to_failed: 0,
    failed_to_skipped: 0,
    failed_to_missing: 0,
    skipped_to_passed: 0,
    skipped_to_failed: 0,
    skipped_to_skipped: 0,
    skipped_to_missing: 0,
    missing_to_passed: 0,
    missing_to_failed: 0,
    missing_to_skipped: 0
};

Array.from(allKeys).forEach(key => {
    const parts = key.split('|');
    const className = parts[0];
    const testName = parts[1];

    const relInfo = releasedMap.get(key);
    const netInfo = net472Map.get(key);

    const relOutcome = relInfo ? relInfo.Outcome : 'Missing';
    const netOutcome = netInfo ? netInfo.Outcome : 'Missing';

    let diffType = 'Unchanged';
    if (relOutcome === 'Passed' && netOutcome === 'Failed') diffType = 'Regression (Passed -> Failed)';
    else if (relOutcome === 'Passed' && netOutcome === 'Skipped') diffType = 'Regression (Passed -> Skipped)';
    else if (relOutcome === 'Passed' && netOutcome === 'Missing') diffType = 'Regression (Passed -> Missing)';
    else if (relOutcome === 'Failed' && netOutcome === 'Passed') diffType = 'Improvement (Failed -> Passed)';
    else if (relOutcome === 'Skipped' && netOutcome === 'Passed') diffType = 'Improvement (Skipped -> Passed)';
    else if (relOutcome === 'Missing' && netOutcome === 'Passed') diffType = 'Improvement (New Passed)';
    else if (relOutcome === 'Failed' && netOutcome === 'Skipped') diffType = 'Change (Failed -> Skipped)';
    else if (relOutcome === 'Skipped' && netOutcome === 'Failed') diffType = 'Change (Skipped -> Failed)';
    else if (relOutcome === 'Missing' && netOutcome === 'Failed') diffType = 'Change (New Failed)';
    else if (relOutcome === 'Missing' && netOutcome === 'Skipped') diffType = 'Change (New Skipped)';
    else if (relOutcome === 'Failed' && netOutcome === 'Missing') diffType = 'Change (Failed -> Missing)';
    else if (relOutcome === 'Skipped' && netOutcome === 'Missing') diffType = 'Change (Skipped -> Missing)';

    // Update stats
    const relLower = relOutcome.toLowerCase();
    const netLower = netOutcome.toLowerCase();
    const statKey = `${relLower}_to_${netLower}`;
    if (stats[statKey] !== undefined) {
        stats[statKey]++;
    }

    comparisonResults.push({
        className,
        testName,
        released: relOutcome,
        net472: netOutcome,
        diffType
    });
});

// Sort comparison results for better readability (Class name first, then Test name)
comparisonResults.sort((a, b) => {
    const classCompare = a.className.localeCompare(b.className);
    if (classCompare !== 0) return classCompare;
    return a.testName.localeCompare(b.testName);
});

// Write CSV
const csvHeaders = 'Class,Test,stable-released,stable-net472,ComparisonStatus\n';
const csvRows = comparisonResults.map(r => {
    // Escape quotes and wrap in quotes to handle potential commas
    const c = `"${r.className.replace(/"/g, '""')}"`;
    const t = `"${r.testName.replace(/"/g, '""')}"`;
    return `${c},${t},${r.released},${r.net472},"${r.diffType}"`;
}).join('\n');

fs.writeFileSync(CSV_PATH, csvHeaders + csvRows, 'utf8');
console.log(`Wrote CSV report to ${CSV_PATH}`);

// Generate Markdown
let md = `# EPPlus Test Comparison Report\n\n`;
md += `This report compares test execution results between the **stable-released** branch and the **stable-net472** branch.\n\n`;

md += `## Summary Statistics\n\n`;
md += `| Metric | Count |\n`;
md += `| :--- | :--- |\n`;
md += `| **Total Unique Test Cases** | **${stats.totalUnique}** |\n`;
md += `| Test Cases in **stable-released** | ${stats.releasedCount} |\n`;
md += `| Test Cases in **stable-net472** | ${stats.net472Count} |\n`;
md += `| Unchanged (Passed -> Passed) | ${stats.passed_to_passed} |\n`;
md += `| Unchanged (Failed -> Failed) | ${stats.failed_to_failed} |\n`;
md += `| Unchanged (Skipped -> Skipped) | ${stats.skipped_to_skipped} |\n`;
md += `| **Regressions (Passed -> Failed)** | <span style="color:red">**${stats.passed_to_failed}**</span> |\n`;
md += `| **Regressions (Passed -> Skipped)** | ${stats.passed_to_skipped} |\n`;
md += `| **Regressions (Passed -> Missing)** | ${stats.passed_to_missing} |\n`;
md += `| **Improvements (Failed -> Passed)** | <span style="color:green">**${stats.failed_to_passed}**</span> |\n`;
md += `| **Improvements (Skipped -> Passed)** | ${stats.skipped_to_passed} |\n`;
md += `| **Improvements (New Passed)** | ${stats.missing_to_passed} |\n`;
md += `| New Failed Tests | ${stats.missing_to_failed} |\n`;
md += `| New Skipped Tests | ${stats.missing_to_skipped} |\n`;
md += `| Other Changes | ${stats.failed_to_skipped + stats.skipped_to_failed + stats.failed_to_missing + stats.skipped_to_missing} |\n\n`;

md += `## Detailed Comparison Table\n\n`;
md += `| Class | Test Name | stable-released | stable-net472 | Comparison Status |\n`;
md += `| :--- | :--- | :--- | :--- | :--- |\n`;

comparisonResults.forEach(r => {
    let relLabel = r.released;
    let netLabel = r.net472;
    let statusLabel = r.diffType;

    // Add colored formatting for markdown
    if (r.released === 'Passed') relLabel = '🟢 Passed';
    else if (r.released === 'Failed') relLabel = '🔴 Failed';
    else if (r.released === 'Skipped') relLabel = '🟡 Skipped';
    else if (r.released === 'Missing') relLabel = '⚪ Missing';

    if (r.net472 === 'Passed') netLabel = '🟢 Passed';
    else if (r.net472 === 'Failed') netLabel = '🔴 Failed';
    else if (r.net472 === 'Skipped') netLabel = '🟡 Skipped';
    else if (r.net472 === 'Missing') netLabel = '⚪ Missing';

    if (statusLabel.startsWith('Regression')) {
        statusLabel = `⚠️ **${statusLabel}**`;
    } else if (statusLabel.startsWith('Improvement')) {
        statusLabel = `🎉 **${statusLabel}**`;
    }

    md += `| ${r.className} | ${r.testName} | ${relLabel} | ${netLabel} | ${statusLabel} |\n`;
});

fs.writeFileSync(MD_PATH, md, 'utf8');
console.log(`Wrote Markdown report to ${MD_PATH}`);
