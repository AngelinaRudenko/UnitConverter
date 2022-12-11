namespace UnitConverter.Decoder
{
    public struct DecodedInputDTO
    {
        public string FromUnit { get; set; }
        public string FromPrefix { get; set; }
        public string ToUnit { get; set; }
        public string ToPrefix { get; set; }
        public double FromValue { get; set; }
        public string CategoryConverterName { get; set; }
    }
}