using c11.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using c11.Models;
using c11.Repositories;

namespace c11.Controllers;

[Route("api/patients")]
[ApiController]
public class PatientController : ControllerBase
{

    private IPatientRepository _patientRepository;

    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var patientDto = await _patientRepository.GetPatient(id);

        if (patientDto == null)
        {
            return NotFound("Patient not found");
        }

        return Ok(patientDto);
    }
}