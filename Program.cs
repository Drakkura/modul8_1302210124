using modul8_1302210124;
using System.Reflection.Metadata.Ecma335;

internal class program {
    private static int Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();

        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }
        string tf = Console.ReadLine();
        int jumTF = (int)Convert.ToInt64(tf); int bTF = 0;

        if (jumTF <= config.config.transfer.threshold)
        {
            bTF = config.config.transfer.low_fee;
        }
        else if (jumTF >= config.config.transfer.threshold)
        {
            bTF = config.config.transfer.high_fee;
        }

        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Transfer fee = " + bTF);
            Console.WriteLine("Total amount = " + (jumTF + bTF));
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Biaya Transfer = " + bTF);
            Console.WriteLine("Total biaya = " + (jumTF + bTF));
        }

        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Select transfer method:");
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Pilih metode transfer: ");
        }

        for (int i = 0; i < config.config.methods.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + config.config.methods[i]);

        }
        Console.Write("Select: ");
        string metode = Console.ReadLine();

        int metodeTransfer = (int)Convert.ToInt32(tf);

        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Please typer " + config.config.confirm.en + " to confirm");
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Ketik " + config.config.confirm.id + " untuk konfirmasi");
        }

        string inputKonfirmasi = Console.ReadLine();

        if (config.config.lang.Equals("en"))
        {
            if (inputKonfirmasi.Equals(config.config.confirm.en))
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        }
        else if (config.config.lang.Equals("id"))
        {
            if (inputKonfirmasi.Equals(config.config.confirm.id))
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
                Console.WriteLine("Transfer dibatalkan");
            }

        }
    }
}