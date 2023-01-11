using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools_For_Events.Enums;

namespace Visitor_Placement_Tools_For_Events
{
    public class Row
    {
        public static int seats;
        public int Number { get; private set; }
        public List<Seat> Seats { get; private set; }
        public SectionLetterEnum.SectionLetter SectionLetter { get; private set; }

        public Row(int number, SectionLetterEnum.SectionLetter sectionletter)
        {
            SectionLetter = sectionletter;
            Number = number;
            Seats = new List<Seat>();
            if (number == 1)
            {
                Random r = new Random();
                seats = r.Next(3, 10);
            }
            GenerateSeats(seats);
        }

        private List<Seat> GenerateSeats(int amount)
        {
            // 3 --> amount ; is omdat we 3 seats willen atm
            for (int i = 1; i <= 3; i++)
            {
                Seat seat = new Seat(i, SectionLetter, Number);
                Seats.Add(seat);
            }
            return Seats;
        }

        public int TotalSeatsFree()
        {
            int seatsFree = 0;
            foreach(Seat seat in Seats)
            {
                if(seat.SeatedVisitor == null) seatsFree++;
            }
            return seatsFree;
        }

        public int FrontRowSeatsLeft()
        {
            if (Number == 1)
            {
                return TotalSeatsFree();
            }
            return 0;
        }

        public bool PlaceVisitorOnSeat(Visitor visitor)
        {
            foreach (Seat seat in Seats)
            {
                if (seat.SeatedVisitor == null)
                {
                    seat.PlaceVisitor(visitor);
                    return true;
                }

            }
            return false;
        }
    }
}

