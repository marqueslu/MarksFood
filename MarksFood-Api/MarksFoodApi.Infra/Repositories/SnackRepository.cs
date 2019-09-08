using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarksFoodApi.Infra.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly MarksFoodApiContext _context;

        public SnackRepository(MarksFoodApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Snack> GetAllSnacks()
        {
            return _context.Snacks.ToList();
        }

        public Snack GetById(Guid id)
        {
            return _context.Snacks.Find(id);
        }

        public void Save(Snack snack)
        {
            _context.Snacks.Add(snack);
            _context.SaveChanges();
        }

        public Snack SnackExists(string name)
        {
            return _context.Snacks.Where(x => x.Name == name).FirstOrDefault();
        }

        public void Update(Snack snack)
        {
            _context.Entry(snack).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
