using Shane.Church.Basecamp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Shane.Church.Basecamp.Tests
{
	
	
	/// <summary>
	///This is a test class for PeopleTest and is intended
	///to contain all PeopleTest Unit Tests
	///</summary>
	[TestClass()]
	public class PeopleTest
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
		///A test for GetMe
		///</summary>
		[TestMethod()]
		public void GetMeTest()
		{
			string BasecampUrl = "effectiveui";
			string APIKey = "7f9ef8e8113f8a21b6197f9431cf619698411f9d";
			People target = new People(BasecampUrl, APIKey);
			Person actual;
			actual = target.GetMe();
			Assert.AreEqual("Shane", actual.FirstName);
			Assert.AreEqual("Church", actual.LastName);
		}

		/// <summary>
		///A test for GetPeople
		///</summary>
		[TestMethod()]
		public void GetPeopleTest()
		{
			string BasecampUrl = "effectiveui";
			string APIKey = "7f9ef8e8113f8a21b6197f9431cf619698411f9d";
			People target = new People(BasecampUrl, APIKey); 
			List<Person> expected = null;
			List<Person> actual;
			actual = target.GetPeople();
		}

		/// <summary>
		///A test for GetPeopleForCompany
		///</summary>
		[TestMethod()]
		public void GetPeopleForCompanyTest()
		{
			string BasecampUrl = "effectiveui";
			string APIKey = "7f9ef8e8113f8a21b6197f9431cf619698411f9d";
			People target = new People(BasecampUrl, APIKey);
			int CompanyId = 182845;
			List<Person> expected = null; // TODO: Initialize to an appropriate value
			List<Person> actual;
			actual = target.GetPeopleForCompany(CompanyId);
		}
	}
}
