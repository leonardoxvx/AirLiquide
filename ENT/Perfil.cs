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
    
    
    public class Perfil
    {
        
        private Int32 mIdPerfil;
        
        private String mNomPerfil;
        
        private Int32 mActivo;
        
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
        
        public virtual String NomPerfil
        {
            get
            {
                return this.mNomPerfil;
            }
            set
            {
                this.mNomPerfil = value;
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
