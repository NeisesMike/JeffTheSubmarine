using BepInEx;
using UnityEngine;
using UnityEngine.U2D;
using System.IO;
using System.Reflection;

namespace JefftheSubmarine
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    [BepInDependency(VehicleFramework.PluginInfo.PLUGIN_GUID, VehicleFramework.PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(Nautilus.PluginInfo.PLUGIN_GUID, Nautilus.PluginInfo.PLUGIN_VERSION)]
    public class MainPatcher : BaseUnityPlugin
    {
        private const string MyGUID = "com.Phoenix.Jeff";
        private const string PluginName = "JefftheSubmarine";
        private const string VersionString = "2.0.0";

        private static readonly string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static AssetBundle theUltimateBundleOfAssets;
        public static SpriteAtlas epicAtlasOfSprites;
        public void Start()
        {
            theUltimateBundleOfAssets = AssetBundle.LoadFromFile(Path.Combine(modFolder, "Assets/jeffthesubmarine"));
            epicAtlasOfSprites = theUltimateBundleOfAssets.LoadAsset<SpriteAtlas>("SpriteAtlas");
            UWE.CoroutineHost.StartCoroutine(JefftheSubmarine.Register());
        }
    }
}