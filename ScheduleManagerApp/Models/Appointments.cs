using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagerApp.Models
{
    public class Appointments : CalendarItem, INotifyPropertyChanged
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Stop { get; set; }
        public string AttendeesString { get; set; }


        private ObservableCollection<string> attendees;
        public ObservableCollection<string> Attendees
        {
            get
            {
                //Initialization of attendees list 
                //Uses Spilt on the AttendeesString to break the string into to sub strings and create a new list
                //Then I check using linq where to ensure that no empty string are passed into the attendees array
                //Lastly, the return provides the values in attendees to be passed to the Attendees List
                attendees = new ObservableCollection<string>();
                var list = AttendeesString?.Split(new char[] { ',' })?.ToList() ?? new List<string>();
                list.Where(t => !string.IsNullOrEmpty(t)).ToList().ForEach(attendees.Add);
                return attendees;
            }
        }

        public Appointments(Guid ID) : base(ID) { }
        public Appointments()
        {
            Start = DateTime.Today;
            Stop = DateTime.Today;
        }
        public override string ToString()
        {

            var str = $" Priority: {PriorityString}\t AppointmentName: {Name}\t AppointmentStart: {Start:d}\t AppointmentStop: {Stop:d}\n\t Description: {Description} \tAttendess: ";
            //For loop that goes through every object in the Attendees list and appends them to a string 
            //Then returns the string value ensuring that all values in Attendees list are printed to console/screen
            foreach (var attend in Attendees)
            {
                str += $" {attend}";
            }
            return str;
        }

    }
}
