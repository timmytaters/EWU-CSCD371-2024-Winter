
using System;
﻿namespace CanHazFunny;

public static class Program 
{ 
        public static void Main()
        {
            //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
            Jester jester = new(new JokePrint(), new JokeService());
            jester.TellJoke();

        }
}
