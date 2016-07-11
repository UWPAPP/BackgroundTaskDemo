using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.System.Threading;

namespace RuntimeTask
{
    public sealed partial class Task1 : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral = null;
        IBackgroundTaskInstance _taskInstance = null;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;
            Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");

            var settings = ApplicationData.Current.LocalSettings;
            settings.Values["Task1"] = "this is Task1 data";
            _deferral.Complete();
        }
    }
    public sealed partial class Task2 : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral = null;
        IBackgroundTaskInstance _taskInstance = null;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;
            Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");

            var settings = ApplicationData.Current.LocalSettings;
            settings.Values["Task2"] = "this is Task2 data";
            _deferral.Complete();
        }
    }
}
