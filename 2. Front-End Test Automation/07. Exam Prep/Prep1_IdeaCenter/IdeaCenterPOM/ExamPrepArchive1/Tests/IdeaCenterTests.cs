using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamPrepArchive1.Tests
{
    public class IdeaCenterTests : BaseTest
    {

        public string lastCreatedIdeaTitle;
        public string lastCreatedIdeaDescription;

        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea("", "", "");

            createIdeaPage.AssertErrorMessages();
        }

        [Test, Order(2)]
        public void CreateIdeaWithValidDataTest()
        {

            lastCreatedIdeaTitle = "Idea " + GenerateRandomString(5);
            lastCreatedIdeaDescription = "Description " + GenerateRandomString(5);

            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Url is not correct");

            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Descriptions not matched");

        }

        [Test, Order(3)]
        public void ViewLastCreatedIdeaTest()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle), "Title is not matching");

            Assert.That(ideasReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Description is not matching");
        }

        [Test, Order(4)]
        public void EditLastCreatedIdeaTitleTest()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.EditButtonLastIdea.Click();

            string updatedTitle = "Changed Title: " + lastCreatedIdeaTitle;

            ideasEditPage.TitleField.Clear();
            ideasEditPage.TitleField.SendKeys(updatedTitle);
            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Not correctly redirected");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(updatedTitle), "Title do not match");
        }

        [Test, Order(5)]
        public void EditLastCreatedIdeaDescriptionTest()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.EditButtonLastIdea.Click();

            string updatedDescription = "Changed Description: " + lastCreatedIdeaDescription;

            ideasEditPage.DescriptionField.Clear();
            ideasEditPage.DescriptionField.SendKeys(updatedDescription);
            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Not correctly redirected");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(updatedDescription), "Description do not match");
        }

        [Test, Order(6)]
        public void DeleteLastIdeanTest()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.DeleteButtonLastIdea.Click();

            bool isIdeaDeleted = myIdeasPage.IdeasCards.All(card => card.Text.Contains(lastCreatedIdeaDescription));

            Assert.IsFalse(isIdeaDeleted, "The idea was not deleted");
        }
    }
}

