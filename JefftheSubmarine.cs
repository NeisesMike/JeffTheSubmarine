using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using VehicleFramework;
using VehicleFramework.VehicleTypes;
using VehicleFramework.Admin;
using VehicleFramework.VehicleBuilding;

namespace JefftheSubmarine
{
    public class JefftheSubmarine : Submarine
    {
        public static GameObject model;
        public static Sprite pingSprite;
        public static Sprite crafterSprite;

        public override VehiclePilotSeat PilotSeat
        {
            get
            {
                Transform mainSeat = transform.Find("PilotSeat");
                return new VehiclePilotSeat
                {
                    Seat = mainSeat.gameObject,
                    SitLocation = mainSeat.Find("SitLocation").gameObject,
                    LeftHandLocation = mainSeat,
                    RightHandLocation = mainSeat,
                    ExitLocation = mainSeat.Find("ExitLocation")
                };
            }
        }
        public override GameObject VehicleModel => model;
        public static IEnumerator Register()
        {
            GetAssets();
            ModVehicle JefftheSubmarine = model.EnsureComponent<JefftheSubmarine>();
            JefftheSubmarine.name = "JefftheSubmarine";
            yield return UWE.CoroutineHost.StartCoroutine(VehicleRegistrar.RegisterVehicle(JefftheSubmarine));
            DealDamageOnImpact ddoi = model.GetComponent<DealDamageOnImpact>();
            ddoi.capMirrorDamage = 15f;
            ddoi.mirroredSelfDamage = false;
            ddoi.mirroredSelfDamageFraction = 0.1f;
            ddoi.minDamageInterval = 0.7f;
        }
        public override List<VehicleHatchStruct> Hatches
        {
            get
            {
                Transform intHatch = transform.Find("Hatches/InsideHatch");
                Transform extHatch = transform.Find("Hatches/OutsideHatch");

                VehicleHatchStruct interior_vhs = new VehicleHatchStruct
                {
                    Hatch = intHatch.gameObject,
                    EntryLocation = intHatch.Find("Entry"),
                    ExitLocation = intHatch.Find("Exit"),
                    SurfaceExitLocation = intHatch.Find("SurfaceExit")
                };

                VehicleHatchStruct exterior_vhs = new VehicleHatchStruct
                {
                    Hatch = extHatch.gameObject,
                    EntryLocation = interior_vhs.EntryLocation,
                    ExitLocation = interior_vhs.ExitLocation,
                    SurfaceExitLocation = interior_vhs.SurfaceExitLocation
                };

                return new List<VehicleHatchStruct>
                {
                    interior_vhs,
                    exterior_vhs
                };
            }
        }
        public override BoxCollider BoundingBoxCollider => transform.Find("BoundingBoxCollider").gameObject.GetComponent<BoxCollider>();
        public static void GetAssets()
        {
            model = MainPatcher.theUltimateBundleOfAssets.LoadAsset<GameObject>("Jeff");
            pingSprite = (MainPatcher.epicAtlasOfSprites.GetSprite("JeffPingSprite"));
            crafterSprite = (MainPatcher.epicAtlasOfSprites.GetSprite("JeffRegularSprite"));
        }
        public override GameObject[] CollisionModel => new GameObject[] { transform.Find("CollisionModel").gameObject };
        public override List<VehicleStorage> InnateStorages
        {
            get
            {

                Transform innate1 = transform.Find("InnateStorages/Storage1");
                Transform innate2 = transform.Find("InnateStorages/Storage2");
                Transform innate3 = transform.Find("InnateStorages/Storage3");
                Transform innate4 = transform.Find("InnateStorages/Storage4");
                Transform innate5 = transform.Find("InnateStorages/Storage5");
                Transform innate6 = transform.Find("InnateStorages/Storage6");
                Transform innate7 = transform.Find("InnateStorages/Storage7");
                Transform innate8 = transform.Find("InnateStorages/Storage8");

                VehicleStorage IS1 = new VehicleStorage
                {
                    Container = innate1.gameObject,
                    Height = 8,
                    Width = 8
                };
                VehicleStorage IS2 = new VehicleStorage
                {
                    Container = innate2.gameObject,
                    Height = 8,
                    Width = 8
                };
                VehicleStorage IS3 = new VehicleStorage
                {
                    Container = innate3.gameObject,
                    Height = 8,
                    Width = 8
                };
                VehicleStorage IS4 = new VehicleStorage
                {
                    Container = innate4.gameObject,
                    Height = 8,
                    Width = 8
                };
                VehicleStorage IS5 = new VehicleStorage
                {
                    Container = innate5.gameObject,
                    Height = 3,
                    Width = 3
                };
                VehicleStorage IS6 = new VehicleStorage
                {
                    Container = innate6.gameObject,
                    Height = 3,
                    Width = 3
                };
                VehicleStorage IS7 = new VehicleStorage
                {
                    Container = innate7.gameObject,
                    Height = 6,
                    Width = 5
                };
                VehicleStorage IS8 = new VehicleStorage
                {
                    Container = innate8.gameObject,
                    Height = 6,
                    Width = 5
                };
                return new List<VehicleStorage>
                {
                    IS1,
                    IS2,
                    IS3,
                    IS4,
                    IS5,
                    IS6,
                    IS7,
                    IS8
                };
            }
        }
        public override List<VehicleUpgrades> Upgrades
        {
            get
            {
                VehicleUpgrades vu = new VehicleUpgrades
                {
                    Interface = transform.Find("Upgrades").gameObject
                };
                vu.Flap = vu.Interface;
                return new List<VehicleUpgrades>
                {
                    vu
                };
            }
        }
        public override List<VehicleBattery> Batteries
        {
            get
            {
                VehicleBattery vb1 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery1").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb2 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery2").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb3 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery3").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb4 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery4").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb5 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery5").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb6 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery6").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb7 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery7").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb8 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery8").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb9 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery9").gameObject,
                    BatteryProxy = null
                };

                VehicleBattery vb10 = new VehicleBattery
                {
                    BatterySlot = transform.Find("Batteries/Battery10").gameObject,
                    BatteryProxy = null
                };

                return new List<VehicleBattery>
                {
                    vb1,
                    vb2,
                    vb3,
                    vb4,
                    vb5,
                    vb6,
                    vb7,
                    vb8,
                    vb9,
                    vb10
                };
            }
        }
        public override List<VehicleFloodLight> HeadLights
        {
            get
            {
                return new List<VehicleFloodLight>
                {
                    new VehicleFloodLight
                    {
                        Light = transform.Find("lights_parent/Headlights/R").gameObject,
                        Angle = 70,
                        Color = Color.white,
                        Intensity = 1.3f,
                        Range = 90f
                    },
                    new VehicleFloodLight
                    {
                        Light = transform.Find("lights_parent/Headlights/L").gameObject,
                        Angle = 70,
                        Color = Color.white,
                        Intensity = 1.3f,
                        Range = 90f
                    }
                };
            }
        }
        public override List<GameObject> WaterClipProxies
        {
            get
            {
                var list = new List<GameObject>();
                foreach (Transform child in transform.Find("WaterClipProxy"))
                {
                    list.Add(child.gameObject);
                }
                return list;
            }
        }
        public override List<GameObject> TetherSources
        {
            get
            {
                var list = new List<GameObject>();
                foreach (Transform child in transform.Find("TetherSources"))
                {
                    list.Add(child.gameObject);
                }
                return list;

            }
        }
        public override Dictionary<TechType, int> Recipe
        {
            get
            {
                return new Dictionary<TechType, int>()
                {
                    {TechType.EnameledGlass, 2},
                    {TechType.PlasteelIngot, 2},
                    {TechType.TitaniumIngot, 1},
                    {TechType.PowerCell, 4},
                    {TechType.Lubricant, 2},
                    {TechType.Lead, 2 }
                };
            }
        }
        public override Sprite PingSprite => JefftheSubmarine.pingSprite;
        public override Sprite CraftingSprite => JefftheSubmarine.crafterSprite;
        public override string Description
        {
            get
            {
                return "A Small form factor vehicle used primarily for short to medium length operations.";
            }
        }
        public override string EncyclopediaEntry
        {
            get
            {
                string str = "Jeff the Submarine";
                str += "Jeff ended up in a different universe again... This time as a vehicle in your PDA?!";
                str += "\nIt features:\n";
                str += "- Jeff the Submarine is a small form factor vehicle used for short to medium length operations\n";
                str += "- It's large enough to house one, maybe two people. It can store a lot of items, but it isn't self sustaining because there isn't room for things like Grow Beds.\n";
                str += "- The main goal for this vehicle is to be almost as maneuverable as the Seamoth while offering a home similar to the Cyclops.\n";
                str += "- Onboard AI\n";
                str += "\nUsage:\n";
                str += "- We highly recommend you get yourself a Solar Charger so Jeff can become your main source of power. I gave him 10 slots for Power Cells for a reason.\n";
                str += "- Try to avoid dangerous predators. While Jeff has a good amount of health he's not immortal. When you do face a strong Leviathans we recommend you turn off the engine because noise usually attracts them.\n";
                str += "- -But the Control Panel doesn't work so I can't turn the engine off- I can hear you say... Well... Neither does mine... so tough luck I guess...\n";
                str += "\nRatings:\n";
                str += "- Power: 10 Power Cell for a total of 2000\n";
                str += "- Health: 1200 - For reference the Seamoth has 300 and the Cyclops 1500\n";
                str += "- Dimensions: Length 11m Width 5.45m Height 3.15m Height \n";
                str += "- Persons: 1 or 2 if you share the bed or turn the Storage into a second Bedroom (Optional room for Shark\n";
                str += "- Running the patented Jeff the Ocean Shark or JeffOS for short.\n";
                return str + "\n\'My name Jeff.\'\n";
            }
        }
        public override int BaseCrushDepth => 500;
        public override int CrushDepthUpgrade1 => 250;
        public override int CrushDepthUpgrade2 => 250;
        public override int CrushDepthUpgrade3 => 1000;
        public override int MaxHealth => 2000;
        public override int Mass => 100;
        public override int NumModules => 8;
        public override void Start()
        {
            base.Start();
            transform.Find("Control-Panel-Location/Control-Panel").gameObject.AddComponent<VehicleFramework.ControlPanel.ControlPanel>().mv = this;
        }
    }
}
