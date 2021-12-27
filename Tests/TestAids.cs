using Autokool.Aids;
using Autokool.Aids.Reflection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Autokool.Tests
{
    public abstract class TestAids : TestAssertions
    {
        protected object objUnderTests;
        protected Type type;
        private void testProperty<T>(string propertyName, bool isNullable = true)
        {
            var n = propertyName;
            var pi = getPropertyInfo(n);
            isTrue(pi.CanRead, $"The property {n} does not have a getter");
            isTrue(pi.CanWrite, $"The property {n} does not have a setter");
            var expectedValue = GetRandom.ValueOf(typeof(T));
            pi.SetValue(objUnderTests, expectedValue);
            var actual = pi.GetValue(objUnderTests);
            areEqual(expectedValue, actual,
                $"For the property {n}.");
            if (!isNullable) return;
            pi.SetValue(objUnderTests, null);
            isNull(pi.GetValue(objUnderTests), $"Can not set null for the property {n}.");
        }

        protected void isProperty<T>(bool isNullable = true)
        {
            var n = getPropertyNameAfter(nameof(isProperty));
            var pi = getPropertyInfo(n);
            isTrue(pi.CanRead, $"The property {n} does not have a getter");
            isTrue(pi.CanWrite, $"The property {n} does not have a setter");
            var expectedValue = GetRandom.ValueOf(typeof(T));
            pi.SetValue(objUnderTests, expectedValue);
            var actual = pi.GetValue(objUnderTests);
            areEqual(expectedValue, actual,
                $"For the property {n}.");
            if (!isNullable) return;
            pi.SetValue(objUnderTests, null);
            isNull(pi.GetValue(objUnderTests), $"Can not set null for the property {n}.");
        }
        protected void isProperty<T>(T expectedValue)
        {
            var n = getPropertyNameAfter(nameof(isProperty));
            var pi = getPropertyInfo(n);
            isTrue(pi.CanRead, $"The property {n} does not have a getter");
            var actual = pi.GetValue(objUnderTests);
            areEqual(expectedValue, actual,
                $"For the property {n}.");
        }

        private PropertyInfo getPropertyInfo(string propertyName)
        {
            var t = objUnderTests?.GetType() ?? type;
            var pi = t?.GetProperty(propertyName);
            if (pi == null)
            {
                pi = type?.GetProperty(propertyName);
            }
            isNotNull(pi,$"The class {t} does not have a property {propertyName}");
            return pi;
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
        public TClass random<TClass>() => GetRandom.ObjectOf<TClass>();
        protected void isDisplayProperty<T>(string displayName, bool isNullable = true)
        {
            var n = getPropertyNameAfter(nameof(isDisplayProperty));
            testProperty<T>(n, isNullable);
            hasDisplayName(n, displayName);
        }
        protected void isRequiredProperty<T>(string displayName, bool isNullable = true)
        {
            var n = getPropertyNameAfter(nameof(isRequiredProperty));
            testProperty<T>(n, isNullable);
            hasRequiredAttribute(n);
        }

        private void hasRequiredAttribute(string n)
        {
            var pi = objUnderTests.GetType().GetProperty(n);
            var list = pi?.GetCustomAttributes(typeof(RequiredAttribute), true);
            var a = list?.Cast<RequiredAttribute>().Single();
            if (a is null) isFalse(true, $"Property \"{n}\" is not required");
        }

        private void hasDateAttribute(string n)
        {
            var pi = objUnderTests.GetType().GetProperty(n);
            var list = pi?.GetCustomAttributes(typeof(DataTypeAttribute), true);
            var a = list?.Cast<DataTypeAttribute>().Single();
            var actual = a?.DataType;
            var expected = DataType.Date;
            areEqual(expected, actual, $"Property \"{n}\" has not DataType(DataType.Date) attribute");
        }

        protected void isDateProperty<T>(string displayName, bool isNullable = true)
        {
            var n = getPropertyNameAfter(nameof(isDateProperty));
            testProperty<T>(n, isNullable);
            hasDateAttribute(n);
        }
        protected void isAbstractMethod<T>(string methodName)
        {
            var mi = typeof(T).GetMethod(methodName);
            var actual = mi.IsAbstract;
            isTrue(actual, $"Method \"{methodName}\" is not abstract.");
        }

        private void hasDisplayName(string n, string displayName)
        {
            var actual = GetMember.DisplayName(n, objUnderTests.GetType());
            areEqual(displayName, actual);
        }
        protected void isBooleanProperty(bool expectedValue)
        {
            var n = getPropertyNameAfter(nameof(isBooleanProperty));
            var pi = getPropertyInfo(n);
            isTrue(pi.CanRead, $"The property {n} does not have a getter");
            var actual = pi.GetValue(objUnderTests);
            areEqual(expectedValue, actual,
                $"For the property {n}.");
        }
    }
}
