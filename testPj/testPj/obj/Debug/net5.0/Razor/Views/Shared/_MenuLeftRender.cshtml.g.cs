#pragma checksum "D:\Base.net\testPj\testPj\Views\Shared\_MenuLeftRender.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3090c28a016d02d41b82e4504a7e711bacb7ee2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MenuLeftRender), @"mvc.1.0.view", @"/Views/Shared/_MenuLeftRender.cshtml")]
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
#line 1 "D:\Base.net\testPj\testPj\Views\_ViewImports.cshtml"
using testPj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Base.net\testPj\testPj\Views\_ViewImports.cshtml"
using testPj.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Base.net\testPj\testPj\Views\Shared\_MenuLeftRender.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3090c28a016d02d41b82e4504a7e711bacb7ee2", @"/Views/Shared/_MenuLeftRender.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbef6cc6da0d021c34bd7b3e894e346c6b2f4d24", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MenuLeftRender : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Base.net\testPj\testPj\Views\Shared\_MenuLeftRender.cshtml"
  
    var currentuser = Context.Items["UserInfo"] as CurrentUserModel;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"left-side-bar\">\r\n    <div class=\"brand-logo\">\r\n        <a href=\"javascript:void(0);\" onclick=\"home()\">\r\n            <img src=\"vendors/images/deskapp-logo.svg\"");
            BeginWriteAttribute("alt", " alt=\"", 281, "\"", 287, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"dark-logo\">\r\n            <img src=\"vendors/images/deskapp-logo-white.svg\"");
            BeginWriteAttribute("alt", " alt=\"", 369, "\"", 375, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""light-logo"">
        </a>
        <div class=""close-sidebar"" data-toggle=""left-sidebar-close"">
            <i class=""ion-close-round""></i>
        </div>
    </div>
    <div class=""menu-block customscroll"">
        <div class=""sidebar-menu"">
            <ul id=""accordion-menu"">
                <li class=""dropdown"">
                    <a href=""javascript:void(0)"" class=""dropdown-toggle"">
                        <span class=""micon dw dw-analytics-21""></span><span class=""mtext"">Chỉ số</span>
                    </a>
                    <ul class=""submenu"">
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(1)"">Revenus</a></li>
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(2)"">DAU</a></li>
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(3)"">NRU</a></li>
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(4)"">ARPD</a></li>
                        <li><a href=""jav");
            WriteLiteral(@"ascript:void(0);"" onclick=""openViewIndex(5)"">ARPU</a></li>
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(6)"">DEVICE</a></li>
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(7)"">LOCATION</a></li>
                    </ul>
                </li>
                <li class=""dropdown"">
                    <a href=""javascript:void(0)"" class=""dropdown-toggle"">
                        <span class=""micon dw dw-gamepad""></span><span class=""mtext"">Game</span>
                    </a>
                    <ul class=""submenu"">
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(8)"">CCU</a></li>
                        <li><a href=""javascript:void(0);"" onclick=""openViewIndex(9)"">ACCOUNT</a></li>
                    </ul>
                </li>
                <li>
                    <a href=""javascript:void(0);"" onclick=""openViewIndex(10)"" class=""dropdown-toggle no-arrow"">
                        <span class=""mico");
            WriteLiteral(@"n dw dw-book""></span><span class=""mtext"">Kế toán</span>
                    </a>
                </li>
                <li>
                    <a href=""javascript:void(0);"" onclick=""openViewIndex(11)"" class=""dropdown-toggle no-arrow"">
                        <span class=""micon dw dw-shop""></span><span class=""mtext"">MM</span>
                    </a>
                </li>
                <li>
                    <a href=""javascript:void(0);"" onclick=""openViewIndex(12)"" class=""dropdown-toggle no-arrow"">
                        <span class=""micon dw dw-user-1""></span><span class=""mtext"">Quản lý tài khoản</span>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</div>
<script>
    function home() {
        window.location.href = ""/Home"";
    }
    function openViewIndex(menu) {
        if (menu === 12) {
            $.ajax({
                method: ""GET"",
                url: ""api/User"",
                success: function (result) {
             ");
            WriteLiteral(@"       $(""#body-root"").html(result);
                }
            });
            //localStorage.removeItem(""id"");
            //localStorage.removeItem(""type"");
            //index.show();
            //create.hide();
            //edit.hide();
            //detail.hide();
            //censorship.hide();
            //sendBrowse.hide();
            //historyLog.hide();
            //setTimeout(function () {
            //    onSearch();
            //}, 100);
            //loadYearDefault();
        }
    }
</script>");
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
