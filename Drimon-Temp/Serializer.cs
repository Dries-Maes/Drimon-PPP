using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Drimon_Temp
{
    class Serializer
    {
        public void BinarySerialize(List<object> data, string filePath)
        {
            
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            bf.Serialize(fileStream, data);
            fileStream.Close();

        }
        public object BinaryDeserialize(string filePath)
        {
            // using (Stream stream = File.Open("data.bin", FileMode.Open))
            object obj = null;
            
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                
                fileStream = File.OpenRead(filePath);
                obj = bf.Deserialize(fileStream);
                fileStream.Close();
            }
            var objects = obj as List<object>;
            return objects;
        }
    }
}
