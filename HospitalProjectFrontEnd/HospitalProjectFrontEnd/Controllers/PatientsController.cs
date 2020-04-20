using HospitalProjectFrontEnd.Models;
using HospitalProjectFrontEnd.Models.Interfaces;
using HospitalProjectFrontEnd.ViewModels;
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
        private IResourceManager _resourceService; // Bringing in the resource service
        public PatientsController(IPatientManager patientService, IResourceManager resourceService)
        {
            _patientService = patientService;
            _resourceService = resourceService;
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

        [HttpGet, Route("/patients/resources/{patientId}")]
        public async Task<IActionResult> UpdatePatientResources(int patientId)
        {
            var patientModels = new PatientModels(); // Use viewmodel PatientModels to bring in both patient data and the list of all resources
            patientModels.Patient = await _patientService.GetPatientById(patientId);
            patientModels.AllResources = await _resourceService.GetAllResources();
            return View(patientModels);
        }

        [HttpPost, Route("/patients/resources/{patientId}")]
        public async Task<IActionResult> AssignPatientResourceByPatientIdAndResourceId(int patientId, int resourceId)
        {
            await _patientService.AssignPatientResource(patientId, resourceId);
            return Redirect($"/patients/details/{patientId}");
        }
    }
}
