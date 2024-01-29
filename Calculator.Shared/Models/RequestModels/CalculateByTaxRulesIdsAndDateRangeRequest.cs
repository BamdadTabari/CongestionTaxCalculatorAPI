namespace Calculator.Shared.Models.RequestModels;

public record CalculateByTaxRulesIdsAndDateRangeRequest(List<int> BaseRuleIds,
                                                    DateTime Date,
                                                    List<TimesAndCountofVehiclesAtThoseTime> TimesAndCountOfVehicles);