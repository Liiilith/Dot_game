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
    public struct Player
    {
        public Point ind;
        public Point p1;
        public int dir;
    }

    public partial class Form1 : Form
    {
        private Pen _Pen;
        private Graphics g;
        // private Point p1;
        // private Point ind;
        private Player[] playerr;
        //private int dir;
        private int player_num = 7;
        private bool pl3_first_moved = false;
        private int s_X = 4;
        private int s_Y = 4;
        private Gra gra;
        private int s = 60;
        private int borders = 0;
        private Point third = new Point(0, 0);
        static Random r = new Random();
        private bool m_count = false;
        private static int c_pl_id;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Pen = new Pen(Color.Gray);
            borders = 0;
            _Pen.Width = 5;
            gra = new Gra(s_X, s_Y, player_num);
            playerr = new Player[player_num];
            g = pictureBox1.CreateGraphics();
            pictureBox1.Enabled = true;
            int x, y;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            g.FillRectangle(myBrush, new Rectangle(0, 0, 550, 550));
            myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            for (int i = 0; i < s_X; i++)
            {
                for (int j = 0; j < s_Y; j++)
                {

                    x = s * i + 35;
                    y = s * j + 35;
                    _Pen = new Pen(Color.LightGray);
                    _Pen.Width = 10;
                    Point p0 = new Point(x, y);
                    Point px = new Point(x + s, y);
                    Point py = new Point(x, y + s);
                    if (i != s_X - 1) { g.DrawLine(_Pen, p0, px); }
                    if (j != s_Y - 1) { g.DrawLine(_Pen, p0, py); }
                    x = s * i + 27;
                    y = s * j + 27;
                    g.FillEllipse(myBrush, new Rectangle(x, y, 16, 16));
                }
            }
            c_pl_id = 0;
        }

        private bool Draw_line(Point p, int id, int dir)
        {
            g = pictureBox1.CreateGraphics();
            pictureBox1.Enabled = true;
            _Pen = new Pen(Color.Black);
            _Pen.Width = 10;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            bool res = false;
            Point p_x = new Point(s * p.X + 35, s * p.Y + 35);
            Point p_y = new Point();
            Point p_i = new Point(p.X, p.Y);
            playerr[id].p1 = p;
            //  if (p.X == s_X - 1) p_i.X--;
            // if (p.Y == s_Y - 1) p_i.Y--;
            playerr[id].ind = p_i;
            playerr[id].dir = dir;
            if (dir == 0)
            {
                p_y = new Point(s * (p.X + 1) + 35, s * p.Y + 35);
            }
            else
            {
                p_y = new Point(s * p.X + 35, s * (p.Y + 1) + 35);
            }

            if (gra.lineDrawn(playerr[id].ind.X, playerr[id].ind.Y, playerr[id].dir))
            {
                g.DrawLine(_Pen, p_x, p_y);

                res = true;
            }
            return res;

        }

        private bool Mousee_draw(Point p, int id)
        {
            if (p.X > (s_X - 1) * s + 35 || p.Y > (s_Y - 1) * s + 35) { return false; }
            g = pictureBox1.CreateGraphics();
            bool res = false;
            Point p0, px;
            int x, y;
            int x1 = p.X;
            int y1 = p.Y;


            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(set_color(id));
            for (int i = 0; i < s_X; i++)
            {
                for (int j = 0; j < s_Y; j++)
                {

                    x = s * i + 35;
                    y = s * j + 35;
                    p0 = new Point(x, y);
                    _Pen = new Pen(set_color(id));
                    _Pen.Width = 10;

                    if ((x - 10 < x1 && x1 < x + 10) && (y + 7 < y1 && y1 < y - 7 + s))
                    {
                        px = new Point(x, y + s);
                        playerr[id].p1 = new Point(x, y);
                        playerr[id].ind = new Point(i, j);
                        playerr[id].dir = 1;

                        if (gra.lineDrawn(playerr[id].ind.X, playerr[id].ind.Y, playerr[id].dir))
                        {
                            g.DrawLine(_Pen, p0, px);

                            res = true;
                        }

                    }
                    else if ((y - 10 < y1 && y1 < y + 10) && (x + 7 < x1 && x1 < x - 7 + s))
                    {

                        px = new Point(x + s, y);
                        playerr[id].p1 = new Point(x, y);
                        playerr[id].ind = new Point(i, j);
                        playerr[id].dir = 0;
                        if (gra.lineDrawn(playerr[id].ind.X, playerr[id].ind.Y, playerr[id].dir))
                        {
                            g.DrawLine(_Pen, p0, px);

                            res = true;
                        }

                    }
                }
            }
            return res;
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



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           // Open_click(sender, e);


        }

        private void Open_click(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            Point versus = new Point();

            Mousee_draw(p, c_pl_id);
            if (fill_all_dotta(c_pl_id))
            {
                m_count = true;
                while (check_all_dotta(c_pl_id)) { fill_all_dotta(c_pl_id); m_count = true; }
            }
            if (m_count) m_count = false;
            else
            {
                c_pl_id++;
                c_pl_id = c_pl_id % player_num;
            }
            int end = gra.czeck_end();
            if (end > -1)
            {
                string s = "Player: " + end.ToString() + "!";
                System.Windows.Forms.MessageBox.Show(s, "END");
            }
            //    versus = move_symetricaly_xy(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir);
            // versus = move_symetricaly_x(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir);
            //versus = move_symetricaly_y(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir);
            // versus = ortogonal(playerr[0].ind, playerr[0].dir);
            // fill_all_dotta(0);
            // while (check_all_dotta(0)) { fill_all_dotta(0); m_count = true; }
            // if(fill_all_dotta(0)) m_count = true;
            //
            // if (m_count) m_count = false;
            //  else
            //   {
            // pictureBox1.Enabled = false;
            // fill_all_dotta(1);
            //responsee2();
            // borders++;
            //rAndom4(borders);
            //rAndom45(borders);
            //  reply();
            // }


            //  }
            // }


        }


        public void responsee()
        {

        }

        public void reply()
        {

            int counterr = 0;
            bool result = false;
            while (!result)
            {
                result = rAndom();
                counterr++;
                if (counterr > 1000)
                {
                    System.Windows.Forms.MessageBox.Show("No more moves", "Buuu");
                    break;
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
        public Point ortogonal(Point p, int dir)
        {
            Point ort = new Point();
            ort = new Point(p.X, p.Y);

            if (dir == 1 && p.X == s_X - 1)
            {
                ort.X--; ;
            }
            if (dir == 0 && p.Y == s_Y - 1)
            {
                ort.Y--; ;
            }

            bool res = Draw_line(ort, 1, 1 - dir);
            return ort;
        }

        public bool rAndom()
        {
            Point ort = new Point();
            int[] p = new int[3];
            int border = r.Next(1, (s_X) * (s_Y) * 2 + s_X + s_Y + 1);
            for (int k = 0; k < 2; k++)
            {
                p[k] = 0;

            }
            bool res = gra.get_index(border, p);

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
        public bool fill_all_dotta(int player)
        {
            Point p2;
            bool res = false;
            Color c = set_color(player);
            for (int i = 0; i < s_X - 1; i++)
            {
                for (int j = 0; j < s_Y - 1; j++)
                {
                    if (gra.czy_zamaluj(i, j, 4))
                    {
                        p2 = new Point(s * i + 35, s * j + 35);
                        paint_dotta(p2, c);
                        gra.zamaluj(i, j, player);
                        res = true;
                    }
                }
            }
            return res;
        }
        public bool check_all_dotta(int player)
        {
            Point px, py;
            int x, y, k, d;
            bool res = false;
            Color c = set_color(player);
            for (int i = 0; i < s_X - 1; i++)
            {
                for (int j = 0; j < s_Y - 1; j++)
                {
                    if (gra.czy_zamaluj(i, j, 3))
                    {
                        k = gra.get_border(i, j);
                        d = k % 2;
                        switch (k)
                        {
                            case 0:
                                {
                                    x = i;
                                    y = j;
                                    px = new Point(s * x + 35, s * y + 35);
                                    break;
                                }
                            case 1:
                                {
                                    x = i;
                                    y = j;
                                    px = new Point(s * x + 35, s * y + 35);
                                    break;
                                }
                            case 2:
                                {
                                    x = i;
                                    y = j + 1;
                                    px = new Point(s * x + 35, s * y + 35);
                                    break;
                                }
                            default://k=3
                                {
                                    x = i + 1;
                                    y = j;
                                    px = new Point(s * x + 35, s * y + 35);
                                    break;
                                }

                        }

                        if (d == 0) py = new Point(s * (x + 1) + 35, s * y + 35);
                        else py = new Point(s * x + 35, s * (y + 1) + 35);
                        g.DrawLine(_Pen, px, py);
                        gra.lineDrawn(x, y, d);

                        // fill_all_dotta(player);
                        res = true;
                    }
                }
            }

            return res;

        }

        public void move_player1()
        {
            Point versus = new Point();
            versus = move_symetricaly_xy(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir);
            while (check_all_dotta(1)) { check_all_dotta(1); }
            if (!Mousee_draw(versus, 1))
            {
                versus = move_symetricaly_x(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir);
                if (!Mousee_draw(versus, 1))
                {
                    versus = move_symetricaly_y(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir);
                    if (!Mousee_draw(versus, 1))
                    {
                        versus = ortogonal(playerr[0].ind, playerr[0].dir);
                        if (!Mousee_draw(versus, 1))
                        {
                            versus = ortogonal(playerr[0].ind, playerr[0].dir);
                            if (!Mousee_draw(versus, 1))
                            {

                                versus = ortogonal(playerr[0].ind, playerr[0].dir);
                                while (!Mousee_draw(versus, 1)) { rAndom(); }

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

        public void paint_dotta(Point p, Color c)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
            g.FillEllipse(myBrush, new Rectangle(p.X + s / 2 - 13, p.Y + s / 2 - 13, 26, 26));


        }


        public Color set_color(int id)
        {
            Color c;
            switch (id)
            {
                case 0:
                    c = Color.Red;
                    break;
                case 1:
                    c = Color.Blue;
                    break;
                case 2:
                    c = Color.Purple;
                    break;
                case 3:
                    c = Color.Green;
                    break;
                case 4:
                    c = Color.Yellow;
                    break;

                case 5:
                    c = Color.Pink;
                    break;
                case 6:
                    c = Color.Orange;
                    break;
                default:
                    c = Color.Black;
                    break;
            }
            return c;
        }


        public Point move_symetricaly_xy(int x1, int y1, int dir)
        {
            Point v = new Point();
            int x, y;

            x = s_X - 1 - x1;
            y = s_Y - 1 - y1;
            // }
            if (dir == 0)
            {
                x = x - 1;

            }
            else
            {
                y = y - 1;

            }

            v.X = x;
            v.Y = y;

            bool res = Draw_line(v, 1, dir);

            return v;
        }

        public Point move_symetricaly_x(int x1, int y1, int dir)
        {
            Point v = new Point();
            int x, y;

            x = s_X - 1 - x1 - 1;
            y = y1;

            // }
            if (dir == 1)
            {
                x++;
                if (x1 == s_X - 1) x = 0;

            }


            v.X = x;
            v.Y = y;

            bool res = Draw_line(v, 1, dir);
            return v;
        }

        public Point move_symetricaly_y(int x1, int y1, int dir)
        {
            Point v = new Point();
            int x, y;

            x = x1;
            y = s_Y - 1 - y1 - 1;

            // }
            if (dir == 0)
            {
                y++;
                if (y1 == s_Y - 1) y = 0;

            }

            v.X = x;
            v.Y = y;
            bool res = Draw_line(v, 1, dir);
            return v;
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




    }
}







