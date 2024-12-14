using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ILecturesRepository : IRepository<Lectures>
    {
        List<Lectures> GetAll(string? includeProp = null);
        Lectures? GetOne(int LectureId);
        void Add(Lectures lecture);
        void Edit(Lectures lecture);
        void Delete(Lectures lecture);
        void Commit();
    }
}
