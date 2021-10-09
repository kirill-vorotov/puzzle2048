using System.Linq;
using UnityEditor;

namespace ColorClash.EditorTools
{
    public static class BuildToolAndroid
    {
        public static void Build(string bundleId, int bundleVersionCode, string outputPath, bool development, string keystoreName, string keystorePass, string keyaliasName, string keyaliasPass, params string[] scriptingDefineSymbols)
        {
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, bundleId);
            PlayerSettings.Android.bundleVersionCode = bundleVersionCode;
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
            PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel30;
            PlayerSettings.Android.useCustomKeystore = true;
            PlayerSettings.Android.keystoreName = keystoreName;
            PlayerSettings.Android.keystorePass = keystorePass;
            PlayerSettings.Android.keyaliasName = keyaliasName;
            PlayerSettings.Android.keyaliasPass = keyaliasPass;
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, ApiCompatibilityLevel.NET_Standard_2_0);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, string.Join(";", scriptingDefineSymbols));

            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            EditorUserBuildSettings.buildAppBundle = true;
            EditorUserBuildSettings.androidBuildType = development ? AndroidBuildType.Debug : AndroidBuildType.Release;
            
            var scenes = EditorBuildSettings.scenes
                .Where(s => s.enabled)
                .Select(s => s.path)
                .ToArray();
            var buildOptions = development ? BuildOptions.Development | BuildOptions.AllowDebugging : BuildOptions.CompressWithLz4;
            BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.Android, buildOptions);
        }
    }
}