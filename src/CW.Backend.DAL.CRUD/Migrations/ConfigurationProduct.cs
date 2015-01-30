using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using CW.Backend.DAL.Base.Entities;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.CRUD.Migrations
{
    internal sealed class ConfigurationProduct : DbMigrationsConfiguration<ProductCRUDContext>
    {
        public ConfigurationProduct()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductCRUDContext context)
        {
            context.Products.Add(new Product
            {
                Name = "LG G3, Metallic Black 32GB (AT&T)",
                Description =
                    "Behold the latest smartphone in LG’s award-winning G Series. Now, with a larger, clearer display, a laser-precise camera and superior smart interactivity, we can confidently call the G3 the best smartphone that LG has ever made.",
                Category =
                    new Category
                    {
                        Name = "SmartPhone",
                        Description = "Android based phones",
                        Properties =
                            new Collection<CategoryProperty>
                            {
                                new CategoryProperty {Name = "Screen Size", IsMandatory = true},
                                new CategoryProperty {Name = "Weight", IsMandatory = true},
                                new CategoryProperty {Name = "Talktime", IsMandatory = true},
                                new CategoryProperty {Name = "Light", IsMandatory = false}
                            },
                        CreatedBy = "Ibnoon",
                        CreatedOn = DateTime.Now,
                        Status = EntityStatus.Active
                    },
                PostedBy = new ApplicationUser
                {
                    UserName = "MIbnoon",
                    FullName = "Mufle Ibnoon",
                    Sex = "Male",
                    Email = "tonmoy0605055@gmail.com",
                    CreatedBy = "Ibnoon",
                    CreatedOn = DateTime.Now,
                    Status = EntityStatus.Active
                },
//                Price = new ProductPrice {UnitPrice = 480, Discount = 50, DiscountValidity = new DateTime(2015, 03, 01)},
                //Price = new Collection<ProductPrice>
                //{
                //    new ProductPrice {UnitPrice = 480, Discount = 100, DiscountValidity = new DateTime(2015, 03, 01)},
                //    new ProductPrice {UnitPrice = 500, Discount = 50, DiscountValidity = new DateTime(2015, 04, 01)},
                //    new ProductPrice {UnitPrice = 600, Discount = 30, DiscountValidity = new DateTime(2015, 05, 01)},
                //    new ProductPrice {UnitPrice = 600, Discount = 0}
                //},
                NumberOfUnits = 1,
                Properties = new Collection<ProductProperty>
                {
                    new ProductProperty {Name = "Screen Size", Type = "System.float", Value = "5.5"},
                    new ProductProperty {Name = "Weight", Type = "System.float", Value = "5.44"},
                    new ProductProperty {Name = "Talktime", Type = "System.int", Value = "21"},
                    new ProductProperty {Name = "StandByTime", Type = "System.int", Value = "672"},
                    new ProductProperty {Name = "Processor Cores", Type = "System.int", Value = "4"},
                    new ProductProperty {Name = "Shipping Weight", Type = "System.float", Value = "14.4"},
                    new ProductProperty {Name = "ASIN", Type = "System.string", Value = "B00L9OVC94"},
                    new ProductProperty {Name = "Item model number", Type = "System.string", Value = "G3"},
                    new ProductProperty {Name = "Network Compatibility", Type = "System.string", Value = "LTE"}
                },
                Tags = new Collection<ProductTag>
                {
                    new ProductTag{Name = "LG G3", TagType = TagType.SystemProvided},
                    new ProductTag{Name = "Quad core", TagType = TagType.UserProvided}
                },
                Comments = new Collection<ProductComment>
                {
                    new ProductComment{Comment = "The screen is amazing.", StarRating = 5, HelpfulHits = 17},
                    new ProductComment{Comment = "Lastly, battery life. ", StarRating = 5, HelpfulHits = 3},
                    new ProductComment{Comment = "The design feels very premium and durable now due to the metal coating but retains all the benefits of plastic. ", StarRating = 5, HelpfulHits = 18 },
                    new ProductComment{Comment = "Excellent phone, but not the best Android phone of 2014.", StarRating = 4, HelpfulHits = 182 },
                    new ProductComment{Comment = "Combines every strength from competitors.", StarRating = 5, HelpfulHits = 86}
                },
                ImagePath = @"~\styles\img\lg_g3_001.jpg",
                CreatedBy = "Ibnoon",
                CreatedOn = DateTime.Now,
                Status = EntityStatus.Active
            });
        }
    }
}
