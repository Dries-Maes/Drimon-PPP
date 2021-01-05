using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.CompilerServices;
using System.Linq; 

namespace Drimon_Temp
{
     class Data
    {
        
        
        public static void DeleteKlant(int idInput)
        {
            List<object> KlantenDataObjUIT = Serializer.BinaryDeserialize("Klanten.bin");
            List<Klant> KlantenData = KlantenDataObjUIT.Cast<Klant>().ToList();
            
            Klant item = KlantenData.SingleOrDefault(x => x.ID == idInput);
            if (item != null)
                KlantenData.Remove(item);

            List<object> KlantenDataOnjIN = KlantenData.Cast<object>().ToList();
            Serializer.BinarySerialize(KlantenDataOnjIN, "Klanten.bin");
        }
        public static void AddKlant(Klant klant)
        {
            List<object> KlantenDataObjUIT = Serializer.BinaryDeserialize("Klanten.bin");
            List<Klant> KlantenData = KlantenDataObjUIT.Cast<Klant>().ToList();

            KlantenData.Add(klant);
            
            List<object> KlantenDataOnjIN = KlantenData.Cast<object>().ToList();
            Serializer.BinarySerialize(KlantenDataOnjIN, "Klanten.bin");
        }
        public static List<Klant> GetKlant()
        {
            List<object> KlantenDataOBJ = Serializer.BinaryDeserialize("Klanten.bin");
            List<Klant> klantenData = KlantenDataOBJ.Cast<Klant>().ToList();
            

            return klantenData;
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

