using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Drimon_Temp
{
    internal class Serializer
    {
        public static void BinarySerialize(List<object> data, string file)
        {
            try
            {
                using (Stream stream = File.Open(Data.DirFile(file), FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, data);
                }
            }
            catch (IOException) //opzoeken wat dit doet.
            {
            }
        }

        public static List<object> BinaryDeserialize(string file)
        {
            List<object> resultaat = null;
            try
            {
                using (Stream stream = File.Open(Data.DirFile(file), FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    resultaat = (List<object>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }
            return resultaat;
        }
    }
}