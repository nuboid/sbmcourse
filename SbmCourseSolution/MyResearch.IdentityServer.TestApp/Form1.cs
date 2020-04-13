using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdentityModel;
using IdentityModel.Client;
using MyResearch.IdentityServer.TestApp.Structs;
using Newtonsoft.Json;

namespace MyResearch.IdentityServer.TestApp
{
    public partial class Form1 : Form
    {

        private string _urlToSts;
        private string _clientId;
        private string _clientSecret;

        private string _userNameRO;
        private string _passwordRO;

        private string _scopeToTest;
        private string _accessToken;
        private string _refreshToken;

        public Form1()
        {
            InitializeComponent();

            _urlToSts = "https://localhost:44395";
            _clientId = "roclient";
            _clientSecret = "secret";
            _userNameRO = "test@test.com";
            _passwordRO = "somepassword";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tbAccessToken.Text = "";
            tbRefreshToken.Text = "";
            tbInfo.Text = "";
            tbExceptionDetail.Text = "";

            var tokenClient = new TokenClient(
                _urlToSts + "/connect/token",
                _clientId,
                _clientSecret);


            try
            {
                var r = tokenClient
                    .RequestResourceOwnerPasswordAsync(_userNameRO, _passwordRO, "api1 offline_access").Result;

                _accessToken = r.AccessToken;
                _refreshToken = r.RefreshToken;

                tbAccessToken.Text = _accessToken;
                tbRefreshToken.Text = _refreshToken;

                var tokenParts = _accessToken.Split('.');

                var header = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[0])));
                var payload = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[1])));

                var jwt = JsonConvert.DeserializeObject<JWTPayload>(payload);

                tbInfo.Text = jwt.Claim1 + " " + jwt.Claim2;
            }
            catch (Exception ex)
            {
                tbExceptionDetail.Text = ex.ToString();
            }

            //MessageBox.Show("AccessToken : " + _accessToken);

        }

        private string CreateGoodBase64Encoding(string source)
        {
            var mod4 = source.Length % 4;
            if (mod4 > 0)
                source += new string('=', 4 - mod4);

            return source;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            tbAccessToken.Text = "";
            tbInfo.Text = "";
            tbExceptionDetail.Text = "";

            var base64EncodedBasic = Base64Encode(_clientId + ":" + _clientSecret);

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + base64EncodedBasic);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", "test@test.com"),
                new KeyValuePair<string, string>("password", "somepassword"),
                new KeyValuePair<string, string>("scope", "api1 offline_access")
            });

            var response =
                await httpClient.PostAsync(
                    _urlToSts +
                    @"/connect/token",
                    content);

            var responsePayload = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<PostPasswordGrantResponsePayload>(responsePayload);


            _accessToken = data.access_token;
            _refreshToken = data.refresh_token;

            tbAccessToken.Text = _accessToken;
            tbRefreshToken.Text = _refreshToken;

            var tokenParts = _accessToken.Split('.');

            var header = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[0])));
            var payload = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[1])));

            var jwt = JsonConvert.DeserializeObject<JWTPayload>(payload);

            tbInfo.Text = jwt.Claim1 + " " + jwt.Claim2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbAccessToken.Text = "";
            tbInfo.Text = "";
            tbExceptionDetail.Text = "";

            var tokenClient = new TokenClient(
                _urlToSts + "/connect/token",
                _clientId,
                _clientSecret);

            var r = tokenClient
                .RequestRefreshTokenAsync(tbRefreshToken.Text).Result;

            _accessToken = r.AccessToken;
            _refreshToken = r.RefreshToken;

            tbAccessToken.Text = _accessToken;
            tbRefreshToken.Text = _refreshToken;

            var tokenParts = _accessToken.Split('.');

            var header = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[0])));
            var payload = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[1])));

            var jwt = JsonConvert.DeserializeObject<JWTPayload>(payload);

            tbInfo.Text = jwt.Claim1 + " " + jwt.Claim2;


        }

        private async void button4_Click(object sender, EventArgs e)
        {
            tbAccessToken.Text = "";
            tbInfo.Text = "";
            tbExceptionDetail.Text = "";

            var base64EncodedBasic = Base64Encode(_clientId + ":" + _clientSecret);

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + base64EncodedBasic);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", tbRefreshToken.Text),
            });

            var response =
                await httpClient.PostAsync(
                    _urlToSts +
                    @"/connect/token",
                    content);

            var responsePayload = await response.Content.ReadAsStringAsync();

            tbExceptionDetail.Text = responsePayload;
            var data = JsonConvert.DeserializeObject<PostRefreshTokenGrantResponsePayload>(responsePayload);

            _accessToken = data.access_token;

            _refreshToken = data.refresh_token;

            tbAccessToken.Text = _accessToken;
            tbRefreshToken.Text = _refreshToken;

            var tokenParts = _accessToken.Split('.');

            var header = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[0])));
            var payload = Encoding.UTF8.GetString(Convert.FromBase64String(CreateGoodBase64Encoding(tokenParts[1])));

            var jwt = JsonConvert.DeserializeObject<JWTPayload>(payload);

            tbInfo.Text = jwt.Claim1 + " " + jwt.Claim2;

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            //http://localhost:82/API/PINGUNSECURE

            tbExceptionDetail.Text = "";
            tbInfo.Text = "";
            var httpClient = new HttpClient();

            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await httpClient.GetAsync("http://localhost:85/API/PINGSECURE");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                tbInfo.Text = content;
            }
            catch (Exception ex)
            {
                tbExceptionDetail.Text = ex.ToString();
            }

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            tbExceptionDetail.Text = "";
            tbInfo.Text = "";

            var httpClient = new HttpClient();

            var bogusAccessToken =
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJCb2d1cyIsImlhdCI6MTUwNzU2MDIyMywiZXhwIjoxNTM5MDk2MjIzLCJhdWQiOiJ3d3cuZXhhbXBsZS5jb20iLCJzdWIiOiJib2d1c0BleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.WfSKoLftJgUKiDnkFq4lKo023kTVK5v-XjI9gijUJYw";

            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bogusAccessToken);
                var response = await httpClient.GetAsync("http://localhost:85/API/PINGSECURE");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                tbInfo.Text = content;
            }
            catch (Exception ex)
            {
                tbExceptionDetail.Text = ex.ToString();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://localhost:44395/.well-known/openid-configuration");
        }
    }
}
