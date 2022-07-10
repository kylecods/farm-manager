using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkerTracker :Entity
    {
        public Guid WorkerId { get; set; }

        public Worker Worker { get; set; }

        public decimal KiloGramsPicked { get; set; }
    }
}
