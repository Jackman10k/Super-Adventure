using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;

namespace SuperAdventure
{
    public partial class NPCScreen : Form
    {
        Player _currentPlayer { get; set; }

        public NPCScreen(Player player)
        {
            _currentPlayer = player;

            InitializeComponent();

            btnNPC1.Visible = false;
            btnNPC2.Visible = false;
            btnNPC3.Visible = false;

            //Revealing conversation buttons as determined by the number of NPCs in the location
            if(_currentPlayer.CurrentLocation.NPCsLivingHere.Count == 1)
            {
                PopulateNPC1();
            }

            if (_currentPlayer.CurrentLocation.NPCsLivingHere.Count == 2)
            {
                PopulateNPC1();
                PopulateNPC2();
            }

            if (_currentPlayer.CurrentLocation.NPCsLivingHere.Count  == 3)
            {
                PopulateNPC1();
                PopulateNPC2();
                PopulateNPC3();
            }

        }

        /*The following functions show the dialogue the NPC has*/
        private void btnNPC1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_currentPlayer.CurrentLocation.NPCsLivingHere[0].Dialogue);
        }

        private void btnNPC2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_currentPlayer.CurrentLocation.NPCsLivingHere[1].Dialogue);
        }

        private void btnNPC3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_currentPlayer.CurrentLocation.NPCsLivingHere[2].Dialogue);
        }

        /*The following functions fill in the NPC names and reveal the buttons as needed*/
        private void PopulateNPC1()
        {
            lblNPC1.Text = _currentPlayer.CurrentLocation.NPCsLivingHere[0].Name;
            btnNPC1.Visible = true;
        }

        private void PopulateNPC2()
        {
            lblNPC2.Text = _currentPlayer.CurrentLocation.NPCsLivingHere[1].Name;
            btnNPC2.Visible = true;
        }

        private void PopulateNPC3()
        {
            lblNPC3.Text = _currentPlayer.CurrentLocation.NPCsLivingHere[2].Name;
            btnNPC3.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
