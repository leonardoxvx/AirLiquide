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
    
    
    public class UbicEmail
    {
        
        private Int32 mIdEmail;
        
        private String mRut;
        
        private String mEmail;
        
        private DateTime mFechaIngreso;
        
        private Int32 mIdusuarioIngreso;
        
        private DateTime mFechaModif;
        
        private Int32 mIdUsuarioModif;
        
        private Int32 mIdEstadoUbic;
        
        private Int32 mIdProveedorUbic;
        private String mNombreContacto;
        private String mTipoEmail;
        private String mCargoContacto;

        public virtual Int32 IdEmail
        {
            get
            {
                return this.mIdEmail;
            }
            set
            {
                this.mIdEmail = value;
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

        public virtual String CargoContacto
        {
            get
            {
                return this.mCargoContacto;
            }
            set
            {
                this.mCargoContacto = value;
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
        
        public virtual DateTime FechaIngreso
        {
            get
            {
                return this.mFechaIngreso;
            }
            set
            {
                this.mFechaIngreso = value;
            }
        }
        
        public virtual Int32 IdusuarioIngreso
        {
            get
            {
                return this.mIdusuarioIngreso;
            }
            set
            {
                this.mIdusuarioIngreso = value;
            }
        }
        
        public virtual DateTime FechaModif
        {
            get
            {
                return this.mFechaModif;
            }
            set
            {
                this.mFechaModif = value;
            }
        }
        
        public virtual Int32 IdUsuarioModif
        {
            get
            {
                return this.mIdUsuarioModif;
            }
            set
            {
                this.mIdUsuarioModif = value;
            }
        }
        
        public virtual Int32 IdEstadoUbic
        {
            get
            {
                return this.mIdEstadoUbic;
            }
            set
            {
                this.mIdEstadoUbic = value;
            }
        }
        
        public virtual Int32 IdProveedorUbic
        {
            get
            {
                return this.mIdProveedorUbic;
            }
            set
            {
                this.mIdProveedorUbic = value;
            }
        }
        
        public virtual String NombreContacto
        {
            get
            {
                return this.mNombreContacto;
            }
            set
            {
                this.mNombreContacto = value;
            }
        }

        public virtual String TipoEmail
        {
            get
            {
                return this.mTipoEmail;
            }
            set
            {
                this.mTipoEmail = value;
            }
        }
    }
}