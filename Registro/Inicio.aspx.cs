using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.8.3.min.js",
                DebugPath = "~/scripts/jquery-1.8.3.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.js"
            });
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ln.searchEmail(correo_text.Text))
            {
                if (psw_text.Text.Equals(ln.getPassword(correo_text.Text)))
                {
                    if (ln.getConfirmed(correo_text.Text))
                    {
                        Response.Redirect("https://hads22-07.azurewebsites.net/Gestion.aspx");
                    } else
                    {
                        error_login.Text = "Tu cuenta no está confirmada. Pulsa en el siguiente botón para obtener un nuevo correo de confirmación:\n";
                        enlace.Visible = true;
                    }
                } else
                {
                    error_login.Text = "Contraseña no válida";
                }
            } else
            {
                error_login.Text = "Correo no existe";
            }
        }

        protected void enlace_Click(object sender, EventArgs e)
        {
            int numconfir = ln.getNumconfir(correo_text.Text);
            String subject = "Confirmación registro";
            String body = "Para confirmar el registro en la página HADS22-07, accesa el siguiente enlace:\nhttp://hads22-07.azurewebsites.net/Confirmar.aspx?mbr=" + correo_text.Text + "&numconf=" + numconfir;
            ln.sendMail(subject, body, correo_text.Text);
            correo_enviado.Text = "Correo enviado. Verifica tu buzón.";
        }
    }
}