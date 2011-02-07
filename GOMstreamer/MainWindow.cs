using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace GOMstreamer
{
    public partial class MainWindow : Form
    {
        string email = "";
        string pass = "";
        string vlcloc = "";
        string dumploc = "";
        string streamloc = "";
        string streamQuality = "SQTest";
        CookieContainer cookieJar = new CookieContainer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            txtVLCloc.Text = "";

            // Setting default quality to SQTest
            cbQuality.SelectedIndex = 0;
            streamQuality = cbQuality.SelectedItem.ToString();

            // Checking for the Program Files folder location on the OS
            string progfiles = Environment.GetEnvironmentVariable("ProgramFiles(x86)");

            if (progfiles != "")
            {
                txtVLCloc.Text = progfiles + "\\VideoLAN\\VLC\\vlc.exe";
            }
            else
            {
                txtVLCloc.Text = Environment.GetEnvironmentVariable("ProgramFiles") + "\\VideoLAN\\VLC\\vlc.exe";
            }

            // Setting the VLC location to the default location
            vlcloc = txtVLCloc.Text;

            // Set the default save location to be dump.ogm on the Desktop
            txtdumploc.Text = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop\\dump.ogm";
            dumploc = txtdumploc.Text;
        }
        
        private void btnDumpLoc_Click(object sender, EventArgs e)
        {
            // Ensure that the saved file is an OGM file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Ogg Media (*.ogm)|*.ogm";
            sfd.Title = "Stream dump location";

            DialogResult clickedOK = sfd.ShowDialog();

            // Only assign class variables if the dialog was successful
            if (clickedOK == DialogResult.OK)
            {
                dumploc = sfd.FileName;
                txtdumploc.Text = dumploc;
            }
        }

        private void btnVLCLoc_Click(object sender, EventArgs e)
        {
            // Ensure that only VLC is found when the user searches for an executable
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "VLC Executable|vlc.exe";
            ofd.Title = "VLC Location";

            DialogResult clickedOK = ofd.ShowDialog();

            // Only assign class variables if the dialog was successful
            if (clickedOK == DialogResult.OK)
            {
                vlcloc = ofd.FileName;
                txtVLCloc.Text = vlcloc;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text;
            pass = txtPassword.Text;
            vlcloc = txtVLCloc.Text;
            dumploc = txtdumploc.Text;
            streamQuality = cbQuality.SelectedItem.ToString();
            string dumplocdir = dumploc.Substring(0, dumploc.LastIndexOf("\\"));

            // Catch any exceptions and display the message if they're encountered.
            try
            {
                if (!File.Exists(vlcloc))
                {
                    throw new WebException("Please choose a valid VLC location.");
                }

                if (!Directory.Exists(dumplocdir))
                {
                    throw new WebException("Please choose a valid location to save the stream to.");
                }
                if (File.Exists(dumploc))
                {
                    if (MessageBox.Show("File exists at the stream save location. Do you want to overwrite the file?",
                                    "Overwrite?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                        throw new Exception();
                }

                saveStream();
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message, "GOMstreamer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { }
        }
        
        private void btnPlay_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text;
            pass = txtPassword.Text;
            vlcloc = txtVLCloc.Text;
            streamQuality = cbQuality.SelectedItem.ToString();

            // Catch any exceptions and display the message if they're encountered.
            try
            {
                if (! File.Exists(vlcloc))
                {
                    throw new WebException("Please choose a valid VLC location.");
                }

                playStream();
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message, "GOMstreamer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void saveStream()
        {
            dumploc = txtdumploc.Text;
            string streamURL = getStreamURL();

            // If the user has changed the text field, update it with the correct value
            if (txtStreamURL.Text != streamURL)
            {
                txtStreamURL.Text = streamURL;
            }

            // Run VLC with the correct arguments
            string vlcargs = "--http-caching=30000 " + streamURL +
                             " :demux=dump :demuxdump-file=\"" + dumploc + "\"" +
                             " vlc://quit";
            Process vlc = new Process();
            vlc.StartInfo.UseShellExecute = true;
            vlc.StartInfo.FileName = vlcloc;
            vlc.StartInfo.Arguments = vlcargs;
            vlc.Start();
        }

        private void playStream()
        {
            string streamURL = getStreamURL();

            // If the user has changed the text field, update it with the correct value
            if (txtStreamURL.Text != streamURL)
            {
                txtStreamURL.Text = streamURL;

            }

            // Run VLC with the correct arguments
            string vlcargs = "--http-caching=30000 " + streamURL +
                             " vlc://quit";
            Process vlc = new Process();
            vlc.StartInfo.UseShellExecute = true;
            vlc.StartInfo.FileName = vlcloc;
            vlc.StartInfo.Arguments = vlcargs;
            vlc.Start();
        }
        
        private string getStreamURL()
        {
            string gomtvURL = "http://www.gomtv.net";
            string gomtvLiveURL = gomtvURL + "/2011gstl1/live/";
            cookieJar = new CookieContainer();

            // Signing in
            signIn();

            // Now that we have the cookies that we need to authenticate further interaction
            // we should be able to load the Live page and grab the stream from there.
            HttpWebRequest liveReq = (HttpWebRequest)WebRequest.Create(gomtvLiveURL);
            liveReq.Method = "GET";
            liveReq.CookieContainer = cookieJar;
            liveReq.Timeout = 15000;  // Ensuring no long wait if the webserver is down
            HttpWebResponse liveResponse = (HttpWebResponse)liveReq.GetResponse();  // Grabbing live page
            StreamReader reader = new StreamReader(liveResponse.GetResponseStream(), Encoding.UTF8);
            string liveHTML = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            liveResponse.Close();

            string goxurl = parseGOXUrl(liveHTML);  // Getting the GOX XML file
            string httpStream = parseHTTPStream(goxurl);  // Getting the HTTP stream from the GOX XML file
            streamloc = httpStream;
            return httpStream;
        }

        private void signIn()
        {
            string gomtvURL = "http://www.gomtv.net";
            string gomtvSignInURL = gomtvURL + "/user/loginProcess.gom";
            string httpEmail = HttpUtility.UrlEncode(email);  // The email & password will have special characters that need decoding
            string httpPass = HttpUtility.UrlEncode(pass);
            string postdata = "rememberme=1&cmd=login&mb_username=" + httpEmail + "&mb_password=" + httpPass;  // Forming post data string
            byte[] byteArray = Encoding.UTF8.GetBytes(postdata);  // Send data with UTF-8 encoding
            
            // Signing into GOMtv
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(gomtvSignInURL);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;
            req.CookieContainer = cookieJar;

            // Sending login data to the correct URL
            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            dataStream.Dispose();
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            response.Close();

            // Checking to see for a failed sign-in
            if (cookieJar.Count == 0)
                throw new WebException("Authentication failed. Please check your username and password.");
        }

        private string parseGOXUrl(string liveHTML)
        {
            // The live page has been collected. Now to parse for the stream via regex
            Regex linkRegex = new Regex("http://www.gomtv.net/gox[^;]+;");
            Match m = linkRegex.Match(liveHTML);
            string urlFromHTML = "";

            if (m.Success)
            {
                urlFromHTML = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse GOX XML URL from the live page.");
            }

            urlFromHTML = urlFromHTML.Replace("\" + playType + \"", streamQuality);
            urlFromHTML = Regex.Replace(urlFromHTML, "\"[^;]+;", "");

            Regex titleRegex = new Regex("this.title[^;]+;");
            m = titleRegex.Match(liveHTML);
            string titleFromHTML = "";

            if (m.Success)
            {
                titleFromHTML = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse stream title from the live page.");
            }

            titleRegex = new Regex("\"(.*)\"");
            m = titleRegex.Match(titleFromHTML);

            if (m.Success)
            {
                titleFromHTML = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse stream title from the live page.");
            }

            titleFromHTML = titleFromHTML.Replace("\"", "");
            string goxurl = urlFromHTML + titleFromHTML;
            return goxurl;
        }

        private string parseHTTPStream(string goxurl)
        {
            // Now we have the link to the XML file that contains the actual stream link
            // Grabbing it now
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(goxurl);
            req.Method = "GET";
            req.CookieContainer = cookieJar;  // Using the authenticated cookies
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();  // Grabbing the GOX XML file
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string GOXxml = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            response.Close();

            if (GOXxml == "1002")
                throw new WebException("Please purchase a premium ticket to watch higher quality streams. Use the 'SQTest' stream quality instead.");

            // Have the XML file, now to parse for the stream link
            Regex goxRegex = new Regex("<REF href=\"([^\"]*)\"/>");
            Match m = goxRegex.Match(GOXxml);
            string streamURL = "";

            if (m.Success)
            {
                streamURL = m.Groups[1].Value;
            }
            else
            {
                throw new WebException("Unable to parse gomcmd URL from the GOX XML file.");
            }

            // The stream link is much simpler to parse, all we need to do is clean up
            // the contents of the href in the XML
            if (streamQuality == "HQ" || streamQuality == "SQ")
            {
                streamURL = HttpUtility.UrlDecode(streamURL); // Creating a more readable stream URL
                streamURL = streamURL.Replace("&amp;", "&");  // Decoding &amp; HTML entity
                return streamURL;
            }

            goxRegex = new Regex("(http%3[Aa].+)&quot;");
            m = goxRegex.Match(GOXxml);

            if (m.Success)
            {
                streamURL = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse HTTP stream from gomcmd URL.");
            }

            streamURL = HttpUtility.UrlDecode(streamURL); // Creating a more readable stream URL
            streamURL = streamURL.Replace("&amp;", "&");  // Decoding &amp; HTML entity
            streamURL = streamURL.Replace("&quot;", "");  // Removing an unnecessary HTML entity
            return streamURL;
        }
    }
}
