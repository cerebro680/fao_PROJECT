// See https://aka.ms/new-console-template for more information

using System.IO;       
using System;
using CsvHelper;        //Library for reading in CSV files
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;     //Library for reading in CSV files
using CsvHelper.Configuration.Attributes;    //Library for reading in CSV files


namespace fao

{
    class program
    {
        static void Main(String[] args)
        {

            /* Reads in input from csv files according to director */
            using (var datacasesReader = new StreamReader(@"F:\proj\fao_PROJECT\fao_PROJECT\soft_assignment\data_cases_1.csv")) //use directory as desired


            {
                using (var csvReader = new CsvReader(datacasesReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<classmapping>();
                    var records = csvReader.GetRecords<cases>().ToList();
                }
                using (var diseaselistReader = new StreamReader(@"F:\proj\fao_PROJECT\fao_PROJECT\soft_assignment\disease_list.csv")) //use directory as desired

                {
                    using (var csvReader = new CsvReader(diseaselistReader, CultureInfo.InvariantCulture))
                    {
                        var records = csvReader.GetRecords<dynamic>().ToList();
                    }

                }
            }

        }

    }
    public class classmapping : ClassMap<cases> //With cases as base class
    {
        public classmapping  //Map class
            {
            Map(m => m.uuid).Name("uuid");
        Map(m => m.datetime).Name("datetime");
        Map(m => m.species).Name("species");
        Map(m => m.number_morbidity.Name("number_morbidity");
        Map(m => m.disease_id).Name("disease_id");
        Map(m => m.number_mortality).Name("number_mortality");
        Map(m => m.total_number_cases).Name("total_number_cases");
        Map(m => m.location).Name("location"); 
    }

    public class diseasemapping : ClassMap<diseases> //With diseases as base class
    {
        public classmapping  //Map class
            {
            Map(m => m.ID).Name("ID");
        Map(m => m.name).Name("name");
       
    }




}




    





    public class cases   //Getter and setter methods
    {

        public int uuid { get; set; }

        public string datetime { get; set; }

        public string species { get; set; }

        public int number_morbidity { get; set; }

        public int disease_id { get; set; }


        public int number_mortality { get; set; }

        public int total_number_cases { get; set; }

        public string location { get; set; }


    }

   public class diseases   //getter and setter methods
{
    
    public int ID { get; set; }
    
    public string name { get; set; }

}


