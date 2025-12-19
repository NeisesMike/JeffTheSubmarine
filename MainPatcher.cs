using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehicleFramework.VehicleTypes;
using System.Collections;
using VehicleFramework;
using JefftheSubmarine;
using BepInEx;
using HarmonyLib;
using Nautilus.Utility;

namespace JefftheSubmarine
{
    public static class Logger
    {
        public static void Log(string message)
        {
            UnityEngine.Debug.Log("[JefftheSubmarine]:" + message);
        }
        public static void Output(string msg)
        {
            BasicText message = new BasicText(500, 0);
            message.ShowMessage(msg, 5);
        }
    }
    [BepInPlugin("com.royalty.subnautica.JeffTheSubmarine.mod", "JeffTheSubmarine", "2.2.9")]
    [BepInDependency("com.mikjaw.subnautica.vehicleframework.mod")]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("com.royalty.subnautica.RoyalCommonalities.mod")]

    public class MainPatcher : BaseUnityPlugin
    {
        public void Start()
        {
            var harmony = new Harmony("com.royalty.subnautica.JeffTheSubmarine.mod");
            harmony.PatchAll();
            UWE.CoroutineHost.StartCoroutine(JefftheSubmarine.Register());
        }
    }
}