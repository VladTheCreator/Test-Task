using UnityEditor;
using System.IO;
using UnityEngine;


public class CreateAssetBundle : MonoBehaviour
{
    [MenuItem("Assets/Build Assetsbundles")]
    static void BuildAssetBundle()
    {
        string AssetBundleDirectory = "Assets/AssetBundle";
        if (!Directory.Exists(AssetBundleDirectory))
        {
            Directory.CreateDirectory(AssetBundleDirectory);
        }

        BuildPipeline.BuildAssetBundles(AssetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
