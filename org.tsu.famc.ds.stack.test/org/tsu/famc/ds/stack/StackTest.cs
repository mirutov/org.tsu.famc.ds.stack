using System;


namespace org.tsu.famc.ds.stack
{
    class StackTest
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            // some comment
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    s.Push(i);
                }
                Stack s1 = new Stack(s);
                while (true)
                {
                    Console.WriteLine(s1.Pop());
                }
            }
            catch (EStackEmpty e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
