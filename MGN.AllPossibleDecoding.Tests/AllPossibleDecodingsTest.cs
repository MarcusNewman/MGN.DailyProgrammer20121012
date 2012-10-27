using MGN.AllPossibleDecodings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MGN.AllPossibleDecodings.Tests
{
    /// <summary>
    ///This is a test class for AllPossibleDecodings and is intended
    ///to contain all AllPossibleDecodings Unit Tests
    ///</summary>
    [TestClass()]
    public class AllPossibleDecodingsTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private static String CodeAssemblyName = "MGN.AllPossibleDecodings";
        private static String AllPossibleDecodingsName = "AllPossibleDecodings";
        private static String GetAllPossibleDecodingsMethodName = "GetAllPossibleDecodings";

        /// <summary>
        /// A test for the existence of the MGN.AllPossibleDecodings assembly.
        /// Assumes a relative path of MGN.AllPossibleDecodings\MGN.AllPossibleDecodings\bin\Debug
        /// </summary>
        [TestMethod]
        public void CodeAssemblyShouldExist()
        {
            var CodeAssembly = GetCodeAssembly();
            Assert.IsNotNull(CodeAssembly, CodeAssemblyName + " assembly should not be null.");
        }

        /// <summary>
        /// Gets the code Assembly
        /// </summary>
        /// <returns>The code Assembly</returns>
        private static Assembly GetCodeAssembly()
        {
            Assembly result = null;
            try
            {
                var relativeAssemblyPath = String.Format("..\\..\\..\\{0}\\bin\\Debug\\{0}.dll", CodeAssemblyName);
                result = Assembly.LoadFrom(relativeAssemblyPath);
            }
            catch (System.IO.FileNotFoundException)
            {
                Assert.Fail(CodeAssemblyName + " assembly was not found.");
            }
            return result;
        }

        /// <summary>
        /// Test for existence of AllPossibleDecodings.AllPossibleDecodings class
        /// AllPossibleDecodings must be public
        /// </summary>
        [TestMethod]
        public void AssemblyShouldContainGetAllPossibleDecodings()
        {
            var Class1Type = GetAllPossibleDecodingsType();
            Assert.IsNotNull(Class1Type, AllPossibleDecodingsName + " type should not be null.");
        }

        /// <summary>
        /// Test for static method AllPossibleDecodings.GetAllPossibleDecodings should return a string.
        /// </summary>
        [TestMethod]
        public void AllPossibleDecodingsShouldHaveAStaticMethodGetAllPossibleDecodingsThatReturnsAnArrayOfStrings()
        {
            var GetNameMemberInfo = GetAllPossibleDecodingsMethodInfo();
            Assert.IsNotNull(GetNameMemberInfo, AllPossibleDecodingsName + "." + GetAllPossibleDecodingsMethodName + "(String) method should exist.");
            Assert.IsTrue(GetNameMemberInfo.IsStatic, GetAllPossibleDecodingsMethodName + " should be static.");
            Assert.IsTrue(GetNameMemberInfo.ReturnType == typeof(string[]), GetAllPossibleDecodingsMethodName + " should return a string.");
        }

        /// <summary>
        /// Gets the Type of AllPossibleDecodings.
        /// </summary>
        /// <returns>The Type of AllPossibleDecodings</returns>
        private static Type GetAllPossibleDecodingsType()
        {
            Type result = null;
            var ModelAssembly = GetCodeAssembly();
            var AllPossibleDecodingsFullName = CodeAssemblyName + "." + AllPossibleDecodingsName;
            try
            {
                result = ModelAssembly.GetType(AllPossibleDecodingsFullName, true);
            }
            catch (TypeLoadException)
            {
                Assert.Fail(AllPossibleDecodingsName + " type was not found.");
            }
            return result;
        }

        /// <summary>
        /// Gets AllPossibleDecodings.GetAllPossibleDecodings MethodInfo
        /// </summary>
        /// <returns>AllPossibleDecodings.GetAllPossibleDecodings MethodInfo</returns>
        private static MethodInfo GetAllPossibleDecodingsMethodInfo()
        {
            var getAllPossibleDecodingsType = GetAllPossibleDecodingsType();
            return getAllPossibleDecodingsType.GetMethod(GetAllPossibleDecodingsMethodName, new Type[] { typeof(String) });
        }

        //Consider the translation from letters to numbers a -> 1 through z -> 26. Every sequence of letters can be translated into a string of numbers this way,
        //with the numbers being mushed together. For instance hello -> 85121215. Unfortunately the reverse translation is not unique. 85121215 could map to hello,
        //but also to heaubo. Write a program that, given a string of digits, outputs every possible translation back to letters.
        //Sample input:
        //123
        //Sample output:
        //abc
        //aw
        //lc
        [TestMethod]
        public void GetAllPossibleDecodingsShouldreturn_abc_aw_lc_for_123()
        {
            var expected = new string[] { "abc", "aw", "lc" };
            var actual = AllPossibleDecodings.GetAllPossibleDecodings("123");
            CollectionAssert.AreEqual(expected, actual, "GetAllPossibleDecodings should return \"abc\", \"aw\" and \"lc\" for the input string \"123\".");
        }

        [TestMethod]
        public void GetAllPossibleDecodings_85121215_Should_contain_hello()
        {
            var expectedElement = "hello";
            var actual = AllPossibleDecodings.GetAllPossibleDecodings("85121215");
            CollectionAssert.Contains(actual, expectedElement, "GetAllPossibleDecodings(85121215) results should contain \"hello\".");
        }
    }
}
