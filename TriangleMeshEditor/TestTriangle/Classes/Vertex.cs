using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTriangle.Classes
{
    public class Vertex
    {
        public double x { get; set;}
        public double y {get;set;}
        public double z { get; set;}

        public double defx { get; set; }
        public double defy { get; set; }
        public double defz { get; set; }
        public Vertex(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.defx = x;
            this.defy = y;
            this.defz = z;
        }
        public Vertex(Vertex v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.defx = v.defx;
            this.defy = v.defy;
            this.defz = v.defz;
        }
        public void setxyz()
        {
            this.defx = this.x;
            this.defy = this.y;
            this.defz = this.z;
        }
    }
    public class Texture
    {
        public double x { get; set; }
        public double y { get; set; }
        public Texture(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}