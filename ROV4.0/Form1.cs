using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using SlimDX.DirectInput;
using System.Net.Sockets;
using System.Linq;
using System.Drawing;
using System.IO.Ports;

/*
 * TODO:
 * ADD Trim functionality
 * ADD Reverse direction
 * ADD the saving functionality for reverses
 * 
 */
namespace ROV4
{
    public partial class Form1 : Form
    {
        int ltTrim = 0;
        int rtTrim = 0;
        int v1Trim = 0;
        int v2Trim = 0;
        TcpClient tcpclnt;
        Stream stream;
        DirectInput input = new DirectInput();
        SlimDX.DirectInput.Joystick stick;
        static Joystick[] sticks;
        Thread pollThread;
        int x = 0;
        int y = 0;
        int z = 0;
        char divider = '\t';
       

        public void poll()
        {
            while (true)
            {
                if (stick != null)
                {
                    if (input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly).ToArray().Length > 0)
                    {
                        stickHandle(stick);
                    }
                    else
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            debug.Text += "Controller Disconnected";
                        }));
                        stick = null;
                        sticks = GetSticks();
                    }
                }
                else
                {
                    try
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            debug.Text += "Controller Disconnected";
                        }));
                        sticks = GetSticks();
                    }
                    catch (Exception e) { }
                }
                Thread.Sleep(13);
            }
        }

        public Joystick[] GetSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            // List<Microsoft.DirectX.DirectInput.Joystick> mSticks = new List<Microsoft.DirectX.DirectInput.Joystick>();
            foreach (DeviceInstance device in input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(input, device.InstanceGuid);
                    stick.Acquire();
                    sticks.Add(stick);
                    Invoke(new MethodInvoker(delegate
                    {
                        debug.Text = "Controller Connected.";
                        /*foreach (bool btn in buttons) {
                            controlOut.Text += (btn ? "t " : "f ") ;
                        }*/

                    }));
                }
                catch (InvalidOperationException e) { debug.Text += "E: Controller Connected."; }
            }
            return sticks.ToArray();
        }

        int pwr(int pwr, int trim, bool invert, double stretchFactor)
        {
            int power;
            if (invert)
            {
                power = 3000 - pwr;
            }
            else
            {
                power = pwr;
            }
            if (power >= 1500)
            {
                 power = Math.Max(power+trim, 1500);
                return (int)(stretchFactor * Math.Pow((power-1500), 2)+1500);
            }
            else
            {
                power = Math.Min(power+trim, 1500);
                return (int)(-stretchFactor * Math.Pow((power-1500), 2)+1500);
            }
        }

        int clawInertia = 0;
        int camInertia = 0;

        int lowDeadBand = 1100;//really min
        int highDeadBand = 1900;//really max
        int clawDeg = 14; //14-90;
        int camDeg = 30;
        int clawMs = 1000;
        int camMs = 1000;
        int deadBandH = 1530;
        int deadBandL = 1470;
        double lowRangeSF = 0.0025;//This is the Stretch Factor for the quadratic power for a 800 unit range.
        double highRangeSF = 0.002;//Stretch Factor for 1000 unit range.
        bool fr = false;
        bool lr = false; //keep track of forwards/back axis and left/right axis
                         //this makes it so you have to return stick to center to change from forward/back to left/right
        int selectedCam = 1;
        void stickHandle(Joystick stick)
        {
            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();
            x = state.X;
            y = state.Y;
            z = state.Z;
            //int ltPwr = (z / 82) + 1100;//these are NOT arbitrarily created numbers
            //int xPwr = (x / 82) + 1100;
            int ltPwr = ((y / 82) + 1100);//may need to change to a divisor of 65.536
            int rtPwr = (state.RotationZ/82) + 1100;
            int rightTrig = (state.RotationY / 164) + 1500;
            int leftTrig = 1500 - (state.RotationX / 164);//131
            bool[] buttons = state.GetButtons();

            Invoke(new MethodInvoker(delegate
            {
                //debug.Text = "X: "+xPwr;                   
            }));
            //handle cam switchbox

            if (serPort.IsOpen)
            {
                int pov = state.GetPointOfViewControllers()[0];
                if(pov == 9000)
                {
                    serPort.Write("2");
                }
                if(pov == 27000)
                {
                    serPort.Write("1");
                }
            }

            if (tcpclnt != null)
            {
                if (tcpclnt.Connected)
                {
                    String str = "";
                    str += ((ltPwr>1501 || ltPwr<1499) ? divider + "l" + pwr(ltPwr, ltTrim, !checkBox3.Checked, lowRangeSF) : "");
                    str += ((rtPwr>1501 || rtPwr<1499) ? divider + "r" + pwr(rtPwr, rtTrim, !checkBox4.Checked, lowRangeSF) : "");
                    bool up = (rightTrig > 1501);
                    if (up || !upStopped)
                    {
                        str += divider + "u" + pwr(rightTrig, v1Trim, checkBox1.Checked, lowRangeSF) + divider + "U" + pwr(rightTrig, v2Trim, checkBox2.Checked, lowRangeSF);
                        upStopped = !up;
                    }

                    bool down = (leftTrig < 1499);
                    if((down || !downStopped))
                    {
                        if (!up)
                        {
                            str += divider + "u" + pwr(leftTrig, v1Trim, checkBox1.Checked, lowRangeSF) + divider + "U" + pwr(leftTrig, v2Trim, checkBox2.Checked, lowRangeSF);
                            downStopped = !down;
                        }
                    }
                    else
                    {
                        //check for rolling
                        str += setRoll(buttons[4], buttons[5]);
                    }
                    str +=
                       // (buttons[3] && ((camMs+=4) < 1315)? divider + "w" + camMs: "") + (buttons[1]  && ((camMs-=4)>875)? divider + "w"+camMs : "") +
                        (buttons[8] ? divider + "s0000" : "") +
                         (//buttons[3] && ((camDeg)<89)? divider+"W" +camDeg++:"")+ (buttons[1] && ((camDeg)>15)? divider + "W" + camDeg--:"")+
                        //(buttons[2] && ((clawDeg)<89)? divider + "Q"+clawDeg++:"")+(buttons[0] && ((clawDeg)>15) ? divider+"Q + clawDeg--: "")+
                        //(buttons[2] && (clawMs+=4)<1315 ? divider + "q" + clawMs : "") + (buttons[0] && (clawMs-=4)>875? divider + "q" + clawMs: "") +//servo, adding this many degrees to position
                        checkForBuzzer(buttons[13]));
                    if (buttons[0] && clawInertia>=0)//send claw close
                    {
                        clawInertia = -1;
                        quickWrite( divider + "H"+clawInertia + divider + "\n");
                    }
                    else
                    {
                        if (!buttons[0] && clawInertia < 0)//stop the close
                        {
                            clawInertia = 0;
                            quickWrite( divider + "H"+clawInertia + divider + "\n");
                        }
                    }

                    if(buttons[2] && clawInertia <= 0)//claw open
                    {
                        clawInertia = 1;
                        quickWrite( divider + "H" + clawInertia + divider + "\n");//repetitive here so cmd only sent once
                    }
                    else
                    {
                        if (!buttons[2] && clawInertia > 0)//stop the open. Prolly better way to write this, since
                            //the stops are pretty much the same.
                        {
                            clawInertia = 0;
                            quickWrite( divider + "H" + clawInertia + divider + "\n");
                        }
                    }

                    //repeat for cam. Again, im prolly gonna hate myself for being this sloppy.
                    if (buttons[1] && camInertia >= 0)//claw close
                    {
                        camInertia = -1;
                        quickWrite( divider + "h" + camInertia + divider + "\n");
                    }
                    else
                    {
                        if (!buttons[1] && camInertia < 0)//stop the close
                        {
                            camInertia = 0;
                            quickWrite( divider + "h" + camInertia + divider + "\n");
                        }
                    }

                    if (buttons[3] && camInertia <= 0)//claw open
                    {
                        camInertia = 1;
                        quickWrite(divider + "h" + camInertia+divider+"\n");//repetitive here so cmd only sent once
                    }
                    else
                    {
                        if (!buttons[3] && camInertia > 0)//stop the open. Prolly better way to write this, since
                                            //the stops are pretty much the same.
                        {
                            camInertia = 0;
                            quickWrite( divider + "h" + camInertia + divider + "\n");
                        }
                    }

                    //str += checkForStop(xPwr, yPwr, zPwr);

                    quickWrite(str);

                }

            }

        }
        //pre condition, stream is open.
        void quickWrite(string str)
        {
            if (str.Length > 0)
            {

                str += divider + "\n";
                ASCIIEncoding asen = new ASCIIEncoding();
                Invoke(new MethodInvoker(delegate
                {
                    debug.Text = asen.GetString(asen.GetBytes(str));
                }));
                try
                {
                    byte[] ba = asen.GetBytes(str);
                    stream.Write(ba, 0, ba.Length);
                }
                catch (IOException e) { }
            }
        }

        bool rollingRight = false;
        bool rollingLeft = false;

        string setRoll(bool right, bool left)
        {
            string ret = "";
            if (right && !rollingRight)
            {
                ret = divider + "u1600" + divider+ "U1400";
            }
            if (!right && rollingRight)
            {
                ret = divider + "u1500" + divider + "U1500";
            }
            if (left && !rollingLeft)
            {
                ret = divider + "u1400" + divider + "U1600";
            }
            if (!left && rollingLeft)
            {
                ret = divider + "u1500" + divider + "U1500";
            }
            rollingLeft = left;
            rollingRight = right;
            return ret;
        }

        bool leftStopped = true;
        bool rightStopped = true;
        bool upStopped = true;
        bool downStopped = true;
        bool buzzerOn = false;

        string checkForBuzzer(bool button)
        {
            string retVal = "";
            if (!buzzerOn && button)
            {
                retVal += divider + "a0000";
                buzzerOn = true;
            }
            else if (buzzerOn && !button)
            {
                buzzerOn = false;
                retVal += divider + "a0000";
            }

            return retVal;
        }

        SerialPort serPort;

        public Form1()
        {
            InitializeComponent();
            //GetSticks();
            // sticks = GetSticks();
            pollThread = new Thread(poll);
            pollThread.Start();

            this.FormClosing += monClosing;
            ConnectBtn.Click += ConnectBtn_Click;
            // this.MouseMove += mouseMove;

            //Setup Onshore Arduino with Camera Switch
            serPort = new SerialPort();
            serPort.BaudRate = 9600;
            serPort.Parity = Parity.None;
            serPort.DataBits = 8;
            serPort.StopBits = StopBits.One;
            serPort.ReadTimeout = 50;
            serPort.WriteTimeout = 50;
            debug.Text = "SwitchBox not found.";
            foreach (string name in SerialPort.GetPortNames())
            {
                serPort.PortName = name;
                try
                {
                    serPort.Open();
                    serPort.Write("1");
                    if (serPort.ReadLine().Contains("SAAHDUDE"))
                    {
                        debug.Text = name;
                        break;
                    }
                }
                catch (IOException e) { serPort.Close(); }
                catch (TimeoutException e) { serPort.Close(); }
                
            }
        }

        public void monClosing(object ev, FormClosingEventArgs e)// a better cleanup
        {
            if (pollThread.IsAlive)
            {
                //stick.Dispose();
                pollThread.Abort();
            }
            if (tcpclnt != null)
            {
                tcpclnt.Close();
            }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            debug.Text = "Connected to ROV";
            if (tcpclnt != null)
            {
                tcpclnt.Close();
            }
            try
            {
                tcpclnt = new TcpClient();
                tcpclnt.SendTimeout = 500;

                tcpclnt.Connect(arduinoIP.Text, 1740);
                stream = tcpclnt.GetStream();
                stream.WriteTimeout = 500;
            }
            catch (Exception ex) { debug.Text = "Network Error"; }
        }


        int seconds = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            timer.Text = addZeros(seconds / 60, 2) + ":" + addZeros(seconds % 60, 2);
        }

        string addZeros(int num, int numOfDigits)
        {
            string ret = "";
            for (int i = numOfDigits - 1; i > -1; i--)
            {
                if ((num / (int)(Math.Pow(10, i))) == 0)
                {
                    ret += "0";
                }
                else
                {
                    ret += num.ToString();
                    i = -1;
                }
            }
            return ret;
        }

        private void button1_Click(object sender, EventArgs e)//Start/Stop
        {
            if (timer1.Enabled)
            {
                button1.Text = "Start";
                timer1.Stop();
            }
            else
            {
                button1.Text = "Stop";
                timer1.Interval = 1000;
                timer1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)//reset
        {
            seconds = 0;
            timer.Text = "00:00";
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            string name = ((ScrollBar)sender).Name;
            string str = "";

                    //str = divider + "t" + makeTrimValue(e.NewValue) + name.Substring(name.Length - 1) + divider;
             switch (name.Substring(name.Length - 1))
             {
                case "1":
                    v1Trim = e.NewValue;
                    break;
                case "2":
                    v2Trim = e.NewValue;
                    break;
                case "3":
                    ltTrim = e.NewValue;
                    break;
                case "6":
                    rtTrim = e.NewValue;
                    break;

             }
        }

        string makeTrimValue(int pwr)
        {
            string ret = "";
            if (pwr > 0)
            {
                ret += addZeros(pwr, 3);
            }
            else
            {
                ret += "-";
                ret += addZeros(Math.Abs(pwr), 2);
            }
            return ret;
        }

        bool saving = false;
        private void button3_Click(object sender, EventArgs e)//save
        {
            saving = true;
            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.FileName = "trims.txt";
            saveFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)//load
        {
            saving = false;
            saveFileDialog1.OverwritePrompt = false;
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (saving)
            {
                string str = "";
                ScrollBar bar;
                for (int i = 1; i < 4; i++)
                {
                    bar = this.Controls.Find("vScrollBar" + i, true).FirstOrDefault() as ScrollBar;
                    str += bar.Value + ",";

                }
                bar = this.Controls.Find("vScrollBar6", true).FirstOrDefault() as ScrollBar;
                str += bar.Value;
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    sw.WriteLine(str);


            }
            else
            {
                String trims;
                using (StreamReader sr = new StreamReader(saveFileDialog1.FileName))
                    trims = sr.ReadLine();
                string[] sValues = trims.Split(',');
                ScrollBar bar;
                for (int i = 1; i < 4; i++)
                {
                    bar = this.Controls.Find("vScrollBar" + i, true).FirstOrDefault() as ScrollBar;
                    bar.Value = int.Parse(sValues[i - 1]);
                    vScrollBar_Scroll((object)bar, new ScrollEventArgs(ScrollEventType.SmallIncrement, bar.Value));
                }
                bar = this.Controls.Find("vScrollBar6", true).FirstOrDefault() as ScrollBar;
                bar.Value = int.Parse(sValues[sValues.Length-1]);
                vScrollBar_Scroll((object)bar, new ScrollEventArgs(ScrollEventType.SmallIncrement, bar.Value));
            }
        }

        Pen pen = new Pen(Color.YellowGreen);
        private void LakeWashingtonMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            pen.Width = 2;
            //instructions.Text = "" + startX;
            if (startX != 0)
            {
                int aVecX = 0;//planeDistance0
                int aVecY = 0;
                double theta = ((double)dir)*(Math.PI/180);
                //double Distance0 = (planeDistance0 /1000)*pixelsPerKM;
                aVecY = (int)-((((Math.Cos(theta) * planeDistance0)/1000)*pixelsPerKM))+startY;
                aVecX = (int)(((Math.Sin(theta) * planeDistance0)/1000)*pixelsPerKM) + startX;
                g.DrawLine(pen, new Point(startX, startY), new Point(aVecX, aVecY));//ascent vector
                //descent vector
                pen.Color = Color.Red;
                startX = aVecX;
                startY = aVecY;
                int dVecX;
                int dVecY;
                dVecY = (int)-((((Math.Cos(theta) * planeDistance1) / 1000) * pixelsPerKM)) + startY;
                dVecX = (int)(((Math.Sin(theta) * planeDistance1) / 1000) * pixelsPerKM) + startX;
                g.DrawLine(pen, new Point(startX, startY), new Point(dVecX, dVecY));//descent vector
                //wind vector
                pen.Color = Color.Teal;
                startX = dVecX;
                startY = dVecY;
                int wX;
                int wY;
                theta = ((double)windDirectionI) * (Math.PI / 180);
                wY = (int)-((((Math.Cos(theta) * windDistance) / 1000) * pixelsPerKM) )+ startY;
                wX = (int)(((Math.Sin(theta) * windDistance) / 1000) * pixelsPerKM) + startX;
                g.DrawLine(pen, new Point(startX, startY), new Point(wX, wY));
                pen.Color = Color.YellowGreen;
            }
            else
            {
                
            }
        }

    
       // int calculationPhase = -2;
        int startX = 0;
        int startY = 0;
       // int scaleStart = 0;
        double pixelsPerKM = 20.7;
        int dir;
        double planeDistance0;
        double planeDistance1;
        int windDirectionI;
        double windDistance;
        private void calculate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                dir = Int16.Parse(heading.Text);
                double ascent_rateD = Double.Parse(ascent_rate.Text);
                int failureSeconds = Int16.Parse(failure_time.Text);
                double ascent_speedD = Double.Parse(ascent_speed.Text);
                double descent_speedD = Double.Parse(descent_speed.Text);
                double descent_rateD = Double.Parse(descent_rate.Text);
                double wind_speedD = Double.Parse(wind_speed.Text);
                double wind_directionR = Double.Parse(wind_direction.Text);

                double height = ascent_rateD * failureSeconds;
                planeDistance0 = round(ascent_speedD * failureSeconds, 2);//before failure vecotr
                planeDistance1 = round(descent_speedD * (height / descent_rateD), 2);//after failure vector
                windDistance = round(wind_speedD * (height / descent_rateD), 2);
                windDirectionI = (int)(wind_directionR < 180 ? wind_directionR + 180 : wind_directionR - 180);
                av.Text = "Ascent Vector: \n" + planeDistance0 + " meters\n" + dir + " degrees";
                dv.Text = "Descent Vector: \n" + planeDistance1 + " meters\n" + dir + " degrees";
                wv.Text = "Wind Vector: \n" + windDistance + " meters\n" + windDirectionI + " degrees";
                //calculationPhase = -1;
                instructions.Text = "Click the starting point.";
            }
            catch (Exception x) { instructions.Text = "Enter valid numbers, Dingus!"; }
        }

        double round(double x, int significantFigs)
        {
            x += (5 * Math.Pow(10, -(significantFigs+1)));
            int a = (int)( x * (Math.Pow(10, (significantFigs))));

            return a / Math.Pow(10, significantFigs);
        }

        private void LakeWashingtonMap_MouseUP(object sender, MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;
            LakeWashingtonMap.Invalidate();
            instructions.Text = "";
        }

        private void LakeWashingtonMap_MouseMove(object sender, MouseEventArgs e)
        {
           // instructions.Text = "X: "+e.X +" Y: "+e.Y;
        }

        private void calculateTide_Click(object sender, EventArgs e)
        {
            int rotors = Int16.Parse(numRotors.Text);
            double density = Double.Parse(waterDensity.Text);
            double diameter = Double.Parse(rotorDiameter.Text);
            double velocity = Double.Parse(tideVelocity.Text);
            double efficiency = Double.Parse(genEfficiency.Text);

            velocity *= 0.514444;//knots -> m/s
            double A = Math.PI * Math.Pow((diameter / 2), 2);
            efficiency /= 100;
            double Mwatt = (rotors * 0.5 * density * A * Math.Pow(velocity, 3) * efficiency) / 1000000;

            tideOut.Text = "The generator would\n generate "+ round(Mwatt, 8) +" Megawatts\n of power.";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}