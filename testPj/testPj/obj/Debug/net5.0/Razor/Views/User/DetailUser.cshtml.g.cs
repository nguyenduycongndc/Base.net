#pragma checksum "C:\Users\Admin\Desktop\Base.net\testPj\testPj\Views\User\DetailUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fe0bd4ff47c6eb7a141e8773f6474f59e124aee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_DetailUser), @"mvc.1.0.view", @"/Views/User/DetailUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fe0bd4ff47c6eb7a141e8773f6474f59e124aee", @"/Views/User/DetailUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbef6cc6da0d021c34bd7b3e894e346c6b2f4d24", @"/Views/_ViewImports.cshtml")]
    public class Views_User_DetailUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetailModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form_update_item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form_update_item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""modal fade"" id=""DetailUser"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-md"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel""><i class=""fa fa-fw fa-shopping-cart""></i>Sửa</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fe0bd4ff47c6eb7a141e8773f6474f59e124aee4617", async() => {
                WriteLiteral(@"
                    <div class="" row col-lg-12 col-md-12 col-12"">
                        <div class=""col-lg-12 col-md-12 col-12 row"">
                            <div class=""col-md-4 col-4 mt-3"">
                                <label class=""text-dark"">Tên người dùng</label>
                            </div>
                            <div class=""col-md-8 col-8 mt-3"">
                                services.AddScoped<IUserRepo, LoginRepo>
                                    ();
                                    <input type=""text"" class=""form-control"" id=""editName"" name=""title"" placeholder=""Tên người dùng""");
                BeginWriteAttribute("value", " value=\"", 1333, "\"", 1356, 1);
#nullable restore
#line 23 "C:\Users\Admin\Desktop\Base.net\testPj\testPj\Views\User\DetailUser.cshtml"
WriteAttributeValue("", 1341, Model.UserName, 1341, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            </div>
                            <div class=""col-md-4 col-4 mt-3"">
                                <label class=""text-dark"">Mật khẩu</label>
                            </div>
                            <div class=""col-md-8 col-8 mt-3"">
                                <input type=""password"" class=""form-control"" id=""editPass"" name=""title"" placeholder=""Mật khẩu"" value=""*********""hidden>
                            </div>
                        </div>

                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"modal-footer\">\r\n                <button type=\"button\" class=\"btn btn-outline-secondary\" data-dismiss=\"modal\">Đóng</button>\r\n                <button type=\"button\" class=\"btn btn-primary px-3\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2142, "\"", 2172, 3);
            WriteAttributeValue("", 2152, "SaveEdit(", 2152, 9, true);
#nullable restore
#line 38 "C:\Users\Admin\Desktop\Base.net\testPj\testPj\Views\User\DetailUser.cshtml"
WriteAttributeValue("", 2161, Model.Id, 2161, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2170, ");", 2170, 2, true);
            EndWriteAttribute();
            WriteLiteral(@">Lưu</button>
            </div>
        </div>
    </div>
</div>


<script type=""text/javascript"">
    function SaveEdit(Id) {
        var editName = $('#editName').val()
        var editPass = $('#editPass').val()
        debugger;
        if (editName == """" || editPass == """") {
            swal({
                title: ""Thông báo"",
                text: ""Vui lòng nhập đầy đủ thông tin!"",
                icon: ""warning""
            })
            return;
        } else {
            $.ajax({
                url: '/Home/Update',
                type: ""PUT"",
                dataType: ""json"",
                contentType: 'application/json',
                data: JSON.stringify({
                    Id: Id,
                    Name: editName,
                    Password: editPass,
                }),
                //data: {
                //    Id: Id,
                //    Name: editName,
                //    Password: editPass,
                //},
                succe");
            WriteLiteral(@"ss: function (response) {
                    if (response == true) {
                        swal({
                            title: ""Thành công!"",
                            text: """",
                            icon: ""success""
                        });
                        $('#DetailUser').modal('hide');
                        window.location = ""/Home/listUser"";
                    }
                    else {
                        swal({
                            title: ""Có lỗi xảy ra!"",
                            text: ""Không thể sửa."",
                            icon: ""warning""
                        });
                    }
                },
                error: function (result) {
                }
            });
        }
    };
</script>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
