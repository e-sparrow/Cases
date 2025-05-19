using System;
using Cyriller;

namespace Birdhouse.Cases
{
    public static class CyrillerHelper
    {
        public static readonly Lazy<CyrNounCollection> MainNounCollection
            = new Lazy<CyrNounCollection>(() => new CyrNounCollection());
    }
}