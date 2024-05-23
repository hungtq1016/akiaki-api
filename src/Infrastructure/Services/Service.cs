
namespace Infrastructure.Services
{
    public class Service<TEntity, TRequest, TResponse> : IService<TEntity, TRequest, TResponse> where TEntity : AbstractEntity where TRequest : EntityRequest
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Core.Response<PaginationResponse<List<TResponse>>>> FindPageAsync(PaginationRequest request)
        {
            var entities = await _repository.FindPageAsync(request);

            if (entities is null)
                return ResponseHelper.CreateNotFoundResponse<PaginationResponse<List<TResponse>>>(null);

            PaginationResponse<List<TResponse>> response = _mapper.Map<PaginationResponse<List<TResponse>>>(entities);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<PaginationResponse<List<TResponse>>>> FindPageByConditionAsync(PaginationRequest request, Expression<Func<TEntity, bool>>[] conditions, params string[] properties)
        {
            var entities = await _repository.FindPageByConditionAsync(request, conditions, properties);

            if (entities is null)
                return ResponseHelper.CreateNotFoundResponse<PaginationResponse<List<TResponse>>>(null);

            PaginationResponse<List<TResponse>> response = _mapper.Map<PaginationResponse<List<TResponse>>>(entities);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<TResponse>> FindRandomAsync()
        {
            var entities = await _repository.FindRandomAsync();

            if (entities is null)
                return ResponseHelper.CreateNotFoundResponse<TResponse>(null);

            TResponse response = _mapper.Map<TResponse>(entities);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<PaginationResponse<List<TResponse>>>> FindPageByTimeUnitAsync(PaginationRequest request, string timePeriod, params string[] properties)
        {
            if (string.IsNullOrWhiteSpace(timePeriod))
            {
                timePeriod = "currentday"; // Default to "currentday" if timePeriod is null or empty
            }

            var (startDate, endDate) = GetDateRange(timePeriod);

            Expression<Func<TEntity, bool>> condition = e =>
                e.UpdatedAt >= startDate && e.UpdatedAt < endDate;

            var entities = await _repository.FindPageByConditionAsync(request, new[] { condition }, properties);

            if (entities == null)
                return ResponseHelper.CreateNotFoundResponse<PaginationResponse<List<TResponse>>>(null);

            var response = _mapper.Map<PaginationResponse<List<TResponse>>>(entities);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<int>> CountByTimeUnitAsync(string timePeriod)
        {
            if (string.IsNullOrWhiteSpace(timePeriod))
            {
                timePeriod = "currentday"; // Default to "currentday" if timePeriod is null or empty
            }

            var (startDate, endDate) = GetDateRange(timePeriod);

            Expression<Func<TEntity, bool>> condition = e =>
                (e.UpdatedAt >= startDate && e.UpdatedAt < endDate) ||
                (e.CreatedAt >= startDate && e.CreatedAt < endDate);

            var count = await _repository.CountByConditionAsync(new[] { condition });

            return ResponseHelper.CreateSuccessResponse(count);
        }

        public async Task<Core.Response<List<TResponse>>> FindAllAsync(params string[] properties)
        {
            List<TEntity> records = await _repository.FindAllAsync(properties);

            if (records is null)
                return ResponseHelper.CreateNotFoundResponse<List<TResponse>>(null);

            records = records.Where(record => record.Status != StatusEnum.Inactive || record.Status != StatusEnum.Remove).ToList();

            List<TResponse> response = _mapper.Map<List<TResponse>>(records);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<List<TResponse>>> FindAllByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties)
        {
            List<TEntity> records = await _repository.FindAllByConditionAsync(conditions, properties);

            if (records is null)
                return ResponseHelper.CreateNotFoundResponse<List<TResponse>>(null);

            records = records.Where(record => record.Status != StatusEnum.Inactive || record.Status != StatusEnum.Remove).ToList();

            List<TResponse> response = _mapper.Map<List<TResponse>>(records);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<TResponse>> FindByParamsAsync(Guid id, params string[] properties)
        {
            TEntity record = await _repository.FindByParamsAsync(id, properties);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<TResponse>(null);

            var response = _mapper.Map<TResponse>(record);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<TResponse>> FindByIdAsync(Guid id)
        {
            TEntity record = await _repository.FindByIdAsync(id);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<TResponse>(null);

            var response = _mapper.Map<TResponse>(record);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<TResponse>> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions)
        {
            TEntity record = await _repository.FindOneAsync(conditions);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<TResponse>(null);

            TResponse response = _mapper.Map<TResponse>(record);

            return ResponseHelper.CreateSuccessResponse(response);
        }
        public async Task<Core.Response<TResponse>> FindOneByConditionAsync(Expression<Func<TEntity, bool>>[] conditions, params string[] properties)
        {
            TEntity record = await _repository.FindOneByConditionAsync(conditions, properties);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<TResponse>(null);

            TResponse response = _mapper.Map<TResponse>(record);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<TResponse>> AddAsync(TRequest request)
        {
            TEntity entity = _mapper.Map<TEntity>(request);

            TEntity record = await _repository.AddAsync(entity);

            TResponse response = _mapper.Map<TResponse>(record);

            return ResponseHelper.CreateCreatedResponse(response);
        }

        public async Task<Core.Response<bool>> DeleteAsync(Guid id)
        {
            TEntity record = await _repository.FindByIdAsync(id);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<bool>(null);

            await _repository.DeleteAsync(record);

            return ResponseHelper.CreateSuccessResponse(true);
        }

        public async Task<Core.Response<TResponse>> EditAsync(Guid id, TRequest request)
        {
            if (id != request.Id)
            {
                return ResponseHelper.CreateNotFoundResponse<TResponse>(null);
            }

            TEntity record = await _repository.FindByIdAsync(id);
            if (record == null)
            {
                return ResponseHelper.CreateNotFoundResponse<TResponse>(null);
            }

            _mapper.Map(request, record);

            TEntity result = await _repository.EditAsync(record);

            TResponse response = _mapper.Map<TResponse>(result);

            return ResponseHelper.CreateSuccessResponse(response);
        }


        public async Task<Core.Response<List<TResponse>>> BulkEditAsync(List<TRequest> requests)
        {
            List<TEntity> entities = _mapper.Map<List<TEntity>>(requests);

            List<TEntity> records = await _repository.BulkEditAsync(entities);

            List<TResponse> response = _mapper.Map<List<TResponse>>(records);

            return ResponseHelper.CreateSuccessResponse(response);
        }

        public async Task<Core.Response<bool>> BulkDeleteAsync(List<TRequest> requests)
        {
            List<TEntity> entities = _mapper.Map<List<TEntity>>(requests);

            await _repository.BulkDeleteAsync(entities);

            return ResponseHelper.CreateSuccessResponse(true);
        }

        public async Task<Core.Response<Dictionary<string, Dictionary<int, int>>>> CompareCountAsync(string timePeriod)
        {
            DateTime currentday = DateTime.Today;

            if (string.IsNullOrWhiteSpace(timePeriod))
            {
                timePeriod = "day"; // Default to "currentday" if timePeriod is null or empty
            }

            Dictionary<string, Dictionary<int, int>> totals = new Dictionary<string, Dictionary<int, int>>()
            {
                { "last", new Dictionary<int, int>() },
                { "current", new Dictionary<int, int>() }
            };

            switch (timePeriod.ToLower())
            {
                case "day":
                    DateTime startOfLastDay = currentday.AddDays(-1);
                    DateTime startOfCurrenDay = currentday;

                    DateTime endOfLastDay = startOfLastDay.AddDays(1);
                    DateTime endOfCurrentDay = startOfCurrenDay.AddDays(1);
                    int countLastDay = await GetCountForDateRangeAsync(startOfLastDay, endOfLastDay);
                    int countCurrentDay = await GetCountForDateRangeAsync(startOfCurrenDay, endOfCurrentDay);
                    totals["last"].Add(1, countLastDay);
                    totals["current"].Add(1, countCurrentDay);

                    break;

                case "week":
                    DateTime startOfLastWeek = currentday.AddDays(-(int)currentday.DayOfWeek - 7);
                    DateTime startOfCurrentWeek = currentday.AddDays(-(int)currentday.DayOfWeek);

                    for (int i = 0; i < 7; i++)
                    {
                        DateTime dateLastWeek = startOfLastWeek.AddDays(i);
                        DateTime dateCurrentWeek = startOfCurrentWeek.AddDays(i);
                        int countLastWeek = await GetCountForDateAsync(dateLastWeek);
                        int countCurrentWeek = await GetCountForDateAsync(dateCurrentWeek);
                        totals["last"].Add(i + 1, countLastWeek);
                        totals["current"].Add(i + 1, countCurrentWeek);
                    }
                    break;

                case "month":
                    DateTime startOfLastMonth = new DateTime(currentday.Year, currentday.Month, 1).AddMonths(-1);
                    DateTime startOfCurrentMonth = new DateTime(currentday.Year, currentday.Month, 1);
                    int daysInLastMonth = DateTime.DaysInMonth(startOfLastMonth.Year, startOfLastMonth.Month);
                    int daysInCurrentMonth = DateTime.DaysInMonth(currentday.Year, currentday.Month);

                    for (int i = 0; i < daysInLastMonth; i++)
                    {
                        DateTime dateLastMonth = startOfLastMonth.AddDays(i);
                        int countLastMonth = await GetCountForDateAsync(dateLastMonth);
                        totals["last"].Add(i + 1, countLastMonth);
                    }

                    for (int i = 0; i < daysInCurrentMonth; i++)
                    {
                        DateTime dateCurrentMonth = startOfCurrentMonth.AddDays(i);
                        int countCurrentMonth = await GetCountForDateAsync(dateCurrentMonth);
                        totals["current"].Add(i + 1, countCurrentMonth);
                    }
                    break;

                case "quarter":
                    int currentQuarter = (currentday.Month - 1) / 3 + 1;
                    DateTime startOfLastQuarter = new DateTime(currentday.Year, (currentQuarter - 2) * 3 + 1, 1);
                    DateTime startOfCurrentQuarter = new DateTime(currentday.Year, (currentQuarter - 1) * 3 + 1, 1);
                    int monthsInQuarter = 3;

                    for (int i = 0; i < monthsInQuarter; i++)
                    {
                        DateTime startOfMonthInLastQuarter = startOfLastQuarter.AddMonths(i);
                        DateTime endOfMonthInLastQuarter = startOfMonthInLastQuarter.AddMonths(1);
                        int countLastQuarter = await GetCountForDateRangeAsync(startOfMonthInLastQuarter, endOfMonthInLastQuarter);
                        totals["last"].Add(i + 1, countLastQuarter);

                        DateTime startOfMonthInCurrentQuarter = startOfCurrentQuarter.AddMonths(i);
                        DateTime endOfMonthInCurrentQuarter = startOfMonthInCurrentQuarter.AddMonths(1);
                        int countCurrentQuarter = await GetCountForDateRangeAsync(startOfMonthInCurrentQuarter, endOfMonthInCurrentQuarter);
                        totals["current"].Add(i + 1, countCurrentQuarter);
                    }
                    break;

                case "year":
                    DateTime startOfLastYear = new DateTime(currentday.Year - 1, 1, 1);
                    DateTime startOfCurrentYear = new DateTime(currentday.Year, 1, 1);

                    for (int i = 0; i < 12; i++)
                    {
                        DateTime startOfMonthInLastYear = startOfLastYear.AddMonths(i);
                        DateTime endOfMonthInLastYear = startOfMonthInLastYear.AddMonths(1);
                        int countLastYear = await GetCountForDateRangeAsync(startOfMonthInLastYear, endOfMonthInLastYear);
                        totals["last"].Add(i + 1, countLastYear);

                        DateTime startOfMonthInCurrentYear = startOfCurrentYear.AddMonths(i);
                        DateTime endOfMonthInCurrentYear = startOfMonthInCurrentYear.AddMonths(1);
                        int countCurrentYear = await GetCountForDateRangeAsync(startOfMonthInCurrentYear, endOfMonthInCurrentYear);
                        totals["current"].Add(i + 1, countCurrentYear);
                    }
                    break;

                default:
                    return ResponseHelper.CreateNotFoundResponse<Dictionary<string, Dictionary<int, int>>>("Invalid period specified");
            }

            return ResponseHelper.CreateSuccessResponse(totals);
        }

        private async Task<int> GetCountForDateAsync(DateTime date)
        {
            DateTime startDate = date;
            DateTime endDate = date.AddDays(1);

            Expression<Func<TEntity, bool>> condition = e =>
                (e.UpdatedAt >= startDate && e.UpdatedAt < endDate) ||
                (e.CreatedAt >= startDate && e.CreatedAt < endDate);

            return await _repository.CountByConditionAsync(new[] { condition });
        }

        private async Task<int> GetCountForDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            Expression<Func<TEntity, bool>> condition = e =>
                (e.UpdatedAt >= startDate && e.UpdatedAt < endDate) ||
                (e.CreatedAt >= startDate && e.CreatedAt < endDate);

            return await _repository.CountByConditionAsync(new[] { condition });
        }


        private (DateTime startDate, DateTime endDate) GetDateRange(string timePeriod)
        {
            DateTime currentday = DateTime.Today;
            DateTime startDate;
            DateTime endDate = currentday.AddDays(1); // Default end date to the start of the next day

            switch (timePeriod.ToLower())
            {
                case "currentday":
                    startDate = currentday;
                    break;
                case "lastday":
                    startDate = currentday.AddDays(-1);
                    endDate = currentday;
                    break;
                case "lastweek":
                    startDate = currentday.AddDays(-(int)currentday.DayOfWeek - 7);
                    endDate = startDate.AddDays(7);
                    break;
                case "currentweek":
                    startDate = currentday.AddDays(-(int)currentday.DayOfWeek);
                    endDate = startDate.AddDays(7);
                    break;
                case "lastmonth":
                    startDate = new DateTime(currentday.Year, currentday.Month, 1).AddMonths(-1);
                    endDate = startDate.AddMonths(1);
                    break;
                case "currentmonth":
                    startDate = new DateTime(currentday.Year, currentday.Month, 1);
                    endDate = startDate.AddMonths(1);
                    break;
                case "lastquarter":
                    int currentQuarter = (currentday.Month - 1) / 3 + 1;
                    startDate = new DateTime(currentday.Year, (currentQuarter - 2) * 3 + 1, 1);
                    endDate = startDate.AddMonths(3);
                    break;

                case "currentquarter":
                    int quarter = (currentday.Month - 1) / 3 + 1;
                    startDate = new DateTime(currentday.Year, (quarter - 1) * 3 + 1, 1);
                    endDate = startDate.AddMonths(3);
                    break;

                case "lastyear":
                    startDate = new DateTime(currentday.Year - 1, 1, 1);
                    endDate = new DateTime(currentday.Year, 1, 1);
                    break;

                case "currentyear":
                    startDate = new DateTime(currentday.Year, 1, 1);
                    endDate = new DateTime(currentday.Year + 1, 1, 1);
                    break;

                case "all":
                    startDate = new DateTime(2000, 1, 1);
                    endDate = new DateTime(2100, 12, 31);
                    break;

                default:
                    throw new ArgumentException("Invalid time period");
            }

            return (startDate, endDate);
        }
    }
}
