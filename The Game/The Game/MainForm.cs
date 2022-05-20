using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Newtonsoft.Json;
using The_Game.handlers;
using The_Game.models.player;

namespace The_Game
{
    public partial class MainForm : Form
    {

        private FileHandler fileHandler = new FileHandler();
        private Stopwatch stopwatch = new Stopwatch();

        public string TempName { get; set; }
        public Player player = new Player("dummy", 0, 0 ,0, 0);

        public MainForm()
        {
            InitializeComponent();
            this.UserInput.KeyDown += new KeyEventHandler(this.UserInput_KeyDown);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.saveToolStripMenuItem.Enabled = false;

            NPCHandler.LoadNPCS();
            stopwatch.Start();
        }

        public RichTextBox mainConsole
        {
            get { return MainConsole; }
        }



        private void UserInput_KeyDown(object sender, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.Enter && UserInput.Text != "")
            {
                CommandHandler.HandleCommands(player, UserInput.Text);

                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:D2}:{1:D2}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

                MainConsole.AppendText("[" + elapsedTime + "] " + UserInput.Text + "\n");

                UserInput.Text = "";
                k.Handled = true;
                k.SuppressKeyPress = true;

            }
        }

        private void mainConsole_TextChanged(object sender, EventArgs e)
        {
            MainConsole.SelectionStart = MainConsole.Text.Length;
            MainConsole.ScrollToCaret();
        }

        #region ToolStrip
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDialog createDialog = new CreateDialog(this);
            createDialog.ShowDialog();
            if (createDialog.IsDisposed)
                toolStripStatusLabel1.Text = "Player: " + TempName + ", has been created.";
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"../../data/saves/";
                openFileDialog.Filter = "JSON Files (*.json)|*.json";
                openFileDialog.FilterIndex = 0;
                openFileDialog.Title = "Load Character";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(filePath));  
                    this.saveToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileHandler.SavePlayer(player);
            MessageBox.Show(player.Name + " has been saved!");
            NPCHandler.SpawnNPC(0);
            NPCHandler.SpawnNPC(2);
            NPCHandler.SpawnNPC(1);
            NPCHandler.SpawnNPC(0);
            NPCHandler.WhoSpawned();
        }
        #endregion
    }
}
