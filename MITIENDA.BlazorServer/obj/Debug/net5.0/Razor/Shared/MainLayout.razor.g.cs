#pragma checksum "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdb0a898b48b867a3722a90f65de8c299aa7309c"
// <auto-generated/>
#pragma warning disable 1591
namespace MITIENDA.BlazorServer.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using MITIENDA.BlazorServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\_Imports.razor"
using MITIENDA.BlazorServer.Shared;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-0t6w23xle9");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-0t6w23xle9");
            __builder.OpenComponent<MITIENDA.BlazorServer.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-0t6w23xle9");
            __builder.AddMarkupContent(11, "<div class=\"top-row px-4\" b-0t6w23xle9><span b-0t6w23xle9>Nombre de Usuario</span>\r\n            <span b-0t6w23xle9>Salir</span></div>\r\n\r\n        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "content px-4");
            __builder.AddAttribute(14, "b-0t6w23xle9");
            __builder.AddContent(15, 
#nullable restore
#line 15 "D:\PROYECTOS\CURSO\PROYECTO TIENDA\MITIENDA.BlazorServer\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
