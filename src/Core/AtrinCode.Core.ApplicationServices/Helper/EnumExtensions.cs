using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AtrinCode.Core.ApplicationServices.Helper
{
    public static class EnumExtensions
    {
        public static IEnumerable<Item> GetItems<TEnum>(Type enumType)
        {
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();
            IEnumerable<Item> items = from value in values
                                      select new Item
                                      {
                                          Text = GetEnumDiscription(value),
                                          Value = Convert.ToByte(value)
                                      };
            return items;

        }

        private static string GetEnumDiscription<TEnum>(TEnum Value )
        {
            var fieldInfo = Value.GetType().GetField(Value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : Value.ToString();
        }
    }
}
