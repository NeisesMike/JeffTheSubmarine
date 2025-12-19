using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using VehicleFramework;
using VehicleFramework.VehicleParts;
using VehicleFramework.VehicleTypes;
using VehicleFramework.Engines;
using Nautilus;
using static Nautilus.Utility.MaterialUtils;

namespace JeffTheSubmarine
{
    public class JefftheSubmarine : Submarine
    {
        public static GameObject model;
        public static Sprite pingSprite;
        public static Sprite crafterSprite;

        public override List<VehiclePilotSeat> PilotSeats
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehiclePilotSeat>();
                VehicleFramework.VehicleParts.VehiclePilotSeat vps = new VehicleFramework.VehicleParts.VehiclePilotSeat();
                Transform mainSeat = transform.Find("PilotSeat");
                vps.Seat = mainSeat.gameObject;
                vps.SitLocation = mainSeat.Find("SitLocation").gameObject;
                vps.LeftHandLocation = mainSeat;
                vps.RightHandLocation = mainSeat;
                vps.ExitLocation = mainSeat.Find("ExitLocation");
                // TODO exit location
                list.Add(vps);
                return list;
            }
        }

        public override GameObject VehicleModel
        {
            get
            {
                return model;
            }
        }
        public static IEnumerator Register()
        {
            GetAssets();
            ModVehicle JefftheSubmarine = Radical.EnsureComponent<JefftheSubmarine>(model);
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
                var list = new List<VehicleFramework.VehicleParts.VehicleHatchStruct>();

                VehicleFramework.VehicleParts.VehicleHatchStruct interior_vhs = new VehicleFramework.VehicleParts.VehicleHatchStruct();
                Transform intHatch = transform.Find("Hatches/InsideHatch");
                interior_vhs.Hatch = intHatch.gameObject;
                interior_vhs.EntryLocation = intHatch.Find("Entry");
                interior_vhs.ExitLocation = intHatch.Find("Exit");
                interior_vhs.SurfaceExitLocation = intHatch.Find("SurfaceExit");

                VehicleFramework.VehicleParts.VehicleHatchStruct exterior_vhs = new VehicleFramework.VehicleParts.VehicleHatchStruct();
                Transform extHatch = transform.Find("Hatches/OutsideHatch");
                exterior_vhs.Hatch = extHatch.gameObject;
                exterior_vhs.EntryLocation = interior_vhs.EntryLocation;
                exterior_vhs.ExitLocation = interior_vhs.ExitLocation;
                exterior_vhs.SurfaceExitLocation = interior_vhs.SurfaceExitLocation;

                list.Add(interior_vhs);
                list.Add(exterior_vhs);
                return list;
            }
        }
        public override BoxCollider BoundingBoxCollider
        {
            get
            {
                return transform.Find("BoundingBoxCollider").gameObject.GetComponent<BoxCollider>();
            }
        }

        public static void GetAssets()
        {
            model = MainPatcher.theUltimateBundleOfAssets.LoadAsset<GameObject>("Jeff");

            pingSprite = (MainPatcher.epicAtlasOfSprites.GetSprite("JeffPingSprite"));
            crafterSprite = (MainPatcher.epicAtlasOfSprites.GetSprite("JeffRegularSprite"));
        }
        public override GameObject CollisionModel
        {
            get
            {
                return transform.Find("CollisionModel").gameObject;
            }
        }

        public override GameObject StorageRootObject
        {
            get
            {
                return transform.Find("StorageRoot").gameObject;
            }
        }

        public override GameObject ModulesRootObject
        {
            get
            {
                return transform.Find("ModulesRoot").gameObject;
            }
        }

        public override List<VehicleStorage> InnateStorages
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehicleStorage>();

                Transform innate1 = transform.Find("InnateStorages/Storage1");
                Transform innate2 = transform.Find("InnateStorages/Storage2");
                Transform innate3 = transform.Find("InnateStorages/Storage3");
                Transform innate4 = transform.Find("InnateStorages/Storage4");
                Transform innate5 = transform.Find("InnateStorages/Storage5");
                Transform innate6 = transform.Find("InnateStorages/Storage6");
                Transform innate7 = transform.Find("InnateStorages/Storage7");
                Transform innate8 = transform.Find("InnateStorages/Storage8");

                VehicleFramework.VehicleParts.VehicleStorage IS1 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS1.Container = innate1.gameObject;
                IS1.Height = 8;
                IS1.Width = 8;
                list.Add(IS1);
                VehicleFramework.VehicleParts.VehicleStorage IS2 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS2.Container = innate2.gameObject;
                IS2.Height = 8;
                IS2.Width = 8;
                list.Add(IS2);
                VehicleFramework.VehicleParts.VehicleStorage IS3 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS3.Container = innate3.gameObject;
                IS3.Height = 8;
                IS3.Width = 8;
                list.Add(IS3);
                VehicleFramework.VehicleParts.VehicleStorage IS4 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS4.Container = innate4.gameObject;
                IS4.Height = 8;
                IS4.Width = 8;
                list.Add(IS4);
                VehicleFramework.VehicleParts.VehicleStorage IS5 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS5.Container = innate5.gameObject;
                IS5.Height = 3;
                IS5.Width = 3;
                list.Add(IS5);
                VehicleFramework.VehicleParts.VehicleStorage IS6 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS6.Container = innate6.gameObject;
                IS6.Height = 3;
                IS6.Width = 3;
                list.Add(IS6);
                VehicleFramework.VehicleParts.VehicleStorage IS7 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS7.Container = innate7.gameObject;
                IS7.Height = 6;
                IS7.Width = 5;
                list.Add(IS7);
                VehicleFramework.VehicleParts.VehicleStorage IS8 = new VehicleFramework.VehicleParts.VehicleStorage();
                IS8.Container = innate8.gameObject;
                IS8.Height = 6;
                IS8.Width = 5;
                list.Add(IS8);

                return list;
            }
        }

        public override List<VehicleUpgrades> Upgrades
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehicleUpgrades>();
                VehicleFramework.VehicleParts.VehicleUpgrades vu = new VehicleFramework.VehicleParts.VehicleUpgrades();
                vu.Interface = transform.Find("Upgrades").gameObject;
                vu.Flap = vu.Interface;
                list.Add(vu);
                return list;
            }
        }

        public override List<VehicleBattery> Batteries
        {
            get
            {
                var list = new List<VehicleBattery>();

                VehicleBattery vb1 = new VehicleBattery();
                vb1.BatterySlot = transform.Find("Batteries/Battery1").gameObject;
                vb1.BatteryProxy = null;
                list.Add(vb1);

                VehicleBattery vb2 = new VehicleBattery();
                vb2.BatterySlot = transform.Find("Batteries/Battery2").gameObject;
                vb2.BatteryProxy = null;
                list.Add(vb2);

                VehicleBattery vb3 = new VehicleBattery();
                vb3.BatterySlot = transform.Find("Batteries/Battery3").gameObject;
                vb3.BatteryProxy = null;
                list.Add(vb3);

                VehicleBattery vb4 = new VehicleBattery();
                vb4.BatterySlot = transform.Find("Batteries/Battery4").gameObject;
                vb4.BatteryProxy = null;
                list.Add(vb4);

                VehicleBattery vb5 = new VehicleBattery();
                vb5.BatterySlot = transform.Find("Batteries/Battery5").gameObject;
                vb5.BatteryProxy = null;
                list.Add(vb5);

                VehicleBattery vb6 = new VehicleBattery();
                vb6.BatterySlot = transform.Find("Batteries/Battery6").gameObject;
                vb6.BatteryProxy = null;
                list.Add(vb6);

                VehicleBattery vb7 = new VehicleBattery();
                vb7.BatterySlot = transform.Find("Batteries/Battery7").gameObject;
                vb7.BatteryProxy = null;
                list.Add(vb7);

                VehicleBattery vb8 = new VehicleBattery();
                vb8.BatterySlot = transform.Find("Batteries/Battery8").gameObject;
                vb8.BatteryProxy = null;
                list.Add(vb8);

                VehicleBattery vb9 = new VehicleBattery();
                vb9.BatterySlot = transform.Find("Batteries/Battery9").gameObject;
                vb9.BatteryProxy = null;
                list.Add(vb9);

                VehicleBattery vb10 = new VehicleBattery();
                vb10.BatterySlot = transform.Find("Batteries/Battery10").gameObject;
                vb10.BatteryProxy = null;
                list.Add(vb10);

                return list;
            }
        }
        public override List<VehicleFloodLight> HeadLights
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehicleFloodLight>();

                list.Add(new VehicleFramework.VehicleParts.VehicleFloodLight
                {
                    Light = transform.Find("lights_parent/Headlights/R").gameObject,
                    Angle = 70,
                    Color = Color.white,
                    Intensity = 1.3f,
                    Range = 90f
                });
                list.Add(new VehicleFramework.VehicleParts.VehicleFloodLight
                {
                    Light = transform.Find("lights_parent/Headlights/L").gameObject,
                    Angle = 70,
                    Color = Color.white,
                    Intensity = 1.3f,
                    Range = 90f
                });

                return list;
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

        public override GameObject BoundingBox
        {
            get
            {
                return transform.Find("BoundingBox").gameObject;
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
            {
                TechType.EnameledGlass, 2
            },
            {
                TechType.PlasteelIngot, 2
            },
                                {
                TechType.TitaniumIngot, 1
            },
            {
                TechType.PowerCell, 4
            },
            {
                TechType.Lubricant, 2
            },
                        {
                TechType.Lead, 2
            }
        };
            }
        }

        public override Sprite PingSprite
        {
            get
            {
                return JefftheSubmarine.pingSprite;
            }
        }

        public override Sprite CraftingSprite
        {
            get
            {
                return JefftheSubmarine.crafterSprite;
            }
        }
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

        public override int BaseCrushDepth
        {
            get
            {
                return 500;
            }
        }

        public override int CrushDepthUpgrade1
        {
            get
            {
                return 250;
            }
        }

        public override int CrushDepthUpgrade2
        {
            get
            {
                return 250;
            }
        }

        public override int CrushDepthUpgrade3
        {
            get
            {
                return 1000;
            }
        }
        public override int MaxHealth
        {
            get
            {
                return 2000;
            }
        }

        public override int Mass
        {
            get
            {
                return 100;
            }
        }

        public override int NumModules
        {
            get
            {
                return 8;
            }
        }

        public override bool HasArms
        {
            get
            {
                return false;
            }
        }
    }
}