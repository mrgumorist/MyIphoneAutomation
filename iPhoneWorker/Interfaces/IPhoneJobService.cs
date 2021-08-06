using iPhoneWorker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPhoneWorker.Interfaces
{
    public interface IPhoneJobService
    {
        public ActionResult ConnectPhone();
        public bool IsSSHConnected();
        public ActionResult UnlockPhone();
        public ActionResult LockPhone();
        public ActionResult MakeScreenshot();
        public ActionResult SaveLastScreenShot(string folderPath);
        public void DisconnectPhone();
    }
}
