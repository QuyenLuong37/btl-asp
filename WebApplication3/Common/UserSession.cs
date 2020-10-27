using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Common
{
    [Serializable]
    public class UserSession
    {
        public String email { get; set; }
        public int  userId { get; set; }
    }
}