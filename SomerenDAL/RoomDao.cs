using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT RoomId, NumberBed, FloorRoom, Building, Type FROM room";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room()
                {
                    RoomID = (int)dr["RoomId"],
                    Capacity = (int)dr["NumberBed"],
                    Type = (string)dr["Type"],
                    Floor = (int)dr["FloorRoom"],
                    Building = (string)dr["Building"],
                };
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
