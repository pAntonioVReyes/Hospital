using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();

            try 
            {

                using (DL.HospitalEntities context = new DL.HospitalEntities()) 
                {
                    var query = context.PacienteGetAll().ToList();

                    if (query != null) 
                    {
                        result.ResultObjs = new List<object>();

                        foreach (var pacientes in query) 
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.TipoSangre = new ML.TipoSangre_DLL();

                            paciente.IdPaciente = pacientes.IdPaciente;
                            paciente.Nombre = pacientes.Nombre;
                            paciente.Ap = pacientes.AP;
                            paciente.Am = pacientes.AM;
                            paciente.FechaNacimiento = pacientes.FechaNacimiento.Value.ToString("D");
                            paciente.FechaIngreso = pacientes.FechaIngreso.Value;
                            paciente.TipoSangre.IdTipoSangre = pacientes.IdTipoSangre.Value;
                            paciente.TipoSangre.Nombre = pacientes.TipoSangre;
                            paciente.Sexo = pacientes.Sexo;
                            paciente.Sintomas = pacientes.Sintomas;

                            if(paciente != null) result.ResultObjs.Add(paciente);
                        }

                        if (result.ResultObjs != null) result.Correct = true;
                    }   

                }

            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al encontrar registros \n" + result.Ex;
            }

            return result;
        }

        public static ML.Result GetyById(int id) 
        {
            ML.Result result = new ML.Result();

            try 
            {
                using (DL.HospitalEntities context = new DL.HospitalEntities()) 
                {
                    var query = context.PacienteGetById(id).FirstOrDefault();

                    if(query != null) 
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.TipoSangre = new ML.TipoSangre_DLL();

                        paciente.IdPaciente = query.IdPaciente;
                        paciente.Nombre = query.Nombre;
                        paciente.Ap = query.AP;
                        paciente.Am = query.AM;
                        paciente.FechaNacimiento = query.FechaNacimiento.Value.ToString("D");
                        paciente.FechaIngreso = query.FechaIngreso.Value;
                        paciente.TipoSangre.IdTipoSangre = query.IdTipoSangre.Value;
                        paciente.TipoSangre.Nombre = query.TipoSangre;
                        paciente.Sexo = query.Sexo;
                        paciente.Sintomas = query.Sintomas;

                        result.ResultObj = paciente;

                        if (result.ResultObj != null) result.Correct = true;

                    }
                }

            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al encontrar registro \n" + result.Ex;
            }

            return result;
        }

        public static ML.Result Delete(int id) 
        {
            ML.Result result = new ML.Result();

            try 
            {

                using (DL.HospitalEntities context = new DL.HospitalEntities()) 
                {
                    var query = context.PacienteDelete(id);

                    if (query > 0) 
                    {
                        result.Correct = true;
                        result.Mensaje = "Registro Eliminado";
                    }
                }

            } catch (Exception ex) 
            {
                result.Correct = true;
                result.Ex = ex;
                result.Mensaje = "Error al eliminar registro \n" + result.Ex;
            }

            return result;
        }

        public static ML.Result Add(ML.Paciente paciente) 
        {
            ML.Result result = new ML.Result();

            try 
            {
                using (DL.HospitalEntities context = new DL.HospitalEntities()) 
                {
                    var query = context.PacienteAdd(paciente.Nombre, paciente.Ap, paciente.Am, paciente.FechaNacimiento,paciente.TipoSangre.IdTipoSangre,
                        paciente.Sexo, paciente.Sintomas);

                    if (query > 0) 
                    {
                        result.Correct = true;
                        result.Mensaje = "Registro añadido";
                    }
                }

            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al agregar registro \n" + result.Ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Paciente paciente) 
        {
            ML.Result result = new ML.Result();

            try 
            {
                using (DL.HospitalEntities context = new DL.HospitalEntities()) 
                {
                    var query = context.PacienteUpdate(paciente.Nombre, paciente.Ap, paciente.Am, paciente.FechaNacimiento, paciente.TipoSangre.IdTipoSangre,
                        paciente.Sexo, paciente.Sintomas, paciente.IdPaciente);

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Mensaje = "Registro actualizado";
                    }
                }

            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex=ex;
                result.Mensaje = "Error al actualizar registro \n" + result.Ex;
            }

            return result;
        }
    }
}
