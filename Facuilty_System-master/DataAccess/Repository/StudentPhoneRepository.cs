﻿using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StudentPhoneRepository : Repository<StudentPhone>, IStudentPhoneRepository
    {
        private readonly ApplicationDbContext dbContext;

        public StudentPhoneRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
