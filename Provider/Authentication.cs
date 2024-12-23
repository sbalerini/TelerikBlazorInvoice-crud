
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
namespace BlazorOE01.Provider

{
  
        public class Authentication : AuthenticationStateProvider
        {

            public override Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                var user = new ClaimsPrincipal();
                return Task.FromResult(new AuthenticationState(user));
            }

        }
    }

