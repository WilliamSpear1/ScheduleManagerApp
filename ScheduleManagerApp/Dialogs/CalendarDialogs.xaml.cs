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
    public sealed partial class CalendarDialogs: ContentDialog
    {
        private IList<CalendarItem> calandarItems;
        public CalendarDialogs(IList<CalendarItem> calendarItems)
        {
            InitializeComponent();
            DataContext = new Tasks();
            this.calandarItems = calendarItems;
            DatePicker.MinDate = DateTime.Today;
         
        }
        public CalendarDialogs(IList<CalendarItem> calendarItems, CalendarItem SelectedItem) {
            InitializeComponent();
            DataContext = SelectedItem;
            this.calandarItems = calendarItems;
            DatePicker.MinDate = DateTime.Today;
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var ItemOfInterset = DataContext as Tasks;
            var existingTask = calandarItems.FirstOrDefault(t => t.ID == ItemOfInterset.ID);    //Search if Item is already in list
            if (existingTask == null)   //If not add to list as Tasks
            {
                //Add the object as Tasks to the list
                calandarItems.Add(DataContext as Tasks);
            }
            else 
            {
                var index = calandarItems.IndexOf(ItemOfInterset); //Determine where in the list the object is 
                calandarItems.RemoveAt(index); //Remove the Item from lost
                calandarItems.Insert(index, ItemOfInterset);//Put the newly made/edited item in the list where the previous item was 
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
