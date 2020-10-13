using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilderApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BuilderModelTools> modelTools = new List<BuilderModelTools>();

            DirectoryInfo d = new DirectoryInfo(@"C:/Code/ToolsCodeBuilder/CodeBuilderApplication/bin/DependenciesTools");
            var dllFiles = d.GetFiles("*.dll");
            foreach (var files in dllFiles)
            {
                Assembly asm = Assembly.LoadFile(files.FullName);
                var classes = asm.GetTypes().Where(x => x.IsClass == true);
                var c = new BuilderModelTools { ToolName = asm.GetName().ToString() };
                modelTools.Add(c);
                foreach (Type typeInfo in classes)
                {
                    MethodInfo[] classMethods = typeInfo.GetMethods();
                    Console.WriteLine();
                    Console.WriteLine("ToolName = " + typeInfo.Namespace);
                    Console.WriteLine("ClassName = " + typeInfo.Name);
                    var t = new ToolClass
                    {
                        ClassName = typeInfo.Name
                    };
                    c.ToolClasses.Add(t);

                    foreach (var methodName in classMethods)
                    {
                        var methods = new ClassMethod()
                        {
                            MethodName = methodName.Name,
                            ReturnType = methodName.ReturnType.ToString()
                        };
                        t.ClassMethods.Add(methods);
                        Console.WriteLine(methodName.Name);
                    }

                }
            }
            WriteCode(modelTools);
            Console.ReadKey();
            
        }

        private static void WriteCode(List<BuilderModelTools> modelTools)
        {
            var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(modelTools);
        }
    }
}
