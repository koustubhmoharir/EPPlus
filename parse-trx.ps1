param(
    [string]$TrxPath,
    [string]$JsonPath
)

if (-not (Test-Path $TrxPath)) {
    Write-Error "TRX file not found: $TrxPath"
    exit 1
}

[xml]$xml = Get-Content $TrxPath
$testDefs = @{}
if ($xml.TestRun.TestDefinitions -and $xml.TestRun.TestDefinitions.UnitTest) {
    foreach ($ut in $xml.TestRun.TestDefinitions.UnitTest) {
        $testDefs[$ut.id] = $ut.TestMethod.className
    }
}

$results = @()
if ($xml.TestRun.Results -and $xml.TestRun.Results.UnitTestResult) {
    $results = foreach ($r in $xml.TestRun.Results.UnitTestResult) {
        $cls = $testDefs[$r.testId]
        if (-not $cls) {
            $cls = "UnknownClass"
        }
        [PSCustomObject]@{
            ClassName = $cls
            TestName  = $r.testName
            Outcome   = $r.outcome
        }
    }
}

$results | ConvertTo-Json -Depth 5 | Out-File -FilePath $JsonPath -Encoding utf8
Write-Host "Parsed $TrxPath to $JsonPath successfully."
