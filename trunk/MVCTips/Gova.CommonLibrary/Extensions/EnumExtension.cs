using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Gova.CommonLibrary.Extensions
{
    public static class EnumExtension
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");

            var values = from int e in Enum.GetValues(typeof(TEnum))
                         select new { ID = e, Name = Enum.GetName(typeof(TEnum), e) };


            return new SelectList(values, "ID", "Name", enumObj);
        }
    }
}
