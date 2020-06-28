using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace FifteenPercentDrop.Services
{
    public interface ILogger
    {
        void Log(string logInfo);
        void Log(Exception ex);

    }

    public class Logger : ILogger
    {
        public void Log(string logInfo)
        {
            var analyticsEnabled = Xamarin.Essentials.Preferences.Get(PreferencesKeys.Analytics, true);
            if(analyticsEnabled)
            {
                Analytics.TrackEvent(logInfo);
            }

        }

        public void Log(Exception ex)
        {
            Crashes.TrackError(ex);

        }
    }

}