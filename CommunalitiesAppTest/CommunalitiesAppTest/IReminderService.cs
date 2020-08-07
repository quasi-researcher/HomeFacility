using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace HomeFacility
{
    public interface IReminderService
    {
        string Remind(DateTime datetime, string title, string message);
    }
}
