using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using The_Game.models.player;

namespace The_Game.handlers
{
    public class FileHandler
    {
        private readonly string savedir = @"../../data/saves/";
        private Player player = new Player("dummy", 10, 10, 5, 10);
        private MainForm mainForm { get; set; }
        
        public void CreatePlayer(String name)
        {
            player.Name = name;
            JObject json = JObject.Parse(JsonConvert.SerializeObject(player));
            File.WriteAllText(Path.GetFullPath(Path.Combine(savedir, name + ".json")), json.ToString());
        }

        public void SavePlayer(Player player)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(player));
            File.WriteAllText(Path.GetFullPath(Path.Combine(savedir, player.Name + ".json")), json.ToString());
        }
    }
}
