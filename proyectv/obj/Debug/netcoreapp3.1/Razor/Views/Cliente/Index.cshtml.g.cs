#pragma checksum "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e42442b4503074c95682457710a80c386f4f97fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_Index), @"mvc.1.0.view", @"/Views/Cliente/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e42442b4503074c95682457710a80c386f4f97fd", @"/Views/Cliente/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5526e83e581477299e889a27abd345158a0f9f2b", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<proyectv.Models.Productos>>
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
#line 2 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.messaged))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        alert(\"");
#nullable restore
#line 5 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
          Write(ViewBag.messaged);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n    </script>\r\n");
#nullable restore
#line 7 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.error))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        alert(\"");
#nullable restore
#line 11 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
          Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n    </script>\r\n");
#nullable restore
#line 13 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e42442b4503074c95682457710a80c386f4f97fd6325", async() => {
                WriteLiteral(@"
    <link href=""https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"" rel=""stylesheet"" />
    <script src=""https://code.jquery.com/jquery-3.5.1.min.js""></script>
    <script src=""https://kit.fontawesome.com/3f88322c46.js"" crossorigin=""anonymous""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e42442b4503074c95682457710a80c386f4f97fd6888", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e42442b4503074c95682457710a80c386f4f97fd8066", async() => {
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
#line 21 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
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
    <span class=""navbar-text d-flex ml-auto mr-2 text-light"">$");
#nullable restore
#line 32 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
                                                         Write(ViewData["valor_a_pagar"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("<i class=\"fa fa-shopping-cart mr-2 ml-2 text-light fa-fw\" style=\"font-size: 25px;\" aria-hidden=\"true\"></i></span>\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 1444, "\"", 1493, 2);
            WriteAttributeValue("", 1450, "/img/profilesimg/", 1450, 17, true);
#nullable restore
#line 33 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
WriteAttributeValue("", 1467, ViewData["imagen_perfil"], 1467, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n         width=\"50\" height=\"50\" style=\"min-height: 50px; max-height: 50px;min-width: 50px; max-width: 50px;\" class=\"mr-3 rounded-circle img-thumbnail shadow-sm img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 1666, "\"", 1672, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\">\r\n</nav>\r\n<!--End horizontal navbar-->\r\n<!-- Vertical navbar -->\r\n<div class=\"vertical-nav bg-dark\" id=\"sidebar\">\r\n    <div class=\"py-4 px-3 mb-4 bg-dark\">\r\n        <div class=\"media d-flex align-items-center\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 1917, "\"", 1966, 2);
            WriteAttributeValue("", 1923, "/img/profilesimg/", 1923, 17, true);
#nullable restore
#line 41 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
WriteAttributeValue("", 1940, ViewData["imagen_perfil"], 1940, 26, false);

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
#nullable restore
#line 109 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
         if (ViewData["estado_tienda"].ToString() != "")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"text-light mx-auto my-auto\">");
#nullable restore
#line 110 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
                                           Write(ViewData["estado_tienda"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>");
#nullable restore
#line 110 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
                                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 112 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
           int counter = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 114 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
         foreach (var item in Model)
        {
            if (Convert.ToInt32(item.cantidad_producto) != 0)
            {
                if ((counter % 3) == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"w-100\"></div>\r\n");
#nullable restore
#line 121 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col mb-4 manito text-light\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5423, "\"", 5510, 4);
            WriteAttributeValue("", 5433, "location.href", 5433, 13, true);
            WriteAttributeValue(" ", 5446, "=\'/DetallesProducto?id=", 5447, 24, true);
#nullable restore
#line 122 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
WriteAttributeValue("", 5470, Html.DisplayFor(modelItem => item.id), 5470, 38, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5508, "\';", 5508, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"card h-100 bg-dark\" style=\"max-width:234px;padding:0.6rem;\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 5636, "\"", 5710, 2);
            WriteAttributeValue("", 5642, "/img/productsimg/", 5642, 17, true);
#nullable restore
#line 124 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
WriteAttributeValue("", 5659, Html.DisplayFor(modelItem => item.imagen_producto), 5659, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top img-thumbnail img-fluid\"\r\n                             style=\"min-height: 185px; max-height: 185px; max-width: 240px;\"");
            BeginWriteAttribute("alt", " alt=\"", 5850, "\"", 5907, 1);
#nullable restore
#line 125 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
WriteAttributeValue("", 5856, Html.DisplayFor(modelItem => item.nombre_producto), 5856, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <div class=\"card-body text-center\">\r\n                            <h5 class=\"card-title\">");
#nullable restore
#line 127 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.nombre_producto));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <h6 class=\"card-subtitle\">$");
#nullable restore
#line 128 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.precio_producto));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 132 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\Cliente\Index.cshtml"
            }
            counter++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n</div>\r\n<!-- End demo content -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<proyectv.Models.Productos>> Html { get; private set; }
    }
}
#pragma warning restore 1591