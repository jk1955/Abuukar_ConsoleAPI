using ConsoleApp4.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;

public class Program
{
 

    static async Task Main(string[] args)
    {
        var msg = await ClientGET();
        Console.WriteLine(JToken.Parse(msg).ToString());

        var resultPOST = await ClientPOST();
        Console.WriteLine(resultPOST);

        var resultPUT = await ClientPUT();
        Console.WriteLine(resultPUT);

        var resultDELETE = await ClientDELETE();
        Console.WriteLine(resultDELETE);

    }

    public class Header : HttpClient
    {
        public string requestUri { get; set; }
        public HttpClient client { get; set; }

        public Header()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

            requestUri = "https://localhost:7221/api/Class1s/";
        }
    }

    public static async Task<string> ClientGET()
    {

        Header client = new Header();
        var requestUri = client.requestUri;

        Console.WriteLine(requestUri);

        var stringTask = client.GetStringAsync(requestUri);
        var msg = await stringTask;

        return msg;

    }
    public static async Task<HttpResponseMessage> ClientPOST()
    {
        Header client = new Header();
        var requestUri = client.requestUri;

        var class1POST = new Class1 { player = "rondldo", teams = "manscherunited", preferdfoot = "right ", postion = "striker", salary = 26000000, nationality = "portugual", Height = "187cm", weight = "83kg", age = 37 };

        var resultPOST = await client.PostAsync<Class1>(requestUri, class1POST, new JsonMediaTypeFormatter());

        return (HttpResponseMessage)resultPOST;

    }
    public static async Task<HttpResponseMessage> ClientPUT()
    {
        Header client = new Header();
        var requestUri = client.requestUri;

        var class1PUT = new Class1 {Id=1,  player = "rondldo", teams = "manscherunited", preferdfoot = "right ", postion = "striker", salary = 26000000, nationality = "portugual", Height = "187cm", weight = "83kg", age = 37 };
        var resultPUT = await client.PutAsync<Class1>(requestUri + "1", class1PUT, new JsonMediaTypeFormatter());

        return (HttpResponseMessage)resultPUT;

    }
    public static async Task<HttpResponseMessage> ClientDELETE()
    {
        Header client = new Header();
        var requestUri = client.requestUri;

        var resultDELETE = await client.DeleteAsync(requestUri + "7");

        return (HttpResponseMessage)resultDELETE;

    }
}

