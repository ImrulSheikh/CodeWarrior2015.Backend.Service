using System;
using CodeWarrior2015.Backend.Service.ProductCRUD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CW.Backend.DAL.CRUD.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private static ProductCRUDContext _context;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            _context = new ProductCRUDContext();
        }

        [TestMethod]
        public void AddProduct()
        {

        }
    }
}
