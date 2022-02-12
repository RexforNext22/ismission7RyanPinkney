// Author Ryan Pinkney
// This is my pagnination taag helper logic

using System;
using ismission7RyanPinkney.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ismission7RyanPinkney.Infrastructure
{
    // Build the Tag helper
    [HtmlTargetElement("div", Attributes = "page-blah-model")]
    public class PaginationTagHelper : TagHelper
    {

        // Dynamically create the page link

        // Create the Url Helper Factory
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        // Bring in the View Context
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        // Bring in our Page info models and set the action
        public PageInfo PageBlahModel { get; set; }
        public string PageAction { get; set; }


        // Stuff for styling
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        // Override the basic template
        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");


            for (int iCount = 1; iCount <= PageBlahModel.iTotalPages; iCount++)
            {

                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { iPageNum = iCount });

                // Use the tag helper to store properties about the styling
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(iCount == PageBlahModel.iCurrentPage
                        ? PageClassSelected : PageClassNormal);
                }



                // Assign the construct link chain back to the html
                tb.InnerHtml.Append(iCount.ToString());
                final.InnerHtml.AppendHtml(tb);

            }

            // Append the output of the html
            tho.Content.AppendHtml(final.InnerHtml);


        }





    }




}
