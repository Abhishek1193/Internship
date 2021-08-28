using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Internship
{
    class Program
    {

       static void newCSVCountry(string name, string filename, string template, object[] arr)
        {
            createFile(filename, template);
            var csv = new StringBuilder();
            
            List<string> listA = (List<string>)arr[0];
            List<string> listB = (List<string>)arr[1];
            List<string> listC = (List<string>)arr[2];
            List<string> listD = (List<string>)arr[3];
            List<string> listE = (List<string>)arr[4];
            List<string> listF = (List<string>)arr[5];
            List<string> listG = (List<string>)arr[6];
            List<string> listH = (List<string>)arr[7];
            List<string> listI = (List<string>)arr[8];

            //createFile(file, template);


            for (int i = 0; i < listA.Count; i++)
            {
                var title = listI[i];
                bool contains = title.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0;
                if (contains)
                {
                    var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                        listA[i], listB[i], listC[i], listD[i], listE[i], listF[i], listG[i], listH[i], listI[i]);
               
                    csv.AppendLine(newLine);
                }

            }
            File.AppendAllText(filename, csv.ToString());
            Console.WriteLine("usa.csv created");
        }
        static void minCSV(string filename, string template, object[] arr)
        {
            createFile(filename, template);
            var csv = new StringBuilder();
            
            List<string> listA = (List<string>)arr[0];
            List<string> listF = (List<string>)arr[5];

            string curr = listA[1];
            List<double> price = new List<double>();
            
            for(int i = 1; i < listA.Count; i++)
            {
                price.Add(69420.69);
                price.Add(69420.69);
                
                if ((!string.Equals(curr, listA[i])||i == listA.Count-1))
                {
                  
                    curr = listA[i];
                    price.Sort();

                    var newline = string.Format("{0},{1},{2}", listA[i - 1],price[0].ToString(),price[1].ToString());
                    csv.AppendLine(newline);
                    price.Clear();
                    double parsed;
                    var input = listF[i];
                   
                    parsed = Double.Parse(input, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
                    
                    price.Add(parsed);
                    

                }
                else
                {
                    var input = listF[i];
                    input = input.Replace("\"","");
                    input = input.Replace("?", "");
                    input = input.Replace("x", "");
                    input = input.Replace("cl", "");
                    input = input.Replace("Case3", "");
                    input = input.Replace("�", "");
                    
                    double parsed;
                    parsed = Double.Parse(input, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
                 
                    price.Add(parsed);
                }

            }
            File.AppendAllText(filename, csv.ToString());
            Console.WriteLine("min.csv created");




        }
        static void createFile(string file,string template)
        {
            if (!File.Exists(file))
            {
                File.Create(file);
                TextWriter tw = new StreamWriter(file);
                tw.WriteLine(template.ToString());
                tw.Close();
            }
            else if (File.Exists(file))
            {
                TextWriter tw = new StreamWriter(file);
                tw.Flush();
                tw.WriteLine(template.ToString());
                tw.Close();
            }
        }
        static void Main(string[] args)
        {
            
            string filePath = "main.csv";
            StreamReader reader = null;
            if (File.Exists(filePath))
            {
                reader = new StreamReader(File.OpenRead(filePath));
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> listC = new List<string>();
                List<string> listD = new List<string>();
                List<string> listE = new List<string>();
                List<string> listF = new List<string>();
                List<string> listG = new List<string>();
                List<string> listH = new List<string>();
                List<string> listI = new List<string>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    //var values = line.Split("\"");

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                    listC.Add(values[2]);
                    listD.Add(values[3]);
                    listE.Add(values[4]);
                    listF.Add(values[5]);
                    listG.Add(values[6]);
                    listH.Add(values[7]);
                    listI.Add(values[8]);
                }
                Object[] arr = new object[9];
                arr[0] = listA;
                arr[1] = listB;
                arr[2] = listC;
                arr[3] = listD;
                arr[4] = listE;
                arr[5] = listF;
                arr[6] = listG;
                arr[7] = listH;
                arr[8] = listI;
        
                
                //USA
                var country = "usa";
                var template = "SKU,DESCRIPTION,YEAR,CAPACITY,URL,PRICE,SELLER_INFORMATION,OFFER_DESCRIPTION,COUNTRY";
                string file = "usa.csv";
                
                newCSVCountry(country, file,template, arr);
                string file1 = "min.csv";
                var template1 = "SKU,FIRST_MINIMUM_PRICE, SECOND_MINIMUM_PRICE";
                minCSV(file1, template1, arr);
                

            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }

            

           
        }



    }
 }

