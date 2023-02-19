using Ludens.Shared.Dtos;

namespace Ludens.BusinessLogic.Abstract
{
    public interface ILudensBLL
    {
        Task<Response<double>> CalculateDailyProccessAsync(string fundCode);
        Task<Response<double>> CalculateWeeklyProccessAsync(string fundCode);
        Task<Response<double>> CalculateMonthlyProccessAsync(string fundCode);
        Task<Response<double>> CalculateQuarterlyOfMonthProccessAsync(string fundCode);
    }
}
