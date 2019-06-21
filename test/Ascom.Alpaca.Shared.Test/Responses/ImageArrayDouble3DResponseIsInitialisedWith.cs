using ES.Ascom.Alpaca.Responses;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Responses
{
    public class ImageArrayDouble3DResponseIsInitialisedWith
    {
        [Fact]
        public void ImageArrayDouble3DResponse_IsInitialisedWith_Rank2_And_TypeDouble()
        {
            var response = new ImageArrayDouble3DResponse(new double[1,1,1]);
            
            Assert.Equal(ImageArrayRank.MultiPlane, response.Rank);
            Assert.Equal(ImageArrayType.Double, response.ArrayType);
        }
    }
}