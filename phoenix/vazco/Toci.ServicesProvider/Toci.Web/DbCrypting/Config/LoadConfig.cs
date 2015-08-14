namespace DbCrypting.Config
{
    public static class LoadConfig
    {
        public const string DataBaseName = "master";
        public const string TableName = "VazcoTable";

        public const string login = "sa";
        public const string secret = "Rabarbar12";
        public const string address = "RYUU\\SQLEXPRESS";

        public const string TemporarySecret = "8a32d4v723s";

    }
}

/*

CREATE TABLE VazcoTable
   (id int IDENTITY PRIMARY KEY NOT NULL,
    data varchar(MAX),
	name varchar(MAX),
	addingTime datetime,
    hash varchar(MAX)
);

*/