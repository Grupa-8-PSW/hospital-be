namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class RenovationSessionDTO
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Room { get; set; }
        public int Interval { get; set; }
        public int Duration { get; set; }
        public int Available { get; set; }
        public int Changes { get; set; }
        public int Schedule { get; set; }

        public RenovationSessionDTO(int type, int room, int interval, int duration, int available, int changes, int schedule)
        {
            Type = type;
            Room = room;
            Interval = interval;
            Duration = duration;
            Available = available;
            Changes = changes;
            Schedule = schedule;
        }

        public RenovationSessionDTO(Renovation renovation)
        {
            Id = renovation.Id;
            Type = renovation.Type;
            Room = renovation.RoomId;
            Interval = renovation.Interval;
            Duration = renovation.Interval;
            Available = renovation.Available;
            Changes = renovation.Changes;
            Schedule = renovation.Schedule;
        }
    }
}
