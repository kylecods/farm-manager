using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mappers
{
    public class WorkerTrackerMapper
    {
        public static WorkerTracker CreateWorkerTracker(WorkerTrackerModel model)
        {
            var workerTracker = new WorkerTracker();

            workerTracker.SetNewId();

            workerTracker.KiloGramsPicked = model.KiloGramsPicked;

            workerTracker.CreatedDate = DateTime.Now;

            return workerTracker;
        }
    }
}
