using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;

        public AoNavegarParaHomeMobile()
        {
        }

        [Fact]
        public void DadaLargura992DeveMostrarMenuMobile()
        {
            //arange
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 992;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);
            var homePO = new HomeNaoLogadaPO(driver);

            //act
            homePO.Visitar();

            //assert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            //arange
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 993;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);
            var homePO = new HomeNaoLogadaPO(driver);

            //act
            homePO.Visitar();

            //assert
            Assert.False(homePO.Menu.MenuMobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
