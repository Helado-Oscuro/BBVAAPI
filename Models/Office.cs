﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBVA.Models
{
    public class Office
    {
        public int Id { get; set; }
        public String Place { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Capacity { get; set; }
        public int VentanillasTotalQuantity { get; set; }
        public int PlataformasTotalQuantity { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
    }
}