using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace LogicaNegocio
{
    public class LN
    {
        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();

        /// <summary>
        /// Método que realiza el envió de correo electronico.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="email"></param>
        /// <returns>true si envio el correo satisfactorio | false si fallo en envio de correo </returns>
        public Boolean sendMail (String subject, String body, String email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("hads2207@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hads2207@gmail.com", "hadsaj2122@");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Método que realiza una llamada al método de insertar datos de la base de datos.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="numconfir"></param>
        /// <param name="tipo"></param>
        /// <param name="pass"></param>
        /// <returns>true correcto insert de datos. |false fallo en insertar datos.</returns>
        public Boolean insertUser(String email, String nombre, String apellidos, int numconfir, String tipo, String pass)
        {
            bd.open();
            bool resul = bd.insertUser(email, nombre, apellidos, numconfir, tipo, pass);
            bd.close();
            return resul;
        }

        /// <summary>
        /// Método que realiza una llamada al método actulizar codigo de contraseña de la base de datos y
        /// lo ejecuta con los parámetros indicados.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>codigo de password</returns>
        public void updateCodpass(String email)
        {
            bd.open();
            bd.updateCodpass(email);
            bd.close();
        }

        /// <summary>
        /// Método que realiza una llamada al método getCodPass de la base de datos y
        /// retorna el codpass
        /// </summary>
        /// <param name="email"></param>
        /// <returns>codpass</returns>
        public int getCodpass(String email)
        {
            bd.open();
            int resul = bd.getCodpass(email);
            bd.close();
            return resul;
        }

        /// <summary>
        /// Método que realiza una llamada al método UpdatePassword de la base de datos y
        /// lo ejecuta con los parámetros indicados.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public void updatePassword(String password, String email)
        {
            bd.open();
            bd.updatePassword(password, email);
            bd.close();
        }

        /// <summary>
        /// Método que realiza una llamada al método searchmail de la base de datos
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true si el correo existe en bd</returns>
        public bool searchEmail(String email)
        {
            bd.open();
            bool resul = bd.searchEmail(email);
            bd.close();
            return resul;
        }

        /// <summary>
        /// Método que realiza una llamada al método getPassword de la base de datos
        /// </summary>
        /// <param name="email"></param>
        /// <returns>password en formato string</returns>
        public string getPassword(String email)
        {
            bd.open();
            string resul = bd.getPassword(email);
            bd.close();
            return resul;
        }

        /// <summary>
        /// Método que realiza una llamada al método getConfirmed de la base de datos
        /// </summary>
        /// <param name="email"></param>
        /// <returns>estado de confirmación de una cuenta</returns>
        public bool getConfirmed(String email)
        {
            bd.open();
            bool resul = bd.getConfirmed(email);
            bd.close();
            return resul;
        }

        /// <summary>
        /// Método que realiza una llamada al método confirmAccount de la base de datos y
        /// lo ejecuta con el parámetro indicado.
        /// </summary>
        /// <param name="email"></param>
        public void confirmAccount(String email)
        {
            bd.open();
            bd.confirmAccount(email);
            bd.close();
        }

        /// <summary>
        /// Devuelve el numero de confirmación de creación de un usuario
        /// </summary>
        /// <param name="email"></param>
        /// <returns>int nunconfir</returns>
        public int getNumconfir(String email)
        {
            bd.open();
            int resul = bd.getNumconfir(email);
            bd.close();
            return resul;
        }
    }
}
