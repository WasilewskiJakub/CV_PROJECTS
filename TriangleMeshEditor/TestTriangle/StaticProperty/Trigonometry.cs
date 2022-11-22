using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTriangle.StaticProperty
{
    static class Trigonometry
    {
        public static double ForMove(double angle) => (Math.PI / 180) * angle;
        public static double ForAnim(double angle) => Math.Sin((Math.PI / 180) * angle);
    }
}
