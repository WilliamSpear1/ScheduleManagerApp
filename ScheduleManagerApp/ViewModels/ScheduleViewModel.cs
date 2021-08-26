using Newtonsoft.Json;
using ScheduleManagerApp.Json;
using ScheduleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagerApp.ViewModels
{
   public class ScheduleViewModel : INotifyPropertyChanged
    {
       
        public CalendarItem SelectedCalendarItem { get; set; }
        public String find { get; set; }    //String used for the search dialog box
        public String Save { get; set; }    //String used for the save dialog box
        public String Load { get; set; }    //String used for the laod dialog box

                                            //Each provide a string to work with inside methods 
        public ObservableCollection<CalendarItem> CalendarItems { get; set; }

        public ScheduleViewModel(){
            CalendarItems = new ObservableCollection<CalendarItem>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = ""){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      
        public void Remove(){
            CalendarItems.Remove(SelectedCalendarItem);
        }
        public void display_uncompleted() {
            var uncompleted = CalendarItems.Where(t => (t as Tasks)?.Iscompleted == false)?.ToList();
            CalendarItems.Clear();
            CalendarItems = Putback(uncompleted);
        }
        public void SortPriority() 
        {
           var sorted = CalendarItems.OrderByDescending(x => x.Priority).ToList(); 
            CalendarItems.Clear();
            CalendarItems = Putback(sorted);
        }
        public void SortAlpha()
        {
            var sort = CalendarItems.OrderBy(x => x.Name).ToList();
            CalendarItems.Clear();
            CalendarItems = Putback(sort);
        }
        public void SortReverse() 
        {
            SortAlpha();
            var reverseCalendar = CalendarItems.Reverse().ToList();
            CalendarItems.Clear();
            CalendarItems = Putback(reverseCalendar);
        }
       
      
        //Method made to achieve putting data into the list of calendar items from temporary list in that are thought this program
        public ObservableCollection<CalendarItem> Putback(List<CalendarItem> Items) 
        {
            foreach (var obj in Items)
            {
                if (obj is Appointments)
                {
                    CalendarItems.Add(obj as Appointments);
                }
                else if (obj is Tasks)
                {
                    CalendarItems.Add(obj as Tasks);
                }
            }
            return CalendarItems;
        } 

    public void LoadContents()
    {
            CalendarItems.Add(new Tasks { Name = "Wash", Description = "Wash the car", Deadline = DateTime.Today, PriorityString = "High" });
            CalendarItems.Add(new Tasks { Name = "Move", Description = "Help move", Deadline = DateTime.Today, PriorityString = "High" });
            CalendarItems.Add(new Tasks { Name = "TV", Description = "Watch TV", Deadline = DateTime.Today, PriorityString = "High" });
            CalendarItems.Add(new Tasks { Name = "Homework", Description = "Do Homework", Deadline = DateTime.Today, PriorityString= "High" });
            CalendarItems.Add(new Tasks { Name = "Bills", Description = "Pay Bills", Deadline = DateTime.Today, PriorityString = "High" });
            CalendarItems.Add(new Tasks { Name = "Wash", Description = "Wash clothes", Deadline = DateTime.Today, PriorityString = "Low"});
            CalendarItems.Add(new Tasks { Name = "Friends", Description = "Go see Friends", Deadline = DateTime.Today, PriorityString = "Low" });
            CalendarItems.Add(new Tasks { Name = "Game", Description = "Play Video Games", Deadline = DateTime.Today, PriorityString = "Low" });
            CalendarItems.Add(new Tasks { Name = "movies", Description = "Go to Movies", Deadline = DateTime.Today, PriorityString = "Low" });
            CalendarItems.Add(new Tasks { Name = "listen", Description = "Listen to new Album", Deadline = DateTime.Today, PriorityString = "Medium" });
            CalendarItems.Add(new Tasks { Name = "catch up", Description = "Catch up on Lectures", Deadline = DateTime.Today, PriorityString = "Medium" });
            CalendarItems.Add(new Tasks { Name = "start", Description = "Start Homework", Deadline = DateTime.Today, PriorityString = "Medium" });
            CalendarItems.Add(new Tasks { Name = "view", Description = "View the News", Deadline = DateTime.Today, PriorityString = "Medium" });
            CalendarItems.Add(new Tasks { Name = "hello", Description = "Say hello to friend", Deadline = DateTime.Today, PriorityString = "Medium" });


           CalendarItems.Add(new Appointments { Name = "Dentist", Description = "Vist Dentist", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString = "Me, Dentist", PriorityString = "Medium" });
            CalendarItems.Add(new Appointments { Name = "Dinner Party", Description = "Go to Dinner Party", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString="Me, Susan, Mary, David", PriorityString = "High" });
            CalendarItems.Add(new Appointments { Name = "Doctor", Description = "Visit Doctor", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString="Me, Doctor", PriorityString = "Low" });
            CalendarItems.Add(new Appointments { Name = "Vet", Description = "Visit Vet", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString= "Me, Henry, Veterinarian", PriorityString = "High" });
            CalendarItems.Add(new Appointments { Name = "Walk", Description = "Walk the dog", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString="Me, Henry", PriorityString = "Low" });
            CalendarItems.Add(new Appointments { Name = "Go see Grandmother", Description = "Visit Grandmother", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString="Me, Grandmother", PriorityString = "Medium" });
            CalendarItems.Add(new Appointments { Name = "Go see Mother", Description = "Visit Mother", Start = DateTime.Today, Stop = DateTime.Today ,AttendeesString="Me ,Mother", PriorityString = "Low" });
            CalendarItems.Add(new Appointments { Name = "Work", Description = "Go to work", Start = DateTime.Today, Stop = DateTime.Today,AttendeesString="Me, Coworkers", PriorityString = "Medium" });
            CalendarItems.Add(new Appointments { Name = "Watch Party", Description = "Watch the Batman movie with Friends", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString="Me, David, Jason,Emerson,Tyler", PriorityString = "High" });
            CalendarItems.Add(new Appointments { Name = "Visit job fair", Description = "Go to find job", Start = DateTime.Today, Stop = DateTime.Today,AttendeesString="me", PriorityString = "Medium" });
            CalendarItems.Add(new Appointments { Name = "Go to Career Center" , Description = "Go to find intership", Start = DateTime.Today, Stop = DateTime.Today,AttendeesString="me", PriorityString = "High" });
            CalendarItems.Add(new Appointments { Name = "Talk to Advisor", Description = "Plan out Semster", Start = DateTime.Today, Stop = DateTime.Today,AttendeesString="Me, Advisor", PriorityString = "Low" });
            CalendarItems.Add(new Appointments { Name = "Meet Neighbor", Description = "Go say hi to Next door Neighbor", Start = DateTime.Today, Stop = DateTime.Today,AttendeesString="Me, Neighbor", PriorityString = "High" });
            CalendarItems.Add(new Appointments { Name = "Upload to Github", Description = "Upload project to Github", Start = DateTime.Today, Stop = DateTime.Today,AttendeesString="me", PriorityString = "Low" });
            CalendarItems.Add(new Appointments { Name = "Download from Github", Description = "Download new project from Github", Start = DateTime.Today, Stop = DateTime.Today, AttendeesString="me", PriorityString = "Medium" });
            CalendarItems.Add(new Appointments { Name = "Watch the news", Description = "Watch the new with family", Start = DateTime.Today, Stop = DateTime.Today , AttendeesString = "me, mother,father, brother, sister", PriorityString = "Low" });
            CalendarItems.Add(new Appointments { Name = "Say hello to coworkers", Description = "Speak to coworkers about life", Start = DateTime.Today, Stop = DateTime.Today , AttendeesString = "me,coworkers", PriorityString = "Medium" });
    }
   }
}
