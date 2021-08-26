using Newtonsoft.Json;
using ScheduleManagerApp.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagerApp.Models
{
    //Registration of Json Converter as the default for properties/derived classes of type CalendarItem
    [JsonConverter(typeof(CalendarItemJsonConverter))]
    public class CalendarItem : INotifyPropertyChanged
    {
        public String PriorityString { get; set; } //Takes in a String from dialogs and uses that String to set the 
                                                   //Priority Levels based off of passed String
        private int priority;
        public int Priority
        { 
            get 
            {
                    if (PriorityString.ToUpper().Equals("High".ToUpper()))
                    {  
                        priority = 2;
                    }
                    else if (PriorityString.ToUpper().Equals("Medium".ToUpper()))
                    {
                        priority = 1;
                    }
                    else if (PriorityString.ToUpper().Equals("Low".ToUpper())) 
                    {
                        priority = 0;
                    }
                    return priority; 
              }
           
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ID { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CalendarItem() { ID = Guid.NewGuid(); }
        public CalendarItem(Guid ID) { this.ID = ID; }
       
        public override string ToString()
        {
            return $"{Name}\t Description: {Description}";
        }
    }
}
