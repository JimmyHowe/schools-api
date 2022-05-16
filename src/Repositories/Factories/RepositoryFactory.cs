using System;

namespace SkillsDevelopmentScotland.Functions.Schools {

    public sealed class RepositoryFactory {

        internal static SchoolRepository buildSchoolRepository()
        {
            return new TableStorageSchoolRepository();
        }
    }

}