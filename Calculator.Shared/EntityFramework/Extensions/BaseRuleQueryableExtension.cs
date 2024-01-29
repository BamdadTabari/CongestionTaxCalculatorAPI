using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shared.EntityFramework.Extensions;
public static class BaseRuleQueryableExtension
{
    public static IQueryable<BaseRule> ApplyFilter(this IQueryable<BaseRule> query, BaseRulePaginationFilter filter)
    {
        // Filter By User Id
        if (filter.IntValue.HasValue && filter.IntValue != 0)
            query = query.Where(x => x.Id == filter.IntValue);

        // Filter By Vehicle Type
        if (filter.Vehicle.HasValue)
            query = query.Where(x => x.Vehicle == filter.Vehicle);

        // Filter By DayOfWeek
        if (filter.DayOfWeek.HasValue)
            query = query.Where(x => x.DayOfWeek >= filter.DayOfWeek);

        // Filter By City Name
        if (!string.IsNullOrEmpty(filter.City))
            query = query.Where(x => x.City.Equals(filter.City, StringComparison.CurrentCultureIgnoreCase));

        // Filter By Country Name
        if (!string.IsNullOrEmpty(filter.Country))
            query = query.Where(x => x.Country.Equals(filter.Country, StringComparison.CurrentCultureIgnoreCase));

        // Filter By DayOfWeek
        if (filter.DayOfWeek.HasValue)
            query = query.Where(x => x.DayOfWeek >= filter.DayOfWeek);


        // Filter By Keyword
        if (!string.IsNullOrEmpty(filter.Keyword))
            query = query.Where(x=> x.City.Equals(filter.Keyword, StringComparison.CurrentCultureIgnoreCase)
            || x.Country.Equals(filter.Keyword, StringComparison.CurrentCultureIgnoreCase));

        return query;
    }

    public static IQueryable<BaseRule> ApplySort(this IQueryable<BaseRule> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }

}
