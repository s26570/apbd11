namespace c11.Dtos;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentDto> MedicamentDtos { get; set; }
    public DoctorDto DoctorDto { get; set; }
}