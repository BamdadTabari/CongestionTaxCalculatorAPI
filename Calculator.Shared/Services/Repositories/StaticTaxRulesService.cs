using Calculator.Shared.Enums;
using Calculator.Shared.Services.Interfaces;

namespace Calculator.Shared.Services.Repositories
{
    public class StaticTaxRulesService : IStaticTaxRulesService
    {
        public int CalculateTollFeeBasedOnTimeForGothenburg(DateTime date)
        {
            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute >= 0 && minute <= 29 ||
                hour == 6 && minute >= 30 && minute <= 59 ||
                hour == 7 && minute >= 0 && minute <= 59 ||
                hour == 8 && minute >= 0 && minute <= 29 ||
                hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59 ||
                hour == 15 && minute >= 0 && minute <= 29 ||
                hour == 15 && minute >= 30 && minute <= 59 ||
                hour == 16 && minute >= 0 && minute <= 59 ||
                hour == 17 && minute >= 0 && minute <= 59 ||
                hour == 18 && minute >= 0 && minute <= 29 ||
                hour >= 18 && hour <= 5 && minute >= 30 && minute <= 59)
            {
                return 8;
            }
            else if (hour == 7 && minute >= 0 && minute <= 59 ||
                     hour == 15 && minute >= 0 && minute <= 59 ||
                     hour == 16 && minute >= 0 && minute <= 59 ||
                     hour == 17 && minute >= 0 && minute <= 59 ||
                     hour == 18 && minute >= 0 && minute <= 29 ||
                     hour >= 18 && hour <= 5 && minute >= 30 && minute <= 59)
            {
                return 13;
            }
            else if (hour == 7 && minute >= 0 && minute <= 59 ||
                     hour == 15 && minute >= 0 && minute <= 59 ||
                     hour == 16 && minute >= 0 && minute <= 59 ||
                     hour == 17 && minute >= 0 && minute <= 59 ||
                     hour == 18 && minute >= 0 && minute <= 29 ||
                     hour >= 18 && hour <= 5 && minute >= 30 && minute <= 59)
            {
                return 18;
            }
            else
            {
                return 0;
            }
        }

        public int GetTollFee(DateTime date, VehicleType vehicle)
        {
            if (IsItTollFreeDay(date) || IsTollFreeVehicle(vehicle)) return 0;

            return CalculateTollFeeBasedOnTimeForGothenburg(date);
        }

        public bool IsItTollFreeDay(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsTollFreeVehicle(VehicleType vehicleType)
        {
            var isFree = vehicleType == VehicleType.Motorbike || vehicleType == VehicleType.Bus ||
                   vehicleType == VehicleType.Diplomat || vehicleType == VehicleType.Military ||
                   vehicleType == VehicleType.Foreign || vehicleType == VehicleType.Emergency;
            if (isFree)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
