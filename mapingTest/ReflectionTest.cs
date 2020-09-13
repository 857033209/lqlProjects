using System;
using System.Reflection;

namespace mapingTest
{
    class ReflectionHelper
    {
        public static void GetAssemblyInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("程序集全名：{0}", assembly.FullName);
            Console.WriteLine("程序集的版本：{0}", assembly.GetName().Version);
            Console.WriteLine("程序集初始位置：{0}", assembly.CodeBase);
            Console.WriteLine("程序集位置：{0}", assembly.Location);
            Console.WriteLine("程序集入口：{0}", assembly.EntryPoint);
            Type[] types = assembly.GetTypes();
            Console.WriteLine("程序集中包含的类型：");
            foreach (Type item in types)
            {
                Console.WriteLine("类：" + item.Name);
            }
        }

        public static void GetTypeInfo(Type type)
        {
            Console.WriteLine("类型名：{0}", type.Name);
            Console.WriteLine("类全名：{0}", type.FullName);
            Console.WriteLine("命名空间：{0}", type.Namespace);
            Console.WriteLine("程序集名：{0}", type.Assembly);
            Console.WriteLine("模块名：{0}", type.Module);
            Console.WriteLine("基类名：{0}", type.BaseType);
            Console.WriteLine("是否类：{0}", type.IsClass);
            Console.WriteLine("类的公共成员：");
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo memberInfo in members)
            {
                Console.WriteLine("{0}:{1}", memberInfo.MemberType, memberInfo);
            }
        }

        public static void InvokeMethod(string dllName,string className,string funtionName)
        {
            #region 方法一
            Assembly assembly1 = Assembly.Load(dllName);
            Type type1 = assembly1.GetType(className);
            object obj1 = System.Activator.CreateInstance(type1);
            MethodInfo method1 = type1.GetMethod(funtionName);
            method1.Invoke(obj1, null);
            #endregion

            #region 方法二
            object obj2 = Assembly.Load(dllName).CreateInstance(className);
            Type type2 = obj2.GetType();
            MethodInfo method = type2.GetMethod(funtionName);
            method.Invoke(obj2, null);
            #endregion
        }
    }
}
