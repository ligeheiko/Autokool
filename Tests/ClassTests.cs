using Autokool.Aids;
using Tests;

namespace Autokool.Tests
{
    public abstract class ClassTests<TBaseClass> :
        BaseClassTests<TBaseClass>
    {
        protected override object createObject() => GetRandom.ObjectOf(type);
    }
}