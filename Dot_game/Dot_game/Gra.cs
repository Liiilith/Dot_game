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

    public struct kratka
    {
        public int ile_kraw;
        public int kolor;
        public int[] border;

    }

    class Gra
    {
        static private int[] p_color;
        private kratka[,] plansza;
        private int[] player;
        private int winner = -1;
        private int d_X;
        private int d_Y;


        public Gra(int x, int y, int p_num)
        {
            plansza = new kratka[x, y];
            d_X = x;
            d_Y = y;
            player = new int[p_num];
            p_color = new int[p_num];
            for (int k = 0; k < p_num; k++)
            {
                player[k] = 0;
                p_color[k] = k + 1;
            }
            for (int i = 0; i < d_X; i++)
            {
                for (int j = 0; j < d_Y; j++)
                {
                    plansza[i, j].ile_kraw = 0;
                    plansza[i, j].kolor = 0;
                    plansza[i, j].border = new int[4];
                    for (int k = 0; k < 2; k++)
                    {
                        plansza[i, j].border[k] = 0;
                    }
                    if (i == d_X - 1)
                    {
                        plansza[i, j].border[0] = -1;
                        plansza[i, j].border[2] = -1;
                        plansza[i, j].border[3] = -1;

                    }
                    if (j == d_Y - 1)
                    {
                        plansza[i, j].border[1] = -1;
                        plansza[i, j].border[2] = -1;
                        plansza[i, j].border[3] = -1;

                    }
                }
            }


        }
        public bool lineDrawn(int x, int y, int dir)
        {
            //plansza[x, y].ile_kraw++;
            bool res = false;
            if (dir == 1)
            {
                if (x < d_X && plansza[x, y].border[dir] == 0)
                {
                    plansza[x, y].ile_kraw++;
                    plansza[x, y].border[dir] = 1;
                    res = true;
                }

                if (x > 0 && plansza[x - 1, y].border[dir + 2] == 0)
                {
                    plansza[x - 1, y].ile_kraw++;
                    plansza[x - 1, y].border[dir + 2] = 1;
                    res = true;
                }
            }
            else
            {
                if (y < d_Y && plansza[x, y].border[dir] == 0)
                {
                    plansza[x, y].ile_kraw++;
                    plansza[x, y].border[dir] = 1;
                    res = true;
                }
                if (y > 0 && plansza[x, y - 1].border[dir + 2] == 0)
                {
                    plansza[x, y - 1].ile_kraw++;
                    plansza[x, y - 1].border[dir + 2] = 1;
                    res = true;
                }
            }
            return res;
        }


        public bool czy_zamaluj(int x, int y, int ile)
        {

            // if (x == d_X-1) x--;
            //if (y == d_Y-1) y--;
            if (plansza[x, y].ile_kraw == ile && plansza[x, y].kolor == 0) return true;
            else return false;
        }

        public int get_border(int x, int y)
        {
            int borderr = -1;

            if (plansza[x, y].ile_kraw == 3)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (plansza[x, y].border[k] == 0) borderr = k;
                }
            }
            return borderr;
        }


        public void zamaluj(int x, int y, int p_id)
        {
            plansza[x, y].kolor = p_color[p_id];
            player[p_id]++;

        }

        public Point move_symetricaly(int x, int y, int dir, int s)
        {
            Point v = new Point();

            x = d_X - x;
            y = d_Y - y;

            if (dir == 0)
            {
                x = x - 1;
                x = x * s + 35 + s / 2;
                y = y * s + 35;
            }
            else
            {
                y = y - 1;
                y = y * s + 35 + s / 2;
                x = x * s + 35;
            }

            v.X = x;
            v.Y = y;
            return v;
        }

        public bool get_index(int ind, int[] p)
        {

            if (ind == 0) return false;
            int s_ind = 0;
            for (int j = 0; j < d_Y; j++)
            {
                for (int i = 0; i < d_X; i++)
                {

                    if (!(i == d_X - 1 && j == d_Y - 1))
                    {
                        p[0] = i;
                        p[1] = j;
                        if (i == d_X - 1 && j < d_Y - 1)
                        {
                            p[2] = 1;
                            s_ind++;
                            if (s_ind == ind)
                            {
                                return true;
                            }
                        }
                        if (j == d_Y - 1 && i < d_X - 1)
                        {
                            p[2] = 0;
                            s_ind++;
                            if (s_ind == ind)
                            {
                                return true;
                            }
                        }

                        for (int k = 0; k < 2; k++)
                        {
                            p[2] = k;
                            s_ind++;
                            if (s_ind == ind)
                            {
                                return true;
                            }

                        }


                    }
                }
            }

            return false;

        }

        public int czeck_end()
        {
            int k = 0;
            int s = -1;
            for (int i = 0; i < d_X - 1; i++)
            {
                for (int j = 0; j < d_Y - 1; j++)
                {
                    if (plansza[i, j].kolor == 0) k++;
                }
            }

            if (k == 0)
            {
                int win = 0;
                for (int i = 1; i < player.Count(); i++)
                {
                    if (player[i] > player[win])
                    {
                        win = i; s = i;
                    }
                }
            }
            return s;

        }

    }
}
