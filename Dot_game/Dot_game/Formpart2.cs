using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dot_game
{
     public partial class Form1 : Form
    {


         public static DialogResult ConfigBox(ref string player_num, ref string s_X, ref string s_Y, ref string tryb)
         {
             Form form = new Form();
             Label label1 = new Label();
             Label label2 = new Label();
             Label label3 = new Label();
             Label label4 = new Label();
             Label label5 = new Label();
             TextBox textBox4 = new TextBox();
             TextBox textBox1 = new TextBox();
             TextBox textBox2 = new TextBox();
             TextBox textBox3 = new TextBox(); 
             TextBox textBox = new TextBox();
             Button buttonOk = new Button();
             Button buttonCancel = new Button();

             form.Text = "KONFIGURACJA:";
             label1.Text = "Liczba graczy";
             label4.Text = "Rozmiar planszy:";
             label2.Text = "N:";
             label3.Text = "M:";
             label5.Text = "Tryb Gry (0- vs Comp 1- Open)";
             player_num = textBox1.Text;
             s_X = textBox2.Text;
             s_Y = textBox3.Text;
             tryb = textBox4.Text;
			 
            
             buttonOk.Text = "OK";
             buttonCancel.Text = "Cancel";
             buttonOk.DialogResult = DialogResult.OK;
             buttonCancel.DialogResult = DialogResult.Cancel;


             label5.SetBounds(10, 10, 330, 30);
             label1.SetBounds(10, 100, 100, 30);
             label2.SetBounds(10, 190, 15, 30);
             label3.SetBounds(150, 190, 15, 30);
             label4.SetBounds(10, 145, 100, 30);
             textBox4.SetBounds(10, 55, 30, 30);
             textBox2.SetBounds(210, 190, 30, 30);
             textBox3.SetBounds(100, 190, 30, 30);
             textBox1.SetBounds(220, 100, 30, 30);
             buttonOk.SetBounds(20, 230, 60, 30);
             buttonCancel.SetBounds(100, 230, 60, 30);
			

             label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
             label1.AutoSize = false;
             label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
             label2.AutoSize = false;
             label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
             label3.AutoSize = false;
             label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
             label4.AutoSize = false;
             label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
             label5.AutoSize = false;
             textBox1.AutoSize = false;
             textBox2.AutoSize = false;
             textBox3.AutoSize = false;
             textBox4.AutoSize = false;
             buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
             buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

             form.ClientSize = new Size(350, 270);
             form.Controls.Add(label1);
             form.Controls.Add(label2);
             form.Controls.Add(label3);
             form.Controls.Add(label4);
             form.Controls.Add(label5);
             form.Controls.Add(textBox1);
             form.Controls.Add(textBox2);
             form.Controls.Add(textBox3);
             form.Controls.Add(textBox4);
             form.Controls.Add(buttonOk);
             form.Controls.Add(buttonCancel);
             form.FormBorderStyle = FormBorderStyle.FixedDialog;
             form.StartPosition = FormStartPosition.CenterScreen;
             form.MinimizeBox = false;
             form.MaximizeBox = false;
             form.AcceptButton = buttonOk;
             form.CancelButton = buttonCancel;

             DialogResult dialogResult = form.ShowDialog();
             
             return dialogResult;
         }








        public void fill_dotta(int player)
        {

            Point p2;
            Color c = set_color(player);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
            //  zamaluj = gra.czy_zamaluj(ind.X, ind.Y);
            if (gra.czy_zamaluj(playerr[0].ind.X, playerr[0].ind.Y, 4))
            {
                p2 = new Point(playerr[0].p1.X, playerr[0].p1.Y);
                paint_dotta(p2, c);
            }
            if (playerr[0].dir == 0 && playerr[0].ind.Y > 0)
            {
                if (gra.czy_zamaluj(playerr[0].ind.X, playerr[0].ind.Y - 1, 4))
                {
                    p2 = new Point(playerr[0].p1.X, playerr[0].p1.Y - s);
                    paint_dotta(p2, c);
                }
            }
            if (playerr[0].dir == 1 && playerr[0].ind.X > 0)
            {
                if (gra.czy_zamaluj(playerr[0].ind.X - 1, playerr[0].ind.Y, 4))
                {
                    p2 = new Point(playerr[0].p1.X - s, playerr[0].p1.Y);
                    paint_dotta(p2, c);
                }
            }
        }

        public void fill_dotta_2(int player)
        {

            Point p2;
            Color c = set_color(player);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
            //  zamaluj = gra.czy_zamaluj(ind.X, ind.Y);
            if (gra.czy_zamaluj(playerr[0].ind.X, playerr[0].ind.Y, 4))
            {
                p2 = new Point(playerr[0].p1.X, playerr[0].p1.Y);
                paint_dotta(p2, c);
            }
            if (playerr[0].dir == 0 && playerr[0].ind.Y > 0)
            {
                if (gra.czy_zamaluj(playerr[0].ind.X, playerr[0].ind.Y - 1, 4))
                {
                    p2 = new Point(playerr[0].p1.X, playerr[0].p1.Y - s);
                    paint_dotta(p2, c);
                }
            }
            if (playerr[0].dir == 1 && playerr[0].ind.X > 0)
            {
                if (gra.czy_zamaluj(playerr[0].ind.X - 1, playerr[0].ind.Y, 4))
                {
                    p2 = new Point(playerr[0].p1.X - s, playerr[0].p1.Y);
                    paint_dotta(p2, c);
                }
            }
        }

        public void responsee2()
        {
            Point versus = new Point();
            int k = 0;
            for (int i = 0; i < s_X; i++)
            {
                for (int j = 0; j < s_Y; j++)
                {
                    rAndom4(k);
                    k++;
                }
            }


            /*
            versus = rAndom2(playerr[0].ind);
            versus = rAndom3(borders);
            
            int counterr = 0;
            while (!rAndom4(borders))
            {
                counterr++;
                borders++;
                if (counterr > 1000)
                {
                    System.Windows.Forms.MessageBox.Show("No more moves", "Buuu");
                    break;
                }

            }*/
        }

        public void player3_moves()
        {
            if (pl3_first_moved)
            {
                fill_all_dotta(2);

                while (check_all_dotta(2)) { fill_all_dotta(2); }
            }
            else
            {
                if (playerr[0].dir == 0)
                {
                    third = new Point((playerr[0].ind.X) * s + 35, (playerr[0].ind.Y) * s + 35 + s / 2);
                }
                else
                {
                    third = new Point((playerr[0].ind.X) * s + 35 + s / 2, (playerr[0].ind.Y) * s + 35);
                }
                Draw_line(third, 3, 2 - playerr[0].dir);
                pl3_first_moved = true;
            }
        }

        public void move_player1()
        {
            Point versus = new Point();
            move_symetricaly_xy(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir, versus, 1);
            while (check_all_dotta(1)) { check_all_dotta(1); }
            if (!Mousee_draw(versus, 1))
            {
                move_symetricaly_x(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir, versus, 1);
                if (!Mousee_draw(versus, 1))
                {
                    move_symetricaly_y(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir, versus, 1);
                    if (!Mousee_draw(versus, 1))
                    {
                        ortogonal(playerr[0].ind, playerr[0].dir, versus, 1);
                        if (!Mousee_draw(versus, 1))
                        {
                            ortogonal(playerr[0].ind, playerr[0].dir, versus, 1);
                            if (!Mousee_draw(versus, 1))
                            {

                                ortogonal(playerr[0].ind, playerr[0].dir, versus, 1);
                                while (!Mousee_draw(versus, 1)) { rAndom(1); }

                                /*if (!Mousee_draw(versus, 1))
                                {

                                    System.Windows.Forms.MessageBox.Show("No more moves", "Buuu");
                                }*/

                            }

                        }

                    }

                }


            }

        }

        public Point rAndom3(int bord)
        {
            Point ort = new Point();
            int[] p = new int[3];
            int border = bord++;
            for (int k = 0; k < 2; k++)
            {
                p[k] = 0;

            }
            bool res = gra.get_index(border, p);
            if (res)
            {
                if (p[2] % 2 == 0)
                {

                    ort = new Point((p[0]) * s + 35, (p[1]) * s + 35 + s / 2);
                }
                else
                {

                    ort = new Point((p[0]) * s + 35 + s / 2, (p[1]) * s + 35);
                }
            }


            return ort;
        }

        public bool rAndom4(int bord)
        {
            Point ort = new Point();
            int[] p = new int[3];
            for (int k = 0; k < 3; k++)
            {
                p[k] = 0;

            }

            bool res = gra.get_index(bord, p);

            if (res)
            {
                ort = new Point(p[0], p[1]);
                res = Draw_line(ort, 1, p[2] % 2);
            }

            return res;
        }

        public Point rAndom2(Point p)
        {
            Point ort = new Point(0, 0);

            int dir = r.Next(2);


            if (dir == 0)
            {
                ort.X = r.Next(s_X - 1);
                ort = new Point((ort.X) * s + 35, (ort.Y) * s + 35 + s / 2);
            }
            else
            {
                ort.Y = r.Next(s_Y - 1);
                ort = new Point((ort.X) * s + 35 + s / 2, (ort.Y) * s + 35);
            }

            return ort;
        }

        public bool rAndom45(int bord)
        {
            Point ort = new Point();
            int[] p = new int[3];
            bool res = false;
            int bordd = 0;
            for (int d = 1; d < (s_X) * (s_Y) * 2 + s_X + s_Y; d++)
            {


                for (int k = 0; k < 3; k++)
                {
                    p[k] = 0;

                }

                res = gra.get_index(bordd, p);

                if (res)
                {
                    ort = new Point(p[0], p[1]);
                    res = Draw_line(ort, 1, p[2] % 2);
                }

                bordd++;


            }

            return res;
        }

        private bool Comp_draw(int[] pp, int id)
        {

            g = pictureBox1.CreateGraphics();
            bool res = false;
            Point p0, px;
            int x, y;
            int i = pp[0];
            int j = pp[1];
            int k = pp[2] % 2;
            x = i;
            y = j;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            if (k == 0)
            {
                x++;
            }
            else
            {
                y++;
            }

            px = new Point(s * x + 35, s * y + 35);
            p0 = new Point(s * i + 35, s * j + 35);
            _Pen = new Pen(Color.Black);
            _Pen.Width = 10;


            playerr[id].p1 = new Point(s * i + 35, s * j + 35);
            playerr[id].ind = new Point(i, j);
            playerr[id].dir = pp[2] % 2;

            if (gra.lineDrawn(playerr[id].ind.X, playerr[id].ind.Y, playerr[id].dir))
            {
                g.DrawLine(_Pen, p0, px);

                res = true;
            }

            return res;
        }
      
    }
}
