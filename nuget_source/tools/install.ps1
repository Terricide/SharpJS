param($installPath, $toolsPath, $package, $project)

Write-Host ("ExaPhaser.WebForms is configuring " + $project.ProjectName)

# Remove all references of object
$project.Object.References | foreach-object {
    if ($_.Identity.ToLower().StartsWith("system") -or $_.Identity.ToLower().StartsWith("microsoft")) {
        Write-Host ("Removing Reference to " + $_.Identity)
        $_.Remove()
    }
}

Write-Host ("ExaPhaser.WebForms installation was successful! :D")