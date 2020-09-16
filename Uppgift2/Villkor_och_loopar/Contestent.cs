
namespace Villkor_och_loopar
{
    public class Contestent
    { 
        public Contestent(int startNumber, int startHour, int startMinute, int startSecond, int endHour, int endMinute, int endSecond)
        {
            StartNumber = startNumber;
            StartHour = startHour;
            StartMinute = startMinute;
            StartSecond = startSecond;
            EndHour = endHour;
            EndMinute = endMinute;
            EndSecond = endSecond;
        }

        public int StartNumber { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StartSecond { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int EndSecond { get; set; }

    }
}
