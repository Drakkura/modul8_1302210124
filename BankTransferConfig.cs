using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302210124
{
    internal class BankTransferConfig
    {
        public Config config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "bank_transfer_config.json";

        public BankTransferConfig() {
            try {
                ReadConfig();
            }
            catch {
                setDefault();
                WriteConfig();
            }
        }
        private Config ReadConfig() { 
            string jsonFromFile = File.ReadAllText(path+'/'+configFileName);
            config = JsonSerializer.Deserialize<Config>(jsonFromFile);
            return config;
        }
        private void WriteConfig() {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }

        public void setDefault()
        {
            config = new Config("en", new Transfer(25000000, 6500, 15000), 
                new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST"}, 
                new Confirm("yes", "ya"));
        }

        public void ubahBahasa() {
            config.lang = config.lang == "en" ? "id" : "en";
        }


    }

    public class Confirm { 
        public string en { get; set; }
        public string id { get; set; }

        public Confirm() { }

        public Confirm(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
    public class Transfer {
        public int threshold { get; set; }
        public int low_fee { get; set; }

        public int high_fee { get; set; }

        public Transfer() { }

        public Transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }


    public class Config {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }

        public Confirm confirm { get; set; }

        public Config(){ }

        public Config(string lang, Transfer transfer, List<string> methods, Confirm confirm) { 
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirm = confirm;
        }
    }
}
