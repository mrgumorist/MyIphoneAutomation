using iPhoneWorker.Interfaces;
using iPhoneWorker.Models;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iPhoneWorker.Services
{
    public class PhoneJobService:IPhoneJobService
    {
        private readonly Phone _phone;
        SshClient _client;
        private const string PressHomeButtonCommand = "activator send libactivator.system.homebutton";
        private const string LockPhoneCommand = "activator send libactivator.system.sleepbutton";


        public PhoneJobService(Phone phone)
        {
            _phone = phone;
        }

        public ActionResult ConnectPhone()
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                _client = new SshClient(_phone.PhoneIP, _phone.PhoneSSHLogin, _phone.PhoneSSHPass);
                _client.Connect();
                actionResult.IsSuccessfull = true;
                actionResult.Description = "Connected successfully";
            }
            catch(Exception ex)
            {
                actionResult.IsSuccessfull = false;
                actionResult.ResObj = ex;
                actionResult.Description = ex.Message;
            }
            return actionResult;
        }

        public bool IsSSHConnected()
        {
            bool isConnected = false;
            try
            {
                isConnected = _client.IsConnected;
            }
            catch
            {
                //TODO logger
                isConnected = false;
            }
            return isConnected;
        }

        public ActionResult UnlockPhone()
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                _client.RunCommand(PressHomeButtonCommand);
                _client.RunCommand(PressHomeButtonCommand);
                actionResult.IsSuccessfull = true;
                actionResult.Description = "Unlocked successfully";
            }
            catch (Exception ex)
            {
                actionResult.IsSuccessfull = false;
                actionResult.ResObj = ex;
                actionResult.Description = ex.Message;
            }
            return actionResult;
        }

        public ActionResult LockPhone()
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                _client.RunCommand(LockPhoneCommand);
                actionResult.IsSuccessfull = true;
                actionResult.Description = "Locked successfully";
            }
            catch (Exception ex)
            {
                actionResult.IsSuccessfull = false;
                actionResult.ResObj = ex;
                actionResult.Description = ex.Message;
            }
            return actionResult;
        }

        public ActionResult MakeScreenshot()
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                _client.RunCommand("activator send libactivator.system.take-screenshot");
                actionResult.IsSuccessfull = true;
                actionResult.Description = "Connected successfully";
            }
            catch (Exception ex)
            {
                actionResult.IsSuccessfull = false;
                actionResult.ResObj = ex;
                actionResult.Description = ex.Message;
            }
            return actionResult;
        }

        public ActionResult SaveLastScreenShot(string folderPath)
        {
            ActionResult actionResult = new ActionResult();
            try
            {
                string imagesDir = "/private/var/mobile/Media/DCIM/100APPLE";
                //GoToImagesDirectory
                var cmd = _client.RunCommand($"cd {imagesDir}&&dir  -t --width=1");
                var neededImageName = cmd.Result.Split('\n')[0];
                //SaveLast
                var neededImageFilePath = imagesDir + '/' + neededImageName;
                var sftp = new SftpClient(_phone.PhoneIP, _phone.PhoneSSHLogin, _phone.PhoneSSHPass);
                sftp.Connect();
                using (Stream fileStream = File.Create($@"{folderPath}/{neededImageName}"))
                {
                    sftp.DownloadFile(neededImageFilePath, fileStream);
                }
                sftp.Disconnect();
                //RemoveScreenShot
                //_client.RunCommand($"rm neededImageFilePath");

                actionResult.IsSuccessfull = true;
                actionResult.Description = "Connected successfully";
            }
            catch (Exception ex)
            {
                actionResult.IsSuccessfull = false;
                actionResult.ResObj = ex;
                actionResult.Description = ex.Message;
            }
            return actionResult;
        }

        public void DisconnectPhone()
        {
            _client.Disconnect();
        }
    }
}
