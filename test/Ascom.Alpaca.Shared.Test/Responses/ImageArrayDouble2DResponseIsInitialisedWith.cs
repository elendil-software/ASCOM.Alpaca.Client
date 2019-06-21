using ES.Ascom.Alpaca.Responses;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Responses
{
    public class ImageArrayDouble2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeDouble()
        {
            var response = new ImageArrayDouble2DResponse(new double[1,1]);
            
            Assert.Equal(ImageArrayRank.SinglePlane, response.Rank);
            Assert.Equal(ImageArrayType.Double, response.ArrayType);
        }
    }
}