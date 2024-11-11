using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Net;
using System.IO;
using System.Security.Policy;
using HtmlAgilityPack;
namespace Lab4_3
{
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
            webView.NavigationStarting += EnsureHttps;
            InitializeAsync();
        }
        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;

            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");
        }

        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String uri = args.TryGetWebMessageAsString();
            addressBar.Text = uri;
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            goButton.Left = this.ClientSize.Width - goButton.Width;
            addressBar.Width = goButton.Left - addressBar.Left;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(addressBar.Text);
            }
        }
        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2?.Reload();
        }

        private void downfilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient myClient = new WebClient();
                string url = addressBar.Text; // Lấy URL từ thanh địa chỉ
                string filePath = "D:\\clonecode\\Lab4_3_NT106\\Lab4_3\\bin\\Debug\\MyWeb\\MyDownLoadHTML.html"; // Đường dẫn lưu tệp

                // Tải xuống và lưu tệp HTML
                myClient.DownloadFile(url, filePath);

                MessageBox.Show("Tải xuống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải xuống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

private void downRButton_Click(object sender, EventArgs e)
    {
        try
        {
            string url = addressBar.Text;
            string saveDirectory = "D:\\clonecode\\Lab4_3_NT106\\Lab4_3\\bin\\Debug\\MyWeb";

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            WebClient webClient = new WebClient();
            // Tải mã HTML của trang
            string htmlContent = webClient.DownloadString(url);

                // Phân tích mã HTML
             HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
             document.LoadHtml(htmlContent);

            // Trích xuất tất cả các liên kết đến hình ảnh, CSS, và JS
            var imageNodes = document.DocumentNode.SelectNodes("//img[@src]");
            var cssNodes = document.DocumentNode.SelectNodes("//link[@rel='stylesheet']");
            var scriptNodes = document.DocumentNode.SelectNodes("//script[@src]");

            // Tải hình ảnh
            if (imageNodes != null)
            {
                foreach (var node in imageNodes)
                {
                    string imageUrl = node.GetAttributeValue("src", "");
                    DownloadResource(imageUrl, saveDirectory, webClient);
                }
            }

            // Tải CSS
            if (cssNodes != null)
            {
                foreach (var node in cssNodes)
                {
                    string cssUrl = node.GetAttributeValue("href", "");
                    DownloadResource(cssUrl, saveDirectory, webClient);
                }
            }

            // Tải JavaScript
            if (scriptNodes != null)
            {
                foreach (var node in scriptNodes)
                {
                    string scriptUrl = node.GetAttributeValue("src", "");
                    DownloadResource(scriptUrl, saveDirectory, webClient);
                }
            }

            MessageBox.Show("Tải xuống tài nguyên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải xuống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Hàm hỗ trợ để tải và lưu tài nguyên
    private void DownloadResource(string resourceUrl, string saveDirectory, WebClient webClient)
    {
        if (!Uri.IsWellFormedUriString(resourceUrl, UriKind.Absolute))
        {
            // Xử lý các URL tương đối
            resourceUrl = new Uri(new Uri(addressBar.Text), resourceUrl).ToString();
        }

        string fileName = Path.GetFileName(new Uri(resourceUrl).AbsolutePath);
        string savePath = Path.Combine(saveDirectory, fileName);

        webClient.DownloadFile(resourceUrl, savePath);
    }

}
}
