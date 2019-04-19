
namespace Compression.Huffman.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MapBuilder
    {
        public static IDictionary<char, int> GetExample() => new Dictionary<char, int>()
         {
                {'a', 5  },
                {'b', 9  },
                {'c', 12 },
                {'d', 13 },
                {'e', 16 } ,
                {'f', 45 }
         };
    }
}
