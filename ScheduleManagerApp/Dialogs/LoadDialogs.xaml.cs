using Newtonsoft.Json;
using ScheduleManagerApp.Json;
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
    public sealed partial class LoadDialogs : ContentDialog
    {
        private IList<CalendarItem> calendarItems;
        public LoadDialogs(IList<CalendarItem> CalendarItems)
        {
            InitializeComponent();
            DataContext = new ScheduleViewModel();
            this.calendarItems = CalendarItems;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            String Name = LoadN.Text; //Gets the load name from xaml 
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);//Gets a path to the folder to house the Json array items
            var calendar_items = JsonConvert.DeserializeObject<List<CalendarItem>>(File.ReadAllText(filePath + Name + ".json"), new CalendarItemJsonConverter()).ToList();//Deserialization of json file using 
            calendarItems.Clear();                                                                                                                                        //Custom Json converter that converts the base class 

            foreach (var obj in calendar_items)
            {
                if (obj is Appointments)
                {
                    calendarItems.Add(obj as Appointments);
                }
                else if (obj is Tasks)
                {
                    calendarItems.Add(obj as Tasks);
                }
            }
        }
            private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
