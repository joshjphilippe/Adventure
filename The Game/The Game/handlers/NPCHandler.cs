using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using The_Game.models.npc;

namespace The_Game.handlers
{
    public static class NPCHandler
    {

        private static readonly string data = @"../../data/npcs.csv";
        private static List<NPC> npcList = new List<NPC>();
        public static List<NPC> spawnedList = new List<NPC>();

        public static void LoadNPCS()
        {
            var lines = File.ReadAllLines(data).Skip(1);
            foreach (string npc in lines)
            {
                var info = npc.Split('\u002C');
                npcList.Add(item: new NPC()
                {
                    ID = int.Parse(info[0]),
                    Name = info[1],
                    HP = int.Parse(info[2]),
                    Atk = int.Parse(info[3]),
                    Def = int.Parse(info[4]),
                    Desc = info[5]
                });

            }
        }

        public static void WhoDis(int id)
        {
            MessageBox.Show(npcList.ElementAt(id).GetStats());
        }

        public static void SpawnNPC(int id) 
        {
            spawnedList.Add(npcList.ElementAt(id));


            //NPC npc = npcList.ElementAt(id);

            //if (spawnedList.Count == 0 && npc != null)
            //{
            //    Console.WriteLine("----------");
            //    spawnedList.Add(npc);
            //    spawnedList.Last().Pos = NewPos;
            //    WhoSpawned();
            //    Console.WriteLine("----------");
            //    NewPos += 1;
            //}
            //else if (spawnedList.Count > 0 && npc != null)
            //{
            //    Console.WriteLine("----------");
            //    spawnedList.Add(npc);
            //    spawnedList.Last().Pos = NewPos;
            //    WhoSpawned();
            //    Console.WriteLine("----------");
            //    NewPos += 1;
            //}


            //if(spawnedList.Count == 0)
            //{
            //    spawnedList.Last().Pos = 0;
            //}
            //if(spawnedList.Count > 0)
            //{
            //    int previousNPCPos = spawnedList.Last().Pos;

            //    spawnedList.Add(npcList.ElementAt(id));

            //    spawnedList.Last().Pos = previousNPCPos + 1;

            //    WhoSpawned();

            //}


            //var dict = spawnedList.ToDictionary(x => x.Pos);
            //var npc = spawnedList.ElementAt(spawnedList[spawnedList.Count + 1].Pos);
            //int pos = spawnedList.ElementAt(id).Pos;
            //if (dict.TryGetValue(pos, out npc))
            //    npc.Pos = spawnedList.Count + 1;

        }

        public static void WhoSpawned()
        {
            for (int i = 0; i < spawnedList.Count; i++)
                Console.WriteLine("Index: ["+i+"] " + spawnedList[i].GetStats());
        }



    }
}
