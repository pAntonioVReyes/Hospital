using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultPaciente = BL.Paciente.GetAll();
            ML.Result resultTipoSangre = BL.TipoSangre_DLL.GetAll();
            ML.Paciente paciente = new ML.Paciente();
            paciente.TipoSangre = new ML.TipoSangre_DLL();

            if (resultPaciente != null)
            {
                paciente.Pacientes = resultPaciente.ResultObjs;
                paciente.TipoSangre.TiposSangres = resultTipoSangre.ResultObjs;
                return View(paciente);
            }

            else 
            {
                ViewBag.Mensaje = resultPaciente.Mensaje;
                return View(paciente);
            }
        }

        [HttpGet]
        public ActionResult Form(int? idPaciente) 
        {
            ML.Paciente paciente = new ML.Paciente();
            ML.Result resultTipoSangre = BL.TipoSangre_DLL.GetAll();
            paciente.TipoSangre = new ML.TipoSangre_DLL();
            paciente.TipoSangre.TiposSangres = resultTipoSangre.ResultObjs;

            if (idPaciente == 0 || idPaciente == null)
            {
                ViewBag.Titulo = "Agregar";
                return View(paciente);
            }
            else 
            {
                ML.Paciente pacienteUpdate = new ML.Paciente();
                ML.Result resultTipoSangreUpdate = BL.TipoSangre_DLL.GetAll();
                ML.Result resultPaciente = BL.Paciente.GetyById(idPaciente.Value);
                pacienteUpdate.TipoSangre = new ML.TipoSangre_DLL();

                if (resultPaciente.Correct == true) 
                {
                    pacienteUpdate = (ML.Paciente)resultPaciente.ResultObj;
                    pacienteUpdate.TipoSangre.TiposSangres = resultTipoSangreUpdate.ResultObjs;

                    ViewBag.Titulo = "Actualizar";
                    return View(pacienteUpdate);
                }
                else 
                {
                    ViewBag.Mensaje = resultPaciente.Mensaje;
                    ViewBag.Titulo = "ERROR";
                    return View("Modal");
                }
            }
            
        }

        [HttpPost]
        public ActionResult Form(ML.Paciente paciente) 
        {
            if (paciente.IdPaciente == 0 || paciente.IdPaciente == null)
            {
                ML.Result result = BL.Paciente.Add(paciente);

                if (result.Correct != false)
                {
                    ViewBag.Mensaje = result.Mensaje;
                    return View("Modal");
                }
                else 
                {
                    ViewBag.Mensaje = result.Mensaje;
                    return View("Modal");
                }
                    
            }

            else 
            {
                ML.Result result = BL.Paciente.Update(paciente);

                if (result.Correct != false)
                {
                    ViewBag.Mensaje = result.Mensaje;
                    return View("Modal");
                }
                else 
                return View(result.Mensaje);
            }
        }

        [HttpGet]
        public ActionResult Delete(int idPaciente) 
        {
            ML.Result result = BL.Paciente.Delete(idPaciente);

            if (result.Correct != false)
            {
                ViewBag.Mensaje = result.Mensaje;
                return RedirectToAction("GetAll");
            }
            else 
            {
                ViewBag.Mensaje = result.Mensaje;
                return View("Modal");
            }
        }
    }
}