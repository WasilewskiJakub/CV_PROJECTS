using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;
using TestTriangle.StaticProperty;
using System.Runtime.InteropServices;
using System.Windows.Media;
using TestTriangle.OBJReader;
using Light = TestTriangle.StaticProperty.Light;

namespace TestTriangle.Classes
{
    public class Face
    {
        public class FaceVertex
        {
            public Vertex vertex;
            public Vertex normal;
            public Texture texture;
            public FaceVertex(Vertex v, Texture t, Vertex n)
            {
                this.texture = t;
                this.vertex = v;
                this.normal = n;
            }
        }
        public List<FaceVertex> set;
        public double GetMinZ()
        {
            var minz = double.MaxValue;
            Parallel.ForEach(this.set, (x) => minz = Math.Min(minz, x.vertex.z));
            return minz;
        }
        public bool IsClockwise()
        {
            double sum = 0;
            int n = this.set.Count;
            for (int i = 0; i < n; i++)
                sum += (this.set[(i + 1) % n].vertex.x - this.set[i % n].vertex.x) * (this.set[(i + 1) % n].vertex.y + this.set[i % n].vertex.y);
            return sum >= 0;
        }
        public bool IsVisible()
        {
            if (this.IsClockwise())
                return true;
            else
                return false;
        }
        public void PrintFacesNormal(bool hide)
        {
            Vector3D v01 = new Vector3D(this.set[1].vertex.x - this.set[0].vertex.x, this.set[1].vertex.y - this.set[0].vertex.y, this.set[1].vertex.z - this.set[0].vertex.z);
            Vector3D v02 = new Vector3D(this.set[2].vertex.x - this.set[0].vertex.x, this.set[2].vertex.y - this.set[0].vertex.y, this.set[2].vertex.z - this.set[0].vertex.z);
            Vector3D facen = Vector3D.CrossProduct(v02, v01);
            Vertex from = new Vertex((this.set[0].vertex.x + this.set[1].vertex.x + this.set[2].vertex.x) / 3, (this.set[0].vertex.y + this.set[1].vertex.y + this.set[2].vertex.y) / 3, (this.set[0].vertex.z + this.set[1].vertex.z + this.set[2].vertex.z) / 3);
            double length = (double)facen.Length;
            if (length != OBJProperty.FaceNormalLength)
            {
                facen.X *= OBJProperty.FaceNormalLength / length;
                facen.Y *= OBJProperty.FaceNormalLength / length;
                facen.Z *= OBJProperty.FaceNormalLength / length;
            }
            Vertex to = new Vertex(from.x + (double)facen.X, from.y + (double)facen.Y, from.z + (double)facen.Z);
            DrawTool.Bresenham(new Point(522 + OBJProperty.zoom * 300 * from.x, 320 + OBJProperty.zoom * 300 * from.y), new Point(522 + OBJProperty.zoom * 300 * to.x, 320 + OBJProperty.zoom * 300 * to.y), hide ? Color.FromRgb(60, 60, 60) : OBJProperty.FaceNormalColor);
        }
        static public Color Lambert(Vertex x, Vertex n)
        {
            Vector3D N = new Vector3D(n.x - x.x, n.y - x.y, n.z - x.z);
            N.Normalize();
            if (NormalMapReader.setmap)
                N = NormalMapReader.GetMapNormal((int)Math.Round(522 + OBJProperty.zoom * 300 * x.x, 0), (int)(Math.Round(320 + OBJProperty.zoom * 300 * x.y, 0)), N);
            Vector3D L = new Vector3D(Light.possition.x - x.x, Light.possition.y - x.y, Light.possition.z - x.z);
            L.Normalize();
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * (Vector3D.DotProduct(N, L)) * N - L;
            double cos1 = (double)(Vector3D.DotProduct(N,L));
            double cos2 = (double)(Vector3D.DotProduct(V,R));
            cos1 = cos1 < 0 ? 0 : cos1;
            cos2 = cos2 < 0 ? 0 : cos2;
            cos2 = (double)Math.Pow(cos2, Light.m);

            Color obj = OBJProperty.ObjectColor;
            if (NormalMapReader.settext)
                obj = NormalMapReader.GetTextureColor((int)Math.Round(522 + OBJProperty.zoom * 300 * x.x, 0), (int)(Math.Round(320 + OBJProperty.zoom * 300 * x.y, 0)));

            //Red:
            double red = Light.kd * ((double)Light.color.R / 255) * ((double)obj.R / 255) * cos1 + Light.ks * ((double)Light.color.R / 255) * ((double)obj.R / 255) * cos2;
            red = red > 1 ? 1 : red;
            //Green:
            double green = Light.kd * ((double)Light.color.G / 255) * ((double)obj.G / 255) * cos1 + Light.ks * ((double)Light.color.G / 255) * ((double)obj.G / 255) * cos2;
            green = green > 1 ? 1 : green;
            //Blue:
            double blue = Light.kd * ((double)Light.color.B / 255) * ((double)obj.B / 255) * cos1 + Light.ks * ((double)Light.color.B / 255) * ((double)obj.B / 255) * cos2;
            blue = blue > 1 ? 1 : blue;
            return Color.FromRgb((byte)(red *255), (byte)(green * 255), (byte)(blue*255));
        }
        public void PaintVertsNormal(bool hide)
        {
            foreach (var v in CollectionsMarshal.AsSpan(this.set))
            {
                Vector3D tmp = new Vector3D(v.normal.x - v.vertex.x, v.normal.y - v.vertex.y, v.normal.z - v.vertex.z);
                var length = tmp.Length;
                if (length == 0)
                    continue;
                if(length != OBJProperty.VertsNormalLength)
                {
                    tmp.X *= OBJProperty.VertsNormalLength / length;
                    tmp.Y *= OBJProperty.VertsNormalLength / length;
                    tmp.Z *= OBJProperty.VertsNormalLength / length;
                }
                DrawTool.Bresenham(new Point(522 + OBJProperty.zoom * 300 * v.vertex.x, 320 + OBJProperty.zoom * 300 * v.vertex.y), new Point(522 + OBJProperty.zoom * 300 * (v.vertex.x+tmp.X), 320 + OBJProperty.zoom * 300 * (v.vertex.y + tmp.Y)), hide ? Color.FromRgb(60, 60, 60) : OBJProperty.VertNormalColor);
            }
        }
        public Face()
        {
            set = new List<FaceVertex>();
        }
        public void Paint(bool hide)
        {
            EdgeTable tmp = new EdgeTable();
            tmp.AddEdge(this);
            tmp.Paint(hide);
        }
    }
}
