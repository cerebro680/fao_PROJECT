                         //WELCOME TO MY FAO PROJECT. THANK YOU FOR THE OPPORTUNITY
                         //AUTHOR: RUMI CHOWDHURY

using System.IO;       
using System;
using CsvHelper;        //Library/declarations for reading in CSV files
using System.Globalization;  
using System.Linq;
using CsvHelper.Configuration;     //For adding namespaces
using CsvHelper.Configuration.Attributes;    //adding namespaces
using Newtonsoft.Json; //Will automatically ask to install package
using System.Collections.Generic;

namespace fao_PROJECT

{
    class program
    {
        static void Main(String[] args)  //Main method
        {
            // Take dotnet stream reader as a constructor parameter
            /* Reads in input from csv files according to directory */
            using (var datacasesReader = new StreamReader(@"F:\proj\fao_PROJECT\fao_PROJECT\soft_assignment\data_cases_1.csv")) //use directory as desired
            {
                
                using (var csvReader = new CsvReader(datacasesReader, CultureInfo.InvariantCulture)) //initializes csv reader class, culture handles formatting
                {
                    csvReader.Context.RegisterClassMap<classmapping>();
                    var records = csvReader.GetRecords<cases>().ToList(); 
                }

            using (var diseaselistReader = new StreamReader(@"F:\proj\fao_PROJECT\fao_PROJECT\soft_assignment\disease_list.csv")) //use directory as desired

                {
                    using (var csvReader1 = new CsvReader(diseaselistReader, CultureInfo.InvariantCulture))
                    {
                        csvReader1.Context.RegisterClassMap<diseasemapping>();
                        var records = csvReader1.GetRecords<diseases>().ToList(); 
                    }

                }
                using (var datacasereader1 = new StreamReader(@"F:\proj\fao_PROJECT\fao_PROJECT\soft_assignment\data_cases_2.csv")) //use directory as desired

                {
                    using (var csvReader2 = new CsvReader(datacasereader1, CultureInfo.InvariantCulture))
                    {
                        csvReader2.Context.RegisterClassMap<classmapping>();
                        var records = csvReader2.GetRecords<cases>().ToList();
                    }

                }

                using (var datacasecorrupted = new StreamReader(@"F:\proj\fao_PROJECT\fao_PROJECT\soft_assignment\data_cases_corrupted.csv")) //use directory as desired

                {
                    using (var csvReader3 = new CsvReader(datacasecorrupted, CultureInfo.InvariantCulture))
                    {
                        csvReader3.Context.RegisterClassMap<classmapping>();
                        var records = csvReader3.GetRecords<cases>().ToList();
                    }

                }


            }

            // Json code continues from here
            var indicator1 = new cases
            {

               
            }
            var json = JsonConvert.SerializeObject(input);


        }






    }

    public class classmapping : ClassMap<cases> //With cases as base class
    {
        public classmapping()  //Map class
        {
            Map(m => m.uuid).Name("uuid");
            Map(m => m.date).Name("datetime");
            Map(m => m.species).Name("species");
            Map(m => m.number_morbidity).Name("number_morbidity");
            Map(m => m.disease_id).Name("disease_id");
            Map(m => m.number_mortality).Name("number_mortality");
            Map(m => m.total_number_cases).Name("total_number_cases");
            Map(m => m.location).Name("location");
        }
    }


    public class diseasemapping : ClassMap<diseases> //With diseases as base class
    {
        public diseasemapping()  //Map class
        {
            Map(m => m.id).Name("id");
            Map(m => m.name).Name("name");
        }

    }



    public class cases   //Getter and setter methods
    {

        public string uuid { get; set; }

        public DateTime date { get; set; }

        public string species { get; set; }

        public int number_morbidity { get; set; }


        public int disease_id { get; set; }


        public int number_mortality { get; set; }

        public int total_number_cases { get; set; }

        public string location { get; set; }


    }

    public class diseases   //Getter and setter methods
    {

        public int id { get; set; }

        public string name { get; set; }

    }

    


}
//End of Program