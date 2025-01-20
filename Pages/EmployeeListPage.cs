using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EaAppAutomationTesting.Models;
using Microsoft.Playwright;
using NUnit.Framework;
using ServiceStack;
using TechTalk.SpecFlow;

namespace EaAppAutomationTesting.Pages
{
    public class EmployeeListPage
    {
        private IPage page;

        private ILocator employeeListSection => page.Locator("text=Employee List");
        //private ILocator employee => page.Locator("text=Employee List");
        private ILocator employeesTable => page.Locator("table");
        private ILocator searchField => page.Locator("input[name=searchTerm]");
        private ILocator searchButton => page.Locator("text=Search");


        public async  Task clickOnEmployeeListLink()
        {
            await employeeListSection.ClickAsync();
        }

        private async Task getEmployee(ILocator row)
        {
            //await new Employee 
            //{

            //    Name = await row.Locator($"td:nth-child(1)").InnerTextAsync(),
            //    Salary = row.Locator($"td:nth-child(2)").InnerTextAsync().Result.ToInt(),
            //    DurationWorked = row.Locator($"td:nth-child(3)").InnerTextAsync().Result.ToInt(),
            //    Grade = row.Locator($"td:nth-child(4)").InnerTextAsync().Result.ToInt(),
            //    Email = await row.Locator($"td:nth-child(5)").InnerTextAsync()
            //}.InTask(); 

        }

        public async Task verifyEmployeeName(int indexRow,Employee expectedEmployee)
        {

            ILocator row = employeesTable.Locator($"tbody tr:nth-child({indexRow})");
            string Name = await row.Locator($"td:nth-child(1)").InnerTextAsync();
            Assert.AreEqual(expectedEmployee.Name, Name);
        }

        public async Task verifySalary(int indexRow, Employee expectedEmployee)
        {

            ILocator row = employeesTable.Locator($"tbody tr:nth-child({indexRow})");
            int salary = row.Locator($"td:nth-child(2)").InnerTextAsync().Result.ToInt();
            Assert.AreEqual(expectedEmployee.Salary, salary);
        }

        public async Task verifyDurationWorked(int indexRow, Employee expectedEmployee)
        {

            ILocator row = employeesTable.Locator($"tbody tr:nth-child({indexRow})");
            int durationWorked = row.Locator($"td:nth-child(3)").InnerTextAsync().Result.ToInt();
            Assert.AreEqual(expectedEmployee.DurationWorked, durationWorked);
        }


        public async Task verifyGrade(int indexRow, Employee expectedEmployee)
        {

            ILocator row = employeesTable.Locator($"tbody tr:nth-child({indexRow})");
            int grade= row.Locator($"td:nth-child(4)").InnerTextAsync().Result.ToInt();
            Assert.AreEqual(expectedEmployee.Grade, grade);
        }

        public async Task verifyEmail(int indexRow, Employee expectedEmployee)
        {

            ILocator row = employeesTable.Locator($"tbody tr:nth-child({indexRow})");
            string email = await row.Locator($"td:nth-child(5)").InnerTextAsync();
            Assert.AreEqual(expectedEmployee.Email, email);
        }

        public async Task verifyEmployeeList(List<Employee> employees)
        {
            ILocator rows= employeesTable.Locator("tbody tr");
            int count=await rows.CountAsync();
            Console.WriteLine(count);
            Console.WriteLine(employees.Count);
            for (int index=1;index<count;index++)
            {
                ILocator row = employeesTable.Locator($"tbody tr:nth-child({index + 1})");
                await verifyEmployeeName(index + 1, employees[index-1]);
                await verifySalary(index + 1, employees[index - 1]);
                await verifyGrade(index + 1, employees[index - 1]);
                await verifyDurationWorked(index + 1, employees[index - 1]);
                await verifyEmail(index + 1, employees[index - 1]);

            }


        }

        public async Task fillSearchField(string name)
        {
            await searchField.FillAsync(name);
        }
        public async Task clickSearchButton()
        {
            await searchButton.ClickAsync();
        }

        public EmployeeListPage(IPage page)
        {
            this.page = page;
        }
    }
}
