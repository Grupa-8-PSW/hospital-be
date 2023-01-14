namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class RenovateIntervalsDTO
    {
        public int roomId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int duration { get; set; }
        public int roomId2 { get; set; }

        public RenovateIntervalsDTO(int roomId, DateTime startDate, DateTime endDate, int duration, int roomId2)
        {
            this.roomId = roomId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.duration = duration;
            this.roomId2 = roomId2;
        }
    }
}
