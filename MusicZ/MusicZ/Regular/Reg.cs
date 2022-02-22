using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicZ.Regular
{
    internal class Reg
    {
        static private string ForNameSurename { get; }
        static private string ForNumberPhone { get; }
        static private string ForPassword { get; }
        static private string ForNumber { get; }

        static Reg()
        {
            ForNameSurename = @"^([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$";
            ForNumberPhone = @"^((380|\+380)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            ForPassword = @"^(?=.*[0-9].*)(?=.*[a-z].*)(?=.*[A-Z].*)[0-9a-zA-Z]{8,}$";
            ForNumber = @"^\d+$";
        }

        static public bool CheckNameSurename(string str)
        {
            if (str == null)
                return false;

            return Regex.IsMatch(str.Trim(), ForNameSurename);
        }

        static public bool CheckNumberPhone(string str)
        {
            if (str == null)
                return false;

            return Regex.IsMatch(str.Trim(), ForNumberPhone);
        }

        static public bool CheckPassword(string str)
        {
            if (str == null)
                return false;

            return Regex.IsMatch(str.Trim(), ForPassword);
        }

        static public bool CheckNumber(string str)
        {
            if (str == null)
                return false;

            return Regex.IsMatch(str.Trim(), ForNumber);
        }
    }
}
