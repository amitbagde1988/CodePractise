using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.ProdHouse;

namespace Test.ProdHouse.UnitTest
{
    [TestClass]
    public class MovieTestCases
    {
        [TestMethod]
        public void Movie_AddMovie()
        {
            try
            {
                Business.MovieInfo.Add(new Models.Movie
                {
                    Name = "Unit test - Movie",
                    Budget = 100000,
                    Description = "",
                    Format = "",
                    Language = "Hindi",
                    MovieLength = "01:00",
                    Type = "HD",
                    Genre = new System.Collections.Generic.List<string> { "Action" }
                });
                Assert.IsTrue(true);
            }
            catch (Exception exc)
            {
                Console.Out.WriteLine(exc);
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void Movie_GetAllMovies()
        {
            try
            {
                Business.MovieInfo.GetAll();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void Movie_GetOneMovie()
        {
            try
            {
                Business.MovieInfo.GetOne("");
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void Movie_PrintMovies()
        {
            try
            {
                Business.MovieInfo.Print(null);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
