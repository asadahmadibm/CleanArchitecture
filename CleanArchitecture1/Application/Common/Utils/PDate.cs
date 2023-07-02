using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utils
{
    public class PDate : PersianCalendar
    {
        public static string AMSymbol = "&#1602;.&#1592;";
        public static string PMSymbol = "&#1576;.&#1592;";

        public static DateTime MinValue = new DateTime(622, 3, 22);
        public static DateTime MaxValue = new DateTime(9999, 12, 31);

        public static string[] PersianMonth = new string[]
        {
            "",
            "&#1601;&#1585;&#1608;&#1585;&#1583;&#1610;&#1606;", //Farvardin
			"&#1575;&#1585;&#1583;&#1610;&#1576;&#1607;&#1588;&#1578;", //Ordibehsht
			"&#1582;&#1585;&#1583;&#1575;&#1583;", //Khordad
			"&#1578;&#1610;&#1585;", //Tir
			"&#1605;&#1585;&#1583;&#1575;&#1583;", //Mordad
			"&#1588;&#1607;&#1585;&#1610;&#1608;&#1585;", //Shahrivar
			"&#1605;&#1607;&#1585;", //Mehr
			"&#1570;&#1576;&#1575;&#1606;", //Aban
			"&#1570;&#1584;&#1585;", //Azar
			"&#1583;&#1740;", //Dey
			"&#1576;&#1607;&#1605;&#1606;", //Bahman
			"&#1575;&#1587;&#1601;&#1606;&#1583;" //Esfand
		};

        public static string[] PersianWeekDay = new string[]
        {
            "&#1610;&#1705;&#1588;&#1606;&#1576;&#1607;", //Sun
			"&#1583;&#1608;&#1588;&#1606;&#1576;&#1607;", //Mon
			"&#1587;&#1607; &#1588;&#1606;&#1576;&#1607;", //Tue
			"&#1670;&#1607;&#1575;&#1585;&#1588;&#1606;&#1576;&#1607;", //Wed
			"&#1662;&#1606;&#1580;&#1588;&#1606;&#1576;&#1607;", //The
			"&#1580;&#1605;&#1593;&#1607;", //Fri
			"&#1588;&#1606;&#1576;&#1607;" //Sat
		};

        public static string ToShortDateString(DateTime LatinDate)
        {
            return PDate.ToShortDateString(LatinDate, false);
        }

        public static string ToShortDateString(DateTime LatinDate, bool toPersianNumberString)
        {
            if (!IsPersianDate(LatinDate))
                return ToPersianNumberString(LatinDate.ToShortDateString());

            PersianCalendar pcal = new PersianCalendar();

            string result = pcal.GetYear(LatinDate).ToString() + "/";
            result += pcal.GetMonth(LatinDate).ToString("00") + "/";
            result += pcal.GetDayOfMonth(LatinDate).ToString("00");

            if (toPersianNumberString)
                return PDate.ToPersianNumberString(result);
            return result;
        }

        public static string ToShortDateString(String LatinDate)
        {
            DateTime dt;
            string result;

            try
            {
                dt = DateTime.Parse(LatinDate);
                result = PDate.ToShortDateString(dt);
            }
            catch
            {
                result = "";
            }

            return result;
        }

        public static string ToLongDateWithWeekDayString(DateTime LatinDate)
        {
            if (!IsPersianDate(LatinDate))
                return ToPersianNumberString(LatinDate.ToLongDateString());

            PersianCalendar pcal = new PersianCalendar();
            /*		
                        string result = PNumber.ToPersianNumberString(pcal.GetYear(LatinDate).ToString ());
                        result += " " + PersianWeekDay[pcal.GetDayOfWeek(LatinDate).GetHashCode ()];
                        result += " " + PNumber.ToPersianNumberString(pcal.GetDayOfMonth(LatinDate).ToString ());
                        result += " " + PersianMonth[pcal.GetMonth(LatinDate)];
            */
            string result = "";
            result += PersianWeekDay[pcal.GetDayOfWeek(LatinDate).GetHashCode()];
            result += " " + pcal.GetDayOfMonth(LatinDate).ToString();
            result += " " + PersianMonth[pcal.GetMonth(LatinDate)];
            result += " " + pcal.GetYear(LatinDate).ToString();

            return result;
        }

        public static string ToLongDateString(DateTime LatinDate)
        {
            if (!IsPersianDate(LatinDate))
                return ToPersianNumberString(LatinDate.ToLongDateString());

            PersianCalendar pcal = new PersianCalendar();

            string result = String.Empty;
            result += "&nbsp;" + pcal.GetDayOfMonth(LatinDate).ToString();
            result += "&nbsp;" + PersianMonth[pcal.GetMonth(LatinDate)];
            result += "&nbsp;" + pcal.GetYear(LatinDate).ToString();

            return result;
        }

        public static string ToShortTime12String(DateTime LatinDate)
        {
            string result = String.Empty;

            if (LatinDate.Hour <= 12)
                result += String.Format("{0:0#}", LatinDate.Hour);
            else
                result += String.Format("{0:0#}", LatinDate.Hour - 12);

            result += ":" + String.Format("{0:0#}", LatinDate.Minute);

            if (LatinDate.Hour < 12)
                result += " " + PDate.AMSymbol;
            else
                result += " " + PDate.PMSymbol;

            return result;
        }

        public static string ToShortTime24String(DateTime LatinDate)
        {
            string result = String.Empty;

            result += String.Format("{0:0#}", LatinDate.Hour);
            result += ":" + String.Format("{0:0#}", LatinDate.Minute);

            return result;
        }

        public static string ToShortTime24String(DateTime LatinDate, bool toPersianNumberString)
        {
            string result = String.Empty;

            result += String.Format("{0:0#}", LatinDate.Hour);
            result += ":" + String.Format("{0:0#}", LatinDate.Minute);

            if (toPersianNumberString)
                return PDate.ToPersianNumberString(result);
            return result;
        }

        public static string ToLongDateString(String LatinDate)
        {
            DateTime dt;
            string result;

            try
            {
                dt = DateTime.Parse(LatinDate);
                result = PDate.ToLongDateString(dt);
            }
            catch
            {
                result = "";
            }

            return result;
        }

        public static string ToPersianNumberString(String LatinNumber)
        {
            string PersianNumber = "";
            int len = LatinNumber.Length;
            for (int i = 0; i < len; i++)
                if ('0' <= LatinNumber[i] && LatinNumber[i] <= '9')
                    PersianNumber += Convert.ToChar(1728 + (int)LatinNumber[i]).ToString();
                else
                    PersianNumber += LatinNumber[i];

            return PersianNumber;
        }

        public static bool IsPersianDate(DateTime LatinDate)
        {
            return (MinValue <= LatinDate && LatinDate <= MaxValue);
        }

        public static DateTime ToPersianDate(DateTime LatinDate)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                return persianCalendar.ToDateTime(persianCalendar.GetYear(LatinDate), persianCalendar.GetMonth(LatinDate), persianCalendar.GetDayOfMonth(LatinDate), 0, 0, 0, 0);
            }
            catch (Exception)
            {
                throw new Exception("تاریخ وارد شده معتبر نمی باشد");
            }

        }

        public static DateTime ToGeorgianDate(string persianDate)
        {
            try
            {
                string[] splittedDate = null;
                if (persianDate.Length.Equals(8))
                {
                    splittedDate = new string[3];
                    splittedDate[0] = persianDate.Substring(0, 4);
                    splittedDate[1] = persianDate.Substring(4, 2);
                    splittedDate[2] = persianDate.Substring(6, 2);
                }
                else
                {
                    splittedDate = persianDate.Split('/');
                }

                PersianCalendar persianCalendar = new PersianCalendar();
                DateTime result = new DateTime(int.Parse(splittedDate[0]),
                                                int.Parse(splittedDate[1]),
                                                int.Parse(splittedDate[2]),
                                                DateTime.Now.TimeOfDay.Hours,
                                                DateTime.Now.TimeOfDay.Minutes,
                                                DateTime.Now.TimeOfDay.Seconds,
                                                persianCalendar);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("تاریخ وارد شده معتبر نمی باشد");
            }

        }
    }
}
