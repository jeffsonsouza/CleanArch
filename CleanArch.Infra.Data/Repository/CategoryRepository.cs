using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repository;
public class CategoryRepository : ICategoryRepository {
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    readonly ApplicationDbContext _context;

    public async Task<Category> CreateAsync(Category category)
    {
        try {
            _context.Add(category);
            await _context.SaveChangesAsync();

            return category;

        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<Category> GetByIdAsync(int? id)
    {
        try {
            if (id == null)
                throw new Exception("Id não pode ser nulo.");

            var category = await _context.Categories.FindAsync(id);

            return category;
        }
        catch {
            throw;
        }
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        try {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        catch {
            throw;
        }
    }

    public async Task<Category> RemoveAsync(Category category)
    {
        try {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch {
            throw;
        }
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        try {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch {
            throw;
        }
    }
}
