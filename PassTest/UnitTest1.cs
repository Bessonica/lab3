using IIG.PasswordHashingUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;



namespace PassTest
{
    [TestClass]
    public class UnitTest1
    {

        //_____________________________ No Pass _______________________
        [TestMethod]
        public void Route_1_6_7()
        {
            String result = PasswordHasher.GetHash(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_5_6_7()
        {
            String result = PasswordHasher.GetHash(null, null, 3);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_2_4_5_6_7()
        {
            String result = PasswordHasher.GetHash(null, "one", 6);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_2_3_4_6_7()
        {
            //3 - salt OverflowException
            String result = PasswordHasher.GetHash(null, "oneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneone");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_2_4_6_7()
        {
            //3 нет. потому что нет overflowEsception
            String result = PasswordHasher.GetHash(null, "one");
            Assert.IsNull(result);
        }

        //___________________________________ Pass exist _________________________
        public void Route_1_6_8_10()
        {
            String result = PasswordHasher.GetHash("one");
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void Route_1_2_4_6_8_10()
        {
            String result = PasswordHasher.GetHash("oneTwo", "oneTwo");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Route_1_2_4_5_6_8_10()
        {
            String result = PasswordHasher.GetHash("one", "one", 3);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_5_6_8_10()
        {
            String result = PasswordHasher.GetHash("one", null, 6);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Route_1_2_3_4_6_8_10()
        {
            String result = PasswordHasher.GetHash("one", "oneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneone");
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_2_3_4_5_6_7_8_10()
        {
            String result = PasswordHasher.GetHash("one", "oneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneone", 6);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_2_4_6_8_9_10()
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!
            //
            String result = PasswordHasher.GetHash("oneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneoneone", "one");
            Assert.IsNotNull(result);
        }




    }
}
