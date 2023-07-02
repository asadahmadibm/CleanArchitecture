using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public class ErrorEnum
    {
        public string Value { get; set; }
        public string Caption { get; set; }

        public ErrorEnum(string value, string caption)
        {
            this.Value = value;
            this.Caption = caption;
        }

        public static ErrorEnum Status90001 { get; private set; } =
            new ErrorEnum("90001", "رمز عبور اشتباه می باشد از رمزنگاری صحیح استفاده شود");
        public static ErrorEnum Status90002 { get; private set; } =
            new ErrorEnum("90002", "رمز عبور اشتباه می باشد");
        public static ErrorEnum Status90003 { get; private set; } =
            new ErrorEnum("90003", "نام کاربری اشتباه می باشد");
        public static ErrorEnum Status90004 { get; private set; } =
            new ErrorEnum("90004", "شعبه مورد نظر در این شرکت وجود ندارد");
        public static ErrorEnum Status90005 { get; private set; } =
            new ErrorEnum("90005", "");
        public static ErrorEnum Status90006 { get; private set; } =
            new ErrorEnum("90006", "");
        public static ErrorEnum Status90007 { get; private set; } =
            new ErrorEnum("90007", "این کاربر هیچ دسترسی ندارد");
        public static ErrorEnum Status90008 { get; private set; } =
            new ErrorEnum("90008", "کد شرکت وجود ندارد");
        public static ErrorEnum Status90009 { get; private set; } =
            new ErrorEnum("90009", "ارتباط با پایگاه داده شرکت برقرار نشد");
        public static ErrorEnum Status90010 { get; private set; } =
            new ErrorEnum("90010", "شماره صفحه معتبر نمیباشد");
        public static ErrorEnum Status90011 { get; private set; } =
            new ErrorEnum("90011", "تعداد رکورد معتبر نمیباشد");
        public static ErrorEnum Status90012 { get; private set; } =
            new ErrorEnum("90012", "پارامترهای ورودی معتبر نمیباشد");
        public static ErrorEnum Status90013 { get; private set; } =
        new ErrorEnum("90013", "تعداد رکورد نمی تواند بیشتر از 50 باشد");


        public static ErrorEnum Status40001 { get; private set; } =
            new ErrorEnum("40001", "سال مالی از قبل وجود دارد.");
        public static ErrorEnum Status40002 { get; private set; } =
           new ErrorEnum("40001", "سال مالی درخواست شده وجود ندارد.");
        public static ErrorEnum Status9999exception { get; private set; } =
          new ErrorEnum("9999", "exception توسط سیستم تولید میشود.");
        public static ErrorEnum Status40003 { get; private set; } =
          new ErrorEnum("40003", "حساب موجود است.");
        public static ErrorEnum Status40004 { get; private set; } =
           new ErrorEnum("40004", "حساب وجود ندارد.");
        public static ErrorEnum Status40005notfound { get; private set; } =
            new ErrorEnum("40005", "اطلاعات پیدا نشد.");
        public static ErrorEnum Status40006notzero { get; private set; } =
            new ErrorEnum("40006", "مقدار نباید صفر باشد .");

        public static ErrorEnum Status40007delete { get; private set; } =
    new ErrorEnum("40007", "امکان حذف وجود ندارد .");

    }
}
