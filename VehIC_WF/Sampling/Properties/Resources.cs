namespace VehIC_WF.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), CompilerGenerated, DebuggerNonUserCode]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static Bitmap _1
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("1", resourceCulture);
            }
        }

        internal static Bitmap _2
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("2", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap ffffff
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("ffffff", resourceCulture);
            }
        }

        internal static Bitmap PRINT3
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("PRINT3", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("VehIC_WF.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static Bitmap search
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("search", resourceCulture);
            }
        }

        internal static Bitmap VIEWER4
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("VIEWER4", resourceCulture);
            }
        }
    }
}

