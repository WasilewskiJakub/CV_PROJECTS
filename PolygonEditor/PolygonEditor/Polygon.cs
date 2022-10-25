using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PolygonEditor
{
    public class PolygonSet
    {
        public List<Polygon> Polygons;
        public PolygonSet()
        {
            Polygons = new List<Polygon>();
        }
        public Polygon GetCurrent()
        {
            if(Polygons.Count == 0 || Polygons[Polygons.Count-1].list.Count==0 || Polygons[Polygons.Count - 1].list[0].prev!=null)
            {
                Polygons.Add(new Polygon());
            }
            return Polygons[Polygons.Count - 1];
        }
    }
    public class Polygon
    {
        public class Vertex
        {
            public Vertex prev, next;
            public float X { get; set; }
            public float Y { get; set; }
            public Color color { get; set;}
            public int Radius { get; set; }
            public bool selected;
            public Vertex(float x, float y,Vertex prev, Vertex next = null, int Radius = 10)
            {
                this.X = x;
                this.Y = y;
                this.prev = prev;
                this.next = next;
                this.Radius = Radius;
                this.selected = false;
                this.color = Property.curr_color;
            }
            public Vertex(Vertex v)
            {
                this.next = this.prev = null;
                this.X = v.X;
                this.Y = v.Y;
                this.color = v.color;
                this.Radius = v.Radius;
                this.selected = v.selected;
            }
            public override bool Equals(Object obj)
            {
                Vertex v = (Vertex)obj;
                return Math.Sqrt((Math.Pow(this.X - v.X, 2) + Math.Pow(this.Y - v.Y, 2))) < this.Radius + v.Radius;
            }
            public void PaintVertex(ref Bitmap BtM, bool hide = false)
            {
                if (hide!= true && (this == Property.selected ||this.selected))
                    this.SelectVertex(ref BtM);
                else
                using (Graphics g = Graphics.FromImage(BtM))
                {
                    Brush brush = new SolidBrush(hide? Color.White : this.color);
                    g.FillEllipse(brush, (int)this.X - this.Radius, (int)this.Y - this.Radius, this.Radius * 2, this.Radius * 2);
                }
            }
            public void SelectVertex(ref Bitmap BtM)
            {
                using (Graphics g = Graphics.FromImage(BtM))
                {
                    Pen pen1 = new Pen(this.color, Property.LineWidth);
                    g.DrawEllipse(pen1, (int)X - Radius, (int)Y - Radius, Radius * 2, Radius * 2);
                }
            }
            static public Vertex getBetween(Vertex v1, Vertex v2)
            {
                if (v1.X == v2.X)
                {
                    return new Polygon.Vertex(v1.X, Math.Min(v1.Y, v2.Y) + Math.Abs(v1.Y - v2.Y)/2,null);
                }
                var f = Functions.by2points(v1, v2);
                var x = Math.Min(v1.X,v2.X) + (Math.Abs(v1.X - v2.X)/2);
                var y = Math.Min(v1.Y, v2.Y) + (Math.Abs(v1.Y - v2.Y) / 2);
                return new Polygon.Vertex(x, y, null);
            }
            
        }
        public List<Vertex> list;
        public Dictionary<(float, float), Vertex> HashSet;
        public Dictionary<(Vertex,Vertex),Edge> edges;
        public Polygon()
        {
            HashSet = new Dictionary<(float, float), Vertex>();
            this.list = new List<Vertex>();
            edges = new Dictionary<(Vertex, Vertex), Edge>();
        }
        public bool AddVertex(Vertex v)
        {
            bool flag = false;
            if (list.Count != 0)
            {
                list[list.Count - 1].next = v;
                v.prev = list[list.Count - 1];
                edges.Add((list[list.Count - 1],v),new Edge(list[list.Count - 1], v));
                flag = true;
            }
            list.Add(v);
            HashSet.Add((v.X, v.Y), v);
            return flag;
        }
        public void Select(bool t = true)
        {
            foreach (var v in this.list)
                v.selected = t;
            foreach (var e in this.edges.Values)
                e.selected = t;
        }
        public void PaintPolygon(ref Bitmap BtM,bool hide = false)
        {
            if (hide == true)
                using (Graphics g = Graphics.FromImage(BtM))
                {
                    g.Clear(Color.White);
                    return;
                }
            for (int i = 0; i < this.list.Count; i++)
            {
                EdgeMaker.DrawSegment(ref BtM, this.edges[(list[i% this.list.Count],list[(i + 1) % this.list.Count])], hide);
            }
        }
        public bool IsClockwise()
        {
            double sum = 0;
            for(int i = 0; i <this.list.Count;i++)
            {
                sum += (list[i].X - list[i].next.X)*(list[i].Y + list[i].next.Y);
            }
            return sum > 0;
        }
        public void MakeClockwise()
        {
            var keys = this.edges.Keys;
            Dictionary<(Vertex, Vertex), Edge> tmp = new Dictionary<(Vertex, Vertex), Edge>();
            foreach (var key in keys)
            {
                var edge = edges[key];
                (edge.v1, edge.v2) = (edge.v2, edge.v1);
                tmp.Add((key.Item2, key.Item1), edge);
            }
            this.edges.Clear();
            this.edges = tmp;
            List<Polygon.Vertex> verts = new List<Vertex>();
            verts.Add(this.list[0]);
            for (int i = this.list.Count - 1; i > 0; i--)
                verts.Add(list[i]);

            this.list = verts;
            
            int size = this.list.Count;
            for(int i = 0; i < this.list.Count;i++)
            {
                (list[i % size].next, list[(i + 1) % size].prev) = (list[(i + 1) % size], list[i % size]);
            }
        }
    }
    public class Edge
    {
        public enum relation
        {
            none, SetLength, perpedincular
        }
        public Polygon.Vertex v1;
        public Polygon.Vertex v2;
        public Perpendicular perpe;
        public int length;
        public int width;
        public relation rel;
        public Color color;
        public bool selected;
        public int number_length;
        public Edge(Polygon.Vertex v1, Polygon.Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.length = 0;
            this.rel = relation.none;
            this.color = Color.Black;
            this.width = Property.LineWidth;
            this.selected = false;
            this.perpe = null;
            this.number_length = 0;
        }
        public Edge(Edge e)
        {
            this.color = e.color;
            this.length = e.length;
            this.rel = e.rel;
            this.width = e.width;
            this.v1 = new Polygon.Vertex(e.v1);
            this.v2 = new Polygon.Vertex(e.v2);
            this.length = e.length;
            this.selected = e.selected;
        }
        public bool IsSelected((int X,int Y)m)
        {
            int ODL = (int)Math.Sqrt((Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2)));
            int v1m = (int)Math.Sqrt((Math.Pow(v1.X - m.X, 2) + Math.Pow(v1.Y - m.Y, 2)));
            int mv2 = (int)Math.Sqrt((Math.Pow(v2.X - m.X, 2) + Math.Pow(v2.Y - m.Y, 2)));
            return Math.Abs(v1m + mv2 - ODL) < Property.Tolerance;
        }
        public void CalcLength()
        {
            this.length = (int)Math.Sqrt((Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2)));
        }
    }
    static class EdgeMaker
    {
        static public void DrawSegment(ref Bitmap BtM, Edge e, bool hide = false)
        {
            using (Graphics g = Graphics.FromImage(BtM))
            {
                Pen pen = new Pen(hide?Color.White : e.color,e.width);
                if (Property.Style == EdgeStyle.SystemLine && e == Property.selected_edge || e.selected)
                    pen.DashPattern = new float[] { 5, 5 };
                if (Property.Style == EdgeStyle.SystemLine)
                    g.DrawLine(pen, new Point((int)e.v1.X, (int)e.v1.Y), new Point((int)e.v2.X, (int)e.v2.Y));
                else
                    BresenhamLine(ref BtM, e.v1, e.v2,pen, e == Property.selected_edge || e.selected);
                // Set Length
                if (e.number_length != 0)
                {
                    (float, float) W = (e.v1.X + (e.v2.X - e.v1.X) / 2, e.v1.Y + (e.v2.Y - e.v1.Y) / 2);
                    Image ruller = Properties.Resources.Ruller1;
                    Rectangle src = new Rectangle(0, 0, ruller.Width, ruller.Height);
                    g.FillRectangle(Brushes.DarkRed, new Rectangle((int)W.Item1 - 10, (int)W.Item2-10, 20, 20));
                    g.DrawRectangle(new Pen(Brushes.Black), new Rectangle((int)W.Item1 - 10, (int)W.Item2 - 10, 20, 20));
                    PointF ff = new PointF(W.Item1 - 7, W.Item2 - 7);
                    FontFamily fontFamily = new FontFamily("Arial");
                    Font font = new Font(
                       fontFamily,
                       14,
                       FontStyle.Bold,
                       GraphicsUnit.Pixel);
                    g.DrawString(e.number_length.ToString(), font, Brushes.White, ff);
                }
                if (e.perpe != null)
                {
                    (float, float) W = (e.v1.X + (e.v2.X - e.v1.X) / 2, e.v1.Y + (e.v2.Y - e.v1.Y) / 2);
                    Image ruller = Properties.Resources.Ruller1;
                    Rectangle src = new Rectangle(0, 0, ruller.Width, ruller.Height);
                    g.FillRectangle(Brushes.DarkBlue, new Rectangle((int)W.Item1 - 10, (int)W.Item2 - 10, 20, 20));
                    g.DrawRectangle(new Pen(Brushes.Black), new Rectangle((int)W.Item1 - 10, (int)W.Item2 - 10, 20, 20));
                    PointF ff = new PointF(W.Item1 - 7, W.Item2 - 7);
                    FontFamily fontFamily = new FontFamily("Arial");
                    Font font = new Font(
                       fontFamily,
                       14,
                       FontStyle.Bold,
                       GraphicsUnit.Pixel);
                    g.DrawString(Property.perps_list.IndexOf(e.perpe).ToString(), font, Brushes.White, ff);
                }
            }
            e.v1.PaintVertex(ref BtM,hide);
            e.v2.PaintVertex(ref BtM,hide);
        }
        static private void BresenhamLine(ref Bitmap BtM, Polygon.Vertex v1, Polygon.Vertex v2,Pen pen,bool selected)
        {
            //https://pl.wikipedia.org/wiki/Algorytm_Bresenhama

            int d, dx, dy, ai, bi, xi, yi;
            int x = (int)v1.X, y = (int)v1.Y;
            int i = 0;
            int width = 2;
            int separator = 10;
            Brush brush = new SolidBrush(pen.Color);
            bool paint = true;
            if (v1.X < v2.X)
            {
                xi = 1;
                dx = (int)v2.X - (int)v1.X;
            }
            else
            {
                xi = -1;
                dx = (int)v1.X - (int)v2.X;
            }
            if (v1.Y < v2.Y)
            {
                yi = 1;
                dy = (int)v2.Y - (int)v1.Y;
            }
            else
            {
                yi = -1;
                dy = (int)v1.Y - (int)v2.Y;
            }
            using (Graphics g = Graphics.FromImage(BtM))
            {
                if(selected == false)
                {
                    g.FillRectangle(brush, (int)x, (int)y, width, width);
                }
                else
                {
                    if (paint)
                        g.FillRectangle(brush, (int)x, (int)y, width, width);
                    i++;
                    if (i % separator == 0)
                        paint = !paint;
                }
            }
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                while (x != (int)v2.X)
                {
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    using (Graphics g = Graphics.FromImage(BtM))
                    {
                        if (selected == false)
                        {
                            g.FillRectangle(brush, (int)x, (int)y, width, width);
                        }
                        else
                        {
                            if (paint)
                                g.FillRectangle(brush, (int)x, (int)y, width, width);
                            i++;
                            if (i % separator == 0)
                                paint = !paint;
                        }
                    }
                }
            }
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                while (y != (int)v2.Y)
                {
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    using (Graphics g = Graphics.FromImage(BtM))
                    {
                        if (selected == false)
                        {
                            g.FillRectangle(brush, (int)x, (int)y, width, width);
                        }
                        else
                        {
                            if (paint)
                                g.FillRectangle(brush, (int)x, (int)y, width, width);
                            i++;
                            if (i % separator == 0)
                                paint = !paint;
                        }
                    }
                }
            }
        }
    }
}
