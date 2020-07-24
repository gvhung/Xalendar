using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Xalendar.Api.Extensions;

namespace Xalendar.Api.Models
{
    public class MonthContainer
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Month _month;
        
        public IReadOnlyList<Day?> Days { get; }
        public IReadOnlyList<string> DaysOfWeek { get; }
        
        public MonthContainer(DateTime dateTime)
        {
            _month = new Month(dateTime);
            
            var daysOfContainer = new List<Day?>();
            this.GetDaysToDiscardAtStartOfMonth(daysOfContainer);
            daysOfContainer.AddRange(_month.Days);
            this.GetDaysToDiscardAtEndOfMonth(daysOfContainer);
            Days = daysOfContainer;

            var cultureInfo = CultureInfo.CurrentCulture;
            DaysOfWeek = new List<string>
            {
                cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Sunday).ToUpper(),
                cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Monday).ToUpper(),
                cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Tuesday).ToUpper(),
                cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Wednesday).ToUpper(),
                cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Thursday).ToUpper(),
                cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Friday).ToUpper(),
                cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Saturday).ToUpper()
            };
        }
    }
}
