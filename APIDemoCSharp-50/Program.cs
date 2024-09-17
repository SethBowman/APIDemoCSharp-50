using Newtonsoft.Json.Linq;

//Create an instance of a class called HttpClient, this is what actually makes the api call
var client = new HttpClient();

//Build an api url from where the api call comes from
var kanyeUrl = "https://api.kanye.rest/";

//Using the HttpClient instance
//Send a GET request to the url created above, this is going to give us back a string of JSON
var kanyeResponseJson = client.GetStringAsync(kanyeUrl).Result;

//Parse the json response we just got back into a JObject, we do this so we can access certain parts of the json
//In this case we will be getting the value of "quote" which will give me the actual quote itself and not the whole body of json
//var kanyeQuote = JObject.Parse(kanyeResponseJson).GetValue("quote").ToString();
var kanyeQuote = JObject.Parse(kanyeResponseJson)["quote"].ToString();

Console.WriteLine(kanyeQuote);

//USING APPSETTINGS JSON SECTION

//Grab appsettings file and all the text it contains
var appsettingsText = File.ReadAllText("appsettings.json");

//Get the api key from the appsettings text using it's name "key"
var apiKey = JObject.Parse(appsettingsText)["key"].ToString();

var url = $"http://api.openweathermap.org/data/2.5/weather?zip=35091&appid={apiKey}&units=imperial";