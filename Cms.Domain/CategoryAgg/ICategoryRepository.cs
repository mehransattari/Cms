﻿using Common.Domain.Repository;


namespace Cms.Domain.CategoryAgg;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> DeleteCategory(long categoryId);
}