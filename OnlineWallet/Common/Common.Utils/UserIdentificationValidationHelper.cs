using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils
{
    public static class UserIdentificationValidationHelper
    {
        public static bool MaturityValidateIdentificationNumber(string userIdentificationNumber)
        {
            DateTime date = GetDateFromUserIdentificationNumber(userIdentificationNumber.Trim());
            var date18 = new DateTime((date.Year + 18), date.Month, date.Day);
            DateTime dateNow = DateTime.Now;
            
            if(dateNow >= date18)
            {
                return true;
            }
            return false;
        }
        private static DateTime GetDateFromUserIdentificationNumber(string userIdentificationNumber)
        {
            string day = userIdentificationNumber.Substring(0, 2);
            string month = userIdentificationNumber.Substring(2, 2);
            string year = userIdentificationNumber.Substring(4, 3);

            int dayInt = int.Parse(day);
            int monthInt = int.Parse(month);
            int yearInt = int.Parse(year);
            if (yearInt >= 900) yearInt += 1000;
            else if (yearInt <= DateTime.Now.Year) yearInt += 2000;
            else throw new ArgumentOutOfRangeException("nije unesen dobar jmbg!");
            var date = new DateTime(yearInt, monthInt, dayInt);
            return date;
        }

        public static bool MaturityValidateIdentificationNumberTest(string userIdentificationNumber, DateTime dateToCount)
        {
            DateTime date = GetDateFromUserIdentificationNumberTest(userIdentificationNumber.Trim(), dateToCount);
            var date18 = new DateTime(date.Year, date.Month, date.Day).AddYears(18);
            //DateTime dateNow = DateTime.Now;

            if (dateToCount >= date18)
            {
                return true;
            }
            return false;
        }
        public static DateTime GetDateFromUserIdentificationNumberTest(string userIdentificationNumber, DateTime dateToCount)
        {
            string day = userIdentificationNumber.Substring(0, 2);
            string month = userIdentificationNumber.Substring(2, 2);
            string year = userIdentificationNumber.Substring(4, 3);

            int dayInt = int.Parse(day);
            int monthInt = int.Parse(month);
            int yearInt = int.Parse(year);
            if (yearInt >= 900) yearInt += 1000;
            else if (yearInt <= dateToCount.Year) yearInt += 2000;
            else throw new ArgumentOutOfRangeException("nije unesen dobar jmbg!");

            var date = new DateTime(yearInt, monthInt, dayInt);

            return date;
        }
    }
}
