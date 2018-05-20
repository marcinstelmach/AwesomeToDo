using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeToDo.Core.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public int ExpiryTime { get; set; }
        public string Issuer { get; set; }
    }
}
