using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppBaby
{
    public partial class Form餐廳資訊 : Form
    {
        public Form餐廳資訊()
        {
            InitializeComponent();
            // 關掉js錯誤提示
            //webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void Form商家資訊_Load(object sender, EventArgs e)
        {
            // =========== 版本 ===========
            this.Text = GlobalVar.version版本;

            if (GlobalVar.store目前餐廳資訊 != null)
            {
                lbl餐廳名稱.Text = GlobalVar.store目前餐廳資訊.f餐廳名稱;
                lbl餐廳電話.Text = GlobalVar.store目前餐廳資訊.f餐廳電話;
                lbl餐廳地址.Text = GlobalVar.store目前餐廳資訊.f餐廳地址;
            }
        }

        // ========================= 使用chrome取代預設的IE =========================
        // 安裝套件CefSharp.WinForms；一定要把AnyCPU(不支援)改成x86或x64
        public ChromiumWebBrowser chrome;

        private void pbox地圖_Click(object sender, EventArgs e)
        {
            //$"https://www.google.com.tw/maps?q={position.coords.latitude},{position.coords.longitude}"
            string url = @"http://maps.google.com/maps/api/staticmap";
            url += @"?zoom=15&size=333x333&maptype=roadmap&sensor=false";
            url += @"&key=你的金鑰"; // 請用自己的金鑰>"<
            url += $"&markers=" + GlobalVar.store目前餐廳資訊.f餐廳地址;

            //System.Diagnostics.Process.Start(url);

            // ============= 使用chrome取代預設的IE =============
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            chrome = new ChromiumWebBrowser(url);
            this.panel地圖.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
        }
    }
}
