using System;

namespace WorkStation.Entities {
    class HourContract {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract() {

        }

        public HourContract(DateTime date, double valuePerHour, int hours) {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }
        
        //Definicao do valor total de ganhos Value x Hour
        public double TotalValue() {
            return Hours * ValuePerHour;
        }
    }
}
