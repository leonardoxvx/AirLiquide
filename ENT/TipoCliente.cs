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
    
    
    public class TipoCliente
    {
        
        private Int32 mIdTipoCliente;
        
        private String mNomTipoCliente;
        
        private Int32 mActivo;
        
        public virtual Int32 IdTipoCliente
        {
            get
            {
                return this.mIdTipoCliente;
            }
            set
            {
                this.mIdTipoCliente = value;
            }
        }
        
        public virtual String NomTipoCliente
        {
            get
            {
                return this.mNomTipoCliente;
            }
            set
            {
                this.mNomTipoCliente = value;
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
