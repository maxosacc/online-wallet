using System;

namespace Common.Utils
{
    public static class EnumMappers
    {
        public static string MapBankTypes(int bank)
        {
            string result = bank switch
            {
                0 => "Xoma bank",
                _ => throw new ArgumentException("Status not defined for this id")
            };
            return result;
        }

        public static string MapTransactionTypes(int bank)
        {
            string result = bank switch
            {
                0 => "Uplata",
                1 => "Isplata",
                _ => throw new ArgumentException("Status not defined for this id")
            };
            return result;
        }
    }
}
