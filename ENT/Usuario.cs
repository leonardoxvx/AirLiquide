//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENT
{
    using System;
    
    
    public class Usuario
    {
        
        private Int32 mIdUsuario;
        
        private String mRut;
        
        private String mNombre;
        
        private String mEmail;
        
        private Int32 mIdPerfil;
        
        private String mLogin;
        
        private String mClave;
        
        private String mAreaCargo;
        
        private String mFoto;
        
        private Int32 mActivo;
        private DateTime mFechaCreacion;
        private Int32? mIdUsuarioDiscador;
        private String mIdSucursal;

        public virtual Int32 IdUsuario
        {
            get
            {
                return this.mIdUsuario;
            }
            set
            {
                this.mIdUsuario = value;
            }
        }
        
        public virtual String Rut
        {
            get
            {
                return this.mRut;
            }
            set
            {
                this.mRut = value;
            }
        }
        
        public virtual String Nombre
        {
            get
            {
                return this.mNombre;
            }
            set
            {
                this.mNombre = value;
            }
        }
        
        public virtual String Email
        {
            get
            {
                return this.mEmail;
            }
            set
            {
                this.mEmail = value;
            }
        }
        
        public virtual Int32 IdPerfil
        {
            get
            {
                return this.mIdPerfil;
            }
            set
            {
                this.mIdPerfil = value;
            }
        }
        
        public virtual String Login
        {
            get
            {
                return this.mLogin;
            }
            set
            {
                this.mLogin = value;
            }
        }
        
        public virtual String Clave
        {
            get
            {
                return this.mClave;
            }
            set
            {
                this.mClave = value;
            }
        }
        
        public virtual String AreaCargo
        {
            get
            {
                return this.mAreaCargo;
            }
            set
            {
                this.mAreaCargo = value;
            }
        }
        
        public virtual String Foto
        {
            get
            {
                return this.mFoto;
            }
            set
            {
                this.mFoto = value;
            }
        }
        
        public virtual Int32 Activo
        {
            get
            {
                return this.mActivo;
            }
            set
            {
                this.mActivo = value;
            }
        }

        public virtual DateTime FechaCreacion
        {
            get
            {
                return this.mFechaCreacion;
            }
            set
            {
                this.mFechaCreacion = value;
            }
        }


        public virtual Int32? IdUsuarioDiscador
        {
            get
            {
                return this.mIdUsuarioDiscador;
            }
            set
            {
                this.mIdUsuarioDiscador = value;
            }
        }


        public virtual String IdSucursal
        {
            get
            {
                return this.mIdSucursal;
            }
            set
            {
                this.mIdSucursal = value;
            }
        }
    }
}
