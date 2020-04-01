using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Train.Entities;

namespace Train.Services
{
    public class FileServices
    {
        public async IAsyncEnumerable<TrainPath> ReadFile()
        {
            using (TextFieldParser parser = new TextFieldParser(@"Data/test_task_data.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    var dateStart = DateTime.Parse(fields[4]);
                    var dateEnd = DateTime.Parse(fields[5]);
                    var dateDiff = GetDiff(dateStart, ref dateEnd);
                    //await Task.Delay(50);
                    // try
                    yield return new TrainPath
                    {
                        TrainNumber = fields[0],
                        DepartureStation = fields[1],
                        ArrivalStation = fields[2],
                        Cost = double.Parse(fields[3], CultureInfo.InvariantCulture),
                        DateStart = dateStart,
                        DateEnd = dateEnd,
                        DateDiff = dateDiff
                    };
                }
            }
        }

        private double GetDiff(DateTime dateStart, ref DateTime dateEnd)
        {
            if (dateStart > dateEnd)
                dateEnd = dateEnd.AddDays(1);

            return (dateEnd - dateStart).TotalSeconds;
        }
    }
}