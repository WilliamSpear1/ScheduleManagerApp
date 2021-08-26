using ScheduleManagerApp.Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScheduleManagerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new ScheduleViewModel();
            (DataContext as ScheduleViewModel).LoadContents();
        }

        private  async void Add_Click_App(object sender, RoutedEventArgs e)
        {
            var diag = new AppDialogs((DataContext as ScheduleViewModel).CalendarItems);
            await diag.ShowAsync();
        }
        private async void Add_Click_Task(object sender, RoutedEventArgs e) {
            var diag = new CalendarDialogs((DataContext as ScheduleViewModel).CalendarItems);
            await diag.ShowAsync();
        }
        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as ScheduleViewModel).SelectedCalendarItem is Tasks)
            {
                var diag = new CalendarDialogs((DataContext as ScheduleViewModel).CalendarItems, (DataContext as ScheduleViewModel).SelectedCalendarItem);
                await diag.ShowAsync();
            }
            else if ((DataContext as ScheduleViewModel).SelectedCalendarItem is Appointments) {
                var diag = new AppDialogs((DataContext as ScheduleViewModel).CalendarItems, (DataContext as ScheduleViewModel).SelectedCalendarItem);
                await diag.ShowAsync();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ScheduleViewModel).Remove();
        }

        private async void Searh_Click(object sender, RoutedEventArgs e)
        { 
            var diag = new Search((DataContext as ScheduleViewModel).CalendarItems);
            await diag.ShowAsync();
        }

      
        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            var diag = new LoadDialogs((DataContext as ScheduleViewModel).CalendarItems);
            await diag.ShowAsync();

        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {

            var diag = new SaveDialogs((DataContext as ScheduleViewModel).CalendarItems);
            await diag.ShowAsync();

        }

        private void SortPriority_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ScheduleViewModel).SortPriority();
        }

        private void SortLettter_Click_1(object sender, RoutedEventArgs e)
        {
            (DataContext as ScheduleViewModel).SortAlpha();
        }

        private void SortLetterReverse_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ScheduleViewModel).SortReverse();
        }

        private void Display_Uncompleted_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ScheduleViewModel).display_uncompleted();
        }
    }
}
