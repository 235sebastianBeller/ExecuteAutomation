using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using EaAppAutomationTesting.Drivers;
using EaAppAutomationTesting.Models;
using TechTalk.SpecFlow;

namespace EaAppAutomationTesting.Hooks
{


    [Binding]
    public class PlaywrightHooks
    {
        public static PlaywrightDriver Driver { get; private set; } // Singleton
        public static List<Employee> Employees { get; private set; }


        public List<Employee> ReadEmployeesFromCsv(string filePath)
        {
            var employees = new List<Employee>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read(); // Lee la fila actual
                csv.ReadHeader(); // Lee los encabezados
                while (csv.Read())
                {
                    try
                    {
                        var employee =  csv.GetRecord<Employee>();
                        employees.Add(employee);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Excepción: {ex.Message}");
                    }
                }
            }

            return employees;
        }

        [BeforeScenario("@Employees")]
        public void SetupForEmployees()
        {
            Employees = ReadEmployeesFromCsv("../../../Data/employees.csv");
        }


            [BeforeScenario]
        public void Setup()
        {
            Driver = new PlaywrightDriver(); // inicializamos el navegador antes de cada escenario
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Dispose(); // Cierra el navegador y limpia los recursos despues del escenario
        }
    }
}

