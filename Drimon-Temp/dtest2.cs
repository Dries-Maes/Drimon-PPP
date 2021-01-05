using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Drimon_Temp
{ 
[Serializable]
public class Lizard
{
    public string Type { get; set; }
    public int Number { get; set; }
    public bool Healthy { get; set; }

    public Lizard(string t, int n, bool h)
    {
        Type = t;
        Number = n;
        Healthy = h;
    }
}
class Dtest
{
    public static void DTEST()
    {
            /* while (true)
             {
                 Console.WriteLine("s=serialize, r=read:");
                 switch (Console.ReadLine())
                 {
                     case "s":
                         var lizards1 = new List<object>();
                         lizards1.Add(new Lizard("Horny Simon", 1, true));
                         lizards1.Add(new Lizard("Casquehead Dries", 0, false));
                         lizards1.Add(new Lizard("Green Ward", 4, true));
                         lizards1.Add(new Lizard("Blotched blue-tongue Emma", 0, false));
                         lizards1.Add(new Lizard("Gila monster", 1, false));

                             Serializer.BinarySerialize(lizards1, "testje.bin");

                             break;
                         case "r":

                             var testje = Serializer.BinaryDeserialize("testje.bin");
                             foreach (Lizard lizard in testje)
                             {
                                 Console.WriteLine("{0}, {1}, {2}",
                                     lizard.Type,
                                     lizard.Number,
                                     lizard.Healthy);
                             }


                         break;
                 }
             }

     */
        }
    }
}