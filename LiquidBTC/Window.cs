using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiquidBTCTrend
{
    public partial class App : Form
    {
        static Random R = new Random();
        HttpClient Client = new HttpClient();
        Timer FetchTick = new Timer();
        Timer PresentTick = new Timer();
        string Id = "1";
        decimal NextHigh = 0;
        decimal NextLow = 0;
        decimal NextOffer = 0;
        decimal NextPredict = 0;
        decimal PrevHigh = 0;
        decimal PrevLow = 0;
        decimal PrevOffer = 0;
        decimal PrevPredict = 0;
        double Time = 0;
        bool Long = false;

        public App()
        {
            InitializeComponent();
            FetchTick.Tick += FetchUpdate;
            FetchTick.Interval = 2000;
            FetchTick.Start();
            PresentTick.Tick += PresentUpdate;
            PresentTick.Interval = 10;
            PresentTick.Start();
            Client.BaseAddress = new Uri("https://api.liquid.com/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            PairBox.SelectedIndex = 0;
            PairBox.DropDown += PairUpdate;
            PairBox.SelectedIndexChanged += PairChange;
            Strategy.Click += StrategyChange;
            Latency.ValueChanged += LatencyChanged;
        }
        private async void PairUpdate(object Sender, EventArgs Event)
        {
            if (PairBox.Items.Count > 1)
                return;

            try
            {
                HttpResponseMessage Response = await Client.GetAsync("/products");
                if (Response.IsSuccessStatusCode)
                {
                    JArray Object = JArray.Parse(await Response.Content.ReadAsStringAsync());
                    PairBox.Items.Clear();

                    foreach (var Item in Object)
                    {
                        PairBox.Items.Add(Item["currency_pair_code"].ToString() + "/" + Item["id"].ToString());
                        if (Item["currency_pair_code"].ToString() == "BTCUSD")
                            PairBox.SelectedIndex = PairBox.Items.Count - 1;
                    }
                }
            }
            catch
            {
                Status.ForeColor = Color.Red;
            }
        }
        private async void FetchUpdate(object Sender, EventArgs Event)
        {
            PrevHigh = NextHigh;
            PrevLow = NextLow;
            PrevOffer = NextOffer;
            PrevPredict = NextPredict;
            Time = (DateTimeOffset.Now.ToUnixTimeMilliseconds() + FetchTick.Interval);

            try
            {
                HttpResponseMessage Response = await Client.GetAsync("/products/" + Id);
                if (!Response.IsSuccessStatusCode)
                    return;

                JObject Object = JObject.Parse(await Response.Content.ReadAsStringAsync());
                if (!decimal.TryParse(Object["last_traded_price"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal OfferPrice))
                    return;

                Response = await Client.GetAsync("/products/" + Id + "/price_levels");
                if (!Response.IsSuccessStatusCode)
                    return;

                Object = JObject.Parse(await Response.Content.ReadAsStringAsync());
                decimal BuyPrice = 0, BuyAmount = 0, SellPrice = 0, SellAmount = 0;

                JArray Buy = (JArray)Object["buy_price_levels"];
                if (Long)
                {
                    foreach (var Item in Buy)
                    {
                        if (decimal.TryParse(Item[0].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Price))
                        {
                            if (decimal.TryParse(Item[1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Amount))
                            {
                                BuyPrice += Price;
                                BuyAmount += Amount;
                            }
                        }
                    }
                }
                else
                {
                    if (decimal.TryParse(Buy[0][0].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Price))
                    {
                        if (decimal.TryParse(Buy[0][1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Amount))
                        {
                            BuyPrice = Price;
                            BuyAmount = Amount;
                        }
                    }
                }

                JArray Sell = (JArray)Object["sell_price_levels"];
                if (Long)
                {
                    foreach (var Item in Sell)
                    {
                        if (decimal.TryParse(Item[0].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Price))
                        {
                            if (decimal.TryParse(Item[1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Amount))
                            {
                                SellPrice += Price;
                                SellAmount += Amount;
                            }
                        }
                    }
                }
                else
                {
                    if (decimal.TryParse(Sell[0][0].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Price))
                    {
                        if (decimal.TryParse(Sell[0][1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal Amount))
                        {
                            SellPrice = Price;
                            SellAmount = Amount;
                        }
                    }
                }

                if (Long)
                {
                    BuyPrice /= Buy.Count;
                    SellPrice /= Sell.Count;
                }

                NextHigh = SellPrice;
                NextLow = BuyPrice;
                NextOffer = OfferPrice;
                NextPredict = (SellPrice + BuyPrice) / 2;
                ChangeColors();

                if (SellPrice >= OfferPrice)
                {
                    Trend.Text = "UP";
                    if (BuyPrice >= OfferPrice)
                        Trend.ForeColor = Color.Green;
                    else
                        Trend.ForeColor = Color.Red;
                }
                else
                {
                    Trend.Text = "DOWN";
                    if (BuyPrice < OfferPrice)
                        Trend.ForeColor = Color.Red;
                    else
                        Trend.ForeColor = Color.Green;
                }

                Status.ForeColor = Color.Black;
            }
            catch
            {
                Status.ForeColor = Color.Red;
            }
        }
        private void PairChange(object Sender, EventArgs Event)
        {
            string Value = PairBox.Items[PairBox.SelectedIndex].ToString();
            int Index = Value.LastIndexOf("/");
            if (Index < 0)
                return;

            string Product = Value.Substring(Index + 1);
            if (int.TryParse(Product, NumberStyles.Any, CultureInfo.InvariantCulture, out int Weak))
                Id = Product;
        }
        private void LatencyChanged(object Sender, EventArgs Event)
        {
            FetchTick.Interval = Latency.Value;
        }
        private void StrategyChange(object Sender, EventArgs Event)
        {
            Long = !Long;
            Strategy.Text = (Long ? "LONG" : "SHORT");
        }
        private void PresentUpdate(object Sender, EventArgs Event)
        {
            double T = Time - DateTimeOffset.Now.ToUnixTimeMilliseconds();
            T /= FetchTick.Interval;
            T = 1.0 - T;
            
            High.Text = Lerp(PrevHigh, NextHigh, T).ToString("0.#########################");
            Low.Text = Lerp(PrevLow, NextLow, T).ToString("0.#########################");
            Offer.Text = Lerp(PrevOffer, NextOffer, T).ToString("0.#########################");
            Predict.Text = Lerp(PrevPredict, NextPredict, T).ToString("0.#########################");
        }
        private void ChangeColors()
        {
            Task.Delay(R.Next(500)).ContinueWith((T1) =>
            {
                High.BackColor = High.BackColor;
                if (PrevHigh < NextHigh)
                    High.ForeColor = Color.Green;
                else if (PrevHigh > NextHigh)
                    High.ForeColor = Color.Red;
                else
                    High.ForeColor = Color.Black;

                Task.Delay(300).ContinueWith((T2) =>
                {
                    High.BackColor = High.BackColor;
                    High.ForeColor = Color.Black;
                });
            });

            Task.Delay(R.Next(500)).ContinueWith((T1) =>
            {
                Low.BackColor = Low.BackColor;
                if (PrevLow < NextLow)
                    Low.ForeColor = Color.Green;
                else if (PrevLow > NextLow)
                    Low.ForeColor = Color.Red;
                else
                    Low.ForeColor = Color.Black;

                Task.Delay(300).ContinueWith((T2) =>
                {
                    Low.BackColor = Low.BackColor;
                    Low.ForeColor = Color.Black;
                });
            });

            Task.Delay(R.Next(500)).ContinueWith((T1) =>
            {
                Offer.BackColor = Offer.BackColor;
                if (PrevOffer < NextOffer)
                    Offer.ForeColor = Color.Green;
                else if (PrevOffer > NextOffer)
                    Offer.ForeColor = Color.Red;
                else
                    Offer.ForeColor = Color.Black;

                Task.Delay(300).ContinueWith((T2) =>
                {
                    Offer.BackColor = Offer.BackColor;
                    Offer.ForeColor = Color.Black;
                });
            });

            Task.Delay(R.Next(500)).ContinueWith((T1) =>
            {
                Predict.BackColor = Predict.BackColor;
                if (PrevPredict < NextPredict)
                    Predict.ForeColor = Color.Green;
                else if (PrevPredict > NextPredict)
                    Predict.ForeColor = Color.Red;
                else
                    Predict.ForeColor = Color.Black;

                Task.Delay(300).ContinueWith((T2) =>
                {
                    Predict.BackColor = Predict.BackColor;
                    Predict.ForeColor = Color.Black;
                });
            });
        }
        private decimal Lerp(decimal A, decimal B, double T)
        {
            return A + (decimal)T * (B - A);
        }
    }
}
