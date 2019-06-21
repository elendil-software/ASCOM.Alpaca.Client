namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Represents the number of planes of an image
    /// </summary>
    public enum ImageArrayRank
    {
        /// <summary>
        /// Single plane image (monochrome)
        /// </summary>
        SinglePlane = 2,
        
        /// <summary>
        /// Multi plane image (colour)
        /// </summary>
        MultiPlane = 3
    }
}