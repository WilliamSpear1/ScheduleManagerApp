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
    public sealed partial class SaveDialogs : ContentDialog
    {
        private IList<CalendarItem> calandarItems;

        public SaveDialogs(IList<CalendarItem> CalendarItems)
        {
            InitializeComponent();
            DataContext = new ScheduleViewModel();
            this.calandarItems = CalendarItems;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
             String Name =SaveN.Text;
            var items = JsonConvert.SerializeObject(calandarItems);
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            File.WriteAllText(filePath + Name + ".json", items);
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
