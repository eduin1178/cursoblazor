using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Providers
{
	public class CookieAuthenticationState : AuthenticationStateProvider
	{
		private readonly HttpContext httpContext;

		private AuthenticationState Anonimo => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		public CookieAuthenticationState(IHttpContextAccessor httpContext)
		{
			this.httpContext = httpContext.HttpContext;
		}

		public async override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var userIdentity = httpContext.User.Identity;
			if (userIdentity==null)
			{
				return Anonimo;
			}

			if (!httpContext.User.Identity.IsAuthenticated)
			{
				return Anonimo;
			}

			var claims = new List<Claim>
			{ 
				new Claim(ClaimTypes.Name, httpContext.User.Identity.Name)
			};

			var user = new ClaimsIdentity(claims, "MITIENDA");

			return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
		}
	}
}
