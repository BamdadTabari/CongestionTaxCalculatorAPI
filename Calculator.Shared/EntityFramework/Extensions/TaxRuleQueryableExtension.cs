using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;

namespace Calculator.Shared.EntityFramework.Extensions;
public static class TaxRuleQueryableExtension
{
    public static IQueryable<TaxRule> ApplyFilter(this IQueryable<TaxRule> query, DefaultPaginationFilter filter)
    {
        // Filter By User Id
        if (filter.IntValue.HasValue && filter.IntValue != 0)
            query = query.Where(x => x.Id == filter.IntValue);

        // Filter By ExactTaxAmount
        if (filter.ExactDecimalValue.HasValue)
            query = query.Where(x => x.TaxAmount == filter.ExactDecimalValue);

        // Filter By Range of TaxAmount
        if (filter.BigDecimalValue.HasValue && filter.SmallDecimalValue.HasValue)
            query = query.Where(x => x.TaxAmount >= filter.SmallDecimalValue && x.TaxAmount <= filter.BigDecimalValue);

        // Filter By City Name
        if (!string.IsNullOrEmpty(filter.CityName))
            query = query.Where(x => x.City.Equals(filter.CityName, StringComparison.CurrentCultureIgnoreCase));

        // Filter By Country Name
        if (!string.IsNullOrEmpty(filter.CountryName))
            query = query.Where(x => x.Country.Equals(filter.CountryName, StringComparison.CurrentCultureIgnoreCase));

        // Filter By MonetaryUnit Name
        if (!string.IsNullOrEmpty(filter.MonetaryUnitName))
            query = query.Where(x => x.MonetaryUnit.Equals(filter.MonetaryUnitName, StringComparison.CurrentCultureIgnoreCase));

        // Filter By Keyword
        if (!string.IsNullOrEmpty(filter.Keyword))
            query = query.Where(x => x.MonetaryUnit.Equals(filter.Keyword, StringComparison.CurrentCultureIgnoreCase)
            || x.City.Equals(filter.Keyword, StringComparison.CurrentCultureIgnoreCase)
            || x.Country.Equals(filter.Keyword, StringComparison.CurrentCultureIgnoreCase));

        // Filter By Start Date Time 
        if (filter.StartTime != null)
            query = query.Where(x => x.StartTime >= filter.StartTime);

        // Filter By End Date Time 
        if (filter.StartTime != null)
            query = query.Where(x => x.EndTime <= filter.EndTime);

        return query;
    }

    public static IQueryable<TaxRule> ApplySort(this IQueryable<TaxRule> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
