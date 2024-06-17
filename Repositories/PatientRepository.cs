using c11.DBContext;
using Microsoft.EntityFrameworkCore;
using c11.Dtos;
using c11.Models;

namespace c11.Repositories;

public class PatientRepository : IPatientRepository
{
    private Context _context;

    public PatientRepository(Context Context)
    {
        _context = Context;
    }

    public async Task<PatientDto> GetPatient(int id)
    {
        var patient = await (from p in _context.Patients
            where p.IdPatient == id
            select new PatientDto
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDay = p.BirthDay,
                Prescriptions = p.Prescriptions
                    .OrderByDescending(pr => pr.DueDate)
                    .Select(pr => new Prescription
                    {
                        IdPrescription = pr.IdPrescription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        IdDoctor = pr.IdDoctor,
                        PrescriptionMedicaments = pr.PrescriptionMedicaments
                            .Select(pm => new PrescriptionMedicament
                            {
                                IdMedicament = pm.IdMedicament,
                                Dose = pm.Dose,
                                Details = pm.Details
                            }).ToList()
                    }).ToList()
            }).FirstOrDefaultAsync();

        if (patient == null)
        {
            return null!;
        }

        return patient;
    }
}