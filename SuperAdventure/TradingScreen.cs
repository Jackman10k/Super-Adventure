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
    public partial class TradingScreen : Form
    {
        public Player _currentPlayer { get; set; }
        BindingList<InventoryItem> playerInventoryThatVendorWillBuy = new BindingList<InventoryItem>();

        public TradingScreen(Player player)
        {
            _currentPlayer = player;

            InitializeComponent();

            //Filling in UI with information from the specific vendor at the location
            lblVendorName.Text += _currentPlayer.CurrentLocation.VendorWorkingHere.Name;
            rtbVendorText.Text += _currentPlayer.CurrentLocation.VendorWorkingHere.Greeting;

            //Styling column values
            DataGridViewCellStyle rightAlignedCellStyle = new DataGridViewCellStyle();
            rightAlignedCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Populating the datagrid for the player's inventory
            dgvPlayerItems.RowHeadersVisible = false;
            dgvPlayerItems.AutoGenerateColumns = false;

            //This hidden column holds the item ID, so we know which item to sell
            dgvPlayerItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ItemID",
                Visible = false
            });

            dgvPlayerItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 150,
                DataPropertyName = "Description"
            });

            dgvPlayerItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Qty",
                Width = 30,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = "Quantity"
            });

            dgvPlayerItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                Width = 50,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = "Price"
            });

            dgvPlayerItems.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Sell 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "ItemID"
            });

            /*dgvPlayerItems.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Sell All",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "ItemID"
            });*/

            //Only showing items in player inventory that vendor will buy
            foreach (InventoryItem item in _currentPlayer.Inventory)
            {
                foreach (Item buyableItem in _currentPlayer.CurrentLocation.VendorWorkingHere.ItemsVendorWillBuy)
                {
                    if (item.ItemID == buyableItem.ID)
                        playerInventoryThatVendorWillBuy.Add(item);
                }    
            }

            //Binding the player's buyable inventory to the datagridview
            dgvPlayerItems.DataSource = playerInventoryThatVendorWillBuy;

            //When the user clicks on a row, call this function
            dgvPlayerItems.CellClick += dgvPlayerItems_CellClick;

            //Populating the datagrid for the vendor's inventory
            dgvVendorItems.RowHeadersVisible = false;
            dgvVendorItems.AutoGenerateColumns = false;

            //This hidden column holds the item ID, so we know which item to buy
            dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ItemID",
                Visible = false
            });

            dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 150,
                DataPropertyName = "Description"
            });

            dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                Width = 50,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = "Price"
            });

            dgvVendorItems.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Buy 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = "ItemID"
            });

            //Binding the vendor's inventory to the datagridview 
            dgvVendorItems.DataSource = _currentPlayer.CurrentLocation.VendorWorkingHere.Inventory;

            //When the user clicks on a row, call this function
            dgvVendorItems.CellClick += dgvVendorItems_CellClick;
        }

        private void dgvPlayerItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*The first column of a datagridview has a ColumnIndex = 0
              This is known as a "zero-based" array/collection/list.
              You start counting with 0.
            
              The 5th column (ColumnIndex = 4) is the column with the button.
              So, if the player clicked the button column, we will sell an item from that row.*/

            //Performing operations when the player clicks the 5th column
            if (e.ColumnIndex == 4)
            {
                //Getting the ID of the item at the specific row and column
                var itemID = dgvPlayerItems.Rows[e.RowIndex].Cells[0].Value;

                //Getting the Item object for the selected item row with the ID
                Item itemBeingSold = World.ItemByID(Convert.ToInt32(itemID));

                if (itemBeingSold.Price == World.UNSELLABLE_ITEM_PRICE)
                {
                    //Telling player they cannot sell an unsellable item
                    MessageBox.Show("You cannot sell the " + itemBeingSold.Name);
                }
                else
                {
                    if(Convert.ToInt32(dgvPlayerItems.Rows[e.RowIndex].Cells[2].Value) <= 0)
                    {
                        //Telling player they don't have any of an item left to sell
                        MessageBox.Show("You don't have any of these left to sell.");
                    }
                    else
                    {
                        //Removing one of these items from the player's inventory
                        _currentPlayer.RemoveItemFromInventory(itemBeingSold);
                        playerInventoryThatVendorWillBuy.Remove(ConvertItemToInventoryItem(itemBeingSold));

                        //Giving the player the gold for the item being sold.
                        _currentPlayer.Gold += itemBeingSold.Price;
                    }
                }
            }

            //Displaying item description if players click the second column instead
            else if (e.ColumnIndex == 1)
            {
                rtbPlayerItemDescription.Clear();
                var itemID = dgvPlayerItems.Rows[e.RowIndex].Cells[0].Value;
                Item selectedItem = World.ItemByID(Convert.ToInt32(itemID));
                rtbPlayerItemDescription.Text += selectedItem.Description;
            }
        }

        private void dgvVendorItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // The 4th column (ColumnIndex = 3) has the "Buy 1" button.
            if (e.ColumnIndex == 3)
            {
                //This gets the ID value of the item, from the hidden 1st column
                var itemID = dgvVendorItems.Rows[e.RowIndex].Cells[0].Value;

                //Getting the Item object for the selected item row
                Item itemBeingBought = World.ItemByID(Convert.ToInt32(itemID));

                //Checking to see if player is buying a one-off item
                if (itemBeingBought.CanOnlyHaveOne)
                {
                    foreach (InventoryItem item in _currentPlayer.Inventory)
                    {
                        if (item.ItemID == itemBeingBought.ID)
                        {
                            MessageBox.Show("You cannot have more than one of this item.");
                            return;
                        }
                    }
                }

                //Checking if the player has enough gold to buy the item
                if (_currentPlayer.Gold >= itemBeingBought.Price)
                {
                    //Adding one of the items to the player's inventory
                    _currentPlayer.AddItemToInventory(itemBeingBought);

                    //Removing the gold to pay for the item
                    _currentPlayer.Gold -= itemBeingBought.Price;
                }
                else
                {
                    //Informing player they cannot afford an item
                    MessageBox.Show("You do not have enough gold to buy the " + itemBeingBought.Name);
                }
            }

            //Displaying item description if players click the second column instead
            else if (e.ColumnIndex == 1)
            {
                rtbVendorItemDescription.Clear();
                var itemID = dgvVendorItems.Rows[e.RowIndex].Cells[0].Value;
                Item selectedItem = World.ItemByID(Convert.ToInt32(itemID));
                rtbVendorItemDescription.Text += selectedItem.Description;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public InventoryItem ConvertItemToInventoryItem(Item itemToRemove, int quantity = 1)
        {
            InventoryItem item = _currentPlayer.Inventory.SingleOrDefault(ii => ii.Details.ID == itemToRemove.ID);
            return new InventoryItem(itemToRemove, quantity);
        }
    }
}
