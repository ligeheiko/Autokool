using Autokool.Aids;
using Autokool.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BaseTests : TestAids
    {

        [TestCleanup]
        public virtual void TestCleanup()
        {
            objUnderTests = null;
            type = null;
        }
        [TestMethod]
        public virtual void IsSpecifiedClassTested()
        {
            if (type == null) notTested(notSpecifiedMsg);
            var testClassName = GetType().Name;
            isTrue(testClassName.StartsWith(testableClassName));
        }

        protected Type getTestableClassType()
        {
            var testClassName = GetType().FullName;
            var testableClassName = testClassName.Replace("Tests", string.Empty);
            testableClassName = testableClassName.Replace("..", ".");
            var solutionName = testableClassName.GetHead();
            var projectName = testableClassName.GetTail().GetHead();
            var l = GetSolution.TypesForAssembly($"{solutionName}.{projectName}");
            var list = l?.Where(x => x.FullName == testableClassName)?.ToList();
            if (list?.Count == 0)
            {
                testableClassName += "`";
                list = l?.Where(x => x.FullName.StartsWith(testableClassName))?.ToList();
            }
            return (list?.Count() > 0)? list[0] : null;
        }

        [TestMethod]
        public virtual void IsTested()
        {
            if (type == null) notTested(notSpecifiedMsg);
            members = publicDeclaredMembers;
            removeTestedMethods();
            if (!isTested) notTested(notTestedMsg, members[0]);
        }
        private const string notSpecifiedMsg = "Class is not specified";
        private const string notTestedMsg = "<{0}> is not tested";
        private List<string> members { get; set; }
        private bool isTested => members.Count == 0;
        private string testableClassName
        {
            get
            {
                var s = type.Name;
                var index = s.IndexOf("`", StringComparison.Ordinal);
                if (index > -1) s = s.Substring(0, index);
                return s;
            }
        }
        private List<string> publicDeclaredMembers
                => GetClass.Members(type, PublicFlagsFor.Declared).Select(e => e.Name).ToList();

        private void removeTestedMethods()
        {
            var tests = GetType().GetMembers().Select(e => e.Name).ToList();
            for (var i = members.Count; i > 0; i--)
            {
                var m = members[i - 1] + "Test";
                var isTested = tests.Find(o => o == m);
                if (string.IsNullOrEmpty(isTested)) continue;
                members.RemoveAt(i - 1);
            }
        }
    }
}