using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Toci.Client.Models;
using Toci.Client.Models.Interfaces;

namespace Toci.Client.Logic.AccountControllerLogic
{
    public abstract class AccountControllerHelper : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        #region Properties
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Constructors
        public AccountControllerHelper()
        {
        }

        public AccountControllerHelper(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        #endregion

        #region Helpers

        protected virtual async Task<ActionResult> LoginHelper(LoginViewModel model, string returnUrl)
        {
            var result =
                await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            var loginActionsDictionary = GetLoginActionsDictionary(model.RememberMe, returnUrl);

            return (loginActionsDictionary.ContainsKey(result))
                ? loginActionsDictionary[result]()
                : AddErrorHelper(model, string.Empty, "Invalid login attempt.");
        }

        protected virtual Dictionary<SignInStatus, Func<ActionResult>> GetLoginActionsDictionary(bool rememberMe, string returnUrl)
        {
            return new Dictionary<SignInStatus, Func<ActionResult>>
            {
                {SignInStatus.Success, (() => RedirectToLocal(returnUrl))},
                {SignInStatus.LockedOut, (() => View("Lockout"))},
                {
                    SignInStatus.RequiresVerification,
                    (() => RedirectToAction("SendCode", new {ReturnUrl = returnUrl, RememberMe = rememberMe}))
                }
            };
        }

        protected virtual ViewResult AddErrorHelper(IModelBase model, string key, string errorMessage)
        {
            ModelState.AddModelError(key, errorMessage);
            return View(model);
        }

        protected virtual ViewResult AddErrorsHelper(IModelBase model, IdentityResult result)
        {
            AddErrors(result);

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        protected virtual ViewResult AddErrorsHelper(IdentityResult result)
        {
            AddErrors(result);

            return View();
        }

        protected virtual void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected virtual async Task<ActionResult> VerifyCodeHelper(VerifyCodeViewModel model)
        {
            var result =
                await
                    SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe,
                        rememberBrowser: model.RememberBrowser);
            var veryfiCodeActionsDictionary = GetVeryfiCodeActionsDictionary(model);

            return (veryfiCodeActionsDictionary.ContainsKey(result))
                ? veryfiCodeActionsDictionary[result]()
                : AddErrorHelper(model, string.Empty, "Invalid code.");
        }

        protected virtual Dictionary<SignInStatus, Func<ActionResult>> GetVeryfiCodeActionsDictionary(VerifyCodeViewModel model)
        {
            return new Dictionary<SignInStatus, Func<ActionResult>>
            {
                {SignInStatus.Success, (() => RedirectToLocal(model.ReturnUrl))},
                {SignInStatus.LockedOut, (() => View("Lockout"))}
            };
        }

        protected virtual async Task<ActionResult> RegisterHelper(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);

            return (result.Succeeded) ? await SignInHelper(user) : AddErrorsHelper(model, result);
        }

        protected virtual async Task<ActionResult> SignInHelper(ApplicationUser user)
        {
            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            return RedirectToAction("Index", "Home");
        }

        protected virtual async Task<ActionResult> ConfrimEmailHelper(string userId, string code)
        {
            var result = await UserManager.ConfirmEmailAsync(userId, code);

            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        protected virtual async Task<ActionResult> ForgotPasswordHelper(ForgotPasswordViewModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Email);

            return ((user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id))))
                ? View("ForgotPasswordConfirmation")
                : View(model);
        }

        protected virtual async Task<ActionResult> ResetPasswordHelper(ResetPasswordViewModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Email);

            return (user == null)
                ? RedirectToAction("ResetPasswordConfirmation", "Account")
                : await TryToResetPassword(model, user);
        }

        protected virtual async Task<ActionResult> TryToResetPassword(ResetPasswordViewModel model, ApplicationUser user)
        {
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);

            return (result.Succeeded)
                ? (ActionResult)RedirectToAction("ResetPasswordConfirmation", "Account")
                : AddErrorsHelper(result);
        }

        protected virtual async Task<ActionResult> SendCodeHelper(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();

            return (userId == null) ? View("Error") : await GetNewSendCodeView(returnUrl, rememberMe, userId);
        }

        protected virtual async Task<ActionResult> GetNewSendCodeView(string returnUrl, bool rememberMe, string userId)
        {
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();

            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        protected virtual async Task<ActionResult> SendCodeHelper(SendCodeViewModel model)
        {
            return (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
                ? View("Error")
                : (ActionResult)RedirectToAction("VerifyCode",
                    new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        protected virtual async Task<ActionResult> ExternalLoginCallbackHelper(string returnUrl, ExternalLoginInfo loginInfo)
        {
            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            FillTmpExternalLoginCallbackDictionary(returnUrl);

            return (_tmpExternalLoginCallbackDictionary.ContainsKey(result))
                ? _tmpExternalLoginCallbackDictionary[result]()
                : ShowCreateAccountPrompt(returnUrl, loginInfo);
        }

        protected virtual ActionResult ShowCreateAccountPrompt(string returnUrl, ExternalLoginInfo loginInfo)
        {
            // If the user does not have an account, then prompt the user to create an account
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.LoginProvider = loginInfo.Login.LoginProvider;

            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        }

        protected readonly Dictionary<SignInStatus, Func<ActionResult>> _tmpExternalLoginCallbackDictionary = new Dictionary<SignInStatus, Func<ActionResult>>();

        protected virtual void FillTmpExternalLoginCallbackDictionary(string returnUrl)
        {
            _tmpExternalLoginCallbackDictionary.Add(SignInStatus.Success, (() => RedirectToLocal(returnUrl)));
            _tmpExternalLoginCallbackDictionary.Add(SignInStatus.LockedOut, (() => View("Lockout")));
            _tmpExternalLoginCallbackDictionary.Add(SignInStatus.RequiresVerification, (() => RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false })));
        }

        // Used for XSRF protection when adding external logins

        protected virtual IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        protected virtual ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        #endregion
    }
}