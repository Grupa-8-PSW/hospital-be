﻿using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IAppointmentSchedulingSessionRepository
    {
        AppointmentSchedulingSession FindBy(int id);

        void Add(AppointmentSchedulingSession appointmentSchedulingSession);

        void Save(AppointmentSchedulingSession appointmentSchedulingSession);
    }
}