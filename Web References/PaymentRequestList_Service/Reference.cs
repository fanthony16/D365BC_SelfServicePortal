﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace NAV_HR_WINDOW.PaymentRequestList_Service {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PaymentRequestList_Binding", Namespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist")]
    public partial class PaymentRequestList_Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ReadOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadByRecIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadMultipleOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsUpdatedOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecIdFromKeyOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PaymentRequestList_Service() {
            this.Url = global::NAV_HR_WINDOW.Properties.Settings.Default.NAV_HR_WINDOW_PaymentRequestList_Service_PaymentRequestList_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ReadCompletedEventHandler ReadCompleted;
        
        /// <remarks/>
        public event ReadByRecIdCompletedEventHandler ReadByRecIdCompleted;
        
        /// <remarks/>
        public event ReadMultipleCompletedEventHandler ReadMultipleCompleted;
        
        /// <remarks/>
        public event IsUpdatedCompletedEventHandler IsUpdatedCompleted;
        
        /// <remarks/>
        public event GetRecIdFromKeyCompletedEventHandler GetRecIdFromKeyCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/paymentrequestlist:Read", RequestNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", ResponseElementName="Read_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("PaymentRequestList")]
        public PaymentRequestList Read(string No) {
            object[] results = this.Invoke("Read", new object[] {
                        No});
            return ((PaymentRequestList)(results[0]));
        }
        
        /// <remarks/>
        public void ReadAsync(string No) {
            this.ReadAsync(No, null);
        }
        
        /// <remarks/>
        public void ReadAsync(string No, object userState) {
            if ((this.ReadOperationCompleted == null)) {
                this.ReadOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadOperationCompleted);
            }
            this.InvokeAsync("Read", new object[] {
                        No}, this.ReadOperationCompleted, userState);
        }
        
        private void OnReadOperationCompleted(object arg) {
            if ((this.ReadCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadCompleted(this, new ReadCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/paymentrequestlist:ReadByRecId", RequestNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", ResponseElementName="ReadByRecId_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("PaymentRequestList")]
        public PaymentRequestList ReadByRecId(string recId) {
            object[] results = this.Invoke("ReadByRecId", new object[] {
                        recId});
            return ((PaymentRequestList)(results[0]));
        }
        
        /// <remarks/>
        public void ReadByRecIdAsync(string recId) {
            this.ReadByRecIdAsync(recId, null);
        }
        
        /// <remarks/>
        public void ReadByRecIdAsync(string recId, object userState) {
            if ((this.ReadByRecIdOperationCompleted == null)) {
                this.ReadByRecIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadByRecIdOperationCompleted);
            }
            this.InvokeAsync("ReadByRecId", new object[] {
                        recId}, this.ReadByRecIdOperationCompleted, userState);
        }
        
        private void OnReadByRecIdOperationCompleted(object arg) {
            if ((this.ReadByRecIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadByRecIdCompleted(this, new ReadByRecIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/paymentrequestlist:ReadMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", ResponseElementName="ReadMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("ReadMultiple_Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public PaymentRequestList[] ReadMultiple([System.Xml.Serialization.XmlElementAttribute("filter")] PaymentRequestList_Filter[] filter, string bookmarkKey, int setSize) {
            object[] results = this.Invoke("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize});
            return ((PaymentRequestList[])(results[0]));
        }
        
        /// <remarks/>
        public void ReadMultipleAsync(PaymentRequestList_Filter[] filter, string bookmarkKey, int setSize) {
            this.ReadMultipleAsync(filter, bookmarkKey, setSize, null);
        }
        
        /// <remarks/>
        public void ReadMultipleAsync(PaymentRequestList_Filter[] filter, string bookmarkKey, int setSize, object userState) {
            if ((this.ReadMultipleOperationCompleted == null)) {
                this.ReadMultipleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadMultipleOperationCompleted);
            }
            this.InvokeAsync("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize}, this.ReadMultipleOperationCompleted, userState);
        }
        
        private void OnReadMultipleOperationCompleted(object arg) {
            if ((this.ReadMultipleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadMultipleCompleted(this, new ReadMultipleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/paymentrequestlist:IsUpdated", RequestNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", ResponseElementName="IsUpdated_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("IsUpdated_Result")]
        public bool IsUpdated(string Key) {
            object[] results = this.Invoke("IsUpdated", new object[] {
                        Key});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsUpdatedAsync(string Key) {
            this.IsUpdatedAsync(Key, null);
        }
        
        /// <remarks/>
        public void IsUpdatedAsync(string Key, object userState) {
            if ((this.IsUpdatedOperationCompleted == null)) {
                this.IsUpdatedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsUpdatedOperationCompleted);
            }
            this.InvokeAsync("IsUpdated", new object[] {
                        Key}, this.IsUpdatedOperationCompleted, userState);
        }
        
        private void OnIsUpdatedOperationCompleted(object arg) {
            if ((this.IsUpdatedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsUpdatedCompleted(this, new IsUpdatedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/paymentrequestlist:GetRecIdFromKey", RequestNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", ResponseElementName="GetRecIdFromKey_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetRecIdFromKey_Result")]
        public string GetRecIdFromKey(string Key) {
            object[] results = this.Invoke("GetRecIdFromKey", new object[] {
                        Key});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetRecIdFromKeyAsync(string Key) {
            this.GetRecIdFromKeyAsync(Key, null);
        }
        
        /// <remarks/>
        public void GetRecIdFromKeyAsync(string Key, object userState) {
            if ((this.GetRecIdFromKeyOperationCompleted == null)) {
                this.GetRecIdFromKeyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecIdFromKeyOperationCompleted);
            }
            this.InvokeAsync("GetRecIdFromKey", new object[] {
                        Key}, this.GetRecIdFromKeyOperationCompleted, userState);
        }
        
        private void OnGetRecIdFromKeyOperationCompleted(object arg) {
            if ((this.GetRecIdFromKeyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecIdFromKeyCompleted(this, new GetRecIdFromKeyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist")]
    public partial class PaymentRequestList {
        
        private string keyField;
        
        private string noField;
        
        private System.DateTime dateField;
        
        private bool dateFieldSpecified;
        
        private string payeeField;
        
        private string payment_NarrationField;
        
        private string currency_CodeField;
        
        private decimal total_VAT_AmountField;
        
        private bool total_VAT_AmountFieldSpecified;
        
        private decimal total_Witholding_Tax_AmountField;
        
        private bool total_Witholding_Tax_AmountFieldSpecified;
        
        private decimal total_Net_AmountField;
        
        private bool total_Net_AmountFieldSpecified;
        
        private decimal total_Payment_AmountField;
        
        private bool total_Payment_AmountFieldSpecified;
        
        private string cheque_NoField;
        
        private Status statusField;
        
        private bool statusFieldSpecified;
        
        private string created_ByField;
        
        private string cashierField;
        
        /// <remarks/>
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        public string No {
            get {
                return this.noField;
            }
            set {
                this.noField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified {
            get {
                return this.dateFieldSpecified;
            }
            set {
                this.dateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Payee {
            get {
                return this.payeeField;
            }
            set {
                this.payeeField = value;
            }
        }
        
        /// <remarks/>
        public string Payment_Narration {
            get {
                return this.payment_NarrationField;
            }
            set {
                this.payment_NarrationField = value;
            }
        }
        
        /// <remarks/>
        public string Currency_Code {
            get {
                return this.currency_CodeField;
            }
            set {
                this.currency_CodeField = value;
            }
        }
        
        /// <remarks/>
        public decimal Total_VAT_Amount {
            get {
                return this.total_VAT_AmountField;
            }
            set {
                this.total_VAT_AmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Total_VAT_AmountSpecified {
            get {
                return this.total_VAT_AmountFieldSpecified;
            }
            set {
                this.total_VAT_AmountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Total_Witholding_Tax_Amount {
            get {
                return this.total_Witholding_Tax_AmountField;
            }
            set {
                this.total_Witholding_Tax_AmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Total_Witholding_Tax_AmountSpecified {
            get {
                return this.total_Witholding_Tax_AmountFieldSpecified;
            }
            set {
                this.total_Witholding_Tax_AmountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Total_Net_Amount {
            get {
                return this.total_Net_AmountField;
            }
            set {
                this.total_Net_AmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Total_Net_AmountSpecified {
            get {
                return this.total_Net_AmountFieldSpecified;
            }
            set {
                this.total_Net_AmountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Total_Payment_Amount {
            get {
                return this.total_Payment_AmountField;
            }
            set {
                this.total_Payment_AmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Total_Payment_AmountSpecified {
            get {
                return this.total_Payment_AmountFieldSpecified;
            }
            set {
                this.total_Payment_AmountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Cheque_No {
            get {
                return this.cheque_NoField;
            }
            set {
                this.cheque_NoField = value;
            }
        }
        
        /// <remarks/>
        public Status Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified {
            get {
                return this.statusFieldSpecified;
            }
            set {
                this.statusFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Created_By {
            get {
                return this.created_ByField;
            }
            set {
                this.created_ByField = value;
            }
        }
        
        /// <remarks/>
        public string Cashier {
            get {
                return this.cashierField;
            }
            set {
                this.cashierField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist")]
    public enum Status {
        
        /// <remarks/>
        Pending,
        
        /// <remarks/>
        _x0031_st_Approval,
        
        /// <remarks/>
        _x0032_nd_Approval,
        
        /// <remarks/>
        Cheque_Printing,
        
        /// <remarks/>
        Posted,
        
        /// <remarks/>
        Cancelled,
        
        /// <remarks/>
        Checking,
        
        /// <remarks/>
        Rejected,
        
        /// <remarks/>
        Pending_Approval,
        
        /// <remarks/>
        Approved,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist")]
    public partial class PaymentRequestList_Filter {
        
        private PaymentRequestList_Fields fieldField;
        
        private string criteriaField;
        
        /// <remarks/>
        public PaymentRequestList_Fields Field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        public string Criteria {
            get {
                return this.criteriaField;
            }
            set {
                this.criteriaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/paymentrequestlist")]
    public enum PaymentRequestList_Fields {
        
        /// <remarks/>
        No,
        
        /// <remarks/>
        Date,
        
        /// <remarks/>
        Payee,
        
        /// <remarks/>
        Payment_Narration,
        
        /// <remarks/>
        Currency_Code,
        
        /// <remarks/>
        Total_VAT_Amount,
        
        /// <remarks/>
        Total_Witholding_Tax_Amount,
        
        /// <remarks/>
        Total_Net_Amount,
        
        /// <remarks/>
        Total_Payment_Amount,
        
        /// <remarks/>
        Cheque_No,
        
        /// <remarks/>
        Status,
        
        /// <remarks/>
        Created_By,
        
        /// <remarks/>
        Cashier,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void ReadCompletedEventHandler(object sender, ReadCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PaymentRequestList Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PaymentRequestList)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void ReadByRecIdCompletedEventHandler(object sender, ReadByRecIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadByRecIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadByRecIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PaymentRequestList Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PaymentRequestList)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void ReadMultipleCompletedEventHandler(object sender, ReadMultipleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadMultipleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadMultipleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PaymentRequestList[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PaymentRequestList[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void IsUpdatedCompletedEventHandler(object sender, IsUpdatedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsUpdatedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsUpdatedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void GetRecIdFromKeyCompletedEventHandler(object sender, GetRecIdFromKeyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecIdFromKeyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecIdFromKeyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591