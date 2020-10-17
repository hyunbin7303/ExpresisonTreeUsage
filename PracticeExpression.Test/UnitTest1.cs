using NUnit.Framework;
using System;

namespace PracticeExpression.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Or_Fails()
        {
            Assert.Throws<ArgumentException>(ExprFundamental.Testing2);

        }
    }
}