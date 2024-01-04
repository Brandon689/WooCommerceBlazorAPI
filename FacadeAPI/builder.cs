using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.Media;
using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace FacadeAPI
{
    public class ProductBuilder
    {
        private Product product = new Product();


        public ProductBuilder CreateProductAsync(string name, string type, string regularPrice)
        {
            product = new Product
            {
                Request = new ProductRequest
                {
                    Name = name,
                    Type = type,
                    RegularPrice = regularPrice,
                    Images = new ProductImage[] { new ProductImage() { Id = 50413 } }
                }
            };
            return this;
        }


        //public ProductBuilder WithVariation(Variation variation)
        //{
        //    if (product.Variations == null)
        //        product.Variations = new List<Variation>();

        //    product.Variations.Add(variation);
        //    return this;
        //}

        public Product Build()
        {
            return product;
        }
    }











    public class ProductAttributeBuilder
    {
        private ProductAttribute attribute = new ProductAttribute();

        public ProductAttributeBuilder WithName(string name)
        {
            attribute.Name = name;
            return this;
        }

        public ProductAttributeBuilder WithVariation(bool variation)
        {
            attribute.Variation = variation;
            return this;
        }

        public ProductAttributeBuilder WithOptions(params string[] options)
        {
            attribute.Options = options;
            return this;
        }

        public ProductAttribute Build()
        {
            return attribute;
        }
    }

    //public class ProductVariationBuilder
    //{
    //    private ProductVariation variation = new ProductVariation();

    //    public ProductVariationBuilder WithRegularPrice(string price)
    //    {
    //        variation.RegularPrice = price;
    //        return this;
    //    }

    //    public ProductVariationBuilder WithAttribute(ProductVariationAttribute attribute)
    //    {
    //        if (variation.Attributes == null)
    //            variation.Attributes = new List<ProductVariationAttribute>();

    //        variation.Attributes.Add(attribute);
    //        return this;
    //    }

    //    public ProductVariationBuilder WithImage(MediaItemRequest image)
    //    {
    //        variation.Image = image;
    //        return this;
    //    }

    //    public ProductVariation Build()
    //    {
    //        return variation;
    //    }
    //}









}
