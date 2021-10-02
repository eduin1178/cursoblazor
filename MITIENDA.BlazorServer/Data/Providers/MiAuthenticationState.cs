using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MITIENDA.BlazorServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Providers
{
    public class MiAuthenticationState : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;

        public MiAuthenticationState(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorage.GetItemAsync<LoginModel>("token");

            if (token == null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            if (string.IsNullOrEmpty(token.Usuario))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var usuarioAutenticado = SignIn(token);
            return new AuthenticationState(usuarioAutenticado);

        }

        public ClaimsPrincipal SignIn(LoginModel token)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, token.Usuario),
                new Claim(ClaimTypes.Email, token.Usuario)
            };

            var identity = new ClaimsIdentity(claims, "mitienda");

            var principal = new ClaimsPrincipal(identity);
            var authState = Task.FromResult(new AuthenticationState(principal));
            NotifyAuthenticationStateChanged(authState);

            return principal;
        }

        public void SignOut()
        {
            var usuarioAnonimo = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(usuarioAnonimo));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
