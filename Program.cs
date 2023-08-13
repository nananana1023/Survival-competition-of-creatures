using System.Reflection.PortableExecutable;
using TextFile;
namespace creature_me
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Create a program to model survival competition of creatures.
            The creatures may belong to 3 species (greenfinch, dune beetle, squelchy). Every creature has 
            a name (string) and power (natural number). The creatures (one after the other) pass a 
            racetrack which consists of fields with different types of ground (sand, grass, marsh). When a 
            creature passes on a ground, it may change it while its power changes. If the power of the 
            creature falls to zero or less, it dies. Give the name of the creatures who survive the 
            competition.
            • Greenfinch: its power increases by one on grass, decreases by two on sand and by 
            one on marsh. It transfmutes marsh to grass.
            • Dune beetle: its power decreases by two on grass, by four on marsh, and increases by 
            three on sand. It transfmutes marsh to grass and grass to sand.
            • Squelchy: its power decreases by two on grass, by five on sand, and increases by six 
            on marsh. It transfmutes grass to marsh. 
            Every data is stored in a text file. The first line contains the number of creatures. Each of the 
            following lines contain the data of one creature: one character for the type (G – Greenfinch, 
            D – Dune beetle, S – Squelchy), name of the creature (one word), and the initial level of 
            exhilaration.
            In the last line, a natural number is given for the length of the racetrack, followed by IDs of 
            the ground of each part of the track. The IDs: 0 – sand, 1 – grass, 2 – marsh. The file is 
            assumed to be correct.*/

            TextFileReader r = new TextFileReader("inp.txt");
            List<Creature> creatures = new List<Creature>();
            List<IGround> track = new List<IGround>();

            // populating creatures
            r.ReadLine(out string num); 
            int n = int.Parse(num);
            for (int i=0; i < n; i++)
            {
                Creature creature = null;
                if (r.ReadLine(out string line))
                {
                    string[] spr = line.Split(' ');
                    char type = char.Parse(spr[0]);
                    string name = spr[1];
                    int p = int.Parse(spr[2]);
                
                    switch (type)
                    {
                        case 'G': creature = new Greenfinch(name, p); break;
                        case 'D': creature = new Dune(name, p); break;
                        case 'S': creature = new Squelchy(name, p); break;
                    }
                }
               creatures.Add(creature);
            }

            //tracks
            r.ReadLine(out string line2); int m = int.Parse(line2);
            for (int j = 0; j < m; ++j)
            {
                r.ReadChar(out char c);
                switch (c)
                {
                    case 'g': track.Add(Grass.Instance()); break;
                    case 's': track.Add(Sand.Instance()); break;
                    case 'm': track.Add(Marsh.Instance()); break;
                }
            }

    
                foreach(var c in creatures)
                {
                    c.Race(ref track);
                    if(c.Alive())
                    {
                        Console.WriteLine(c.getName());
                    }
                }
                
            
           


       

        }
    }
}