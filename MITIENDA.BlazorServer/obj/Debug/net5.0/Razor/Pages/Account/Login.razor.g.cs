#pragma checksum "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4534f6ab70f63d3a05800f185ccfc1708b8ce8ef"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/account/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "col-md-6 offset-md-3");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "card");
            __builder.AddMarkupContent(6, "<div class=\"card-header\"><h4>Mi Tienda</h4></div>\r\n            ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "card-body");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(9);
            __builder.AddAttribute(10, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 13 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
                                 Model

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 13 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
                                                       LoginUser

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(13);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(14, "\r\n                    ");
                __builder2.AddMarkupContent(15, "<h4 class=\"card-title text-center\">Iniciar Sesi??n</h4>\r\n                    ");
                __builder2.OpenElement(16, "div");
                __builder2.AddAttribute(17, "class", "col-md-12 mb-3");
                __builder2.AddMarkupContent(18, "<label>Usuario</label>\r\n                        ");
                __builder2.OpenElement(19, "input");
                __builder2.AddAttribute(20, "type", "email");
                __builder2.AddAttribute(21, "class", "form-control");
                __builder2.AddAttribute(22, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 18 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
                                                                        Model.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Model.Email = __value, Model.Email));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n                        ");
                __Blazor.MITIENDA.BlazorServer.Pages.Account.Login.TypeInference.CreateValidationMessage_0(__builder2, 25, 26, 
#nullable restore
#line 19 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
                                                (()=>Model.Email)

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n\r\n                    ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "col-md-12 mb-3");
                __builder2.AddMarkupContent(30, "<label>Contrase??a</label>\r\n                        ");
                __builder2.OpenElement(31, "input");
                __builder2.AddAttribute(32, "type", "password");
                __builder2.AddAttribute(33, "class", "form-control");
                __builder2.AddAttribute(34, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 24 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
                                                                           Model.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Model.Password = __value, Model.Password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(36, "\r\n                        ");
                __Blazor.MITIENDA.BlazorServer.Pages.Account.Login.TypeInference.CreateValidationMessage_1(__builder2, 37, 38, 
#nullable restore
#line 25 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
                                                (()=>Model.Password)

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n\r\n                    ");
                __builder2.OpenElement(40, "div");
                __builder2.AddAttribute(41, "class", "col-md-12 mb-3");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "form-group form-check");
                __builder2.OpenElement(44, "input");
                __builder2.AddAttribute(45, "type", "checkbox");
                __builder2.AddAttribute(46, "class", "form-check-input");
                __builder2.AddAttribute(47, "id", "exampleCheck1");
                __builder2.AddAttribute(48, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 31 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
                                          Model.RememberMe

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(49, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Model.RememberMe = __value, Model.RememberMe));
                __builder2.SetUpdatesAttributeName("checked");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n                            ");
                __builder2.AddMarkupContent(51, "<label class=\"form-check-label\" for=\"exampleCheck1\">Mantener sesi??n abierta</label>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(52, "\r\n\r\n                    ");
                __builder2.AddMarkupContent(53, "<div class=\"col-md-12 mb-3\"><button type=\"submit\" class=\"btn btn-primary btn-block\">Iniciar</button></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(54, "\r\n                ");
            __builder.AddMarkupContent(55, "<div class=\"col-md-12 mb-3\"><a href=\"/account/recoverpassword\"> ??Olvidaste tu contrase??a?</a></div>\r\n                ");
            __builder.AddMarkupContent(56, "<div class=\"col-md-12 mb-3\"><hr></div>\r\n                ");
            __builder.AddMarkupContent(57, "<div class=\"col-md-12 mb-3\"><h5>??Aun no tienes una cuenta?</h5></div>\r\n\r\n                ");
            __builder.AddMarkupContent(58, "<div class=\"col-md-12 mb-3\"><a href=\"/account/register\" class=\"btn btn-success btn-block\">Registrarte Ahora</a></div>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n\r\n");
            __builder.OpenComponent<Sotsera.Blazor.Toaster.ToastContainer>(60);
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 69 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Account\Login.razor"
       


    public LoginUsuarioModel Model { get; set; } = new LoginUsuarioModel();

    protected async Task LoginUser()
    {
        var res = usuarioService.Login(Model);

        if (!res.IsSuccess)
        {
            toaster.Error(res.Message, "Error");
        }
        else
        {

            var token = new LoginModel
            {
                Usuario = Model.Email,
                Recordar = Model.RememberMe,
            };


            await authProvider.Login(token);

            navigation.NavigateTo("/", true);

        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToaster toaster { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthProvider authProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UsuariosService usuarioService { get; set; }
    }
}
namespace __Blazor.MITIENDA.BlazorServer.Pages.Account.Login
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
