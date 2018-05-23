using NSubstitute;
using System.Data.Entity;
using System.Linq;

namespace MockingTools
{
    public class MockSet<T> where T : class
    {
        public DbSet<T> Create(IQueryable<T> mockData)
        {
            var mockSet = Substitute.For<DbSet<T>, IQueryable<T>>();

            ((IQueryable<T>)mockSet).Provider.Returns(mockData.Provider);
            ((IQueryable<T>)mockSet).Expression.Returns(mockData.Expression);
            ((IQueryable<T>)mockSet).ElementType.Returns(mockData.ElementType);
            ((IQueryable<T>)mockSet).GetEnumerator().Returns(mockData.GetEnumerator());
            return mockSet;
        }
    }
}
