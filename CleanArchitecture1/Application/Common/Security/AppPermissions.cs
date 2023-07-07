using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Application.Common.Security
{


    public static class AppPermissions
    {
        public static Permission SysAdmin = new Permission("SysAdmin", "مدیر سامانه", null);
        public static Permission EcarSales = new Permission("EcarSales", "سامانه یکپارچه", null);

        public static Permission CrmCompanyGetAll = new Permission("CrmCompanyGetAll", "لیست شرکتها", null);
        public static Permission CrmCompanyGetById = new Permission("CrmCompanyGetById", "مشخصات شرکت", null);
        public static Permission CrmCompanyUpsert = new Permission("CrmCompanyUpsert", "ویرایش شرکتها", null);
        public static Permission CrmCompanyDelete = new Permission("CrmCompanyDelete", "حذف شرکت", null);
        

        public static Permission Dashboard = new Permission("Dashboard", "داشبورد", null);
        public static Permission Dashboard_Nima = new Permission("Dashboard_Nima", "نیما", Dashboard);
        public static Permission Dashboard_Nima_Total = new Permission("Dashboard_Nima_Total", "عرضه ارز روز جاری", Dashboard);

        

        public static Permission Nima = new Permission("Nima", "نیما", null);
        public static Permission Nima_ViewExchangeAccount = new Permission("Nima_ViewExchangeAccount", "مشاهده اطلاعات حسابهای ارزی ", Nima);
        public static Permission NimaImport = new Permission("NimaImport", "نیما واردات", Nima);
        public static Permission RequestManagement_ViewDetail = new Permission("RequestManagement_ViewDetail", "مشاهده جزئیات یک درخواست", NimaImport);
        public static Permission RequestManagement_ReturnFromMakhtoome = new Permission("RequestManagement_ReturnFromMakhtoome", "بازگشت از مختومه", NimaImport);
        public static Permission RequestManagement_CancelOffer = new Permission("RequestManagement_CancelOffer", "انصراف صراف از پیشنهاد", NimaImport);
        public static Permission RequestManagement_ConfirmApplicantCancel = new Permission("RequestManagement_ConfirmApplicantCancel", "تایید/رد انصراف متقاضی از پیشنهاد", NimaImport);
        public static Permission RequestManagement_DownloadDocuments = new Permission("RequestManagement_DownloadDocuments", "دانلود مستندات حواله", NimaImport);

        public static Permission NimaExport = new Permission("NimaExport", "نیما صادرات", Nima);
        public static Permission NimaExport_ViewDealing = new Permission("NimaExport_ViewDealing", "مشاهده عرضه/تقاضا/معاملات", NimaExport);
        public static Permission NimaExport_CancelDealing = new Permission("NimaExport_CancelDealing", "انصراف از معامله", NimaExport);
        public static Permission NimaExport_ReplySupplierCanceling = new Permission("NimaExport_ReplySupplierCanceling", "تایید/رد انصراف از معامله بازرگان", NimaExport);
        public static Permission NimaExport_FinalDealing = new Permission("NimaExport_FinalDealing", "تایید نهایی معامله", NimaExport);
        public static Permission NimaExport_ReturnFromFinalDealing = new Permission("NimaExport_ReturnFromFinalDealing", "برگشت از مختومه معامله", NimaExport);
        public static Permission NimaExport_SupplyCottage = new Permission("NimaExport_SupplyCottage", "نمایش کوتاژها", NimaExport);
        //public static Permission NimaExport_CellingBuy = new Permission("NimaExport_CellingBuy", "سقف خرید صرافی ها ", NimaExport);

        public static Permission NimaBlackList = new Permission("NimaBlackList", "مدیریت استثنائات لیست سیاه", Nima);
        public static Permission NimaBlackList_View = new Permission("NimaBlackList_View", "مشاهده معاملات استثناء در لیست سیاه", NimaBlackList);
        public static Permission NimaBlackList_AddToExceptions = new Permission("NimaBlackList_AddToExceptions", "افزودن به معاملات مستثنی شده در لیست سیاه", NimaBlackList);
        public static Permission NimaBlackList_RemoveFromExceptions = new Permission("NimaBlackList_RemoveFromExceptions", "حذف از معاملات مستثنی شده در لیست سیاه", NimaBlackList);


        public static Permission Merchant = new Permission("Merchant", "بازرگان ها", null);
        public static Permission Merchant_permission = new Permission("Merchant_permission", "مجوز بازرگان ها", Merchant);

        public static Permission AccountManagement = new Permission("AccountManagement", "مدیریت کاربران", null);
        public static Permission AccountManagement_AddRole = new Permission("AccountManagement_AddRole", "ایجاد نقش", AccountManagement);
        public static Permission AccountManagement_EditRole = new Permission("AccountManagement_EditRole", "ویرایش نقش", AccountManagement);
        public static Permission AccountManagement_DeleteRole = new Permission("AccountManagement_DeleteRole", "حذف نقش", AccountManagement);
        public static Permission AccountManagement_SearchUser = new Permission("AccountManagement_SearchUser", "جستجوی کاربر", AccountManagement);
        public static Permission CreateUser = new Permission("AccountManagement_AddUser", "ایجاد کاربر جدید", AccountManagement);
        public static Permission UpdateUser = new Permission("AccountManagement_UpdateUser", "بروزرسانی کاربر موجود", AccountManagement);
        public static Permission DeleteUser = new Permission("AccountManagement_DeleteUser", "حذف کاربر", AccountManagement);
        public static Permission ResetPassword = new Permission("AccountManagement_ResetPassword", "ریست رمز عبور", AccountManagement);

        public static Permission ExchangeManagement = new Permission("ExchangeManagement", "مدیریت صرافی ها", null);
        //public static Permission ExchangeManagement_Search = new Permission("ExchangeManagement_Search", "جستجوی صرافی ها", ExchangeManagement);
        public static Permission ExchangeManagement_View = new Permission("ExchangeManagement_View", "مشاهده مدیریت صرافی ها", ExchangeManagement);
        public static Permission ExchangeManagement_EditAccess = new Permission("ExchangeManagement_EditAccess", "ویرایش مجوز صرافی", ExchangeManagement);
        public static Permission ExchangeManagement_ViewBalance = new Permission("ExchangeManagement_ViewBalance", "مشاهده تراز صرافی", ExchangeManagement);
        public static Permission ExchangeManagement_TaahodCategory = new Permission("ExchangeManagement_TaahodCategory", "نوع سقف تعهد", ExchangeManagement);
        public static Permission ExchangeManagement_OpenPositionCategory = new Permission("ExchangeManagement_OpenPositionCategory", "نوع سقف وضعیت باز", ExchangeManagement);
        
        public static Permission ExchangeManagement_PositionCorrection = new Permission("ExchangeManagement_PositionCorrection", "مدیریت سند اصلاحی پوزیشن", ExchangeManagement);

        public static Permission SanaManagement = new Permission("SanaManagement", "مدیریت سنا", null);
        public static Permission SanaManagement_Edit = new Permission("SanaManagement_Edit", "ویرایش سرفصل های سنا", SanaManagement);
        public static Permission SanaManagement_ExceptionalCurUseBySarafi = new Permission("SanaManagement_ExceptionalCurUseBySarafi", "مستثنی کردن سرفصل های سنا", SanaManagement);
        public static Permission SanaManagement_SellFromResourceBank = new Permission("SanaManagement_SellFromResourceBank", "فروش از منابع بانک مرکزی", SanaManagement);


        public static Permission RoleManagement = new Permission("RoleManagement", "مدیریت نقش و دسترسی", null);
        public static Permission RoleManagement_ViewRole = new Permission("RoleManagement_ViewRole", "مشاهده نقش ها", RoleManagement);
        public static Permission RoleManagement_CreateRole = new Permission("RoleManagement_CreateRole", "ایجاد نقش", RoleManagement);
        public static Permission RoleManagement_DeleteRole = new Permission("RoleManagement_DeleteRole", "حذف نقش", RoleManagement);
        public static Permission RoleManagement_AssignPermissionToRole = new Permission("RoleManagement_AssignPermissionToRole", "نسبت دادن دسترسی به نقش", RoleManagement);
        public static Permission RoleManagement_AssignUserToRole = new Permission("RoleManagement_AssignUserToRole", "نسبت دادن کاربر به نقش", RoleManagement);


        public static Permission SettingManagement = new Permission("SettingManagement", "تنظیمات", null);
        public static Permission SettingManagement_Shahlar = new Permission("SettingManagement_Shahlar", "شاهکار", SettingManagement);
        public static Permission SettingManagement_NimaOperTime = new Permission("SettingManagement_NimaOperTime", "ساعات کاری نیما", SettingManagement);
        public static Permission SettingManagement_PolicyCoef = new Permission("SettingManagement_PolicyCoef", "ضرایت سیاستی تعهدات", SettingManagement);
        public static Permission SettingManagement_Calendar = new Permission("SettingManagement_Calendar", "تقویم روزهای کاری", SettingManagement);
        public static Permission SettingManagement_RateRange = new Permission("SettingManagement_RateRange", "سقف/کف نرخ معاملات حواله ارز", SettingManagement);

        public static Permission DigitalCheque = new Permission("DigitalCheque", "حساب تسویه ریالی", null);
        // public static Permission DigitalCheque_menu = new Permission("DigitalCheque_menu", "مشاهده منو ", DigitalCheque);
        public static Permission DigitalCheque_ViewRole = new Permission("DigitalCheque_ViewRole", "مشاهده پرداختها", DigitalCheque);
        public static Permission Invalidpayments_ViewRole = new Permission("Invalidpayments_ViewRole", "مشاهده واریزی های نامعتبر", DigitalCheque);

        public static Permission ReportsManagement = new Permission("ReportsManagement", "گزارشات", null);
        public static Permission ReportsManagement_SanaRialiValidation = new Permission("ReportsManagement_SanaRialiValidation", "صحت سنجی پرداختهای ریالی سنا", ReportsManagement);
        public static Permission ReportsManagement_ShowExchangePosition = new Permission("ReportsManagement_ShowExchangePosition", "مشاهده پوزیشن شروع دوره صرافی ها", ReportsManagement);
        
        public static Permission CoinDealing = new Permission("CoinDealing", "معاملات سکه", null);
        public static Permission CoinDealing_View = new Permission("CoinDealing_View", "مشاهده معاملات سکه در سنا", CoinDealing);

        public static IEnumerable<Permission> GetAllPermissions()
        {
            return
                typeof(AppPermissions).GetFields(BindingFlags.Static | BindingFlags.Public).
                Where(a => a.FieldType == typeof(Permission)).
                Select(a => a.GetValue(null))
                .Cast<Permission>();
        }
    }


    public class Permission
    {
        public Permission(string key, string description, Permission parent)
        {
            Key = key;
            Description = description;
            Parent = parent;
        }
        public string Key { get; set; }
        public string Description { get; set; }
        public Permission Parent { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Permission)obj).Key == Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }

}
