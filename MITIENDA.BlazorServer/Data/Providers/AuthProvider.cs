using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MITIENDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Providers
{
    public class AuthProvider
    {
        private readonly AuthenticationStateProvider authenticationState;
        private readonly ILocalStorageService localStorage;

        public AuthProvider(AuthenticationStateProvider authenticationState, 
            ILocalStorageService localStorage)
        {
            this.authenticationState = authenticationState;
            this.localStorage = localStorage;
        }
        public async Task<bool> Login(LoginModel model)
        {
             await localStorage.SetItemAsync<LoginModel>("token", model);
            ((MiAuthenticationState) authenticationState).SignIn(model);
            return true;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("token");
            ((MiAuthenticationState) authenticationState).SignOut();
        }
    }
}
