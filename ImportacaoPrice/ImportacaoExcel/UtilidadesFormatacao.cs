using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoExcel
{
    public static class UtilidadesFormatacao
    {
        public static decimal? ToDecimal(this object value)
        {
            if(!string.IsNullOrEmpty(value.ToString()))
             value = value.ToString().Replace(".",",");

            decimal valor;
            if (decimal.TryParse((string)value, out valor))
                return valor;
            return null;
        }

        public static int? ToInt(this object value)
        {
            int valor;
            if (int.TryParse(value.ToString(), out valor))
                return valor;
            return null;
        }

        public static bool ToBool(this string value)
        {
            return value.ToUpper().StartsWith("S");
        }
    }
}
