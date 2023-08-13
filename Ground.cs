using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creature_me
{
    public interface IGround
    {
        IGround ChangeG(Greenfinch g);
        IGround ChangeD(Dune g);
        IGround ChangeS(Squelchy g);

    }
    public class Sand : IGround
    {
        private static Sand instance;
        private Sand() { }
        public static Sand Instance()
        {
            if(instance == null)
                instance = new Sand();
            return instance;
        }
        public IGround ChangeG(Greenfinch g)
        {
            g.ChangePower(-2);
            return this;
        }
        public IGround ChangeD(Dune g)
        {
            g.ChangePower(3);
            return this;
        }
        public IGround ChangeS(Squelchy g)
        {
            g.ChangePower(-5);
            return this;
        }

    }
    public class Grass : IGround
    {
        private static Grass instance;
        private Grass() { }
        public static Grass Instance()
        {
            if (instance == null)
                instance = new Grass();
            return instance;
        }
        public IGround ChangeG(Greenfinch g)
        {
            g.ChangePower(1);
            return this;
        }
        public IGround ChangeD(Dune g)
        {
            g.ChangePower(-2);
            return Sand.Instance();
        }
        public IGround ChangeS(Squelchy g)
        {
            g.ChangePower(-2);
            return Marsh.Instance();
        }

    }
    public class Marsh : IGround
    {
        private static Marsh instance;
        private Marsh() { }
        public static Marsh Instance()
        {
            if (instance == null)
                instance = new Marsh();
            return instance;
        }
        public IGround ChangeG(Greenfinch g)
        {
            g.ChangePower(1);
            return Sand.Instance(); ;
        }
        public IGround ChangeD(Dune g)
        {
            g.ChangePower(-4);
            return Grass.Instance();
        }
        public IGround ChangeS(Squelchy g)
        {
            g.ChangePower(6);
            return this;
        }

    }
}
