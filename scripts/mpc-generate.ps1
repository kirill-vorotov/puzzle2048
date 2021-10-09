function Get-ScriptDirectory { Split-Path $MyInvocation.ScriptName }

$input = Join-Path (Get-ScriptDirectory) "../src/ColorBallsPuzzleUnityProject/Assets/ColorBallsPuzzle.Gameplay/Runtime/Models"
$output = Join-Path (Get-ScriptDirectory) "../src/ColorBallsPuzzleUnityProject/Assets/ColorBallsPuzzle.Gameplay/Runtime/Models/MessagePackGenerated"

dotnet mpc -i $input -o $output