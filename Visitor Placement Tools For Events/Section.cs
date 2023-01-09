using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Visitor_Placement_Tools_For_Events.Enums.SectionLetterEnum;

namespace Visitor_Placement_Tools_For_Events
{
    public class Section
    {
        public SectionLetter Name { get; private set; }
        public List<Row> Rows { get; private set; }
        public int MaxRows { get; private set; }
        public Section(SectionLetter name, int Maxrows)
        {
            Name = name;
            Rows = new List<Row>();
            MaxRows = Maxrows;
            Random r = new Random();
            int seats = r.Next(3, 10);
            GenerateRows(seats);
        }
        public List<Row> GenerateRows(int amountOfSeats)
        {
            for (int i = 1; i <= MaxRows; i++)
            {
                Row row = new Row(i, Name);
                Rows.Add(row);
            }
            return Rows;
        }
    }
}
