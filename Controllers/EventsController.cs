using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SNMedicTreatment.Helper;
using SNMedicTreatment.Models.Events;
using SNMedicTreatment.Models.Medications;
using SNMedicTreatment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNMedicTreatment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsService _service;
        private readonly MedicationService _medicationService;
        public EventsController(EventsService service, MedicationService medicationService)
        {
            _service = service;
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventResponse>>> Get()
        {
            var events = _service.FindByUserId(IdentityHelper.GetId(User));
            var medications = _medicationService.FindByUserId(IdentityHelper.GetId(User));
            var eventsResponse = new List<EventResponse>();
            events.ForEach(_event => {
                var medication = medications.FirstOrDefault(m => m.Id == _event.IdMedication)?.Name;
                eventsResponse.Add(new EventResponse(_event, medication));
            });

            return Ok(eventsResponse);
        }
    }
}
