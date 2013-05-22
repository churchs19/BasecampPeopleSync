using Shane.Church.Basecamp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Shane.Church.Basecamp.Tests
{
    
    
    /// <summary>
    ///This is a test class for AccountTest and is intended
    ///to contain all AccountTest Unit Tests
    ///</summary>
	[TestClass()]
	public class AccountTest
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


		/// <summary>
		///A test for Account Constructor
		///</summary>
		[TestMethod()]
		public void AccountConstructorTest()
		{
			string BasecampUrl = "effectiveui";
			string APIKey = "7f9ef8e8113f8a21b6197f9431cf619698411f9d"; 
			Account target = new Account(BasecampUrl, APIKey);
			Assert.AreEqual("effectiveui", target.Name.ToLower());
			Assert.AreEqual(84930, target.Id);
			Assert.AreEqual("elite suite", target.Subscription.Name.ToLower());
		}
	}
}
