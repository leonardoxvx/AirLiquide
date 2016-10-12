using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Datos
    {
        Database db = DatabaseFactory.CreateDatabase();

        public DataSet getBuscarUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            if (user.Rut == string.Empty)
            {
                db.AddInParameter(cmd, "@rut", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@rut", DbType.String, user.Rut);
            }
            
            db.AddInParameter(cmd, "@nombre", DbType.String, user.Nombre);
            db.AddInParameter(cmd, "@idPerfil", DbType.String, user.IdPerfil);
            db.AddInParameter(cmd, "@login", DbType.String, user.Login);
            db.AddInParameter(cmd, "@clave", DbType.String, user.Clave);
            db.AddInParameter(cmd, "@areaCargo", DbType.String, user.AreaCargo);
            db.AddInParameter(cmd, "@activo", DbType.String, user.Activo);


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarUsuarioExporte()
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioExporte");
            
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarUsuarioPorPerfil(string idPerfil, int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioPorPerfil");

            db.AddInParameter(cmd, "@idPerfil", DbType.String, idPerfil);
            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarHistorialGestiones(string rut, int idMandante)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarHistorialGestiones");

            db.AddInParameter(cmd, "@rut", DbType.String, rut);
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el historial de gestiones, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el historial de gestiones, " + ex.Message, ex);
            }
        }



        public DataSet getBuscarValUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_ValUsuario");

            
            db.AddInParameter(cmd, "@login", DbType.String, user.Login);


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }
        

        public DataSet getBuscarUsuarioMandante(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioMandante");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarUsuarioSucursal(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioSucursal");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }
        public DataSet getBuscarUsuarioAsignadoMandante(int idMandante)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioAsignadoPorMandante");

            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }
        

        public string setInUpUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUpUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@Rut", DbType.String, user.Rut);
            db.AddInParameter(cmd, "@Nombre", DbType.String, user.Nombre);
            db.AddInParameter(cmd, "@Email", DbType.String, user.Email);
            if (user.IdPerfil == 0)
            {
                db.AddInParameter(cmd, "@IdPerfil", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdPerfil", DbType.String, user.IdPerfil);
            }
            db.AddInParameter(cmd, "@Login", DbType.String, user.Login);
            db.AddInParameter(cmd, "@Clave", DbType.String, user.Clave);
            db.AddInParameter(cmd, "@AreaCargo", DbType.String, user.AreaCargo);
            db.AddInParameter(cmd, "@Foto", DbType.String, user.Foto);
            db.AddInParameter(cmd, "@Activo", DbType.String, user.Activo);

            if (user.IdUsuarioDiscador == 0)
            {
                db.AddInParameter(cmd, "@idUsuarioDiscador", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idUsuarioDiscador", DbType.String, user.IdUsuarioDiscador);
            }
            db.AddInParameter(cmd, "@idSucursal", DbType.String, user.IdSucursal);

            try
            {
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
        }
        
        public void setInUsuarioMandante(UsuarioMandante user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUsuarioMandante");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@IdMandante", DbType.String, user.IdMandante);
           
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario mandante, " + ex.Message, ex);
            }
        }


        public void setInUsuarioPorSucursal(int idUsuario, string idSucursal)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUsuarioPorSucursal");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            db.AddInParameter(cmd, "@idSucursal", DbType.String, idSucursal);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario mandante, " + ex.Message, ex);
            }
        }

        public void setDelUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
        }

        public void setUpFotoUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpFotoUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@foto", DbType.String, user.Foto);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la fotografia del usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la fotografia del usuario, " + ex.Message, ex);
            }
        }
        

        public void setDelUsuarioMandante(UsuarioMandante user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelUsuarioMandante");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
        }



        public void setDelUsuarioSucursal(int idUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelUsuarioSucursal");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
        }


        //PERFIL




        public DataSet getBuscarPerfil(Perfil per)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarPerfil");
            //@idMandante int, @nomMandante varchar(30), @razonSocial varchar(100), @giro varchar(50), @rut varchar(12), @activo int
            db.AddInParameter(cmd, "@idPerfil", DbType.String, per.IdPerfil);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el perfil, " + ex.Message, ex);
            }
        }


        //MANDANTE

        public DataSet getBuscarMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMandante");
            //@idMandante int, @nomMandante varchar(30), @razonSocial varchar(100), @giro varchar(50), @rut varchar(12), @activo int
            db.AddInParameter(cmd, "@idMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@nomMandante", DbType.String, man.NomMandante);
            db.AddInParameter(cmd, "@razonSocial", DbType.String, man.RazonSocial);
            db.AddInParameter(cmd, "@giro", DbType.String, man.Giro);
            db.AddInParameter(cmd, "@rut", DbType.String, man.Rut);
            db.AddInParameter(cmd, "@activo", DbType.String, man.Activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el mandante, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarMandanteArchivo(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMandanteArchivo");
            //@idMandante int
            db.AddInParameter(cmd, "@idMandante", DbType.String, man.IdMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el mandante archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el mandante archivo, " + ex.Message, ex);
            }
        }
        
        public DataSet getBuscarDeudorArchivo(Deudor deudor, int idMandante)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarDeudorArchivo");
            //@idMandante int
            db.AddInParameter(cmd, "@rutDeudor", DbType.String, deudor.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el deudor archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el deudor archivo, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTipoCliente(TipoCliente tc)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_SeTipoCliente");

            db.AddInParameter(cmd, "@idTipoCliente", DbType.String, tc.IdTipoCliente);
            db.AddInParameter(cmd, "@nomTipoCliente", DbType.String, tc.NomTipoCliente);
            db.AddInParameter(cmd, "@activo", DbType.String, tc.Activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo cliente, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo cliente, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTipoIntereses(TipoInteres ti)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTipoIntereses");

            db.AddInParameter(cmd, "@activo", DbType.String, ti.Activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar tipo de intereses, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar tipo de intereses, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarMoneda(Moneda mo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMoneda");
            
            db.AddInParameter(cmd, "@activo", DbType.String, mo.Activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la moneda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la moneda, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarComuna(Comuna co)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarComuna");

            db.AddInParameter(cmd, "@idComuna", DbType.String, co.IdComuna);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la comuna, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la comuna, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarEtapaCobranza(int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarEtapaCobranza");

            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la etapa, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la etapa, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarEstadoDeuda(int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarEstadoDeuda");

            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el estado deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el estado deuda, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarEstadoDeuda2(int activo, int? soloAdmin)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarEstadoDeuda2");

            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            db.AddInParameter(cmd, "@admin", DbType.String, soloAdmin);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el estado deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el estado deuda, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarProbabilidadCobro(int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarProbabilidadCobro");

            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar probabilidad, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar probabilidad, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTipoPersona(int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTipoPersona");

            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo de persona, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo de persona, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarAging(int idMandante, int idEjecutivo, string rut, string idSector, string idSucursal)
        {
            //@idMandante int, @idEjecutivo int, @rut varchar(12), @idSector varchar(10), @sucursal varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarAGING");

            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);

            if (idEjecutivo == 0)
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, idEjecutivo);
            }
            
            if (rut == string.Empty)
            {
                db.AddInParameter(cmd, "@rut", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@rut", DbType.String, rut);
            }

            if (idSector == "0")
            {
                db.AddInParameter(cmd, "@idSector", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idSector", DbType.String, idSector);
            }

            if (idSucursal == "0")
            {
                db.AddInParameter(cmd, "@sucursal", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@sucursal", DbType.String, idSucursal);
            }
            

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo de persona, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo de persona, " + ex.Message, ex);
            }
        }
        

        public DataSet getBuscarDeudor(Deudor deudor)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarDeudor");

            db.AddInParameter(cmd, "@RutDeudor", DbType.String, deudor.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, deudor.IdMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el deudor, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarMensajes(Usuario usuario, int? leido)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMensajes");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, usuario.IdUsuario);
            db.AddInParameter(cmd, "@leido", DbType.String, leido);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el mensaje, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el mensaje, " + ex.Message, ex);
            }
        }
        

        public void setInUpMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUpMandante");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@NomMandante", DbType.String, man.NomMandante);
            db.AddInParameter(cmd, "@RazonSocial", DbType.String, man.RazonSocial);
            db.AddInParameter(cmd, "@Giro", DbType.String, man.Giro);
            db.AddInParameter(cmd, "@Rut", DbType.String, man.Rut);
            db.AddInParameter(cmd, "@Direccion", DbType.String, man.Direccion);
            if (man.IdComuna == "0")
            {
                db.AddInParameter(cmd, "@idComuna", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idComuna", DbType.String, man.IdComuna);
            }
            
            db.AddInParameter(cmd, "@Telefono", DbType.String, man.Telefono);
            db.AddInParameter(cmd, "@RepLegalNombre", DbType.String, man.RepLegalNombre);
            db.AddInParameter(cmd, "@RepLegalRut", DbType.String, man.RepLegalRut);
            db.AddInParameter(cmd, "@ContactoNombre", DbType.String, man.ContactoNombre);
            db.AddInParameter(cmd, "@ContactoEmail", DbType.String, man.ContactoEmail);
            db.AddInParameter(cmd, "@DeudaNomAdic1", DbType.String, man.DeudaNomAdic1);
            db.AddInParameter(cmd, "@DeudaNomAdic2", DbType.String, man.DeudaNomAdic2);
            db.AddInParameter(cmd, "@DeudaNomAdic3", DbType.String, man.DeudaNomAdic3);
            db.AddInParameter(cmd, "@DeudaNomAdic4", DbType.String, man.DeudaNomAdic4);
            db.AddInParameter(cmd, "@DeudaNomAdic5", DbType.String, man.DeudaNomAdic5);
            db.AddInParameter(cmd, "@DeudaNomAdic6", DbType.String, man.DeudaNomAdic6);
            db.AddInParameter(cmd, "@DeudaNomAdic7", DbType.String, man.DeudaNomAdic7);
            db.AddInParameter(cmd, "@DeudaNomAdic8", DbType.String, man.DeudaNomAdic8);
            db.AddInParameter(cmd, "@DeudaNomAdic9", DbType.String, man.DeudaNomAdic9);
            db.AddInParameter(cmd, "@DeudaNomAdic10", DbType.String, man.DeudaNomAdic10);
            db.AddInParameter(cmd, "@DeudorNomAdic1", DbType.String, man.DeudorNomAdic1);
            db.AddInParameter(cmd, "@DeudorNomAdic2", DbType.String, man.DeudorNomAdic2);
            db.AddInParameter(cmd, "@DeudorNomAdic3", DbType.String, man.DeudorNomAdic3);
            db.AddInParameter(cmd, "@DeudorNomAdic4", DbType.String, man.DeudorNomAdic4);
            db.AddInParameter(cmd, "@DeudorNomAdic5", DbType.String, man.DeudorNomAdic5);
            db.AddInParameter(cmd, "@TasaMaxConv", DbType.String, man.TasaMaxConv);
            if (man.IdTipoInteres == 0)
            {
                db.AddInParameter(cmd, "@IdTipoInteres", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdTipoInteres", DbType.String, man.IdTipoInteres);
            }

            if (man.IdTipoCliente == 0)
            {
                db.AddInParameter(cmd, "@IdTipoCliente", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdTipoCliente", DbType.String, man.IdTipoCliente);
            }
            
            db.AddInParameter(cmd, "@InteresMora", DbType.String, man.InteresMora);
            
            if (man.IdMoneda == 0)
            {
                db.AddInParameter(cmd, "@IdMoneda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdMoneda", DbType.String, man.IdMoneda);
            }
            db.AddInParameter(cmd, "@Activo", DbType.String, man.Activo);
            db.AddInParameter(cmd, "@RutaLogo", DbType.String, man.RutaLogo);
            db.AddInParameter(cmd, "@Skin", DbType.String, man.Skin);
            db.AddInParameter(cmd, "@IdTipoTipificacion", DbType.String, man.IdTipoTipificacion);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el mandante, " + ex.Message, ex);
            }
        }


        
        public void setDelMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelMandante");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el mandante, " + ex.Message, ex);
            }
        }

        public void setUpContrasena(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpPassword");
            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@clave", DbType.String, user.Clave);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el usuario, " + ex.Message, ex);
            }
        }
        
        public void setInDeudorArchivos(Deudor deu, int idMandante, string rutaArchivo, int idUsuarioIngreso, string descripcion, string nombre)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_IngresarDeudorArchivos");
            db.AddInParameter(cmd, "@rutDeudor", DbType.String, deu.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            db.AddInParameter(cmd, "@rutaArchivo", DbType.String, rutaArchivo);
            db.AddInParameter(cmd, "@idUsuarioIngreso", DbType.String, idUsuarioIngreso);
            db.AddInParameter(cmd, "@descripcion", DbType.String, descripcion);
            db.AddInParameter(cmd, "@nombre", DbType.String, nombre);

            //@rutDeudor varchar(12), @idMandante int, @idArchivo int, @rutaArchivo varchar(100), @idUsuarioIngreso int, @descripcion varchar(250), @nombre varchar(100)
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el archivo del deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el archivo del deudor, " + ex.Message, ex);
            }
        }
        
        public string setInDeudor(Deudor deudor)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InDeudor");
            db.AddInParameter(cmd, "@RutDeudor", DbType.String, deudor.RutDeudor);
            db.AddInParameter(cmd, "@IdMandante", DbType.String, deudor.IdMandante);
            db.AddInParameter(cmd, "@NombreDeudor", DbType.String, deudor.NombreDeudor);
            db.AddInParameter(cmd, "@IdUsuarioIngreso", DbType.String, deudor.IdUsuarioIngreso);
            db.AddInParameter(cmd, "@IdUsuarioModif", DbType.String, deudor.IdUsuarioModif);
            db.AddInParameter(cmd, "@RepLegalRut", DbType.String, deudor.RepLegalRut);
            db.AddInParameter(cmd, "@RepLegalNombre", DbType.String, deudor.RepLegalNombre);

            db.AddInParameter(cmd, "@rut", DbType.String, deudor.rut);

            if (deudor.IdTipoPersona == 0)
            {
                db.AddInParameter(cmd, "@IdTipoPersona", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdTipoPersona", DbType.String, deudor.IdTipoPersona);
            }

            if (deudor.IdAsignacion == 0)
            {
                db.AddInParameter(cmd, "@IdAsignacion", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdAsignacion", DbType.String, deudor.IdAsignacion);
            }
            
            db.AddInParameter(cmd, "@Observacion", DbType.String, deudor.Observacion);
            db.AddInParameter(cmd, "@ObsSistema", DbType.String, deudor.ObsSistema);
            if (deudor.IdEtapaCobranza == 0)
            {
                db.AddInParameter(cmd, "@IdEtapaCobranza", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdEtapaCobranza", DbType.String, deudor.IdEtapaCobranza);
            }

            if (deudor.IdCampana ==0)
            {
                db.AddInParameter(cmd, "@IdCampana", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdCampana", DbType.String, deudor.IdCampana);
            }
            
            db.AddInParameter(cmd, "@CodUltimaGestionEj", DbType.String, deudor.CodUltimaGestionEj);
            db.AddInParameter(cmd, "@CodUltimaGestionJud", DbType.String, deudor.CodUltimaGestionJud);
            if (deudor.IdUltGestionEJ==0)
            {
                db.AddInParameter(cmd, "@IdUltGestionEJ", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdUltGestionEJ", DbType.String, deudor.IdUltGestionEJ);
            }
            if (deudor.IdUltGestionJud ==0)
            {
                db.AddInParameter(cmd, "@IdUltGestionJud", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdUltGestionJud", DbType.String, deudor.IdUltGestionJud);
            }
            db.AddInParameter(cmd, "@Adic1", DbType.String, deudor.Adic1);
            db.AddInParameter(cmd, "@Adic2", DbType.String, deudor.Adic2);
            db.AddInParameter(cmd, "@Adic3", DbType.String, deudor.Adic3);
            db.AddInParameter(cmd, "@Adic4", DbType.String, deudor.Adic4);
            db.AddInParameter(cmd, "@Adic5", DbType.String, deudor.Adic5);
            db.AddInParameter(cmd, "@IdUsuarioAsig", DbType.String, deudor.IdUsuarioIngreso);
            db.AddInParameter(cmd, "@CampanaCliente", DbType.String, deudor.CampanaCliente);
            if (deudor.IdProbabilidadCobro ==0)
            {
                db.AddInParameter(cmd, "@IdProbabilidadCobro", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdProbabilidadCobro", DbType.String, deudor.IdProbabilidadCobro);
            }
            db.AddInParameter(cmd, "@IdCondicionPago", DbType.String, deudor.IdCondicionPago);
            db.AddInParameter(cmd, "@fechaIngreso", DbType.String, deudor.FechaIngreso);
            db.AddInParameter(cmd, "@renovable", DbType.String, deudor.Renovable);
            db.AddInParameter(cmd, "@fechaTerminoContrato", DbType.String, deudor.FechaTerminoContrato);
            db.AddInParameter(cmd, "@responsableComercial", DbType.String, deudor.ResponsableComercial);
            db.AddInParameter(cmd, "@idSector", DbType.String, deudor.IdSector);
            


            try
            {
                string valor;
                valor = db.ExecuteScalar(cmd).ToString();
                return valor;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el deudor, " + ex.Message, ex);
            }
        }

        public void setDelMandanteArchivo(Mandante man, string idArchivo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelMandanteArchivo");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@IdArchivo", DbType.String, idArchivo);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
        }


        public void setDelDeudorArchivo(Deudor deu,int idMandante, int idArchivo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelDeudorArchivo");
            db.AddInParameter(cmd, "@rutDeudor", DbType.String, deu.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            db.AddInParameter(cmd, "@idArchivo", DbType.String, idArchivo);
            //@rutDeudor varchar(12),@idMandante int,@idArchivo int
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
        }


        public void setInMandanteArchivo(Mandante man, string nombre, string desc, string ruta, string idUsuarioIngreso)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InMandanteArchivo");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@nombre", DbType.String, nombre);
            db.AddInParameter(cmd, "@descripcion", DbType.String, desc);
            db.AddInParameter(cmd, "@rutaArchivo", DbType.String, ruta);
            db.AddInParameter(cmd, "@idUsuarioIngreso", DbType.String, idUsuarioIngreso);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el archivo, " + ex.Message, ex);
            }
        }
        
        public void setUpLogoMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpLogoMandante");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@logo", DbType.String, man.RutaLogo);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar el logo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el logo, " + ex.Message, ex);
            }
        }

        
        public string setInAsignacion(Asignacion asig)
        {
            //@idMandante int, @nomAsignacion varchar(100),@fechaAsignacion varchar(20),@fechaInicio varchar(20),
            //@fechaTermino varchar(20),@activo int
            DbCommand cmd = db.GetStoredProcCommand("stp_InAsignacion");
            db.AddInParameter(cmd, "@idMandante", DbType.String, asig.IdMandante);
            db.AddInParameter(cmd, "@nomAsignacion", DbType.String, asig.NomAsignacion);
            db.AddInParameter(cmd, "@fechaAsignacion", DbType.String, asig.FechaAsignacion);
            db.AddInParameter(cmd, "@fechaInicio", DbType.String, asig.FechaInicio);

            db.AddInParameter(cmd, "@fechaTermino", DbType.String, asig.FechaTermino);
            db.AddInParameter(cmd, "@activo", DbType.String, asig.Activa);
            try
            {
                string valor;
                valor = db.ExecuteScalar(cmd).ToString();
                return valor;
                //db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar la asignacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar la asignacion, " + ex.Message, ex);
            }
        }


        public void setUpAsignacion(Asignacion asig)
        {
            //@idAsignacion int, @idMandante int, @nomAsignacion varchar(100),@fechaAsignacion varchar(20),
            //@fechaInicio varchar(20),@fechaTermino varchar(20),@activo int
            DbCommand cmd = db.GetStoredProcCommand("stp_UpAsignacion");
            db.AddInParameter(cmd, "@idAsignacion", DbType.String, asig.IdAsignacion);
            db.AddInParameter(cmd, "@idMandante", DbType.String, asig.IdMandante);
            db.AddInParameter(cmd, "@nomAsignacion", DbType.String, asig.NomAsignacion);
            
            db.AddInParameter(cmd, "@fechaAsignacion", DbType.String, asig.FechaAsignacion);
            db.AddInParameter(cmd, "@fechaInicio", DbType.String, asig.FechaInicio);

            db.AddInParameter(cmd, "@fechaTermino", DbType.String, asig.FechaTermino);
            db.AddInParameter(cmd, "@activo", DbType.String, asig.Activa);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la asignacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la asignacion, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarAsignacion(int activo,int idMandante)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarAsignacion");

            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la asignacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la asignacion, " + ex.Message, ex);
            }
        }

        public void setDelAsignacion(Asignacion asig)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelAsignacion");
            db.AddInParameter(cmd, "@IdAsignacion", DbType.String, asig.IdAsignacion);
          

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la asignacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la asignacion, " + ex.Message, ex);
            }
        }

        
        public DataSet getBuscarTipoDocumento(int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTipoDocumento");
            if (activo == 2)
            {
                db.AddInParameter(cmd, "@activo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@activo", DbType.String, activo);
            }
            

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo de documento, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo de documento, " + ex.Message, ex);
            }
        }
        
        public string setInTipoDocumento(TipoDocumento tDoc)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InTipoDocumento");
            db.AddInParameter(cmd, "@nomTipoDocumento", DbType.String, tDoc.NomTipoDocumento);
            db.AddInParameter(cmd, "@activo", DbType.String, tDoc.Activo);
            try
            {
                string valor;
                valor = db.ExecuteScalar(cmd).ToString();
                return valor;
                //db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar la asignacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar la asignacion, " + ex.Message, ex);
            }
        }

        public void setUpTipoDocumento(TipoDocumento tDoc)
        {
            //@nomTipoDocumento varchar(100),@activo int
            
            DbCommand cmd = db.GetStoredProcCommand("stp_UpTipoDocumento");
            db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, tDoc.IdTipoDocumento);
            db.AddInParameter(cmd, "@nomTipoDocumento", DbType.String, tDoc.NomTipoDocumento);
            db.AddInParameter(cmd, "@activo", DbType.String, tDoc.Activo);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el tipo de documento, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el tipo de documento, " + ex.Message, ex);
            }
        }

        public void setDelTipoDocumento(TipoDocumento tDoc)
        {
            //@nomTipoDocumento varchar(100),@activo int
            DbCommand cmd = db.GetStoredProcCommand("stp_DelTipoDocumento");
            db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, tDoc.IdTipoDocumento);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el tipo de documento, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el tipo de documento, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarDeudaPorRutDeudor(Deudor deu)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarDeudaPorRutDeudor");
            db.AddInParameter(cmd, "@rutDeudor", DbType.String, deu.RutDeudor);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el rut deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el rut deudor, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarDeudaDetalle(Deuda deuda)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarDeudaDetalle");

            db.AddInParameter(cmd, "@rutDeudor", DbType.String, deuda.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, deuda.IdMandante);

            if (deuda.IdTipoDocumento == "0")
            {
                db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, deuda.IdTipoDocumento);
            }

            if (deuda.IdEstadoDeuda == 0)
            {
                db.AddInParameter(cmd, "@idEstadoDeuda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idEstadoDeuda", DbType.String, deuda.IdEstadoDeuda);
            }
            
            if (deuda.Sucursal == "0")
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, deuda.Sucursal);
            }
            

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el detalle de la deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el detalle de la deuda, " + ex.Message, ex);
            }
        }



        public DataSet getBuscarTelefonoPorRutMaximo(Deudor deudor)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarTelefonoPorRutMaximo");

            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el telefono del deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el telefono del deudor, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarPagosPorRutDeudor(Deudor deudor)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarPagosPorRutDeudor");

            db.AddInParameter(cmd, "@rutDeudor", DbType.String, deudor.RutDeudor);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar pagos por rut deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar pagos por rut deudor, " + ex.Message, ex);
            }
        }
        


        public DataSet getBuscarEmailPorRutMaximo(Deudor deudor)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarEmailPorRutMaximo");

            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el email del deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el email del deudor, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarDireccionPorRutMaximo(Deudor deudor)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarDireccionPorRutMaximo");
            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el dirección del deudor, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el dirección del deudor, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarProveedorUbic(int activo)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarProveedorUbic");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el proveedor ubic, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el proveedor ubic, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarCampana(int activo)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarCampana");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la campana, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la campana, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTipoDeuda(int activo)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTipoDeuda");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo de deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo de deuda, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTipoGestion(int activo)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTipoGestion");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo de gestión, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo de gestión, " + ex.Message, ex);
            }
        }
        

        public string setInUbicTelefono(UbicTelefono tel)
        {
            //@nomTipoDocumento varchar(100),@activo int
            DbCommand cmd = db.GetStoredProcCommand("stp_InUbicTelefono");
            db.AddInParameter(cmd, "@rut", DbType.String, tel.Rut);
            db.AddInParameter(cmd, "@IdArea", DbType.String, tel.IdArea);
            db.AddInParameter(cmd, "@telefono", DbType.String, tel.Telefono);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, tel.IdUsuarioIngreso);
            db.AddInParameter(cmd, "@idProveedorUbic", DbType.String, tel.IdProveedorUbic);
            db.AddInParameter(cmd, "@nombreContacto", DbType.String, tel.NombreContacto);
            db.AddInParameter(cmd, "@tipoTelefono", DbType.String, tel.TipoTelefono);
            db.AddInParameter(cmd, "@cargoContacto", DbType.String, tel.CargoContacto);
            try
            {
                //db.ExecuteNonQuery(cmd);
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el telefono, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el telefono, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTelefonoPorRut(Deudor deudor)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTelefonoPorRut");
            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los telefonos, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los telefonos, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarDireccionPorRut(Deudor deudor)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarDireccionPorRut");
            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar las direcciones, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar las direcciones, " + ex.Message, ex);
            }
        }

        public void setUpTelefono(UbicTelefono tel)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpTelefono");
            db.AddInParameter(cmd, "@IdTelefono", DbType.String, tel.IdTelefono);
            db.AddInParameter(cmd, "@idEstadoUbic", DbType.String, tel.IdEstadoUbic);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, tel.IdUsuarioModif);

            db.AddInParameter(cmd, "@contacto", DbType.String, tel.NombreContacto);
            db.AddInParameter(cmd, "@tipoTelefono", DbType.String, tel.TipoTelefono);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar el telefono, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el telefono, " + ex.Message, ex);
            }
        }

        public void setUpDireccion(UbicDireccion dir)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpDireccion");
            db.AddInParameter(cmd, "@IdDireccion", DbType.String, dir.IdDireccion);
            db.AddInParameter(cmd, "@idEstadoUbic", DbType.String, dir.IdEstadoUbic);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la dirección, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la dirección, " + ex.Message, ex);
            }
        }

        public string setInUbicDireccion(UbicDireccion dir)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUbicDireccion");
            //@rut varchar(12),@calle varchar(200),@numero varchar(10),@resto varchar(150),
            //@comuna varchar(50), @idUsuario int, @idProveedorUbic int
            
            db.AddInParameter(cmd, "@rut", DbType.String, dir.Rut);
            db.AddInParameter(cmd, "@calle", DbType.String, dir.Calle);
            db.AddInParameter(cmd, "@numero", DbType.String, dir.Numero);
            db.AddInParameter(cmd, "@resto", DbType.String, dir.Resto);
            db.AddInParameter(cmd, "@comuna", DbType.String, dir.Comuna);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, dir.IdUsuarioIngreso);
            db.AddInParameter(cmd, "@idProveedorUbic", DbType.String, dir.IdProveedorUbic);

            db.AddInParameter(cmd, "@nombreContacto", DbType.String, dir.NombreContacto);
            db.AddInParameter(cmd, "@cargoContacto", DbType.String, dir.CargoContacto);
            try
            {
                //db.ExecuteNonQuery(cmd);
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar la direccion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar la direccion, " + ex.Message, ex);
            }
        }

        public string setInUbicEmail(UbicEmail email)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUbicEmail");
            //@rut varchar(12),@email varchar(100),@idUsuario int, @idProveedorUbic int,@nombreContacto varchar(50),@tipoEmail varchar(15)

            db.AddInParameter(cmd, "@rut", DbType.String, email.Rut);
            db.AddInParameter(cmd, "@email", DbType.String, email.Email);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, email.IdusuarioIngreso);
            db.AddInParameter(cmd, "@idProveedorUbic", DbType.String, email.IdProveedorUbic);

            db.AddInParameter(cmd, "@nombreContacto", DbType.String, email.NombreContacto);
            db.AddInParameter(cmd, "@tipoEmail", DbType.String, email.TipoEmail);

            db.AddInParameter(cmd, "@cargoContacto", DbType.String, email.CargoContacto);

            try
            {
                //db.ExecuteNonQuery(cmd);
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el email, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el email, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarEmailPorRut(Deudor deudor)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarEmailPorRut");
            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los emails, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los emails, " + ex.Message, ex);
            }
        }

        public void setUpEmail(UbicEmail email)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpEmail");
            db.AddInParameter(cmd, "@IdEmail", DbType.String, email.IdEmail);
            db.AddInParameter(cmd, "@idEstadoUbic", DbType.String, email.IdEstadoUbic);
            db.AddInParameter(cmd, "@contacto", DbType.String, email.NombreContacto);
            db.AddInParameter(cmd, "@tipoEmail", DbType.String, email.TipoEmail);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar el email, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el email, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarUltimaGestion(Deudor deudor)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUltimaGestion");
            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, deudor.IdMandante);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los emails, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los emails, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarNivel1(int idTipoTipificacion)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipoDocumento int, @idEstadoDeuda int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarNivel1");
            db.AddInParameter(cmd, "@idTipoTipificacion", DbType.String, idTipoTipificacion);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el nivel1, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el nivel1, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarNivel2(string nivel1)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarNivel2");
            db.AddInParameter(cmd, "@nivel1", DbType.String, nivel1);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el nivel2, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el nivel2, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarNivel3(string nivel2)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarNivel3");
            db.AddInParameter(cmd, "@nivel2", DbType.String, nivel2);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el nivel3 " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el nivel3, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarNivel4(string nivel3)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarNivel4");
            db.AddInParameter(cmd, "@nivel3", DbType.String, nivel3);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el nivel4 " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el nivel4, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTipificacion(int? idTipificacion, string nivel1, string nivel2, string nivel3, string nivel4, int? idTipoTipificacion)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTipificacion");
            db.AddInParameter(cmd, "@idTipificacion", DbType.String, idTipificacion);
            db.AddInParameter(cmd, "@nivel1", DbType.String, nivel1);
            db.AddInParameter(cmd, "@nivel2", DbType.String, nivel2);
            db.AddInParameter(cmd, "@nivel3", DbType.String, nivel3);
            db.AddInParameter(cmd, "@nivel4", DbType.String, nivel4);

            if (idTipoTipificacion == 0)
            {
                db.AddInParameter(cmd, "@idTipoTipificacion", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idTipoTipificacion", DbType.String, idTipoTipificacion);
            }
            
            
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la tipificación " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la tipificación, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarContadorGestiones(int idMandante, int idUsuario, string fechaDesde, string fechaHasta)
        {
            //@idMandante int, @idUsuario int, @fechaDesde varchar(10),@fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarContadorGestiones");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            if (idUsuario ==0)
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            }

            if (fechaDesde.Trim() == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta.Trim() == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }
            
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo contar las gestiones, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo contar las gestiones, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarGestionesExporte(int idMandante, int idUsuario, string fechaDesde, string fechaHasta)
        {
            //@idMandante int, @idUsuario int, @fechaDesde varchar(10),@fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarGestionesExporte");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            if (idUsuario == 0)
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            }

            if (fechaDesde.Trim() == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta.Trim() == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }



            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo contar las gestiones, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo contar las gestiones, " + ex.Message, ex);
            }
        }
        

        public DataSet getContarGestiones(int idMandante, int idUsuario, string fechaDesde, string fechaHasta)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_ContarGestiones");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            if (idUsuario == 0)
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            }

            if (fechaDesde.Trim() == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta.Trim() == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar las gestiones, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar las gestiones, " + ex.Message, ex);
            }
        }


        public void setUpTipificacion(int idTipificacion, string nivel1, string nivel2, string nivel3, string nivel4, 
            int? idTipoGestion, int? esAgendable, int? esCompPago, int? prioridad, string gestionMandante, int? validaFono, int? invalidaFono)
        {
            // @nivel1 varchar(100),@nivel2 varchar(100),
            //@nivel3 varchar(100), @nivel4 varchar(100), @idTipoGestion int, @esAgendable int, @esCompPago int
            
            DbCommand cmd = db.GetStoredProcCommand("stp_UpTipificacion");
            db.AddInParameter(cmd, "@idTipificacion", DbType.String, idTipificacion);
            db.AddInParameter(cmd, "@nivel1", DbType.String, nivel1);
            db.AddInParameter(cmd, "@nivel2", DbType.String, nivel2);
            db.AddInParameter(cmd, "@nivel3", DbType.String, nivel3);
            db.AddInParameter(cmd, "@nivel4", DbType.String, nivel4);
            db.AddInParameter(cmd, "@idTipoGestion", DbType.String, idTipoGestion);
            db.AddInParameter(cmd, "@esAgendable", DbType.String, esAgendable);
            db.AddInParameter(cmd, "@esCompPago", DbType.String, esCompPago);
            db.AddInParameter(cmd, "@prioridad", DbType.String, prioridad);
            db.AddInParameter(cmd, "@codMandante", DbType.String, gestionMandante);

            db.AddInParameter(cmd, "@validaFono", DbType.String, validaFono);
            db.AddInParameter(cmd, "@invalidaFono", DbType.String, invalidaFono);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la tipificacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la tipificacion, " + ex.Message, ex);
            }
        }


        public string setInGestion(Gestiones ges)
        {
            //@rutDeudor varchar(12),@idMandante int, @idTipificacion int, @fechaCompromiso varchar(20), @montoCompromiso int,@observacion varchar(600),
            //@IdTelefonoAsociado int, @IdDireccionAsociada int, @fechaAgendamiento varchar(20),@horaAgendamiento varchar(5), @idUsuario int
             
            DbCommand cmd = db.GetStoredProcCommand("stp_InGestion");
            db.AddInParameter(cmd, "@rutDeudor", DbType.String, ges.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, ges.IdMandante);
            db.AddInParameter(cmd, "@idTipificacion", DbType.String, ges.IdTipificacion);
            db.AddInParameter(cmd, "@fechaCompromiso", DbType.String, ges.FechaCompromiso);
            db.AddInParameter(cmd, "@montoCompromiso", DbType.String, ges.MontoCompromiso);
            db.AddInParameter(cmd, "@IdTelefonoAsociado", DbType.String, ges.IdTelefonoAsociado);
            db.AddInParameter(cmd, "@IdDireccionAsociada", DbType.String, ges.IdDireccionAsociada);
            db.AddInParameter(cmd, "@fechaAgendamiento", DbType.String, ges.FechaAgendamiento);
            db.AddInParameter(cmd, "@horaAgendamiento", DbType.String, ges.HoraAgendamiento);
            db.AddInParameter(cmd, "@observacion", DbType.String, ges.Observaciones);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, ges.IdUsuario);

            try
            {
                //db.ExecuteNonQuery(cmd);
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar el email, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el email, " + ex.Message, ex);
            }
        }


        public string setInDeuda(Deuda deuda)
        {
            //@rut,@idMandante,@nroDoc,@nroCuota,@idTipoDoc,@fecVenc,@fecEmision,@fecProtesto,@monto, @montoProtesto,
            //@nroCliente,@sucursal,@centroCosto,@rutSubCliente,@nombreSubCliente,@observacion,@adic1,@adic2,@adic3,@adic4,@adic5,
            //@adic6,@adic7,@adic8,@adic9,@adic10,1,getdate(),@idUsuario,@idTipoCarga
            
            DbCommand cmd = db.GetStoredProcCommand("stp_InDeuda");
            db.AddInParameter(cmd, "@rut", DbType.String, deuda.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, deuda.IdMandante);
            db.AddInParameter(cmd, "@nroDoc", DbType.String, deuda.NroDocumento);
            db.AddInParameter(cmd, "@nroCuota", DbType.String, deuda.NroCuota);
            db.AddInParameter(cmd, "@idTipoDoc", DbType.String, deuda.IdTipoDocumento);
            db.AddInParameter(cmd, "@fecVenc", DbType.String, deuda.FechaVencimiento);
            db.AddInParameter(cmd, "@fecEmision", DbType.String, deuda.FechaEmision);
            db.AddInParameter(cmd, "@fecProtesto", DbType.String, deuda.FechaProtesto);
            db.AddInParameter(cmd, "@monto", DbType.String, deuda.DeudaOriginal);
            db.AddInParameter(cmd, "@montoProtesto", DbType.String, deuda.MontoProtesto);
            db.AddInParameter(cmd, "@nroCliente", DbType.String, deuda.NumCliente);
            db.AddInParameter(cmd, "@sucursal", DbType.String, deuda.Sucursal);
            db.AddInParameter(cmd, "@centroCosto", DbType.String, deuda.CentroCosto);
            db.AddInParameter(cmd, "@rutSubCliente", DbType.String, deuda.RutSubCliente);
            db.AddInParameter(cmd, "@nombreSubCliente", DbType.String, deuda.NombreSubCliente);
            db.AddInParameter(cmd, "@observacion", DbType.String, deuda.Observacion);
            db.AddInParameter(cmd, "@adic1", DbType.String, deuda.Adic1);
            db.AddInParameter(cmd, "@adic2", DbType.String, deuda.Adic2);
            db.AddInParameter(cmd, "@adic3", DbType.String, deuda.Adic3);
            db.AddInParameter(cmd, "@adic4", DbType.String, deuda.Adic4);
            db.AddInParameter(cmd, "@adic5", DbType.String, deuda.Adic5);
            db.AddInParameter(cmd, "@adic6", DbType.String, deuda.Adic6);
            db.AddInParameter(cmd, "@adic7", DbType.String, deuda.Adic7);
            db.AddInParameter(cmd, "@adic8", DbType.String, deuda.Adic8);
            db.AddInParameter(cmd, "@adic9", DbType.String, deuda.Adic9);
            db.AddInParameter(cmd, "@adic10", DbType.String, deuda.Adic10);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, deuda.UsuarioCreacion);
            db.AddInParameter(cmd, "@idTipoCarga", DbType.String, deuda.IdTipoCarga);
            db.AddInParameter(cmd, "@idAsignacion", DbType.String, deuda.IdAsignacion);
            db.AddInParameter(cmd, "@cuenta", DbType.String, deuda.Cuenta);
            try
            {
                //db.ExecuteNonQuery(cmd);
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la deuda, " + ex.Message, ex);
            }
        }

        

        public DataSet getBuscarDeudorBuscador(string rut, string nombre, string documento, string cuenta, string telefono, string idSucursal)
        {
            //@rut varchar(12),@nombre varchar(100),@documento varchar(10),@cuenta varchar(10),@telefono varchar(20)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarDeudorBuscador");
            if (rut==string.Empty)
            {
                db.AddInParameter(cmd, "@rut", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@rut", DbType.String, rut);
            }
            if (nombre==string.Empty)
            {
                db.AddInParameter(cmd, "@nombre", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@nombre", DbType.String, nombre);
            }
            if (documento==string.Empty)
            {
                db.AddInParameter(cmd, "@documento", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@documento", DbType.String, documento);
            }
            if (cuenta==string.Empty)
            {
                db.AddInParameter(cmd, "@cuenta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@cuenta", DbType.String, cuenta);
            }
            if (telefono==string.Empty)
            {
                db.AddInParameter(cmd, "@telefono", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@telefono", DbType.String, telefono);
            }
            if (idSucursal == "0")
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, idSucursal);
            }
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los deudores " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los deudores, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarCarteraAsignada(Deuda deuda, Deudor deudor, int? montoDesde, int? montoHasta)
        {
            //@idMandante int, @idAsignacion int, @idCampana int, @idEtapaCobranza int, @idEjecutivo int,
            //@idTipoDeuda int, @nombre varchar(100),@rut varchar(12), @montoDesde decimal, @montoHasta decimal,
            //@idTipoCartera int
            
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarCarteraAsignada");
            db.AddInParameter(cmd, "@idMandante", DbType.String, deuda.IdMandante);
            if (deuda.IdAsignacion == 0)
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, deuda.IdAsignacion);
            }

            if (deuda.IdCampana == 0)
            {
                db.AddInParameter(cmd, "@idCampana", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idCampana", DbType.String, deuda.IdCampana);
            }

            if (deuda.IdEstadoDeuda == 0)
            {
                db.AddInParameter(cmd, "@IdEstadoDeuda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdEstadoDeuda", DbType.String, deuda.IdEstadoDeuda);
            }

            if (deuda.IdUsuarioAsig == 0)
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, deuda.IdUsuarioAsig);
            }

            if (deuda.IdTipoDeuda == 0)
            {
                db.AddInParameter(cmd, "@idTipoDeuda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idTipoDeuda", DbType.String, deuda.IdTipoDeuda);
            }

            if (deuda.TipoDeuda == "0")
            {
                db.AddInParameter(cmd, "@TipoDeuda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@TipoDeuda", DbType.String, deuda.TipoDeuda);
            }

            if (deuda.Sucursal == "0")
            {
                db.AddInParameter(cmd, "@sucursal", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@sucursal", DbType.String, deuda.Sucursal);
            }

            db.AddInParameter(cmd, "@nombre", DbType.String, deudor.NombreDeudor);
            
            if (deudor.RutDeudor == string.Empty)
            {
                db.AddInParameter(cmd, "@rut", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);
            }
            db.AddInParameter(cmd, "@montoDesde", DbType.String, montoDesde);
            db.AddInParameter(cmd, "@montoHasta", DbType.String, montoHasta);
            db.AddInParameter(cmd, "@idTipoCartera", DbType.String, deuda.IdTipoDeuda);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo de deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo de deuda, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarCarteraAsignadaExporte(Deuda deuda, Deudor deudor, int? montoDesde, int? montoHasta)
        {
            //@idMandante int, @idAsignacion int, @idCampana int, @idEtapaCobranza int, @idEjecutivo int,
            //@idTipoDeuda int, @nombre varchar(100),@rut varchar(12), @montoDesde decimal, @montoHasta decimal,
            //@idTipoCartera int

            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarCarteraAsignadaExporte");
            db.AddInParameter(cmd, "@idMandante", DbType.String, deuda.IdMandante);
            if (deuda.IdAsignacion == 0)
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, deuda.IdAsignacion);
            }

            if (deuda.IdCampana == 0)
            {
                db.AddInParameter(cmd, "@idCampana", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idCampana", DbType.String, deuda.IdCampana);
            }

            if (deuda.IdEstadoDeuda == 0)
            {
                db.AddInParameter(cmd, "@idEstadoDeuda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idEstadoDeuda", DbType.String, deuda.IdEstadoDeuda);
            }

            if (deuda.IdUsuarioAsig == 0)
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, deuda.IdUsuarioAsig);
            }

            if (deuda.IdTipoDeuda == 0)
            {
                db.AddInParameter(cmd, "@idTipoDeuda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idTipoDeuda", DbType.String, deuda.IdTipoDeuda);
            }

            db.AddInParameter(cmd, "@nombre", DbType.String, deudor.NombreDeudor);
            db.AddInParameter(cmd, "@rut", DbType.String, deuda.RutDeudor);
            db.AddInParameter(cmd, "@montoDesde", DbType.String, deuda.Saldo);
            db.AddInParameter(cmd, "@montoHasta", DbType.String, deuda.Saldo);
            db.AddInParameter(cmd, "@idTipoCartera", DbType.String, deuda.IdTipoDeuda);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el tipo de deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el tipo de deuda, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarDetalleGestiones(int? idTipificacion, int idUsuario, string fechaDesde, string fechaHasta)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarGestionesPorIdTipificacion");
            db.AddInParameter(cmd, "@idTipificacion", DbType.String, idTipificacion);

            if (fechaDesde == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }

            if (idUsuario == 0)
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            }
            

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el detalle de las gestiones, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el detalle de las gestiones, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarMandantesGeneral(int activo, int idUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMandantesGeneral");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los mandantes, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los mandantes, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarOtrasDeudas(Deudor deudor)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarOtrasDeudas");
            db.AddInParameter(cmd, "@rut", DbType.String, deudor.RutDeudor);
            db.AddInParameter(cmd, "@idMandante", DbType.String, deudor.IdMandante);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar las otras deudas, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar las otras deudas, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarConfiguracionExporte(int? idExporte)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarConfExporte");
            db.AddInParameter(cmd, "@idExporte", DbType.String, idExporte);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar las otras, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar las otras, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarExporte(int idMandante, int? idExporte, int? idAsignacion, string fechaDesde, string fechaHasta, string tipoTelefono)
        {

            //@idAsignacion int, @fechaDesde varchar(10),@fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_Exporte");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            db.AddInParameter(cmd, "@idExporte", DbType.String, idExporte);
            if (idAsignacion==null)
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, idAsignacion);
            }

            if (fechaDesde==string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta==string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }

            if (tipoTelefono == "0")
            {
                db.AddInParameter(cmd, "@idTipoTelefono", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idTipoTelefono", DbType.String, tipoTelefono);
            }
            

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar las otras, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar las otras, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarAgendamientosCompromisos(int idMandante, int tipo, int idUsuario, string fechaDesde, string fechaHasta)
        {
            //@idMandante int, @tipo int,@idUsuario int, @fechaDesde varchar(10),@fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarAgendamientosCompromisos");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            db.AddInParameter(cmd, "@tipo", DbType.String, tipo);
            if (idUsuario == 0)
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            }
            
            if (fechaDesde == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }
          
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los agendamientos o compromisos, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los agendamientos o compromisos, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarUsuarioConGestion(int idMandante)
        {
            //@idMandante int, @tipo int,@idUsuario int, @fechaDesde varchar(10),@fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioConGestion");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los agendamientos o compromisos, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los agendamientos o compromisos, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarTipoTipificacion(int activo)
        {
            //@idMandante int, @tipo int,@idUsuario int, @fechaDesde varchar(10),@fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarTipoTipificacion");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los tipo tipificacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los tipo tipificacion, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarUsuarioAsignacion(int idMandante, int idUsuarioAsignado)
        {
            //@idMandante int, @idUsuarioAsignado int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioAsignacion");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            db.AddInParameter(cmd, "@idUsuarioAsignado", DbType.String, idUsuarioAsignado);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los usuarios, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los usuarios, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarResumenAsignacionAutomatica(int idMandante, int idAsignacion)
        {
            //@idMandante int, @idUsuarioAsignado int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarResumenAsignacionAutomatica");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            if (idAsignacion ==0)
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idAsignacion", DbType.String, idAsignacion);
            }
            
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los usuarios, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los usuarios, " + ex.Message, ex);
            }
        }

        
        public void setUpAsignacionAsistida(Deuda deuda, string tipo)
        {
            //@idMandante int, @rut varchar(12),@idUsuarioAsignado int
            DbCommand cmd = db.GetStoredProcCommand("stp_UpAsignacionAsistida");

            db.AddInParameter(cmd, "@idMandante", DbType.String, deuda.IdMandante);
            db.AddInParameter(cmd, "@rut", DbType.String, deuda.RutDeudor);
            db.AddInParameter(cmd, "@idUsuarioAsignado", DbType.String, deuda.IdUsuarioAsig);
            db.AddInParameter(cmd, "@idUsuarioAsignadoPor", DbType.String, deuda.IdUsuarioAsigPor);
            db.AddInParameter(cmd, "@nroDocumento", DbType.String, deuda.NroDocumento);
            db.AddInParameter(cmd, "@tipo", DbType.String, tipo);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario mandante, " + ex.Message, ex);
            }
        }



        public void setProcesoAsignacion(int IntTipoProceso, int IntIdMandante, int IntIdAsignacion, string strArrUsuarios)
        {
            // [Stp_ProcesoAsignacion] 1,1,1,'1,2,4'
            //@IntTipoProceso int, @IntIdMandante int,@IntIdAsignacion int, @strArrUsuarios varchar(2000)
            DbCommand cmd = db.GetStoredProcCommand("Stp_ProcesoAsignacion");
            db.AddInParameter(cmd, "@IntTipoProceso", DbType.String, IntTipoProceso);
            db.AddInParameter(cmd, "@IntIdMandante", DbType.String, IntIdMandante);
            db.AddInParameter(cmd, "@IntIdAsignacion", DbType.String, IntIdAsignacion);
            db.AddInParameter(cmd, "@strArrUsuarios", DbType.String, strArrUsuarios);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la asignacion, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la asignacion, " + ex.Message, ex);
            }
        }


        public DataSet getInformeGestionesDiarias(string mes, string anio, string fechaDesdePer, string fechaHastaPer)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InformeGestionesDiarias");

            db.AddInParameter(cmd, "@mes", DbType.String, mes);
            db.AddInParameter(cmd, "@anio", DbType.String, anio);
            db.AddInParameter(cmd, "@fechaDesdePer", DbType.String, fechaDesdePer);
            db.AddInParameter(cmd, "@fechaHastaPer", DbType.String, fechaHastaPer);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarSucursal(Sucursal su)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarSucursal");

            if (su.Activo==0)
            {
                db.AddInParameter(cmd, "@activo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@activo", DbType.String, su.Activo);
            }
            

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }
        

        public void setDelDeuda(int idMandante)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelDeuda");

            db.AddInParameter(cmd, "@IdMandante", DbType.String, idMandante);

            try
            {
                 db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar las deudas, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar las deudas, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarDetallePago(string idSucursal,string idTipoDocumento, 
            int idEjecutivo, string fechaDesde, string fechaHasta,string codCliente, string referencia)
        {
            // @idSucursal varchar(10),@IdTipoDocumento varchar(10),@idEjecutivo int, @fechaDesde varchar(10), @fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarPagosDetalle");

            if (idSucursal == "0")
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, idSucursal);
            }
            
            
            if (idTipoDocumento == "0")
            {
                db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, idTipoDocumento);
            }

            if (idEjecutivo == 0)
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, idEjecutivo);
            }

            if (fechaDesde == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }

            if (codCliente == string.Empty)
            {
                db.AddInParameter(cmd, "@codCliente", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@codCliente", DbType.String, codCliente);
            }

            if (referencia == string.Empty)
            {
                db.AddInParameter(cmd, "@referencia", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@referencia", DbType.String, "%"+referencia+"%");
            }



            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }



        public DataSet getBuscarDetallePagoRut(string idSucursal, string idTipoDocumento, int idEjecutivo, string fechaDesde, string fechaHasta,string rut)
        {
            // @idSucursal varchar(10),@IdTipoDocumento varchar(10),@idEjecutivo int, @fechaDesde varchar(10), @fechaHasta varchar(10)
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarPagosDetalleRut");

            db.AddInParameter(cmd, "@rut", DbType.String, rut);
            if (idSucursal == "0")
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, idSucursal);
            }


            if (idTipoDocumento == "0")
            {
                db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idTipoDocumento", DbType.String, idTipoDocumento);
            }

            if (idEjecutivo == 0)
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idEjecutivo", DbType.String, idEjecutivo);
            }

            if (fechaDesde == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaDesde", DbType.String, fechaDesde);
            }

            if (fechaHasta == string.Empty)
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@fechaHasta", DbType.String, fechaHasta);
            }


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }

        public string setInPagosAL(PagosAirLiquide pago, int idUsuario, int idMandante)
        {
            /*@codSucursal ,
            @codCliente ,
            @nombreCliente ,
            @serie ,
            @esp,
            @documento,
            @modalidad,
            @fechaEmision,
            @fechaVencimiento,
            @referencia,
            @fechaReferencia,
            @montoTitulo,
            @banco,
            @nroCheque,
            @valorBaja,
            @fechaVencimientoCheque,
            @montoTotal,
            @portador,
            @idUsuarioIngreso,
            @idMandante,
            @fechaIngreso*/
            DbCommand cmd = db.GetStoredProcCommand("stp_InPagosAL");
            db.AddInParameter(cmd, "@codSucursal", DbType.String, pago.COD_SUCURSAL);
            db.AddInParameter(cmd, "@codCliente", DbType.String, pago.COD_CLIENTE);
            db.AddInParameter(cmd, "@nombreCliente", DbType.String, pago.NOMBRE_CLIENTE);
            db.AddInParameter(cmd, "@serie", DbType.String, pago.SERIE);
            db.AddInParameter(cmd, "@esp", DbType.String, pago.ESP);
            db.AddInParameter(cmd, "@documento", DbType.String, pago.DOCUMENTO);
            db.AddInParameter(cmd, "@modalidad", DbType.String, pago.MODALIDAD);
            db.AddInParameter(cmd, "@fechaEmision", DbType.String, pago.FECHA_EMISION);
            db.AddInParameter(cmd, "@fechaVencimiento", DbType.String, pago.FECHA_VENCIMIENTO);
            db.AddInParameter(cmd, "@referencia", DbType.String, pago.REFERENCIA);
            db.AddInParameter(cmd, "@fechaReferencia", DbType.String, pago.FECHA_REFERENCIA);
            db.AddInParameter(cmd, "@montoTitulo", DbType.String, pago.MONTO_TITULO);
            db.AddInParameter(cmd, "@banco", DbType.String, pago.BANCO);
            db.AddInParameter(cmd, "@nroCheque", DbType.String, pago.NRO_CHEQUE);
            db.AddInParameter(cmd, "@valorBaja", DbType.String, pago.VALOR_BAJA);
            db.AddInParameter(cmd, "@fechaVencimientoCheque", DbType.String, pago.FECHA_VENCIMIENTO_CHEQUE);
            db.AddInParameter(cmd, "@montoTotal", DbType.String, pago.MONTO_TOTAL);
            db.AddInParameter(cmd, "@portador", DbType.String, pago.PORTADOR);
            db.AddInParameter(cmd, "@idUsuarioIngreso", DbType.String, idUsuario);
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);

            try
            {
                //db.ExecuteNonQuery(cmd);
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el pago, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el pago, " + ex.Message, ex);
            }
        }





        public string setInUpSucursal(Sucursal suc)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUpSucursal");
            //@idSucursal varchar(10),@nombreSucursal varchar(100),@activo int
            db.AddInParameter(cmd, "@idSucursal", DbType.String, suc.IdSucursal);
            db.AddInParameter(cmd, "@nombreSucursal", DbType.String, suc.NomSucursal);
            db.AddInParameter(cmd, "@activo", DbType.String, suc.Activo);

            try
            {
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el sucursal, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el sucursal, " + ex.Message, ex);
            }
        }



        public void setDelSucursal(Sucursal su)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelSucursal");

            db.AddInParameter(cmd, "@idSucursal", DbType.String, su.IdSucursal);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar la sucursal , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar la sucursal , " + ex.Message, ex);
            }
        }

















        public DataSet getBuscarPortador(Portador port)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarPortador");

            if (port.Activo == 0)
            {
                db.AddInParameter(cmd, "@activo", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@activo", DbType.String, port.Activo);
            }


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }

        

        public DataSet getBuscarMensajePorId(int idMensaje)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMensajePorId");
            db.AddInParameter(cmd, "@idMensaje", DbType.String, idMensaje);


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarCondicionPago(int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarCondicionPago");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }



        public DataSet getBuscarDeudaPorId(int idDeuda)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarDeudaPorId");
            db.AddInParameter(cmd, "@idDeuda", DbType.String, idDeuda);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarSector(int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarSector");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }

        

        public string setInUpPortador(Portador port)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUpPortador");
            //@idPortador varchar(10),@nomPortador varchar(100),@activo int
            db.AddInParameter(cmd, "@idPortador", DbType.String, port.IdPortador);
            db.AddInParameter(cmd, "@nomPortador", DbType.String, port.NomPortador);
            db.AddInParameter(cmd, "@activo", DbType.String, port.Activo);

            try
            {
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el sucursal, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el sucursal, " + ex.Message, ex);
            }
        }


        public void setDelPortador(Portador port)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelPortador");

            db.AddInParameter(cmd, "@idPortador", DbType.String, port.IdPortador);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el portador , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el portador , " + ex.Message, ex);
            }
        }

        public void setInMensaje(Mensaje msj)
        {
            //@asunto varchar(10),@mensaje varchar(300),@idUsuarioPara int, @idUsuarioDe int
            DbCommand cmd = db.GetStoredProcCommand("stp_InMensaje");

            db.AddInParameter(cmd, "@asunto", DbType.String, msj.Asunto);
            db.AddInParameter(cmd, "@mensaje", DbType.String, msj.MensajeObs);
            db.AddInParameter(cmd, "@idUsuarioPara", DbType.String, msj.IdUsuarioPara);
            db.AddInParameter(cmd, "@idUsuarioDe", DbType.String, msj.IdUsuarioDe);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el mensaje, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el mensaje, " + ex.Message, ex);
            }
        }


        public void setUpDeuda(int idDeuda, int idEstadoDeuda2, string obs)
        {
            //@asunto varchar(10),@mensaje varchar(300),@idUsuarioPara int, @idUsuarioDe int
            DbCommand cmd = db.GetStoredProcCommand("stp_UpDeuda");

            db.AddInParameter(cmd, "@IdDeuda", DbType.String, idDeuda);
            db.AddInParameter(cmd, "@idEstadoDeuda2", DbType.String, idEstadoDeuda2);
            db.AddInParameter(cmd, "@observacion", DbType.String, obs);
            
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede editar la deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede editar la deuda, " + ex.Message, ex);
            }
        }




        public DataSet getBuscarMetas(string periodo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMetas");
            db.AddInParameter(cmd, "@periodo", DbType.String, periodo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarverDiasPagosAirLiquide()
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_VerDiasPagosAirLiquide");

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }

        public DataSet getBuscarReporteMetas(string ano, string mes, string idSucursal)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarReporteMetas");
            db.AddInParameter(cmd, "@ano", DbType.String, ano);
            db.AddInParameter(cmd, "@mes", DbType.String, mes);
            if (idSucursal == "0")
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idSucursal", DbType.String, idSucursal);
            }
            
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }

        public void setInUpMetas(string periodo, string idSucursal, string meta)
        {
            //@periodo varchar(6),@idSucursal int, @meta int
            DbCommand cmd = db.GetStoredProcCommand("stp_InUpMetas");

            db.AddInParameter(cmd, "@periodo", DbType.String, periodo);
            db.AddInParameter(cmd, "@idSucursal", DbType.String, idSucursal);
            db.AddInParameter(cmd, "@meta", DbType.String, meta);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede editar la información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede editar la información, " + ex.Message, ex);
            }
        }


        public void setDelMetas(string periodo, string idSucursal)
        {
            //@asunto varchar(10),@mensaje varchar(300),@idUsuarioPara int, @idUsuarioDe int
            DbCommand cmd = db.GetStoredProcCommand("stp_DelMeta");

            db.AddInParameter(cmd, "@periodo", DbType.String, periodo);
            db.AddInParameter(cmd, "@idSucursal", DbType.String, idSucursal);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede editar la deuda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede editar la deuda, " + ex.Message, ex);
            }
        }


    }
}
