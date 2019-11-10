using ControlTrafico.ExternalServices.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitExternalServices
{
    public abstract class BaseTest
    {
        protected abstract IApiService CreateInstance();

        [Test]
        public void Test1()
        {
            IApiService instance = CreateInstance();
            //Do some testing on the instance...
        }
    }
}
