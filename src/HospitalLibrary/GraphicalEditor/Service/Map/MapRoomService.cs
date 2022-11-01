using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class MapRoomService : IMapRoomService
    {
        private readonly IMapRoomRepository _roomRepository;

        public MapRoomService(IMapRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<MapRoom> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public MapRoom GetById(int id)
        {
            return _roomRepository.GetById(id);
        }
    }
}
