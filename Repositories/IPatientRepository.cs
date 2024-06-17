using c11.Dtos;

namespace c11.Repositories;

public interface IPatientRepository
{
    public Task<PatientDto> GetPatient(int id);
}