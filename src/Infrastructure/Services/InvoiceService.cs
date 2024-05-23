namespace Infrastructure.Services
{
    public interface IInvoiceService
    {
        Task<Core.Response<double>> TotalByUnitTimeAsync(string timePeriod);
        Task<Core.Response<Dictionary<string, Dictionary<int, double>>>> CompareTotalAsync(string timePeriod);
    }

    public class CInvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepository;

        public CInvoiceService(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Core.Response<double>> TotalByUnitTimeAsync(string timePeriod)
        {
            DateTime currentday = DateTime.Today;
            DateTime startDate, endDate;

            if (string.IsNullOrWhiteSpace(timePeriod))
            {
                timePeriod = "currentday"; 
            }

            switch (timePeriod.ToLower())
            {
                case "lastday":
                    startDate = currentday.AddDays(-1);
                    endDate = currentday;
                    break;

                case "currentday":
                    startDate = currentday;
                    endDate = currentday.AddDays(1);
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
                    startDate = currentday;
                    endDate = currentday.AddDays(1);
                    break;
            }

            return ResponseHelper.CreateSuccessResponse(await GetTotalForDateRangeAsync(startDate, endDate));
        }

        public async Task<Core.Response<Dictionary<string, Dictionary<int, double>>>> CompareTotalAsync(string timePeriod)
        {
            DateTime currentday = DateTime.Today;

            if (string.IsNullOrWhiteSpace(timePeriod))
            {
                timePeriod = "day"; // Default to "currentday" if timePeriod is null or empty
            }

            Dictionary<string, Dictionary<int, double>> totals = new Dictionary<string, Dictionary<int, double>>()
            {
                { "last", new Dictionary<int, double>() },
                { "current", new Dictionary<int, double>() }
            };

            switch (timePeriod.ToLower())
            {
                case "day":
                    DateTime startOfLastDay = currentday.AddDays(-1);
                    DateTime startOfCurrenDay = currentday;

                    DateTime endOfLastDay = startOfLastDay.AddDays(1);
                    DateTime endOfCurrentDay = startOfCurrenDay.AddDays(1);
                    double totalLastDay = await GetTotalForDateRangeAsync(startOfLastDay, endOfLastDay);
                    double totalCurrentDay = await GetTotalForDateRangeAsync(startOfCurrenDay, endOfCurrentDay);
                    totals["last"].Add(1, totalLastDay);
                    totals["current"].Add(1, totalCurrentDay);

                    break;

                case "week":
                    DateTime startOfLastWeek = currentday.AddDays(-(int)currentday.DayOfWeek - 7);
                    DateTime startOfCurrentWeek = currentday.AddDays(-(int)currentday.DayOfWeek);

                    for (int i = 0; i < 7; i++)
                    {
                        DateTime dateLastWeek = startOfLastWeek.AddDays(i);
                        DateTime dateCurrentWeek = startOfCurrentWeek.AddDays(i);
                        double totalLastWeek = await GetTotalForDateAsync(dateLastWeek);
                        double totalCurrentWeek = await GetTotalForDateAsync(dateCurrentWeek);
                        totals["last"].Add(i + 1, totalLastWeek);
                        totals["current"].Add(i + 1, totalCurrentWeek);
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
                        double totalLastMonth = await GetTotalForDateAsync(dateLastMonth);
                        totals["last"].Add(i + 1, totalLastMonth);
                    }

                    for (int i = 0; i < daysInCurrentMonth; i++)
                    {
                        DateTime dateCurrentMonth = startOfCurrentMonth.AddDays(i);
                        double totalCurrentMonth = await GetTotalForDateAsync(dateCurrentMonth);
                        totals["current"].Add(i + 1, totalCurrentMonth);
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
                        double totalLastQuarter = await GetTotalForDateRangeAsync(startOfMonthInLastQuarter, endOfMonthInLastQuarter);
                        totals["last"].Add(i + 1, totalLastQuarter);

                        DateTime startOfMonthInCurrentQuarter = startOfCurrentQuarter.AddMonths(i);
                        DateTime endOfMonthInCurrentQuarter = startOfMonthInCurrentQuarter.AddMonths(1);
                        double totalCurrentQuarter = await GetTotalForDateRangeAsync(startOfMonthInCurrentQuarter, endOfMonthInCurrentQuarter);
                        totals["current"].Add(i + 1, totalCurrentQuarter);
                    }
                    break;

                case "year":
                    DateTime startOfLastYear = new DateTime(currentday.Year - 1, 1, 1);
                    DateTime startOfCurrentYear = new DateTime(currentday.Year, 1, 1);

                    for (int i = 0; i < 12; i++)
                    {
                        DateTime startOfMonthInLastYear = startOfLastYear.AddMonths(i);
                        DateTime endOfMonthInLastYear = startOfMonthInLastYear.AddMonths(1);
                        double totalLastYear = await GetTotalForDateRangeAsync(startOfMonthInLastYear, endOfMonthInLastYear);
                        totals["last"].Add(i + 1, totalLastYear);

                        DateTime startOfMonthInCurrentYear = startOfCurrentYear.AddMonths(i);
                        DateTime endOfMonthInCurrentYear = startOfMonthInCurrentYear.AddMonths(1);
                        double totalCurrentYear = await GetTotalForDateRangeAsync(startOfMonthInCurrentYear, endOfMonthInCurrentYear);
                        totals["current"].Add(i + 1, totalCurrentYear);
                    }
                    break;

                default:
                    return ResponseHelper.CreateNotFoundResponse<Dictionary<string, Dictionary<int, double>>>("Invalid period specified");
            }

            return ResponseHelper.CreateSuccessResponse(totals);
        }

        private async Task<double> GetTotalForDateAsync(DateTime date)
        {
            DateTime startDate = date;
            DateTime endDate = date.AddDays(1);

            return await _invoiceRepository.Query()
                .Where(i => i.CreatedAt >= startDate && i.CreatedAt < endDate)
                .SumAsync(i => i.Total);
        }

        private async Task<double> GetTotalForDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _invoiceRepository.Query()
                .Where(i => i.CreatedAt >= startDate && i.CreatedAt < endDate)
                .SumAsync(i => i.Total);
        }
    }

}
