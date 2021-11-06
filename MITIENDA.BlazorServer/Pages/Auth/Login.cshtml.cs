using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MITIENDA.Data.Entities;
using MITIENDA.Models;
using MITIENDA.Services;

namespace MITIENDA.BlazorServer.Pages.Auth
{
    [BindProperties]
    public class LoginModel : PageModel
    {
		private readonly UsuariosService usuariosService;

		public LoginUsuarioModel Model { get; set; }

		public LoginModel(UsuariosService usuariosService)
		{
			this.usuariosService = usuariosService;
		}

		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
            returnUrl = returnUrl ?? Url.Content("~/");

			try
			{
				await HttpContext.SignOutAsync("Cookies");
			}
			catch (Exception)
			{
			}

			var res = usuariosService.Login(Model);

			if (!res.IsSuccess)
			{
				return Page();
			}

			var userModel = res.Objeto as Usuario;

			var claaims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, userModel.Nombre),
				new Claim(ClaimTypes.Email, userModel.Email),
				new Claim(ClaimTypes.Role, userModel.Rol.Nombre),
				new Claim("Role", userModel.Rol.Nombre),
			};

			var claimsIdentity = new ClaimsIdentity(
				claaims, CookieAuthenticationDefaults.AuthenticationScheme);

			var authProperties = new AuthenticationProperties
			{
				IsPersistent = Model.RememberMe,
				RedirectUri = this.Request.Host.Value,
			};

			try
			{
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity), authProperties);
			}
			catch (Exception)
			{

			}

			return LocalRedirect(returnUrl);
		}
    }
}
