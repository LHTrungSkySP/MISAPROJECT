﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.WEB07.LHTRUNG.GD.DTO.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.WEB07.LHTRUNG.GD.DTO.Resources.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Trùng mã!!! Mã nhân viên đã tồn tại!.
        /// </summary>
        public static string duplicateOfficerCode_exp {
            get {
                return ResourceManager.GetString("duplicateOfficerCode_exp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email không đúng định dạng!!!.
        /// </summary>
        public static string emailFail {
            get {
                return ResourceManager.GetString("emailFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra!!! Vui lòng liên hệ với MISA để được hỗ trợ!.
        /// </summary>
        public static string error_exp {
            get {
                return ResourceManager.GetString("error_exp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thông tin {0} không được phép để trống..
        /// </summary>
        public static string InfoNotEmpty {
            get {
                return ResourceManager.GetString("InfoNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} sai format!!!.
        /// </summary>
        public static string InfoNotTrue {
            get {
                return ResourceManager.GetString("InfoNotTrue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} có giá trị nằm ngoài giá trị cho phép!!!.
        /// </summary>
        public static string InfoOutSize {
            get {
                return ResourceManager.GetString("InfoOutSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thông tin {0} nhập vào có độ dài sai!!!.
        /// </summary>
        public static string lengthNotTrue {
            get {
                return ResourceManager.GetString("lengthNotTrue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số điện thoại không đúng định dạng!!!.
        /// </summary>
        public static string phoneNumberFail {
            get {
                return ResourceManager.GetString("phoneNumberFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ngày nghỉ việc không được lớn hơn ngày hiện tại!.
        /// </summary>
        public static string quitDate_exp {
            get {
                return ResourceManager.GetString("quitDate_exp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lỗi format của dữ liệu, dữ liệu không đúng định dạng!.
        /// </summary>
        public static string valiadate_exp {
            get {
                return ResourceManager.GetString("valiadate_exp", resourceCulture);
            }
        }
    }
}