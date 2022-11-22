using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows;

namespace TestTriangle.FileHistory
{
    [Serializable]
    public class RecentProjects
    {
        public List<ProjectData> Details { get; set; }
        public RecentProjects()
        {
            this.Details = new List<ProjectData>();
        }
        public void Makedata()
        {
            for (int i = 0; i < 30; i++)
            {
                this.Details.Add(new ProjectData($"New Project{i}", $"C://New Project{i}", DateTime.Now));
            }
        }
    }
    [Serializable]
    public class ProjectData
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime LastEdit { get; set; }
        public ProjectData() { }
        public ProjectData(string name, string path, DateTime dt)
        {
            this.FilePath = path;
            this.FileName = name;
            this.LastEdit = dt;
        }
    }
    static class Serializators
    {
        public static string SetPath;
        public static void Serializate_Recent_Projects(RecentProjects obj)
        {
            bool result = File.Exists(Serializators.SetPath);
            if ( result== false)
            {
                MessageBox.Show("Can not save recent projects to startup file.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(RecentProjects));
            using(FileStream file = new FileStream(Serializators.SetPath, FileMode.Truncate))
            {
                serializer.Serialize(file, obj);
            }
        }
        public static RecentProjects Deserializate_Recent_Projects()
        {
            bool result = File.Exists(Serializators.SetPath);
            if (result == false)
            {
                MessageBox.Show("Can not load recent projects from startup file.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return new RecentProjects();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(RecentProjects));
            var RP = new RecentProjects();
            using (FileStream file = new FileStream(Serializators.SetPath, FileMode.Open))
            {
                if (file.Length == 0)
                    return RP;
                RP = (RecentProjects)serializer.Deserialize(file);
            }
            return RP;
        }
    }
}