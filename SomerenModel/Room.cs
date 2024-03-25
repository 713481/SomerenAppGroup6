namespace SomerenModel
{
    public class Room
    {
        public int Id { get; set; }         // database id
        public int RoomID { get; set; }     // RoomNumber, e.g. 206
        public int Capacity { get; set; }   // number of beds, either 4, 6, 8, 12 or
        public string Type { get; set; }      // student = false, teacher = true
        public int Floor { get; set; }
        public string Building { get; set; }
    }
}