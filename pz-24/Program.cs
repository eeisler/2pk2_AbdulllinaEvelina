using pz_22;
using pz_23;

namespace pz_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = new NegativeFN(4, 5, 10);
            var f = new FractionalNumbers("+", 50, 67);

            var nClone = (NegativeFN)n.Clone();
            nClone.Capacity = 1000;

            var nClone2 = (NegativeFN)nClone.Clone();
            nClone2.Capacity = 20;

            var fClone = (FractionalNumbers)f.Clone();
            fClone.Divider = 156;

            var fClone2 = (FractionalNumbers)fClone.Clone();
            fClone2.Divider = 346;

            Console.WriteLine($"n.Capacity: {n.Capacity}\t\tnClone.Capacity: {nClone.Capacity}");
            Console.WriteLine($"nClone.Capacity: {nClone.Capacity}\tnClone2.Capacity: {nClone2.Capacity}");
            Console.WriteLine($"f.Divider: {f.Divider}\t\tfClone.Divider: {fClone.Divider}");
            Console.WriteLine($"fClone.Divider: {fClone.Divider}\tfClone2.Divider: {fClone2.Divider}");
        }
    }
}