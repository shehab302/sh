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
    public class LecturesRepository : Repository<Lectures>, ILecturesRepository
    {
        private readonly ApplicationDbContext dbContext;
        public LecturesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Lectures> GetAll(string? includeProp = null)
        {
            IQueryable<Lectures> query = dbContext.Lectures;

            if (!string.IsNullOrEmpty(includeProp))
            {
                query = query.Include(includeProp);
            }

            return query.ToList();
        }

        public Lectures? GetOne(int lectureId)
        {
            return dbContext.Lectures
                .Include(l => l.Course)
                .FirstOrDefault(l => l.LecturesID == lectureId);
        }

        public void Add(Lectures lecture)
        {
            if (lecture == null)
            {
                throw new ArgumentNullException(nameof(lecture));
            }

            dbContext.Lectures.Add(lecture);
        }

        public void Edit(Lectures lecture)
        {
            if (lecture == null)
            {
                throw new ArgumentNullException(nameof(lecture));
            }

            var existingLecture = dbContext.Lectures.FirstOrDefault(l => l.LecturesID == lecture.LecturesID);
            if (existingLecture != null)
            {
                dbContext.Entry(existingLecture).CurrentValues.SetValues(lecture);
            }
            else
            {
                throw new ArgumentException("Lecture not found for update");
            }
        }

        public void Delete(Lectures lecture)
        {
            if (lecture == null)
            {
                throw new ArgumentNullException(nameof(lecture));
            }

            dbContext.Lectures.Remove(lecture);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}