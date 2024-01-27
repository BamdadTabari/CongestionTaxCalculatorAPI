using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shared.EntityFramework.Extensions;
public static class CalculatedTaxQueryableExtension
{
    public static IQueryable<CalculatedTax> ApplyFilter(this IQueryable<CalculatedTax> query, DefaultPaginationFilter filter)
    {
        // Filter By User Id
        if (filter.IntValue.HasValue && filter.IntValue != 0)
            query = query.Where(x => x.Id == filter.IntValue);

        // Filter By ExactTaxAmount
        if (filter.ExactDecimalValue.HasValue)
            query = query.Where(x => x.AmountOfDay == filter.ExactDecimalValue);

        // Filter By Range of TaxAmount
        if (filter.BigDecimalValue.HasValue && filter.SmallDecimalValue.HasValue)
            query = query.Where(x => x.AmountOfDay >= filter.SmallDecimalValue && x.AmountOfDay <= filter.BigDecimalValue);

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

        // Filter By Date Time 
        if (filter.ExactTime != null)
            query = query.Where(x => x.Date == filter.ExactTime);

        // Filter By Start Date Time 
        if (filter.StartTime != null)
            query = query.Where(x => x.Date >= filter.StartTime);

        // Filter By End Date Time 
        if (filter.StartTime != null)
            query = query.Where(x => x.Date <= filter.EndTime);

        return query;
    }

    public static IQueryable<CalculatedTax> ApplySort(this IQueryable<CalculatedTax> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
