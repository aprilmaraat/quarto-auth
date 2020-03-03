set-location "D:\Projects\quarto-auth\Quarto.Auth.Api"
$launchProfile = 'LocalHTTPS';
dotnet user-secrets list | ForEach-Object { [environment]::SetEnvironmentVariable("APPSETTING_"+$_.Substring(0,$_.IndexOf("=")),$_.Substring($_.IndexOf("=")+1));}
$launchSettings = Get-Content .\Properties\launchSettings.json | ConvertFrom-Json;
[environment]::SetEnvironmentVariable("ASPNETCORE_URLS", ($launchSettings | Select-Object -ExpandProperty "profiles" | Select-Object -ExpandProperty $launchProfile | Select-Object -ExpandProperty "applicationUrl"));
[environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", ($launchSettings | Select-Object -ExpandProperty "profiles" | Select-Object -ExpandProperty $launchProfile | Select-Object -ExpandProperty "environmentVariables" | Select-Object -ExpandProperty "ASPNETCORE_ENVIRONMENT"));
[environment]::SetEnvironmentVariable("ASPNETCORE_LAUNCHPROFILE", ($launchSettings | Select-Object -ExpandProperty "profiles" | Select-Object -ExpandProperty $launchProfile | Select-Object -ExpandProperty "environmentVariables" | Select-Object -ExpandProperty "ASPNETCORE_LAUNCHPROFILE"));
dotnet run --Configuration Debug --launch-profile ([environment]::GetEnvironmentVariable("ASPNETCORE_LAUNCHPROFILE"))