using System;

namespace AnimalShelter.Models

{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime DateAdmittance { get; set; }

    public string Breed { get; set; }


    // public int CategoryId { get; set; }
    // public virtual Category Category { get; set; }

  }
}