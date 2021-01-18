using System;

namespace GCSeleniumTests
{
    public class HelperMethods
    {
        public string GetRandomThreadNumber()
        {
            Random rand = new Random();
            string threadMainNumber = rand.Next(2, 11).ToString();
            string threadSubNumber = rand.Next(1, 17).ToString();
            return $"{threadMainNumber}.{threadSubNumber}";
        }

        public string GetRandomVariation()
        {
            Random rand = new Random();
            string chars = "abcdef";
            int num = rand.Next(chars.Length);
            return chars[num].ToString();
        }
    }
}