using System.Linq;

namespace Misc
{
    public class AnagramUtil
    {
        public bool AreAnagrams(string str1, string str2)
        {
            var cleanStr1 = str1.Where(x => !char.IsWhiteSpace(x)).OrderBy(x => x).ToList();
            var cleanStr2 = str2.Where(x => !char.IsWhiteSpace(x)).OrderBy(x => x).ToList();

            if (cleanStr1.Count != cleanStr2.Count) return false;

            for (int i = 0; i < cleanStr1.Count; i++)
            {
                if (cleanStr1[i] != cleanStr2[i]) return false;
            }

            return true;
        }
    }
}
