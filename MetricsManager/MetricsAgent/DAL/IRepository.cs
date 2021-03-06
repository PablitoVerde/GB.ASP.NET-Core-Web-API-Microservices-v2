using System;
using System.Collections.Generic;

namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById (int id);
        IList<T> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime);
        void Create (T item);
        void Update (T item);
        void Delete (T item);
    }
}
