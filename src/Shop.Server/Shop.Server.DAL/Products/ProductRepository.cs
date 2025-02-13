﻿using Microsoft.EntityFrameworkCore;
using Shop.Server.DAL.Core;
using Shop.Shared.Core.Pagination;

namespace Shop.Server.DAL.Products;

public sealed class ProductRepository(ApplicationDbContext dbContext)
    : Repository<Product, int>(dbContext), IProductRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<PagedList<Product>> GetAsync(PagingQuery? paging)
    {
        var query = _dbContext.Set<Product>()
            .OrderBy(product => product.Name);

        if (paging is { PageNumber: > 0, PageSize: > 0 })
            return await query.ToPagedListAsync(paging);

        return PagedList<Product>.CreateSinglePage(await query.ToListAsync());
    }
}