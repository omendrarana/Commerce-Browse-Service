
namespace Commerce.Browse.Service.Domain.Models
{   /// <summary>
    /// Represents a product model.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// the unique identifier for the product.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// the identifier specific to Wegmans for the product.
        /// </summary>
        public string WegmansId { get; set; }

        /// <summary>
        /// the identifier for the store associated with the product.
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// the version number of the product.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// the Stock Keeping Unit identifier for the product.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// the price information for the product based on a specific unit of measurement.
        /// </summary>
        public object UnitPrice { get; set; }

        /// <summary>
        /// the base price information for the product based on a specific unit of measurement.
        /// </summary>
        public Price BasePrice { get; set; }

        /// <summary>
        /// the name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// the description of the product.
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// a list of categories to which the product belongs.
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// the URL of the image associated with the product.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// a list of brands associated with the product.
        /// </summary>
        public List<string> Brands { get; set; }

        /// <summary>
        /// the aisle location of the product in the store.
        /// </summary>
        public string Aisle { get; set; }

        /// <summary>
        /// a list of tags associated with the product.
        /// </summary>
        public List<object> Tags { get; set; }

        /// <summary>
        /// the ingredients used in the product.
        /// </summary>
        public string Ingredients { get; set; }

        /// <summary>
        /// the size information of the product item.
        /// </summary>
        public string ItemSize { get; set; }

        /// <summary>
        /// a value indicating whether the product is an alcoholic item.
        /// </summary>
        public bool isAlcoholicItem { get; set; }

        /// <summary>
        /// a value indicating whether the product is sold by weight.
        /// </summary>
        public bool IsSoldByWeight { get; set; }

        /// <summary>
        /// additional parameters related to ordering the product.
        /// </summary>
        public object OrderParameter { get; set; }
    }

    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// the unique identifier for the category.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the Search Engine Optimization (SEO) information related to the category.
        /// </summary>
        public string Seo { get; set; }
    }

    /// <summary>
    /// Represents price information.
    /// </summary>
    public class Price
    {
        /// <summary>
        /// the unit of measurement for the price.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// the actual price value.
        /// </summary>
        public float price { get; set; }

        /// <summary>
        /// fractional part of price
        /// </summary>
        public int? FractionDigits { get; set; }
    }

}
