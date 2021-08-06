using System;
using System.Collections.Generic;
using System.Text;

namespace iPhoneWorker.Models
{
    public class ActionResult
    {
        public bool IsSuccessfull { get; set; } = false;
        public string Description { get; set; } = "";
        public object ResObj { get; set; } = null;

        public ActionResult()
        {

        }

        public ActionResult(bool IsSuccessfull, string Description)
        {
            this.IsSuccessfull = IsSuccessfull;
            this.Description = Description;
        }

        public ActionResult(bool IsSuccessfull, string Description, string Data)
        {
            this.IsSuccessfull = IsSuccessfull;
            this.Description = Description;
        }

        public ActionResult(bool IsSuccessfull, string Description, object Obj)
        {
            this.IsSuccessfull = IsSuccessfull;
            this.Description = Description;
            this.ResObj = Obj;
        }
    }
}
