using System.Collections.Generic;

namespace TheGame.Engine
{
    public static class EnumTraits<TEnum> where TEnum : struct, System.Enum
    {
        public static readonly int Count;

        public static readonly TEnum[] Values;
        public static readonly string[] StringValues;
        public static readonly Dictionary<string, TEnum> DictionaryValues;
        public static readonly int[] IntValues;

        static EnumTraits()
        {
            var values = System.Enum.GetValues(typeof(TEnum));

            Count = values.Length;

            Values = new TEnum[Count];
            IntValues = new int[Count];
            StringValues = new string[Count];
            DictionaryValues = new Dictionary<string, TEnum>();

            for (int i = 0; i < values.Length; ++i)
            {
                Values[i] = (TEnum)values.GetValue(i);
                StringValues[i] = Values[i].ToString();
                IntValues[i] = ((int)(object)Values[i]);
                DictionaryValues.Add(StringValues[i], Values[i]);
            }
        }

        public static bool HasFlag(TEnum where, TEnum value)
        {
            return ((int)(object)where & (int)(object)value) != 0;
        }

        public static bool IsEmpty(TEnum where)
        {
            return ((int)(object)where) == 0;
        }
    }
}