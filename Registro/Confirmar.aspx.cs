﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = Request.QueryString["mbr"];
            String numconf = Request.QueryString["numconf"];

            if (ln.searchEmail(email))
            {
                if (!ln.getConfirmed(email))
                {
                    ln.confirmAccount(email);
                    texto.Text = "¡Enhorabuena!\nTe has registrado correctamente.";
                } else
                {
                    texto.Text = "¡Ya te has registrado!";
                }
            } else
            {
                texto.Text = "Registro incorrecto. Correo incorrecto.";
            }

        }
    }
}