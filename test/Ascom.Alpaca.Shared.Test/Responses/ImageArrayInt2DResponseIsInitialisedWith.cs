using ES.Ascom.Alpaca.Responses;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Responses
{
    public class ImageArrayInt2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeInt()
        {
            var response = new ImageArrayInt2DResponse(new int[1,1]);
            
            Assert.Equal(ImageArrayRank.SinglePlane, response.Rank);
            Assert.Equal(ImageArrayType.Int, response.ArrayType);
        }
    }
}