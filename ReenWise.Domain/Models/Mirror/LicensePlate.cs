using System;
using System.Collections.Generic;
using System.Text;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class LicensePlate : EntityBase
    {
        public string Number { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
