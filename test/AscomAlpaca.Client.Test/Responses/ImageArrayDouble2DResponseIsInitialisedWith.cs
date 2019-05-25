using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Responses
{
    public class ImageArrayDouble2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeDouble()
        {
            var response = new ImageArrayDouble2DResponse(new double[1,1]);
            
            Assert.Equal(2, response.Rank);
            Assert.Equal(ImageArrayType.Double, response.ArrayType);
        }
    }
}