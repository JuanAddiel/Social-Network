﻿using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Infrastructured.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructured.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public virtual async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
            //todo: hacer listados
            //return await _context.Set<T>().Skip(1).Take(1).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllInclude(List<string> properties, int skip, int take)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task Update(T entity, int id)
        {
            T entityToUpdate = await _context.Set<T>().FindAsync(id);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
