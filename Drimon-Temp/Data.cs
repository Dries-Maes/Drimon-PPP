using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Drimon_Temp
{
    internal class Data
    {
        
        public static void DeleteKlant(int idInput)
        {
            List<object> KlantenDataObjUIT = Serializer.BinaryDeserialize("Klanten.bin");
            List<Klant> KlantenData = KlantenDataObjUIT.Cast<Klant>().ToList();
            KlantenData[idInput].Actief = false;
            List<object> KlantenDataOnjIN = KlantenData.Cast<object>().ToList();
            Serializer.BinarySerialize(KlantenDataOnjIN, "Klanten.bin");
        }

        public static void AddKlant(Klant klant)
        {
            List<Klant> KlantenData = new List<Klant>();
            List<object> KlantenDataObjUIT = Serializer.BinaryDeserialize("Klanten.bin");
            if (KlantenDataObjUIT != null) {    KlantenData = KlantenDataObjUIT.Cast<Klant>().ToList();
            };
            
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
        public static void DeleteBestelling(int idInput)
        {
            List<object> BestellingenDataObjUIT = Serializer.BinaryDeserialize("Bestellingen.bin");
            List<Bestelling> BestellingenData = BestellingenDataObjUIT.Cast<Bestelling>().ToList();
            Bestelling item = BestellingenData.SingleOrDefault(x => x.ID == idInput);
            if (item != null)
                BestellingenData.Remove(item);
            List<object> BestellingenDataOnjIN = BestellingenData.Cast<object>().ToList();
            Serializer.BinarySerialize(BestellingenDataOnjIN, "Bestellingen.bin");
        }

        public static void AddBestelling(Bestelling input)
        {
            List<object> BestellingenDataObjUIT = Serializer.BinaryDeserialize("Bestellingen.bin");
            List<Bestelling> BestellingenData = BestellingenDataObjUIT.Cast<Bestelling>().ToList();
            BestellingenData.Add(input);
            List<object> BestellingenDataOnjIN = BestellingenData.Cast<object>().ToList();
            Serializer.BinarySerialize(BestellingenDataOnjIN, "Bestellingen.bin");
        }

        public static List<Bestelling> GetBestelling()
        {
            List<object> BestellingenDataOBJ = Serializer.BinaryDeserialize("Bestellingen.bin");
            List<Bestelling> BestellingenData = BestellingenDataOBJ.Cast<Bestelling>().ToList();
            return BestellingenData;
        }
        public static void DeleteSchotel(int idInput)
        {
            List<object> SchotelsDataObjUIT = Serializer.BinaryDeserialize("Schotels.bin");
            List<Schotel> SchotelsenData = SchotelsDataObjUIT.Cast<Schotel>().ToList();
            SchotelsenData[idInput].Actief = false;
            List<object> SchotelsDataOnjIN = SchotelsenData.Cast<object>().ToList();
            Serializer.BinarySerialize(SchotelsDataOnjIN, "Schotels.bin");
        }

        public static void AddSchotel(Schotel schotel)
        {
            List<object> SchotelsDataObjUIT = Serializer.BinaryDeserialize("Schotels.bin");
            List<Schotel> SchotelsData = SchotelsDataObjUIT.Cast<Schotel>().ToList();
            SchotelsData.Add(schotel);
            List<object> SchotelsDataOnjIN = SchotelsData.Cast<object>().ToList();
            Serializer.BinarySerialize(SchotelsDataOnjIN, "Schotels.bin");
        }

        public static List<Schotel> GetSchotel()
        {
            List<object> SchotelsDataOBJ = Serializer.BinaryDeserialize("Schotels.bin");
            List<Schotel> SchotelsData = SchotelsDataOBJ.Cast<Schotel>().ToList();
            return SchotelsData;
        }
        public static void DeleteProduct(int idInput)
        {
            List<object> ProductDataObjUIT = Serializer.BinaryDeserialize("Producten.bin");
            List<Product> ProductData = ProductDataObjUIT.Cast<Product>().ToList();
            ProductData[idInput].Actief = false;
            List<object> ProductDataOnjIN = ProductData.Cast<object>().ToList();
            Serializer.BinarySerialize(ProductDataOnjIN, "Producten.bin");
        }

        public static void AddProduct(Product product)
        {
            List<object> ProductenDataObjUIT = Serializer.BinaryDeserialize("Producten.bin");
            List<Product> ProductenData = ProductenDataObjUIT.Cast<Product>().ToList();
            ProductenData.Add(product);
            List<object> ProductenDataOnjIN = ProductenData.Cast<object>().ToList();
            Serializer.BinarySerialize(ProductenDataOnjIN, "Producten.bin");
        }

        public static List<Product> GetProduct()
        {
            List<object> ProductenDataOBJ = Serializer.BinaryDeserialize("Producten.bin");
            List<Product> productenData = ProductenDataOBJ.Cast<Product>().ToList();
            return productenData;
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