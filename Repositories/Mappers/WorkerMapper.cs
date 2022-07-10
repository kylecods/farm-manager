using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mappers
{
    public class WorkerMapper
    {

        public static Worker CreateWorker(WorkerModel model)
        {
            var worker = new Worker();

            worker.SetNewId();

            worker.WorkerName = model.WorkerName;

            worker.PhoneNumber = model.PhoneNumber;

            worker.CreatedDate = DateTime.Now;

            return worker;
        }
    }
}
