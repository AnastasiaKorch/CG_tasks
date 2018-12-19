using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Триангуляция_Делоне
{
	public partial class Form1 : Form
	{
		Bitmap bmp;
		Pen pen = new Pen(Color.Red, 4);
		public Form1()
		{
			InitializeComponent();
			bmp = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
			pictureBox.Image = bmp;
			//pen.EndCap = LineCap.ArrowAnchor;
		}

		Graphics g;
		List<my_point> points = new List<my_point>(); // список точек
		List<edge> edges = new List<edge>(); // список рёбер
		SolidBrush brush = new SolidBrush(Color.LightGreen); //цвет кисти

		
		// Добавляем/удаляем точки
		private void pictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			my_point p = null;
			foreach (my_point pp in points)
				if (Math.Abs(pp.X - e.X) <= 3 && Math.Abs(pp.Y - e.Y) <= 3)
					p = pp;

			// если нажата левая кнопка мыши, то добавляем
			if (e.Button == MouseButtons.Left)
			{
				my_point new_p = new my_point(e.X, e.Y);
				points.Add(new_p);
				g.FillEllipse(brush, new_p.X - 4, new_p.Y - 4, 8, 8);
				pictureBox.Image = bmp;
				return;
			}

			// иначе - удаляем
			else
			{
				points.Remove(p);
				redrawImage();
			}
		}

		// Очищаем рисунок
		private void butt_clear_Click(object sender, EventArgs e)
		{
			g.Clear(Color.White);
			points.Clear();
			edges.Clear();
			pictureBox.Image = bmp;
		}

		
		// Перерисовываем pictureBox
		private void redrawImage()
		{
			g.Clear(Color.White);
			foreach (my_point p in points)
				g.FillEllipse(brush, p.X - 4, p.Y - 4, 8, 8);
			foreach (edge e in edges)
				g.DrawLine(pen, e.P1.X, e.P1.Y, e.P2.X, e.P2.Y);
			pictureBox.Image = bmp;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			g = Graphics.FromImage(bmp);
		}

		// Определяет c какой стороны относительно направленного ребра лежит точка
		// ed - ребро
		// pt - точка
		// 1 - слева, -1 - справа, 0 - на ребре
		private int pos_rel_edge(edge ed, my_point pt)
		{
			double z = (ed.P2.Y - ed.P1.Y) * pt.X + (ed.P1.X - ed.P2.X) * pt.Y + (ed.P1.X * (ed.P1.Y - ed.P2.Y) + ed.P1.Y * (ed.P2.X - ed.P1.X));
			if (z < 0)
				return -1;
			else
				if (z > 0)
					return 1;
				else
					return 0;
		}


        // Вычисляется абсолютное значение угла между двумя ребрами
		// e1 - Первое ребро
		// e2 - Второе ребро
		//Возвращается значение угла между ребрами в градусах
		private double degree_between_edges(edge e1, edge e2)
		{
			int e1X = e1.P2.X - e1.P1.X;
			int e1Y = e1.P2.Y - e1.P1.Y;
			int e2X = e2.P2.X - e2.P1.X;
			int e2Y = e2.P2.Y - e2.P1.Y;
			double res = Math.Acos((e1X * e2X + e1Y * e2Y) / (Math.Sqrt(e1X * e1X + e1Y * e1Y) * Math.Sqrt(e2X * e2X + e2Y * e2Y))) * (180 / Math.PI);
			return res;
		}

		//Триангуляция
		List<edge> living_edges;
		private void butt_triangulator_Click(object sender, EventArgs e)
		{
			redrawImage();
			living_edges = new List<edge>();
			my_point fst_point = find_first_point(points);
			draw_point(fst_point);
			my_point sec_point = find_second_point(points, fst_point);
			draw_point(sec_point);
            pictureBox.Image = bmp;

            living_edges.Add(new edge(fst_point, sec_point));

            while (living_edges.Count() > 0)
            {
                edge living = living_edges[living_edges.Count() - 1];
                living_edges.RemoveAt(living_edges.Count() - 1);
                double radius = double.MaxValue;
                my_point third_point = null;
                foreach (my_point p in points)
                {
                    draw_point(p);
                    if (pos_rel_edge(living, p) != -1) // Определяет c какой стороны относительно направленного ребра лежит точка
                        continue;                        //1 - слева, -1 - справа, 0 - на ребре
                    triad tr = new triad(living.start(), living.end(), p);
                    if (radius > tr.dist)
                    {
                        radius = tr.dist;
                        third_point = p;
                    }
                }

                draw_edge(living);

                if (third_point != null)
                {
                    edge ed = new edge(living.start(), third_point);
                    int ind = living_edges.FindIndex(new Predicate<edge>(ee => ee == new edge(ed.end(), ed.start())));
                    if (ind >= 0)
                    {
                        draw_edge(living_edges[ind]);
                        living_edges.RemoveAt(ind);
                    }
                    else
                    {

                        living_edges.Add(ed);
                        //draw_edge(ed);
                    }

                    ed = new edge(third_point, living.end());
                    ind = living_edges.FindIndex(new Predicate<edge>(ee => ee == new edge(ed.end(), ed.start())));
                    if (ind >= 0)
                    {
                        draw_edge(living_edges[ind]);
                        living_edges.RemoveAt(ind);
                    }
                    else
                    {

                        living_edges.Add(ed);
                        //draw_edge(ed);
                    }
                }
            }
            
        }

		private my_point find_first_point(List<my_point> list)
		{
			my_point res = list[0];
			int x = pictureBox.Width, y = pictureBox.Height;
			foreach (my_point p in list)
				if (p.X < x)
				{
					x = p.X;
					res = p;
				}
				else if (p.X == x)
					if (p.Y > y)
					{
						y = p.Y;
						res = p;
					}
			return res;
		}

		private my_point find_second_point(List<my_point> list, my_point fst_point)
		{
			my_point res = fst_point;
			double min_deg = 180;
			foreach (my_point p in list)
			{
				double deg = degree_between_edges(new edge(fst_point, new my_point(fst_point.X, fst_point.Y - 1)), new edge(fst_point, p));
				if (deg < min_deg)
				{
					min_deg = deg;
					res = p;
				}
			}
			return res;
		}

		private void draw_point(my_point p)
		{
			g.FillEllipse(new SolidBrush(Color.Black), p.X - 4, p.Y - 4, 8, 8);
		}

		private void draw_edge(edge e)
		{
			g.DrawLine(new Pen(Color.Blue, 1), e.P1.X, e.P1.Y, e.P2.X, e.P2.Y);
		}

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }

    public class my_point
	{
		public int X, Y;
		public my_point(int x, int y) { X = x; Y = y; }
		public static bool operator ==(my_point p1, my_point p2)
		{
			if (System.Object.ReferenceEquals(p1, p2))
				return true;
			if (((object)p1 == null) || ((object)p2 == null))
				return false;
			return p1.X == p2.X && p1.Y == p2.Y;
		}
		public static bool operator !=(my_point p1, my_point p2)
		{
			return !(p1 == p2);
		}
	}

	public class edge
	{
		public my_point P1, P2;
		public edge(my_point p1, my_point p2) { P1 = p1; P2 = p2; }
		public bool contains(my_point p) { return p == P1 || p == P2; }
		public my_point start() { return P1; }
		public my_point end() { return P2; }
		public edge reverse() { return new edge(P2, P1); }
		public static bool operator ==(edge e1, edge e2)
		{
			if (System.Object.ReferenceEquals(e1, e2))
				return true;
			if (((object)e1 == null) || ((object)e2 == null))
				return false;
			return e1.P1 == e2.P1 && e1.P2 == e2.P2;
		}
		public static bool operator !=(edge e1, edge e2)
		{
			return !(e1 == e2);
		}
	}

	public class triad
	{
		public my_point a, b, c;

		// координаты центра и квадрат радиуса описанной окружности, расстояние до центра
		public double circleX, circleY, dist;

		public triad(my_point aa, my_point bb, my_point cc)
		{
			a = aa; b = bb; c = cc;
			find_coord_and_radius();
			find_dist_to_center();
		}

	
		// Нахождение квадрата радиуса и координаты центра описанной окружности
		public void find_coord_and_radius()
		{
			double x4 = (a.X + b.X) / 2;
			double y4 = (a.Y + b.Y) / 2;

			double x5 = (a.X + c.X) / 2;
			double y5 = (a.Y + c.Y) / 2;

			double a1 = b.X - a.X;
			double b1 = b.Y - a.Y;
			double c1 = x4 * (b.X - a.X) + y4 * (b.Y - a.Y);
			double a2 = c.X - a.X;
			double b2 = c.Y - a.Y;
			double c2 = x5 * (c.X - a.X) + y5 * (c.Y - a.Y);

			circleX = Math.Round((c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1));
			circleY = Math.Round((a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1));
		}

		
		// Нахождение расстояния до центра
		public void find_dist_to_center()
		{
			dist = ((a.Y - b.Y) * circleX + (b.X - a.X) * circleY + (a.X * b.Y + b.X * a.Y)) / (Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y)));
		}
	}
}
