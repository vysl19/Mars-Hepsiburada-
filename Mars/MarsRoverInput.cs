namespace Mars
{
    /// <summary>
    /// The input is used for console input
    /// </summary>
    public class MarsRoverInput
    {
        /// <summary>
        /// The Format of position expects to be same with "1 2 N"
        /// First character is x location
        /// Second chracter is y location
        /// third chracter is direction
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// It keeps the insructions for a rover
        /// </summary>
        public string Instruction { get; set; }
    }
}
