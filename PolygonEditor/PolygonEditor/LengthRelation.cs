using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PolygonEditor
{
    class LengthRelation
    {
        Polygon.Vertex prim1;

        Polygon.Vertex old_one_top;
        Polygon.Vertex new_one_top;

        Polygon.Vertex old_one_down;
        Polygon.Vertex new_one_down;
        Edge top;
        Edge down;
        public LengthRelation(Polygon.Vertex new_one, Polygon.Vertex old_one)
        {
            this.new_one_top = this.new_one_down = new_one;
            this.old_one_top = this.old_one_down = old_one;
            this.top = Property.workingpolyg.edges[(new_one.prev, new_one)];
            this.down = Property.workingpolyg.edges[(new_one, new_one.next)];
            this.prim1 = new_one;
        }
        public LengthRelation(Polygon.Vertex new_one, Polygon.Vertex old_one,int x)
        {
            this.new_one_top = this.new_one_down = new_one;
            this.old_one_top = this.old_one_down = new_one;
            this.top = Property.workingpolyg.edges[(new_one.prev, new_one)];
            this.down = Property.workingpolyg.edges[(new_one, new_one.next)];
            this.prim1 = new_one;
        }
        public LengthRelation(Edge curr, Edge old)
        {
            this.new_one_top = curr.v1;
            this.new_one_down = curr.v2;

            this.old_one_top = old.v1;
            this.old_one_down = old.v2;

            this.top = Property.workingpolyg.edges[(new_one_top.prev, new_one_top)];
            this.down = Property.workingpolyg.edges[(new_one_down, new_one_down.next)];
        }
        public void MoveEdges()
        {
            if (top.perpe == null && down.perpe == null && top.length == 0 && down.length == 0)
                return;
            for (int i = 0; i < Property.workingpolyg.list.Count; i++)
            {
                if (top.length != 0)
                {
                    GetNewPositionTop(this.top);
                }
                if (down.length != 0)
                {
                    GetNewPositiondown(this.down);
                }
                if (top.perpe != null)
                {
                    MakePerpeTop(this.top);
                    this.top = Property.workingpolyg.edges[(this.new_one_top.prev, this.new_one_top)];
                }
                if(down.perpe != null)
                {
                    MakePerpeDown(this.down);
                    this.down = Property.workingpolyg.edges[(this.new_one_down, this.new_one_down.next)];
                }
            }
        }
        private float GetLength(Polygon.Vertex v1, Polygon.Vertex v2)
        {
            return (float)Math.Sqrt(((float)Math.Pow(v1.X - v2.X, 2) + (float)Math.Pow(v1.Y - v2.Y, 2)));
        }
        public bool Linear(Polygon.Vertex v0, Polygon.Vertex v1, Polygon.Vertex v2)
        {
            float ans = (v1.X - v0.X) * (v2.Y - v0.Y) - (v2.X - v0.X) * (v1.Y - v0.Y);
            return ans == 0;
        }

        public void MakePerpeDown(Edge e)
        {
            var perpe = e.perpe;
            if(e.perpe.e1 == e)//perpe is e1!!!
            {
                if(perpe.Y.e1 != null)
                {
                    perpe.Y.e1 = e.v1.Y;
                    this.old_one_down = new Polygon.Vertex(e.v2);
                    e.v2.Y = e.v1.Y;
                    this.new_one_down = e.v2;
                }
                if (perpe.X.e1 != null)
                {
                    perpe.X.e1 = e.v1.X;
                    this.old_one_down = new Polygon.Vertex(e.v2); // <v2>/<v1> ------- <v2>/<v1> --------- <v2>/<v1>
                    e.v2.X = e.v1.X;
                    this.new_one_down = e.v2;
                    return;
                }
                if(perpe.fe1 != null)
                {
                    float a = this.old_one_down.X, b = this.old_one_down.Y;
                    float c = e.v2.X, d = e.v2.Y;
                    //float A = (d - b) / (c - a);
                    float A = perpe.Ae1;
                    float B = this.new_one_down.Y - A * this.new_one_down.X;
                    perpe.fe1 = (x) => { return A * x + B; };
                    this.old_one_down = new Polygon.Vertex(e.v2);
                    e.v2.Y = perpe.fe1(e.v2.X);
                    this.new_one_down = e.v2;
                }
            }
            else
            {
                if (perpe.Y.e2 != null)
                {
                    perpe.Y.e2 = e.v1.Y;
                    this.old_one_down = new Polygon.Vertex(e.v2);
                    e.v2.Y = e.v1.Y;
                    this.new_one_down = e.v2;
                }
                if (perpe.X.e2 != null)
                {
                    perpe.X.e2 = e.v1.X;
                    this.old_one_down = new Polygon.Vertex(e.v2); // <v2>/<v1> ------- <v2>/<v1> --------- <v2>/<v1>
                    e.v2.X = e.v1.X;
                    this.new_one_down = e.v2;
                    return;
                }
                if(perpe.fe2!=null)
                {
                    //float a = e.v1.X, b = e.v1.Y;
                    //float c = this.old_one_down.X, d = this.old_one_down.Y;
                    //float A = (d - b) / (c - a);
                    //float B = this.new_one_down.Y - A * this.new_one_down.X;
                    //perpe.fe2 = (x) => { return A * x + B; };
                    //this.old_one_down = new Polygon.Vertex(e.v2);
                    //e.v2.Y = perpe.fe2(e.v2.X);
                    //this.new_one_down = e.v2;
                    float a = this.old_one_down.X, b = this.old_one_down.Y;
                    float c = e.v2.X, d = e.v2.Y;
                    //float A = (d - b) / (c - a);
                    float A = perpe.Ae2;
                    float B = this.new_one_down.Y - A * this.new_one_down.X;
                    perpe.fe2 = (x) => { return A * x + B; };
                    this.old_one_down = new Polygon.Vertex(e.v2);
                    e.v2.Y = perpe.fe2(e.v2.X);
                    this.new_one_down = e.v2;
                }
            }
        }

        public void MakePerpeTop(Edge e)
        {
            var perpe = e.perpe;
            if(e == e.perpe.e1)
            {
                if(perpe.Y.e1 != null)
                {
                    perpe.Y.e1 = e.v2.Y;
                    this.old_one_top = new Polygon.Vertex(e.v1);
                    e.v1.Y = e.v2.Y;
                    this.new_one_top = e.v1;
                    return;
                }
                if(perpe.X.e1 != null)
                {
                    perpe.X.e1 = e.v2.X;
                    this.old_one_top = new Polygon.Vertex(e.v1); // <v2>/<v1> ------- <v2>/<v1> --------- <v2>/<v1>
                    e.v1.X = e.v2.X;
                    this.new_one_top = e.v1;
                    return;
                }
                if(perpe.fe1!= null)
                {
                    float a = this.old_one_top.X, b = this.old_one_top.Y;
                    float c = e.v1.X, d = e.v1.Y;
                    //float A = (d - b) / (c - a);
                    float A = perpe.Ae1;
                    float B = this.new_one_top.Y - A * this.new_one_top.X;
                    perpe.fe1 = (x) => { return A * x + B; };
                    this.old_one_top = new Polygon.Vertex(e.v1);
                    e.v1.Y = perpe.fe1(e.v1.X);
                    this.new_one_top = e.v1;
                }
            }
            else
            {
                if (perpe.Y.e2 != null)
                {
                    perpe.Y.e2 = e.v2.Y;
                    this.old_one_top = new Polygon.Vertex(e.v1);
                    e.v1.Y = e.v2.Y;
                    this.new_one_top = e.v1;
                    return;
                }
                if (perpe.X.e2 != null)
                {
                    perpe.X.e2 = e.v2.X;
                    this.old_one_top = new Polygon.Vertex(e.v1); // <v2>/<v1> ------- <v2>/<v1> --------- <v2>/<v1>
                    e.v1.X = e.v2.X;
                    this.new_one_top = e.v1;
                    return;
                }
                if (perpe.fe2 != null)
                {
                    float a = this.old_one_top.X, b = this.old_one_top.Y;
                    float c = e.v1.X, d = e.v1.Y;
                    //float A = (d - b) / (c - a);
                    float A = perpe.Ae2;
                    float B = this.new_one_top.Y - A * this.new_one_top.X;
                    perpe.fe2 = (x) => { return A * x + B; };
                    this.old_one_top = new Polygon.Vertex(e.v1);
                    e.v1.Y = perpe.fe2(e.v1.X);
                    this.new_one_top = e.v1;
                }
            }
        }
        public void GetNewPositionTop(Edge e)
        {
            float d = GetLength(e.v1, this.old_one_top);
            float l = GetLength(e.v1, this.new_one_top);
            (float, float) V = (this.new_one_top.X-e.v1.X, this.new_one_top.Y - e.v1.Y);
            float tmp = (l - d) / l;
            V.Item1 = V.Item1 * tmp;
            V.Item2 = V.Item2 * tmp;
            this.old_one_top = new Polygon.Vertex(e.v1);
            e.v1.X += V.Item1;
            e.v1.Y += V.Item2;
            e.CalcLength();
            this.new_one_top = e.v1;
            e.CalcLength();
            this.top = Property.workingpolyg.edges[(this.new_one_top.prev, this.new_one_top)];
        }
        public void GetNewPositiondown(Edge e)
        {
            float d = GetLength(e.v2, this.old_one_down);
            float l = GetLength(e.v2, this.new_one_down);
            (float, float) V = (this.new_one_down.X - e.v2.X, this.new_one_down.Y - e.v2.Y);
            float tmp = (l - d) / l;
            V.Item1 = V.Item1 * tmp;
            V.Item2 = V.Item2 * tmp;
            this.old_one_down = new Polygon.Vertex(e.v2);
            e.v2.X += V.Item1;
            e.v2.Y += V.Item2;
            e.CalcLength();
            this.new_one_down = e.v2;
            e.CalcLength();
            this.down = Property.workingpolyg.edges[(this.new_one_down, this.new_one_down.next)];
        }
        private (Polygon.Vertex,Polygon.Vertex) ByCircle(Polygon.Vertex new1, Polygon.Vertex prim, Polygon.Vertex old, double dl)
        {
            float a = new1.X, b = new1.Y;
            float c = prim.X, d = prim.Y;
            float e = old.X, f = old.Y;
            float g = (d - f) / (c - e);
            float ax2 = (float)(1 + Math.Pow(g, 2));
            float bx = 2 * (f*g - g*b -  a - (float)Math.Pow(g,2)*e);
            float cc = (float)Math.Pow(a, 2) + (float)Math.Pow(g * e, 2) - (2 * f * g * e) + (float)Math.Pow(f, 2) + (2* g * e * b) - (2 * f * b) + (float)Math.Pow(b, 2) - (float)Math.Pow(dl, 2);
            float delta = (float)Math.Pow(bx, 2) - (4 * ax2 * cc);
            float x1 = (-1 * bx - (float)Math.Sqrt(delta)) / (2 * ax2);
            float x2 = (-1 * bx + (float)Math.Sqrt(delta)) / (2 * ax2);
            Func<float, float> func = (arg) => { return g * (arg - e) + f; };
            float y1 = func(x1);
            float y2 = func(x2);
            return (new Polygon.Vertex(x1, y1, null), new Polygon.Vertex(x2, y2, null));
        }
    }
}
