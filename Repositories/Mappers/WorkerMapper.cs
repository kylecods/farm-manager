using Entities;
using Entities.Models;
using AutoMapper;

namespace Repositories.Mappers
{
    public class WorkerMapper:Profile
    {
        public WorkerMapper()
        {
            CreateMap<Worker, WorkerModel>();
        }

        public static Worker CreateWorker(WorkerModel model)
        {
            var worker = new Worker();

            worker.SetNewId();

            worker.WorkerName = model.WorkerName;

            worker.PhoneNumber = model.PhoneNumber;

            worker.CreatedDate = DateTime.Now;

            return worker;
        }

        public static Worker ToWorker(WorkerModel copy)
        {
            return new Worker()
            {
                WorkerName = copy.WorkerName,
                PhoneNumber = copy.PhoneNumber,
            };
        }
    }
}
