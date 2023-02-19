namespace Ludens.DataAccess.Abstract
{
    public interface ILudensDAL
    {
        Task<double> CalculateDailyProccess(string fundCode);
        Task<double> CalculateWeeklyProccess(string fundCode);
        Task<double> CalculateMonthlyProccess(string fundCode);
        Task<double> CalculateQuarterlyOfMonthProccess(string fundCode);
    }
}
