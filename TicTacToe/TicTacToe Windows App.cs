using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe_Windows_App : Form
    {
        public static int count = 0;
        List<int> player1, player2;
        List<PossibleRows> possibility;

        public static Boolean Status;


        public TicTacToe_Windows_App()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btnText = (Button)sender;

            btnText.Enabled = false;

            if (count % 2 == 0)
            {
                btnText.Text = "X";
                player1.Add(btnText.TabIndex);
                if (whoWonTicTacToe(player1, "X"))
                    MessageBox.Show("Player 1 won");
            }
            else
            {
                btnText.Text = "O";
                player2.Add(btnText.TabIndex);
                if (whoWonTicTacToe(player2, "O"))
                    MessageBox.Show("Player 2 won");
            }
            count++;

            if (count > 8 && Status == false)
                MessageBox.Show("Draw");

            if (Status == true || count > 8)
                StartAgain();

        }

        public void StartAgain()
        {
            player1 = new List<int>();
            player2 = new List<int>();

            count = 0;
            Status = false;

            this.button1.Text = this.button2.Text = this.button3.Text = this.button4.Text = this.button5.Text = this.button6.Text = this.button7.Text = this.button8.Text = this.button9.Text = "";
            this.button1.Enabled = this.button2.Enabled = this.button3.Enabled = this.button4.Enabled = this.button5.Enabled = this.button6.Enabled = this.button7.Enabled = this.button8.Enabled = this.button9.Enabled = true;

        }

        public bool whoWonTicTacToe(List<int> items, string Player)
        {
            int CountMe = 0;

            if (items.Count < 3)
                return false;

            foreach (var sucess in possibility)
            {
                CountMe = 0;
                foreach (var item in sucess.Rows)
                {
                    foreach (var row in items)
                    {
                        if (row.Equals(item))
                            CountMe++;
                    }

                }

                if (CountMe >= 3)
                {
                    Status = true;
                    return true;
                }
            }

            return false;
        }

        private void TicTacToe_Windows_App_Load(object sender, EventArgs e)
        {
            player1 = new List<int>();
            player2 = new List<int>();

            possibility = new List<PossibleRows>();

            possibility.Add(new PossibleRows() { Rows = new int[] { 0, 1, 2 } });
            possibility.Add(new PossibleRows() { Rows = new int[] { 0, 4, 8 } });
            possibility.Add(new PossibleRows() { Rows = new int[] { 0, 3, 6 } });
            possibility.Add(new PossibleRows() { Rows = new int[] { 6, 4, 2 } });
            possibility.Add(new PossibleRows() { Rows = new int[] { 3, 4, 5 } });
            possibility.Add(new PossibleRows() { Rows = new int[] { 6, 7, 8 } });
            possibility.Add(new PossibleRows() { Rows = new int[] { 1, 4, 7 } });
            possibility.Add(new PossibleRows() { Rows = new int[] { 2, 5, 8 } });
        }

        public class PossibleRows
        {
            public int[] Rows { get; set; }
        }
    }
}
