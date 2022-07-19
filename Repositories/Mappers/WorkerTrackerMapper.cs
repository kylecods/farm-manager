using AutoMapper;
using Entities;
using Entities.Models;

namespace Repositories.Mappers
{
    public class WorkerTrackerMapper : Profile
    {
        public WorkerTrackerMapper()
        {
            CreateMap<WorkerTracker, WorkerTrackerModel>();
        }

        public static WorkerTracker CreateWorkerTracker(WorkerTrackerModel model)
        {
            var workerTracker = new WorkerTracker();

            workerTracker.SetNewId();

            workerTracker.WorkerId = model.WorkerId;

            workerTracker.KiloGramsPicked = model.KiloGramsPicked;

            workerTracker.Activity = model.Activity;

            workerTracker.AmountPaid = model.AmountPaid;

            workerTracker.PickedDate = model.PickedDate;

            workerTracker.CreatedDate = DateTime.Now;

            return workerTracker;
        }

    }
}
