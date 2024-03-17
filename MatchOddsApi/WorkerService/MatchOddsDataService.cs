using Microsoft.AspNetCore.Http.HttpResults;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shared.Messages;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatchOddsApi.WorkerService
{

    public class MatchOddsDataService
    {
        public async Task<List<MatchOddsEventMessage>> GetMatchOdds()
        {
            List<MatchOddsEventMessage> MatchOddsEventmessage = new();
            //ChromeDriver'ı başlat
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Arka planda çalışması için argüman ekle
            using (IWebDriver driver = new ChromeDriver(options))
            {

                //Web sayfasını yükle
                driver.Navigate().GoToUrl("https://www.misli.com/iddaa/futbol");

                //Dinamik olarak oluşturulan içeriği almak için bir bekleme yapın
                System.Threading.Thread.Sleep(10000); // Örnek olarak 10 saniye bekleyin

                //Sıcaklık ve hava durumu öğelerini al
                IReadOnlyList<IWebElement> odds = driver.FindElements(By.ClassName("bulletinItemRow"));

                foreach (var element in odds)
                {
                    string oddText = element.Text.Trim();
                    MatchOddsEventmessage.Add(new MatchOddsEventMessage() { Datas = oddText});

                }
                //ChromeDriver'ı kapat
                driver.Quit();
                return MatchOddsEventmessage;
                
            }
        }
    }
}
