using System;
using System.ComponentModel;
using System.Reflection;

namespace Easy.SharedKernel.Helpers
{
    public static class Helper
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GetDescription(int value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static int CalcularDiasEmAberto(DateTime dataInicio, DateTime dataFim)
        {
            return (dataFim - dataInicio).Days;
        }
    }
}
