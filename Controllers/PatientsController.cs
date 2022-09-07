using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SNMedicTreatment.Contexts;
using SNMedicTreatment.Helper;
using SNMedicTreatment.Models.Account;
using SNMedicTreatment.Models.Config;
using SNMedicTreatment.Models.Error;
using SNMedicTreatment.Models.Patients;
using SNMedicTreatment.Models.Users;
using SNMedicTreatment.Services;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SNMedicTreatment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly PatientsService _service;

        public PatientsController(PatientsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Insert([FromBody] PatientRequest request)
        {
            var _patient = new Patient() { 
                IdUser = IdentityHelper.GetId(User),
                Name = request.Name,
                Birthdate = request.Birthdate, 
                Breed = request.Breed,
                Weigth = request.Weigth,
                Allergy = request.Allergy, 
                Image = request.Image
            };
            _service.Create(_patient);

            return Ok(_patient);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var patient = _service.Find(id);
            return Ok(patient);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<string>> Update(int id, [FromBody] PatientRequest request)
        {
            var patient = _service.Find(id);
            patient.Name = request.Name;
            patient.Birthdate = request.Birthdate;
            patient.Breed = request.Breed;
            patient.Allergy = request.Allergy;
            patient.Image = request.Image;

            _service.Update(patient);

            return Ok(patient);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            _service.DeleteAllFromPatients(id);
            return Ok();
        }


        [HttpGet]
        [Route("User")]
        public async Task<ActionResult<string>> PatientsByUser()
        {
            var patients = _service.FindByUserId(IdentityHelper.GetId(User));
            return Ok(patients);
        }

    }
}
