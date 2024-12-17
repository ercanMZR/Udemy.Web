
namespace Udemy.Web.Models.Repository


{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
    {
        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}
