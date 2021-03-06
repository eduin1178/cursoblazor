// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MITIENDA.BlazorServer.Pages.Tienda
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
#nullable restore
#line 3 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Tienda\ProductosComponente.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/products")]
    public partial class ProductosComponente : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 129 "D:\PROYECTOS\CURSO\TIENDA\MITIENDA.BlazorServer\Pages\Tienda\ProductosComponente.razor"
       

    public ProductoModel Producto { get; set; } = new ProductoModel();

    public List<CategoriaModel> ListaCategorias { get; set; }

    public List<ProductoModel> ListaProductos { get; set; } = new List<ProductoModel>();

    protected override void OnInitialized()
    {
        ListaCategorias = categoriasService.ListaCategorias();

        CargarProductos();
    }

    protected void CargarProductos(int? idCategoria = null)
    {
        if (idCategoria == null)
        {
            ListaProductos = productoService.ListaProductos();
        }
        else
        {
            ListaProductos = productoService.ListaProductos(Convert.ToInt32(idCategoria));

        }

    }

    protected void AgregarProducto()
    {
        var res = productoService.Crear(Producto);

        if (res.IsSuccess)
        {
            toaster.Success(res.Message, "OK");

            var prod = (ProductoModel)res.Objeto;
            //var prod = res.Objeto as ProductoModel;

            ListaProductos.Add(prod);
            Producto = new ProductoModel();

            //CargarProductos(); No recomendada

        }
        else
        {
            toaster.Error(res.Message, "Error");
        }
    }

    protected void AlCamabiarCategoriaSeleccionada(ChangeEventArgs e)
    {
        Producto.IdCategoria = Convert.ToInt32(e.Value);

        CargarProductos(Producto.IdCategoria);


    }

    protected async Task EliminarProducto(ProductoModel producto)
    {
        var confirm = await swal.FireAsync(new SweetAlertOptions
        {
            Title = "??Confirma que desea eliminar este producto?",
            Text = "No podr?? revertir esta operaci??n",
            ShowConfirmButton = true,
            ShowCancelButton = true,
            ConfirmButtonText = "De acuerdo",
            CancelButtonText = "Cancelar"
        });

        if (!confirm.IsConfirmed)
        {
            return;
        }

        var res = productoService.Eliminar(producto.Id);

        if (res.IsSuccess)
        {
            toaster.Success(res.Message, "OK");
            ListaProductos.Remove(producto);
        }
        else
        {
            toaster.Error(res.Message, "Erro");
        }
    }

    protected void GuardarProducto(ProductoModel producto)
    {
        if (string.IsNullOrEmpty(producto.Referencia))
        {
            toaster.Error("Debe escribir la referencia del producto", "Error");
            return;
        }

        if (string.IsNullOrEmpty(producto.Nombre) || producto.Nombre.Length <5)
        {
            toaster.Error("El nombre del producto debe ser mayor a 5 caracteres", "Error");
            return;
        }

        if (producto.Stock == null)
        {
            toaster.Error("Debe escribir el nombre valor del stok", "Error");
            return;
        }

        if (string.IsNullOrEmpty(producto.Costo.ToString()))
        {
            toaster.Error("Debe escribir el costo del producto", "Error");
            return;
        }

        if (string.IsNullOrEmpty(producto.Precio.ToString()))
        {
            toaster.Error("Debe escribir el precio del producto", "Error");
            return;
        }


        var res = productoService.Modificar(producto);

        if (res.IsSuccess)
        {
            toaster.Success(res.Message, "OK");
        }
        else
        {
            toaster.Error(res.Message, "Erro");
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SweetAlertService swal { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToaster toaster { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProductoService productoService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CategoriasService categoriasService { get; set; }
    }
}
#pragma warning restore 1591
