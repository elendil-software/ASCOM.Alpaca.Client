using ES.AscomAlpaca.Client.Responses;
using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Responses
{
    public class ImageArrayInt2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeInt()
        {
            var response = new ImageArrayInt2DResponse();
            
            Assert.Equal(2, response.Rank);
            Assert.Equal(ImageArrayType.Int, response.ArrayType);
        }
    }
}