using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages_Tests
{
    public class HomePageTests : BaseTests
    {
        [Test]
        public void Correct_HomePage_Content()
        {
            var homepage = new HomePage(driver);
            homepage.OpenPage();

            Assert.That(homepage.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(homepage.GetPageHeading(), Is.EqualTo("Students Registry"));
            Assert.That(homepage.GetStudentsCount(), Is.GreaterThan(3));
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var homepage = new HomePage(driver);
            homepage.OpenPage();

            Assert.That(homepage.IsOpen(), Is.True);

            homepage.OpenPage();
            homepage.ViewStudentsLinkElement.Click();
            Assert.That(new ViewStudents(driver).IsOpen(), Is.True);

            homepage.OpenPage();
            homepage.AddtudentLinkElement.Click();
            Assert.That(new AddStudent(driver).IsOpen(), Is.True);
        }
    }
}
