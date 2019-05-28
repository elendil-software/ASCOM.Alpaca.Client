using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Shared.Test.Responses
{
    public class ImageArrayInt3DResponseIsInitialisedWith
    {
        [Fact]
        public void ImageArrayInt3DResponse_IsInitialisedWith_Rank2_And_TypeInt()
        {
            var response = new ImageArrayInt3DResponse(new int[1,1,1]);
            
            Assert.Equal(ImageArrayRank.MultiPlane, response.Rank);
            Assert.Equal(ImageArrayType.Int, response.ArrayType);
        }
    }
}