using System;
using System.Collections.Generic;
using System.Text;

namespace AppCursValutar.Services.Date
{
    public interface IDateTimeProvider
    {
        DateTime DateTimeNow { get; }
    }
}
