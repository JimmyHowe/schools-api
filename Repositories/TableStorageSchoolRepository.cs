using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using System;

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public class TableStorageSchoolRepository : TableStorageRepository, SchoolRepository
    {
        public async Task<List<SchoolEntity>> GetAll()
        {
            TableContinuationToken token = null;
            var entities = new List<SchoolEntity>();
            do
            {
                var queryResult = await this.table.ExecuteQuerySegmentedAsync(new TableQuery<SchoolEntity>(), token);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);

            return entities;
        }

        public async Task<bool> Save(SchoolEntity schoolEntity)
        {
            TableOperation insert = TableOperation.Insert(schoolEntity);
            try
            {

                await this.table.ExecuteAsync(insert);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<SchoolEntity> Get(string id)
        {
            TableOperation retrieve = TableOperation.Retrieve<SchoolEntity>("Schools API", id);

            TableResult tableResult = await this.table.ExecuteAsync(retrieve);

            return (SchoolEntity)tableResult.Result;
        }

        public async Task<bool> Update(string id, SchoolEntity schoolEntity)
        {
            try
            {
                await this.Delete(id);
                await this.Save(schoolEntity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            SchoolEntity school = await this.Get(id);

            TableOperation deleteOperation = TableOperation.Delete(school);

            try
            {
                await this.table.ExecuteAsync(deleteOperation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

