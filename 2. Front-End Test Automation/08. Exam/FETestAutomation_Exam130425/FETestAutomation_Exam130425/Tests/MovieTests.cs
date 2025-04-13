using FETestAutomation_Exam130425.Pages;
using OpenQA.Selenium.BiDi.Modules.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Tests
{
    public class MovieTests : BaseTest
    {
        public string lastCreatedMovieTitle;
        public string lastCreatedMovieDescription;
        
        [Test, Order(1)]
        public void AddMovieWithoutTitleTest()
        {
            addMoviePage.OpenPage();

            addMoviePage.AddMovie("", "");

            addMoviePage.AssertTitleErrorMessages();
        }

        [Test, Order(2)]
        public void AddMovieWithoutDescriptionTest()
        {
            lastCreatedMovieTitle = "Title " + GenerateRandomString(5);

            addMoviePage.OpenPage();

            addMoviePage.AddMovie(lastCreatedMovieTitle, "");

            addMoviePage.AssertDescriptionErrorMessages();
        }

        [Test, Order(3)]
        public void AddMovieWithRandomTitleTest()
        {

            lastCreatedMovieTitle = "Title " + GenerateRandomString(5);
            lastCreatedMovieDescription = "Description " + GenerateRandomString(5);

            addMoviePage.OpenPage();

            addMoviePage.AddMovie(lastCreatedMovieTitle, lastCreatedMovieDescription);

            Assert.That(driver.Url, Is.EqualTo(allMoviesPage.Url), "Url is not correct");

            Assert.That(allMoviesPage.TitleLastMovie.Text.Trim(), Is.EqualTo(lastCreatedMovieTitle).IgnoreCase, "Title not matched");
        }

        [Test, Order(4)]
        public void EditLastMovieTest()
        {
            allMoviesPage.OpenPage();

            allMoviesPage.EditeButtonLastMovie.Click();

            string updatedName = "Updated Title: " + lastCreatedMovieTitle;

            editMoviePage.TitleField.Clear();
            editMoviePage.TitleField.SendKeys(updatedName);
            editMoviePage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(allMoviesPage.Url), "Not correctly redirected");

            Assert.That(allMoviesPage.TitleLastMovie.Text.Trim(), Is.EqualTo(updatedName).IgnoreCase, "Title do not match");
        }

        [Test, Order(5)]
        public void MarkLastAddedMovieAsWatchedTest()
        {
            allMoviesPage.OpenPage();

            allMoviesPage.MarkAsWatchedButtonLastMovie.Click();

            watchedMoviesPage.OpenPage();

            Assert.That(driver.Url, Is.EqualTo(watchedMoviesPage.Url), "Not correctly redirected");

            string updatedName = "Updated Title: " + lastCreatedMovieTitle;

            Assert.That(watchedMoviesPage.TitleLastMovie.Text.Trim(), Is.EqualTo(updatedName).IgnoreCase, "Title do not match");
        }

        [Test, Order(6)]
        public void DeleteLastCreatedRevueTitleTest()
        {
            allMoviesPage.OpenPage();

            allMoviesPage.DeleteButtonLastMovie.Click();

            deleteMoviePage.YesButton.Click();

            allMoviesPage.OpenPage();

            bool isLastMovieDeleted = allMoviesPage.AllMoviesList.All(movie => movie.Text.Contains(lastCreatedMovieTitle));

            Assert.IsFalse(isLastMovieDeleted, "The movie was not deleted");
        }   
    }
}
