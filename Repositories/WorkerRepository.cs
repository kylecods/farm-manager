using AutoMapper;
using Entities;
using Entities.Extensions;
using Entities.Models;

using Repositories.Mappers;

namespace Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly FarmDbContext _farmDbContext;

        private readonly IMapper _mapper;

        public WorkerRepository(FarmDbContext farmDbContext, IMapper mapper)
        {
            _farmDbContext = farmDbContext ?? throw new ArgumentNullException();

            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public async ValueTask AddAsync(WorkerModel item)
        {
            var worker = WorkerMapper.CreateWorker(item);

            await _farmDbContext.AddAsync(worker!);

            await _farmDbContext.SaveChangesAsync();
        }

        public virtual async ValueTask DeleteAsync(Guid id)
        {
            var entity = await _farmDbContext.Workers.FindAsync(id);

            _farmDbContext.Remove(entity);

            await _farmDbContext.SaveChangesAsync();
        }

        public virtual async ValueTask<IEnumerable<WorkerModel>> GetAllAsync()
        {
            var result = _farmDbContext.Workers;

            var mappedResult = _mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerModel>>(result);

            return await ValueTask.FromResult(mappedResult);
        }

        public virtual async ValueTask<WorkerModel> GetByIdAsync(Guid id)
        {
            var entity = await _farmDbContext.Workers.FindAsync(id);

            var mappedEntity = _mapper.Map<WorkerModel>(entity);

            return mappedEntity ?? new WorkerModel();
        }

        public virtual async ValueTask UpdateAsync(WorkerModel item)
        {
            var entity = await _farmDbContext.Workers.FindAsync(item.Id);

            if (entity != null)
            {
                entity.UpdateWorker(item);

                await _farmDbContext.SaveChangesAsync();
            }
        }
    }

}
