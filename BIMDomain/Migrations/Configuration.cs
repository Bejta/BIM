namespace BIMDomain.Migrations
{
    using Models;
    using Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Web.Hosting;
    internal sealed class Configuration : DbMigrationsConfiguration<BIMDomain.Models.DAL.BIMObjectContext>
    {

        private static readonly Guid _constantGuid = new Guid("ea817faf-50fd-4c5e-a330-2765d9497663");
        //private static readonly string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/");
        string filePath = HostingEnvironment.MapPath("~/Content/images/");

        ImageManager _imageManager = new ImageManager();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Models.DAL.BIMObjectContext context)
        {
           
            var manufacturies = new List<Manufactury>
            {
                new Manufactury { Logo = _imageManager.converterImageToByte(_imageManager.LoadImageFromFile("git.png")), Name = "Drawings",   guidCreated = _constantGuid, Created = DateTime.Now,
                guidUpdated = _constantGuid, Updated = DateTime.Now},
                new Manufactury { Logo = _imageManager.converterImageToByte(_imageManager.LoadImageFromFile("epub.png")), Name = "Drawings",   guidCreated = _constantGuid, Created = DateTime.Now,
                guidUpdated = _constantGuid, Updated = DateTime.Now},
            };
            manufacturies.ForEach(s => context.Manufacturies.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Image = _imageManager.converterImageToByte(_imageManager.LoadImageFromFile("mouse.png")), ManufacturyID = 1, Name = "Mouse",   guidCreated = _constantGuid, Created = DateTime.Now,
                      guidUpdated = _constantGuid, Updated = DateTime.Now},
                new Product { Image =_imageManager.converterImageToByte(_imageManager.LoadImageFromFile("drawing.png")), ManufacturyID = 1, Name = "Crown",   guidCreated = _constantGuid, Created = DateTime.Now,
                      guidUpdated = _constantGuid, Updated = DateTime.Now},
                new Product { Image =_imageManager.converterImageToByte(_imageManager.LoadImageFromFile("image1.png")), ManufacturyID = 2, Name = "Dead Mouse",   guidCreated = _constantGuid, Created = DateTime.Now,
                      guidUpdated = _constantGuid, Updated = DateTime.Now},
                new Product {  Image = _imageManager.converterImageToByte(_imageManager.LoadImageFromFile("oldschool.png")), ManufacturyID = 2, Name = "Old school poster",   guidCreated = _constantGuid, Created = DateTime.Now,
                      guidUpdated = _constantGuid, Updated = DateTime.Now},
                new Product {  Image = _imageManager.converterImageToByte(_imageManager.LoadImageFromFile("youtube.png")), ManufacturyID = 2, Name = "Youtube icon",   guidCreated = _constantGuid, Created = DateTime.Now,
                      guidUpdated = _constantGuid, Updated = DateTime.Now},
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
