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
    
    
    public class Portador
    {
        
        private String mIdPortador;
        
        private String mNomPortador;
        
        private Int32 mActivo;
        
        public virtual String IdPortador
        {
            get
            {
                return this.mIdPortador;
            }
            set
            {
                this.mIdPortador = value;
            }
        }
        
        public virtual String NomPortador
        {
            get
            {
                return this.mNomPortador;
            }
            set
            {
                this.mNomPortador = value;
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
    }
}