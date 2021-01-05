using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Drimon_Temp
{
     class Data
    {
        string folder = $"C:/Users/{Environment.UserName}/source/repos/Drimon-Temp/Drimon-Temp/";
        public static List<Klant> KlantenData = new List<Klant>();
        public static List<Product> ProductenData = new List<Product>();
        public static List<Schotel> SchotelsData = new List<Schotel>();
        public static List<Bestellingen> BestellingenData = new List<Bestellingen>();

        public static void AddKlant()
         {
             

        KlantenData.Add(new Klant("Dries", "Maes"));
        KlantenData.Add(new Klant("Simon"));
        KlantenData.Add(new Klant("Ward", "ward"));
            Serializer.BinarySerialize(KlantenData, "Klanten.bin");
           
       }
        public static List<Klant> GetKlant()
        {

            List<Klant> klantinfo = Serializer.BinaryDeserialize("Klanten.bin");
             
            return klantinfo;
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

