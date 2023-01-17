using NLIMS_Automation_Testing.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLIMS_Automation_Testing.Pages;
using NUnit.Framework;

namespace NLIMS_Automation_Testing.Tests
{
    class ProjectTemplatesTestCases : BaseTest
    {
        ProjectTemplatesPage PT;
        [Test]
        public void ProjectSearch()
        {
 
            PT = new ProjectTemplatesPage(tst);
            PT.ClickOnSettings();
            PT.ClickOnSearchbar();
           // Assert.AreEqual(pageName, "Project Templates");
            PT.SearchProject();
        }

        [Test]
         public void EditProject()
        {
            string projectName;
            string MS = "MS Tester";
            string inlet = "Inlet Tester";
            dynamic vol = 5;
            dynamic process = 3;

            PT = new ProjectTemplatesPage(tst);
            PT.ClickOnSettings();
            int count = PT.GetRowsCount();
            Console.WriteLine("rows count is" + count); //To make sure that all rows in the page are counted, not only the displayed ones without scrolling.
            PT.EditTemplate(3);
            PT.InsertMS_File(MS);
            PT.InsertInlet_File(inlet);
            PT.InsertInjection_Volume(vol);
            PT.InsertProcess_Parameters(process);
            PT.ClickOnUpdate();
            projectName = PT.getProjectName(3);
            Assert.AreEqual(MS, PT.getMSfile(3));
            Assert.AreEqual(inlet, PT.getInlet(3));
            Assert.AreEqual(vol.ToString(), PT.getVolume(3));
            Assert.AreEqual(process.ToString(), PT.getProcess(3));
            Assert.AreEqual(projectName + " " + "template updated successfully.", PT.GetToasterMessage());

        }
      
    }
}
