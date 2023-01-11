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
            GenerateRows();
        }
        public List<Row> GenerateRows()
        {
            for (int i = 1; i <= MaxRows; i++)
            {
                Row row = new Row(i, Name);
                Rows.Add(row);
            }
            return Rows;
        }

        public bool SeatVisitorInRow(Visitor visitor)
        {
            foreach (Row row in Rows)
            {
                bool Placed = row.PlaceVisitorOnSeat(visitor);
                if (Placed) return true;                     
            }
            return false;           
        }

        public bool IsEnoughSeatsForGroupWithChildren(int groupSize, int children)
        {
            int freeSeats = 0;
            int freeFrontSeats = 0;
            foreach(Row row in Rows)
            {
                freeFrontSeats += row.FrontRowSeatsLeft();
                freeSeats += row.TotalSeatsFree(); 
            }

            if (freeSeats >= groupSize && freeFrontSeats >= children) return true;
            else return false;
        }
    }
}
