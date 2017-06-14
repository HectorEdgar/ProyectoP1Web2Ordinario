using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ProyectoP1Web2.Models;
using System.Data;
using System.Reflection;

namespace ProyectoP1Web2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://IS6A-MRHE.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SistemaGimnasioEntities entity;

        [WebMethod]
        public string RetornarCadena()
        {
            return "Esto es una cadena :v";
        }

        [WebMethod]
        public DataTable buscarGrupoGimnasio(int idGimnasio,String nombre)
        {
            entity = new SistemaGimnasioEntities();
            return ToDataTable(entity.GrupoGimnasio.Select(p => new { p.idGimnasio, p.nombre, p.IdHorario }).Where(p=>p.idGimnasio.Equals(idGimnasio)).Where(p=> p.nombre.Contains(nombre)).ToList());
        }

        [WebMethod]
        public List<String> MostrarGruposGimnasio()
        {
            List<string> gruposGimnasios = new List<string>();
            entity = new SistemaGimnasioEntities();
            foreach (var item in entity.GrupoGimnasio.Select(p => p))
            {
                gruposGimnasios.Add(item.nombre);
            } 


            return gruposGimnasios;
        }
        [WebMethod]
        public DataTable MostrarGruposGimnasio2()
        {
            entity = new SistemaGimnasioEntities();         
            return ToDataTable(entity.GrupoGimnasio.Select(p => new { p.idGimnasio,p.nombre,p.IdHorario}).ToList());
        }



        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
