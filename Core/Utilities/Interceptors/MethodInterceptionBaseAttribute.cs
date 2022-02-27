using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    //birden fazla kullanma sebebi örneğin hem database hemde bir dosyaya loglasın istenirse.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //Autofac Interceptor özelliğinden geliyor IInterceptor
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //öncelikli olarak hangi attribute validation ,loglama vb. gibi

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
