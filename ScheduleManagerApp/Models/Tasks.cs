using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagerApp.Models
{
    public class Tasks : CalendarItem, INotifyPropertyChanged
    {
        public DateTimeOffset Deadline { get; set; }
        public bool Iscompleted 
        {
            get { return IsChecked; }
            set { IsChecked = value; }
        }
        public bool IsChecked { get; set; } //Used for the completed check box in CalendarDialogs
                                             //When the box is checked sets the Iscompleted field to true

        public Tasks(Guid ID) : base(ID) { }
        public Tasks() {
            Deadline = DateTime.Today;//DateTimeOffset variable coupled with CalendarDateTimePicker provided
                                       //MinDateTime of 1921 a 100 years off to correct this error
                                       //Set the DateTimeOffset variable in Constructors 
        }
        public override string ToString()
        {
            String status = null;
            if (Iscompleted == true)
            {
                status = "Task has been completed";
            }
            else 
            {
                status = "Task has not been completed";
            }
             return $" Priority: {PriorityString}\t Task Name: {Name}\t Due: {Deadline:d}\t Description: {Description} \t Task Completion Status: {status}";
        }
    }
}
