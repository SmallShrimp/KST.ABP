# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    "Organizations"
	#"ABPExtension"
)

# List of projects
$projects = (

    # Organizations
	"Organizations/src/KST.ABP.Organizations.Domain.Shared",
	"Organizations/src/KST.ABP.Organizations.Domain",    
	"Organizations/src/KST.ABP.Organizations.Application.Contracts",
	"Organizations/src/KST.ABP.Organizations.Application",	
	"Organizations/src/KST.ABP.Organizations.EntityFrameworkCore",
	"Organizations/src/KST.ABP.Organizations.HttpApi",
	"Organizations/src/KST.ABP.Organizations.HttpApi.Client",
	"Organizations/src/KST.ABP.Organizations.MongoDB",
	"Organizations/src/KST.ABP.Organizations.Web",
	
    # ABPExtension
	"ABPExtension/KST.ABP.SignalR"
)