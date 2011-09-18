using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace GOMstreamer
{
    public partial class MainWindow : Form
    {
        Version VERSION = new Version("0.7.1");
        string emailAddress = "";
        string userPassword = "";
        string vlcLocation = "";
        string dumpLocation = "";
        string streamUrlLocation = "";
        string streamQuality = "SQTest";
        string mode = "Save";
        TimeSpan timeToWait;
        Timer streamDelayTimer = new Timer();
        CookieContainer cookieJar = new CookieContainer();
        bool isMinimised = false;
        bool isEvent = false;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void saveSettings(string settingsLocation)
        {
            XmlTextWriter writer = new XmlTextWriter(settingsLocation, new UTF8Encoding());
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("GOMstreamer");

            writer.WriteStartElement("emailAddress");
            writer.WriteString(emailAddress);
            writer.WriteEndElement();

            writer.WriteStartElement("userPassword");
            writer.WriteString(userPassword);
            writer.WriteEndElement();

            writer.WriteStartElement("vlcLocation");
            writer.WriteString(vlcLocation);
            writer.WriteEndElement();

            writer.WriteStartElement("dumpLocation");
            writer.WriteString(dumpLocation);
            writer.WriteEndElement();

            writer.WriteStartElement("streamQuality");
            writer.WriteAttributeString("index", cbStreamQuality.SelectedIndex.ToString());
            writer.WriteString(streamQuality);
            writer.WriteEndElement();

            writer.WriteStartElement("mode");
            writer.WriteAttributeString("index", cbMode.SelectedIndex.ToString());
            writer.WriteString(mode);
            writer.WriteEndElement();

            writer.WriteStartElement("frmKoreanHour");
            writer.WriteString(frmKoreanHour.Value.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("frmKoreanMinute");
            writer.WriteString(frmKoreanMinute.Value.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void loadSettings(string settingsLocation)
        {
            if (File.Exists(settingsLocation))
            {
                XmlTextReader reader = new XmlTextReader(settingsLocation);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "emailAddress")
                        {
                            emailAddress = reader.ReadElementContentAsString();
                            txtEmailAddress.Text = emailAddress;
                        }

                        if (reader.Name == "userPassword")
                        {
                            userPassword = reader.ReadElementContentAsString();
                            txtUserPassword.Text = userPassword;
                        }

                        if (reader.Name == "vlcLocation")
                        {
                            vlcLocation = reader.ReadElementContentAsString();
                            txtVlcLocation.Text = vlcLocation;
                        }

                        if (reader.Name == "dumpLocation")
                        {
                            dumpLocation = reader.ReadElementContentAsString();
                            txtDumpLocation.Text = dumpLocation;
                        }

                        if (reader.Name == "streamQuality")
                        {
                            cbStreamQuality.SelectedIndex = int.Parse(reader["index"]);
                            streamQuality = reader.ReadElementContentAsString();
                        }

                        if (reader.Name == "mode")
                        {
                            cbMode.SelectedIndex = int.Parse(reader["index"]);
                            mode = reader.ReadElementContentAsString();
                        }

                        if (reader.Name == "frmKoreanHour")
                        {
                            frmKoreanHour.Value = Decimal.Parse(reader.ReadElementContentAsString());
                        }

                        if (reader.Name == "frmKoreanMinute")
                        {
                            frmKoreanMinute.Value = Decimal.Parse(reader.ReadElementContentAsString());
                        }
                    }
                }
                reader.Close();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            txtVlcLocation.Text = "";

            // Setting default quality to SQTest
            cbStreamQuality.SelectedIndex = 0;
            streamQuality = cbStreamQuality.SelectedItem.ToString();

            // Setting default execution mode to 'Save'
            // Will set this back to 'Play' if I can pipe output to VLC correctly
            cbMode.SelectedIndex = 1;
            mode = cbMode.SelectedItem.ToString();

            // Disabling to avoid confusion, will enable once a stream URL has been collected
            txtStreamURL.Enabled = false;

            // Checking for the Program Files folder location on the OS
            string progfiles = Environment.GetEnvironmentVariable("ProgramFiles(x86)");

            if (progfiles != "")
            {
                txtVlcLocation.Text = progfiles + "\\VideoLAN\\VLC\\vlc.exe";
            }
            else
            {
                txtVlcLocation.Text = Environment.GetEnvironmentVariable("ProgramFiles") + "\\VideoLAN\\VLC\\vlc.exe";
            }

            // Setting the VLC location to the default location
            vlcLocation = txtVlcLocation.Text;

            // Set the default save location to be dump.ogm on the Desktop
            txtDumpLocation.Text = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop\\dump.ogm";
            dumpLocation = txtDumpLocation.Text;

            // Checking to see whether settings have been stored (insecurely) locally
            try
            {
                loadSettings("gomsettings.xml");
            }
            catch (Exception ex)
            {
                // Doing nothing here. Loading settings is merely a convenience.
            }

            // Checking for an update to GOMstreamer
            checkForUpdate();

            // Resetting label once update check has been made
            statusLabel.Text = "Ready.";
        }
        
        private void btnDumpLocation_Click(object sender, EventArgs e)
        {
            // Ensure that the saved file is an OGM file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Ogg Media (*.ogm)|*.ogm";
            sfd.Title = "Stream dump location";

            DialogResult clickedOK = sfd.ShowDialog();

            // Only assign class variables if the dialog was successful
            if (clickedOK == DialogResult.OK)
            {
                dumpLocation = sfd.FileName;
                txtDumpLocation.Text = dumpLocation;
            }
        }

        private void btnVlcLocation_Click(object sender, EventArgs e)
        {
            // Ensure that only VLC is found when the user searches for an executable
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "VLC Executable|vlc.exe";
            ofd.Title = "VLC Location";

            DialogResult clickedOK = ofd.ShowDialog();

            // Only assign class variables if the dialog was successful
            if (clickedOK == DialogResult.OK)
            {
                vlcLocation = ofd.FileName;
                txtVlcLocation.Text = vlcLocation;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            emailAddress = txtEmailAddress.Text;
            userPassword = txtUserPassword.Text;
            vlcLocation = txtVlcLocation.Text;
            dumpLocation = txtDumpLocation.Text;
            streamQuality = cbStreamQuality.SelectedItem.ToString();
            mode = cbMode.SelectedItem.ToString();
            string dumplocdir = dumpLocation.Substring(0, dumpLocation.LastIndexOf("\\"));
            
            // Getting rid of the old timer if the button was pressed more than once
            // otherwise we start counting down by more than 1 second at a time
            streamDelayTimer.Dispose();
            streamDelayTimer = new Timer();
            timeToWait = new TimeSpan();

            // Catch any exceptions and display the message if they're encountered.
            try
            {
                if (!File.Exists(vlcLocation))
                {
                    throw new WebException("Please choose a valid VLC location.");
                }

                if (!Directory.Exists(dumplocdir))
                {
                    throw new WebException("Please choose a valid location to save the stream to.");
                }
                if (File.Exists(dumpLocation))
                {
                    if (MessageBox.Show("File exists at the stream save location. Do you want to overwrite the file?",
                                    "Overwrite?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                        throw new Exception();
                }

                // Delaying execution until target KST if mode is set to 'Delayed Save'
                if (mode == "Delayed Save")
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    gomNotifyIcon.BalloonTipTitle = "GOMstreamer";
                    gomNotifyIcon.BalloonTipText = "GOMstreamer is still running, but will wait until the scheduled time to begin recording the stream.";
                    gomNotifyIcon.ShowBalloonTip(3000);
                    isMinimised = true;
                    delayStream();
                }
                else
                {
                    // Continuing execution...
                    grabStream();
                }
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message, "GOMstreamer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Ready.";
            }
            catch (Exception ex) { }

            // Storing settings in a text file for later.
            try
            {
                saveSettings("gomsettings.xml");
            }
            catch (Exception ex)
            { 
                // Not going to be bothering doing anything here.
                // Saving settings is not particularly important.
            }
        }
        
        private void grabStream()
        {
            dumpLocation = txtDumpLocation.Text;
            string streamUrl = getStreamURL();

            // If the user has changed the text field, update it with the correct value
            if (txtStreamURL.Text != streamUrl)
            {
                txtStreamURL.Text = streamUrl;
                txtStreamURL.Enabled = true;
            }

            // Run VLC with the correct arguments
            statusLabel.Text = "Executing wget.";

            string wgetCmd = "wget.exe";
            string wgetArgs = "";
            string combinedCmd = "";

            if (mode != "Play")
            {
                wgetArgs +=  "-U KPeerClient " + streamUrl + " -O \"" + dumpLocation + "\"";
                combinedCmd = wgetArgs;
            }

            Process cmd = new Process();
            cmd.StartInfo.FileName = wgetCmd;
            cmd.StartInfo.Arguments = combinedCmd;
            cmd.Start();

            // Resetting the label as all execution has been done
            statusLabel.Text = "Ready.";
        }

        private void delayStream()
        {
            // Parsing time from Korean time input
            int hour = (int) frmKoreanHour.Value;
            int minute = (int) frmKoreanMinute.Value;

            DateTime currentUtcTime = DateTime.UtcNow;
            DateTime currentKoreanTime = currentUtcTime.AddHours(9); // Korea is GMT+9
            DateTime targetKoreanTime = new DateTime(currentKoreanTime.Year,
                                                       currentKoreanTime.Month,
                                                       currentKoreanTime.Day,
                                                       hour,
                                                       minute,
                                                       0);

            // If we find that the current time in Korea is ahead of what we expect
            // then add a day to ensure that we don't end up with negative time or
            // a delay period greater than 24h
            if (currentKoreanTime > targetKoreanTime)
            {
                targetKoreanTime = new DateTime(currentKoreanTime.Year,
                                                currentKoreanTime.Month,
                                                currentKoreanTime.Day + 1,
                                                hour,
                                                minute,
                                                0);
            }

            timeToWait = (targetKoreanTime - currentKoreanTime);
            streamDelayTimer.Interval = 1000;
            streamDelayTimer.Tick += new EventHandler(OnDelayTick);
            streamDelayTimer.Enabled = true;
        }

        private void OnDelayTick(Object source, EventArgs e)
        {
            // Restoring from tray prior to recording
            if (timeToWait.TotalSeconds <= 60 && isMinimised)
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
            
            // Kill the timer if the time has been met
            if (timeToWait.TotalSeconds <= 0)
            {
                streamDelayTimer.Enabled = false;

                // Attempt to go ahead and grab the stream
                try
                {
                    // Continuing execution...
                    grabStream();
                }
                catch (WebException we)
                {
                    MessageBox.Show(we.Message, "GOMstreamer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = "Ready.";
                }
                catch (Exception ex) { }
            }
            else
            {
                // Subtracting the tick length, in this case 0h, 0m, 1s
                timeToWait -= new TimeSpan(0, 0, 1);

                string timeText = "";
                timeText += timeToWait.Hours > 0 ? " " + timeToWait.Hours + "h" : "";
                timeText += timeToWait.Minutes > 0 ? " " + timeToWait.Minutes + "m" : "";
                timeText += timeToWait.Seconds > 0 ? " " + timeToWait.Seconds + "s" : "";

                // Update the label with the current remaining time
                statusLabel.Text = "Waiting" + timeText + ".";
                gomNotifyIcon.Text = "GOMstreamer. Waiting" + timeText + ".";
            }
        }

        private void checkForUpdate()
        {
            statusLabel.Text = "Checking for updates.";

            string versionUrl = "http://sjp.co.nz/projects/gomstreamer/version.txt";
            HttpWebRequest versionRequest = (HttpWebRequest)WebRequest.Create(versionUrl);
            versionRequest.Method = "GET";
            versionRequest.Timeout = 15000;  // Ensuring no long wait if the webserver is down
            HttpWebResponse versionResponse = (HttpWebResponse)versionRequest.GetResponse();  // Grabbing live page
            StreamReader reader = new StreamReader(versionResponse.GetResponseStream(), Encoding.UTF8);
            string response = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            versionResponse.Close();

            Version latestVersion = new Version(response.Trim());

            if (latestVersion > VERSION)
            {
                MessageBox.Show("Your version of GOMstreamer is " +
                                VERSION.ToString() + ".\n\n" +
                                "The latest version is " +
                                latestVersion.ToString() + ".\n\n" +
                                "Download the latest version from http://sjp.co.nz/projects/gomstreamer/",
                                "GOMstreamer Update Available",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
            }

        }

        private string getSeasonURL(string gomtvUrl)
        {
            statusLabel.Text = "Collecting the latest season URL.";

            string seasonURL = getSeasonURL_gom(gomtvUrl);
            return seasonURL;
        }

        private string getSeasonURL_gom(string gomtvUrl)
        {
            statusLabel.Text = "Collecting the latest season URL from GOMtv.";

            HttpWebRequest homeRequest = (HttpWebRequest)WebRequest.Create(gomtvUrl);
            homeRequest.Method = "GET";
            homeRequest.Timeout = 15000;  // Ensuring no long wait if the webserver is down
            HttpWebResponse homeResponse = (HttpWebResponse)homeRequest.GetResponse();  // Grabbing live page
            StreamReader reader = new StreamReader(homeResponse.GetResponseStream(), Encoding.UTF8);
            string response = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            homeResponse.Close();

            // The home page has been collected. Now to parse for the current season
            Regex linkRegex = new Regex("<a href=\"([^\"]*)\" class=\"golive_btn");
            Match m = linkRegex.Match(response);
            string seasonUrl = "";

            if (m.Success)
            {
                seasonUrl = m.Groups[1].Value;
            }
            else
            {
                seasonUrl = getSeasonURL_sjp();
            }

            string currentSeasonUrl = gomtvUrl + seasonUrl;
            return currentSeasonUrl;
        }

        private string getSeasonURL_sjp()
        {
            statusLabel.Text = "Collecting the latest season URL from sjp.co.nz.";

            string seasonURL = "http://sjp.co.nz/projects/gomstreamer/season.txt";
            HttpWebRequest seasonReq = (HttpWebRequest)WebRequest.Create(seasonURL);
            seasonReq.Method = "GET";
            seasonReq.Timeout = 15000;  // Ensuring no long wait if the webserver is down
            HttpWebResponse seasonResponse = (HttpWebResponse)seasonReq.GetResponse();  // Grabbing season txt file
            StreamReader reader = new StreamReader(seasonResponse.GetResponseStream(), Encoding.UTF8);
            string response = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            seasonResponse.Close();

            string currentSeasonURL = response.Trim();
            return currentSeasonURL;
        }
        
        private string getStreamURL()
        {            
            string gomtvURL = "http://www.gomtv.net";
            string gomtvLiveUrl = getSeasonURL(gomtvURL);
            cookieJar = new CookieContainer();

            // Signing in
            signIn();

            // Now that we have the cookies that we need to authenticate further interaction
            // we should be able to load the Live page and grab the stream from there.
            statusLabel.Text = "Grabbing the 'Live' page.";

            HttpWebRequest liveRequest = (HttpWebRequest)WebRequest.Create(gomtvLiveUrl);
            liveRequest.Method = "GET";
            liveRequest.CookieContainer = cookieJar;
            liveRequest.Timeout = 15000;  // Ensuring no long wait if the webserver is down
            HttpWebResponse liveResponse = (HttpWebResponse)liveRequest.GetResponse();  // Grabbing live page
            StreamReader reader = new StreamReader(liveResponse.GetResponseStream(), Encoding.UTF8);
            string liveHtml = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            liveResponse.Close();

            // If a special event occurs, we know that the live page response
            // will just be some JavaScript that redirects the browser to the
            // real live page. We assume that the entireity of this JavaScript
            // is less than 200 characters long, and that real live pages are
            // more than that.
            if (liveHtml.Length < 200)
            {
                isEvent = true;

                // Grabbing the real live page URL
                gomtvLiveUrl = parseLivePageUrl(gomtvLiveUrl, liveHtml);
                HttpWebRequest eventLiveRequest = (HttpWebRequest)WebRequest.Create(gomtvLiveUrl);
                eventLiveRequest.Method = "GET";
                eventLiveRequest.CookieContainer = cookieJar;
                eventLiveRequest.Timeout = 15000;  // Ensuring no long wait if the webserver is down
                HttpWebResponse eventLiveResponse = (HttpWebResponse)eventLiveRequest.GetResponse();  // Grabbing live page
                StreamReader eventReader = new StreamReader(eventLiveResponse.GetResponseStream(), Encoding.UTF8);
                liveHtml = eventReader.ReadToEnd();
                eventReader.Close();
                eventReader.Dispose();
                eventLiveResponse.Close();

                // Most events are free and have both HQ and SQ streams, but
                // not SQTest. As a result, assume we really want SQ after asking
                // for SQTest, makes it more seamless between events and GSL.
                if (streamQuality == "SQTest")
                {
                    streamQuality = "SQ";
                    cbStreamQuality.SelectedIndex = 1;
                }
            }

            string goxUrl = parseGOXUrl(liveHtml);  // Getting the GOX XML file
            string httpStream = parseHTTPStream(goxUrl);  // Getting the HTTP stream from the GOX XML file
            streamUrlLocation = httpStream;
            return httpStream;
        }

        private void signIn()
        {
            statusLabel.Text = "Signing in.";

            string gomtvURL = "http://www.gomtv.net";
            string gomtvSignInURL = gomtvURL + "/user/loginProcess.gom";
            string httpEmail = HttpUtility.UrlEncode(emailAddress);  // The email & password will have special characters that need decoding
            string httpPass = HttpUtility.UrlEncode(userPassword);
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

        private string parseLivePageUrl(string gomtvLiveUrl, string eventHtml)
        {
            statusLabel.Text = "Redirecting to the Event's 'Live' page.";

            // The live page has been collected. Now to parse for the event's live page.
            Regex linkRegex = new Regex("\"(.*)\";");
            Match m = linkRegex.Match(eventHtml);
            string urlFromHtml = "";

            if (m.Success)
            {
                urlFromHtml = m.Groups[0].Value;
                urlFromHtml = urlFromHtml.TrimStart('\"');
                urlFromHtml = urlFromHtml.TrimEnd('\"', ';');
            }
            else
            {
                throw new WebException("Unable to parse the URL for the event's live page.");
            }

            // The event live page is referred to via a relative URL.
            // We need the event live URL (containing JS) to create the canonical URL.
            string[] urlPieces = gomtvLiveUrl.Split('/');
            urlPieces[urlPieces.Length - 1] = urlFromHtml;
            urlFromHtml = string.Join("/", urlPieces);
            return urlFromHtml;
        }

        private string parseGOXUrl(string liveHtml)
        {
            statusLabel.Text = "Parsing the 'Live' page for the GOX XML link.";

            // The live page has been collected. Now to parse for the stream via regex
            Regex linkRegex = new Regex("http://www.gomtv.net/gox[^;]+;");
            Match m = linkRegex.Match(liveHtml);
            string urlFromHtml = "";

            if (m.Success)
            {
                urlFromHtml = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse GOX XML URL from the live page.");
            }

            urlFromHtml = urlFromHtml.Replace("\" + playType + \"", streamQuality);
            urlFromHtml = Regex.Replace(urlFromHtml, "\"[^;]+;", "");

            Regex titleRegex = new Regex("this.title[^;]+;");
            m = titleRegex.Match(liveHtml);
            string titleFromHtml = "";

            if (m.Success)
            {
                titleFromHtml = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse stream title from the live page.");
            }

            titleRegex = new Regex("\"(.*)\"");
            m = titleRegex.Match(titleFromHtml);

            if (m.Success)
            {
                titleFromHtml = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse stream title from the live page.");
            }

            titleFromHtml = titleFromHtml.Replace("\"", "");
            string goxUrl = urlFromHtml + titleFromHtml;
            return goxUrl;
        }

        private string parseHTTPStream(string goxUrl)
        {
            statusLabel.Text = "Grabbing the GOX XML file.";

            // Now we have the link to the XML file that contains the actual stream link
            // Grabbing it now
            HttpWebRequest goxRequest = (HttpWebRequest)WebRequest.Create(goxUrl);
            goxRequest.Method = "GET";
            goxRequest.CookieContainer = cookieJar;  // Using the authenticated cookies
            HttpWebResponse goxResponse = (HttpWebResponse)goxRequest.GetResponse();  // Grabbing the GOX XML file
            StreamReader goxReader = new StreamReader(goxResponse.GetResponseStream(), Encoding.UTF8);
            string goxXml = goxReader.ReadToEnd();
            goxReader.Close();
            goxReader.Dispose();
            goxResponse.Close();

            if (goxXml == "1002")
                throw new WebException("Please purchase a premium ticket to watch higher quality streams. Use the 'SQTest' stream quality instead.");

            // Have the XML file, now to parse for the stream link
            statusLabel.Text = "Parsing the GOX XML file for the HTTP stream URL.";

            Regex goxRegex = new Regex("<REF href=\"([^\"]*)\"/>");
            Match m = goxRegex.Match(goxXml);
            string streamUrl = "";

            if (m.Success)
            {
                streamUrl = m.Groups[1].Value;
            }
            else
            {
                throw new WebException("Unable to parse gomcmd URL from the GOX XML file.");
            }

            // The stream link is much simpler to parse, all we need to do is clean up
            // the contents of the href in the XML
            if (!isEvent && (streamQuality == "HQ" || streamQuality == "SQ"))
            {
                streamUrl = HttpUtility.UrlDecode(streamUrl); // Creating a more readable stream URL
                streamUrl = streamUrl.Replace("&amp;", "&");  // Decoding &amp; HTML entity
                streamUrl = streamUrl.Replace(" ", "");  // Remove White Spaces, thanks Rolf
                return streamUrl;
            }

            goxRegex = new Regex("(http%3[Aa].+)&quot;");
            m = goxRegex.Match(goxXml);

            if (m.Success)
            {
                streamUrl = m.Groups[0].Value;
            }
            else
            {
                throw new WebException("Unable to parse HTTP stream from gomcmd URL.");
            }

            streamUrl = HttpUtility.UrlDecode(streamUrl); // Creating a more readable stream URL
            streamUrl = streamUrl.Replace("&amp;", "&");  // Decoding &amp; HTML entity
            streamUrl = streamUrl.Replace("&quot;", "");  // Removing an unnecessary HTML entity
            return streamUrl;
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = cbMode.SelectedItem.ToString();

            // Enabling and disabling controls that relate to the mode
            // of execution that is currently selected
            if (mode == "Delayed Save")
            {
                frmKoreanHour.Enabled = true;
                frmKoreanMinute.Enabled = true;
            }
            else
            {
                frmKoreanHour.Enabled = false;
                frmKoreanMinute.Enabled = false;
            }

            if (mode != "Play")
            {
                txtDumpLocation.Enabled = true;
                btnDumpLocation.Enabled = true;
                btnGo.Enabled = true;
            }
            else
            {
                txtDumpLocation.Enabled = false;
                btnDumpLocation.Enabled = false;
                btnGo.Enabled = false;
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox gsAbout = new AboutBox();
            gsAbout.Show();
        }

        private void gomNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            isMinimised = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
