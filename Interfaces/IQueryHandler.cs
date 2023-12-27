using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MicroservicesWithCQRSDesignPattern.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
