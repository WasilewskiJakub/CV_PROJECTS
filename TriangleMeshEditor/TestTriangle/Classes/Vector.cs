using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTriangle.Classes
{
    class Vector
    {
        public Vertex u;
        public Vertex v;
        public Vector(Vertex u, Vertex v)
        {
            this.u = u;
            this.v = v;
        }
    }
}
