using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Toci.Client.Logic;
using Toci.Client.Models;
using Toci.Client.Models.Interfaces;

namespace Toci.Client.Controllers
{
    [Authorize]
    public class AccountController : Controller
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
        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        #endregion

        #region Controller stuff
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl, LoginViewModel model)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            return (ModelState.IsValid) ? await LoginHelper(model, returnUrl) : View(model);
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            return (!await SignInManager.HasBeenVerifiedAsync())
                ? View("Error")
                : View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });

        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            return (ModelState.IsValid) ? await VerifyCodeHelper(model) : View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            return (ModelState.IsValid) ? await RegisterHelper(model) : View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            return (userId == null || code == null) ? View("Error") : await ConfrimEmailHelper(userId, code);
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            return (ModelState.IsValid) ? await ForgotPasswordHelper(model) : View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            return (ModelState.IsValid) ? await ResetPasswordHelper(model) : View(model);
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/loginLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            return await SendCodeHelper(returnUrl, rememberMe);
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            return (ModelState.IsValid) ? await SendCodeHelper(model) : View();
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();

            return (loginInfo != null) ? await ExternalLoginCallbackHelper(returnUrl, loginInfo) : RedirectToAction("Login");
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure(string errormsg)
        {
            ViewBag.ErrorMsg = errormsg;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Helpers

        private async Task<ActionResult> LoginHelper(LoginViewModel model, string returnUrl)
        {
            var result =
                await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            var loginActionsDictionary = GetLoginActionsDictionary(model.RememberMe, returnUrl);

            return (loginActionsDictionary.ContainsKey(result))
                ? loginActionsDictionary[result]()
                : AddErrorHelper(model, string.Empty, "Invalid login attempt.");
        }

        private Dictionary<SignInStatus, Func<ActionResult>> GetLoginActionsDictionary(bool rememberMe, string returnUrl)
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

        private ViewResult AddErrorHelper(IModelBase model, string key, string errorMessage)
        {
            ModelState.AddModelError(key, errorMessage);
            return View(model);
        }

        private ViewResult AddErrorsHelper(IModelBase model, IdentityResult result)
        {
            AddErrors(result);

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private ViewResult AddErrorsHelper(IdentityResult result)
        {
            AddErrors(result);

            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private async Task<ActionResult> VerifyCodeHelper(VerifyCodeViewModel model)
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

        private Dictionary<SignInStatus, Func<ActionResult>> GetVeryfiCodeActionsDictionary(VerifyCodeViewModel model)
        {
            return new Dictionary<SignInStatus, Func<ActionResult>>
            {
                {SignInStatus.Success, (() => RedirectToLocal(model.ReturnUrl))},
                {SignInStatus.LockedOut, (() => View("Lockout"))}
            };
        }

        private async Task<ActionResult> RegisterHelper(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);

            return (result.Succeeded) ? await SignInHelper(user) : AddErrorsHelper(model, result);
        }

        private async Task<ActionResult> SignInHelper(ApplicationUser user)
        {
            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            return RedirectToAction("Index", "Home");
        }

        private async Task<ActionResult> ConfrimEmailHelper(string userId, string code)
        {
            var result = await UserManager.ConfirmEmailAsync(userId, code);

            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        private async Task<ActionResult> ForgotPasswordHelper(ForgotPasswordViewModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Email);

            return ((user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id))))
                ? View("ForgotPasswordConfirmation")
                : View(model);
        }

        private async Task<ActionResult> ResetPasswordHelper(ResetPasswordViewModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Email);

            return (user == null)
                ? RedirectToAction("ResetPasswordConfirmation", "Account")
                : await TryToResetPassword(model, user);
        }

        private async Task<ActionResult> TryToResetPassword(ResetPasswordViewModel model, ApplicationUser user)
        {
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);

            return (result.Succeeded)
                ? (ActionResult)RedirectToAction("ResetPasswordConfirmation", "Account")
                : AddErrorsHelper(result);
        }

        private async Task<ActionResult> SendCodeHelper(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();

            return (userId == null) ? View("Error") : await GetNewSendCodeView(returnUrl, rememberMe, userId);
        }

        private async Task<ActionResult> GetNewSendCodeView(string returnUrl, bool rememberMe, string userId)
        {
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();

            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        private async Task<ActionResult> SendCodeHelper(SendCodeViewModel model)
        {
            return (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
                ? View("Error")
                : (ActionResult)RedirectToAction("VerifyCode",
                    new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        private async Task<ActionResult> ExternalLoginCallbackHelper(string returnUrl, ExternalLoginInfo loginInfo)
        {
            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            FillTmpExternalLoginCallbackDictionary(returnUrl);

            return (_tmpExternalLoginCallbackDictionary.ContainsKey(result))
                ? _tmpExternalLoginCallbackDictionary[result]()
                : ShowCreateAccountPrompt(returnUrl, loginInfo);
        }

        private ActionResult ShowCreateAccountPrompt(string returnUrl, ExternalLoginInfo loginInfo)
        {
            // If the user does not have an account, then prompt the user to create an account
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.LoginProvider = loginInfo.Login.LoginProvider;

            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        }

        private readonly Dictionary<SignInStatus, Func<ActionResult>> _tmpExternalLoginCallbackDictionary = new Dictionary<SignInStatus, Func<ActionResult>>();

        private void FillTmpExternalLoginCallbackDictionary(string returnUrl)
        {
            _tmpExternalLoginCallbackDictionary.Add(SignInStatus.Success, (() => RedirectToLocal(returnUrl)));
            _tmpExternalLoginCallbackDictionary.Add(SignInStatus.LockedOut, (() => View("Lockout")));
            _tmpExternalLoginCallbackDictionary.Add(SignInStatus.RequiresVerification, (() => RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false })));
        }

        // Used for XSRF protection when adding external logins

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
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