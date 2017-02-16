using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MemberAPiTest
{
    class Program
    {

        /* Possible endpoints
         * DEV
         * *******************************************
         * http://stldk01d.centene.com:10001
         * https://stldk01d.centene.com:10002
         * When the application sits behind Axway you must provide /getmember
         * https://dev-int-api-gw.centene.com/getmember aka https://dev-int-api-gw.centene.com
         * 
         * TEST
         * *******************************************
         * http://stldk11t.centene.com:10001
         * https://test-ext-api-gateway.centene.com
         */

        static void Main(string[] args)
        {
            string endpoint;
            string environment;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            while (true)
            {
                Console.WriteLine("What endpoint do you want to test? (d = develop, d2 = develop 2, d3 = develop behind axway, t = test, t2 = Test with Gateway)");

                var line = Console.ReadLine();

                if (line == "d")
                {
                    environment = "Develop";
                    endpoint = "http://stldk01d.centene.com:10001/";
                    break;
                }
                if (line == "d2")
                {
                    environment = "Develop_2";
                    endpoint = "https://stldk01d.centene.com:10002/";
                    break;
                }
                if (line == "d3")
                {
                    environment = "Develop_3";
                    endpoint = "https://dev-int-api-gw.centene.com/getmember/";
                    break;
                }
                if (line == "t")
                {
                    environment = "Test";
                    endpoint = "http://stldk11t.centene.com:10001/";
                    break;
                }
                if (line == "p2")
                {
                    environment = "Test_Gateway";
                    endpoint = "https://test-ext-api-gateway.centene.com/";
                    break;
                }
                Console.WriteLine("Please try again.");
            }

            var testCases = new List<TestCase>
            {
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3314+Joe+Johns+Rd&city=Ocean Park&state=WA&zipcode=98640&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=324+Ferry+St+Apt+1&city=Wenatchee&state=WA&zipcode=98801&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=15807+NE+96th+Way&city=Redmond&state=WA&zipcode=98052&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=9421+112th+Ave+NE&city=Kirkland&state=WA&zipcode=98033&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3068+ROSE+PL&city=YAKIMA&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=503+Ismo+Ct&city=Grandview&state=WA&zipcode=98930&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3710+A+St+SE+Trlr+36&city=Auburn&state=WA&zipcode=98002&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=719+E+1st+Ave&city=Toppenish&state=WA&zipcode=98948&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2218+Davison+Ave&city=Richland&state=WA&zipcode=99354&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3710+A+St+SE+Trlr+36&city=Auburn&state=WA&zipcode=98002&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2840+SW+341st+Ct&city=Federal Way&state=WA&zipcode=98023&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=19723+112th+Ave+NE+Apt+D101&city=Bothell&state=WA&zipcode=98011&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1028+Rosewood+Ave+Apt+B&city=Wenatchee&state=WA&zipcode=98801&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1028+Rosewood+Ave+Apt+B&city=Wenatchee&state=WA&zipcode=98801&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=608+39th+Ave+SW+Apt+K103&city=Puyallup&state=WA&zipcode=98373&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=19723+112th+Ave+NE+Apt+D101&city=Bothell&state=WA&zipcode=98011&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=4264+COLE+WAY&city=SPRINGFIELD&state=OR&zipcode=97478&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1533+W+MISSOURI+AVE&city=PHOENIX&state=AZ&zipcode=85015&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=5375+N+COMANCHE+DR&city=ELOY&state=AZ&zipcode=85131&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=4264+COLE+WAY&city=SPRINGFIELD&state=OR&zipcode=97478&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3314+Joe+Johns+Rd&city=Ocean Park&state=WA&zipcode=98640&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=19723+112th+Ave+NE+Apt+D101&city=Bothell&state=WA&zipcode=98011&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1028+Rosewood+Ave+Apt+B&city=Wenatchee&state=WA&zipcode=98801&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=503+Ismo+Ct&city=Grandview&state=WA&zipcode=98930&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2218+Davison+Ave&city=Richland&state=WA&zipcode=99354&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=15807+NE+96th+Way&city=Redmond&state=WA&zipcode=98052&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=19723+112th+Ave+NE+Apt+D101&city=Bothell&state=WA&zipcode=98011&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2840+SW+341st+Ct&city=Federal Way&state=WA&zipcode=98023&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=9421+112th+Ave+NE&city=Kirkland&state=WA&zipcode=98033&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=608+39th+Ave+SW+Apt+K103&city=Puyallup&state=WA&zipcode=98373&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3710+A+St+SE+Trlr+36&city=Auburn&state=WA&zipcode=98002&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=303+N+31st+Ave&city=Yakima&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1028+Rosewood+Ave+Apt+B&city=Wenatchee&state=WA&zipcode=98801&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=719+E+1st+Ave&city=Toppenish&state=WA&zipcode=98948&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=324+Ferry+St+Apt+1&city=Wenatchee&state=WA&zipcode=98801&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3068+ROSE+PL&city=YAKIMA&state=WA&zipcode=98902&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=14913+Red+Delicious+St&city=Entiat&state=WA&zipcode=98822&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3710+A+St+SE+Trlr+36&city=Auburn&state=WA&zipcode=98002&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=4220+W+16th+St+Fl+1&city=Chicago&state=IL&zipcode=60623&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=105+S+CARDINAL+AVE&city=STOCKTON&state=CA&zipcode=95215&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1607+W+LOCUST+ST&city=LODI&state=CA&zipcode=95242&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1504+HASTINGS+DR&city=MANTECA&state=CA&zipcode=95336&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3833+BRIDLEWOOD+CIR&city=STOCKTON&state=CA&zipcode=95219&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=359+ACACIA+ST+APT+1&city=TRACY&state=CA&zipcode=95376&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=10888+N+70TH+ST+APT+230&city=SCOTTSDALE&state=AZ&zipcode=85254&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=8123+CHAMPAGNE+DR&city=STOCKTON&state=CA&zipcode=95210&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1969+PHILLIP+CT&city=STOCKTON&state=CA&zipcode=95206&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2930+GLENN+AVE&city=SANTA MONICA&state=CA&zipcode=90405&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=850+BRODERICK+ST&city=SAN FRANCISCO&state=CA&zipcode=94115&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=4518+STARK+ST&city=RIDGECREST&state=CA&zipcode=93555&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2110+5TH+ST&city=WASCO&state=CA&zipcode=93280&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=4617+GRANDVIEW+TER&city=LA MESA&state=CA&zipcode=91941&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=5301+CAHUENGA+BLVD&city=N HOLLYWOOD&state=CA&zipcode=91601&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=23453+CAROLDALE+AVE&city=CARSON&state=CA&zipcode=90745&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=620+S+68TH+PL&city=SPRINGFIELD&state=OR&zipcode=97478&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=38129+WEIRICH+DR&city=LEBANON&state=OR&zipcode=97355&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=859+N+MOUNTAIN+AVE&city=UPLAND&state=CA&zipcode=91786&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1405+WHITE+LN&city=BAKERSFIELD&state=CA&zipcode=93307&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=4065+N+7TH+ST&city=FRESNO&state=CA&zipcode=93726&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2717+ARROW+HWY&city=LA VERNE&state=CA&zipcode=91750&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=9818+MYRON+ST&city=PICO RIVERA&state=CA&zipcode=90660&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1351+CABRILLO+DR&city=HEMET&state=CA&zipcode=92543&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3208+OCCIDENTAL+ST&city=BAKERSFIELD&state=CA&zipcode=93305&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=11357+THIENES+AVE&city=S EL MONTE&state=CA&zipcode=91733&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1012+E+CLINTON+AVE&city=FRESNO&state=CA&zipcode=93704&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=3046+HOPE+ST&city=HUNTINGTON PK&state=CA&zipcode=90255&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2500+N+WILLIAMS+AVE&city=PORTLAND&state=OR&zipcode=97227&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=13+MINERS+TRL&city=IRVINE&state=CA&zipcode=92620&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=6200+VICTOR+ST&city=BAKERSFIELD&state=CA&zipcode=93308&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=1713+S+WOODLAND+PL&city=SANTA ANA&state=CA&zipcode=92707&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=13759+OXNARD+ST&city=VAN NUYS&state=CA&zipcode=91401&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=22125+MAIN+ST&city=CARSON&state=CA&zipcode=90745&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=101+W+MISSION+BLVD&city=POMONA&state=CA&zipcode=91766&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=2677+W+CORNELL+AVE&city=ANAHEIM&state=CA&zipcode=92801&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=678+W+19TH+ST&city=COSTA MESA&state=CA&zipcode=92627&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=PO+BOX+50107&city=PASADENA&state=CA&zipcode=91115&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=6701+AUBURN+ST&city=BAKERSFIELD&state=CA&zipcode=93306&candidates=1&source=umv"},
                 new TestCase{ Name = "SS", NumberOfTimesToRun = 2, Url = "address?street=10229+N+15TH+DR&city=PHOENIX&state=AZ&zipcode=85021&candidates=1&source=umv"},
            };

            var outerStopwatch = new Stopwatch();
            outerStopwatch.Start();
            var concurrentBag = new ConcurrentBag<TestResult>();

            var tasks = new List<Task>();

            //Authorization: Basic MjdiZmFhZDctYmQ2ZC00N2FmLTg4NjUtZTAwNmMwM2Y4ZTljOg==

            // YOU CANNOT DO THIS, IT WILL NOT WORK!!!
            //var apiKeyCredentials = Convert.ToBase64String(Encoding.Default.GetBytes("27bfaad7-bd6d-47af-8865-e006c03f8e9c"));

            foreach (var testCase in testCases)
            {
                for (var count = 0; count <= testCase.NumberOfTimesToRun; count++)
                {
                    var task = Task.Run(() =>
                    {
                        var testResult = new TestResult { Name = testCase.Name, StartTime = DateTime.Now.ToString("h:mm:ss fff"), ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId };

                        var stopWatch = new Stopwatch();
                        try
                        {
                            var webRequest = WebRequest.Create(endpoint + testCase.Url);
                            webRequest.Headers.Add("Authorization", "Basic MjdiZmFhZDctYmQ2ZC00N2FmLTg4NjUtZTAwNmMwM2Y4ZTljOg==");

                            stopWatch.Start();
                            var response = webRequest.GetResponse();

                            testResult.ResponseDuration = stopWatch.Elapsed.TotalMilliseconds;

                            stopWatch.Restart();

                            using (var stream = new StreamReader(response.GetResponseStream()))
                            {
                                testResult.TotalBytes = Encoding.UTF8.GetBytes(stream.ReadToEnd()).Length;
                                testResult.ResponsePayloadDuration = stopWatch.Elapsed.TotalMilliseconds;
                            }

                        }
                        catch (Exception ex)
                        {
                            testResult.ExceptionMessage = ex.Message;
                        }

                        testResult.CompleteTime = DateTime.Now.ToString("h:mm:ss fff");

                        concurrentBag.Add(testResult);

                        Console.WriteLine(testResult);
                    });
                    tasks.Add(task);
                }
            }
            Task.WaitAll(tasks.ToArray());

            File.Delete($@"{desktop}\{environment}_Result.csv");
            File.WriteAllLines($@"{desktop}\{environment}_Result.csv", concurrentBag.Select(x => x.ToString()));

            File.Delete($@"{desktop}\{environment}_SummaryResult.csv");

            var groups = concurrentBag.GroupBy(x => x.Name);

            var lines = new List<string>
            {
                $"{endpoint}",
                $"Time To Process :{outerStopwatch.Elapsed.TotalSeconds}s",
                $"Total Request Count:{concurrentBag.Count}",
                $"Distinct Thread Count:{concurrentBag.Select(x=> x.ThreadId).Distinct().Count()}",
                "Text,Thread Count, Count, Average ResponseDuration, Average ResponsePayloadDuration, Average TotalDurationAverage, TotalBytes," +
                "Min ResponseDuration, Min ResponsePayloadDuration, Min TotalDuration, Min TotalBytes," +
                "Max ResponseDuration, Max ResponsePayloadDuration, Max TotalDuration, Max TotalBytes," +
                "ResponseDuration StdDev, ResponsePayloadDuration StdDev, TotalDuration StdDev, TotalBytes StdDev, ExceptionMessage Count"
            };

            foreach (var group in groups)
            {
                lines.Add($"{group.Key},{group.Select(x => x.ThreadId).Distinct().Count()},{group.Count()},{group.Average(x => x.ResponseDuration)},{group.Average(x => x.ResponsePayloadDuration)},{group.Average(x => x.TotalDuration)},{group.Average(x => x.TotalBytes)}," +
                          $"{group.Min(x => x.ResponseDuration)},{group.Min(x => x.ResponsePayloadDuration)},{group.Min(x => x.TotalDuration)},{group.Min(x => x.TotalBytes)}," +
                          $"{group.Max(x => x.ResponseDuration)},{group.Max(x => x.ResponsePayloadDuration)},{group.Max(x => x.TotalDuration)},{group.Max(x => x.TotalBytes)}," +
                          $"{group.Select(x => x.ResponseDuration).StdDev()},{group.Select(x => x.ResponsePayloadDuration).StdDev()},{group.Select(x => x.TotalDuration).StdDev()},{group.Select(x => (double)x.TotalBytes).StdDev()}" +
                          $"{group.Count(x => !string.IsNullOrEmpty(x.ExceptionMessage))}");
            }

            File.WriteAllLines($@"{desktop}\{environment}_SummaryResult.csv", lines);
        }
    }

    public class TestCase
    {
        public int NumberOfTimesToRun { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }

    public class TestResult
    {
        public string Name { get; set; }

        public int ThreadId { get; set; }

        public int TotalBytes { get; set; }

        public string StartTime { get; set; }

        public string CompleteTime { get; set; }

        public double TotalDuration => ResponseDuration + ResponsePayloadDuration;

        public double ResponseDuration { get; set; }

        public double ResponsePayloadDuration { get; set; }

        public string ExceptionMessage { get; set; }

        public override string ToString()
        {
            return $"{Name},{ThreadId},{StartTime},{CompleteTime},{ResponseDuration},{ResponsePayloadDuration},{TotalDuration},{TotalBytes},{ExceptionMessage}";
        }
    }

    public static class Extensions
    {
        public static double StdDev(this IEnumerable<double> values)
        {
            double ret = 0;
            int count = values.Count();
            if (count > 1)
            {
                //Compute the Average
                double avg = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => (d - avg) * (d - avg));

                //Put it all together
                ret = Math.Sqrt(sum / count);
            }
            return ret;
        }
    }
}
