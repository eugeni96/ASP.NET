using Ninject;

namespace LessonProject.Model
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public LessonProejctDbDataContext Db { get; set; }

    }
}
