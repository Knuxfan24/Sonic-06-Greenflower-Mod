using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HedgeLib.Sets;

namespace Zone_Builder_Things_to_S06
{
    class Program
    {
        static void Main(string[] args)
        {
            S06SetData targetSet = new S06SetData();
            
            string[] thingList = File.ReadAllLines("Y:\\Things.txt");
            //int plantNumber = 0;
            //foreach (string thing in thingList)
            //{
            //    string[] tempLine = thing.Split('|'); //0 is Object, coords are 1,2,3, angle is 4
            //    switch (tempLine[0])
            //    {
            //        case "THZ Flower":
            //            using (StreamWriter log = new StreamWriter(@"Y:\THZPA0.ms", append: true))
            //            {
            //                log.WriteLine("mergeMAXFile \"C:\\Users\\Knuxf\\Documents\\3dsMax\\scenes\\Flowers\\THZPA0.max\" #useMergedMtlDups");
            //                log.WriteLine("a = $w1_gism_plantDa");
            //                log.WriteLine("a.Name = \"THZPA0_" + plantNumber + "\"");
            //                log.WriteLine("a.pos.x = " + tempLine[1]);
            //                log.WriteLine("a.pos.y = " + -(float.Parse(tempLine[3])));
            //                log.WriteLine("a.pos.z = " + tempLine[2]);
            //                //log.WriteLine("a.rotation = eulerAngles 0 0 " + tempLine[4]);
            //            }
            //            plantNumber++;
            //            break;
            //    }
            //}
            //return;
            List<string> unknownObjects = new List<string> { };

            //SetObject dubObject = new SetObject();
            //dubObject.ObjectID = 0;
            //dubObject.Parameters.Add(new SetObjectParam(typeof(string), "HedgeLib Workaround"));
            //dubObject.Parameters.Add(new SetObjectParam(typeof(bool), false));
            //List<SetObjectParam> parameters2 = dubObject.Parameters;
            //SetObject item2 = new SetObject
            //{
            //    ObjectType = "objectphysics",
            //    ObjectID = dubObject.ObjectID,
            //    Parameters = parameters2,
            //};
            //targetSet.Objects.Add(item2);
            int objectID = 0;

            foreach (string thing in thingList)
            {
                string[] tempLine = thing.Split('|'); //0 is Object, coords are 1,2,3, angle is 4
                string objectType = "objectphysics";
                SetObject s06Object = new SetObject();
                byte[] bytesGLVL = new byte[16];
                bytesGLVL[0] = 64;
                bytesGLVL[1] = 0;
                bytesGLVL[2] = 0;
                bytesGLVL[3] = 0;
                bytesGLVL[4] = 0;
                bytesGLVL[5] = 0;
                bytesGLVL[6] = 0;
                bytesGLVL[7] = 0;
                bytesGLVL[8] = 0;
                bytesGLVL[9] = 0;
                bytesGLVL[10] = 0;
                bytesGLVL[11] = 0;
                bytesGLVL[12] = 0;
                bytesGLVL[13] = 0;
                bytesGLVL[14] = 0;
                bytesGLVL[15] = 0;
                s06Object.UnknownBytes = bytesGLVL;

                switch (tempLine[0])
                {
                    //case "Ring":
                    //case "5 Diagonal Rings (Yellow Spring)":
                    //case "5 Vertical Rings (Red Spring)":
                    //case "5 Vertical Rings (Yellow Spring)":
                    //case "10 Diagonal Rings (Red Spring)":
                    //case "Circle of Rings":
                    //    objectType = "ring";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(bool), true));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), ""));
                    //    break;
                    //case "Player 01 Start":
                    //    objectType = "player_start2";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "sonic_new"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(bool), false));
                    //    break;
                    //case "Crawla (Blue)":
                    //case "Crawla (Red)":
                    //case "MT_BLUECRAWLACLASSIC":
                    //case "MT_REDCRAWLA":
                    //    objectType = "enemy";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunner"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunner_Fix"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    break;
                    //case "Stupid Dumb Unnamed RoboFish":
                    //    objectType = "enemy";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eFlyer"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eFlyer_Fix_Vulcan"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    break;
                    ////case "Buzz (Gold)":
                    ////case "Buzz (Red)":
                    ////    objectType = "enemy";
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunner(Fly)"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunnerFly_Fix"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    ////    break;
                    ////case "Crawla Commander":
                    ////    objectType = "enemy";
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eCannon"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eCannon_Fix"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    ////    break;
                    ////case "Unidus":
                    ////    objectType = "enemy";
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cCrawler"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cCrawler_Fix"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    ////    break;
                    ////case "Pyre Fly":
                    ////    objectType = "enemy";
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cTricker"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 1));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cTricker_Fix"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    ////    break;
                    ////case "Dragonbomber":
                    ////    objectType = "enemy";
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cTricker"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 1));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cTricker_Normal"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    ////    break;
                    ////case "Pterabyte Spawner":
                    ////    objectType = "enemy";
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cTaker"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "cTaker_Fix"));
                    ////    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    ////    break;
                    //case "Super Ring (10 Rings)":
                    //case "Eggman":
                    //    objectType = "itemboxg";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 2));
                    //    break;
                    //case "MT_HYPERRINGBOX":
                    //    objectType = "itemboxg";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 3));
                    //    break;
                    //case "Extra Life":
                    //    objectType = "itemboxg";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 4));
                    //    break;
                    //case "Super Sneakers":
                    //    objectType = "itemboxg";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 5));
                    //    break;
                    //case "Invincibility":
                    //case "Invincibility (Respawn)":
                    //    objectType = "itemboxg";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 7));
                    //    break;
                    //case "Armageddon Shield":
                    //case "Attraction Shield":
                    //case "Elemental Shield":
                    //case "Force Shield":
                    //case "Whirlwind Shield":
                    //case "Whirlwind Shield (Respawn)":
                    //    objectType = "itemboxg";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 8));
                    //    break;
                    //case "Emblem":
                    //case "Emerald Token":
                    //case "Special Stage Token":
                    //    objectType = "medal_of_royal_bronze";
                    //    break;
                    //case "Diagonal Yellow Spring":
                    //case "Horizontal Red Spring":
                    //case "Horizontal Yellow Spring":
                    //case "Red Spring":
                    //case "Yellow Spring":
                    //case "Diagonal Red Spring":
                    //    objectType = "spring";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 3000f));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0.5f));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(uint), 4294967295u));
                    //    break;
                    //case "Star Post":
                    //    objectType = "savepoint";
                    //    break;
                    //case "Level End Sign":
                    //    objectType = "goalring";
                    //    break;
                    //case "Chaos Emerald 5 (Orange)":
                    //    objectType = "common_chaosemerald";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 3));
                    //    break;
                    //case "Player 1 start":
                    //    objectType = "player_start2";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "omega"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(bool), false));
                    //    break;
                    //case "Armor bonus":
                    //case "Ammo clip":
                    //case "Health bonus":
                    //    objectType = "ring";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(bool), true));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), ""));
                    //    break;
                    //case "Barrel":
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "BombBox"));
                    //    break;
                    //case "Blue armor":
                    //    objectType = "itemboxa";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 7));
                    //    break;
                    //case "Box of Ammo":
                    //case "Box of Rockets":
                    //case "Box of Shells":
                    //case "Shotgun shells":
                    //case "Stimpack":
                    //    objectType = "itemboxa";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 1));
                    //    break;
                    //case "Medikit":
                    //case "Chaingun":
                    //case "Rocket launcher":
                    //case "Shotgun":
                    //    objectType = "itemboxa";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 2));
                    //    break;
                    //case "Green armor":
                    //    objectType = "itemboxa";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 8));
                    //    break;
                    //case "Imp":
                    //    objectType = "enemy";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eBuster"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 3));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eBuster_Fix"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    break;
                    //case "Former Human":
                    //    objectType = "enemy";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunner"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 0));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunner_Fix_Vulcan"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    break;
                    //case "Former Sergeant":
                    //    objectType = "enemy";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunner"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(int), 1));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "eGunner_Fix_Vulcan"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    break;
                    //case "Water Ambience A (Large)":
                    //    objectType = "ambience";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "stage_kdv"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "break"));
                    //    break;
                    //case "Water Ambience C (Medium)":
                    //    objectType = "ambience";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "stage_kdv"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "bridge2"));
                    //    break;
                    //case "Water Ambience D (Medium)":
                    //    objectType = "ambience";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "stage_kdv"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "rope_hard"));
                    //    break;
                    //case "Water Ambience E (Small)":
                    //    objectType = "ambience";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "stage_kdv"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "bridge"));
                    //    break;
                    //case "Water Ambience F (Small)":
                    //    objectType = "ambience";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "stage_kdv"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "rope"));
                    //    break;
                    //case "Water Ambience G (Extra Large)":
                    //    objectType = "ambience";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "stage_kdv"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "rockfall"));
                    //    break;
                    //case "Water Ambience H (Extra Large)":
                    //    objectType = "ambience";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "stage_kdv"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "rocksplash"));
                    //    break;
                    //case "Torch Flower":
                    //    objectType = "particle";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "map_flc"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "torchlight_02"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(float), 0f));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), ""));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), ""));
                    //    break;
                    //case "Torch Flower":
                    //    objectType = "pointlight";
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "kdvpoint01"));
                    //    break;
                    //case "Brown Stalagmite":
                    //case "Brown Stalagmite (Tall)":
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(string), "flc_stalactite"));
                    //    s06Object.Parameters.Add(new SetObjectParam(typeof(bool), false));
                    //    break;
                    case "Rollout Rock":
                        s06Object.Parameters.Add(new SetObjectParam(typeof(string), "rvz_checkerball"));
                        s06Object.Parameters.Add(new SetObjectParam(typeof(bool), false));
                        break;
                    default:
                        if (!unknownObjects.Contains(tempLine[0]))
                        {
                            unknownObjects.Add(tempLine[0]);
                        }
                        continue;
                        s06Object.Parameters.Add(new SetObjectParam(typeof(string), tempLine[0]));
                        s06Object.Parameters.Add(new SetObjectParam(typeof(bool), false));
                        break;
                }

                //Common Things Shared Across All Objects
                List<SetObjectParam> parameters = s06Object.Parameters;
                var trans = new SetObjectTransform();
                trans.Position.X = float.Parse(tempLine[1]);
                trans.Position.Y = float.Parse(tempLine[2]);
                trans.Position.Z = float.Parse(tempLine[3]);

                if (objectType == "ring" || objectType == "common_chaosemerald")
                {
                    trans.Position.Y += 24;
                }
                if (objectType == "particle" || objectType == "pointlight")
                {
                    trans.Position.Y += 220;
                }
                if (objectType == "medal_of_royal_bronze")
                {
                    trans.Position.Y += 48;
                }
                if (objectType == "goalring")
                {
                    trans.Position.Y += 168;
                }

                Quaternion temp = ConvertToQuat(float.Parse(tempLine[4]));
                trans.Rotation.W = temp.W;
                trans.Rotation.X = temp.X;
                trans.Rotation.Y = temp.Y;
                trans.Rotation.Z = temp.Z;


                //var trans = GenTransform(forcesObject.Transform);
                SetObject item = new SetObject
                {
                    ObjectType = objectType,
                    ObjectID = 0,
                    Parameters = parameters,
                    Transform = trans,
                    UnknownBytes = bytesGLVL
                };
                targetSet.Objects.Add(item);
                objectID++;
            }

            targetSet.Save(@"C:\Users\Knuxf\AppData\Local\Hyper_Development_Team\Sonic '06 Toolkit\Archives\59061\y2xofjq2.fd1\scripts\xenon\placement\rvz\wheresalltheobjects.set", true);
            if (unknownObjects.Count > 0)
            {
                Console.Clear();
                unknownObjects.Sort();
                Console.WriteLine("Unknown objects:");
                foreach (string obj in unknownObjects)
                {
                    Console.WriteLine(obj);
                }
                Console.ReadKey();
            }
        }

        public static Quaternion ConvertToQuat(float angle)
        {
            Quaternion quat = new Quaternion();
            var h = (angle + 90) * Math.PI / 360; //Y
            var a = 0 * Math.PI / 360; //Z
            var b = 0 * Math.PI / 360; //X
            var c1 = Math.Cos(h);
            var c2 = Math.Cos(a);
            var c3 = Math.Cos(b);
            var s1 = Math.Sin(h);
            var s2 = Math.Sin(a);
            var s3 = Math.Sin(b);
            quat.W = ToSingle(Math.Round((c1 * c2 * c3 - s1 * s2 * s3) * 100000) / 100000);
            quat.X = ToSingle(Math.Round((s1 * s2 * c3 + c1 * c2 * s3) * 100000) / 100000);
            quat.Y = ToSingle(Math.Round((s1 * c2 * c3 + c1 * s2 * s3) * 100000) / 100000);
            quat.Z = ToSingle(Math.Round((c1 * s2 * c3 - s1 * c2 * s3) * 100000) / 100000);
            return quat;
        }

        public static float ToSingle(double value)
        {
            return (float)value;
        }
    }
}
