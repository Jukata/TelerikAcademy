using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Points
{
    //Create a static class PathStorage with static methods to save 
    //and load paths from a text file. Use a file format of your choice.
    static class PathStorage
    {
        public static void SaveToFile(Path path, string filename = null)
        {
            string fullFIlePath = null;
            if (string.IsNullOrWhiteSpace(filename))
            {
                fullFIlePath = "../../test.txt";
            }
            else
            {
                fullFIlePath = "../../" + filename + ".txt";
            }

            using (StreamWriter writer = new StreamWriter(fullFIlePath))
            {
                for (int i = 0; i < path.Count; i++)
                {
                    writer.WriteLine(path[i]);
                }
            }
        }

        public static Path LoadFromFile(string fileFullPath)
        {
            Path result = new Path();
            using (StreamReader reader = new StreamReader(fileFullPath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] dimensions = line.Split(new char[] { ' ', ',', '(', ')', 'x', 'y', 'z', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    double x, y, z;
                    if (dimensions.Length == 3 &&
                        double.TryParse(dimensions[0], out x) &&
                        double.TryParse(dimensions[1], out y) &&
                        double.TryParse(dimensions[2], out z))
                    {
                        result.AddPoint(new Point3D(x, y, z));
                    }
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}
