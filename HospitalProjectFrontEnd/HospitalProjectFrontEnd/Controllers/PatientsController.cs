using HospitalProjectFrontEnd.Models;
using HospitalProjectFrontEnd.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Controllers
{
    public class PatientsController : Controller
    {
        private IPatientManager _patientService; // Bringing in the patient service
        public PatientsController (IPatientManager patientService)
        {
            _patientService = patientService;
        }

        [HttpGet, Route("/patients")]
        public async Task<IActionResult> Index()
        {
            var result = await _patientService.GetAllPatients();
            return View(result);
        }

        [HttpGet, Route("/patients/{patientId}")]
        public async Task<IActionResult> PatientDetails(int patientId)
        {
            var result = await _patientService.GetPatientById(patientId);
            return View(result);
        }

        [HttpPost, Route("/patients/add")]
        public IActionResult AddNewPatient(string name, string birthday)
        {
            Patient patient = _patientService.CreatePatient(name, birthday);
            _patientService.AddPatient(patient);
            return RedirectToAction("PatientDetails", patient.ID);

        }
    }
}
