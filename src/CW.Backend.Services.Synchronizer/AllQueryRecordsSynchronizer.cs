namespace CW.Backend.Services.Synchronizer
{
    public class AllQueryRecordsSynchronizer
    {
        public void SyncAll()
        {
            var detailsSynchronizer = new ProductDetailsSynchronizer();
            var summarySynchronizer = new ProductSummarySynchronizer();
            var usersSynchronizer = new UserFlatProfilesSynchronizer();

            detailsSynchronizer.Sync();
            summarySynchronizer.Sync();
            usersSynchronizer.Sync();
        }
    }
}
