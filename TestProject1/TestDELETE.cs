using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using ConsoleApp4.Models;

namespace ConsoleApp4.Test
{
    public class TestDELETE
    {
        [Fact]
        public async void API_Delete()
        {
            var resultDELETE = await Program.ClientDELETE();

            Assert.Equal((double)204, (double)resultDELETE.StatusCode);
        }

    }
}