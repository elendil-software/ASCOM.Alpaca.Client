using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Shared.Test.Responses
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