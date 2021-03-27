using System;
using System.Collections.Generic;
using System.Text;

namespace AppCursValutar.Services.Date
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow => DateTime.Now;
    }
}
