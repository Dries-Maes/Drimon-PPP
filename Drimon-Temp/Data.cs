using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Drimon_Temp
{
    internal class Data
    {
        public static void DeleteKlant(int ID)
        {
            List<object> KlantenDataObjUIT = Serializer.BinaryDeserialize("Klanten.bin");
            List<Klant> KlantenData = KlantenDataObjUIT.Cast<Klant>().ToList();
            KlantenData[ID - 1].Actief = false;
            List<object> KlantenDataOnjIN = KlantenData.Cast<object>().ToList();
            Serializer.BinarySerialize(KlantenDataOnjIN, "Klanten.bin");
        }

        public static void SetKlant(List<Klant> input)
        {
            List<object> output = input.Cast<object>().ToList();
            Serializer.BinarySerialize(output, "Klanten.bin");
        }

        public static void SetProduct(List<Product> input)
        {
            List<object> output = input.Cast<object>().ToList();
            Serializer.BinarySerialize(output, "Producten.bin");
        }

        public static void SetSchotel(List<Schotel> input)
        {
            List<object> output = input.Cast<object>().ToList();
            Serializer.BinarySerialize(output, "Schotels.bin");
        }

        public static void AddKlant(Klant input)
        {
            List<Klant> KlantenData = new List<Klant>();
            List<object> KlantenDataObjUIT = Serializer.BinaryDeserialize("Klanten.bin");
            if (KlantenDataObjUIT != null) KlantenData = KlantenDataObjUIT.Cast<Klant>().ToList();
            KlantenData.Add(input);
            List<object> KlantenDataOnjIN = KlantenData.Cast<object>().ToList();
            Serializer.BinarySerialize(KlantenDataOnjIN, "Klanten.bin");
        }

        public static List<Klant> GetKlant()
        {
            if (File.Exists(Data.DirFile("Klanten.bin")))
            {
                List<object> KlantenDataOBJ = Serializer.BinaryDeserialize("Klanten.bin");
                List<Klant> klantenData = KlantenDataOBJ.Cast<Klant>().ToList();
                return klantenData;
            }
            List<Klant> klantenNoData = new List<Klant>();
            return klantenNoData;
        }

        public static void DeleteBestelling(int ID)
        {
            List<object> BestellingenDataObjUIT = Serializer.BinaryDeserialize("Bestellingen.bin");
            List<Bestelling> BestellingenData = BestellingenDataObjUIT.Cast<Bestelling>().ToList();
            Bestelling item = BestellingenData.SingleOrDefault(x => x.ID == ID);
            if (item != null)
                BestellingenData.Remove(item);
            List<object> BestellingenDataOnjIN = BestellingenData.Cast<object>().ToList();
            Serializer.BinarySerialize(BestellingenDataOnjIN, "Bestellingen.bin");
        }
        public static void SetBestelling(List<Bestelling> input)
        {
            List<object> output = input.Cast<object>().ToList();
            Serializer.BinarySerialize(output, "Bestellingen.bin");
        }
        public static void AddBestelling(Bestelling input)
        {
            List<Bestelling> BestellingenData = new List<Bestelling>();
            List<object> BestellingenDataObjUIT = Serializer.BinaryDeserialize("Bestellingen.bin");
            if (BestellingenDataObjUIT != null) BestellingenData = BestellingenDataObjUIT.Cast<Bestelling>().ToList();
            BestellingenData.Add(input);
            List<object> BestellingenDataOnjIN = BestellingenData.Cast<object>().ToList();
            Serializer.BinarySerialize(BestellingenDataOnjIN, "Bestellingen.bin");
        }

        public static List<Bestelling> GetBestelling()
        {
            if (File.Exists(Data.DirFile("Bestellingen.bin")))
            {
                List<object> BestellingenDataOBJ = Serializer.BinaryDeserialize("Bestellingen.bin");
                List<Bestelling> BestellingenData = BestellingenDataOBJ.Cast<Bestelling>().ToList();
                return BestellingenData;
            }
            List<Bestelling> BestellingenNoData = new List<Bestelling>();
            return BestellingenNoData;
        }

        public static void DeleteSchotel(int ID)
        {
            List<object> SchotelsDataObjUIT = Serializer.BinaryDeserialize("Schotels.bin");
            List<Schotel> SchotelsenData = SchotelsDataObjUIT.Cast<Schotel>().ToList();
            SchotelsenData[ID - 1].Actief = false;
            List<object> SchotelsDataOnjIN = SchotelsenData.Cast<object>().ToList();
            Serializer.BinarySerialize(SchotelsDataOnjIN, "Schotels.bin");
        }

        public static void AddSchotel(Schotel input)
        {
            List<Schotel> SchotelenData = new List<Schotel>();
            List<object> SchotelenDataObjUIT = Serializer.BinaryDeserialize("Schotels.bin");
            if (SchotelenDataObjUIT != null) SchotelenData = SchotelenDataObjUIT.Cast<Schotel>().ToList();
            SchotelenData.Add(input);
            List<object> SchotelenDataObjIN = SchotelenData.Cast<object>().ToList();
            Serializer.BinarySerialize(SchotelenDataObjIN, "Schotels.bin");
        }

        public static List<Schotel> GetSchotel()
        {
            if (File.Exists(Data.DirFile("Schotels.bin")))
            {
                List<object> SchotelsDataOBJ = Serializer.BinaryDeserialize("Schotels.bin");
                List<Schotel> SchotelsData = SchotelsDataOBJ.Cast<Schotel>().ToList();
                return SchotelsData;
            }
            List<Schotel> SchotelsNoData = new List<Schotel>();
            return SchotelsNoData;
        }

        public static void DeleteProduct(int ID)
        {
            List<object> ProductDataObjUIT = Serializer.BinaryDeserialize("Producten.bin");
            List<Product> ProductData = ProductDataObjUIT.Cast<Product>().ToList();
            ProductData[ID - 1].Actief = false;
            List<object> ProductDataOnjIN = ProductData.Cast<object>().ToList();
            Serializer.BinarySerialize(ProductDataOnjIN, "Producten.bin");
        }

        public static void AddProduct(Product product)
        {
            List<Product> ProductenData = new List<Product>();
            List<object> ProductenDataObjUIT = Serializer.BinaryDeserialize("Producten.bin");
            if (ProductenDataObjUIT != null) ProductenData = ProductenDataObjUIT.Cast<Product>().ToList();
            ProductenData.Add(product);
            List<object> ProductenDataOnjIN = ProductenData.Cast<object>().ToList();
            Serializer.BinarySerialize(ProductenDataOnjIN, "Producten.bin");
        }

        public static List<Product> GetProduct()
        {
            if (File.Exists(Data.DirFile("Producten.bin")))
            {
                List<object> ProductenDataOBJ = Serializer.BinaryDeserialize("Producten.bin");
                List<Product> productenData = ProductenDataOBJ.Cast<Product>().ToList();
                return productenData;
            }
            List<Product> productenNoData = new List<Product>();
            return productenNoData;
        }

        public static string DirFile(string file = "")
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            string combined = projectDirectory + "\\" + file;
            return combined;
        }
    }
}