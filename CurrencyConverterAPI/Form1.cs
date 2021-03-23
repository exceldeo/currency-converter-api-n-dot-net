using Currency_Conversion_App;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CurrencyConverterAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set label2 to null value
            label2.Text = "";
            getCurrencyList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label2.Text = "Insert a number.";
                label2.ForeColor = Color.Red;
            }
            else
            {
                if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
                {
                    label2.Text = "One or two of the currencies are still empty.";
                    label2.ForeColor = Color.Red;
                }
                else
                {
                    double input = Convert.ToDouble(textBox1.Text);
                    double rate = ExchangeRate(comboBox1.Text, comboBox2.Text, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                    input = input * rate;

                    label2.Text = Convert.ToString(input);
                    label2.ForeColor = Color.Black;
                }
            } 
        }

        public void getCurrencyList()
        {
            APIRequester currencyListRequest = new APIRequester("https://free.currconv.com/api/v7/currencies?apiKey=8a6251713f19f409c37d");
            CurrencyList currencyList = CurrencyList.Deserialize(currencyListRequest.SendAndGetResponse());
            
            CurrencyData[] datas = currencyList.ToArray(); 
            foreach (CurrencyData currency in datas)
            {
                comboBox1.Items.Add(currency.id);
                comboBox2.Items.Add(currency.id);
            }
        }

        public static double ExchangeRate(string from, string to, string date)
        {
            string url;
            url = "https://free.currencyconverterapi.com/api/v6/" + "convert?q=" + from + "_" + to + "&compact=y&date=" + date + "&apiKey=8a6251713f19f409c37d";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string jsonString;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return JObject.Parse(jsonString).First.First["val"].First.ToObject<double>();
        }
    }
}
