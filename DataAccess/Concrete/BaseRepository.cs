using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly MeetingDbContext _meetingDbContext;
        private DbSet<T> _table;

        public BaseRepository(MeetingDbContext meetingDbContext)
        {
            _meetingDbContext = meetingDbContext;
        }
        public bool Add(T entity)
        {
            _table.Add(entity);
            return Save() > 0;
            
        }

        public bool AddRange(List<T> entities)
        {
            _table.AddRange(entities);
            return Save() > 0;
        }

        public bool Delete(T entity)
        {
            entity.GetType().GetProperty("Status").SetValue(entity, Status.Deleted);
            return Update(entity);
            
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetByID(int id)
        {
            return _table.Find(id);
        }

        public int Save()
        {
            return _meetingDbContext.SaveChanges();
        }

        public bool Update(T entity)
        {
            _meetingDbContext.Entry<T>(entity).State = EntityState.Modified;
            return Save() > 0;  
        }
    }
}
