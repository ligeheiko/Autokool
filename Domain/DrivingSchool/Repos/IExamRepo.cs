using Autokool.Domain.DrivingSchool.Model;
using System.Threading.Tasks;

namespace Autokool.Domain.DrivingSchool.Repos
{
    public interface IExamRepo : IRepo<Exam>
    {
        public Task Added(Exam e);
    }
}
