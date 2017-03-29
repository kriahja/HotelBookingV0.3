using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.UnitTests
{
    public class FakeSystemTime
    {
        public static class SystemTime
        {
            private static DateTime date;

            public static DateTime Today
            {
                get
                {
                    return (date == DateTime.MinValue) ? DateTime.Today : date;
                }
            }

            public static void Set(DateTime customDate)
            {
                date = customDate;
            }

            public static void Reset()
            {
                date = DateTime.MinValue;
            }
        }

    }
}
