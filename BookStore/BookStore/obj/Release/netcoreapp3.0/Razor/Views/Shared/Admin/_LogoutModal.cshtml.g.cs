#pragma checksum "C:\Other\lessons\c#\BookStoreRepo\BookStore\BookStore\Views\Shared\Admin\_LogoutModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc4e070fe886cc177f766570b1a51b8c5a0c97bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Admin__LogoutModal), @"mvc.1.0.view", @"/Views/Shared/Admin/_LogoutModal.cshtml")]
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
#line 2 "C:\Other\lessons\c#\BookStoreRepo\BookStore\BookStore\Views\_ViewImports.cshtml"
using BookStore.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Other\lessons\c#\BookStoreRepo\BookStore\BookStore\Views\_ViewImports.cshtml"
using BookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc4e070fe886cc177f766570b1a51b8c5a0c97bf", @"/Views/Shared/Admin/_LogoutModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f98c2058f0725a03780f06f171d8f86e8c01f366", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Admin__LogoutModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Other\lessons\c#\BookStoreRepo\BookStore\BookStore\Views\Shared\Admin\_LogoutModal.cshtml"
  
    ViewData["Title"] = "_LogoutModal";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Logout Modal-->
<div class=""modal fade"" id=""logoutModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Ready to Leave?</h5>
                <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body"">Select ""Logout"" below if you are ready to end your current session.</div>
            <div class=""modal-footer"">
                <button class=""btn btn-secondary"" type=""button"" data-dismiss=""modal"">Cancel</button>
                <a class=""btn btn-primary""");
            BeginWriteAttribute("href", " href=\"", 901, "\"", 939, 1);
#nullable restore
#line 19 "C:\Other\lessons\c#\BookStoreRepo\BookStore\BookStore\Views\Shared\Admin\_LogoutModal.cshtml"
WriteAttributeValue("", 908, Url.Action("LogOut","Account"), 908, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Logout</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
