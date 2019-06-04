using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class QBExperienceDb : SqliteHelper
    {
        private const String TABLE_NAME = "Routes";
        private const String KEY_ID = "id";
        private const String KEY_NAME = "name";
        private const String KEY_LISTOFWAYPOINTS = "listofwaypoints";
        private String[] COLUMNS = new String[] { KEY_ID, KEY_NAME, KEY_LISTOFWAYPOINTS };

        public QBExperienceDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_NAME + " TEXT, " +
                KEY_LISTOFWAYPOINTS + " TEXT )" ;
            dbcmd.ExecuteNonQuery();
        }

        public void addData(RouteEntity route)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_NAME + ", "
                + KEY_LISTOFWAYPOINTS
                + " ) "

                + "VALUES ( '"
                + route._id + "', '"
                + route._name + "', '"
                + route._listofwaypoints
                + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log("Getting route: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_NAME + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log("Deleting route: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log("Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }
    }
}