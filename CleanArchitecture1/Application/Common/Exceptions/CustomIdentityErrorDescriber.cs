

using Microsoft.AspNetCore.Identity;

namespace SApplication.Common.Exceptions
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"یک خطای ناشناخته بروز کرده است، در صورت تکرار با مدیر سامانه تماس بگیرید" }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "خطای همزمانی، این شیء قبلا تغییر کرده است." }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "پسورد صحیح نمی باشد." }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "توکن صحیح نمی باشد." }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "این نام کاربری قبلا لاگین شده است." }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"نام کاربری '{userName}' معتبر نمی باشد، نام کاربری می تواند تنها شامل عدد و حرف باشد." }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"پست الکترونیکی '{email}' معتبر نمی باشد." }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"نام کاربری '{userName}' قبلا انتخاب شده است" }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"پست الکترونیکی '{email}' تکراری می باشد." }; }
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"نقش '{role}' معتبر نمی باشد." }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"نقش '{role}' قبلا ثبت شده است." }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "کاربر در حال حاضر " }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "امکان قفل کردن این کاربر وجود ندارد." }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"نقش '{role}' برای این کاربر قبلا تعریف شده است." }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = $"کاربر در نقش '{role}' نمی باشد." }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"حداقل طول پسورد {length} کاراکتر می باشد." }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "پسورد باید حداقل شامل یک کاراکتر خاص باشد." }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "پسورد باید حداقل شامل یک عدد بین 0 تا 9 باشد." }; }
        //public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Passwords must have at least one lowercase ('a'-'z')." }; }
        //public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Passwords must have at least one uppercase ('A'-'Z')." }; }

    }
}
