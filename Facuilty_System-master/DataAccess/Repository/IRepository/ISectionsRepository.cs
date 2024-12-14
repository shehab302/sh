using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ISectionsRepository : IRepository<Sections>
    {
        List<Sections> GetAll(string? includeProp = null);
        Sections? GetOne(int SectionId);
        void Add(Sections section);
        void Edit(Sections section);
        void Delete(Sections section);
        void Commit();
    }
}
