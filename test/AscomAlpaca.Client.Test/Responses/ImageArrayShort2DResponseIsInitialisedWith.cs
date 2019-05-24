using ES.AscomAlpaca.Client.Responses;
using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Responses
{
    public class ImageArrayShort2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeShort()
        {
            var response = new ImageArrayShort2DResponse();
            
            Assert.Equal(2, response.Rank);
            Assert.Equal(ImageArrayType.Short, response.ArrayType);
        }
    }
}