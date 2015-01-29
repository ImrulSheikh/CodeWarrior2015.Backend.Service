using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BuySellService.Tests
{
    [TestClass]
    public class SampleTest
    {


        protected Mock<IBusinessLogicRepository> Repository;
        

        [TestInitialize]
        public void Initiallize()
        {
            Repository = new Mock<IBusinessLogicRepository>();

        }

    

        [TestMethod]
        public void Check_Geo_Count()
        {
            var geos = new List<Geo>();
            Repository.Setup(x => x.GetGeoAll()).Returns(geos);
            
            //Repository.Setup(x => x.GetDataAvailibiltyInfo(It.IsAny<DecisionParameterDataAvailability>(), It.IsAny<IReadOnlyDictionary<string, string>>())).Returns(BusinessConstant.DataAvailability.Available);

            Assert.AreEqual(geos.Count, 0);

        }
    }
}
