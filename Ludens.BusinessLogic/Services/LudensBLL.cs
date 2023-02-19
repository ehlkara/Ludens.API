using Ludens.BusinessLogic.Abstract;
using Ludens.DataAccess.Abstract;
using Ludens.Shared.Dtos;

namespace Ludens.BusinessLogic.Services
{
    public class LudensBLL : ILudensBLL
    {
        private readonly ILudensDAL _ludensDAL;

        public LudensBLL(ILudensDAL ludensDAL)
        {
            _ludensDAL = ludensDAL;
        }

        public async Task<Response<double>> CalculateDailyProccessAsync(string fundCode)
        {
            var process = await _ludensDAL.CalculateDailyProccess(fundCode);

            return Response<double>.Success(process, 200);
        }

        public async Task<Response<double>> CalculateMonthlyProccessAsync(string fundCode)
        {
            var process = await _ludensDAL.CalculateMonthlyProccess(fundCode);

            return Response<double>.Success(process, 200);
        }

        public async Task<Response<double>> CalculateQuarterlyOfMonthProccessAsync(string fundCode)
        {
            var process = await _ludensDAL.CalculateQuarterlyOfMonthProccess(fundCode);

            return Response<double>.Success(process, 200);
        }

        public async Task<Response<double>> CalculateWeeklyProccessAsync(string fundCode)
        {
            var process = await _ludensDAL.CalculateWeeklyProccess(fundCode);

            return Response<double>.Success(process, 200);
        }
    }
}
