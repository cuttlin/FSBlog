#pragma checksum "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38ca428828247ea8cd28bfd129ce6d6bd27664dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_BlogDetail), @"mvc.1.0.view", @"/Views/Blog/BlogDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Blog/BlogDetail.cshtml", typeof(AspNetCore.Views_Blog_BlogDetail))]
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
#line 1 "D:\github_code\FSBlog\FSBlog\Views\_ViewImports.cshtml"
using FSBlog;

#line default
#line hidden
#line 2 "D:\github_code\FSBlog\FSBlog\Views\_ViewImports.cshtml"
using FSBlog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38ca428828247ea8cd28bfd129ce6d6bd27664dc", @"/Views/Blog/BlogDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fed0f686931c01ca3694dcd49ace88251458c19a", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_BlogDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogDetail.cshtml"
  
    ViewData["Title"] = "BlogDetail";

#line default
#line hidden
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogDetail.cshtml"
   var a = ViewData["textc"].ToString();

#line default
#line hidden
            BeginContext(94, 11, false);
#line 7 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogDetail.cshtml"
Write(Html.Raw(a));

#line default
#line hidden
            EndContext();
            BeginContext(105, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
