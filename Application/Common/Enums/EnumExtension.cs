using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreIMS.Application.Common.ExtensionMethods
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Extension method to use reflection to return the Display Name attribute for enum values
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            MemberInfo member = enumValue.GetType().GetMember(enumValue.ToString()).First();

            DisplayAttribute displayAttrib = member.GetCustomAttribute<DisplayAttribute>();
            if (displayAttrib == null)
            {
                return member.Name;
            }

            return displayAttrib.GetName();
        }
    }
}
