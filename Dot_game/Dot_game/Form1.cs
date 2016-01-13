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
        private int player_num = 2;
        private bool pl3_first_moved = false;
        private int s_X = 9;
        private int s_Y = 9;
        private Gra gra;
        private int s = 60;
        private int borders = 0;
        private int tryb = 0;
        private Point third = new Point(0, 0);
        static Random r = new Random();
        private bool m_count = false;
        private static int c_pl_id;
        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Point p = e.Location;
            Point versus = new Point();
            if (tryb == 0)
            {
                Open_Comp_click(p);
            }
            else
            {
                Open_click(p);
            }
            // Open_click(p);
            Open_Comp_click(p);

        }



        private void Open_click(Point p)
        {
            if (Mousee_draw(p, c_pl_id))
            {


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
                end_of_game();
            }
        }


        private void Open_Comp_click(Point p)
        {
            if (Mousee_draw(p, 0))
            {
                //strategy_1(1);
                if (fill_all_dotta(0))
                {
                    m_count = true;
                    while (check_all_dotta(0)) { fill_all_dotta(0); m_count = true; }
                }
                if (m_count) m_count = false;
                else
                {
                    //c_pl_id++;
                    // c_pl_id = c_pl_id % player_num;
                    strategy_1(1);


                }
            }
            end_of_game();



        }

        public void strategy_1(int id)
        {


            while (check_all_dotta(id)) { fill_all_dotta(id); m_count = true; }

            m_oponnent(id);
            if (fill_all_dotta(id))
            {
                m_count = false;
                while (check_all_dotta(id)) { fill_all_dotta(id); m_count = true; }
                m_oponnent(id);
            }


            m_count = false;




        }

        public bool m_oponnent(int id)
        {
            Point versus = new Point();
            bool res = false;
            if (!move_symetricaly_x(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir, versus, id))
            {
                if (!move_symetricaly_x(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir, versus, id))
                {

                    if (!move_symetricaly_y(playerr[0].ind.X, playerr[0].ind.Y, playerr[0].dir, versus, id))
                    {
                        if (!ortogonal(playerr[0].ind, playerr[0].dir, versus, id))
                        {

                            reply_rand(id);

                        }

                    }


                }
            }
            return res;
        }


        public bool ortogonal(Point p, int dir, Point ort, int id)
        {


            if (dir == 1 && p.X == s_X - 1)
            {
                ort.X--; ;
            }
            if (dir == 0 && p.Y == s_Y - 1)
            {
                ort.Y--; ;
            }

            bool res = Draw_line(ort, id, 1 - dir);
            return res;
        }

        public bool move_symetricaly_xy(int x1, int y1, int dir, Point v, int id)
        {

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

            bool res = Draw_line(v, id, dir);

            return res;
        }

        public bool move_symetricaly_x(int x1, int y1, int dir, Point v, int id)
        {

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

            bool res = Draw_line(v, id, dir);
            return res;
        }

        public bool move_symetricaly_y(int x1, int y1, int dir, Point v, int id)
        {

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
            bool res = Draw_line(v, id, dir);
            return res;
        }

        public bool reply_rand(int id)
        {

            int counterr = 0;
            bool result = false;
            while (!result)
            {
                result = rAndom(id);
                counterr++;
                if (counterr > 1000)
                {
                    System.Windows.Forms.MessageBox.Show("No more moves", "Buuu");
                    result = false;
                    break;
                }

            }
            return result;
        }

        public bool rAndom(int id)
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
                res = Draw_line(ort, id, p[2] % 2);
            }

            return res;



        }




        private void button1_Click(object sender, EventArgs e)
        {

            if (tryb == 0)
            {

                player_num = 2;
                numericUpDown2.Value = player_num;

            }


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
            _Pen = new Pen(set_color(id));
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
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(set_color(player));
            _Pen = new Pen(set_color(player));
            _Pen.Width = 10;
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
                    c = Color.Black;
                    break;
                case 6:
                    c = Color.Orange;
                    break;
                case 7:
                    c = Color.Brown;
                    break;
                default:
                    c = Color.Pink;
                    break;
            }
            return c;
        }

        private void end_of_game()
        {
            int end = gra.czeck_end();
            if (end == 0)
            {
                int end3 = gra.czeck_pairs();
                if (end3 == 0)
                {

                    System.Windows.Forms.MessageBox.Show("Remis", "END");
                }
                else
                {
                    int end2 = gra.czeck_winner();
                    if (end2 > -1)
                    {
                        string s = "Player: " + end.ToString() + "!";
                        System.Windows.Forms.MessageBox.Show(s, "Winner");
                    }
                }

            }



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;

            player_num = Convert.ToInt32(nud.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;

            tryb = Convert.ToInt32(nud.Value);

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;

            s_X = Convert.ToInt32(nud.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;

            s_Y = Convert.ToInt32(nud.Value);
        }

    }
}







