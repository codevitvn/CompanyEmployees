using System.Linq.Expressions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected CompanyEmployeeContext CompanyEmployeeContext;

    public RepositoryBase(CompanyEmployeeContext companyEmployeeContext)
    {
        CompanyEmployeeContext = companyEmployeeContext;
    }

    public IQueryable<T> FindAll(bool trackingChanges) =>
        trackingChanges ? CompanyEmployeeContext.Set<T>() : CompanyEmployeeContext.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackingChanges) =>
        trackingChanges
            ? CompanyEmployeeContext.Set<T>().Where(expression)
            : CompanyEmployeeContext.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity) => CompanyEmployeeContext.Set<T>().Add(entity);

    public void Update(T entity) => CompanyEmployeeContext.Set<T>().Update(entity);

    public void Delete(T entity) => CompanyEmployeeContext.Set<T>().Remove(entity);
}