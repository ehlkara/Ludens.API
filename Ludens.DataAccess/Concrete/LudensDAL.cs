using Ludens.Core.Context;
using Ludens.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Ludens.DataAccess.Concrete
{
    public class LudensDAL : ILudensDAL
    {
        private readonly LudensDbContext _context;

        public LudensDAL(LudensDbContext context)
        {
            _context = context;
        }

        public async Task<double> CalculateDailyProccess(string fundCode)
        {
            var fundCodeToId = await _context.Funds.FirstOrDefaultAsync(x => x.Code == fundCode);
            var prices = _context.FundPrices.Where(p => p.FundId == fundCodeToId.Id).OrderByDescending(y => y.Date)
                .Take(2).ToList();
            if(prices.Count != 2) return 0.0;

            var currentClose = prices.First().Close;
            var previousClose = prices.Last().Close;

            return (currentClose - previousClose) / previousClose;
        }

        public async Task<double> CalculateMonthlyProccess(string fundCode)
        {
            var fundCodeToId = await _context.Funds.FirstOrDefaultAsync(x => x.Code == fundCode);
            var prices = _context.FundPrices.Where(p => p.FundId == fundCodeToId.Id && p.Date >= DateTime.Today.AddMonths(-1)).OrderBy(p => p.Date).ToList();
            if (prices.Count < 2) return 0.0;

            var currentClose = prices.First().Close;
            var previousClose = prices.Last().Close;

            return (currentClose - previousClose) / previousClose;
        }

        public async Task<double> CalculateQuarterlyOfMonthProccess(string fundCode)
        {
            var fundCodeToId = await _context.Funds.FirstOrDefaultAsync(x => x.Code == fundCode);
            var prices = _context.FundPrices.Where(p => p.FundId == fundCodeToId.Id && p.Date >= DateTime.Today.AddMonths(-3)).OrderBy(p => p.Date).ToList();
            if (prices.Count < 2) return 0.0;

            var currentClose = prices.First().Close;
            var previousClose = prices.Last().Close;

            return (currentClose - previousClose) / previousClose;
        }

        public async Task<double> CalculateWeeklyProccess(string fundCode)
        {
            var fundCodeToId = await _context.Funds.FirstOrDefaultAsync(x => x.Code == fundCode);
            var prices = _context.FundPrices.Where(p => p.FundId == fundCodeToId.Id).OrderByDescending(y => y.Date)
                .Take(8).ToList();
            if (prices.Count != 8) return 0.0;

            var currentClose = prices.First().Close;
            var previousClose = prices.Last().Close;

            return (currentClose - previousClose) / previousClose;
        }
    }
}
