using AutoMapper;
using Entities;
using Entities.Extensions;
using Entities.Models;
using Repositories.Mappers;


namespace Repositories
{
    public class WorkerTrackerRepository : IWorkerTrackerRepository
    {
        private readonly FarmDbContext _farmDbContext;

        private readonly IMapper _mapper;

        public WorkerTrackerRepository(FarmDbContext farmDbContext, IMapper mapper)
        {
            _farmDbContext = farmDbContext ?? throw new ArgumentNullException();

            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public async Task AddAsync(WorkerTrackerModel item)
        {
            var workerTracker = WorkerTrackerMapper.CreateWorkerTracker(item);

            await _farmDbContext.AddAsync(workerTracker!);

            await _farmDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _farmDbContext.WorkerTrackers.FindAsync(id);

            _farmDbContext.Remove(entity);

            await _farmDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkerTrackerModel>> GetAllAsync()
        {
            var result = _farmDbContext.WorkerTrackers;

            var mappedResult = _mapper.Map<IEnumerable<WorkerTracker>, IEnumerable<WorkerTrackerModel>>(result);

            return await Task.FromResult(mappedResult);
        }

        public async Task<WorkerTrackerModel> GetByIdAsync(Guid id)
        {
            var entity = await _farmDbContext.WorkerTrackers.FindAsync(id);

            var mappedEntity = _mapper.Map<WorkerTrackerModel>(entity);

            return mappedEntity;
        }

        public async Task UpdateAsync(WorkerTrackerModel item)
        {
            var entity = await _farmDbContext.WorkerTrackers.FindAsync(item.Id);

            if (entity != null)
            {
                entity.UpdateWorkerTracker(item);

                await _farmDbContext.SaveChangesAsync();
            }
        }
    }
}
