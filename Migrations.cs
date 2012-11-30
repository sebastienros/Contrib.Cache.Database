using System.Data;
using Orchard.Data.Migration;

namespace Contrib.Cache.Database {
    public class Migrations : DataMigrationImpl {

        public int Create() {
			// Creating table CacheItemRecord
			SchemaBuilder.CreateTable("CacheItemRecord", table => table
				.Column("Id", DbType.Int32, column => column.PrimaryKey().Identity())
				.Column("ValidUntilUtc", DbType.DateTime)
				.Column("CachedOnUtc", DbType.DateTime)
				.Column("Output", DbType.String, column => column.Unlimited())
				.Column("ContentType", DbType.String)
				.Column("QueryString", DbType.String, column => column.WithLength(2048))
				.Column("CacheKey", DbType.String, column => column.WithLength(2048))
				.Column("InvariantCacheKey", DbType.String, column => column.WithLength(2048))
				.Column("Url", DbType.String, column => column.WithLength(2048))
				.Column("Tenant", DbType.String)
				.Column("StatusCode", DbType.Int32)
				.Column("Tags", DbType.String, column => column.Unlimited())
			);

            // todo: add an index on CacheKey

            return 1;
        }
    }
}