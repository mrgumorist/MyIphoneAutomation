using System;

namespace iPhoneWorker
{
    public class Phone
    {
        public string PhoneIP { get; set; }
        public string PhoneSSHLogin { get; set; }
        public string PhoneSSHPass { get; set; }

        public Phone(string phoneIP, string phoneSSHLogin, string phoneSSHPass)
        {
            PhoneIP = phoneIP;
            PhoneSSHLogin = phoneSSHLogin;
            PhoneSSHPass = phoneSSHPass;
        }
    }
}
