using Shane.Church.Basecamp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shane.Church.Basecamp.Tests
{
	
	
	/// <summary>
	///This is a test class for CompaniesTest and is intended
	///to contain all CompaniesTest Unit Tests
	///</summary>
	[TestClass()]
	public class CompaniesTest
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
		///A test for GetCompanies
		///</summary>
		[TestMethod()]
		public void GetCompaniesTest()
		{
			string BasecampUrl = "effectiveui";
			string APIKey = "7f9ef8e8113f8a21b6197f9431cf619698411f9d";
			Companies target = new Companies(BasecampUrl, APIKey);
			List<Company> actual = target.GetCompanies();
			Assert.AreEqual("effectiveui", actual.First().Name.ToLower());
		}

		/// <summary>
		///A test for GetCompany
		///</summary>
		[TestMethod()]
		public void GetCompanyTest()
		{
			string BasecampUrl = "effectiveui";
			string APIKey = "7f9ef8e8113f8a21b6197f9431cf619698411f9d";
			Companies target = new Companies(BasecampUrl, APIKey);
			int id = 182845;
			Company actual = target.GetCompany(id);
			Assert.AreEqual("effectiveui", actual.Name.ToLower());
		}
	}
}
