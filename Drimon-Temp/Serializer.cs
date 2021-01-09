using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Drimon_Temp
{
    internal class Serializer
    {
        
       private static object foutmelding;
        public static void BinarySerialize(List<object> data, string file)
        {
            try
            {
                using Stream stream = File.Open(Data.DirFile(file), FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, data);
            }
            catch (IOException foutmelding)
            {
                Console.WriteLine("Serializerfout; reden -->  " + foutmelding.Message);
                Console.WriteLine("press any key to exit");
                Console.ReadLine();
            }
        }

        public static List<object> BinaryDeserialize(string file)
        {
            List<object> resultaat = null;
            try
            {
                using Stream stream = File.Open(Data.DirFile(file), FileMode.Open);
                BinaryFormatter bin = new BinaryFormatter();

                resultaat = (List<object>)bin.Deserialize(stream);
            }
            catch (IOException foutmelding)
            {
                Console.WriteLine("Serializerfout; reden -->  " + foutmelding.Message);
                Console.WriteLine("press any key to exit");
                Console.ReadLine();
            }
            return resultaat;
        }
    }
}