namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Renovation
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int RoomId { get; set; }
        public int Interval { get; set; }
        public int Duration { get; set; }
        public int Available { get; set; }
        public int Changes { get; set; }
        public int Schedule { get; set; }

        public Renovation()
        { }

        public Renovation(int id, int type, int roomId, int interval, int duration, int available, int changes, int schedule)
        {
            Id = id;
            Type = type;
            RoomId = roomId;
            Interval = interval;
            Duration = duration;
            Available = available;
            Changes = changes;
            Schedule = schedule;
        }
    }
}
