using System;
using System.IO;
using CommandLine;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace ColorClash.EditorTools
{
    public static class BuildTool
    {
        private class Options
        {
            [Option("out", Required = false)]
            public string OutputPath { get; set; } = "";

            [Option("buildTarget", Required = true)]
            public string BuildTarget { get; set; } = "Android";

            [Option("dev", Required = false)]
            public bool Development { get; set; } = true;
        }

        private static BuildToolSettings _settings = BuildToolSettings.Default;
        // private const string companyName = "Company name";
        // private const string productName = "ProductName";
        // public const string BundleId = "com.CompanyName.ProductName";
        // public const string Version = "0.1.0";
        // public const int BuildNumber = 1;
        // public const int BundleVersionCode = 1;
        // public const string AppleDeveloperTeamID = "LPQDBL5VFM";
        // public static readonly string[] ScriptingDefineSymbols = new[]
        // {
        //     "UNITASK_DOTWEEN_SUPPORT",
        // };

        private const string iOSDevBuildPath = "../Build/iOS/Dev/XCode";
        private const string iOSreleaseBuildPath = "../Build/iOS/Release/XCode";
        private const string androidDevBuildPath = "../Build/Android/Dev/Build.aab";
        private const string androidreleaseBuildPath = "../Build/Android/Release/Build.aab";

        public static void BuildFromCommandLine()
        {
            var cmdArgs = Environment.GetCommandLineArgs();
            Parser.Default.ParseArguments<Options>(cmdArgs).WithParsed<Options>(o =>
            {
                var outputPath = o.OutputPath;
                if (Enum.TryParse(o.BuildTarget, out BuildTarget buildTarget))
                {
                    switch (buildTarget)
                    {
                        case BuildTarget.iOS:
                        {
                            if (string.IsNullOrEmpty(outputPath))
                            {
                                outputPath = GetOutputPath(BuildTarget.iOS, o.Development);
                            }
                            Build(BuildTarget.iOS, outputPath, o.Development);
                            break;
                        }
                        case BuildTarget.Android:
                        {
                            if (string.IsNullOrEmpty(outputPath))
                            {
                                outputPath = GetOutputPath(BuildTarget.Android, o.Development);
                            }
                            Build(BuildTarget.Android, outputPath, o.Development);
                            break;
                        }
                    }
                }
            });
        }
        
        public static void BuildIOSDev()
        {
            var outputPath = GetOutputPath(BuildTarget.iOS, true);
            Build(BuildTarget.iOS, outputPath, true);
        }
        
        public static void BuildIOSRelease()
        {
            var outputPath = GetOutputPath(BuildTarget.iOS, false);
            Build(BuildTarget.iOS, outputPath, false);
        }
        
        public static void BuildAndroidDev()
        {
            var outputPath = GetOutputPath(BuildTarget.Android, true);
            Build(BuildTarget.Android, outputPath, true);
        }
        
        public static void BuildAndroidRelease()
        {
            var outputPath = GetOutputPath(BuildTarget.Android, false);
            Build(BuildTarget.Android, outputPath, false);
        }

        public static void CreateDefaultBuiltToolSettings()
        {
            try
            {
                var settings = BuildToolSettings.Default;
                var text = JsonConvert.SerializeObject(settings, Formatting.Indented);
                if (!File.Exists(Path.Combine(Application.dataPath, "BuildToolSettings.json")))
                {
                    File.WriteAllText(Path.Combine(Application.dataPath, "BuildToolSettings.json"), text);
                }
                else
                {
                    File.Copy(Path.Combine(Application.dataPath, "BuildToolSettings.json"), Path.Combine(Application.dataPath, "BuildToolSettings_backup.json"));
                    File.WriteAllText(Path.Combine(Application.dataPath, "BuildToolSettings.json"), text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void Build(BuildTarget buildTarget, string outputPath, bool development)
        {
            var text = File.ReadAllText(Path.Combine(Application.dataPath, "BuildToolSettings.json"));
            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    _settings = JsonConvert.DeserializeObject<BuildToolSettings>(text);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    return;
                }
            }
            
            PlayerSettings.SplashScreen.showUnityLogo = false;
            PlayerSettings.bundleVersion = _settings.BundleVersion;
            PlayerSettings.companyName = _settings.CompanyName;
            PlayerSettings.productName = _settings.ProductName;
            PlayerSettings.gcIncremental = true;

            EditorUserBuildSettings.development = development;
            EditorUserBuildSettings.allowDebugging = development;
            
            switch (buildTarget)
            {
                case BuildTarget.iOS:
                {
                    BuildTooliOS.Build(_settings.AppleDeveloperTeamID, _settings.BundleId, _settings.BuildNumber,
                        _settings.ApplicationDisplayName,
                        outputPath, development, _settings.ScriptingDefineSymbols);
                    break;
                }
                case BuildTarget.Android:
                {
                    BuildToolAndroid.Build(_settings.BundleId, _settings.BundleVersionCode, outputPath, development,
                        _settings.KeystoreName, _settings.KeystorePass, _settings.KeyaliasName, _settings.KeyaliasPass,
                        _settings.ScriptingDefineSymbols);
                    break;
                }
                default:
                {
                    Debug.LogError($"{nameof(BuildTool)}.{nameof(Build)} {buildTarget.ToString()} is not supported");
                    break;
                }
            }
        }

        private static string GetOutputPath(BuildTarget buildTarget, bool development)
        {
            switch (buildTarget)
            {
                case BuildTarget.iOS:
                {
                    return Path.Combine(Application.dataPath, development ? iOSDevBuildPath : iOSreleaseBuildPath);
                }
                case BuildTarget.Android:
                {
                    return Path.Combine(Application.dataPath, development ? androidDevBuildPath : androidreleaseBuildPath);
                }
                default:
                {
                    return Path.Combine(Application.dataPath, "../Build/UnknownPlatform");
                }
            }
        }
    }
}