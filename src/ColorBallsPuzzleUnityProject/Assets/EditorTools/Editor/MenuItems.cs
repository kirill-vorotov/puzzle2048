using UnityEditor;
using UnityEngine;

namespace ColorClash.EditorTools
{
    public static class MenuItems
    {
        private const string deleteAllPlayerPrefsMenuItem = "Tools/Delete all PlayerPrefs";
        private const string createDefaultBuiltToolSettings = "Tools/Create default BuiltToolSettings";
        private const string buildiOSDevMenuItem = "Tools/Build/iOS development";
        private const string buildiOSReleaseMenuItem = "Tools/Build/iOS release";
        private const string buildAndroidDevMenuItem = "Tools/Build/Android development";
        private const string buildAndroidReleaseMenuItem = "Tools/Build/Android release";
        
        [MenuItem(deleteAllPlayerPrefsMenuItem)]
        public static void DeleteAllPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem(createDefaultBuiltToolSettings)]
        public static void CreateDefaultBuiltToolSettings()
        {
            BuildTool.CreateDefaultBuiltToolSettings();
        }
        
        [MenuItem(buildiOSDevMenuItem)]
        public static void BuildIOSDev()
        {
            BuildTool.BuildIOSDev();
        }
        
        [MenuItem(buildiOSReleaseMenuItem)]
        public static void BuildIOSRelease()
        {
            BuildTool.BuildIOSRelease();
        }
        
        [MenuItem(buildAndroidDevMenuItem)]
        public static void BuildAndroidDev()
        {
            BuildTool.BuildAndroidDev();
        }
        
        [MenuItem(buildAndroidReleaseMenuItem)]
        public static void BuildAndroidRelease()
        {
            BuildTool.BuildAndroidRelease();
        }
    }
}