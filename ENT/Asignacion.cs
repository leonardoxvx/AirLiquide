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
    
    
    public class Asignacion
    {
        
        private Int32 mIdAsignacion;
        
        private Int32 mIdMandante;
        
        private String mNomAsignacion;
        
        private DateTime? mFechaAsignacion;
        
        private DateTime? mFechaInicio;
        
        private DateTime? mFechaTermino;
        
        private String mNomArchivoCarga;
        
        private String mObsCarga;
        
        private Int32 mActiva;
        
        public virtual Int32 IdAsignacion
        {
            get
            {
                return this.mIdAsignacion;
            }
            set
            {
                this.mIdAsignacion = value;
            }
        }
        
        public virtual Int32 IdMandante
        {
            get
            {
                return this.mIdMandante;
            }
            set
            {
                this.mIdMandante = value;
            }
        }
        
        public virtual String NomAsignacion
        {
            get
            {
                return this.mNomAsignacion;
            }
            set
            {
                this.mNomAsignacion = value;
            }
        }
        
        public virtual DateTime? FechaAsignacion
        {
            get
            {
                return this.mFechaAsignacion;
            }
            set
            {
                this.mFechaAsignacion = value;
            }
        }
        
        public virtual DateTime? FechaInicio
        {
            get
            {
                return this.mFechaInicio;
            }
            set
            {
                this.mFechaInicio = value;
            }
        }
        
        public virtual DateTime? FechaTermino
        {
            get
            {
                return this.mFechaTermino;
            }
            set
            {
                this.mFechaTermino = value;
            }
        }
        
        public virtual String NomArchivoCarga
        {
            get
            {
                return this.mNomArchivoCarga;
            }
            set
            {
                this.mNomArchivoCarga = value;
            }
        }
        
        public virtual String ObsCarga
        {
            get
            {
                return this.mObsCarga;
            }
            set
            {
                this.mObsCarga = value;
            }
        }
        
        public virtual Int32 Activa
        {
            get
            {
                return this.mActiva;
            }
            set
            {
                this.mActiva = value;
            }
        }
    }
}