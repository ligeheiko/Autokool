using Autokool.Domain.DrivingSchool.Model;
using System.Threading.Tasks;

namespace Autokool.Domain.DrivingSchool.Repos
{
    public interface ITeacherRepo : IRepo<Teacher>
    {
        public Task Added(Teacher t);
    }
}
