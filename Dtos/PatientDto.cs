using c11.Models;

namespace c11.Dtos;

public class PatientDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDay { get; set; }
    public List<Prescription> Prescriptions { get; set; }
}