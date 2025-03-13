using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages_Tests
{
    public class ViewStudentsPageTests : BaseTests
    {

        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var viewPage = new ViewStudents(driver);
            viewPage.OpenPage();

            Assert.That(viewPage.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(viewPage.GetPageHeading(), Is.EqualTo("Registered Students"));

            var students = viewPage.GetRegisteredStudents();

            foreach(var student in students)
            {
                Assert.That(student.IndexOf("(") > 0, Is.True);
                Assert.That(student.LastIndexOf(")") == student.Length - 1, Is.True);
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var viewPage = new ViewStudents(driver);

            viewPage.OpenPage();
            viewPage.HomeLinkElement.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            viewPage.OpenPage();
            viewPage.ViewStudentsLinkElement.Click();
            Assert.That(viewPage.IsOpen(), Is.True);

            viewPage.OpenPage();
            viewPage.AddtudentLinkElement.Click();
            Assert.That(new AddStudent(driver).IsOpen, Is.True);
        }
    }
}
