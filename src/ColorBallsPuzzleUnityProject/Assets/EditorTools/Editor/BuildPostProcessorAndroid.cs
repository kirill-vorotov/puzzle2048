using UnityEditor;
using UnityEditor.Callbacks;

namespace ColorClash.EditorTools
{
    public static class BuildPostProcessorAndroid
    {
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.Android)
            {
                return;
            }
        }
    }
}