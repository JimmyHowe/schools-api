using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace SkillsDevelopmentScotland.Functions.Schools
{
    public class SchoolEntity : TableEntity
    {
        public string Level { get; set; }
        public string Name { get; set; }

        public SchoolEntity()
        {
        }

        public SchoolEntity(string level, string name)
        {
            PartitionKey = "Schools API";
            RowKey = slugify(level, name);
            Level = level;
            Name = name;
        }

        private string slugify(string level, string name)
        {
            string combined = level.ToLower() + " " + name.ToLower();

            return Regex.Replace(combined, @"\s", "-", RegexOptions.Compiled);
        }
    }
}