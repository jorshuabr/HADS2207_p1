using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class BBDD
    {
        private SqlConnection connection;

        public BBDD()
        {
            connect();
        }      

        /// <summary>
        /// Este método realiza la conexion a la base de datos.
        /// </summary>
        /// <returns>Boolean</returns>
        public void connect()
        { 
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:hads2207.database.windows.net,1433";
                builder.UserID = "apelipian001@ikasle.ehu.eus@hads2207";
                builder.Password = "hadsaj2122@";
                builder.InitialCatalog = "HADS22-07";

                connection = new SqlConnection(builder.ConnectionString);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Este método realiza el cierre de la conexión de la Base de Datos.
        /// </summary>
        public void close()
        {
            connection.Close();
        }

        /// <summary>
        /// Este método realiza la apertura de la Base de Datos.
        /// </summary>
        public void open()
        {
            connection.Open();
        }

        /// <summary>
        /// Inserta un nuevo usuario a la base de datos con los valores enviados por parámetro.
        /// </summary>
        public Boolean insertUser(String email, String nombre, String apellidos, int numconfir, String tipo, String pass)
        {
            String sql = "INSERT INTO Usuarios VALUES(@email, @nombre, @apellidos, @numconfir, 0, @tipo, @pass, 0)";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);

            sqlCmd.Parameters.AddWithValue("@email", email );
            sqlCmd.Parameters.AddWithValue("@nombre", nombre );
            sqlCmd.Parameters.AddWithValue("@apellidos", apellidos);
            sqlCmd.Parameters.AddWithValue("@numconfir", numconfir);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            sqlCmd.Parameters.AddWithValue("@pass", pass);

            return (sqlCmd.ExecuteNonQuery()==0);
            
        }

        /// <summary>
        /// El siguiente método actualiza el codPass de un determinado email
        /// cuando se desea cambiar la contraseña.
        /// </summary>
        /// <param name="email"></param>
        public void updateCodpass(String email)
        {
            Random generator = new Random();
            int codChangePass = int.Parse(generator.Next(0, 1000000).ToString("D6"));
            String sql = "UPDATE Usuarios SET codpass=@codChangePass WHERE email=@email";

            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@codChangepass", codChangePass);
            sqlCmd.Parameters.AddWithValue("@email",email);

            sqlCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Retorna el codpass de una fila correspondiente al email enviado por parámetro
        /// </summary>
        /// <param name="email"></param>
        /// <returns>int codpass</returns>
        public int getCodpass(String email)
        {
            String sql = "SELECT codpass FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);
            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return int.Parse(string.Format("{0}", reader["codpass"]));
                }
            }
            return 0;
        }

        /// <summary>
        /// Actualiza en valor del campo pass en la base de datos
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public void updatePassword(String password, String email)
        {
            String sql = "UPDATE Usuarios SET pass=@password WHERE email=@email";

            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@password", password);
            sqlCmd.Parameters.AddWithValue("@email", email);

            sqlCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// método que realiza la busquede del correo enviado por parámetro
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true tupla existente | false tupla inexistente</returns>
        public Boolean searchEmail(String email)
        {
            String sql = "SELECT email FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = sqlCmd.ExecuteReader();
            return reader.Read();
        }

        /// <summary>
        /// método que devuelve el campo contraseña de una tupla determinada correspondiente a 
        /// lo enviado por parámetro.        l
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>password de la tupla correspondiente</returns>
        public string getPassword(String email)
        {
            String sql = "SELECT pass FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return string.Format("{0}", reader["pass"]);
                }
            }
            return "";
        }

        /// <summary>
        /// este método retorna valor del campo confirmado de una determinada tupla
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true si confirmado |false no confirmado</returns>
        public bool getConfirmed(String email)
        {
            String sql = "SELECT confirmado FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return bool.Parse(string.Format("{0}", reader["confirmado"]));
                }
            }
            return false;
        }

        /// <summary>
        /// Método que marca como confirmado un usuario
        /// </summary>
        /// <param name="email"></param>
        public void confirmAccount(String email)
        {
            String sql = "UPDATE Usuarios SET confirmado=@confirmado WHERE email=@email";

            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@confirmado", true);

            sqlCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Devuelve el numero de confirmación de creación de un usuario, retorna el campo
        /// numconfir de una determinada tupla
        /// </summary>
        /// <param name="email"></param>
        /// <returns>int nunconfir</returns>
        public int getNumconfir(String email)
        {
            String sql = "SELECT numconfir FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return int.Parse(string.Format("{0}", reader["numconfir"]));
                }
            }
            return 0;
        }
    }
}
