using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace UnitTestProject
{
    public class BaseTest
    {

        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class, new()
        {
            var queryable = sourceList.AsQueryable();
            var mockSet = new Mock<DbSet<T>>() { CallBase = true };
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockSet.Object;
        }
    }
}
