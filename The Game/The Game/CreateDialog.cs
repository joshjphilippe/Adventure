using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FluentValidation.Results;

using The_Game.handlers;
using The_Game.models.player;

namespace The_Game
{
    public partial class CreateDialog : Form
    {
        public MainForm ParentWindow { get; set; }
        private readonly FileHandler fileHandler = new FileHandler();


        public CreateDialog(MainForm parent)
        {
            InitializeComponent();
            this.ParentWindow = parent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void CreateDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Need to sanitize user input so that values are all expected
            // Creating a dummy player object for validation
            Player valid = new Player(playerNameSubmission.Text, 0, 0, 0, 0);
            PlayerNameValidator validator = new PlayerNameValidator();

            // Passing player data to validator and storing result
            ValidationResult results = validator.Validate(valid);

            if (results.IsValid == false)
                foreach (ValidationFailure error in results.Errors)
                    MessageBox.Show("Property: '" + error.PropertyName + "' " + error.ErrorMessage);
            else
            {
                fileHandler.CreatePlayer(playerNameSubmission.Text);
                ParentWindow.TempName = playerNameSubmission.Text;
                this.Dispose();
            }
        }
    }
}
