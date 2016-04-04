$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'

Write-Host "Root is $root"

$version = [System.Reflection.Assembly]::LoadFile("$root\src\Gogs.Dnx\bin\Debug\Gogs.Dnx.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\src\Gogs.Dnx\Gogs.Dnx.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\src\Gogs.Dnx\Gogs.Dnx.compiled.nuspec

& $root\NuGet\NuGet.exe pack $root\src\Gogs.Dnx\Gogs.Dnx.csproj -IncludeReferencedProjects