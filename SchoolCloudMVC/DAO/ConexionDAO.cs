using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using SchoolCloudMVC.BO;
using System.Web.Mvc;

namespace SchoolCloudMVC.DAO
{
    public class ConexionDAO
    {
     public   SqlConnection con;
        SqlCommand exec;

        SqlDataAdapter adaptador;
        DataSet DataSetAdaptador;
        //constructor
        public  ConexionDAO()
        {
            //base de datos myasp
            //this.con = new SqlConnection("Data Source = SQL5030.site4now.net; Initial Catalog = DB_A35772_SCBD; User Id = DB_A35772_SCBD_admin; Password = mexico10; ");


            con = new SqlConnection("server=LAPTOP-NT04IKD6\\SQLEXPRESS ; database=SchoolCloud ; integrated security = true;");
            //con = new SqlConnection("workstation id=SchoolCloudDataBase.mssql.somee.com;packet size=4096;user id=TICS160914033_SQLLogin_1;pwd=obabqu91sa;data source=SchoolCloudDataBase.mssql.somee.com;persist security info=False;initial catalog=SchoolCloudDataBase");
            //sirve para establecer las consultas e instrucciones SQL que se ejecutarán en el servidor
            exec = new SqlCommand();

        }

        //método para abrir conexión

        public void abrirConexion()
        {
            this.con.Open();

        }

        //método para cerrar conexión
        public void cerrarConexion()
        {
            this.con.Close();
        }

        public int ejecutarSentencia(String strSql) //insert,update, delete
        {
            try
            {
                //donde se asigna el texto de la instrucción SQL a ser ejecutada en el servidor
                this.exec.CommandText = strSql;
                //donde se asigna el objeto de conexión construido con SqlConnection
                this.exec.Connection = this.con;
                this.abrirConexion();
                // indicar la ejecución de la instrucción SQL definida en CommandText, devuelve un valor entero que indica las filas afectadas
                this.exec.ExecuteNonQuery();
                this.cerrarConexion();
                return 1;

            }
            catch (SqlException)
            {
                return 0;
            }
            finally
            {
                this.cerrarConexion();
            }

        }
        public int EjecutarComando(string Comando)
        {
         
            // INSERT, DELETE, UPDATE
            String strComandoSQL = Comando;

            adaptador = new SqlDataAdapter(); //crea la instancia de SqlDataAdapter
            exec = new SqlCommand(); //crea instancia de SqlCommand
         this.exec.Connection = this.con; //crea un objeto de conexion
            this.abrirConexion(); //abre la conexion
           exec.CommandText = strComandoSQL; //establece una instrucción SQL que se va a ejecutar
            int id = Convert.ToInt32(exec.ExecuteScalar()); //ejecuta instrucción sql

            this.cerrarConexion(); //cierra conexion
            return id;
        }
        public int EjecutarComandoFECHA(string Comando, BackendBO bo)
        {
            DateTime fecha = DateTime.Now;
            // INSERT, DELETE, UPDATE
            String strComandoSQL = Comando;

            adaptador = new SqlDataAdapter(); //crea la instancia de SqlDataAdapter
            exec = new SqlCommand(); //crea instancia de SqlCommand
            exec.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha.ToString("yyy-MM-dd HH:mm:ss");
            exec.Parameters.Add("@foto", SqlDbType.VarBinary).Value = bo.Fotouniversidad;
            this.exec.Connection = this.con; //crea un objeto de conexion
            this.abrirConexion(); //abre la conexion
            exec.CommandText = strComandoSQL; //establece una instrucción SQL que se va a ejecutar
            int id = Convert.ToInt32(exec.ExecuteScalar()); //ejecuta instrucción sql

            this.cerrarConexion(); //cierra conexion
            return id;
        }
        public int EjecutarComandoFECHA2(string Comando, UniversidadAccseso bo)
        {
            DateTime fecha = DateTime.Now;
            // INSERT, DELETE, UPDATE
            String strComandoSQL = Comando;

            adaptador = new SqlDataAdapter(); //crea la instancia de SqlDataAdapter
            exec = new SqlCommand(); //crea instancia de SqlCommand
            exec.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha.ToString("yyy-MM-dd HH:mm:ss");
            exec.Parameters.Add("@foto", SqlDbType.VarBinary).Value = bo.fotopublicacion;
            this.exec.Connection = this.con; //crea un objeto de conexion
            this.abrirConexion(); //abre la conexion
            exec.CommandText = strComandoSQL; //establece una instrucción SQL que se va a ejecutar
            int id = Convert.ToInt32(exec.ExecuteScalar()); //ejecuta instrucción sql

            this.cerrarConexion(); //cierra conexion
            return id;
        }
        public int EjecutarComandofoto(string Comando, BackendBO bo)
        {

            // INSERT, DELETE, UPDATE
            String strComandoSQL = Comando;

            adaptador = new SqlDataAdapter(); //crea la instancia de SqlDataAdapter
            exec = new SqlCommand(); //crea instancia de SqlCommand
            exec.Parameters.Add("@foto", SqlDbType.VarBinary).Value = bo.FotoUsuario;
            this.exec.Connection = this.con; //crea un objeto de conexion
            this.abrirConexion(); //abre la conexion
            exec.CommandText = strComandoSQL; //establece una instrucción SQL que se va a ejecutar
            int id = Convert.ToInt32(exec.ExecuteScalar()); //ejecuta instrucción sql

            this.cerrarConexion(); //cierra conexion
            return id;
        }
        public int EjecutarComandofotoUni(string Comando, BackendBO bo)
        {

            // INSERT, DELETE, UPDATE
            String strComandoSQL = Comando;

            adaptador = new SqlDataAdapter(); //crea la instancia de SqlDataAdapter
            exec = new SqlCommand(); //crea instancia de SqlCommand
            exec.Parameters.Add("@foto", SqlDbType.VarBinary).Value = bo.Fotouniversidad;
            this.exec.Connection = this.con; //crea un objeto de conexion
            this.abrirConexion(); //abre la conexion
            exec.CommandText = strComandoSQL; //establece una instrucción SQL que se va a ejecutar
            int id = Convert.ToInt32(exec.ExecuteScalar()); //ejecuta instrucción sql

            this.cerrarConexion(); //cierra conexion
            return id;
        }
        public DataTable EjercutarSentenciaBus(String strSql) //SELECT
        {
            SqlDataAdapter adapter = new SqlDataAdapter(strSql, this.con);
            DataTable tabla = new DataTable();
            //rellenar un objeto DataSet con los resultados del elemento SelectCommand
            adapter.Fill(tabla);
            return tabla;
        }

        public DataSet EjecutarSentencia(SqlCommand SqlComando)
        {

            // SELECT (Devolver registros)
            adaptador = new SqlDataAdapter();
     exec = new SqlCommand();
            DataSetAdaptador = new DataSet();

          exec = SqlComando;
            exec.Connection = this.con;
            this.abrirConexion();
            adaptador.SelectCommand = exec;
            adaptador.Fill(DataSetAdaptador);
            this.cerrarConexion();
            return DataSetAdaptador;

        }
        public List<SelectListItem> EjecutarSetencialistaTiposUsuarios(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["tipo"].ToString(),
                        Value = dr["ID"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }
        public List<SelectListItem> EjecutarSetencialistaTipoCicloEscolar(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["Nombre"].ToString(),
                        Value = dr["IDciclo"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }

        public List<SelectListItem> EjecutarSetencialistaTiposGrado(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["tipogrado"].ToString(),
                        Value = dr["IDgrado"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }
        public List<SelectListItem> EjecutarSetencialistauniversidades(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["nombre"].ToString(),
                        Value = dr["ID"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }
        public List<SelectListItem> EjecutarSetencialistaTipoUniversidad(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["tipo"].ToString(),
                        Value = dr["idtipouni"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }

        public List<SelectListItem> ListaPais(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["Nombre"].ToString(),
                        Value = dr["IDPais"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }
        public List<SelectListItem> ListaEstado(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["Nombre"].ToString(),
                        Value = dr["IDEstado"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }
        public List<SelectListItem> ListaCiudad(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["Nombre"].ToString(),
                        Value = dr["IDCiudad"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }
        public List<SelectListItem> ListaArea(String strSql)
        {
            var estados = new List<SelectListItem>();
            this.abrirConexion();
            var query = new SqlCommand(strSql, this.con);
            using (var dr = query.ExecuteReader())
            {
                while (dr.Read())
                {

                    var estado = new SelectListItem
                    {
                        Text = dr["NombreArea"].ToString(),
                        Value = dr["ID"].ToString()
                    };


                    estados.Add(estado);
                }
            }
            this.cerrarConexion();
            return estados;
        }
    }
}