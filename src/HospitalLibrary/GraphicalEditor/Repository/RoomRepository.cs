using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HospitalDbContext _context;

        public RoomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Include(r => r.Beds).Where(r => r.Id == id).FirstOrDefault<Room>();// Find(id);
        }

        public IEnumerable<Room> GetRoomsByFloorId(int id)
        {
            return _context.Rooms.Where(f => f.FloorId == id);
        }

        public IEnumerable<Room> GetFreeRooms()
        {
            return _context.Rooms.Where(r => r.Beds.Where(b => b.Available).ToList().Count > 0);
        }

    }
}