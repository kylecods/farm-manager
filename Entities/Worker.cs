using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Worker : Entity
    {
        public string WorkerName { get; set; }

        public string PhoneNumber { get; set; }

    }
}
