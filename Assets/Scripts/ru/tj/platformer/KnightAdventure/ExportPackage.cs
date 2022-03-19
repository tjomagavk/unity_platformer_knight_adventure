using UnityEditor;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure {
    public static class ExportPackage {
        [MenuItem("Export/Export with tags and layers, Input settings")]
        public static void export() {
            string[] projectContent = {
                "Packages/com.unity.cinemachine",
                "Assets",
                "ProjectSettings/TagManager.asset",
                "ProjectSettings/InputManager.asset",
                "ProjectSettings/ProjectSettings.asset",
                "Packages/manifest.json",
                "Packages/packages-lock.json"
            };
            AssetDatabase.ExportPackage(projectContent, "Done.unitypackage",
                                        ExportPackageOptions.Interactive
                                        | ExportPackageOptions.Recurse
                                        | ExportPackageOptions.IncludeDependencies);
            Debug.Log("Project Exported");
        }
    }
}