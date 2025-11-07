# git-commit-auto.ps1

$gitStatus = git status --porcelain

if ($gitStatus) {
    $files = $gitStatus | ForEach-Object { $_.Substring(3) }
    
    git add -A
    git commit -m "Changes: $($files -join ' ')"
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Committed $($files.Count) files"
    } else {
        Write-Host "Commit failed"
        exit 1
    }
} else {
    Write-Host "No changes to commit"
}