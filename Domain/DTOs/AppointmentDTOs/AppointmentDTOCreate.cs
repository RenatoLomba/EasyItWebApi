﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.AppointmentDTOs
{
    public class AppointmentDTOCreate
    {
        public Guid UserId { get; set; }
        public Guid ExpertId { get; set; }
        public Guid ServiceId { get; set; }
        public AppointmentDTOCreateDateDTO DateInfo { get; set; }
    }
}
