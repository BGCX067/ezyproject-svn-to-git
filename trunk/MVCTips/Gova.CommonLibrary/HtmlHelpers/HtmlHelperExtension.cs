using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;
using System.Web.Mvc.Html;

namespace Gova.CommonLibrary.HtmlHelpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Type enumType)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            Dictionary<string, string> enumItems = enumType.GetDescription();
            foreach (KeyValuePair<string, string> pair in enumItems)
                list.Add(new SelectListItem() { Value = pair.Key, Text = pair.Value });
            return htmlHelper.DropDownListFor(expression, list);
        }

        /// <summary>
        /// return the items of enum paired with its descrtioption.
        /// </summary>
        /// <param name="enumeration">enumeration type to be processed.</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDescription(this Type enumeration)
        {
            if (!enumeration.IsEnum)
            {
                throw new ArgumentException("passed type must be of Enum type", "enumerationValue");
            }

            Dictionary<string, string> descriptions = new Dictionary<string, string>();
            var members = enumeration.GetMembers().Where(m => m.MemberType == MemberTypes.Field);

            foreach (MemberInfo member in members)
            {
                var attrs = member.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Count() != 0)
                    descriptions.Add(member.Name, ((DescriptionAttribute)attrs[0]).Description);
            }
            return descriptions;
        }

    }
}
