using System;
using System.Threading.Tasks;

namespace DemoDI
{
    public class MyDependency
    {

        private static Random rand = new Random();
        private readonly MyDependency2 dependency2;

        public MyDependency(MyDependency2 dependency2)
        {
            this.Value = rand.Next(1000);
            Console.WriteLine("MyDependency : ctor.");
            this.dependency2 = dependency2;
        }

        public int Value { get; }

        public Task WriteMessage(string message)
        {
            Console.WriteLine(
                $"MyDependency.WriteMessage called. Message: {message} {this.Value}");
            Console.WriteLine(
                $"MyDependency2.WriteMessage called. Message: {this.dependency2.Value}");

            return Task.CompletedTask;
        }
    }
}