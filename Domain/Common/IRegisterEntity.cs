﻿
namespace Autokool.Domain.Common
{
    public interface IRegisterEntity : IUniqueEntity
    {
        public bool IsRegisteredCourse { get; }
        public string UserId { get; }
        public string UserName { get; }
    }
    public interface IRegisterEntity<out TData> : IRegisterEntity, IUniqueEntity<TData> { }
}