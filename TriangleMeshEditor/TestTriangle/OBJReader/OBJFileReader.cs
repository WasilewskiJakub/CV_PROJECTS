using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTriangle.Classes;
using System.IO;
using System.Globalization;
using System.Windows.Media.Media3D;

namespace TestTriangle.OBJReader
{
    public class OBJFileReader
    {
        public string path;
        public OBJItem Readed_Object { get; set; }
        public OBJFileReader(string filepath)
        {
            this.path = filepath;
        }
        public override string ToString()
        {
            FileInfo f = new FileInfo(this.path);
            return f.Name;
        }
        public bool RenderObject()
        {
            if (!File.Exists(path))
                return false;
            Readed_Object = new OBJItem();
            using(StreamReader file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Parser(line);
                }
            }
            this.Readed_Object.Resize();
            this.Readed_Object.SetMaxZ();
            return true;
        }
        private void Parser(string line)
        {
            string[] tab = line.Split(' ');
            
            if (tab.Length == 0)
                return;

            Dictionary<string,Action<string[],OBJItem>> prefixes = new Dictionary<string, Action<string[], OBJItem>>();
            prefixes.Add("f",(line, obj)=> {
                var fac = new Face();
                
                var tmp1 = new List<string>(line);
                
                tmp1.RemoveAll((x) => x == "");
                line = tmp1.ToArray();
                
                for (int i = 1; i < line.Length; i++)
                {
                    var tmp = line[i].Split('/');

                    if (tmp.Length == 1)
                        fac.set.Add(new Face.FaceVertex(obj.v[int.Parse(tmp[0]) - 1], null, null));
                    else if (tmp.Length == 2)
                        fac.set.Add(new Face.FaceVertex(obj.v[int.Parse(tmp[0]) - 1], obj.vt[int.Parse(tmp[1]) - 1], null));
                    else if (tmp.Length == 3)
                    {
                        var tmp12 = obj.v[int.Parse(tmp[0]) - 1];
                        
                        var vnnew = new Vertex(tmp12.x + obj.vectorn[int.Parse(tmp[2]) - 1].X, tmp12.y + obj.vectorn[int.Parse(tmp[2]) - 1].Y, tmp12.z + obj.vectorn[int.Parse(tmp[2]) - 1].Z);
                        
                        fac.set.Add(new Face.FaceVertex(obj.v[int.Parse(tmp[0]) - 1], tmp[1] != "" ? obj.vt[int.Parse(tmp[1]) - 1] : null, vnnew));
                        obj.vn.Add(vnnew);
                    }
                        
                }
                obj.f.Add(fac);
            });
            prefixes.Add("v",(line,obj)=> {
                var tmp = new List<string>(line);
                tmp.RemoveAll((x) => x == "");
                line = tmp.ToArray();
                obj.v.Add(new Vertex(double.Parse(line[1], CultureInfo.InvariantCulture), -1*double.Parse(line[2], CultureInfo.InvariantCulture), double.Parse(line[3], CultureInfo.InvariantCulture)));
            });
            prefixes.Add("vt", (line, obj) => {
                var tmp1 = new List<string>(line);
                tmp1.RemoveAll((x) => x == "");
                line = tmp1.ToArray();
                obj.vt.Add(new Texture(double.Parse(line[1], CultureInfo.InvariantCulture), double.Parse(line[2], CultureInfo.InvariantCulture)));
            });
            prefixes.Add("vn", (line, obj) => {
                var tmp1 = new List<string>(line);
                tmp1.RemoveAll((x) => x == "");
                line = tmp1.ToArray();
                obj.vectorn.Add(new Vector3D(double.Parse(line[1], CultureInfo.InvariantCulture), -1*double.Parse(line[2], CultureInfo.InvariantCulture), double.Parse(line[3], CultureInfo.InvariantCulture)));
            });
            if (!prefixes.ContainsKey(tab[0]))
                return;

            var f = prefixes[tab[0]];
            f(tab, this.Readed_Object);
        }
    }
}
