#pragma checksum "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\RecoverPassword.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebc35132ff0125a64c621dcbbd35297ceb3f9f61"
// <auto-generated/>
#pragma warning disable 1591
namespace MITIENDA.BlazorServer.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using MITIENDA.BlazorServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using MITIENDA.BlazorServer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using MITIENDA.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using MITIENDA.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using MITIENDA.BlazorServer.Data.Providers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using CurrieTechnologies.Razor.SweetAlert2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Sotsera.Blazor.Toaster;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(UnauthorizedLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/account/recoverpassword")]
    public partial class RecoverPassword : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div class=""container""><div class=""col-md-6 offset-md-3""><div class=""card""><div class=""card-header""><h4>Mi Tienda</h4></div>
            <div class=""card-body""><h4 class=""card-title text-center"">??Olvidaste tu contrase??a?</h4>
                <div class=""col-md-12 mb-3 text-center""><p>
                        Si olvidaste tu clave, escribe tu
                        direcci??n de correo electr??nico a
                        continuaci??n para restablecerla
                    </p></div>
                <div class=""col-md-12 mb-3""><label>Email</label>
                    <input type=""email"" class=""form-control""></div>

                <div class=""col-md-12 mb-3""><a href=""#"" class=""btn btn-primary btn-block"">Env??ame la clave</a></div>

                <div class=""col-md-12 mb-3""><hr></div>
                <div class=""col-md-12 mb-3""><h5>Tambi??n puedes</h5></div>

                <div class=""col-md-12 mb-3""><a href=""/account/login"" class=""btn btn-success btn-block"">Iniciar Sesi??n Ahora</a></div></div></div></div></div>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
