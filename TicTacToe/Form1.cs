using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        List<Button> buttons = new List<Button>();
        int turn = 1;
        Boolean gameInProgress = false;
        public Form1()
        {
            InitializeComponent();
            initialiseButtons();
        }

        private void initialiseButtons()
        {
            int xPos = 0;
            int yPos = 0;
            for (int i = 0; i < 9; i++)
            {
                buttons.Add(new Button());
                buttons[i].Location = new Point(xPos, yPos);
                buttons[i].Margin = new Padding(4, 4, 4, 4);
                buttons[i].Name = "tile" + i;
                buttons[i].Size = new Size(50, 50);
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Click += new EventHandler(this.TileClick);
                this.Controls.Add(buttons[i]);
                xPos += 50;
                if (xPos % 3 == 0)
                {
                    yPos += 50;
                    xPos = 0;
                }
            }
        }

        private void TileClick(object sender, EventArgs e)
        {
            if (this.gameInProgress == false)
            {
                for (int i = 0; i < 9; i++)
                {
                    buttons[i].Text = "";
                }
                this.gameInProgress = true;
            }
            else
            {
                var tile = (Button)sender;
                if (tile.Text == "")
                {
                    if (this.turn == 1)
                    {
                        tile.Text = "X";
                        this.turn = 2;
                    }
                    else
                    {
                        tile.Text = "O";
                        this.turn = 1;
                    }
                }
                this.CheckWinCondition();
            }
        }

        private void CheckWinCondition()
        {
            if (
                buttons[0].Text == buttons[1].Text && buttons[1].Text == buttons[2].Text && buttons[0].Text != ""||
                buttons[3].Text == buttons[4].Text && buttons[4].Text == buttons[5].Text && buttons[3].Text != "" ||
                buttons[6].Text == buttons[7].Text && buttons[7].Text == buttons[8].Text && buttons[6].Text != "" ||
                buttons[0].Text == buttons[3].Text && buttons[3].Text == buttons[6].Text && buttons[0].Text != "" ||
                buttons[1].Text == buttons[4].Text && buttons[4].Text == buttons[7].Text && buttons[1].Text != "" ||
                buttons[2].Text == buttons[5].Text && buttons[5].Text == buttons[8].Text && buttons[2].Text != "" ||
                buttons[0].Text == buttons[4].Text && buttons[4].Text == buttons[8].Text && buttons[0].Text != "" ||
                buttons[6].Text == buttons[4].Text && buttons[4].Text == buttons[2].Text && buttons[6].Text != ""
            )
            {
                Console.WriteLine("Game Over");
                this.gameInProgress = false;
            }
        }
    }
}
