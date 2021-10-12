using Autokool.Aids;
using System.Diagnostics;

namespace Autokool.Tests
{
    public abstract class TestAids : TestAssertions
    {
        protected object objUnderTests;
        protected void isProperty<T>(bool isNullable = true)
        {
            var type = objUnderTests?.GetType();
            var name = getPropertyNameAfter(nameof(isProperty));
            var propertyInfo = type?.GetProperty(name);
            isNotNull(propertyInfo);
            isTrue(propertyInfo.CanRead);
            isTrue(propertyInfo.CanWrite);
            var expectedValue = GetRandom.ValueOf(typeof(T));
            propertyInfo.SetValue(objUnderTests, expectedValue);
            var actual = propertyInfo.GetValue(objUnderTests);
            areEqual(expectedValue, actual);
            if (!isNullable) return;
            propertyInfo.SetValue(objUnderTests, null);
            isNull(propertyInfo.GetValue(objUnderTests));
        }

        private string getPropertyNameAfter(string methodName)
        {
            var stack = new StackTrace();
            var i = getFrameIndex(stack, methodName);
            return nextMethodName(stack, i);
        }

        private string nextMethodName(StackTrace stack, int frameIndex)
        {
            var i = frameIndex;
            for (i += 1; i < stack.FrameCount - 1; i++)
            {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;
                if (n is "MoveNext" or "Start") continue;
                return n?.Replace("Test", string.Empty);
            }
            return string.Empty;
        }

        private int getFrameIndex(StackTrace stack, string methodName)
        {
            int index = -1;
            for (var i = 0; i < stack.FrameCount - 1; i++)
            {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;
                if (n == methodName) index = i;
                else if (index > -1 && n != methodName) break;
            }
            return index;
        }
    }
}
