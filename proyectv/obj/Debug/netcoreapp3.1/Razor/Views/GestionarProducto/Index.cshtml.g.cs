#pragma checksum "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96d61bcc53fc5c41db02859a057342f16c08e972"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GestionarProducto_Index), @"mvc.1.0.view", @"/Views/GestionarProducto/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\_ViewImports.cshtml"
using proyectv;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\_ViewImports.cshtml"
using proyectv.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96d61bcc53fc5c41db02859a057342f16c08e972", @"/Views/GestionarProducto/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5526e83e581477299e889a27abd345158a0f9f2b", @"/Views/_ViewImports.cshtml")]
    public class Views_GestionarProducto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/stye1.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/custom.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("names", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.messaged))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        alert(\"");
#nullable restore
#line 4 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
          Write(ViewBag.messaged);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n    </script>\r\n");
#nullable restore
#line 6 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.error))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        alert(\"");
#nullable restore
#line 10 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
          Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n    </script>\r\n");
#nullable restore
#line 12 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96d61bcc53fc5c41db02859a057342f16c08e9726404", async() => {
                WriteLiteral(@"
    <link href=""https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"" rel=""stylesheet"" />
    <script src=""https://code.jquery.com/jquery-3.5.1.min.js""></script>
    <script src=""https://kit.fontawesome.com/3f88322c46.js"" crossorigin=""anonymous""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "96d61bcc53fc5c41db02859a057342f16c08e9726967", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96d61bcc53fc5c41db02859a057342f16c08e9728145", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>let nombre = \"");
#nullable restore
#line 20 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
                     Write(ViewData["nombre"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";</script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Names = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<!--Horizontal navbar-->
<nav class=""navbar navbar-dark bg-dark"">
    <div class=""navbar-brand"" href=""#"">
        <!-- Toggle button -->
        <button id=""sidebarCollapse"" type=""button"" class=""btn btn-dark px-3"">
            <i class=""fa fa-bars mr-2""
               style=""font-size: 30px;""></i><small class=""text-uppercase font-weight-bold""> </small>
        </button>
    </div>
    <img");
            BeginWriteAttribute("src", " src=\"", 1194, "\"", 1243, 2);
            WriteAttributeValue("", 1200, "/img/profilesimg/", 1200, 17, true);
#nullable restore
#line 31 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
WriteAttributeValue("", 1217, ViewData["imagen_perfil"], 1217, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n         width=\"50\" height=\"50\" style=\"min-height: 50px; max-height: 50px;min-width: 50px; max-width: 50px;\" class=\"mr-3 rounded-circle img-thumbnail shadow-sm img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 1416, "\"", 1422, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\">\r\n</nav>\r\n<!--End horizontal navbar-->\r\n<!-- Vertical navbar -->\r\n<div class=\"vertical-nav bg-dark\" id=\"sidebar\">\r\n    <div class=\"py-4 px-3 mb-4 bg-dark\">\r\n        <div class=\"media d-flex align-items-center\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 1667, "\"", 1716, 2);
            WriteAttributeValue("", 1673, "/img/profilesimg/", 1673, 17, true);
#nullable restore
#line 39 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
WriteAttributeValue("", 1690, ViewData["imagen_perfil"], 1690, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                 alt=""Foto de perfil"" height=""63"" width=""63"" style=""min-height: 63px; max-height: 63px;min-width: 63px; max-width: 63px;"" class=""mr-3 rounded-circle img-thumbnail shadow-sm img-fluid"">
            <div class=""media-body"">
                <h4 id=""DBNombre2"" class=""m-0 text-light"">
                    <script>if (nombre.indexOf("" "") == -1) { document.getElementById(""DBNombre2"").innerHTML = nombre.substring(-1, 8); } else { document.getElementById(""DBNombre2"").innerHTML = nombre.substring(-1, 8) + "".""; }</script>
                </h4>
                <p class=""font-weight-light text-muted mb-0"">Comprador</p>
            </div>
        </div>
    </div>

    <p class=""text-gray bg-dark font-weight-bold text-uppercase px-3 small pb-4 mb-0"">Productos</p>

    <ul class=""nav flex-column bg-white mb-0"">
        <li class=""nav-item"">
            <a href=""/Cliente"" class=""nav-link text-light font-italic bg-dark"">
                <i class=""fa fa-store mr-3 text-primary fa-fw""></i>
     ");
            WriteLiteral(@"           Comprar
            </a>
        </li>
        <li class=""nav-item"">
            <a href=""/CarritoActual"" class=""nav-link text-light font-italic bg-dark"">
                <i class=""fa fa-shopping-cart mr-3 text-primary fa-fw""></i>
                Mi carrito
            </a>
        </li>
        <li class=""nav-item"">
            <a href=""/MisProductos"" class=""nav-link text-light bg-dark font-italic"">
                <i class=""fa fa-shopping-bag mr-3 bg-dark text-primary fa-fw""></i>
                Adquiridos
            </a>
        </li>
    </ul>

    <p class=""text-gray font-weight-bold text-uppercase px-3 small py-4 mb-0"">Perfil</p>

    <ul class=""nav flex-column bg-dark mb-0"">
        <li class=""nav-item"">
            <a href=""/CambiarFotoPerfilC"" class=""nav-link text-light bg-dark font-italic"">
                <i class=""fa fa-id-badge mr-3 text-primary fa-fw""></i>
                Cambiar foto
            </a>
        </li>
        <li class=""nav-item"">
            ");
            WriteLiteral(@"<a href=""/CambiarCorreoC"" class=""nav-link text-light bg-dark font-italic"">
                <i class=""fa fa-envelope mr-3 text-primary fa-fw""></i>
                Cambiar correo
            </a>
        </li>
        <li class=""nav-item"">
            <a href=""/CambiarContrasenaC"" class=""nav-link text-light bg-dark font-italic"">
                <i class=""fa fa-lock mr-3 text-primary fa-fw""></i>
                Cambiar contraseña
            </a>
        </li>
        <li class=""nav-item"">
            <a href=""/Logout"" class=""nav-link text-light bg-info font-italic"">
                <i class=""fa fa-sign-out mr-3 text-black-50 fa-fw""></i>
                Cerrar sesión
            </a>
        </li>
    </ul>
</div>
<!-- End vertical navbar -->
<!-- Page content holder -->
<div class=""page-content p-5 text-black"" id=""content"">
    <div class=""row row-cols-1 row-cols-md-3"">
");
            WriteLiteral("        <div class=\"card mb-3 mx-auto p-3\" style=\"max-height: 472px;min-width: 100%;\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 4795, "\"", 4846, 2);
            WriteAttributeValue("", 4801, "/img/productsimg/", 4801, 17, true);
#nullable restore
#line 108 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
WriteAttributeValue("", 4818, ViewData["imagen_producto"], 4818, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-left\" height=\"330\" width=\"330\"");
            BeginWriteAttribute("alt", " alt=\"", 4894, "\"", 4928, 1);
#nullable restore
#line 108 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
WriteAttributeValue("", 4900, ViewData["nombre_producto"], 4900, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p class=\"pt-2 text-center\" style=\"width: 330px;\"><small class=\"text-muted\">Unidades disponibles: <b>");
#nullable restore
#line 109 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
                                                                                                            Write(ViewData["cantidad_producto"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></small></p>\r\n            <div class=\"card-body position-relative\" style=\"top: -351px;right: -60%;width: 37%;\">\r\n                <h2 class=\"card-title text-center\">");
#nullable restore
#line 111 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
                                              Write(ViewData["nombre_producto"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <hr>\r\n                <h6 class=\"card-subtitle text-center\"><b>Precio:</b> $");
#nullable restore
#line 113 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
                                                                 Write(ViewData["precio_producto"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <hr>\r\n                <h6 class=\"text-center\"><b>Descripción: </b></h6>\r\n                <p class=\"card-text text-center\">");
#nullable restore
#line 116 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
                                            Write(ViewData["descripcion_producto"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <hr>\r\n                <b style=\"float: left;width: 45%;padding: 10px 0 18px 0;\" class=\"card-subtitle text-center\">Unidades:</b>\r\n                <input type=\"number\" id=\"inputQuantity\" min=\"1\"");
            BeginWriteAttribute("max", " max=\"", 5790, "\"", 5826, 1);
#nullable restore
#line 119 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
WriteAttributeValue("", 5796, ViewData["cantidad_producto"], 5796, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control mb-2 text-center"" name=""idproducto"" value=""1"" required style=""float: right;width: 45%;"">
                <a class=""btn btn-info"" href=""/Cliente"" style=""width: 45%;float: left;"">Regresar</a>
                <a class=""btn btn-success text-light"" id=""AddCarrito""");
            BeginWriteAttribute("onclick", " onclick=\"", 6109, "\"", 6234, 3);
            WriteAttributeValue("", 6119, "window.location.href=\'/AddCarrito?id=", 6119, 37, true);
#nullable restore
#line 121 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GestionarProducto\Index.cshtml"
WriteAttributeValue("", 6156, ViewData["id_producto"], 6156, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6180, "&qnt=\'+document.getElementById(\'inputQuantity\').value;", 6180, 54, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"float: right;width: 45%;\">Añadir al carrito</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            WriteLiteral("</div>\r\n<!-- End demo content -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591