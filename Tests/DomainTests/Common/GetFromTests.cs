using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class GetFromTests : SealedTests<object>
    {
        protected override object createObject()
        {
            return new GetFrom<ICourseRepo, Course>();
        }
    }
}
