﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace KST.ABP.Organizations.MongoDB
{
    [ConnectionStringName(OrganizationsDbProperties.ConnectionStringName)]
    public class OrganizationsMongoDbContext : AbpMongoDbContext, IOrganizationsMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureOrganizations();
        }
    }
}