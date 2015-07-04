using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPratico.Models
{
    public static partial class Funcoes
    {


        public static List<SelectListItem> EnumToSelectListItem<TEnum>() where TEnum : struct, IConvertible
        {
            var lista = from item in Enum.GetNames(typeof(TEnum)).ToList()
                        select new SelectListItem()
                        {
                            Selected = false,
                            Text = item.ToString(),
                            Value = item.ToString()
                        };

            var final = new List<SelectListItem>();

            foreach (var item in lista)
            {
                TEnum x = (TEnum)Enum.Parse(typeof(TEnum), item.Value);
                item.Text = x.ToString();
                item.Value = ((Int32)(object)x).ToString();

                final.Add(item);
            }

            return final;
        }
    }
}