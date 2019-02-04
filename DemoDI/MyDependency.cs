namespace DemoDI
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    #endregion

    public class MyDependency
    {
        #region Champs et constantes statiques

        private static readonly Random rand = new Random();

        #endregion

        #region Champs

        private readonly MyDependency2 dependency2;

        #endregion

        #region Constructeurs et destructeurs

        public MyDependency(MyDependency2 dependency2)
        {
            this.Value = rand.Next(1000);
            Console.WriteLine("MyDependency : ctor.");
            this.dependency2 = dependency2;
        }

        #endregion

        #region Propriétés et indexeurs

        public int Value { get; }

        #endregion

        #region Méthodes publiques

        public Task WriteMessage(string message)
        {
            Console.WriteLine(
                $"MyDependency.WriteMessage called. Message: {message} {this.Value}");
            Console.WriteLine(
                $"MyDependency2.WriteMessage called. Message: {this.dependency2.Value}");

            return Task.CompletedTask;
        }

        #endregion
    }
}
