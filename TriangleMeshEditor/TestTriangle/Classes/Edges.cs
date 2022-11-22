using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;
using System.Threading;
using System.Diagnostics;
using TestTriangle.Classes;
using TestTriangle.StaticProperty;
using System.Windows.Media.Media3D;
using TestTriangle.OBJReader;

namespace TestTriangle.Classes
{
    public class Edge
    {
        public Vertex v1;
        public Vertex v2;
        public Edge(Vertex v1, Vertex v2)
        {
            this.v2 = v2;
            this.v1 = v1;
        }
        public void Paint(bool hide)
        {
            DrawTool.Bresenham(new Point(522 + OBJProperty.zoom * 300 * this.v1.x, 320 + OBJProperty.zoom * 300 * this.v1.y), new Point(522 + OBJProperty.zoom * 300 * this.v2.x, 320 + OBJProperty.zoom * 300 * this.v2.y), hide ? Color.FromRgb(60, 60, 60) : OBJProperty.EdgeColor);
        }
    }
    class EdgeStructure
    {
        public class Node
        {
            public Vertex v1;
            public Vertex v2;
            public double ymax;
            public double xmin;
            public double invm;
            public Node(Vertex v1, Vertex v2, double ymax, double xmin, double invm)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.invm = invm;
                this.ymax = ymax;
                this.xmin = xmin;
            }
        }
        public List<Node> list;
        public EdgeStructure()
        {
            this.list = new List<Node>();
        }
        public void AddEdge(Vertex v1, Vertex v2)
        {
            float v1x = (int)Math.Round((522 + OBJProperty.zoom * 300 * v1.x), 0), v1y = (int)Math.Round((320 + OBJProperty.zoom * 300 * v1.y), 0);
            float v2x = (int)Math.Round((522 + OBJProperty.zoom * 300 * v2.x), 0), v2y = (int)Math.Round((320 + OBJProperty.zoom * 300 * v2.y), 0);

            var tmp = new Node(v1, v2, Math.Max(v1y, v2y), v1y > v2y ? v2x : v1x, (v1x - v2x) / (v1y - v2y));
            this.list.Add(tmp);
        }
    }
    class EdgeTable
    {
        public Dictionary<double, EdgeStructure> ET;
        //public Dictionary<Vertex, Color> vertcolor;
        public List<(Vertex, Color)> vertlist;
        public bool same_color;
        public EdgeStructure AET;
        public List<(Vertex, Vertex)> normvert;

        // Equatation:
        double denominator;
        double Wv1bra1;
        double Wv1bra3;

        double Wv2bra1;
        double Wv2bra3;

        public EdgeTable()
        {
            this.ET = new Dictionary<double, EdgeStructure>();
            //this.vertcolor = new Dictionary<Vertex, Color>();
            this.vertlist = new List<(Vertex, Color)>();
            this.normvert = new List<(Vertex, Vertex)>();

        }
        private void AddVertex(Vertex v1, Vertex v2)
        {
            float v1x = (int)Math.Round((522 + OBJProperty.zoom * 300 * v1.x),0), v1y = (int)Math.Round((320 + OBJProperty.zoom * 300 * v1.y),0);
            float v2x = (int)Math.Round((522 + OBJProperty.zoom * 300 * v2.x),0), v2y = (int)Math.Round((320 + OBJProperty.zoom * 300 * v2.y),0);
            if (v1y == v2y)
                return;
            double ymin = (int)Math.Min(v1y, v2y);
            if (!this.ET.ContainsKey(ymin))
                this.ET.Add(ymin, new EdgeStructure());
            this.ET[ymin].AddEdge(v1, v2);
        }
        public void AddEdge(Face f)
        {
            this.AddVertex(f.set[0].vertex, f.set[1].vertex);
            this.AddVertex(f.set[1].vertex, f.set[2].vertex);
            this.AddVertex(f.set[0].vertex, f.set[2].vertex);
            for (int i = 0; i < f.set.Count; i++)
            {
                this.vertlist.Add((new Vertex((522 + OBJProperty.zoom * 300 * f.set[i].vertex.x), (320 + OBJProperty.zoom * 300 * f.set[i].vertex.y), 0), Face.Lambert(f.set[i].vertex, f.set[i].normal)));
                this.normvert.Add((new Vertex(f.set[i].vertex), new Vertex(f.set[i].normal)));
            }
            same_color = true;
            for(int i = 0; i <this.vertlist.Count-1;i++)
            {
                if(vertlist[i].Item2 != vertlist[i+1].Item2)
                { 
                    same_color = false;
                    break;
                }
            }
            this.denominator = ((vertlist[1].Item1.y - vertlist[2].Item1.y) * (vertlist[0].Item1.x - vertlist[2].Item1.x)) + ((vertlist[2].Item1.x - vertlist[1].Item1.x) * (vertlist[0].Item1.y - vertlist[2].Item1.y));

            this.Wv1bra1 = vertlist[1].Item1.y - vertlist[2].Item1.y;
            this.Wv1bra3 = vertlist[2].Item1.x - vertlist[1].Item1.x;

            this.Wv2bra1 = vertlist[2].Item1.y - vertlist[0].Item1.y;
            this.Wv2bra3 = vertlist[0].Item1.x - vertlist[2].Item1.x;
        }
        public void Paint(bool hide)
        {
            this.AET = new EdgeStructure();
            var tmp = new List<double>(this.ET.Keys);
            if (tmp.Count == 0)
                return;
            int y = (int)tmp.Min();
            while (!(this.ET.Count == 0 && this.AET.list.Count == 0))
            {
                if (this.ET.ContainsKey(y))
                {
                    this.AET.list.AddRange(this.ET[y].list);
                    this.ET.Remove(y);
                }
                this.AET.list.Sort((a, b) => a.xmin < b.xmin ? -1 : 1);

                for (int i = 0; i < this.AET.list.Count - 1; i += 2)
                {
                    FillScanLine(y, this.AET.list[i].xmin, this.AET.list[i + 1].xmin, hide);
                }
                y += 1;
                this.AET.list.RemoveAll((x) => x.ymax <= y);
                for (int i = 0; i < this.AET.list.Count; i++)
                    this.AET.list[i].xmin += this.AET.list[i].invm;

            }
        }
        public Color CalculateColor(Point P)
        {
            double Wv1 = (Wv1bra1 * (Math.Round(P.X,0) - vertlist[2].Item1.x) + Wv1bra3 * (Math.Round(P.Y, 0) - vertlist[2].Item1.y)) / denominator;
            double Wv2 = (Wv2bra1 * (Math.Round(P.X, 0) - vertlist[2].Item1.x) + Wv2bra3 * (Math.Round(P.Y, 0) - vertlist[2].Item1.y)) / denominator;

            if (Wv1 < 0)
                Wv1 = 0;
            if (Wv2 < 0)
                Wv2 = 0;
            if (Wv1 > 1)
            {
                Wv1 = 1;
                Wv2 = 0;
            }
            if (Wv2 > 1)
            {
                Wv2 = 1;
                Wv1 = 0;
            }
            double Wv3 = 1 - Wv1 - Wv2;
            if (DrawTool.color_style == ColorStyle.VertexInterpolation)
            {
                byte R = (byte)((vertlist[0].Item2.R * Wv1 + vertlist[1].Item2.R * Wv2 + vertlist[2].Item2.R * Wv3));
                byte G = (byte)((vertlist[0].Item2.G * Wv1 + vertlist[1].Item2.G * Wv2 + vertlist[2].Item2.G * Wv3));
                byte B = (byte)((vertlist[0].Item2.B * Wv1 + vertlist[1].Item2.B * Wv2 + vertlist[2].Item2.B * Wv3));
                return Color.FromRgb(R, G, B);
            }
            else
            {
                double z = normvert[0].Item1.z * Wv1 + normvert[1].Item1.z * Wv2 + normvert[2].Item1.z * Wv3; // calculated z!
                Vertex P1 = new Vertex((P.X - 522) / (300 * OBJProperty.zoom), (P.Y - 320) / (300 * OBJProperty.zoom), z);
                Vertex N1 = new Vertex(normvert[0].Item2.x * Wv1 + normvert[1].Item2.x * Wv2 + normvert[2].Item2.x * Wv3,
                    normvert[0].Item2.y * Wv1 + normvert[1].Item2.y * Wv2 + normvert[2].Item2.y * Wv3,
                    normvert[0].Item2.z * Wv1 + normvert[1].Item2.z * Wv2 + normvert[2].Item2.z * Wv3);
                return Face.Lambert(P1, N1);
            }

        }
        private void FillScanLine(int y, double x1, double x2, bool hide)
        {
            for (double i = x1; i < x2; i++)
            {
                DrawTool.DrawPixel(new Point(i, y), same_color&& NormalMapReader.setmap==false? vertlist[0].Item2 : CalculateColor(new Point(i, y)));
            }
            DrawTool.DrawPixel(new Point(x2, y), same_color && NormalMapReader.setmap == false ? vertlist[0].Item2 : CalculateColor(new Point(x2, y)));
        }
    }
    static class BitmapHelper
    {
        static public Color[] pixelcolor;
    }
}
