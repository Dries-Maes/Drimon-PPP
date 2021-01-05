using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Drimon_Temp
{
     class Data
    {
        string folder = $"C:/Users/{Environment.UserName}/source/repos/Drimon-Temp/Drimon-Temp/";
        public static List<object> KlantenData = new List<object>();
        public static List<Product> ProductenData = new List<Product>();
        public static List<Schotel> SchotelsData = new List<Schotel>();
        public static List<Bestellingen> BestellingenData = new List<Bestellingen>();
        public static void AddKlant()
        {
            Serializer dataSerializer = new Serializer();

            /*KlantenData = dataSerializer.BinaryDeserialize($"C:/Users/{Environment.UserName}/source/repos/Drimon-Temp/Drimon-Temp/klant.data");
            */

            KlantenData.Add(new Klant("Dries"));
            KlantenData.Add(new Klant("Simon"));
            
           
            dataSerializer.BinarySerialize(KlantenData, $"C:/Users/{Environment.UserName}/source/repos/Drimon-Temp/Drimon-Temp/klant.data");

        }
        public static string DirFile(string file = "")
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string combined = projectDirectory + "\\" + file;
            return combined;
        }
    }
}

