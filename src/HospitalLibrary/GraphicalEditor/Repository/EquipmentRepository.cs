﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly HospitalDbContext _context;

        public EquipmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipments.ToList();
        }

        public IEnumerable<Equipment> GetEquipmentByRoomId(int id)
        {
            return _context.Equipments.Where(f => f.RoomId == id).ToList();
        }

        public void CreateEquipTransfer(EquipmentTransfer equipTrans)
        {
            _context.EquipmentTransfers.Add(equipTrans);
            _context.SaveChanges();
        }

        public Equipment GetEquipmentByRoomIdAndName(int roomId, string name)
        {
          //  return _context.Equipments.Where(f => (f.RoomId == roomId && f.Name == name)).FirstOrDefault<Equipment>();
          //  return _context.Rooms.Include(r => r.Beds).Where(r => r.Id == id).FirstOrDefault<Room>();
            return _context.Equipments.Where(f => f.RoomId == roomId && f.Name == name).FirstOrDefault();
        }
       
        public void Create(Equipment equip)
        {
            _context.Equipments.Add(equip);
            _context.SaveChanges();
        }

        public void Update(Equipment equip)
        {
            _context.Entry(equip).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public IEnumerable<Equipment> Search(string name, int? amount)
        {
            IQueryable<Equipment> query = _context.Equipments;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(r => r.Name.ToLower().Contains(name.Trim().ToLower()));
            }

            if (amount != null)
            {
                query = query.Where(r => r.Amount >= amount);
            }

            return query.ToList();
        }

        public IEnumerable<EquipmentTransfer> GetEquipmentTransferByRoomId(int id)
        {
            return _context.EquipmentTransfers.Where(f => f.ToRoomId == id || f.FromRoomId == id).ToList();
        }

    }
}
