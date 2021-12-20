using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
    }
}
