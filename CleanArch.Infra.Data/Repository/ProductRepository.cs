﻿using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repository;
public class ProductRepository : IProductRepository {

    ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }

    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        var product = await
            _context.Products
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == id);

        return product;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
