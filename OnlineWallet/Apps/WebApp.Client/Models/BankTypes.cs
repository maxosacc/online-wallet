using Core.Domain.Entities.Enums;
using System;

namespace WebApp.Client.Models
{
    public class BankTypes
    {
    }
    public static class BankTypesTypeEnumHelper
    {
        public static string ConvertVaultTypeEnumToString(BankType bankType)
        {
            switch (bankType)
            {
                case BankType.XomaBank:
                    return "Xoma Banka";

                default:
                    throw new Exception($"{bankType} ne postoji kao tip!");
            }
        }
    }
}
