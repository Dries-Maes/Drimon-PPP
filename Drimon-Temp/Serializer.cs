using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Drimon_Temp
{
    internal class Serializer
    {
        public static void BinarySerialize(List<Klant> data, string file)
        {
            
            try
            {
                using (Stream stream = File.Open(Data.DirFile(file), FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, data);
                }
            }
            catch (IOException)
            {
            }
        }

        public static List<Klant> BinaryDeserialize(string file)
        {
            List<Klant> resultaat = null;
            try
            {
                using (Stream stream = File.Open(Data.DirFile(file), FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    resultaat = (List<Klant>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }
            return resultaat;
        }
    }
}