using System;

namespace iPhoneWorker
{
    public class Phone
    {
        private string _phoneIP;
        private string _phoneSSHLogin;
        private string _phoneSSHPass;

        public Phone(string phoneIP, string phoneSSHLogin, string phoneSSHPass)
        {
            _phoneIP = phoneIP;
            _phoneSSHLogin = phoneSSHLogin;
            _phoneSSHPass = phoneSSHPass;
        }
    }
}
