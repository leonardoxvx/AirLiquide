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
    
    
    public class TipoPersona
    {
        
        private Int32 mIdTipoPersona;
        
        private String mNomTipoPersona;
        
        private Int32 mActivo;
        
        public virtual Int32 IdTipoPersona
        {
            get
            {
                return this.mIdTipoPersona;
            }
            set
            {
                this.mIdTipoPersona = value;
            }
        }
        
        public virtual String NomTipoPersona
        {
            get
            {
                return this.mNomTipoPersona;
            }
            set
            {
                this.mNomTipoPersona = value;
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
