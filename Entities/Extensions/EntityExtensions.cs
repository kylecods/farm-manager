using Entities.Models;

namespace Entities.Extensions
{

    public static class EntityExtensions
    {
        public static void UpdateFactory(this Factory factory, FactoryModel copy)
        {
            factory.FactoryName = copy.FactoryName;

            factory.PhoneNumber = copy.PhoneNumber;

            factory.Location = copy.Location;
        }
        public static void UpdateWorker(this Worker worker, WorkerModel copy)
        {
            worker.WorkerName = copy.WorkerName;

            worker.PhoneNumber = copy.PhoneNumber;
        }


        public static void UpdateWorkerTracker(this WorkerTracker workerTracker, WorkerTrackerModel copy)
        {
            workerTracker.WorkerId = copy.WorkerId;

            workerTracker.KiloGramsPicked = copy.KiloGramsPicked;
        }

        public static void UpdateFactoryCollection(this FactoryCollection factoryCollection, FactoryCollectionModel copy)
        {
            factoryCollection.AmountPaid = copy.AmountPaid;

            factoryCollection.Weight = copy.Weight;

            factoryCollection.PaidDate = copy.PaidDate;
        }
    }
}
