<<<<<<< HEAD
﻿using System;

namespace CanHazFunny
=======
﻿namespace CanHazFunny;

class Program
>>>>>>> d7110209c32aafd7f0d4bd877409d09bf9f50e1a
{
    static void Main(string[] args)
    {
<<<<<<< HEAD
        static void Main(string[] args)
        {
            //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
            Jester jester = new(new JokePrint(), new JokeService());
            jester.jokePrint.PrintJoke(jester.jokeService.GetJoke());

        }
=======
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
>>>>>>> d7110209c32aafd7f0d4bd877409d09bf9f50e1a
    }
}
