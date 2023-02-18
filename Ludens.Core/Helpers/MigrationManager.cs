using Abp.UI;
using Ludens.Core.Context;
using Ludens.Models.Entities.Ludens;
using Ludens.Models.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ludens.Core.Helpers
{
    public static class MigrationManager
    {
        public static async Task<IHost> MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var ludensContext = scope.ServiceProvider.GetRequiredService<LudensDbContext>())
                {
                    try
                    {
                        ludensContext.Database.Migrate();

                        if (ludensContext.Funds.Count() == 0)
                        {
                            await ludensContext.Funds.AddRangeAsync(
                                new List<Funds>()
                                {
                                    new Funds() {Id = "12306CD3-9EE2-4434-B7AD-7AD5F0B1AEB9", Code="AAK", Name="Ata Portföy Çoklu Varlık Değişken Fon"},
                                    new Funds() {Id = "BD6D645E-AD1A-46C3-858A-4DBC8D682D4E", Code="MAC", Name="Marmara Capıtal Portföy Hisse Senedi (TL) Fonu (Hisse Senedi Yoğun Fon)"},
                                    new Funds() {Id = "847D4450-6FE9-43F8-835D-591BA7560256", Code="TCD", Name="Tacirler Portföy Değışken Fon"}
                                });
                            await ludensContext.SaveChangesAsync();
                        }

                        //if(ludensContext.FundPrices.Count() == 0)
                        //{
                        //    await ludensContext.FundPrices.AddRangeAsync(new List<FundPrices>()
                        //    {
                        //        new FundPrices(){Id=""},
                        //        //new FundPrices(){Id="562C56A7-EE10-4529-9714-77C34A9B313E",FundId="12306CD3-9EE2-4434-B7AD-7AD5F0B1AEB9",Date= new DateTime(2023, 02, 09, 00, 0, 0, 000), Close="9,202002" },
                        //    });
                        //    await ludensContext.SaveChangesAsync();
                        //}

                    }
                    catch (Exception ex)
                    {
                        throw new UserFriendlyException((int)ErrorCodes.NotWorkMigrate, ErrorMessages.NotWorkedMigrate, ex.Message);
                    }
                }
            }
            return host;
        }
    }
}
