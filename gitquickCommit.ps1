# git-commit-staged.ps1

# Get git status
$gitStatus = git status --porcelain

if ($gitStatus) {
    $stagedFiles = @()
    
    foreach ($line in $gitStatus) {
        $status = $line.Substring(0, 2)
        
        # Check if file is staged (first character is not space)
        if ($status[0] -ne ' ') {
            $fileName = $line.Substring(3)
            $stagedFiles += $fileName
        }
    }
    
    if ($stagedFiles.Count -gt 0) {
        $commitMessage = "Staged changes: $($stagedFiles -join ' ')"
        
        Write-Host "Staged files: $($stagedFiles -join ', ')"
        
        # Commit without staging (files are already staged)
        git commit -m $commitMessage
        
        if ($LASTEXITCODE -eq 0) {
            Write-Host "Commit completed successfully."
        } else {
            Write-Host "Error: Commit failed."
            exit 1
        }
    } else {
        Write-Host "No staged changes to commit."
        Write-Host ""
        Write-Host "Use 'git add' to stage files first."
        Write-Host "Current changes:"
        git status --short
    }
} else {
    Write-Host "No changes detected."
}