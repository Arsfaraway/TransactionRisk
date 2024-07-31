using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TronRisk;

public class TransactionRisk
{
    public static async Task Main(string[] args)
    {
        string transactionHash = "853793d552635f533aa982b92b35b00e63a1c1add062c099da2450a15119bcb2";
        string apiUrl = $"https://apilist.tronscanapi.com/api/transaction-info?hash={transactionHash}";

        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Transaction transactionInfo = JsonSerializer.Deserialize<Transaction>(responseBody);

            Console.WriteLine($"Transaction risk: {transactionInfo.riskTransaction}");
            Console.WriteLine($"TVBkD4V2qmLGAoQjBgMEDoPihaYgEtiLau risk: {transactionInfo.normalAddressInfo.TVBkD4V2qmLGAoQjBgMEDoPihaYgEtiLau.risk}");
            Console.WriteLine($"TQ793kg2ckYZtbRcUQLfTLwtccCQgGuMyk risk: {transactionInfo.normalAddressInfo.TQ793kg2ckYZtbRcUQLfTLwtccCQgGuMyk.risk}");
            Console.ReadLine();

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }
}

