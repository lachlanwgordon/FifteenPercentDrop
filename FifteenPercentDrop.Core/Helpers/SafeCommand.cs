using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FifteenPercentDrop.Services;
using Microsoft.AppCenter.Crashes;
using MvvmHelpers.Commands;

namespace FifteenPercentDrop.Core.Helpers
{
    public class SafeCommand : AsyncCommand
    {
        public Func<Task> Execute { get; }
        static ILogger Logger = new Logger();//Will need to get this VIA DI when we go blazor.

        public SafeCommand(Func<Task> execute,
                            Func<object, bool>? canExecute = null,
                            bool continueOnCapturedContext = false) : base(execute, canExecute, CatchException, continueOnCapturedContext)
        {
            this.Execute = execute;
        }

        private static void CatchException(Exception ex)
        {
            Debug.WriteLine($"error Command");
            Logger.Log(ex);
        }
    }

    public class SafeCommand<T> : AsyncCommand<T>
    {
        static ILogger Logger = new Logger();//Will need to get this VIA DI when we go blazor.

        public SafeCommand(Func<T, Task> execute,
                            Func<object, bool>? canExecute = null,
                            bool continueOnCapturedContext = false) : base(execute, canExecute, CatchException, continueOnCapturedContext)
        {

        }

        private static void CatchException(Exception ex)
        {
            Debug.WriteLine($"error Command");
            Logger.Log(ex);
        }
    }
}