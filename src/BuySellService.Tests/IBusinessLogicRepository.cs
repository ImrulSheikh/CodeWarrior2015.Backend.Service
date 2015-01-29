using System.Collections.Generic;

namespace BuySellService.Tests
{
    public interface IBusinessLogicRepository
    {
        
        List<Geo> GetGeoAll();
    }

    public class Geo
    {
        public string Name { get; set; }
    }
}
