using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

namespace ColorClash.EditorTools
{
    public static class BuildPostProcessoriOS
    {
        private const string infoPlistFileName = "Info.plist";
        private const string enableBitcode = "ENABLE_BITCODE";
        // ReSharper disable once InconsistentNaming
        private const string SKAdNetworkItems = "SKAdNetworkItems";
        // ReSharper disable once InconsistentNaming
        private const string SKAdNetworkIdentifier = "SKAdNetworkIdentifier";
        private const string unityFramework = "UnityFramework";
        private const string alwaysEmbedSwiftStandardLibraries = "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES";
        
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS)
            {
                return;
            }
            
#if UNITY_IOS            

            {
                var infoPlistFilePath = Path.Combine(pathToBuiltProject, infoPlistFileName);
                var plist = new PlistDocument();
                plist.ReadFromFile(infoPlistFilePath);
                
                var skAdNetworkItems = plist.root.CreateArray(SKAdNetworkItems);
                
                // Uncomment and add real SKAdN identifiers for ad networks.
                // skAdNetworkItems.AddDict().SetString("SKAdNetworkIdentifier", "0123456789.skadnetwork");
                
                plist.WriteToFile(infoPlistFilePath);
            }

            {
                var pbxProjectFile = PBXProject.GetPBXProjectPath(pathToBuiltProject);
                var pbxProject = new PBXProject();
                pbxProject.ReadFromFile(pbxProjectFile);
                var mainTargetGuid = pbxProject.GetUnityMainTargetGuid();
                pbxProject.AddFrameworkToProject(mainTargetGuid, $"{unityFramework}.framework", false);
                var unityFrameworkGuid = pbxProject.GetUnityFrameworkTargetGuid();
                pbxProject.SetBuildProperty(unityFrameworkGuid, enableBitcode, "YES");
                pbxProject.SetBuildProperty(unityFrameworkGuid, alwaysEmbedSwiftStandardLibraries, "NO");
                pbxProject.SetBuildProperty(mainTargetGuid, alwaysEmbedSwiftStandardLibraries, "YES");
                pbxProject.WriteToFile(pbxProjectFile);
            }
#endif
        }
    }
}