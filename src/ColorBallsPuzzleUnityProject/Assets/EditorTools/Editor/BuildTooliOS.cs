using System.Linq;
using UnityEditor;

namespace ColorClash.EditorTools
{
    public static class BuildTooliOS
    {
        public static void Build(string appleDeveloperTeamID, string bundleId, int buildNumber, string applicationDisplayName, string outputPath, bool development, params string[] scriptingDefineSymbols)
        {
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, bundleId);
            PlayerSettings.iOS.buildNumber = buildNumber.ToString();
            PlayerSettings.iOS.appleEnableAutomaticSigning = true;
            PlayerSettings.iOS.appleDeveloperTeamID = appleDeveloperTeamID;
            PlayerSettings.iOS.targetDevice = iOSTargetDevice.iPhoneOnly;
            PlayerSettings.iOS.applicationDisplayName = applicationDisplayName;
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.iOS, ApiCompatibilityLevel.NET_Standard_2_0);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, string.Join(";", scriptingDefineSymbols));

            var scenes = EditorBuildSettings.scenes
                .Where(s => s.enabled)
                .Select(s => s.path)
                .ToArray();
            var buildOptions = development ? BuildOptions.Development | BuildOptions.AllowDebugging : BuildOptions.CompressWithLz4;
            BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.iOS, buildOptions);
        }
    }
}