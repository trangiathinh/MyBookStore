using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Infrastructure
{
    public class SaltHelper
    {
        public static string GenerateSalt(int length)
        {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}