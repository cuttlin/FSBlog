#pragma checksum "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a2cd2abfe663e077ed1d8f12fb3b85f28dcc77a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_BlogList), @"mvc.1.0.view", @"/Views/Blog/BlogList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Blog/BlogList.cshtml", typeof(AspNetCore.Views_Blog_BlogList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a2cd2abfe663e077ed1d8f12fb3b85f28dcc77a", @"/Views/Blog/BlogList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fed0f686931c01ca3694dcd49ace88251458c19a", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_BlogList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blog>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
  
    ViewData["Title"] = "遇上彩虹";

#line default
#line hidden
            BeginContext(59, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a2cd2abfe663e077ed1d8f12fb3b85f28dcc77a3535", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(114, 117, true);
            WriteLiteral("\r\n\r\n<div class=\"filter\">\r\n    <input type=\"radio\" id=\"tag-0\" class=\"filter-tag\" name=\"filter-radio\" hidden checked>\r\n");
            EndContext();
#line 9 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
     for (int i = 1; i <= Convert.ToInt32(ViewData["categoryCount"]); i++)
    {

#line default
#line hidden
            BeginContext(314, 27, true);
            WriteLiteral("        <input type=\"radio\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 341, "\"", 352, 2);
            WriteAttributeValue("", 346, "tag-", 346, 4, true);
#line 11 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
WriteAttributeValue("", 350, i, 350, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(353, 49, true);
            WriteLiteral(" class=\"filter-tag\" name=\"filter-radio\" hidden>\r\n");
            EndContext();
#line 12 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
    }

#line default
#line hidden
            BeginContext(409, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 13 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
       Dictionary<int, string> dic = ViewData["dic"] as Dictionary<int, string>;
        Dictionary<string, int> rdic = ViewData["rdic"] as Dictionary<string, int>;
    

#line default
#line hidden
            BeginContext(583, 85, true);
            WriteLiteral("\r\n    <div class=\"filter-nav\">\r\n        <label class=\"chip\" for=\"tag-0\">All</label>\r\n");
            EndContext();
#line 19 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
         for (int j = 1; j <= Convert.ToInt32(ViewData["categoryCount"]); j++)
        {

#line default
#line hidden
            BeginContext(759, 31, true);
            WriteLiteral("            <label class=\"chip\"");
            EndContext();
            BeginWriteAttribute("for", " for=\"", 790, "\"", 802, 2);
            WriteAttributeValue("", 796, "tag-", 796, 4, true);
#line 21 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
WriteAttributeValue("", 800, j, 800, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(803, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(805, 6, false);
#line 21 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
                                        Write(dic[j]);

#line default
#line hidden
            EndContext();
            BeginContext(811, 10, true);
            WriteLiteral("</label>\r\n");
            EndContext();
#line 22 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
        }

#line default
#line hidden
            BeginContext(832, 45, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"filter-body\">\r\n");
            EndContext();
#line 26 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
         foreach (var item in Model)
        {
            //string k = rdic[item.Category].ToString();



#line default
#line hidden
            BeginContext(988, 56, true);
            WriteLiteral("            <div class=\"filter-item card\" data-tag=\"tag-");
            EndContext();
            BeginContext(1045, 19, false);
#line 31 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
                                                   Write(rdic[item.Category]);

#line default
#line hidden
            EndContext();
            BeginContext(1064, 188, true);
            WriteLiteral("\">\r\n                <!-- Filter item content -->\r\n\r\n\r\n                <div class=\"card\">\r\n                    <div class=\"card-header\">\r\n                        <div class=\"card-title h5\">");
            EndContext();
            BeginContext(1253, 9, false);
#line 37 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
                                              Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1262, 69, true);
            WriteLiteral("</div>\r\n                        <div class=\"card-subtitle text-gray\">");
            EndContext();
            BeginContext(1332, 13, false);
#line 38 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
                                                        Write(item.Category);

#line default
#line hidden
            EndContext();
            BeginContext(1345, 381, true);
            WriteLiteral(@"</div>
                    </div>
                    <div class=""card-body"">
                        linux发音五花八门版本颇多，见到和听到的不下10种。根据linux的创始人Linus Torvalds的说法，Linux的发音和“Minix”是押韵的。“Li”中“i”的发音类似于“Minix”中“i”的发音，而“nux”中“u”的发音类似于英文单词“profess”中“o”的发音。
                    </div>
                    <div class=""card-footer"">
                        <button class=""btn btn-primary""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1726, "\"", 1753, 3);
            WriteAttributeValue("", 1736, "alltext(", 1736, 8, true);
#line 44 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
WriteAttributeValue("", 1744, item.Id, 1744, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 1752, ")", 1752, 1, true);
            EndWriteAttribute();
            BeginContext(1754, 90, true);
            WriteLiteral(">阅读全文</button>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n");
            EndContext();
#line 49 "D:\github_code\FSBlog\FSBlog\Views\Blog\BlogList.cshtml"
        }

#line default
#line hidden
            BeginContext(1855, 191, true);
            WriteLiteral("\r\n        <!-- Filter items -->\r\n    </div>\r\n</div>\r\n<script type=\"text/javascript\">\r\n    function alltext(id) {\r\n        window.location.href = \"/Blog/BlogDetail?id=\" + id;\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blog>> Html { get; private set; }
    }
}
#pragma warning restore 1591
