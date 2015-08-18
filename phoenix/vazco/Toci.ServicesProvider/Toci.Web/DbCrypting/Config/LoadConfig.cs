namespace DbCrypting.Config
{
    public static class LoadConfig
    {
        public const string DataBaseName = "master";

        public const string login = "sa";
        public const string secret = "Rabarbar12";
        public const string address = "RYUU\\SQLEXPRESS";



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