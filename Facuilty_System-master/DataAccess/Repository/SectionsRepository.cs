using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SectionsRepository : Repository<Sections>, ISectionsRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SectionsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Sections section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }
            dbContext.Sections.Add(section);
        }

        public List<Sections> GetAll(string? includeProp = null)
        {
            IQueryable<Sections> query = dbContext.Sections;

            if (!string.IsNullOrEmpty(includeProp))
            {
                query = query.Include(includeProp);
            }

            return query.ToList();
        }

        public Sections? GetOne(int SectionId)
        {
            return dbContext.Sections.FirstOrDefault(s => s.SectionsID == SectionId);
        }

        public void Edit(Sections section)
        {
            var existingSection = dbContext.Sections.FirstOrDefault(s => s.SectionsID == section.SectionsID);
            if (existingSection != null)
            {
                dbContext.Entry(existingSection).CurrentValues.SetValues(section);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Sections section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            dbContext.Sections.Remove(section);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
