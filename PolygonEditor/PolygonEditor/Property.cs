using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PolygonEditor
{
    enum EdgeStyle
    {
        SystemLine, Bresenham
    }

    static class Property
    {
        static public EdgeStyle Style;
        static public int LineWidth;
        static public Color curr_color;
        static public Polygon.Vertex selected;
        static public PolygonSet polygons;
        static public CursorPos curr_cur;
        static public bool movevert;
        static public bool moveedge;
        static public Polygon.Vertex VertCopy;
        static public Edge edge_copy;
        static public Polygon workingpolyg;
        static public Edge selected_edge;
        static public int Tolerance;
        static public bool movepolyg;
        static public List<Polygon.Vertex> verts_cp;
        static public Edge toperpe;
        static public int len_counter;
        static public List<Perpendicular> perps_list;
        static public void ResetProperty()
        {
            selected = null;
            verts_cp = null;
            VertCopy = null;
            edge_copy = null;
            curr_cur = null;
            //workingpolyg = null;
            selected_edge = null;
            moveedge = false;
            movepolyg = false;
            movevert = false;
        }
    }
    class CursorPos
    {
        public int X;
        public int Y;
        public CursorPos(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    static class Functions
    {
        static public Func<float, float> by2points(Polygon.Vertex v1, Polygon.Vertex v2)
        {
            if (v2.Y - v1.Y == 0)
                return (x) => v2.Y; // pozioma
            if (v2.X - v1.X == 0)
                return null; // pionowa 
            return (x) => { return ((v2.Y - v1.Y)/(v2.X - v1.X)) * (x - v1.X) + v1.Y;}; // inna!
        }
    }
    static class Extensions
    {
        public static List<Polygon.Vertex> Copy (this List<Polygon.Vertex> l)
        {
            var ret = new List<Polygon.Vertex>();
            foreach (var v in l)
                ret.Add(new Polygon.Vertex(v));
            return ret;
        }
    }
}
