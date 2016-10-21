using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        void Form1_Load(Object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://twitter.com");
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (e.Url.AbsoluteUri)
            {
                case "https://twitter.com/":
                    HandleMainPage();
                    break;
                case "https://twitter.com/signup":
                    HandleSignup();
                    break;
            }
        }
        void HandleSignup()
        {
            //Get the document element
            HtmlDocument doc = webBrowser1.Document;

            //Get the input boxes
            HtmlElement fullName = doc.GetElementById("full-name");
            HtmlElement email = doc.GetElementById("email");
            HtmlElement pw = doc.GetElementById("password");

            //Set the input values
            ((mshtml.IHTMLInputElement)fullName.DomElement).value = "Test Name";
            ((mshtml.IHTMLInputElement)email.DomElement).value = "testname@databasics.com";
            ((mshtml.IHTMLInputElement)pw.DomElement).value = "asdfqwer1234";

            //Execute the submit button
            doc.GetElementById("submit_button").InvokeMember("click");

        }
        void HandleMainPage()
        {
            //Get the document element
            HtmlDocument doc = webBrowser1.Document;
            //Get all of the anchors
            HtmlElementCollection ancs = doc.GetElementsByTagName("a");

            //Loop all
            foreach (HtmlElement anc in ancs)
            {
                //Get the DOM element
                dynamic domele = anc.DomElement;

                //Execute the click on the first instance of signup
                if (domele.href == "https://twitter.com/signup")
                {
                    anc.InvokeMember("click");
                    break; // TODO: might Not be correct. Was : Exit For
                }
            }
        }

       
    }
}
