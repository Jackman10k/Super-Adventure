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
    public partial class InnScreen : Form
    {
        Player _currentPlayer { get; set; }

        public InnScreen(Player player)
        {
            _currentPlayer = player;

            InitializeComponent();

            btnReturn.Visible = false;
            rtbInnDescription.Text = _currentPlayer.CurrentLocation.InnAvailableHere.Description;
            rtbInnMessage.Text = _currentPlayer.CurrentLocation.InnAvailableHere.WelcomeMessage;
            lblInnCost.Text = _currentPlayer.CurrentLocation.InnAvailableHere.Cost.ToString();
        }

        private void btnInnYes_Click(object sender, EventArgs e)
        {
            if (_currentPlayer.Gold >= _currentPlayer.CurrentLocation.InnAvailableHere.Cost)
            {
                rtbInnMessage.Clear();
                rtbInnMessage.Text = _currentPlayer.CurrentLocation.InnAvailableHere.RestMessage;
                _currentPlayer.Gold -= _currentPlayer.CurrentLocation.InnAvailableHere.Cost;
                _currentPlayer.CurrentHitPoints = _currentPlayer.MaximumHitPoints;
                _currentPlayer.CurrentAbilityPoints = _currentPlayer.MaximumAbilityPoints;
                btnInnYes.Visible = false;
                btnInnNo.Visible = false;
                btnReturn.Visible = true;
            }
            else
            {
                rtbInnMessage.Clear();
                rtbInnMessage.Text = _currentPlayer.CurrentLocation.InnAvailableHere.NotEnoughGoldMessage;
            }
        }

        private void btnInnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
