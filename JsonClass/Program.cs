using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string JsonPath = Environment.CurrentDirectory.ToString() + @"\jsonFile.json";


            var newRAM1 = new RAM("8GB", "DDR4", "1", "2666");
            var newRAM2 = new RAM("16GB", "DDR4", "1", "2666");

            var newCPU1 = new CPU("i3-8950U", "2.0GHz");
            var newCPU2 = new CPU("i5-8900U", "2.1GHz");

            Dictionary<string, Dictionary<string, List<Part>>> MainDictionary = new Dictionary<string, Dictionary<string, List<Part>>>();

            List<Part> RAMList = new List<Part>();
            List<Part> RAMList1 = new List<Part>();
            RAMList.Add(newRAM1);
            RAMList.Add(newRAM1);
            RAMList1.Add(newRAM2);
            List<Part> CPUList = new List<Part>();
            List<Part> CPUList1 = new List<Part>();
            CPUList.Add(newCPU1);
            CPUList1.Add(newCPU2);

            Dictionary<string, List<Part>> PartDictionary = new Dictionary<string, List<Part>>();
            PartDictionary.Add("RAM", RAMList);
            MainDictionary.Add("95185-010", PartDictionary);

            PartDictionary = new Dictionary<string, List<Part>>();
            PartDictionary.Add("RAM", RAMList1);
            MainDictionary.Add("98185-001", PartDictionary);

            PartDictionary = new Dictionary<string, List<Part>>();
            PartDictionary.Add("CPU", CPUList);
            MainDictionary.Add("98905-002", PartDictionary);

            PartDictionary = new Dictionary<string, List<Part>>();
            PartDictionary.Add("CPU", CPUList);
            MainDictionary.Add("78185-001", PartDictionary);

            //foreach (var key in PartDictionary.Keys)
            //{
            //    //Console.Write("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}\n", key, PartDictionary[key]._type);
            //    string type = PartDictionary[key]._type;
            //    Console.WriteLine("{0,-15}{1,-15}", key, PartDictionary[key].Size);
            //}

            //https://www.newtonsoft.com/json/help/html/ReducingSerializedJSONSize.htm
            //Ignore any values that is null, follow link above instruction
            string jsonContent = JsonConvert.SerializeObject(MainDictionary, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            using (StreamWriter Writer = new StreamWriter(JsonPath))
            {
                Writer.WriteLine(jsonContent);
            }

            string ReadJSON = File.ReadAllText(JsonPath);
            Console.WriteLine(ReadJSON);

            Dictionary<string, Dictionary<string, List<Part>>> ReadPartDictionary  = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<Part>>>> (ReadJSON,Part.StandardJsonConverter);
            //foreach (var key in ReadPartDictionary.Keys)
            //{
            //    foreach(var PartKey in ReadPartDictionary[key].Keys)
            //    {
            //        switch (PartKey)
            //        {
            //            case "RAM":
            //                string partNumber = key;
            //                foreach (var list in ReadPartDictionary[key][PartKey])
            //                {
            //                    Console.Write("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}\n", key, list._type, list.Size, list.Type, list.Quantity, list.Speed);
            //                }
            //                break;
            //            case "CPU":
            //                foreach (var list in ReadPartDictionary[key][PartKey])
            //                {
            //                    Console.Write("{0,-15}{1,-15}{2,-15}{3,-15}\n", key, list._type, list.Name, list.Speed );
            //                }
            //                break;
            //        }
            //    }
                
            //}
            PrintPartInfo("95185-010", ReadPartDictionary);
            PrintPartInfo("98185-001", ReadPartDictionary);
            PrintPartInfo("98905-002", ReadPartDictionary);
            PrintPartInfo("98905-001", ReadPartDictionary);
        }

        private static void PrintPartInfo(string partNumber, Dictionary<string, Dictionary<string, List<Part>>> ReadPartDictionary)
        {
            if (ReadPartDictionary.ContainsKey(partNumber))
            {
                var ReadPart = ReadPartDictionary[partNumber].First();
                var ReadPartElement = ReadPart.Value;
                string printPartNumber = partNumber;
                switch (ReadPart.Key)
                {
                    case "RAM":
                        foreach (var list in ReadPart.Value)
                        {
                            Console.Write("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}\n", printPartNumber,list._type, list.Size, list.Type, list.Quantity, list.Speed);
                            printPartNumber = "";
                        }
                        break;
                    case "CPU":
                        foreach (var list in ReadPart.Value)
                        {
                            Console.Write("{0,-15}{1,-15}{2,-15}{3,-15}\n", printPartNumber,list._type, list.Name, list.Speed);
                            printPartNumber = "";
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0} is not found in system", partNumber);
            }
        }
    }
}
