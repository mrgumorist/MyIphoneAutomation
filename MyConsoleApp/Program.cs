using iPhoneWorker;
using iPhoneWorker.Interfaces;
using iPhoneWorker.Services;
using System;
using System.Threading;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone("192.168.31.6", "root", "alpine");
            IPhoneJobService phoneJobService = new PhoneJobService(phone);
            phoneJobService.ConnectPhone();
            phoneJobService.UnlockPhone();
            phoneJobService.MakeScreenshot();
            phoneJobService.SaveLastScreenShot("C:/Users/mrgumorist/source/repos/ConsoleApp28/ConsoleApp28");
            Thread.Sleep(5000);
            phoneJobService.LockPhone();
            phoneJobService.DisconnectPhone();
        }
    }
}
