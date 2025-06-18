using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

public class SeleniumTests : IDisposable
{
    private readonly IWebDriver _driver;

    public SeleniumTests()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless"); // uruchamiaj bez otwierania okna przeglądarki
        _driver = new ChromeDriver(options);
    }

    [Fact]
    public void HomePage_ShouldContainText()
    {
        _driver.Navigate().GoToUrl("http://localhost:5270/");
        
        var header = _driver.FindElement(By.TagName("h1"));
        Assert.Contains("Witaj", header.Text);
    }
    

         public class LoginSeleniumTest : IDisposable
        {
        private readonly IWebDriver _driver;
        private readonly string _appUrl = "http://localhost:5270";
        public LoginSeleniumTest()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); 
            _driver = new ChromeDriver(options);
        } 
        public void Login() 
        {
            _driver.Navigate().GoToUrl(_appUrl + "/Identity/Account/Login");
            
            _driver.FindElement(By.Id("Input_Email")).SendKeys("mikolaj@wp.pl");
            _driver.FindElement(By.Id("Input_Password")).SendKeys("Zaq1xsw@");

           
            _driver.FindElement(By.CssSelector("button[type=submit]")).Click();
            
            System.Threading.Thread.Sleep(1000);
            
            Assert.Contains("Witaj", _driver.PageSource); 
        }


        public class AddBicycle : IDisposable
        {
            private readonly IWebDriver _driver;
            private readonly string _appUrl = "http://localhost:5270";
            public AddBicycle()
            {
                var options = new ChromeOptions();
                options.AddArgument("--headless");
                _driver = new ChromeDriver(options);
            }

            [Fact]
            public void AddBicycleTest()
            {
                _driver.Navigate().GoToUrl(_appUrl + "/Rowery/AddRowery");
                
                _driver.FindElement(By.Name("Producent")).SendKeys("TestBrand");
                _driver.FindElement(By.Name("Nazwa")).SendKeys("SuperBike");
                _driver.FindElement(By.Name("Napęd")).SendKeys("3x7");
                _driver.FindElement(By.Name("Hamulce")).SendKeys("V-Brake");
                _driver.FindElement(By.Name("Amortyzacja")).SendKeys("Przód");
                _driver.FindElement(By.Name("RozmiarRamy")).SendKeys("L");
                _driver.FindElement(By.Name("TypRoweru")).SendKeys("Miejski");
                _driver.FindElement(By.Name("Cena")).SendKeys("50,00");
                _driver.FindElement(By.Name("Status")).SendKeys("Dostępny");
                
                _driver.FindElement(By.CssSelector("input[type=submit],button[type=submit]")).Click();
                
                System.Threading.Thread.Sleep(1000);
                
                Assert.Contains("TestBrand", _driver.PageSource);
                Assert.Contains("SuperBike", _driver.PageSource);
                Assert.Contains("Miejski", _driver.PageSource);
            } 
           
            public class RegisterTest : IDisposable
            {
                private readonly IWebDriver _driver;
                private readonly string _appUrl = "http://localhost:5270";
                public RegisterTest()
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--headless");
                    _driver = new ChromeDriver(options);
                }
                [Fact] 
                public void Register()
                {
                    
                    _driver.Navigate().GoToUrl(_appUrl + "/Identity/Account/Register");

                  
                    var email = $"seleniumtest{Guid.NewGuid():N}@example.com";
                    var haslo = "TestoweHaslo123!";

                   
                    _driver.FindElement(By.Id("Input_Email")).SendKeys(email);
                    _driver.FindElement(By.Id("Input_Password")).SendKeys(haslo);
                    _driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys(haslo);
                    
                    _driver.FindElement(By.CssSelector("button[type=submit]")).Click();
                    
                    System.Threading.Thread.Sleep(1000);
                    
                    Assert.Contains("Witaj na naszej stronie", _driver.PageSource);
                }

                public void Dispose()
                {
                    _driver.Quit();
                    _driver.Dispose();
                }
            }

            public void Dispose()
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }


        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }


    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
    
}