using System;

namespace Train.Entities
{
    public class TrainPath
    {
        public string TrainNumber { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public double Cost { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double DateDiff { get; set; }
    }
}