# Publica correalucas.com en Azure App Service.
# Uso:  .\deploy.ps1 -App <nombre-de-la-web-app> -ResourceGroup <grupo-de-recursos>
# Requisitos: Node (para Tailwind), .NET 10 SDK, Azure CLI con `az login` hecho.
param(
    [Parameter(Mandatory = $true)] [string] $App,
    [Parameter(Mandatory = $true)] [string] $ResourceGroup
)

$ErrorActionPreference = 'Stop'
Set-Location $PSScriptRoot

Write-Host '1/4 Compilando CSS (Tailwind)...'
npm run css
if (-not $?) { throw 'Falló la compilación del CSS.' }

Write-Host '2/4 Publicando .NET en modo Release...'
if (Test-Path publish) { Remove-Item publish -Recurse -Force -Confirm:$false }
dotnet publish src/Portfolio -c Release -o publish
if (-not $?) { throw 'Falló dotnet publish.' }

Write-Host '3/4 Empaquetando...'
$zip = Join-Path $env:TEMP 'correalucas-deploy.zip'
if (Test-Path $zip) { Remove-Item $zip -Force -Confirm:$false }
# tar (incluido en Windows 10/11) guarda las rutas con "/". Compress-Archive usa "\" y el servidor Linux no las acepta.
& "$env:SystemRoot\System32\tar.exe" -a -c -f $zip -C publish .
if (-not $?) { throw 'Falló el empaquetado.' }

Write-Host "4/4 Subiendo a la web app '$App'..."
az webapp deploy --resource-group $ResourceGroup --name $App --src-path $zip --type zip --clean true
if (-not $?) { throw 'Falló el deploy.' }

Write-Host "Listo: https://$App.azurewebsites.net"
