using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using HB_Mars.Helper.Models;

namespace HB_Mars.Helper.Helper
{
    public static class EnumExtensions
    {
        public static List<LookupOption> GetValues<T>()
        {
            var values = new List<LookupOption>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                if ((int)itemType == 0)
                {
                    continue;
                }

                values.Add(new LookupOption(
                    (int)itemType,
                    ((Enum)itemType).GetDisplayName(),
                    Enum.GetName(typeof(T), itemType)));
            }

            return values;
        }

        public static string GetDisplayName(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attribute = fi.GetCustomAttribute<DisplayNameAttribute>(false);

            if (attribute == null)
            {
                return value.ToString();
            }

            return attribute.DisplayName;
        }
    }
}
