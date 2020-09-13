using System;

namespace mapingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReflectionHelper.GetTypeInfo(typeof(Test1.Test));
            ReflectionHelper.InvokeMethod("Test1", "Test1.Test", "f2");
        }
    }

}

namespace Test1
{
    class Test
    {
        private int a1;
        public int a2;
        private void f1()
        {
            Console.WriteLine("f1");
        }

        public void f2()
        {
            Console.WriteLine("f2");
        }
    }
}
