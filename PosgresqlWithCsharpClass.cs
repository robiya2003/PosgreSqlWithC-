using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PosgreSqlWithC_
{
    internal class PosgresqlWithCsharpClass
    {
        public const string CONNECTINGSTRING = "Server=127.0.0.1;Port=5432;Database=libruary;User Id=postgres;Password=dfrt43i0";
        
        public void CreateTables()
        {
            #region
            List<string> QueriesList = new List<string>();
            
            QueriesList.Add("create table Categories(category_id serial primary key , " +
                "category_name varchar(100))");


            QueriesList.Add("create table Authers(auther_id serial primary key," +
                "auther_name varchar(100))");



            QueriesList.Add("create table Books(book_id serial primary key," +
                "book_name varchar(100)," +
                "category_id int," +
                "auther_id int," +
                "constraint category_book  foreign key (category_id) references Categories(category_id)," +
                "constraint auther_boon foreign key (auther_id) references Authers(auther_id))");
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand = null;
            foreach (string query in QueriesList)
            {
                npgsqlCommand=new NpgsqlCommand(query,npgsqlConnection);
                npgsqlCommand.ExecuteNonQuery();
                Console.WriteLine("uraaaaa");
            }
            npgsqlConnection.Close();
            #endregion
        }
        public void InsertTables()
        {
            #region
            List<string> QueriesInsert = new List<string>();
            QueriesInsert.Add("" +
                "insert into categories(category_name) values" +
                "('turk adabiyoti')," +
                "('ozbek adabiyiti')," +
                "('sheriyat')," +
                "('Jahon adabiyoti')");

            QueriesInsert.Add("" +
                "insert into authers(auther_name) values" +
                "('Abdulla Qodiriy')," +
                "('Rauf Jilasun')," +
                "('Jorch Oruel')," +
                "('Mehmed Olaqosh')," +
                "('Zulfiya')"); QueriesInsert.Add("" +
                "insert into categories(category_name) values" +
                "('turk adabiyoti')," +
                "('ozbek adabiyiti')," +
                "('sheriyat')," +
                "('Jahon adabiyoti')");

            QueriesInsert.Add("" +
                "insert into authers(auther_name) values" +
                "('Abdulla Qodiriy')," +
                "('Rauf Jilasun')," +
                "('Jorch Oruel')," +
                "('Mehmed Olaqosh')," +
                "('Zulfiya')");
            QueriesInsert.Add("" +
                "insert into books(book_name,category_id,auther_id) values" +
                "('Otgan kunlar',2,1)," +
                "('Mehrobdan Chayon',2,1)," +
                "('Muqaddas Azob',1,2)," +
                "('Halol Luqma',1,2)," +
                "('Chuqur uyqu',1,2)," +
                "('Tinmas kozyoshlar',1,2)," +
                "('1984',4,3)," +
                "('Molxona',4,3)," +
                "('Nafas',4,3)," +
                "('Peshonamdagi nur',1,4)," +
                "('Tutqun',1,4)," +
                "('Devona',1,4)," +
                "('Jumali',1,4)," +
                "('Yongin',1,4)," +
                "('Yashash fursati',1,4)," +
                "('Mushoira',3,5)," +
                "('Shalola',3,5)," +
                "('Kammalak',3,5)");

            QueriesInsert.Add("insert into books(book_name,category_id,auther_id) values" +
                "('Notori',1,1)"); 
            QueriesInsert.Add("insert into books(book_name,category_id,auther_id) values" +
                "('Notori',1,1)"); 
            QueriesInsert.Add("insert into books(book_name,category_id,auther_id) values" +
                "('Notori',1,1)");

            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand =null;

            foreach (string query in QueriesInsert)
            {
                npgsqlCommand=new NpgsqlCommand(query,npgsqlConnection);
                npgsqlCommand.ExecuteNonQuery();
            }

            npgsqlConnection.Close();
            #endregion

        }
        public void GetAll()
        {
            #region
            string query = "select book_name,auther_name,category_name from books\r\ninner join authers using(auther_id)\r\ninner join categories using(category_id)";
            NpgsqlConnection npgsqlConnection= new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query,npgsqlConnection);
            NpgsqlDataReader? reader=npgsqlCommand.ExecuteReader();
            List<object[]> ResultList = new List<object[]>();
            while (reader.Read())
            {
                object[] objects = new object[reader.FieldCount];
                reader.GetValues(objects);
                ResultList.Add(objects);
            }
            foreach (object[] column in ResultList)
            {
                foreach (object row in column)
                {
                    Console.Write(row+" | ");
                }
                Console.WriteLine("\n\n");
            }
            npgsqlConnection.Close();
            #endregion
        }
        public void GetById(int id)
        {
            #region
            string Query = $"select book_id, book_name,auther_name,category_name from books\r\ninner join authers using(auther_id)\r\ninner join categories using(category_id)\r\nwhere book_id={id}";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand=new NpgsqlCommand(Query,npgsqlConnection);
            var reader=npgsqlCommand.ExecuteReader();
            List<object[]> ResultList= new List<object[]>();
            
            while (reader.Read()) 
            {
                object[] values= new object[reader.FieldCount];
                reader.GetValues(values);
                ResultList.Add(values);
            }
            foreach (var column in ResultList)
            {
                foreach(object row in column)
                {
                   Console.Write(row+"  ");
                }
            }
            npgsqlConnection.Close() ;
            #endregion 
        }
        public void DeleteAutherCategory()
        {
            #region
            string query1 = "delete from authers where not auther_id in (1,2,3,4,5) returning *";
            string query2 = "delete from categories where not category_id in (1,2,3,4) returning *";
            List<string> queries = new List<string>();
            queries.Add(query1);
            queries.Add(query2);
            NpgsqlConnection npgsqlConnection=new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand = null;
            foreach (var q in queries)
            {
                npgsqlCommand =new NpgsqlCommand(q,npgsqlConnection);
                npgsqlCommand.ExecuteNonQuery();
                
            }
            npgsqlConnection.Close();
            #endregion
        }
        public void UpdateBooks()
        {
            #region
            string query1 = "update books set " +
                "book_name='Bahor keldi seni soroqlab'," +
                "auther_id=5," +
                "category_id=3 " +
                "where book_id=(select book_id where book_name='Notori' limit 1)";
            string query2 = "update books set " +
                "book_name='Kozlaringda bormi yulduzing'," +
                "auther_id=5," +
                "category_id=3 " +
                "where book_id=(select book_id where book_name='Notori' limit 1)";
            string query3 = "update books set " +
                "book_name='Soz CHamani'," +
                "auther_id=5," +
                "category_id=3 " +
                "where book_id=(select book_id where book_name='Notori' limit 1)";
            List<string> queries= new List<string>();
            queries.Add(query1);
            queries.Add(query2);
            queries.Add(query3);

            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            foreach (var q in queries)
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(q, npgsqlConnection);
                npgsqlCommand.ExecuteNonQuery();
            }
            
            npgsqlConnection.Close();
            #endregion
        }
        public void getLike(string like)
        {
            #region
            string query = $"select book_name,auther_name,category_name from books\r\ninner join authers using(auther_id)\r\ninner join categories using(category_id)\r\nwhere category_name ilike '{like}%'";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand=new NpgsqlCommand(query, npgsqlConnection);
            var reader=npgsqlCommand.ExecuteReader();
            List<object[]> ResultList= new List<object[]>();
            while (reader.Read())
            {
                object[] Result= new object[reader.FieldCount];
                reader.GetValues(Result);
                ResultList.Add(Result);
            }
            foreach (object[] Result in ResultList)
            {
                foreach (object Result2 in Result)
                {
                    Console.Write(Result2 + " | ");
                }
                Console.WriteLine("\n\n");
            }
            npgsqlConnection.Close();
            #endregion
        }
        public void CreateColumnBooks()
        {
            #region
            string query = "alter table books add column p money";
            NpgsqlConnection npgsqlConnection=new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand =new NpgsqlCommand (query, npgsqlConnection);
            npgsqlCommand.ExecuteNonQuery();
            npgsqlConnection.Close() ;
            #endregion
        }
        public void CreateColumnDefaultBooks()
        {
            #region
            string query = "alter table books " +
                "add column discount int default(5)";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand=new NpgsqlCommand (query,npgsqlConnection);
            npgsqlCommand.ExecuteNonQuery();
            npgsqlConnection.Close() ;
            #endregion
        }
        public void RenameColumn()
        {
            #region
            string query = "alter table books rename column p to price";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand= new NpgsqlCommand (query,npgsqlConnection) ;
            npgsqlCommand.ExecuteNonQuery();
            npgsqlConnection.Close() ;
            #endregion
        }

        public void CreateDatabase()
        {
            #region
            string query = "create database Nodatabase";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(CONNECTINGSTRING);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection);
            npgsqlCommand.ExecuteNonQuery();
            npgsqlConnection.Close();
            #endregion
        }
    }
}
