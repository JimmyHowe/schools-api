using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public abstract class TableStorageRepository
    {
        protected CloudStorageAccount account;
        protected CloudTableClient client;
        protected CloudTable table;

        protected TableStorageRepository()
        {
            this.account = new CloudStorageAccount(
                new StorageCredentials(
                    "schoolsapi",
                    "LOZjCUGQlhWAyR46rl3Ae6AkpvbwO/xyNXF7WFnvbMNOA5zspko+OrI0GeeERN85CLd8zE/MwQbycz4NZKGs3A=="),
                    false
                );
            this.client = account.CreateCloudTableClient();
            this.table = client.GetTableReference("schools");
        }
    }
}
