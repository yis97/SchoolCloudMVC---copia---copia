using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SchoolCloudMVC.DAO
{
    public class ConexionFOTO
    {
        SqlCommand comandosql;
        SqlDataAdapter adaptador;
        DataSet datasetadaptador;
        SqlConnection coneccion;

        //DESKTOP-TT12AGM
        public ConexionFOTO()
        {
            adaptador = new SqlDataAdapter();
            comandosql = new SqlCommand();
            coneccion = new SqlConnection();



        }

        public SqlConnection establecerConexion()
        {
            string cs = "server=LAPTOP-NT04IKD6\\SQLEXPRESS ; database=SchoolCloud ; integrated security = true";
        
            coneccion = new SqlConnection(cs);
            return coneccion;
        }


        public void abrirConexion()
        {
            coneccion.Open();
        }
        public void cerrarConexion()
        {
            coneccion.Close();
        }
        public DataSet EjecutarSentencia(SqlCommand SqlComando)
        {

            // SELECT (Devolver registros)
            adaptador = new SqlDataAdapter();
            comandosql = new SqlCommand();
            datasetadaptador = new DataSet();

            comandosql = SqlComando;
            comandosql.Connection = this.establecerConexion();
            this.abrirConexion();
            adaptador.SelectCommand = comandosql;
            adaptador.Fill(datasetadaptador);
            this.cerrarConexion();
            return datasetadaptador;

        }
        public int EjecutarComando(SqlCommand SqlComando)
        {
            // INSERT, DELETE, UPDATE
            comandosql = new SqlCommand();
            comandosql = SqlComando;
            comandosql.Connection = this.establecerConexion();
            this.abrirConexion();
            int id  = Convert.ToInt32(comandosql.ExecuteScalar());
            this.cerrarConexion();
            return id;

        }
    }
}