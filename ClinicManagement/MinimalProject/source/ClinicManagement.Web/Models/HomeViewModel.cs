using System;
using System.Collections.Generic;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Web.Models
{
  public class HomeViewModel
  {
    public IEnumerable<Product> FeaturedProducts { get; set; }
  }
}
