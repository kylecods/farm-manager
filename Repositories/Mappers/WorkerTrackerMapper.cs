using Entities;
using Entities.Models;
using AutoMapper;

namespace Repositories.Mappers
{
    public class WorkerTrackerMapper: Profile
    {
        public WorkerTrackerMapper()
        {
            CreateMap<WorkerTrackerMapper, WorkerTrackerModel>();
        }

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
