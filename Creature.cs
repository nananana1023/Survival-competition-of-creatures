using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creature_me
{
    public abstract class Creature
    {
        protected string name;
        public string getName() { return name; }
        protected int power;
        public Creature(string name, int power)
        {
            this.name = name;
            this.power = power;
        }
        public bool Alive()
        {
            return this.power > 0;
        }
        public void ChangePower(int p)
        {
            this.power += p;
        }
        public void Race(ref List<IGround> track)
        {
            for (int j = 0; Alive() && j < track.Count; ++j)
            {
                track[j] = ChangeGround(track[j]);
            }
        }
        public abstract IGround ChangeGround(IGround g);

    }

    public class Greenfinch : Creature
    {
        public Greenfinch(string n, int p) : base(n, p) { }
        public override IGround ChangeGround(IGround g)
        {
           return g.ChangeG(this);
        }
    }
    public class Squelchy : Creature
    {
        public Squelchy(string n, int p) : base(n, p) { }
        public override IGround ChangeGround(IGround g)
        {
            return g.ChangeS(this);
        }
    }
    public class Dune : Creature
    {
        public Dune(string n, int p) : base(n, p) { }
        public override IGround ChangeGround(IGround g)
        {
            return g.ChangeD(this);
        }
    }
}
