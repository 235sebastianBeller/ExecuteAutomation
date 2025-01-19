using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;


namespace EaAppAutomationTesting.Drivers
{
    public class PlaywrightDriver : IDisposable
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        public IPage Page { get; private set; }

        public PlaywrightDriver()
        {
            InitializeAsync().GetAwaiter().GetResult(); // Creamos la pagina del navegador
        }

        private async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true, // Cambiar a "true" si no se necesita ver el navegador caso contrario false
                SlowMo = 1000 // Delay 
            });

            _context = await _browser.NewContextAsync();
            Page = await _context.NewPageAsync();
        }

        // Cerramos el navegador
        public void Dispose()
        {
            CleanupAsync().GetAwaiter().GetResult();
        }

        private async Task CleanupAsync()
        {
            if (_context != null) await _context.CloseAsync();
            if (_browser != null) await _browser.CloseAsync();
            if (_playwright != null) _playwright.Dispose();
        }
    }

}