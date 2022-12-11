namespace UnitConverter.Decoder
{
    internal struct DecodedInputDTO
    {
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double FromValue { get; set; }
        public string CategoryConverterName { get; set; }
    }
}