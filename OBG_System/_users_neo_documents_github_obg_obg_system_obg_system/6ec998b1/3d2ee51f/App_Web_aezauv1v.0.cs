﻿#pragma checksum "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89B55656B353227E46DB7379E0AB9DBB7F816F82"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



public partial class Admin_Default : System.Web.SessionState.IRequiresSessionState {
    
    protected System.Web.Profile.DefaultProfile Profile {
        get {
            return ((System.Web.Profile.DefaultProfile)(this.Context.Profile));
        }
    }
    
    protected ASP.global_asax ApplicationInstance {
        get {
            return ((ASP.global_asax)(this.Context.ApplicationInstance));
        }
    }
}
namespace ASP {
    
    #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
    using System.Web.UI.WebControls.Expressions;
    
    #line default
    #line hidden
    
    #line 387 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 393 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 400 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Profile;
    
    #line default
    #line hidden
    
    #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
    using System.Web.UI;
    
    #line default
    #line hidden
    
    #line 388 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 392 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
    using ASP;
    
    #line default
    #line hidden
    
    #line 398 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.SessionState;
    
    #line default
    #line hidden
    
    #line 391 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Configuration;
    
    #line default
    #line hidden
    
    #line 395 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web;
    
    #line default
    #line hidden
    
    #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
    using System.Web.DynamicData;
    
    #line default
    #line hidden
    
    #line 396 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Caching;
    
    #line default
    #line hidden
    
    #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
    using System.Web.UI.WebControls;
    
    #line default
    #line hidden
    
    #line 390 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 399 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Security;
    
    #line default
    #line hidden
    
    #line 386 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
    using System.Web.UI.WebControls.WebParts;
    
    #line default
    #line hidden
    
    #line 394 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Text.RegularExpressions;
    
    #line default
    #line hidden
    
    #line 389 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections.Specialized;
    
    #line default
    #line hidden
    
    #line 405 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Xml.Linq;
    
    #line default
    #line hidden
    
    #line 404 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.UI.HtmlControls;
    
    #line default
    #line hidden
    
    
    [System.Runtime.CompilerServices.CompilerGlobalScopeAttribute()]
    public class admin_categorymanagement_aspx : global::Admin_Default, System.Web.IHttpHandler {
        
        private static System.Reflection.MethodInfo @__PageInspector_SetTraceDataMethod = global::ASP.admin_categorymanagement_aspx.@__PageInspector_LoadHelper("SetTraceData");
        
        private static bool @__initialized;
        
        private static object @__fileDependencies;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public admin_categorymanagement_aspx() {
            string[] dependencies;
            
            #line 912304 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx.cs"
            ((global::System.Web.UI.Page)(this)).AppRelativeVirtualPath = "~/Admin/CategoryManagement.aspx";
            
            #line default
            #line hidden
            if ((global::ASP.admin_categorymanagement_aspx.@__initialized == false)) {
                dependencies = new string[4];
                dependencies[0] = "~/Admin/CategoryManagement.aspx";
                dependencies[1] = "~/Admin/AdminSite.master";
                dependencies[2] = "~/Admin/AdminSite.master.cs";
                dependencies[3] = "~/Admin/CategoryManagement.aspx.cs";
                global::ASP.admin_categorymanagement_aspx.@__fileDependencies = this.GetWrappedFileDependencies(dependencies);
                global::ASP.admin_categorymanagement_aspx.@__initialized = true;
            }
            this.Server.ScriptTimeout = 30000000;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control2() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\n");
            @__ctrl.TemplateControl = this;
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        241,
                        1,
                        true});
            return @__ctrl;
        }
        
        private static System.Reflection.MethodInfo @__PageInspector_LoadHelper(string helperName) {
            System.Type helperClass = System.Type.GetType("Microsoft.VisualStudio.Web.PageInspector.Runtime.WebForms.TraceHelpers, Microsoft" +
                    ".VisualStudio.Web.PageInspector.Runtime, Version=1.3.0.0, Culture=neutral, Publi" +
                    "cKeyToken=b03f5f7f11d50a3a", false, false);
            if ((helperClass != null)) {
                return helperClass.GetMethod(helperName);
            }
            return null;
        }
        
        private void @__PageInspector_SetTraceData(object[] parameters) {
            if ((global::ASP.admin_categorymanagement_aspx.@__PageInspector_SetTraceDataMethod != null)) {
                global::ASP.admin_categorymanagement_aspx.@__PageInspector_SetTraceDataMethod.Invoke(null, parameters);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControlContent1(System.Web.UI.Control @__ctrl) {
            global::System.Web.UI.LiteralControl @__ctrl1;
            
            #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__ctrl1 = this.@__BuildControl__control2();
            
            #line default
            #line hidden
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            
            #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__parser.AddParsedSubObject(@__ctrl1);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control3() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\n");
            @__ctrl.TemplateControl = this;
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        334,
                        1,
                        true});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControlContent2(System.Web.UI.Control @__ctrl) {
            global::System.Web.UI.LiteralControl @__ctrl1;
            
            #line 5 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__ctrl1 = this.@__BuildControl__control3();
            
            #line default
            #line hidden
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            
            #line 5 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__parser.AddParsedSubObject(@__ctrl1);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControlTree(admin_categorymanagement_aspx @__ctrl) {
            
            #line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__ctrl.Title = "";
            
            #line default
            #line hidden
            
            #line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__ctrl.MasterPageFile = "~/Admin/AdminSite.master";
            
            #line default
            #line hidden
            
            #line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            this.InitializeCulture();
            
            #line default
            #line hidden
            
            #line 3 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            this.AddContentTemplate("HeadContent", new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControlContent1)));
            
            #line default
            #line hidden
            
            #line 5 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            this.AddContentTemplate("MainContent", new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControlContent2)));
            
            #line default
            #line hidden
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            
            #line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\n"));
            
            #line default
            #line hidden
            
            #line 1 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx"
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\n\n"));
            
            #line default
            #line hidden
        }
        
        
        #line 912304 "C:\Users\Neo\Documents\GitHub\OBG\OBG_System\OBG_System\Admin\CategoryManagement.aspx.cs"
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void FrameworkInitialize() {
            base.FrameworkInitialize();
            this.@__BuildControlTree(this);
            this.AddWrappedFileDependencies(global::ASP.admin_categorymanagement_aspx.@__fileDependencies);
            this.Request.ValidateInput();
        }
        
        #line default
        #line hidden
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override int GetTypeHashCode() {
            return 1654561052;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override void ProcessRequest(System.Web.HttpContext context) {
            base.ProcessRequest(context);
        }
    }
}
