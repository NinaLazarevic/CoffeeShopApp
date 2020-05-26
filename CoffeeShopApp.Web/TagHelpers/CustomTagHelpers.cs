using CoffeeShopApp.Business.RepositoryLogic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApp.Web.TagHelpers
{
    [HtmlTargetElement("products-names")]
    public class ProductNamesTagHelper : TagHelper
    {
        private IProductService _productService;

        public ProductNamesTagHelper(IProductService productService)
        {
            _productService = productService;
        }

        public List<Guid> ProductsIds { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ProductNames";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();

            var products = _productService.GetProducts(ProductsIds);

            foreach(var product in products)
            {
                sb.AppendFormat("<div class=\"productName\">{0}</div>", product.Name);
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }

    [HtmlTargetElement("products-checkboxes")]
    public class ProductCheckBoxesTagHelper : TagHelper
    {
        private IProductService _productService;

        public ProductCheckBoxesTagHelper(IProductService productService)
        {
            _productService = productService;
        }

        public List<Guid> ProductsIds { get; set; }

        public string Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ProductCheckBoxes";
            output.TagMode = TagMode.StartTagAndEndTag;

            var allProducts = _productService.GetProducts();

            var sb = new StringBuilder();

            foreach (var product in allProducts)
            {
                var checkedString = "";
                var disabledString = "";
                if (ProductsIds.Contains(product.ProductId))
                {
                    checkedString = "checked";
                }

                if (String.Equals(Action, "Add") && product.DateDeleted != null)
                {
                    disabledString = "disabled";
                }

                sb.AppendFormat("<div class=\"checkbox productName\">" +
                        "<input type=\"checkbox\" id=\"{0}\" name=\"Products\" value=\"{0}\" onclick =changePrice(\"{0}\",{1}) " + checkedString +" "+ disabledString +" >" +
                        "{2}"+
                        " </div>", product.ProductId, product.Price, product.Name);

            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
