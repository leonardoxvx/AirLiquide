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
    
    
    public class UbicDireccion
    {
        
        private Int32 mIdDireccion;
        
        private String mRut;
        
        private String mCalle;
        
        private String mNumero;
        
        private String mResto;
        
        private String mComuna;
        
        private String mCiudad;
        
        private String mRegion;
        
        private String mCodigoPostal;
        
        private Int32 mIdUsuarioIngreso;
        
        private DateTime mFechaIngreso;
        
        private Int32 mIdusuarioModif;
        
        private DateTime mFechaModif;
        
        private Int32 mIdEstadoUbic;
        
        private Int32 mIdProveedorUbic;
        private String mNombreContacto;
        private String mCargoContacto;

        public virtual Int32 IdDireccion
        {
            get
            {
                return this.mIdDireccion;
            }
            set
            {
                this.mIdDireccion = value;
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

        public virtual String Calle
        {
            get
            {
                return this.mCalle;
            }
            set
            {
                this.mCalle = value;
            }
        }
        
        public virtual String Numero
        {
            get
            {
                return this.mNumero;
            }
            set
            {
                this.mNumero = value;
            }
        }
        
        public virtual String Resto
        {
            get
            {
                return this.mResto;
            }
            set
            {
                this.mResto = value;
            }
        }
        
        public virtual String Comuna
        {
            get
            {
                return this.mComuna;
            }
            set
            {
                this.mComuna = value;
            }
        }
        
        public virtual String Ciudad
        {
            get
            {
                return this.mCiudad;
            }
            set
            {
                this.mCiudad = value;
            }
        }
        
        public virtual String Region
        {
            get
            {
                return this.mRegion;
            }
            set
            {
                this.mRegion = value;
            }
        }
        
        public virtual String CodigoPostal
        {
            get
            {
                return this.mCodigoPostal;
            }
            set
            {
                this.mCodigoPostal = value;
            }
        }
        
        public virtual Int32 IdUsuarioIngreso
        {
            get
            {
                return this.mIdUsuarioIngreso;
            }
            set
            {
                this.mIdUsuarioIngreso = value;
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
        
        public virtual Int32 IdusuarioModif
        {
            get
            {
                return this.mIdusuarioModif;
            }
            set
            {
                this.mIdusuarioModif = value;
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
    }
}
