﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoP1Web2.WebServiceEdgar {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://IS6A-MRHE.org/", ConfigurationName="WebServiceEdgar.WebService1Soap")]
    public interface WebService1Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/RetornarCadena", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string RetornarCadena();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/RetornarCadena", ReplyAction="*")]
        System.Threading.Tasks.Task<string> RetornarCadenaAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/buscarGrupoGimnasio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable buscarGrupoGimnasio(int idGimnasio, string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/buscarGrupoGimnasio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> buscarGrupoGimnasioAsync(int idGimnasio, string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/MostrarGruposGimnasio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] MostrarGruposGimnasio();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/MostrarGruposGimnasio", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> MostrarGruposGimnasioAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/MostrarGruposGimnasio2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable MostrarGruposGimnasio2();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://IS6A-MRHE.org/MostrarGruposGimnasio2", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> MostrarGruposGimnasio2Async();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : ProyectoP1Web2.WebServiceEdgar.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<ProyectoP1Web2.WebServiceEdgar.WebService1Soap>, ProyectoP1Web2.WebServiceEdgar.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RetornarCadena() {
            return base.Channel.RetornarCadena();
        }
        
        public System.Threading.Tasks.Task<string> RetornarCadenaAsync() {
            return base.Channel.RetornarCadenaAsync();
        }
        
        public System.Data.DataTable buscarGrupoGimnasio(int idGimnasio, string nombre) {
            return base.Channel.buscarGrupoGimnasio(idGimnasio, nombre);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> buscarGrupoGimnasioAsync(int idGimnasio, string nombre) {
            return base.Channel.buscarGrupoGimnasioAsync(idGimnasio, nombre);
        }
        
        public string[] MostrarGruposGimnasio() {
            return base.Channel.MostrarGruposGimnasio();
        }
        
        public System.Threading.Tasks.Task<string[]> MostrarGruposGimnasioAsync() {
            return base.Channel.MostrarGruposGimnasioAsync();
        }
        
        public System.Data.DataTable MostrarGruposGimnasio2() {
            return base.Channel.MostrarGruposGimnasio2();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> MostrarGruposGimnasio2Async() {
            return base.Channel.MostrarGruposGimnasio2Async();
        }
    }
}
