using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace trabajo3
{
    /// <summary>
    /// Descripción breve de MIWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class MIWeb : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Guardar(string NombreAsignatura, int creditos)
        {
            try
            {
                DatoEscuelaEntities ctx = new DatoEscuelaEntities();
                Asignaturas asignaturas = new Asignaturas();
                asignaturas.NombreAsignatura = NombreAsignatura;
                asignaturas.Creditos = creditos;
                ctx.Asignaturas.Add(asignaturas);
                ctx.SaveChanges();
            }
            catch (Exception ex) 
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public List<Asignaturas> listar()
        {
            DatoEscuelaEntities ctx = new DatoEscuelaEntities();
            return ctx.Asignaturas.ToList();
        }

        [WebMethod]
        public bool GuardarAlumno(string Nombre, string ApellidoPAt, string ApellidoMat, string Email, string NumeroMatricula)
        {
            try
            {
                DatoEscuelaEntities ctx = new DatoEscuelaEntities();
                Alumnos alumnos = new Alumnos();
                alumnos.Nombre = Nombre;
                alumnos.ApellidoPAt = ApellidoPAt;
                alumnos.ApellidoMat = ApellidoMat;
                alumnos.Email = Email;
                alumnos.NumeroMatricula = NumeroMatricula;
                ctx.Alumnos.Add(alumnos);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public List<Alumnos> listaralumnos()
        {
            DatoEscuelaEntities ctx = new DatoEscuelaEntities();
            return ctx.Alumnos.ToList();
        }
    }
}
