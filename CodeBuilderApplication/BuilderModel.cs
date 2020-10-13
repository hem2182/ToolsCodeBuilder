using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilderApplication
{
    public class BuilderModelTools
    {
        public string ToolName { get; set; }

        public List<ToolClass> ToolClasses { get; set; } = new List<ToolClass>();

    }

    public class ToolClass
    {
        public string ClassName { get; set; }

        public List<ClassMethod> ClassMethods { get; set; } = new List<ClassMethod>();
    }

    public class ClassMethod
    {
        public string MethodName { get; set; }

        public string ReturnType { get; set; }

        public List<MethodParameter> MethodParameters { get; set; } = new List<MethodParameter>();
    }

    public class MethodParameter
    {
        public string ParameterName { get; set; }

        public string ParameterType { get; set; }
    }
}
