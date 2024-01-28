
using System;
﻿namespace CanHazFunny;

class Program 
{ 
        static void Main(string[] args)
        {
            //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
            Jester jester = new(new JokePrint(), new JokeService());
            jester.JokePrint.PrintJoke(jester.JokeService.GetJoke());

        }
}
