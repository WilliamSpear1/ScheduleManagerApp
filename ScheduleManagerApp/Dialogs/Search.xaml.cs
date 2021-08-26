using Newtonsoft.Json;
using ScheduleManagerApp.Models;
using ScheduleManagerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ScheduleManagerApp.Dialogs
{
    public sealed partial class Search : ContentDialog
    {
        private IList<CalendarItem> calendar_Items;
        public Search(IList<CalendarItem> calendarItems)
        {
            InitializeComponent();
            DataContext = new ScheduleViewModel();
            this.calendar_Items = calendarItems;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            List<CalendarItem> calendarItems1 = new List<CalendarItem>();//Temporary List made to hold the results of the queries

            string text = Searching.Text;
             //Queries for the list for any names or descriptions that might match the string in text
            var searched = calendar_Items.Where(t => t.Description.ToUpper().Contains(text.ToUpper())
           || t.Name.ToUpper().Contains(text.ToUpper()));
            //Queries the sub list for attendees that might match the string in text 
            var searchedAttendess = calendar_Items.Where(
                t => (t as Appointments)?.Attendees?.Any(a => a.ToUpper().Contains(text.ToUpper())) ?? false);
            
            if (searched.Count() > 0 || searchedAttendess.Count() > 0)
            {
                foreach (var obj in searched)
                {
                    if (obj is Appointments)
                    { 
                            calendarItems1.Add(obj as Appointments);
                    }
                    else if (obj is Tasks)
                    {
                            calendarItems1.Add(obj as Tasks);
                    }
                }

                if (searchedAttendess != null)
                {
                    foreach (var obj in searchedAttendess)
                    {
                        bool exists = calendarItems1.Any(t => t.ID == obj.ID);
                        if (!exists)
                        {
                            calendarItems1.Add(obj as Appointments);
                        }
                    }
                }
                calendar_Items.Clear();
                foreach (var obj in calendarItems1) {
                    if (obj is Appointments)
                    {
                        calendar_Items.Add(obj as Appointments);
                    }
                    else if (obj is Tasks) 
                    {
                        calendar_Items.Add(obj as Tasks);
                    }
                }
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args){}
    }
}

