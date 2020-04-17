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
        public PatientsController(IPatientManager patientService)
        {
            _patientService = patientService;
        }

        [HttpGet, Route("/patients")]
        public async Task<IActionResult> Index()
        {
            var result = await _patientService.GetAllPatients();
            return View(result);
        }

        [HttpGet, Route("/patients/details/{patientId}")]
        public async Task<IActionResult> PatientDetails(int patientId)
        {
            var result = await _patientService.GetPatientById(patientId);
            return View(result);
        }

        [HttpGet, Route("/patients/add")]
        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost, Route("/patients/add")]
        public async Task<IActionResult> AddNewPatient(string name, string birthday, int status)
        {
            Patient patient = _patientService.CreatePatient(name, birthday, status);
            await _patientService.AddPatient(patient);
            return Redirect("/patients");
        }

        [HttpPost, Route("/patients/details/delete/{patientId}")]
        public async Task<IActionResult> RemovePatientById(int patientId)
        {
            await _patientService.RemovePatientById(patientId);

            return Redirect("/patients");
        }

        [HttpGet, Route("/patients/details/update/{patientId}")]
        public async Task<IActionResult> UpdatePatient(int patientId)
        {
            var result = await _patientService.GetPatientById(patientId);
            return View(result);
        }

        [HttpPost, Route("/patients/details/update/{patientId}")]
        public async Task<IActionResult> UpdatePatientById(int patientId, Patient patient)
        {
            await _patientService.UpdatePatientById(patientId, patient);
            return Redirect($"/patients/details/{patientId}");
        }
    }
}
