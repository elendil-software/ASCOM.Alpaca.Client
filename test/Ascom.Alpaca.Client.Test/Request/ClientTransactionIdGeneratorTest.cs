using ES.Ascom.Alpaca.Client.Request;
using Xunit;

namespace ES.Ascom.Alpaca.Client.Test.Request
{
    public class ClientTransactionIdGeneratorTest
    {
        [Fact]
        public void GeneratorReturnsValue1OnFirstCallForEachClient()
        {
            var generator = new ClientTransactionIdGenerator();

            var firstIdClient1 = generator.GetTransactionId(1);
            var firstIdClient2 = generator.GetTransactionId(2);
            
            Assert.Equal(1, firstIdClient1);
            Assert.Equal(1, firstIdClient2);
        }

        [Fact]
        public void GeneratedIdIsIncrementedOnEachCall()
        {
            var generator = new ClientTransactionIdGenerator();

            var generatedId1 = generator.GetTransactionId(1);
            var generatedId2 = generator.GetTransactionId(1);
            var generatedId3 = generator.GetTransactionId(1);
            
            Assert.Equal(1, generatedId1);
            Assert.Equal(2, generatedId2);
            Assert.Equal(3, generatedId3);
        }
    }
}