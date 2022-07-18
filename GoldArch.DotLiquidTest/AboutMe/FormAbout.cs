using System.Windows.Forms;

namespace GoldArch.DotLiquidTest.AboutMe
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            versionLabel.Text = @"Ver："  + Application.ProductVersion;
        }

        private void FormAbout_Load(object sender, System.EventArgs e)
        {
            //在线html编辑器
            //http://kindeditor.net/demo.php 
            //https://www.lddgo.net/string/htmleditor
            //https://www.qianbo.com.cn/Tool/HtmlEditor.html

            //由于html中的双引号需要转议，太麻烦，直接把文本存入资源文件中！不用转义！
            //全局资源文件设置相对简单
            //wbMain.DocumentText = Resources.AboutMe;

            //放在form自身的资源文件中便于复制！
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            //wbMain.DocumentText = resources.GetObject("AboutMe")?.ToString();

            wbMain.DocumentText = ReadTextHelper.GetAboutMe();

        }
    }
}
