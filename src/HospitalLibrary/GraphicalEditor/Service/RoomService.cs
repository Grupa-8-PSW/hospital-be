<<<<<<< HEAD
﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
=======
﻿using HospitalLibrary.GraphicalEditor.Model;
>>>>>>> 4addd3d9fd52b77c8be88d680c2e3dc301c3a87a
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using System.Collections.Immutable;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBedRepository _bedRepository;


        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public IEnumerable<Room> Search(string name)
        {
            return _roomRepository.Search(name);
        }

        public Room GetById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public IEnumerable<Room> GetRoomsByFloorId(int id)
        {
            try
            {
                return _roomRepository.GetRoomsByFloorId(id);

            }
            catch (Exception e)
            {
                return null;
            }

        }

        public IEnumerable<Room> GetFreeRooms()
        {
            return _roomRepository.GetFreeRooms();
        }

    }
}
