using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Runtime.InteropServices;
using TestTriangle.StaticProperty;
using System.Windows.Media.Media3D;
using System.Threading;

namespace TestTriangle.Classes
{
    public class OBJItem
    {
        public List<Vertex> v;
        public List<Vector3D> vectorn;
        public List<Vertex> vn;
        public List<Face> f;
        public List<Texture> vt;

        public Dictionary<Vertex, Vertex> normal_Vectors;

        public new Dictionary<Face, List<Edge>> edges;
        public double maxz;
        //public OBJItem(List<Vertex> v, List<Vector3D> vn, List<Face> f, List<Texture> vt)
        //{
        //    this.v = v;
        //    this.vn = vn;
        //    this.f = f;
        //    this.vt = vt;
        //    this.maxz = float.MinValue;
        //}
        public OBJItem()
        {
            this.v = new List<Vertex>();
            this.vectorn = new List<Vector3D>();
            this.f = new List<Face>();
            this.vt = new List<Texture>();
            this.edges = new Dictionary<Face, List<Edge>>();
            this.normal_Vectors = new Dictionary<Vertex, Vertex>();
            this.vn = new List<Vertex>();
        }
        public void SetMaxZ()
        {
            this.maxz = double.MinValue;
            foreach (var v in this.v)
                this.maxz = Math.Max(v.z, maxz);
        }
        public void SortFaces()
        {
            this.f.Sort((a, b) => a.GetMinZ() < b.GetMinZ()? -1 : 1);
        }
        public void Paint(bool hide = false)
        {
            //DrawTool.writeableBitmap.Lock();
            foreach (var face in CollectionsMarshal.AsSpan(this.f))
            {
                if (!face.IsVisible())
                    continue;
                face.Paint(hide);
                if (OBJProperty.PrintTriangle)
                    foreach (var ed in this.edges[face])
                    {
                        ed.Paint(hide);
                    }
                if (OBJProperty.PrintFacesNormal)
                {
                    face.PrintFacesNormal(hide);
                }
                if (OBJProperty.PrintVertex)
                {
                    foreach (var v in face.set)
                        DrawTool.DrawPixel(new Point(522 + OBJProperty.zoom * 300 * v.vertex.x, 320 + OBJProperty.zoom * 300 * v.vertex.y), hide ? Color.FromRgb(60, 60, 60) : OBJProperty.VertColor);
                }
                if (OBJProperty.PrintVertsNormal)
                {
                    face.PaintVertsNormal(hide);
                }
            }
            //DrawTool.writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, DrawTool.writeableBitmap.PixelWidth, DrawTool.writeableBitmap.PixelHeight));
            //DrawTool.writeableBitmap.Unlock();
        }
        private void RenderEdges()
        {

            foreach (var f in this.f)
            {
                var edlist = new List<Edge>();
                edlist.Add(new Edge(f.set[0].vertex, f.set[1].vertex));
                edlist.Add(new Edge(f.set[1].vertex, f.set[2].vertex));
                edlist.Add(new Edge(f.set[0].vertex, f.set[2].vertex));
                this.edges.Add(f, edlist);
            }
        }
        public void Resize()
        {

            double maxval = double.MinValue;
            double minval = double.MaxValue;
            foreach (var v in this.v)
                (maxval, minval) = (Math.Max(maxval, v.y), Math.Min(minval, v.y));

            double fheight = maxval - minval;
            double midle = minval + fheight / 2;
            foreach (var v in this.v)
                v.y -= midle;

            foreach (var vn in this.vn)
                vn.y -= midle;

            this.SetVertsxyz();
            this.SetMaxZ();

            maxval = double.MinValue;

            foreach (var v in this.v)
                //maxval = Math.Max(Math.Abs(Math.Max(Math.Abs(v.x), Math.Abs(v.y))),maxval);
                maxval = Math.Abs(Math.Max(Math.Max(Math.Abs(v.x), Math.Max(Math.Abs(v.y), Math.Abs(v.z))), maxval));

            if (maxval > 1)
            {
                Parallel.ForEach(this.v, (v) =>
                 {
                     v.x /= maxval;
                     v.y /= maxval;
                     v.z /= maxval;
                 });
                Parallel.ForEach(this.vn, (vn) =>
                {
                    vn.x /= maxval;
                    vn.y /= maxval;
                    vn.z /= maxval;
                });

                this.SetVertsxyz();
                this.SetMaxZ();
            }
            else if (maxval < 1)
            {
                Parallel.ForEach(this.v, (v) =>
                {
                    v.x *= 1 / maxval;
                    v.y *= 1 / maxval;
                    v.z *= 1 / maxval;
                });
                Parallel.ForEach(this.vn, (vn) =>
                {
                    vn.x *= 1 / maxval;
                    vn.y *= 1 / maxval;
                    vn.z *= 1 / maxval;
                });
                this.SetVertsxyz();
                this.SetMaxZ();
            }
            this.RenderEdges();
        }
        public void SetVertsxyz()
        {
            Parallel.ForEach(this.v, v =>
            {
                v.setxyz();
            });
            Parallel.ForEach(this.vn, v =>
            {
                v.setxyz();
            });
        }
        public void AroundXaxis(double rad)
        {
            this.v.ForEach(v =>
            {
                v.y = v.defy * (float)Math.Cos(rad) - v.defz * (float)Math.Sin(rad);
                v.z = v.defy * (float)Math.Sin(rad) + v.defz * (float)Math.Cos(rad);
                this.maxz = Math.Max(this.maxz, v.z);
            });
            this.vn.ForEach(v =>
            {
                v.y = v.defy * (float)Math.Cos(rad) - v.defz * (float)Math.Sin(rad);
                v.z = v.defy * (float)Math.Sin(rad) + v.defz * (float)Math.Cos(rad);
            });
        }
        public void AroundYaxis(double rad)
        {
            this.v.ForEach(v =>
           {
               v.x = v.defx * (float)Math.Cos(rad) + v.defz * (float)Math.Sin(rad);
               v.z = v.defz * (float)Math.Cos(rad) - v.defx * (float)Math.Sin(rad);
               this.maxz = Math.Max(this.maxz, v.z);
           });

            this.vn.ForEach(v =>
            {
                v.x = v.defx * (float)Math.Cos(rad) + v.defz * (float)Math.Sin(rad);
                v.z = v.defz * (float)Math.Cos(rad) - v.defx * (float)Math.Sin(rad);
            });
        }
        public void AroundZaxis(double rad)
        {
            Parallel.ForEach(this.v, v =>
            {
                v.x = v.defx * (float)Math.Cos(rad) - v.defy * (float)Math.Sin(rad);
                v.y = v.defx * (float)Math.Sin(rad) + v.defy * (float)Math.Cos(rad);
            });
            Parallel.ForEach(this.vn, v =>
            {
                v.x = v.defx * (float)Math.Cos(rad) - v.defy * (float)Math.Sin(rad);
                v.y = v.defx * (float)Math.Sin(rad) + v.defy * (float)Math.Cos(rad);
            });
        }
    }
}
