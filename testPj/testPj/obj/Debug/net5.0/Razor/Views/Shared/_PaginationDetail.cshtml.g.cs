#pragma checksum "C:\Users\Admin\Desktop\Base.net\testPj\testPj\Views\Shared\_PaginationDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38f27293082a859ce8afcfa3857278b2b5e8f748"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PaginationDetail), @"mvc.1.0.view", @"/Views/Shared/_PaginationDetail.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Base.net\testPj\testPj\Views\_ViewImports.cshtml"
using testPj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Base.net\testPj\testPj\Views\_ViewImports.cshtml"
using testPj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38f27293082a859ce8afcfa3857278b2b5e8f748", @"/Views/Shared/_PaginationDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbef6cc6da0d021c34bd7b3e894e346c6b2f4d24", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PaginationDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "20", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "30", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "50", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "100", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "200", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table style=""width: 460px; float: right"">
    <caption hidden></caption>
    <thead style=""background:none !important"">
        <tr>
            <th scope=""col"" style=""width: 85px;text-align: center;font-weight:normal"">
                Hiển thị
            </th>
            <th scope=""col"" style=""width: 80px"">
                <select id=""cbPageSizeDetail"" class=""form-control"" onchange=""onReSearchDetail()"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f27293082a859ce8afcfa3857278b2b5e8f7485950", async() => {
                WriteLiteral("5");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f27293082a859ce8afcfa3857278b2b5e8f7487124", async() => {
                WriteLiteral("10");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f27293082a859ce8afcfa3857278b2b5e8f7488382", async() => {
                WriteLiteral("20");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f27293082a859ce8afcfa3857278b2b5e8f7489557", async() => {
                WriteLiteral("30");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f27293082a859ce8afcfa3857278b2b5e8f74810732", async() => {
                WriteLiteral("50");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f27293082a859ce8afcfa3857278b2b5e8f74811908", async() => {
                WriteLiteral("100");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f27293082a859ce8afcfa3857278b2b5e8f74813085", async() => {
                WriteLiteral("200");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </select>
            </th>
            <th scope=""col"" style=""width: 30px"">
            </th>
            <th scope=""col"" style=""width: 15px"">
                <button class=""btn btn-default"" onclick=""btnViewPagesDetail(1)"" id=""btnViewTopPageDetail""><i class=""fa fa-fast-backward"" aria-hidden=""true""></i></button>
            </th>
            <th scope=""col"" style=""width: 15px;padding-right: 10px;"">
                <button class=""btn btn-default"" onclick=""btnNextPagesDetail(-1)"" id=""btnViewPriPageDetail""><i class=""fa fa-backward"" aria-hidden=""true""></i></button>
            </th>
            <th scope=""col"" style=""width: 50px"">
                <input class=""form-control only-number"" id=""txtCurrentPageDetail"" value=""1"" onchange=""onSearchDetail()"" />
            </th>
            <th scope=""col"" style=""width: 15px"" class=""text-center"">
                /
            </th>
            <th scope=""col"" style=""width: 25px;font-weight:normal"" id=""laCountDetail"">
            </th>

");
            WriteLiteral(@"            <th scope=""col"" style=""width: 15px"">
                <button class=""btn btn-default"" onclick=""btnNextPagesDetail(1)"" id=""btnViewNextPageDetail""><i class=""fa fa-forward"" aria-hidden=""true""></i></button>
            </th>
            <th scope=""col"" style=""width: 15px"">
                <button class=""btn btn-default"" onclick=""btnViewPagesDetail(maxPagesDetail)"" id=""btnViewLastPageDetail""><i class=""fa fa-fast-forward"" aria-hidden=""true""></i></button>
            </th>
            <th scope=""col""></th>
        </tr>
    </thead>
</table>
<script type=""text/javascript"">
    var dataListDetail = {};
    dataListDetail.Total = 0;
    dataListDetail.Sum = 0;
    var maxPagesDetail = 1;

    function reCalculatPagesCustomDetail(total) {
        
        dataListDetail.Total = total;
        var size = parseInt($(""#cbPageSizeDetail"").val());
        var byBlock = parseInt(dataListDetail.Total / size);
        var byAdd = dataListDetail.Total % size > 0 ? 1 : 0;
        maxPagesDetail =");
            WriteLiteral(@" byBlock + byAdd;
        $(""#laCountDetail"").text(maxPagesDetail);
        $(""#rqSumValueDetail"").text(formatNumberByLocate(dataListDetail.Sum));
    }
    function reCalculatPagesCustomNullDetail() {
        document.getElementById(""btnViewTopPageDetail"").disabled = true;
        document.getElementById(""btnViewPriPageDetail"").disabled = true;
        document.getElementById(""btnViewNextPageDetail"").disabled = true;
        document.getElementById(""btnViewLastPageDetail"").disabled = true;
    }

    function reCalculatPagesDetail() {
        var size = parseInt($(""#cbPageSizeDetail"").val());
        var byBlock = parseInt(dataListDetail.Total / size);
        var byAdd = dataListDetail.Total % size > 0 ? 1 : 0;
        maxPagesDetail = byBlock + byAdd;
        $(""#laCountDetail"").text(formatNumberByLocate(maxPagesDetail));
        $(""#rqSumValueDetail"").text(formatNumberByLocate(dataListDetail.Sum));
    }

    function btnNextPagesDetail(isAdd) {
        
        var currentPageDetail");
            WriteLiteral(@" = parseInt($(""#txtCurrentPageDetail"").val());
        currentPageDetail += isAdd;
        if (currentPageDetail <= 1)
            currentPageDetail = 1;
        if (currentPageDetail >= maxPagesDetail)
            currentPageDetail = maxPagesDetail;

        btnViewPagesDetail(currentPageDetail)
    }
    function btnViewPagesDetail(page) {
        $(""#txtCurrentPageDetail"").val(page)
        onSearchDetail();
    }
    function onReSearchDetail() {
        $(""#txtCurrentPageDetail"").val(1)
        onSearchDetail();
    }
    function viewBtnActionPageDetail() {
        
        var currentPageDetail = parseInt($(""#txtCurrentPageDetail"").val());
        document.getElementById(""btnViewTopPageDetail"").disabled = false;
        document.getElementById(""btnViewPriPageDetail"").disabled = false;
        document.getElementById(""btnViewNextPageDetail"").disabled = false;
        document.getElementById(""btnViewLastPageDetail"").disabled = false;
        if (currentPageDetail == 1) {
        ");
            WriteLiteral(@"    document.getElementById(""btnViewTopPageDetail"").disabled = true;
            document.getElementById(""btnViewPriPageDetail"").disabled = true;
        }
        if (currentPageDetail == maxPagesDetail) {
            document.getElementById(""btnViewNextPageDetail"").disabled = true;
            document.getElementById(""btnViewLastPageDetail"").disabled = true;
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
