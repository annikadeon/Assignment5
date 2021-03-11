using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Models.ViewModels;

namespace WaterProject.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
        //inherit from tag helper class
    {
        private IUrlHelperFactory urlHelperFactory;

        //constrctor, pass in a parameter and set the pravate variable
        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }
        //create properties and attach attributes
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        //group properties with common prefix
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        //overloading method- different method when passed in
        //override- override with what we pass in
        //override process of taghelper
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                //instance of object
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["pageNum"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction,
                    PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    //if i= page model, then, otherwise (if statement)
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());
                //append to html
                result.InnerHtml.AppendHtml(tag);
            }
            //build pages in a div
            output.Content.AppendHtml(result.InnerHtml);
        }


    }
}
