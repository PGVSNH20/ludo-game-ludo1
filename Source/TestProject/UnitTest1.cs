using NUnit.Framework;
using System;
using System.IO;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static void test()
        {
            Console.WriteLine("What's your name?");
            var name = Console.ReadLine();
            Console.WriteLine(string.Format("Hello {0}!!", name));
        }

        [Test]
        public void something()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("Somebody");
            Console.SetIn(input);

            test();

            NUnit.Framework.Assert.That(output.ToString(), Is.EqualTo(string.Format("What's your name?{0}Hello Somebody!!{0}", Environment.NewLine)));
        }
    }
}