const fs = require('fs');
const path = require('path');

// Paths to reports
const RELEASED_PATH = path.join(__dirname, 'stable-released-report.json');
const NET472_PATH = path.join(__dirname, 'stable-net472-report.json');
const PORT_PATH = path.join(__dirname, 'dotnetport-report.json');

// Output paths
const CSV_PATH = path.join(__dirname, 'three-way-comparison.csv');
const MD_PATH = path.join(__dirname, 'three-way-comparison.md');

if (!fs.existsSync(RELEASED_PATH)) {
    console.error(`Error: ${RELEASED_PATH} not found.`);
    process.exit(1);
}
if (!fs.existsSync(NET472_PATH)) {
    console.error(`Error: ${NET472_PATH} not found.`);
    process.exit(1);
}
if (!fs.existsSync(PORT_PATH)) {
    console.error(`Error: ${PORT_PATH} not found.`);
    process.exit(1);
}

// Load reports and strip BOM if present
function loadReport(filePath) {
    const raw = fs.readFileSync(filePath, 'utf8');
    return JSON.parse(raw.replace(/^\uFEFF/, ''));
}

const releasedTests = loadReport(RELEASED_PATH);
const net472Tests = loadReport(NET472_PATH);
const portTests = loadReport(PORT_PATH);

// Helper to normalize outcome
function normalizeOutcome(outcome) {
    if (!outcome) return 'Missing';
    if (outcome === 'NotExecuted') return 'Skipped';
    return outcome;
}

// Maps to hold test outcomes: key is "ClassName|TestName"
const releasedMap = new Map();
const net472Map = new Map();
const portMap = new Map();
const allKeys = new Set();

releasedTests.forEach(t => {
    const key = `${t.ClassName}|${t.TestName}`;
    releasedMap.set(key, normalizeOutcome(t.Outcome));
    allKeys.add(key);
});

net472Tests.forEach(t => {
    const key = `${t.ClassName}|${t.TestName}`;
    net472Map.set(key, normalizeOutcome(t.Outcome));
    allKeys.add(key);
});

portTests.forEach(t => {
    const key = `${t.ClassName}|${t.TestName}`;
    portMap.set(key, normalizeOutcome(t.Outcome));
    allKeys.add(key);
});

// Compare results
const comparisonResults = [];
const stats = {
    totalUnique: allKeys.size,
    releasedTotal: releasedTests.length,
    net472Total: net472Tests.length,
    portTotal: portTests.length,
    
    // stable-net472 -> dotnetport transition stats
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

    const relOutcome = releasedMap.get(key) || 'Missing';
    const netOutcome = net472Map.get(key) || 'Missing';
    const portOutcome = portMap.get(key) || 'Missing';

    // Transition type (comparing stable-net472 to dotnetport)
    let transitionType = 'Unchanged';
    if (netOutcome === 'Passed' && portOutcome === 'Failed') transitionType = 'Regression (Passed -> Failed)';
    else if (netOutcome === 'Passed' && portOutcome === 'Skipped') transitionType = 'Regression (Passed -> Skipped)';
    else if (netOutcome === 'Passed' && portOutcome === 'Missing') transitionType = 'Regression (Passed -> Missing)';
    else if (netOutcome === 'Failed' && portOutcome === 'Passed') transitionType = 'Improvement (Failed -> Passed)';
    else if (netOutcome === 'Skipped' && portOutcome === 'Passed') transitionType = 'Improvement (Skipped -> Passed)';
    else if (netOutcome === 'Missing' && portOutcome === 'Passed') transitionType = 'Improvement (New Passed)';
    else if (netOutcome === 'Failed' && portOutcome === 'Skipped') transitionType = 'Change (Failed -> Skipped)';
    else if (netOutcome === 'Skipped' && portOutcome === 'Failed') transitionType = 'Change (Skipped -> Failed)';
    else if (netOutcome === 'Missing' && portOutcome === 'Failed') transitionType = 'Change (New Failed)';
    else if (netOutcome === 'Missing' && portOutcome === 'Skipped') transitionType = 'Change (New Skipped)';
    else if (netOutcome === 'Failed' && portOutcome === 'Missing') transitionType = 'Change (Failed -> Missing)';
    else if (netOutcome === 'Skipped' && portOutcome === 'Missing') transitionType = 'Change (Skipped -> Missing)';

    // Update transition stats
    const netLower = netOutcome.toLowerCase();
    const portLower = portOutcome.toLowerCase();
    const statKey = `${netLower}_to_${portLower}`;
    if (stats[statKey] !== undefined) {
        stats[statKey]++;
    }

    comparisonResults.push({
        className,
        testName,
        released: relOutcome,
        net472: netOutcome,
        dotnetport: portOutcome,
        transitionType
    });
});

// Sort results by Class name then Test name
comparisonResults.sort((a, b) => {
    const classCompare = a.className.localeCompare(b.className);
    if (classCompare !== 0) return classCompare;
    return a.testName.localeCompare(b.testName);
});

// Write CSV
const csvHeaders = 'Class,Test,stable-released,stable-net472,dotnetport,TransitionFromNet472ToNet9\n';
const csvRows = comparisonResults.map(r => {
    const c = `"${r.className.replace(/"/g, '""')}"`;
    const t = `"${r.testName.replace(/"/g, '""')}"`;
    return `${c},${t},${r.released},${r.net472},${r.dotnetport},"${r.transitionType}"`;
}).join('\n');

fs.writeFileSync(CSV_PATH, csvHeaders + csvRows, 'utf8');
console.log(`Wrote CSV to ${CSV_PATH}`);

// Generate Markdown
let md = `# EPPlus Three-Way Test Comparison Report\n\n`;
md += `This report compares test results across three branches: **stable-released** (older Framework), **stable-net472** (.NET Framework 4.7.2 baseline), and **dotnetport** (.NET 9 port).\n\n`;

md += `## Branch Test Summary Counts\n\n`;
md += `| Branch | Passed | Failed | Skipped | Total Tests |\n`;
md += `| :--- | :---: | :---: | :---: | :---: |\n`;
md += `| **stable-released** | 899 | 187 | 166 | 1,252 |\n`;
md += `| **stable-net472** | 1,144 | 209 | 170 | 1,523 |\n`;
md += `| **dotnetport (.NET 9)** | 1,408 | 7 | 211 | 1,626 |\n\n`;

md += `## Porting Transition Stats (stable-net472 ➡️ dotnetport .NET 9)\n\n`;
md += `| Transition Category | Metric | Count |\n`;
md += `| :--- | :--- | :---: |\n`;
md += `| **Overall** | **Total Unique Test Cases** | **${stats.totalUnique}** |\n`;
md += `| **Consistency** | Unchanged (Passed -> Passed) | ${stats.passed_to_passed} |\n`;
md += `| | Unchanged (Failed -> Failed) | ${stats.failed_to_failed} |\n`;
md += `| | Unchanged (Skipped -> Skipped) | ${stats.skipped_to_skipped} |\n`;
md += `| **Regressions** | **Regressions (Passed -> Failed)** | <span style="color:red">**${stats.passed_to_failed}**</span> |\n`;
md += `| | Regressions (Passed -> Skipped) | ${stats.passed_to_skipped} |\n`;
md += `| | Regressions (Passed -> Missing) | ${stats.passed_to_missing} |\n`;
md += `| **Improvements** | **Improvements (Failed -> Passed)** | <span style="color:green">**${stats.failed_to_passed}**</span> |\n`;
md += `| | Improvements (Skipped -> Passed) | ${stats.skipped_to_passed} |\n`;
md += `| | Improvements (New Passed in .NET 9) | ${stats.missing_to_passed} |\n`;
md += `| **New Tests** | New Failed in .NET 9 | ${stats.missing_to_failed} |\n`;
md += `| | New Skipped in .NET 9 | ${stats.missing_to_skipped} |\n`;
md += `| **Removals** | Old Failed Missing in .NET 9 | ${stats.failed_to_missing} |\n`;
md += `| | Old Skipped Missing in .NET 9 | ${stats.skipped_to_missing} |\n`;
md += `| **Other transitions** | Failed -> Skipped | ${stats.failed_to_skipped} |\n`;
md += `| | Skipped -> Failed | ${stats.skipped_to_failed} |\n\n`;

md += `## Detailed Three-Way Comparison Table\n\n`;
md += `| Class | Test Name | stable-released | stable-net472 | dotnetport (.NET 9) | Transition (net472 ➡️ .NET 9) |\n`;
md += `| :--- | :--- | :---: | :---: | :---: | :--- |\n`;

function formatOutcome(outcome) {
    if (outcome === 'Passed') return '🟢 Passed';
    if (outcome === 'Failed') return '🔴 Failed';
    if (outcome === 'Skipped') return '🟡 Skipped';
    return '⚪ Missing';
}

comparisonResults.forEach(r => {
    let transLabel = r.transitionType;
    if (transLabel.startsWith('Regression')) {
        transLabel = `⚠️ **${transLabel}**`;
    } else if (transLabel.startsWith('Improvement')) {
        transLabel = `🎉 **${transLabel}**`;
    }

    md += `| ${r.className} | ${r.testName} | ${formatOutcome(r.released)} | ${formatOutcome(r.net472)} | ${formatOutcome(r.dotnetport)} | ${transLabel} |\n`;
});

fs.writeFileSync(MD_PATH, md, 'utf8');
console.log(`Wrote three-way comparison markdown to ${MD_PATH}`);
