using Ninject;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        public static IKernel AppKernel;

        static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new WeaponNinjectModule());

            var warrior = AppKernel.Get<Warrior>();

            warrior.Kill();

            var otherWarrior = new OtherWarrior();

            otherWarrior.Kill();

            Console.ReadLine();
        }
    }
}
