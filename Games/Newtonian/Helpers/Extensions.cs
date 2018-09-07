using System.Collections.Generic;

namespace Joueur.cs.Games.Newtonian.Helpers
{
    public static class Extensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection) => new HashSet<T>(collection);
    }
}
