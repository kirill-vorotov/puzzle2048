using System;

namespace ColorClash.EditorTools
{
    [Serializable]
    public class BuildToolSettings
    {
        [NonSerialized]
        public static readonly BuildToolSettings Default = new BuildToolSettings()
        {
            CompanyName = "CompanyName",
            ProductName = "ProductName",
            BundleId = "com.CompanyName.ProductName",
            ApplicationDisplayName = "Application Name",
            BundleVersion = "0.1.0",
            BuildNumber = 1,
            BundleVersionCode = 1,
            AppleDeveloperTeamID = "",
            ScriptingDefineSymbols = new []
            {
                ""
            },
            KeystoreName = "",
            KeystorePass = "",
            KeyaliasName = "",
            KeyaliasPass = "",
        };
        
        public string CompanyName = "CompanyName";
        public string ProductName = "ProductName";
        public string BundleId = "com.CompanyName.ProductName";
        public string ApplicationDisplayName = "Application Name";
        public string BundleVersion = "0.1.0";
        public int BuildNumber = 1;
        public int BundleVersionCode = 1;
        public string AppleDeveloperTeamID;
        public string[] ScriptingDefineSymbols;
        public string KeystoreName = "";
        public string KeystorePass = "";
        public string KeyaliasName = "";
        public string KeyaliasPass = "";
    }
}