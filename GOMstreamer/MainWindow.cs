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
        Version VERSION = new Version("0.10.1");
        int numberOfStreams = 0;
        string emailAddress = "";
        string userPassword = "";
        string vlcLocation = "";
        string dumpLocation = "";
        string[] streamUrlLocations = { "" };
        string streamQuality = "SQTest";
        string streamChoice = "First";
        string mode = "Save";
        string[] dumpLocations = { "", "" };
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

            writer.WriteStartElement("streamChoice");
            writer.WriteAttributeString("index", cbStreamSelection.SelectedIndex.ToString());
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
                        }

                        if (reader.Name == "streamQuality")
                        {
                            cbStreamQuality.SelectedIndex = int.Parse(reader["index"]);
                            streamQuality = reader.ReadElementContentAsString();
                        }

                        if (reader.Name == "streamChoice")
                        {
                            cbStreamSelection.SelectedIndex = int.Parse(reader["index"]);
                            streamChoice = reader.ReadElementContentAsString();
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
            this.Name = "MainWindow";
            this.Resize += new EventHandler(MainWindow_Resize);

            // Setting default quality to SQTest
            cbStreamQuality.SelectedIndex = 0;
            streamQuality = cbStreamQuality.SelectedItem.ToString();

            // Setting default execution mode to 'Play'
            cbMode.SelectedIndex = 0;
            mode = cbMode.SelectedItem.ToString();

            // By default, choose the first stream that we can find
            cbStreamSelection.SelectedIndex = 0;
            streamChoice = cbStreamSelection.SelectedItem.ToString();            

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
            btnGo.Enabled = false;
            emailAddress = txtEmailAddress.Text;
            userPassword = txtUserPassword.Text;
            vlcLocation = txtVlcLocation.Text;
            dumpLocation = Path.GetTempFileName();
            streamQuality = cbStreamQuality.SelectedItem.ToString();
            streamChoice = cbStreamSelection.SelectedItem.ToString();
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
                if (! File.Exists(vlcLocation))
                {
                    throw new WebException("Please choose a valid VLC location.");
                }

                // Delaying execution until target KST if mode is set to 'Scheduled Play'
                if (mode == "Scheduled Play")
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    gomNotifyIcon.BalloonTipTitle = "GOMstreamer";
                    gomNotifyIcon.BalloonTipText = "GOMstreamer is still running, but will wait until the scheduled time to begin playing the stream.";
                    gomNotifyIcon.ShowBalloonTip(3000);
                    isMinimised = true;
                    delayStream();
                }
                else
                {
                    // Continuing execution...
                    grabStream();
                }

                btnGo.Enabled = true;
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message, "GOMstreamer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Ready.";
                btnGo.Enabled = true;
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

        private void killWget()
        {
            foreach (Process p in Process.GetProcessesByName("wget"))
            {
                try
                {
                    p.Kill();
                    p.WaitForExit(); // possibly with a timeout
                }
                catch (Exception ex)
                {
                    // process was terminating or can't be terminated - deal with it
                }
            }
        }

        private void vlcExecutePlayStream(object source, System.Timers.ElapsedEventArgs e)
        {
            Process cmd0 = new Process();
            Process cmd1 = new Process();
            cmd0.StartInfo.FileName = vlcLocation;
            cmd0.StartInfo.Arguments = "--file-caching 10000 \"" + dumpLocations[0] + "\" - vlc://quit";
            cmd0.Start();

            if (numberOfStreams > 1)
            {
                cmd1.StartInfo.FileName = vlcLocation;
                cmd1.StartInfo.Arguments = "--file-caching 10000 \"" + dumpLocations[1] + "\" - vlc://quit";
                cmd1.Start();
            }

            // Now that wget is up and running for both streams
            // wait until they're both done, then remove temp files
            cmd0.WaitForExit();
            cmd0.Close();
            killWget();
            File.Delete(dumpLocations[0]);

            if (numberOfStreams > 1)
            {
                cmd1.WaitForExit();
                cmd1.Close();
                killWget();
                File.Delete(dumpLocations[1]);
            }

            statusLabel.Text = "Ready.";
        }

        private void grabStream()
        {
            string[] streamUrls = getStreamURLs();

            // Run VLC with the correct arguments
            statusLabel.Text = "Executing wget.";

            string wgetCmd = "wget.exe";
            string wgetArgs = "";
            string[] combinedCmd = new string[numberOfStreams];
            System.Timers.Timer vlcTimer = new System.Timers.Timer(10000);
            vlcTimer.Elapsed += new System.Timers.ElapsedEventHandler(vlcExecutePlayStream);
            vlcTimer.AutoReset = false;
            vlcTimer.Start();

            if (streamChoice == "First" || streamChoice == "Alternate")
            {
                wgetArgs = "-U KPeerClient --tries 10 \"" + streamUrls[0] + "\" -O \"" + dumpLocation + "\"";
                dumpLocations[0] = dumpLocation;
                combinedCmd = new string[] { wgetArgs };

                Process cmd = new Process();
                cmd.StartInfo.FileName = wgetCmd;
                cmd.StartInfo.Arguments = combinedCmd[0];
                cmd.Start();
                cmd.WaitForExit();
                File.Delete(dumpLocation);
            }
                
            if (streamChoice == "Both")
            {
                string tmpLoc = "";
                for (int i = 0; i < numberOfStreams; i++)
                {
                    // In the case when we're grabbing two streams simultaneously
                    // assume the second stream dump location is simply the specified filename
                    // with a prepended string.
                    if (i > 0)
                    {
                        string[] splitLoc = dumpLocation.Split('\\');
                        splitLoc[(splitLoc.Length - 1)] = "alternate-" + splitLoc[(splitLoc.Length - 1)];
                        tmpLoc = String.Join("\\", splitLoc);
                    }
                    else
                    {
                        tmpLoc = dumpLocation;
                    }
                    dumpLocations[i] = tmpLoc;
                    wgetArgs = "-U KPeerClient --tries 10 \"" + streamUrls[i] + "\" -O \"" + tmpLoc + "\"";
                    combinedCmd[i] = wgetArgs;
                }
            }

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

            string versionUrl = "http://sjp.co.nz/projects/gomstreamer/version-win.txt";
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

        private string getSeasonURL(string gomtvUrl, string method)
        {
            statusLabel.Text = "Collecting the latest season URL.";
            string seasonUrl = "";

            if (method == "url")
                seasonUrl = "/main/goLive.gom";
            else if (method == "html")
                seasonUrl = getSeasonURL_gom(gomtvUrl);
            else
                seasonUrl = getSeasonURL_sjp();

            return gomtvUrl + seasonUrl;
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
            Regex linkRegex = new Regex(".*liveicon\"><a href=\"([^\"]*)\"");
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

            string currentSeasonUrl = seasonUrl;
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
        
        private string[] getStreamURLs()
        {            
            string gomtvURL = "http://www.gomtv.net";
            string gomtvLiveUrl = getSeasonURL(gomtvURL, "url");
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

            string[] goxUrls = parseGOXUrls(liveHtml);  // Getting the GOX XML file
            string[] httpStreams = parseHTTPStreams(goxUrls);  // Getting the HTTP stream from the GOX XML file
            streamUrlLocations = httpStreams;
            return httpStreams;
        }

        private void signIn()
        {
            statusLabel.Text = "Signing in.";

            string gomtvSignInURL = "https://ssl.gomtv.net/userinfo/loginProcess.gom";
            string httpEmail = HttpUtility.UrlEncode(emailAddress);  // The email & password will have special characters that need decoding
            string httpPass = HttpUtility.UrlEncode(userPassword);
            string postdata = "rememberme=1&cmd=login&mb_username=" + httpEmail + "&mb_password=" + httpPass;  // Forming post data string
            byte[] byteArray = Encoding.UTF8.GetBytes(postdata);  // Send data with UTF-8 encoding
            
            // Signing into GOMtv
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(gomtvSignInURL);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;
            req.Referer = "http://www.gomtv.net/";
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

        private string[] parseGOXUrls(string liveHtml)
        {
            statusLabel.Text = "Parsing the 'Live' page for the GOX XML link.";

            // The live page has been collected. Now to parse for the stream via regex
            Regex linkRegex = new Regex("[^/]+var.+(http://www.gomtv.net/gox[^;]+;)");
            Match m = linkRegex.Match(liveHtml);
            string urlFromHtml = "";

            if (m.Success)
            {
                    urlFromHtml = m.Groups[1].Value;
                    urlFromHtml = urlFromHtml.Replace("\" + playType + \"", streamQuality);
            }
            else
            {
                throw new WebException("Unable to parse GOX XML URL from the live page.");
            }

            Regex titleRegex = new Regex("this.title[^;]+;");
            m = titleRegex.Match(liveHtml);
            string titleFromHtml = "";

            if (m.Success)
            {
                titleFromHtml = m.Groups[0].Value;
                titleRegex = new Regex("\"(.*)\"");
                m = titleRegex.Match(titleFromHtml);

                if (m.Success)
                {
                    titleFromHtml = m.Groups[0].Value;
                    titleFromHtml = titleFromHtml.Replace("\"", "");
                    urlFromHtml = Regex.Replace(urlFromHtml, "tmpThis.title[^;]+;", titleFromHtml);
                    urlFromHtml = urlFromHtml.Replace("\"+ ", "");
                }
                else
                {
                    throw new WebException("Unable to parse stream title from the live page.");
                }
            }
            else
            {
                throw new WebException("Unable to parse stream title from the live page.");
            }

            Regex liveRegex = new Regex(@"<a\shref=""/live/index.gom\?conid=(?<conid>\d+)""\sclass=""live_now""\stitle=""(?<title>[^""]+)");
            MatchCollection mc = liveRegex.Matches(liveHtml);
            numberOfStreams = Math.Max(1, mc.Count);

            if (numberOfStreams > 1)
            {
                string[] goxUrls = new string[numberOfStreams];
                for (int i = 0; i < numberOfStreams; i++)
                {
                    m = mc[i];
                    string singleUrlFromHtml = Regex.Replace(urlFromHtml, "conid=\\d+", "conid=" + m.Groups["conid"].Value);
                    string singleTitleHTML = string.Join("+", m.Groups["title"].Value.Split(' '));
                    singleUrlFromHtml = Regex.Replace(singleUrlFromHtml, "title=[\\w|.|+]*", "title=" + singleTitleHTML);
                    goxUrls[i] = singleUrlFromHtml;
                }

                // Assuming that #streams at most 2.
                if (streamChoice == "First" || streamChoice == "Alternate")
                    numberOfStreams = 1;
                if (streamChoice == "First")
                    return new string[] { goxUrls[0] };
                if (streamChoice == "Alternate")
                    return new string[] { goxUrls[1] };
                return goxUrls; // Alternate case where we want both streams
            }
            else
            {
                return new string[] { urlFromHtml };
            }
        }

        private string[] parseHTTPStreams(string[] goxUrls)
        {
            statusLabel.Text = "Grabbing the GOX XML file.";

            string[] goxXmls = new string[numberOfStreams];
            for (int i = 0; i < numberOfStreams; i++)
            {
                string goxUrl = goxUrls[i];
                // Now we have the link to the XML file that contains the actual stream link
                
                bool validGoxUrl = false;
                while (!validGoxUrl)
                {
                    // Grabbing GOX XML file now
                    HttpWebRequest goxRequest = (HttpWebRequest)WebRequest.Create(goxUrl);
                    goxRequest.Method = "GET";
                    goxRequest.CookieContainer = cookieJar;  // Using the authenticated cookies
                    HttpWebResponse goxResponse = (HttpWebResponse)goxRequest.GetResponse();  // Grabbing the GOX XML file
                    StreamReader goxReader = new StreamReader(goxResponse.GetResponseStream(), Encoding.UTF8);
                    goxXmls[i] = goxReader.ReadToEnd();
                    goxReader.Close();
                    goxReader.Dispose();
                    goxResponse.Close();

                    if (goxXmls[i] == "1002" | goxXmls[i] == "")
                    {
                        // If we do not have access to the higher quality streams
                        // because of a lack of a premium ticket, step the quality down
                        // a notch and try again.
                        if (streamQuality == "HQ")
                            streamQuality = "SQ";
                        else if (streamQuality == "SQ")
                            streamQuality = "SQTest";
                        else
                        {
                            String exText = "";
                            if (streamChoice == "First")
                                exText = "Unable to use the 'First' stream without a premium account.\n\nTry using the 'Alternate' stream instead.";
                            if (streamChoice == "Alternate")
                                exText = "Unable to use the 'Alternate' stream without a premium account.\n\nTry using the 'First' stream instead.";
                            if (streamChoice == "Both")
                                exText = "Unable to use one of the streams without a premium account.\n\nTry using one of 'First' or 'Alternate'.";
                            throw new WebException(exText);
                        }
                    }
                    else
                    {
                        validGoxUrl = true;
                    }
                }
            }
            
            // Have the XML file, now to parse for the stream link
            statusLabel.Text = "Parsing the GOX XML file(s) for the HTTP stream URL.";
            string[] streamUrls = new string[numberOfStreams];

            Regex goxRegex = new Regex("<REF href=\"([^\"]*)\"\\s/>");
            for (int i = 0; i < numberOfStreams; i++)
            {
                string goxXml = goxXmls[i];
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
                    streamUrls[i] = streamUrl;
                }
                else
                {
                    Regex sqtestRegex = new Regex("(http%3[Aa].+)&quot;");
                    m = sqtestRegex.Match(goxXml);

                    if (m.Success)
                    {
                        streamUrl = m.Groups[0].Value;
                    }
                    else
                    {
                        throw new WebException("Unable to parse HTTP stream from gomcmd URL.");
                    }

                    streamUrl = HttpUtility.UrlDecode(streamUrl); // Creating a more readable stream URL
                    streamUrl = streamUrl.Replace(" ", "+");      // UrlDecode turns +'s into spaces, undo it
                    streamUrl = streamUrl.Replace("&amp;", "&");  // Decoding &amp; HTML entity
                    streamUrl = streamUrl.Replace("&quot;", "");  // Removing an unnecessary HTML entity
                    streamUrls[i] = streamUrl;
                }
            }
            return streamUrls;
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = cbMode.SelectedItem.ToString();

            // Enabling and disabling controls that relate to the mode
            // of execution that is currently selected
            if (mode == "Scheduled Play")
            {
                frmKoreanHour.Enabled = true;
                frmKoreanMinute.Enabled = true;
            }
            else
            {
                frmKoreanHour.Enabled = false;
                frmKoreanMinute.Enabled = false;
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox gsAbout = new AboutBox();
            gsAbout.Show();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.isMinimised = true;
            }
        }

        private void gomNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.isMinimised) // restore
            {
                this.isMinimised = false;
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
            else // min
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.isMinimised = true;
            }
        }
    }
}
