﻿using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Bed
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public bool Available { get; set; }

        public Bed()
        {
        }

        public Bed(int id, int roomId, bool available)
        {
            Id = id;
            RoomId = roomId;
            Available = available;
        }
    }
}
