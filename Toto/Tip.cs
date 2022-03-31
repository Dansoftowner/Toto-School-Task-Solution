using System;
using System.Collections.Generic;
using System.Text;

namespace Toto
{
    class Tip
    {

        public int Year { get; set; }
        public int Week { get; set; }
        public int Number { get; set; }
        public int T13p1 { get; set; }
        public int Ny13p1 { get; set; }
        public string Results { get; set; }
        public bool FullPrediction => T13p1 > 0 && Ny13p1 > 0;

        public long Profit => T13p1 * Ny13p1;

        public Tip(string row) : this(row.Split(";"))
        {
        }

        private Tip(string[] data)
        {
            Year = int.Parse(data[0]);
            Week = int.Parse(data[1]);
            Number = int.Parse(data[2]);
            T13p1 = int.Parse(data[3]);
            Ny13p1 = int.Parse(data[4]);
            Results = data[5];
        }

        public override string ToString()
        {
            return string.Join("\n\t", 
                $"\n\tÉv: {Year}",  // Bad workaround
                $"Hét: {Week}", 
                $"Forduló: {Number}", 
                $"Telitalálat: {T13p1} db",
                $"Nyeremény: {Profit} Ft.",
                $"Eredmények: {Results}"
            );
        }
    }
}
