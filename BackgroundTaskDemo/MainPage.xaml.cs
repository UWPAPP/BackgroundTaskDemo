using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackgroundTaskDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var exampleTaskName = "BackgroundTask1";
            foreach (var mytask in BackgroundTaskRegistration.AllTasks)
            {
                if (mytask.Value.Name == exampleTaskName)
                {
                    return;
                }
            }
            var builder = new BackgroundTaskBuilder();
            builder.Name = exampleTaskName;
            builder.TaskEntryPoint = "RuntimeTask.Task1";

            IBackgroundTrigger triggter = new SystemTrigger(SystemTriggerType.TimeZoneChange, false);
            builder.SetTrigger(triggter);

            BackgroundTaskRegistration task = builder.Register();
            task.Completed += new BackgroundTaskCompletedEventHandler(OnTask1Completed);
        }

        private void CancelTask1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (String.Equals(cur.Value.Name, "BackgroundTask1")) {
                    cur.Value.Unregister(true);
                }  
            }
        }


        private void OnTask1Completed(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var message = settings.Values["Task1"].ToString();
            Debug.WriteLine(message);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var exampleTaskName = "BackgroundTask2";
            foreach (var mytask in BackgroundTaskRegistration.AllTasks)
            {
                if (mytask.Value.Name == exampleTaskName)
                {
                    return;
                }
            }
            var builder = new BackgroundTaskBuilder();
            builder.Name = exampleTaskName;
            builder.TaskEntryPoint = "RuntimeTask.Task2";


            IBackgroundTrigger triggter = new SystemTrigger(SystemTriggerType.TimeZoneChange, false);
            builder.SetTrigger(triggter);

            BackgroundTaskRegistration task = builder.Register();
            task.Completed += new BackgroundTaskCompletedEventHandler(OnTask2Completed);
        }



        private void CancelTask2_Click(object sender, RoutedEventArgs e)
        {
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (String.Equals(cur.Value.Name, "BackgroundTask2"))
                {
                    cur.Value.Unregister(true);
                }
            }
        }

        private void OnTask2Completed(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var message = settings.Values["Task2"].ToString();
            Debug.WriteLine(message);

        }
    }
}
