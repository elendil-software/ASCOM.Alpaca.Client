using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Shared.Test.Responses
{
    public class ImageArrayInt2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeInt()
        {
            var response = new ImageArrayInt2DResponse(new int[1,1]);
            
            Assert.Equal(2, response.Rank);
            Assert.Equal(ImageArrayType.Int, response.ArrayType);
        }
    }
}