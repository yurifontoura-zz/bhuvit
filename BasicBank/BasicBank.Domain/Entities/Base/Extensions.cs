namespace BasicBank.Domain.Entities
{
    public static class MathUtils
    {
        /// <summary>
        /// If the number is negative, turns it into zero. Otherwise returns itself.
        /// </summary>
        public static int Positive(this int number) => number < 0 ? 0 : number;
        /// <summary>
        /// If the number is negative, turns it into zero. Otherwise returns itself.
        /// </summary>
        public static int? Positive(this int? number) => !number.HasValue || number < 0 ? 0 : number;
        /// <summary>
        /// If the number is negative, turns it into zero. Otherwise returns itself.
        /// </summary>
        public static decimal Positive(this decimal number) => number < 0 ? 0 : number;
        /// <summary>
        /// If the number is negative, turns it into zero. Otherwise returns itself.
        /// </summary>
        public static decimal? Positive(this decimal? number) => !number.HasValue || number < 0 ? 0 : number;
    }
}
