using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class UserLoginCheckEventResponse
    {
        public bool IsValid { get; set; }

        public string TotalPrice { get; set; }
    }
}
