namespace Calculator.Shared.Models.RequestModels;
public record CalculateByTaxRulesIdsAndDateRequest(List<int> BaseRuleIds,
                                                    DateTime Date,
                                                    List<TimesAndCountofVehiclesAtThoseTime> TimesAndCountOfVehicles);
public record TimesAndCountofVehiclesAtThoseTime(int CountOfVehicles, TimeOnly FromTime, TimeOnly ToTime);
