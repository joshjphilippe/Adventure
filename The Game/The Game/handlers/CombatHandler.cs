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
    public class CombatHandler
    {

        public static void StartCombat(Player p, NPC n, string spell)
        {
            int playerHealth = p.Hp;
            int playerAttack = p.Atk;



            combat: do
            {


            } while (NPCHandler.spawnedList.Count > 0);
        }


        private static void AttackNPC(Player p, NPC n)
        {
            int playerAtk = p.Atk;




        }

    }
}
