using ES.AscomAlpaca.Client.Responses;
using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Responses
{
    public class ImageArrayDouble3DResponseIsInitialisedWith
    {
        [Fact]
        public void ImageArrayDouble3DResponse_IsInitialisedWith_Rank2_And_TypeDouble()
        {
            var response = new ImageArrayDouble3DResponse();
            
            Assert.Equal(3, response.Rank);
            Assert.Equal(ImageArrayType.Double, response.ArrayType);
        }
    }
}