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
    
    
    public class Deuda
    {
        
        private Int32 mIdDeuda;
        
        private String mRutDeudor;
        
        private Int32 mIdMandante;
        
        private String mNroDocumento;
        
        private Int32 mNroCuota;
        
        private Int32 mIdAsignacion;
        
        private DateTime? mFechaVencimiento;
        
        private Double mDeudaOriginal;
        
        private Double mSaldo;
        
        private Double mMontoProtesto;
        
        private DateTime? mFechaProtesto;
        
        private String mIdTipoDocumento;
        
        private String mCuenta;
        
        private DateTime? mFechaEmision;
        
        private String mGlosa;
        
        private Int32 mIdEstadoDeuda;
        
        private DateTime? mFechaEstado;
        
        private DateTime? mFechaAsignacion;
        
        private Int32 mIdUsuarioAsig;
        
        private DateTime? mFechaCreacion;
        
        private Int32 mUsuarioCreacion;
        
        private String mSucursal;
        
        private String mCentroCosto;
        
        private String mNumCliente;
        
        private Int32 mIdUltGestionEJ;
        
        private Int32 mIdUltGestionJud;
        
        private Int32 mIdDemanda;
        
        private Int32 mIdAsignadoPor;
        
        private String mObservacion;
        
        private Int32 mIdPago;
        
        private Int32 mIdPagoCorrelativo;
        
        private Int32 mId_Convenio;
        
        private String mObsCarga;
        
        private String mClaveAdicional;
        
        private String mRutSubCliente;
        
        private String mNombreSubCliente;
        
        private String mTipoCobranza;
        
        private String mTipoCastigo;
        
        private String mTipoDeuda;
        
        private String mAdic1;
        
        private String mAdic2;
        
        private String mAdic3;
        
        private String mAdic4;
        
        private String mAdic5;
        
        private String mAdic6;
        
        private String mAdic7;
        
        private String mAdic8;
        
        private String mAdic9;
        
        private String mAdic10;
        
        private Int32 mIdTipoCarga;
        
        private Int32 mIdTipoDeuda;
        
        private Int32 mIdCampana;
        private Int32 mIdUsuarioAsigPor;

        public virtual Int32 IdDeuda
        {
            get
            {
                return this.mIdDeuda;
            }
            set
            {
                this.mIdDeuda = value;
            }
        }
        
        public virtual String RutDeudor
        {
            get
            {
                return this.mRutDeudor;
            }
            set
            {
                this.mRutDeudor = value;
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
        
        public virtual String NroDocumento
        {
            get
            {
                return this.mNroDocumento;
            }
            set
            {
                this.mNroDocumento = value;
            }
        }
        
        public virtual Int32 NroCuota
        {
            get
            {
                return this.mNroCuota;
            }
            set
            {
                this.mNroCuota = value;
            }
        }
        
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
        
        public virtual DateTime? FechaVencimiento
        {
            get
            {
                return this.mFechaVencimiento;
            }
            set
            {
                this.mFechaVencimiento = value;
            }
        }
        
        public virtual Double DeudaOriginal
        {
            get
            {
                return this.mDeudaOriginal;
            }
            set
            {
                this.mDeudaOriginal = value;
            }
        }
        
        public virtual Double Saldo
        {
            get
            {
                return this.mSaldo;
            }
            set
            {
                this.mSaldo = value;
            }
        }
        
        public virtual Double MontoProtesto
        {
            get
            {
                return this.mMontoProtesto;
            }
            set
            {
                this.mMontoProtesto = value;
            }
        }
        
        public virtual DateTime? FechaProtesto
        {
            get
            {
                return this.mFechaProtesto;
            }
            set
            {
                this.mFechaProtesto = value;
            }
        }
        
        public virtual String IdTipoDocumento
        {
            get
            {
                return this.mIdTipoDocumento;
            }
            set
            {
                this.mIdTipoDocumento = value;
            }
        }
        
        public virtual String Cuenta
        {
            get
            {
                return this.mCuenta;
            }
            set
            {
                this.mCuenta = value;
            }
        }
        
        public virtual DateTime? FechaEmision
        {
            get
            {
                return this.mFechaEmision;
            }
            set
            {
                this.mFechaEmision = value;
            }
        }
        
        public virtual String Glosa
        {
            get
            {
                return this.mGlosa;
            }
            set
            {
                this.mGlosa = value;
            }
        }
        
        public virtual Int32 IdEstadoDeuda
        {
            get
            {
                return this.mIdEstadoDeuda;
            }
            set
            {
                this.mIdEstadoDeuda = value;
            }
        }
        
        public virtual DateTime? FechaEstado
        {
            get
            {
                return this.mFechaEstado;
            }
            set
            {
                this.mFechaEstado = value;
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
        
        public virtual Int32 IdUsuarioAsig
        {
            get
            {
                return this.mIdUsuarioAsig;
            }
            set
            {
                this.mIdUsuarioAsig = value;
            }
        }
        
        public virtual DateTime? FechaCreacion
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
        
        public virtual Int32 UsuarioCreacion
        {
            get
            {
                return this.mUsuarioCreacion;
            }
            set
            {
                this.mUsuarioCreacion = value;
            }
        }
        
        public virtual String Sucursal
        {
            get
            {
                return this.mSucursal;
            }
            set
            {
                this.mSucursal = value;
            }
        }
        
        public virtual String CentroCosto
        {
            get
            {
                return this.mCentroCosto;
            }
            set
            {
                this.mCentroCosto = value;
            }
        }
        
        public virtual String NumCliente
        {
            get
            {
                return this.mNumCliente;
            }
            set
            {
                this.mNumCliente = value;
            }
        }
        
        public virtual Int32 IdUltGestionEJ
        {
            get
            {
                return this.mIdUltGestionEJ;
            }
            set
            {
                this.mIdUltGestionEJ = value;
            }
        }
        
        public virtual Int32 IdUltGestionJud
        {
            get
            {
                return this.mIdUltGestionJud;
            }
            set
            {
                this.mIdUltGestionJud = value;
            }
        }
        
        public virtual Int32 IdDemanda
        {
            get
            {
                return this.mIdDemanda;
            }
            set
            {
                this.mIdDemanda = value;
            }
        }
        
        public virtual Int32 IdAsignadoPor
        {
            get
            {
                return this.mIdAsignadoPor;
            }
            set
            {
                this.mIdAsignadoPor = value;
            }
        }
        
        public virtual String Observacion
        {
            get
            {
                return this.mObservacion;
            }
            set
            {
                this.mObservacion = value;
            }
        }
        
        public virtual Int32 IdPago
        {
            get
            {
                return this.mIdPago;
            }
            set
            {
                this.mIdPago = value;
            }
        }
        
        public virtual Int32 IdPagoCorrelativo
        {
            get
            {
                return this.mIdPagoCorrelativo;
            }
            set
            {
                this.mIdPagoCorrelativo = value;
            }
        }
        
        public virtual Int32 Id_Convenio
        {
            get
            {
                return this.mId_Convenio;
            }
            set
            {
                this.mId_Convenio = value;
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
        
        public virtual String ClaveAdicional
        {
            get
            {
                return this.mClaveAdicional;
            }
            set
            {
                this.mClaveAdicional = value;
            }
        }
        
        public virtual String RutSubCliente
        {
            get
            {
                return this.mRutSubCliente;
            }
            set
            {
                this.mRutSubCliente = value;
            }
        }
        
        public virtual String NombreSubCliente
        {
            get
            {
                return this.mNombreSubCliente;
            }
            set
            {
                this.mNombreSubCliente = value;
            }
        }
        
        public virtual String TipoCobranza
        {
            get
            {
                return this.mTipoCobranza;
            }
            set
            {
                this.mTipoCobranza = value;
            }
        }
        
        public virtual String TipoCastigo
        {
            get
            {
                return this.mTipoCastigo;
            }
            set
            {
                this.mTipoCastigo = value;
            }
        }
        
        public virtual String TipoDeuda
        {
            get
            {
                return this.mTipoDeuda;
            }
            set
            {
                this.mTipoDeuda = value;
            }
        }
        
        public virtual String Adic1
        {
            get
            {
                return this.mAdic1;
            }
            set
            {
                this.mAdic1 = value;
            }
        }
        
        public virtual String Adic2
        {
            get
            {
                return this.mAdic2;
            }
            set
            {
                this.mAdic2 = value;
            }
        }
        
        public virtual String Adic3
        {
            get
            {
                return this.mAdic3;
            }
            set
            {
                this.mAdic3 = value;
            }
        }
        
        public virtual String Adic4
        {
            get
            {
                return this.mAdic4;
            }
            set
            {
                this.mAdic4 = value;
            }
        }
        
        public virtual String Adic5
        {
            get
            {
                return this.mAdic5;
            }
            set
            {
                this.mAdic5 = value;
            }
        }
        
        public virtual String Adic6
        {
            get
            {
                return this.mAdic6;
            }
            set
            {
                this.mAdic6 = value;
            }
        }
        
        public virtual String Adic7
        {
            get
            {
                return this.mAdic7;
            }
            set
            {
                this.mAdic7 = value;
            }
        }
        
        public virtual String Adic8
        {
            get
            {
                return this.mAdic8;
            }
            set
            {
                this.mAdic8 = value;
            }
        }
        
        public virtual String Adic9
        {
            get
            {
                return this.mAdic9;
            }
            set
            {
                this.mAdic9 = value;
            }
        }
        
        public virtual String Adic10
        {
            get
            {
                return this.mAdic10;
            }
            set
            {
                this.mAdic10 = value;
            }
        }
        
        public virtual Int32 IdTipoCarga
        {
            get
            {
                return this.mIdTipoCarga;
            }
            set
            {
                this.mIdTipoCarga = value;
            }
        }
        
        public virtual Int32 IdTipoDeuda
        {
            get
            {
                return this.mIdTipoDeuda;
            }
            set
            {
                this.mIdTipoDeuda = value;
            }
        }
        
        public virtual Int32 IdCampana
        {
            get
            {
                return this.mIdCampana;
            }
            set
            {
                this.mIdCampana = value;
            }
        }

        public virtual Int32 IdUsuarioAsigPor
        {
            get
            {
                return this.mIdUsuarioAsigPor;
            }
            set
            {
                this.mIdUsuarioAsigPor = value;
            }
        }
    }
}
