using System;

namespace NUnit.Framework.Tests
{
    [TestFixture]
    public class GreaterEqualFixture
    {
        private readonly int i1 = 5;
        private readonly int i2 = 4;
        private readonly uint u1 = 12345879;
        private readonly uint u2 = 12345678;
        private readonly float f1 = 3.543F;
        private readonly float f2 = 2.543F;
        private readonly decimal de1 = 53.4M;
        private readonly decimal de2 = 33.4M;
        private readonly double d1 = 4.85948654;
        private readonly double d2 = 1.0;
        private readonly System.Enum e1 = System.Data.CommandType.TableDirect;
        private readonly System.Enum e2 = System.Data.CommandType.StoredProcedure;

        [Test]
        public void GreaterEqual()
        {
            Assert.GreaterEqual(i1, i1);
            Assert.GreaterEqual(u1, u1);
            Assert.GreaterEqual(d1, d1, "double");
            Assert.GreaterEqual(de1, de1, "{0}", "decimal");
            Assert.GreaterEqual(f1, f1, "float");

            
            Assert.GreaterEqual(i1, i2);
            Assert.GreaterEqual(u1, u2);
            Assert.GreaterEqual(d1, d2, "double");
            Assert.GreaterEqual(de1, de2, "{0}", "decimal");
            Assert.GreaterEqual(f1, f2, "float");
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void NotGreaterEqual()
        {
            Assert.GreaterEqual(i2, i1);
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void NotGreaterEqualIComparable()
        {
            Assert.GreaterEqual(e2, e1);
        }

        [Test]
        public void FailureMessage()
        {
            string msg = null;

            try
            {
                Assert.GreaterEqual(7, 99);
            }
            catch (AssertionException ex)
            {
                msg = ex.Message;
            }

            StringAssert.Contains("expected: Value greater than or equal to 99", msg);
            StringAssert.Contains("but was: 7", msg);
        }
    }
}

