using ES.Ascom.Alpaca.Responses;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Responses
{
    public class ImageArrayShort2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeShort()
        {
            var response = new ImageArrayShort2DResponse(new short[1,1]);
            
            Assert.Equal(ImageArrayRank.SinglePlane, response.Rank);
            Assert.Equal(ImageArrayType.Short, response.ArrayType);
        }
    }
}