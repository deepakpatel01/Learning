using Learning.BusinessLogic.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using Learning.Models;

namespace Learning.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private LearningContext _ctx;

        public StudentRepository(LearningContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Student newEntity)
        {
            _ctx.Students.Add(newEntity);
        }

        public IQueryable<Student> GetAll(Func<Student, bool> predicate = null)
        {
            return _ctx.Students;
        }

        public Student FindFirst(Expression<Func<Student, bool>> predicate)
        {
            return _ctx.Students.Where(predicate).FirstOrDefault();
        }

        public Student Get(int id)
        {
            return _ctx.Students.Find(id);
        }

        public void Remove(Student entity)
        {
            _ctx.Students.Remove(entity);
        }

        public Student GetStudentByUserName(string username)
        {
            return _ctx.Students.Where(s => s.UserName == username).FirstOrDefault();
        }
    }
}
