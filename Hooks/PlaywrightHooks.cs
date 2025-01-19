using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EaAppAutomationTesting.Drivers;
using TechTalk.SpecFlow;

namespace EaAppAutomationTesting.Hooks
{


    [Binding]
    public class PlaywrightHooks
    {
        public static PlaywrightDriver Driver { get; private set; } // Singleton

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

