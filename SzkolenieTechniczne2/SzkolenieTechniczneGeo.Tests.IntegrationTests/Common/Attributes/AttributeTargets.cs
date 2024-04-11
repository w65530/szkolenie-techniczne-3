using System;
using SzkolenieTechniczneGeo.Tests.IntegrationTests.Common.Enums;

namespace SzkolenieTechniczneGeo.Tests.IntegrationTests.Common.Attributes
{
    public class TestTargetAttribute : Attribute
    {
        public TestTargetAttribute(TestTargetType testTargetType, string targetName)
        {
            TestTargetType = testTargetType;
            TargetName = targetName;
        }

        public TestTargetType TestTargetType { get; }

        public string TargetName { get; }
    }
}
