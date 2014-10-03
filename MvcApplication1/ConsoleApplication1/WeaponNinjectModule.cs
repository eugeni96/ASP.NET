using Ninject.Modules;

namespace ConsoleApplication1
{
    public class WeaponNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWeapon>().To<Sword>();
        }
    }
}
