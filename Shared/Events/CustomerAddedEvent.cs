using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class CustomerAddedEvent
    {
        public Guid Id { get; set; }

        public string HumanIdentity { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string TotalPrice { get; set; }
    }
}
