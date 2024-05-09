using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace SzkolenieTechniczne.Common.Storage
{
    public class TechnicalTrainingContext : DbContext
    {
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            try
            {
                return base.SaveChanges(acceptAllChangesOnSuccess);
            }
            catch (Exception exception)
            {
                throw;
            }

        }
    }
}
