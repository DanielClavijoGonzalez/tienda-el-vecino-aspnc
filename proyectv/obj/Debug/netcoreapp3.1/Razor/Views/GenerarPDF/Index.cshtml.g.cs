#pragma checksum "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "407e108cf4ac353bc4ce858e92a6b024f275f3cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GenerarPDF_Index), @"mvc.1.0.view", @"/Views/GenerarPDF/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"407e108cf4ac353bc4ce858e92a6b024f275f3cb", @"/Views/GenerarPDF/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5526e83e581477299e889a27abd345158a0f9f2b", @"/Views/_ViewImports.cshtml")]
    public class Views_GenerarPDF_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<proyectv.Models.ProductosAdquiridos>>
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
#line 2 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.messaged))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        alert(\"");
#nullable restore
#line 5 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
          Write(ViewBag.messaged);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n    </script>\r\n");
#nullable restore
#line 7 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.error))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        alert(\"");
#nullable restore
#line 11 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
          Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n    </script>\r\n");
#nullable restore
#line 13 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "407e108cf4ac353bc4ce858e92a6b024f275f3cb6368", async() => {
                WriteLiteral(@"
    <link href=""https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"" rel=""stylesheet"" />
    <script src=""https://code.jquery.com/jquery-3.5.1.min.js""></script>
    <script src=""https://kit.fontawesome.com/3f88322c46.js"" crossorigin=""anonymous""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "407e108cf4ac353bc4ce858e92a6b024f275f3cb6931", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "407e108cf4ac353bc4ce858e92a6b024f275f3cb8109", async() => {
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
#line 20 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
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
            WriteLiteral("\r\n");
            WriteLiteral("<!--Horizontal navbar-->\r\n<!-- Page content holder -->\r\n<div class=\"page-content p-5 text-black\" id=\"content\">\r\n    <div class=\"row row-cols-1 row-cols-md-3 border p-4\">\r\n");
            WriteLiteral("\r\n        <h1 class=\"text-white d-block mx-auto mb-4\">Estas son todas las ventas realizadas:</h1>\r\n\r\n");
#nullable restore
#line 31 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
           int counter = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
         foreach (var item in Model)
        {
            if ((counter % 3) == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"w-100\"></div>\r\n");
#nullable restore
#line 38 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col mb-4 text-light\" style=\"cursor: default!important;\">\r\n                <div class=\"card h-100 bg-dark\" style=\"max-width:234px;padding:0.6rem;\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1531, "\"", 1615, 2);
            WriteAttributeValue("", 1537, "/img/productsimg/", 1537, 17, true);
#nullable restore
#line 41 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
WriteAttributeValue("", 1554, Html.DisplayFor(modelItem => item.imagen_producto_adquirido), 1554, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top img-thumbnail img-fluid\"\r\n                         style=\"min-height: 185px; max-height: 185px; max-width: 240px;\"");
            BeginWriteAttribute("alt", " alt=\"", 1751, "\"", 1818, 1);
#nullable restore
#line 42 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
WriteAttributeValue("", 1757, Html.DisplayFor(modelItem => item.nombre_producto_adquirido), 1757, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"card-body text-center\">\r\n                        <h5 class=\"card-title\" style=\"height:20%\">");
#nullable restore
#line 44 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
                                                             Write(Html.DisplayFor(modelItem => item.nombre_producto_adquirido));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <h6 class=\"card-subtitle\" style=\"height:20%\">$");
#nullable restore
#line 45 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
                                                                 Write(Html.DisplayFor(modelItem => item.valor_total_pagado));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <small class=\"text-light d-block\" style=\"height:20%\">Unidades: <span class=\"text-warning\">");
#nullable restore
#line 46 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
                                                                                                             Write(Html.DisplayFor(modelItem => item.cantidad_producto_adquirido));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></small>\r\n                        <small style=\"height: 20%\">Fecha de compra</small>\r\n                        <input class=\"form-control mr-sm-2 d-inline mx-auto mt-2 text-center\" type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 2519, "\"", 2647, 5);
#nullable restore
#line 48 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
WriteAttributeValue("", 2527, Html.DisplayFor(modelItem => item.anio), 2527, 40, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2567, "-", 2567, 1, true);
#nullable restore
#line 48 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
WriteAttributeValue("", 2568, Html.DisplayFor(modelItem => item.mes), 2568, 39, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2607, "-", 2607, 1, true);
#nullable restore
#line 48 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
WriteAttributeValue("", 2608, Html.DisplayFor(modelItem => item.dia), 2608, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 20%\" onkeydown=\"return false\" onclick=\"return false\">\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 52 "C:\Users\00912\Desktop\CODIGO GENERAL\C#\WEB\proyecto\Proyecto ventas\proyectv\proyectv\Views\GenerarPDF\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<proyectv.Models.ProductosAdquiridos>> Html { get; private set; }
    }
}
#pragma warning restore 1591
