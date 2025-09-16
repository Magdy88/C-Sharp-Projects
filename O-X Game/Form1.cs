using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Teo_Game.Properties;

namespace Tic_Tac_Teo_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        stGamestates Gamestates;
        enplayer PlayerTurn = enplayer.player1;
        enum enplayer
        {
            player1,
            player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            inProgross
        }

        struct stGamestates
        {
            public enWinner Winner;
            public bool Gameover;
            public short playcount;
        }


        void EndGame()
        {
            lblTurn.Text = "GameOver";

            switch (Gamestates.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    break;


                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    break;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

    
        public bool CheckValue(Button btn1,Button btn2,Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString()
                && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor= Color.GreenYellow;
                btn2.BackColor= Color.GreenYellow;
                btn3.BackColor= Color.GreenYellow;  

                if(btn1.Tag.ToString()=="X")
                {
                    Gamestates.Winner = enWinner.Player1;
                    Gamestates.Gameover = true;
                    EndGame();
                    return true;
                }

                if(btn1.Tag.ToString()=="O")
                {
                    Gamestates.Winner=enWinner.Player2;
                    Gamestates.Gameover = true;
                    EndGame();
                    return true;
                }

               
            }
            Gamestates.Gameover = false;
            return false;


        }

        public void CheckWinner()
        {
            if (CheckValue(button1, button2, button3))
                return;

            if (CheckValue(button4, button5, button6))
                return;

            if (CheckValue(button7, button8, button9))
                return;

            if (CheckValue(button1, button4, button7))
                return;

            if (CheckValue(button2, button5, button8))
                return;

            if (CheckValue(button3, button6, button9))
                return;



            if (CheckValue(button1, button5, button9))
                return;

            if (CheckValue(button3, button5, button7))
                return;

        }


        void ChangeImage(Button btn)
        {

            if(btn.Tag.ToString()=="?")
            {
                switch (PlayerTurn)
                {
                    case enplayer.player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enplayer.player2;
                        lblTurn.Text = "Player2";
                        Gamestates.playcount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;

                        case enplayer.player2:
                        btn.Image = Resources.download;
                        PlayerTurn = enplayer.player1;
                        lblTurn.Text = "Player1";
                        Gamestates.playcount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;




                }


            }

            else
            {
                MessageBox.Show("Wrong Choise", "Wrong", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            if (Gamestates.playcount == 9)
            {
                Gamestates.Gameover = true;
                Gamestates.Winner = enWinner.Draw;
                EndGame();
            }

        }

        void ResetButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
            


        }

        void RestartGame()
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);

            lblTurn.Text = "Player1";
            PlayerTurn=enplayer.player1;
            Gamestates.Winner = enWinner.inProgross;
            lblWinner.Text = "In Progress";
            Gamestates.Gameover = false;
            Gamestates.playcount = 0;




        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
            //whitePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);
        }
    }
}
