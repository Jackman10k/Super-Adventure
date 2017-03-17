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
    public partial class PlayerStatistics : Form
    {
        Player _currentPlayer { get; set; }

        public PlayerStatistics(Player player, string playerExperienceToNextLevel)
        {
            _currentPlayer = player;
            string toNextLevel = playerExperienceToNextLevel;

            InitializeComponent();

            //Preparing UI labels for use
            lblCurrentHitPoints.DataBindings.Add("Text", _currentPlayer, "CurrentHitPoints");
            lblMaximumHitPoints.DataBindings.Add("Text", _currentPlayer, "MaximumHitPoints");
            lblGold.DataBindings.Add("Text", _currentPlayer, "Gold");
            lblExperience.DataBindings.Add("Text", _currentPlayer, "ExperiencePoints");
            lblLevel.Text = _currentPlayer.Level.ToString();
            lblCurrentAbilityPoints.DataBindings.Add("Text", _currentPlayer, "CurrentAbilityPoints");
            lblMaximumAbilityPoints.DataBindings.Add("Text", _currentPlayer, "MaximumAbilityPoints");
            lblToNextLevel.Text = toNextLevel;
            lblStrength.DataBindings.Add("Text", _currentPlayer, "Strength");
            lblDefense.DataBindings.Add("Text", _currentPlayer, "Defense");
            lblIntelligence.DataBindings.Add("Text", _currentPlayer, "Intelligence");
            lblMagicDefense.DataBindings.Add("Text", _currentPlayer, "MagicDefense");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
