using System.Threading.Tasks;
using System.Collections.Generic;

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public interface SchoolRepository
    {
        /// <summary>
        /// Returns all School entries.
        /// </summary>
        /// <returns>List of school entries.</returns>
        public Task<List<SchoolEntity>> GetAll();

        /// <summary>
        /// Saves a school entry.
        /// </summary>
        /// <param name="schoolEntity"></param>
        /// <returns>TRUE if sucessful and FALSE if not.</returns>
        public Task<bool> Save(SchoolEntity schoolEntity);

        /// <summary>
        /// Returns a School entries.
        /// </summary>
        /// <returns>School entry.</returns>
        public Task<SchoolEntity> Get(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoolEntity"></param>
        /// <returns></returns>
        Task<bool> Update(string id, SchoolEntity schoolEntity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> Delete(string id);
    }
}
