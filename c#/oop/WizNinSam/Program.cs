using System;
using WizNinSam.Models;

namespace WizNinSam
{
    class Program
    {
        static void Main(string[] args)
        {
            Human john = new Human ("john");
            Wizard jane = new Wizard("jane");
            Ninja edwin = new Ninja("edwin");
            Samurai luna = new Samurai("luna");

            jane.Attack(john);
            jane.Heal(john);
            edwin.Attack(jane);
            edwin.Steal(john);
            luna.Attack(edwin);
            luna.Attack(jane);
            luna.Meditate();
        }
    }
}
