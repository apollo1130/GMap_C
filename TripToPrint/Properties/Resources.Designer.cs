//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TripToPrint.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TripToPrint.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Failed to load document.
        /// </summary>
        public static string Error_FailedToLoadDocument {
            get {
                return ResourceManager.GetString("Error_FailedToLoadDocument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This item has been discovered on Foursquare.com.
        /// </summary>
        public static string StepExplore_Source_Foursquare_Tooltip {
            get {
                return ResourceManager.GetString("StepExplore_Source_Foursquare_Tooltip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This item has been discovered on HERE.com.
        /// </summary>
        public static string StepExplore_Source_Here_Tooltip {
            get {
                return ResourceManager.GetString("StepExplore_Source_Here_Tooltip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Explore recommended and popular places nearby.
        /// </summary>
        public static string StepExplore_UpperGroup_Explore {
            get {
                return ResourceManager.GetString("StepExplore_UpperGroup_Explore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Extra information found for your placemarks.
        /// </summary>
        public static string StepExplore_UpperGroup_Placemarks {
            get {
                return ResourceManager.GetString("StepExplore_UpperGroup_Placemarks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Generation process complete.
        /// </summary>
        public static string StepGeneration_GenerateReport_Done {
            get {
                return ResourceManager.GetString("StepGeneration_GenerateReport_Done", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Generation process is done with issues. Check the generation log for details..
        /// </summary>
        public static string StepGeneration_GenerateReport_DoneWithIssues {
            get {
                return ResourceManager.GetString("StepGeneration_GenerateReport_DoneWithIssues", resourceCulture);
            }
        }
    }
}
