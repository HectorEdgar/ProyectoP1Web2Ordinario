using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoP1Web2
{
    public partial class ConsumirServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProyectoP1Web2.WebServiceEdgar.WebService1Soap servicio = new ProyectoP1Web2.WebServiceEdgar.WebService1SoapClient();

            String[] items = servicio.MostrarGruposGimnasio();
            for (int i = 0; i < items.Length; i++)
            {
                lb1.Items.Add(items[i]);
            }
            
        }
    }
}