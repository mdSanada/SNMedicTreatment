using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SNMedicTreatment.Helper;
using SNMedicTreatment.Models.Patients;
using SNMedicTreatment.Models.Treatments;
using SNMedicTreatment.Services;
using System.Threading.Tasks;

namespace SNMedicTreatment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly TreatmentService _service;
        public TreatmentController(TreatmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Insert([FromBody] TreatmentRequest request)
        {
            var _treament = new Treatment()
            {
                IdUser = IdentityHelper.GetId(User),
                Name = request.Name,
                IdPatient = request.IdPatient,
                Status = request.Status,
                DiagnosisDate = request.DiagnosisDate,
                Complement = request.Complement,
            };
            _service.Create(_treament);

            return Ok(_treament);
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
        public async Task<ActionResult<string>> Update(int id, [FromBody] TreatmentRequest request)
        {
            var treatment = _service.Find(id);
            treatment.Name = request.Name;
            treatment.IdPatient = request.IdPatient;
            treatment.Status = request.Status;
            treatment.DiagnosisDate = request.DiagnosisDate;
            treatment.Complement = request.Complement;

            _service.Update(treatment);

            return Ok(treatment);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            _service.DeleteAllFromTreatment(id);
            return Ok();
        }


        [HttpGet]
        [Route("User")]
        public async Task<ActionResult<string>> TreatmentsByUser()
        {
            var treatments = _service.FindByUserId(IdentityHelper.GetId(User));
            return Ok(treatments);
        }

        [HttpGet]
        [Route("Patients/{idPatient}")]
        public async Task<ActionResult<string>> TreatmentsByPatients(int idPatient)
        {
            var treatments = _service.FindByPatientId(idPatient);
            return Ok(treatments);
        }

    }
}
