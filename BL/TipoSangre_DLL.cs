using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoSangre_DLL
    {
        public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();

            try 
            {

                using (DL.HospitalEntities context = new DL.HospitalEntities()) 
                {
                    var query = context.TipoSangreGetAll();

                    if (query != null) 
                    {
                        result.ResultObjs = new List<object>();

                        foreach (var tiposSangre in query) 
                        {
                            ML.TipoSangre_DLL tipoSangre = new ML.TipoSangre_DLL();

                            tipoSangre.IdTipoSangre = tiposSangre.IdTipoSangre;
                            tipoSangre.Nombre = tiposSangre.Nombre;

                            if (tipoSangre != null) result.ResultObjs.Add(tipoSangre);
                        }

                        if (result.ResultObjs != null) result.Correct = true;
                    }
                }

            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al encontrar registros \n"+result.Ex;
            }

            return result;
        }

    }
}
