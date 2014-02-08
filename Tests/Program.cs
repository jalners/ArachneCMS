using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        public abstract class Bird
        {
            public virtual double Altitude
            {
                get;
                set;
            }

            public abstract void Fly();
        }

        static void Main(string[] args)
        {
            
        }
    }
}
