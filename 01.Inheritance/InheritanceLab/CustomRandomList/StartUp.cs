using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("something");
            randomList.Add("item");
            randomList.Add("in");
            randomList.Add("my");
            randomList.Add("pocket");

            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.RandomString());
            
            Console.WriteLine(string.Join(", ",randomList));
        }
    }
}
