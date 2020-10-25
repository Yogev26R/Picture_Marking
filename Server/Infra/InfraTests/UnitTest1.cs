using NUnit.Framework;
using Contracts;
using DI;

namespace InfraTests
{
    public class Tests
    {
        IResolver _resolver;

        [SetUp]
        public void Setup()
        {
            _resolver = new Resolver(@"..\dlls");
        }

        [Test]
        public void Test1()
        {
            // var player = _resolver.Resolve<IHumanPlayer>();
            // Assert.IsInstanceOf(typeof(IHumanPlayer), player); 
        }
    }
}