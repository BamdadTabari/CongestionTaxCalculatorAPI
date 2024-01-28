using Calculator.Shared.Enums;

namespace Calculator.Shared.Infrastructure.Pagination;
public record PaginationFilter
{
    private const int MinPageNumber = 1;
    private const int MaxPageSize = 200;

    protected PaginationFilter(int pageNumber, int pageSize)
    {
        Page = pageNumber > 0 ? pageNumber : MinPageNumber;
        PageSize = pageSize > 0 && pageSize <= MaxPageSize ? pageSize : MaxPageSize;
    }

    protected PaginationFilter()
    {
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
}

public record DefaultPaginationFilter : PaginationFilter
{
    public DefaultPaginationFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public DefaultPaginationFilter() { }
    public string? Keyword { get; set; }
    public int? IntValue { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public DateTime? ExactDateTime { get; set; }
    public decimal? ExactDecimalValue { get; set; }
    public decimal? BigDecimalValue { get; set; }
    public decimal? SmallDecimalValue { get; set; }
    public string? CityName { get; set; }
    public string? CountryName { get; set; }
    public string? MonetaryUnitName { get; set; }
    public SortByEnum? SortByEnum { get; init; }
}

