using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTriangle.Classes;
using System.Windows.Media;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;

namespace TestTriangle.StaticProperty
{
    static class Light
    {
        public static Vertex possition;
        public static double kd;
        public static double ks;
        public static double m;
        public static Color color;
        public static void ResetLight()
        {
            possition = new Vertex(0, 0, 1.1);
            color = Color.FromRgb(255, 255, 255);
            kd = 1;
            ks = 1;
            m = 100;
        }
        public static void Rotate(double angle)
        {
            //angle = (Math.PI / 180) * angle;
            possition.x = possition.defx * Math.Cos(angle) + possition.defy * Math.Sin(angle);
            possition.y = -possition.defx * Math.Sin(angle) + possition.defy * Math.Cos(angle);
        }
        public static void Rchange(float len)
        {
            System.Windows.Vector v = new System.Windows.Vector(possition.x, possition.y);
            if (v.Length == 0)
                v = new System.Windows.Vector(0, -1);
            else
                v.Normalize();
            v.X = v.X * len;
            v.Y = v.Y * len;
            possition = new Vertex(v.X, v.Y, possition.z);
        }
    }
}
