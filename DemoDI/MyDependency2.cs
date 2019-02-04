namespace DemoDI
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    #endregion

    public class MyDependency2
    {
        #region Champs et constantes statiques

        private static readonly Random rand = new Random();

        #endregion

        #region Constructeurs et destructeurs

        public MyDependency2()
        {
            this.Value = rand.Next(1000);
            Console.WriteLine("MyDependency2 : ctor.");
        }

        #endregion

        #region Propriétés et indexeurs

        public int Value { get; }

        #endregion

        #region Méthodes publiques

        public Task WriteMessage(string message)
        {
            Console.WriteLine(
                $"MaDependance.WriteMessage called. Message: {message} {this.Value}");

            return Task.CompletedTask;
        }

        #endregion
    }
}
