using ScheduleManagerApp.Models;
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
    public sealed partial class AppDialogs : ContentDialog
    {
        private IList<CalendarItem> calandarItems;
        public AppDialogs(IList<CalendarItem> calendarItems)
        {
            InitializeComponent();
            DataContext = new Appointments();
            this.calandarItems = calendarItems;
            StartDate.MinDate = DateTime.Today;
            StopDate.MinDate = DateTime.Today;
        }
        public AppDialogs(IList<CalendarItem> calendarItems, CalendarItem SelectedItem)
        {
            InitializeComponent();
            DataContext = SelectedItem;
            this.calandarItems = calendarItems;
            StartDate.MinDate = DateTime.Today;
            StopDate.MinDate = DateTime.Today;

        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
           
            var ItemOfInterset = DataContext as Appointments;
            var existingappointment = calandarItems.FirstOrDefault(t => t.ID == ItemOfInterset.ID);
            if (existingappointment == null)
            {
                //Add the Appointment to the list
                calandarItems.Add(DataContext as Appointments);
            }
            else {
                var index = calandarItems.IndexOf(ItemOfInterset);
                calandarItems.RemoveAt(index);
                calandarItems.Insert(index, ItemOfInterset);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
