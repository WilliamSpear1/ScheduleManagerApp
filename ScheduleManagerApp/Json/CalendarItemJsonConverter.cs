using Newtonsoft.Json.Linq;
using ScheduleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagerApp.Json
{
    public class CalendarItemJsonConverter : JsonCreationConverter<CalendarItem>
    {
        //Based off properties of the Derived determines which class is chosen for objects
        protected override CalendarItem Create(Type objectType, JObject jObject) {
            if (jObject["Deadline"] != null )
            {
                return new Tasks();
            }
            else if (jObject["Start"] != null) {
                return new Appointments();
            }
            return new CalendarItem();
        }
    }
}
