using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;



namespace RideTheLamps
{
    public partial class Form1 : Form
    {
        string line = "";        
        delegate void LampSelNotifier();
        LampSelNotifier MyNotifier;
        
        public ConcurrentQueue<char> serialDataQueue;

        private static string WS_url = "http://192.168.0.100";
        private static string usrKey = "cNj0Rz4LRnNgawBVYwU2JPhJZ3nawoz2p9oINbxx";
        static Uri url = null;
        static bool status = false;
        int Xval=50, Yval=50;
        static bool canEnter = true;
        bool nomore = true;
        static string currentLamp = "/lights/1/state";
        static int Lamp = 1;                

        static int Lamp1Color = 47000;
        static int Lamp2Color = 25500;
        static int Lamp3Color = 5500;
        static int LampAlertColor = 65000;

        static float bri_range = 2.5f;

        private System.Timers.Timer timer, timer2;

        public Form1()
        {
            InitializeComponent();
            serialDataQueue = new ConcurrentQueue<char>();

            timer = new System.Timers.Timer();            
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 250;

            timer2 = new System.Timers.Timer();            
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed2);
            timer2.Interval = 300;            

            MyNotifier = notifyLampSelected;
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {    
            SerialPort sp = sender as SerialPort;
            int bytesAvailable = sp.BytesToRead;

            char[] recBuf = new char[bytesAvailable];
            try
            {
                sp.Read(recBuf, 0, bytesAvailable);
                for (int index = 0; index < bytesAvailable; index++)
                    serialDataQueue.Enqueue(recBuf[index]);
            }
            catch (Exception eee) { }

            readSerialDequeue();
        }

        void readSerialDequeue()
        {
            char ch;
            try
            {
                while (serialDataQueue.TryDequeue(out ch))
                {             
                    if (ch.Equals('\n'))
                    {
                        if(canEnter)
                        {
                            ReadDataFrame();                            
                        }
                        line = "";
                    }
                    else
                        line += ch;
                }
            }
            catch (Exception e) { }
        }


        public void ReadDataFrame()
        {
            Ldataframe.Invoke(new Action(delegate()
            {
                Ldataframe.Text = line;
            }));            
            
            //---REMOVE DATAFRAME FORMATTING CHARACTERS-----
            line = line.Replace('!', ' ');
            line = line.Replace('#',' ');
            string[] metadata = line.Split(new char[]{' '},5);
            metadata[4] = metadata[4].TrimEnd(new Char[] { ' ' });
           
            Int32.TryParse(metadata[1].TrimStart(new Char[] { '0' }), out Xval);
            Int32.TryParse(metadata[2].TrimStart(new Char[] { '0' }), out Yval);

            nomore = true;

            //-TURNING LIGHT SOURCE ON/OFF USING HAND SWIPES--
            //----BACKWARD-> TURNS ON---FORWARD-> TURNS OFF---
            //------------------------------------------------          
            if (metadata[4].Length > 3)
            {
                if (metadata[4].Substring(3, 1).Contains("B"))
                {
                    SendCMD("on", "true");                    
                    nomore = false;
                }
                else if (metadata[4].Substring(3, 1).Contains("F"))
                {
                    SendCMD("on", "false");                    
                    nomore = false;
                }
            }                        

            //------ACTIVE LIGHT SOURCE SELECTION METHODS-----
            //------------------------------------------------
            if (RBsm1.Checked && nomore)
            {
                if (metadata[4].Equals("4FJ") && Xval > 60 && canEnter)
                {                    
                    currentLamp = "/lights/2/state";
                    Lamp = 2;                    
                    MyNotifier();                                        
                    nomore = false;
                }
                else if (metadata[4].Equals("4FJ") && Xval < 40 && canEnter)
                {                    
                    currentLamp = "/lights/1/state";
                    Lamp = 1;                    
                    MyNotifier();
                    nomore = false;
                }
                else if (metadata[4].Equals("2FS") && canEnter)
                {                    
                    //currentLamp = "/groups/0/action";
                    Lamp = 4;                    
                    MyNotifier();
                    nomore = false;
                }
            }
            else if (RBsm2.Checked && nomore)
            {
                if (metadata[4].Equals("1FS") && canEnter)
                {                    
                    currentLamp = "/lights/1/state";
                    Lamp = 1;                    
                    MyNotifier();
                    nomore = false;
                }
                else if (metadata[4].Equals("2FS") && canEnter)
                {                   
                    currentLamp = "/lights/2/state";
                    Lamp = 2;                    
                    MyNotifier();
                    nomore = false;
                }
                else if (metadata[4].Equals("2FJ") && canEnter)
                {                    
                    //currentLamp = "/groups/0/action";
                    Lamp = 4;                    
                    MyNotifier();
                    nomore = false;
                }
            }
           
            canEnter = nomore;

            if (canEnter == false)
                timer2.Start();

            //------------------------------------------------
            int Lthres = 4;
            //--BRIGHTNESS ADJUSTMENT BY CONTIUNUOUS GESTURES-
            if (metadata[3].Equals("1FS") && nomore && RBsm1.Checked)
            {
                if (counter > Lthres)
                {
                    if (RBx.Checked)
                        SendCMD("bri", ((int)(bri_range * (double)Xval)).ToString());                     
                    else
                        SendCMD("bri", ((int)(bri_range * (double)Yval)).ToString());                   
                    counter = 0;
                }

                counter++;
            }

            if (metadata[3].Equals("4FJ") && nomore && RBsm2.Checked)
            {
                if (counter > Lthres)
                {
                    if (RBx.Checked)
                        SendCMD("bri", ((int)(bri_range * (double)Xval)).ToString());
                    else
                        SendCMD("bri", ((int)(bri_range * (double)Yval)).ToString());  
                    counter = 0;
                }

                counter++;
            }

        }
        int counter = 0;
        public void notifyLampSelected()
        {            
            timer.Start();            
        }

        
        async static void setLight(string myQuerry)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();            
            var content = new StringContent(myQuerry, Encoding.UTF8, "application/json");

            try
            {
                url = new Uri(WS_url + "/api/" + usrKey + currentLamp);
                HttpResponseMessage returnStatement = await client.PutAsync(url, content);
                string res = await returnStatement.Content.ReadAsStringAsync();
                Console.WriteLine("Return Statment:" + res);                
            }
            catch (Exception e) { }            
        }

        private void Bstart_Click(object sender, EventArgs e)
        {
            initialState();

            serialPort1.ReceivedBytesThreshold = 10;

            if (!serialPort1.IsOpen)
                serialPort1.Open(); 
        }
        int nLSc = 0;
        int mcnt = 0;
        int mean_lvl = 60;
        int max_lvl = 150;

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {            
            if (mcnt == 0)
            {
                if (Lamp == 1)
                    SendCMD("on", "true", "bri", (mean_lvl).ToString(), "hue", (Lamp1Color).ToString(), "sat", "155");
                else
                    SendCMD("on", "true", "bri", (mean_lvl).ToString(), "hue", (Lamp2Color).ToString(), "sat", "155");
            }
            else if (mcnt == 1)
            {
                SendCMD("bri", (max_lvl).ToString(), "hue", (LampAlertColor).ToString(), "sat", "254");
            }
            else if (mcnt == 2)
            {
                if (Lamp == 1)
                    SendCMD("bri", (mean_lvl).ToString(), "hue", (Lamp1Color).ToString(), "sat", "155");
                else
                    SendCMD("bri", (mean_lvl).ToString(), "hue", (Lamp2Color).ToString(), "sat", "155");
            }
            else
            {
                mcnt = -1;
                timer.Stop();                
            }
            mcnt++;

        }

        int nCNTR=0;
        private void timer_Elapsed2(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (nCNTR == 0)
            {

            }else if (nCNTR == 1)
            {
                canEnter = true;
                nCNTR = 0;
                timer2.Stop();
            }
            nCNTR++;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("no {0}", mcnt);
         
            if (mcnt == 0)
            {                
                if(Lamp==1)                    
                    SendCMD("on","true", "bri", (mean_lvl).ToString(), "hue", (Lamp1Color).ToString(), "sat", "155");
                else
                    SendCMD("on", "true", "bri", (mean_lvl).ToString(), "hue", (Lamp2Color).ToString(), "sat", "155");
            }
            else if (mcnt == 1)
            {                                
                    SendCMD("bri", (max_lvl).ToString(), "hue", (LampAlertColor).ToString(), "sat", "254");
            }
            else if (mcnt == 2)
            {
                if (Lamp == 1)
                    SendCMD("bri", (mean_lvl).ToString(), "hue", (Lamp1Color).ToString(), "sat", "155");
                else
                    SendCMD("bri", (mean_lvl).ToString(), "hue", (Lamp2Color).ToString(), "sat", "155");
            }         
            else
            {
                mcnt = -1;
                timer1.Stop();
                Console.WriteLine("no exit {0}", mcnt);
            }
            mcnt++;
        }

        private void Bblink_Click(object sender, EventArgs e)
        {
            MyNotifier();
        }
      
        void initialState()
        {         
            currentLamp = "/lights/2/state";
                SendCMD("on", "true", "hue", (Lamp2Color).ToString(), "bri", (100).ToString(), "sat", "195");
                    System.Threading.Thread.Sleep(125);
            currentLamp = "/lights/1/state";
                SendCMD("on", "true", "hue", (Lamp1Color).ToString(), "bri", (100).ToString(), "sat", "195");
        }

        void SendCMD(params string[] pars)
        {
            String myJson = "{";            

            int LEN = pars.Length;
            for (int i = 0; i<LEN; i+=2)
            {
                myJson += "\"" + pars[i] + "\":" + pars[i+1];
                if (i + 2 < LEN)
                    myJson += ",";
            }
            myJson += "}";

            if (Lamp == 4)
            {
                currentLamp = "/lights/1/state";
                setLight(myJson);
                    System.Threading.Thread.Sleep(125);
                currentLamp = "/lights/2/state";
                setLight(myJson);                
            }
            else
                setLight(myJson);
        }      

        private void Breset1_Click(object sender, EventArgs e)
        {             
            currentLamp = "/lights/2/state";
            SendCMD("hue", (10000).ToString(), "bri", (150).ToString(), "sat", "0"); ;        
        }

        private void Breset2_Click(object sender, EventArgs e)
        {
            currentLamp = "/lights/1/state";
            SendCMD("hue", (10000).ToString(), "bri", (150).ToString(), "sat", "0"); 
        }
    }
}
