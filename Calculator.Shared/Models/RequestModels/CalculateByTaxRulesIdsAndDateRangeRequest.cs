namespace Calculator.Shared.Models.RequestModels;

public record CalculateByTaxRulesIdsAndDateRangeRequest(List<int> BaseRuleIds,
                                                    DateTime FromDate,
                                                    DateTime ToDate,
                                                    List<TimesAndCountofVehiclesAtThoseTime> TimesAndCountOfVehicles);