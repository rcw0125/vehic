using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VehIC_WF.Sampling
{
    public class Cls_EnumHandle
    {
        public static string GetDescription(Enum value)
        {
            if (value == null) throw new ArgumentNullException("value");
            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attr = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (attr != null && attr.Length > 0)
            {
                description = attr[0].Description;
            }

            return description;
        }

        public static IList ToList(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (!type.IsEnum) throw new ArgumentException("Type provided must be an Enum.", "type");

            ArrayList list = new ArrayList();
            Array array = Enum.GetValues(type);
            foreach (Enum value in array)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDescriptionAttribute : Attribute
    {
        private string description;

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public EnumDescriptionAttribute(string description)
            : base()
        {
            this.description = description;
        }
    }

}
