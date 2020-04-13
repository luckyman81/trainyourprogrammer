using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CS_Aufgabe_136_LeastCommonMultiple
{
    internal class PrimePowEqualityComparer : IEqualityComparer<PrimePow>
    {
        public bool Equals([AllowNull] PrimePow x, [AllowNull] PrimePow y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.Key == y.Key)
                return true;
            else
                return false;
        }

        public int GetHashCode([DisallowNull] PrimePow obj)
        {
            int hCode = obj.Key;
            return hCode.GetHashCode();
        }
    }
}