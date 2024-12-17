namespace Udemy.Web.Models.Repository
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
