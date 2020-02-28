# Liquid BTC
Quick and simple short-term trend analyzer for Liquid Exchange

### Application
This tool can be used to predict next price change of selected currency pair. All Liquid's pairs are supported.
It was written in about 40 minutes. I have tested it in live mode with real money, it's quite good.
I needed this kind of tool to speed up order book lookup to select best buy/sell price.

#### PAIR
Shows current selected currency pair.

#### HIGH
Current highest sell price order.

#### OFFER
Current price level for this pair.

#### LOW
Current lowest buy price order.

#### TRND (UP/DOWN)
if the next price rises with a high probability, the name changes to green UP, if the probability of growth is less, then the UP will be red.
Otherwise, if the next price falls with a high probability, the name changes to red DOWN, if the probability of a fall is less, then DOWN will be green.

#### LAT
Latency between api calls to Liquid, defaults to 2000 ms. Max value is 5000 ms, min is 100 ms.
Also, if there are errors with the network or data, the color of LAT changes to red.

#### SHORT/LONG
In short mode app calculates price based on first buy/sell orders which gives best short-term prediction.
Otherwise, first 20 buy and first 20 sell orders will be used to calculate price change.