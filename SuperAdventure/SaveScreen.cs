using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using Engine;

namespace SuperAdventure
{
    public partial class SaveScreen : Form
    {
        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";
        public Player _currentPlayer { get; set; }

        public SaveScreen(Player player)
        {
            _currentPlayer = player;

            InitializeComponent();

            btnClose.Visible = false;
            rtbSaveScreen.SelectAll();
            rtbSaveScreen.SelectionAlignment = HorizontalAlignment.Center;
            rtbSaveScreen.Text += "Are you sure you want to save your game?";
        }

        private void btnSaveYes_Click(object sender, EventArgs e)
        {
            try
            {
                //Saving the player's data
                File.WriteAllText(PLAYER_DATA_FILE_NAME, _currentPlayer.ToXmlString());
                rtbSaveScreen.Clear();
                rtbSaveScreen.Text += "Your game has been saved!";
                btnSaveYes.Visible = false;
                btnSaveNo.Visible = false;
                btnClose.Visible = true;
            }
            catch
            {
                //Informing the player their data could not be saved in the event of an error
                rtbSaveScreen.Clear();
                rtbSaveScreen.Text += "Game could not be saved.  Sorry. :/";
            }
        }

        private void btnSaveNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
