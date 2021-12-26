using Autokool.Domain.DrivingSchool.Model;
using System.Threading.Tasks;

namespace Autokool.Domain.DrivingSchool.Repos
{
    public interface ICourseRepo : IRepo<Course>
    {
        Task Added(Course c);
    }
}
