using MVC___31._05._2023.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace MVC___31._05._2023.Services
{
    public class SubjectsService
    {
        public ApplicationDbContext dbContext2;
        public SubjectsService(ApplicationDbContext dbContext2)
        {
            this.dbContext2 = dbContext2;
        }
        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await dbContext2.Subjects.ToListAsync();
        }
        public async Task CreateAsync(Subject newSubject)
        {
            await dbContext2.Subjects.AddAsync(newSubject);
            await dbContext2.SaveChangesAsync();
        }
        public async Task<Subject> GetByIdAsync(int id)
        {
            return await dbContext2.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Subject> UpdateAsync(int id, Subject updatedSubject)
        {
            dbContext2.Subjects.Update(updatedSubject);
            await dbContext2.SaveChangesAsync();
            return updatedSubject;
        }
        public async Task DeleteAsync(int id)
        {
            var subjectToDelete = await dbContext2.Subjects.FirstOrDefaultAsync(s => s.Id == id);
            dbContext2.Subjects.Remove(subjectToDelete);
            await dbContext2.SaveChangesAsync();
        }



    }
}
