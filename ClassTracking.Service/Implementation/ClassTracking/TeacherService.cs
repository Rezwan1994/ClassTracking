﻿using ClassTracking.Domain.Entities;
using ClassTracking.Repository.Implementation;
using ClassTracking.Repository.Interface;
using ClassTracking.Repository.UnitOfWork;
using ClassTracking.Service.Interface.ClassTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Service.Implementation.ClassTracking
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teacherRepository = unitOfWork.Repository<Teacher>();
        }
        public IQueryable<Teacher> GetTeacherByTeacherId(Guid teacherId)
        {
            return _teacherRepository.Query(string.Format("select * from teachers where teacherid='{0}'", teacherId));
        }
    }
}
