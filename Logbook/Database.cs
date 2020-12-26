using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Logbook
{
    class Database
    {
        public static string dbFilename;
        public static List<Flight> flights = new List<Flight>();

        public class Flight
        {
            public int ID { get; set; }
            public string PlaceOfDep { get; set; }
            public string PlaceOfArr { get; set; }
            public string Aircraft { get; set; }
            public string Registration { get; set; }
            public string NamePIC { get; set; }
            public string TimeOfDep { get; set; }
            public string TimeOfArr { get; set; }
        }





        public static void NewDatabase()
        {
            SQLiteConnection.CreateFile("Logbook.db");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Logbook.db;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE Logbook (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,Aircraft VARCHAR(32), Registration VARCHAR(32), PlaceOfDeparture VARCHAR(4), PlaceOfArrival VARCHAR(4), TimeOfDep VARCHAR (16), TimeOfArr VARCHAR(16)  ); ";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Logbook (Aircraft, Registration, PlaceOfDeparture) VALUES ('C152', 'SP-KSY', 'EPKN')";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        public static void LoadDatabase(string filename)
        {
            dbFilename = filename;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT ID,       Aircraft,       Registration,       PlaceOfDeparture,       PlaceOfArrival, TimeOfDep, TimeOfArr  FROM Logbook; ";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            SQLiteDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {


                flights.Add(new Flight()
                {
                    ID = rdr.GetInt32(0),
                    PlaceOfDep = "EPKN",
                    PlaceOfArr = "EPKT",
                    Aircraft = rdr.GetString(1),
                    Registration = rdr.GetString(2),
                    TimeOfDep = rdr.GetString(5),
                    TimeOfArr = rdr.GetString(6),
                    NamePIC = "SELF",
                }); ;

            }

            m_dbConnection.Close();
        }

        public static void AddToDatabase(string filename)
        {
            dbFilename = filename;

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
            m_dbConnection.Open();

            string sql = "INSERT INTO Logbook (Aircraft, Registration, PlaceOfDeparture) VALUES ('C152', 'SP-KSY', 'EPKN')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
                        
            m_dbConnection.Close();
        }
    }
}
