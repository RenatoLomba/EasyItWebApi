using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid ExpertId { get; set; }
        public ExpertEntity Expert { get; set; }
        public IEnumerable<AppointmentEntity> Appointments { get; set; }
    }
}
