using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Game.models.npc;
using The_Game.models.player;

namespace The_Game.handlers
{
    internal class CommandHandler
    {

        public static void HandleCommands(Player p, String command)
        {
            string[] cmd = command.Split(' ');
            cmd[0] = cmd[0].ToLower();

            string[] spells = { "hehoo", "nanni" };


            try
            {
                /**
                 * TODO:
                 * attack mob spell(optional)
                 */

                if (cmd[0].StartsWith("attack"))
                    Command_Attack(p, cmd[1]);
                else if (cmd[0].StartsWith("attack") && cmd[2].Contains(spells.ToString()))
                        Command_Attack(p, cmd[1], cmd[2]);

                #region Math
                if (cmd[0].StartsWith("add"))
                {
                    int num1 = int.Parse(cmd[1]);
                    int num2 = int.Parse(cmd[2]);

                    int answer = num1 + num2;

                    MessageBox.Show(answer.ToString());

                }

                if (cmd[0].StartsWith("sub"))
                {
                    int num1 = int.Parse(cmd[1]);
                    int num2 = int.Parse(cmd[2]);

                    int answer = num1 - num2;

                    MessageBox.Show(answer.ToString());

                }

                if (cmd[0].StartsWith("div"))
                {
                    int num1 = int.Parse(cmd[1]);
                    int num2 = int.Parse(cmd[2]);

                    int answer = num1 / num2;

                    MessageBox.Show(answer.ToString());

                }

                if (cmd[0].StartsWith("mul"))
                {
                    int num1 = int.Parse(cmd[1]);
                    int num2 = int.Parse(cmd[2]);

                    int answer = num1 * num2;

                    MessageBox.Show(answer.ToString());

                }
                #endregion

            } catch (Exception ex)
            {
                Console.WriteLine("Invalid command perhaps? Idk");
                Console.WriteLine(ex.Message);
            }

        }

//                    for (int i = 0; i<NPCHandler.spawnedList.Count; i++)
//            {
//                if (mob.Contains(NPCHandler.spawnedList.ElementAt(i).Name.ToLower()))
//                {
//                    MessageBox.Show("Found: " + NPCHandler.spawnedList.ElementAt(i).GetStats());
//                }
//                if (pos.Length > 0 || pos.Length< 2)
//                {
//                    if (char.IsDigit(char.Parse(pos)))
//                    {
//                        MessageBox.Show("Can confirm that this NPC is here!");
//                        break;
//                    }
//                    else
//{
//    MessageBox.Show("This NPC doesn't exist here!");
//    break;
//}
//                }
//                else
//{
//    MessageBox.Show("This mob doesn't exist!");
//    break;
//}
//            }

        private static void Command_Attack(Player p, string mob, string spell = "none")
        {
            NPC npc = new NPC(-1, "null", -1, -1, -1, "null");

            for (int i = 0; i < NPCHandler.spawnedList.Count; i++)
            {
                if (NPCHandler.spawnedList[i].Name.ToLower() == mob)
                {
                    npc.ID = NPCHandler.spawnedList[i].ID;
                    npc.Name = NPCHandler.spawnedList[i].Name;
                    npc.HP = NPCHandler.spawnedList[i].HP;
                    npc.Atk = NPCHandler.spawnedList[i].Atk;
                    npc.Def = NPCHandler.spawnedList[i].Def;
                    npc.Desc = NPCHandler.spawnedList[i].Desc;
                    break;
                }
            }

            CombatHandler.StartCombat(p, npc, spell);


            //NPC mockNPC = new NPC(-1, mob, -1, -1, -1, "null");
            //if (NPCHandler.spawnedList.Contains(item: (NPC)mockNPC.Name))
            //{

            //}
            //    MessageBox.Show("Found: " + mockNPC.GetStats());

            //for (int i = 0; i < NPCHandler.spawnedList.Count; i++)
            //{
            //    if()
            //    {
                    //MessageBox.Show("Found: " + npc.GetStats());
            //    }
            //}


            //NPCHandler.WhoSpawned();
        }
    }
}
