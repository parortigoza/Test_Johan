using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class DataCliente
    {
        private DataConnString connString;

        public DataCliente()
        {
            connString = new DataConnString();
        }

        public ClienteModel ObtieneClientePorIdEmpresaUno(string identidad)
        {
            //Mensaje mensaje = new Mensaje();
            string connexion = this.connString.ObtenerConexionEmpresaUno();
            //List<ClienteModels> listaDetalle = new List<ClienteModels>();
            ClienteModel objCliente = new ClienteModel();
            SqlConnection sqlConnection = new SqlConnection(connexion);

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("OBTENERCLIENTEPORID", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IDENTIDAD", identidad);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    objCliente = armaListaClientes(reader, "Empresa Uno", 1);
                }
            }
            catch (Exception ex)
            {
                //objDetalle = new Detalle();
                //objDetalle.MensajeId = -1;
                //objDetalle.textoMensaje = "Se presentó una falla al obtener el detalle de la factura; comuníquese con el área de soporte";
                //listaDetalle.Add(objDetalle);
            }
            finally
            {
                sqlConnection.Close();
            }

            return objCliente;
        }

        public ClienteModel ObtieneClientePorIdEmpresaDos(string identidad)
        {
            //Mensaje mensaje = new Mensaje();
            string connexion = this.connString.ObtenerConexionEmpresaDos();
            //List<ClienteModels> listaDetalle = new List<ClienteModel>();
            ClienteModel objCliente = new ClienteModel();
            SqlConnection sqlConnection = new SqlConnection(connexion);

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("OBTENERCLIENTEPORID", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IDENTIDAD", identidad);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    objCliente = armaListaClientes(reader, "Empresa Dos", 2);

                }
            }
            catch (Exception ex)
            {
                //objDetalle = new Detalle();
                //objDetalle.MensajeId = -1;
                //objDetalle.textoMensaje = "Se presentó una falla al obtener el detalle de la factura; comuníquese con el área de soporte";
                //listaDetalle.Add(objDetalle);
            }
            finally
            {
                sqlConnection.Close();
            }

            return objCliente;
        }

        private ClienteModel armaListaClientes(SqlDataReader reader, string Empresa, int indiceBD)
        {
            //List<ClienteModels> listaDetalle = new List<ClienteModels>();
            ClienteModel objCliente = new ClienteModel();
            while (reader.Read())
            {
                objCliente = new ClienteModel();
                objCliente.Identidad = reader["identidad"].ToString();
                objCliente.Nombre = reader["nombre"].ToString();
                objCliente.Apellido = reader["apellido"].ToString();
                objCliente.FechaUltimaCompra = Convert.ToDateTime(reader["fechaultmacompra"].ToString()).ToShortDateString();
                objCliente.ComprasRealizadas = Convert.ToInt32(reader["Comprasrealizadas"].ToString());
                objCliente.Correo = reader["correo"].ToString();
                objCliente.Ciudad = reader["ciudad"].ToString();
                objCliente.Estado = Convert.ToBoolean(reader["estado"].ToString()) ? "Activo" : "Inactivo";
                objCliente.Empresa = Empresa;
                objCliente.indiceBD = indiceBD;
            }

            return objCliente;
        }
    }
}
