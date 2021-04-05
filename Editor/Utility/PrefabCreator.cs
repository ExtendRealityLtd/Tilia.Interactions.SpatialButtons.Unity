namespace Tilia.Interactions.SpatialButtons.Utility
{
    using System.IO;
    using UnityEditor;
    using Zinnia.Utility;

    public class PrefabCreator : BasePrefabCreator
    {
        private const string group = "Tilia/";
        private const string project = "Interactions/SpatialButtons/";
        private const string menuItemRoot = topLevelMenuLocation + group + subLevelMenuLocation + project;

        private const string package = "io.extendreality.tilia.interactions.spatialbuttons.unity";
        private const string baseDirectory = "Runtime";
        private const string prefabDirectory = "Prefabs";
        private const string prefabSuffix = ".prefab";

        private const string prefabSpatialButtonClickButton = "Interactions.SpatialButton.ClickButton";
        private const string prefabSpatialButtonToggleButton = "Interactions.SpatialButton.ToggleButton";
        private const string prefabSpatialButtonGroup = "Interactions.SpatialButton.Group";
        private const string prefabSpatialButtonOptionButton = "Interactions.SpatialButton.OptionButton";

        [MenuItem(menuItemRoot + prefabSpatialButtonClickButton, false, priority)]
        private static void AddSpatialButtonClickButton()
        {
            string prefab = prefabSpatialButtonClickButton + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }

        [MenuItem(menuItemRoot + prefabSpatialButtonToggleButton, false, priority)]
        private static void AddSpatialButtonToggleButton()
        {
            string prefab = prefabSpatialButtonToggleButton + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }

        [MenuItem(menuItemRoot + prefabSpatialButtonGroup, false, priority)]
        private static void AddSpatialButtonGroup()
        {
            string prefab = prefabSpatialButtonGroup + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }

        [MenuItem(menuItemRoot + prefabSpatialButtonOptionButton, false, priority)]
        private static void AddSpatialButtonOptionButton()
        {
            string prefab = prefabSpatialButtonOptionButton + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }
    }
}