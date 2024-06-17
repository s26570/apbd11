using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace c11.Models;


public class Patient : IdentityUser
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDay { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}