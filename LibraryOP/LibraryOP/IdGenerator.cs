using System;
using System.Collections.Generic;

namespace LibraryOP
{
    public static class IdGenerator
    {
        public static int GenerateId(List<int> ids)
        {
            Random rand = new Random();

            int random = rand.Next();
            while (ids.Contains(random))
            {
                random = rand.Next();
            }

            return random;
        }
    }
}
