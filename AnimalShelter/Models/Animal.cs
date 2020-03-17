using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models

{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }

    public string Property {get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DateAdmittance { get; set; }

    public string Breed { get; set; }

    // public int CategoryId { get; set; }
    // public virtual Category Category { get; set; }

  }
}