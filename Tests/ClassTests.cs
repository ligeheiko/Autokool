using Autokool.Aids;
using Tests;

namespace Autokool.Tests
{
    public abstract class ClassTests<TClass, TBaseClass> :
        BaseClassTests<TClass, TBaseClass> where TClass : class
    {
        protected override TClass createObject()
        {
            return GetRandom.ObjectOf<TClass>();
        }
    }
}