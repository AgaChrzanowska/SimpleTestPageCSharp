using System;

namespace SimpleTestPageCSharp.Common
{
    public static class DataHelper
    {
        public static string GetRandomText(int length)
        {
            return Guid.NewGuid().ToString("n").Substring(0, length);
        }
    }
}
