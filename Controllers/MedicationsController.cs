using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SNMedicTreatment.Helper;
using SNMedicTreatment.Models.Medications;
using SNMedicTreatment.Services;
using System.Threading.Tasks;

namespace SNMedicTreatment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly MedicationService _service;
        public MedicationsController(MedicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Insert([FromBody] MedicationRequest request)
        {
            var _medication = new Medication()
            {
                IdUser = IdentityHelper.GetId(User),
                IdPatient = request.IdPatient,
                IdTreatment = request.IdTreatment,
                Name = request.Name,
                Status = request.Status,
                Days = request.Days,
                StartDate = request.StartDate,
                Frequency = request.Frequency,
                Dosage = request.Dosage,
                Description = request.Description,
            };
            _service.Create(_medication);

            return Ok(_medication);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var treatment = _service.Find(id);
            return Ok(treatment);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<string>> Update(int id, [FromBody] MedicationRequest request)
        {
            var medications = _service.Find(id);
            medications.IdPatient = request.IdPatient;
            medications.IdTreatment = request.IdTreatment;
            medications.Name = request.Name;
            medications.Status = request.Status;
            medications.Days = request.Days;
            medications.StartDate = request.StartDate;
            medications.Frequency = request.Frequency;
            medications.Dosage = request.Dosage;
            medications.Description = request.Description;

            _service.Update(id, medications);

            return Ok(medications);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            _service.DeleteAllFromMedication(id);
            return Ok();
        }


        [HttpGet]
        [Route("User")]
        public async Task<ActionResult<string>> MedicationsByUser()
        {
            var treatments = _service.FindByUserId(IdentityHelper.GetId(User));
            return Ok(treatments);
        }

        [HttpGet]
        [Route("Patients/{idPatient}")]
        public async Task<ActionResult<string>> MedicationsByPatients(int idPatient)
        {
            var medications = _service.FindByPatientId(idPatient);
            return Ok(medications);
        }

        [HttpGet]
        [Route("Treatments/{idTreatment}")]
        public async Task<ActionResult<string>> MedicationsByTreatments(int idTreatment)
        {
            var medications = _service.FindByTreatmentId(idTreatment);
            return Ok(medications);
        }

    }
}
