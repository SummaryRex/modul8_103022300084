using modul8_103022300084;

class Program
{
    private const String url = @"D:\modul8_103022300084\bank_transfer_config.json";

    public static void Main(string[] args)
    {
        BankTransferConfig bankConfig = new BankTransferConfig();
        bankConfig.ReadConfigFile(url);
        int bhs = 0;
        Console.WriteLine("Select language: ");
        Console.WriteLine("1. English");
        Console.WriteLine("2. Indonesia");
        Console.Write("Choose number: ");
        bhs = Convert.ToInt32(Console.ReadLine());
        if (bhs == 1)
        {
            bankConfig.lang = "en";
        }
        else if (bhs == 2)
        {
            bankConfig.lang = "id";
        }
        else
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        bool defaultLang = bankConfig.lang == "en";

        Console.WriteLine(defaultLang ? "Welcome" : "Selamat Datang!");
        Console.WriteLine(defaultLang ? "Program Language!: English" : "Bahasa Saat Ini!: Indonesia");

        try
        {
            Console.Write(defaultLang ? "Please insert the amount of money to transfer: " : "Masukkan jumlah uang yang akan di-transfer: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            
            int totalPayed = 0;

            Console.WriteLine(defaultLang ? "Select payment method: " : "Pilih metode pembayaran: ");
            string[] methodPayment = bankConfig.methods;

            for (int i = 0; i < methodPayment.Length; i++)
            {
                Console.WriteLine(i + " " + methodPayment[i]);
            }

            Console.Write(defaultLang ? "Choose number: " : "Pilih nomor: ");
            int? choosenMethodPayment = Convert.ToInt32(Console.ReadLine());

            if (choosenMethodPayment != null)
            {
                if (amount <= bankConfig.transfer.threshold)
                {
                    int fee = bankConfig.transfer.low_fee;

                    totalPayed = amount + fee;
                    Console.WriteLine(defaultLang ? $"Transfer fee: {fee} and Total amount: {totalPayed}" : $"Biaya transfer: {fee} and Total biaya: {totalPayed}");
                }
                else if (amount >= bankConfig.transfer.threshold)
                {
                    int fee = bankConfig.transfer.high_fee;

                    totalPayed = amount + fee;
                    Console.WriteLine(defaultLang ? $"Transfer fee: {fee} and Total amount: {totalPayed}" : $"Biaya transfer: {fee} and Total biaya: {totalPayed}");
                }

                Console.WriteLine(defaultLang ? "Transfer is completed!" : "Transfer berhasil!");
            }
        }
        catch
        {
            Console.WriteLine(defaultLang ? "Transfer is cancelled!" : "Transfer dibatalkan!");
        }
    }
}