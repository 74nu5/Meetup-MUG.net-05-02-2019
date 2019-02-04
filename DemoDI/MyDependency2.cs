using System;
using System.Threading.Tasks;

namespace DemoDI
{
    public class MyDependency2
    {

        private static Random rand = new Random();

        public MyDependency2()
        {
            this.Value = rand.Next(1000);
            Console.WriteLine("MyDependency2 : ctor.");
        }

        public int Value { get; }

        public Task WriteMessage(string message)
        {
            Console.WriteLine(
                $"MaDependance.WriteMessage called. Message: {message} {this.Value}");

            return Task.CompletedTask;
        }
    }
}