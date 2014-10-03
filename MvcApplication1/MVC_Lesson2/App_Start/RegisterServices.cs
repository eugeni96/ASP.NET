namespace MVC_Lesson2.App_Start
{
  public interface IWeapon
    {
        string Kill();
    }
    public class Bazuka : IWeapon
    {
        public string Kill()
        {
            return "BIG BADABUM!";
        }
    }
}