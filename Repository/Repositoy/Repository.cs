using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositoy
{
    public abstract class Repository<TEntity, TContext>
        where TEntity : Entity
        where TContext : DbContext, new()
    {
        protected TContext Context { get; set; }
        public Repository()
        {
            this.Context = new TContext();
        }

        public async Task<bool> Add(TEntity entity)
        {
            try
            {
                await this.Context.AddAsync(entity);
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var current = this.Context.Set<TEntity>().Where(_ => _.Id.Equals(Id)).FirstOrDefault();
                this.Context.Remove(current);
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public async Task<TEntity> Get(Guid Id)
        {
            try
            {
                var current = this.Context.Set<TEntity>().Where(_ => _.Id.Equals(Id)).FirstOrDefault();
                return current;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await Context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(TEntity employee)
        {
            try
            {
                var current = this.Context.Set<TEntity>().Where(_ => _.Id.Equals(employee.Id)).FirstOrDefault();
                this.Context.Entry<TEntity>(current).CurrentValues.SetValues(employee);
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
