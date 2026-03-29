using System;
using System.Drawing;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace AnirudhMaths1
{
    public partial class Form1 : Form
    {
        //creating the variables for colour
        int R = 0;
        int G = 0;
        int B = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //creating a variable for speech synthesizer
        SpeechSynthesizer speechSynthesizerObj;

        private void button1_Click(object sender, EventArgs e)
        {
            //creating variables to perform addition
            Single A, B;
            //taking the value out of textbox.1
            Single.TryParse(textBox1.Text, out A);
            //taking the value out of textbox.2
            Single.TryParse(textBox2.Text, out B);
            //creating a variable for the answer
            Single C;
            //performing addition
            C = A + B;
            //creating a variable to store the answer in string format
            string answer;
            //storing the answer in string format
            answer = A.ToString() + " + " + B.ToString() + " = " + C.ToString();
            //displaying the answer in label.4
            label4.Text = "Ans = " + C.ToString();
            //displaying the answer in richtextbox.1
            richTextBox1.AppendText(answer + "\n");
            //storing the answer in string format with different format
            answer = A.ToString() + " plus " + B.ToString() + " = " + C.ToString();
            //calling the method AnirudhSpeak to speak the answer
            AnirudhSpeak(answer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //creating variables to perform subtraction
            Single A, B;
            //taking the value out of textbox.1
            Single.TryParse(textBox1.Text, out A);
            //taking the value out of textbox.2
            Single.TryParse(textBox2.Text, out B);
            //creating a variable for the answer
            Single C;
            //performing subtraction
            C = A - B;
            //displaying the answer in label.4
            label4.Text = "Ans = " + C.ToString();
            //creating a variable to store the answer in string format
            string answer;
            //storing the answer in string format
            answer = A.ToString() + " - " + B.ToString() + " = " + C.ToString();
            //displaying the answer in richtextbox.1
            richTextBox1.AppendText(answer + "\n");
            //storing the answer in string format 
            answer = A.ToString() + " minus " + B.ToString() + " = " + C.ToString();
            //calling the method AnirudhSpeak to speak the answer
            AnirudhSpeak(answer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //creating variables to perform multiplication
            Single A, B;
            //taking the value out of textbox.1
            Single.TryParse(textBox1.Text, out A);
            //taking the value out of textbox.2
            Single.TryParse(textBox2.Text, out B);
            //creating a variable for the answer
            Single C;
            //performing multiplication
            C = A * B;
            //displaying the answer in label.4
            label4.Text = "Ans = " + C.ToString();
            //creating a variable to store the answer in string format
            string answer;
            //storing the answer in string format
            answer = A.ToString() + " * " + B.ToString() + " = " + C.ToString();
            //displaying the answer in richtextbox.1
            richTextBox1.AppendText(A.ToString() + " * " + B.ToString() + " = " + C.ToString() + "\n");
            //storing the answer in string format 
            answer = A.ToString() + " multiplied by " + B.ToString() + " = " + C.ToString();
            //calling the method AnirudhSpeak to speak the answer
            AnirudhSpeak(answer);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //creating variables to perform division
            Single A, B;
            //taking the value out of textbox.1
            Single.TryParse(textBox1.Text, out A);
            //taking the value out of textbox.2
            Single.TryParse(textBox2.Text, out B);
            //creating a variable for the answer
            Single C;
            //performing division
            C = A / B;
            //displaying the answer in label.4
            label4.Text = "Ans = " + C.ToString();
            //creating a variable to store the answer in string format
            string answer;
            //storing the answer in string format
            answer = A.ToString() + " ÷ " + B.ToString() + " = " + C.ToString();
            //displaying the answer in richtextbox.1
            richTextBox1.AppendText(A.ToString() + " ÷ " + B.ToString() + " = " + C.ToString() + "\n");
            //storing the answer in string format
            answer = A.ToString() + " divide by " + B.ToString() + " = " + C.ToString();
            //calling the method AnirudhSpeak to speak the answer
            AnirudhSpeak(answer);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //displaying the date and time in label.6
            label6.Text = DateTime.Now.ToString("dddd dd MMMM yyyy, hh:mm:ss tt");
            //changing the colour of label.1, label.5 and label.6
            label1.ForeColor = Color.FromArgb(R, 0, 0);
            label5.ForeColor = Color.FromArgb(0, G, 0);
            label6.ForeColor = Color.FromArgb(0, 0, B);
            //increasing the value of R, G and B (colours) by 5
            R = R + 5;
            G = G + 5;
            B = B + 5;
            //if the value of R, G and B is greater than 255 then make it 0
            if (R > 255) R = 0;
            if (G > 255) G = 0;
            if (B > 255) B = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //creating an object for speech synthesizer
            speechSynthesizerObj = new SpeechSynthesizer();
            LoadVoice();
        }

        private void LoadVoice()
        {
            //creating an object for speech synthesizer
            SpeechSynthesizer a = new SpeechSynthesizer();

            //a.SelectVoice("Microsoft David Desktop");
            a.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult); // to change VoiceGender and VoiceAge check out those links below

            /*Female  2   Indicates a female voice.
              Male    1   Indicates a male voice.
              Neutral 3   Indicates a gender - neutral voice.
              NotSet  0     Indicates no voice gender specification.

              Adult   30  Indicates an adult voice(age 30).
              Child   10  Indicates a child voice(age 10).
              NotSet  0   Indicates that no voice age is specified.
              Senior  65  Indicates a senior voice(age 65).
              Teen    15  Indicates a teenage voice(age 15).*/

            //getting the installed voices in the system and displaying it in comboBox.1
            foreach (InstalledVoice voice in a.GetInstalledVoices())
            {
                //getting the voice information
                VoiceInfo info = voice.VoiceInfo;
                //creating a variable to store the supported audio formats in string format
                string AudioFormats = "";
                //getting the supported audio formats and storing it in string format
                foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)

                {
                    //storing the supported audio formats in string format
                    AudioFormats += String.Format("{0}\n",
                    fmt.EncodingFormat.ToString());
                }
                //displaying the voice name in comboBox.1
                comboBox1.Items.Add(info.Name);
                //setting the default selected index of comboBox.1 to the last item
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                /*
                //if you want to display additional voice information in richtextbox.1 then you can use the below code
                richTextBox1.AppendText("Name : " + info.Name + "\n");
                richTextBox1.AppendText("Culture : " + info.Culture + "\n");
                richTextBox1.AppendText("Age : " + info.Age + "\n");
                richTextBox1.AppendText("Gender : " + info.Gender + "\n");
                richTextBox1.AppendText("Description : " + info.Description + "\n");
                richTextBox1.AppendText("Info ID : " + info.Id + "\n");
                richTextBox1.AppendText("Voice Status : " + voice.Enabled + "\n");
                richTextBox1.AppendText("\n");
                */
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //copying the history to clipboard
            Clipboard.SetText(richTextBox1.Text + "\nProgram developed by Anirudh M.R 7B");
            //calling the method AnirudhSpeak to speak the status
            AnirudhSpeak("History copied to clipboard successfully");
            //displaying the message box to show the status
            MessageBox.Show("History copied successfully", "Anirudh M.R");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //creating an object for SaveFileDialog
            SaveFileDialog savedlg = new SaveFileDialog();
            //setting the filter for the SaveFileDialog
            savedlg.Filter = "ASCII Text file (.txt)|.txt|" +
                "All files (.)|.";
            //setting the default filter index to 1
            savedlg.FilterIndex = 1;
            //setting the default file name in SaveFileDialog
            savedlg.Title = "Anirudh M.R : Export to Notepad";
            //creating variables to store the header and footer of the file in string format
            string strHeader, strFooter;
            //storing the header of the file in string format
            strHeader = "Anirudh M.R Calculator Program\n\n";

            //mentioning the current date and time 
            strFooter = "Date : " + DateTime.Now.ToString("dddd dd MMMM yyyy");
            strFooter += "\tTime : " + DateTime.Now.ToString("hh:mm:ss tt");
            //showing the SaveFileDialog and if the user clicks on OK then save the file
            if (savedlg.ShowDialog() == DialogResult.OK)
            {
                //appending the history to the file with header and footer
                System.IO.File.AppendAllText(savedlg.FileName,
            strHeader +
            richTextBox1.Text + "\n"
            + strFooter + Environment.NewLine);
                //calling the method AnirudhSpeak to speak the status
                AnirudhSpeak("File created successfully, you can find the file at " + savedlg.FileName);
                DialogResult a1;
                //displaying the message box to show the status and option to open the file
                a1 = MessageBox.Show("File created , you can find the file at " + @savedlg.FileName + "\n\n Do you want to Open Now", "Anirudh: Status and Option", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a1 == DialogResult.Yes) System.Diagnostics.Process.Start(@savedlg.FileName);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //disposing the speech synthesizer object 
            DialogResult Anirudh;
            //displaying the message box to show the status and option to exit the program
            Anirudh = MessageBox.Show("Thanks For Using Anirudh Calculator Program", "Anirudh Message", MessageBoxButtons.YesNo);
            //if the user clicks on Yes then exit the program
            if (Anirudh == DialogResult.Yes)
            {
                textBox3.Text = "2";
                Application.DoEvents();
                AnirudhSpeak("Thanks for using Anirudh Calculator Program");

                Application.Exit();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //clearing all the text
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            label4.Text = "Ans = ";
            AnirudhSpeak("All text are cleared");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //disposing the speech synthesizer object
            speechSynthesizerObj.Dispose();

            if (richTextBox1.Text != "")
            {
                //creating a new object for speech synthesizer
                speechSynthesizerObj = new SpeechSynthesizer();
                //setting the volume and rate of the speech synthesizer object
                speechSynthesizerObj.Volume = 100; // int.Parse(textBox1.Text); //  100;   // 0...100
                speechSynthesizerObj.Rate = int.Parse(textBox3.Text);     //-2;   // -10...10

                //speechSynthesizerObj.SelectVoice("Microsoft David Desktop");
                speechSynthesizerObj.SelectVoice(comboBox1.Text);
                //speaking the text in richTextBox.1 asynchronously
                speechSynthesizerObj.SpeakAsync(richTextBox1.Text);
            }
        }
        private void AnirudhSpeak(string TextMatter)
        {
            //creating a new object for speech synthesizer
            SpeechSynthesizer a = new SpeechSynthesizer();
            //setting the volume and rate of the speech synthesizer object
            a.Volume = 100; // int.Parse(textBox1.Text); //  100;   // 0...100
            a.Rate = int.Parse(textBox3.Text);     //-2;
            //selecting the voice of the speech synthesizer object
            a.SelectVoice(comboBox1.Text);
            //speaking the text in richTextBox.1 asynchronously
            a.Speak(TextMatter);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //displaying the value of trackBar.1 in textBox.3
            textBox3.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            //displaying the value of trackBar.1 in textBox.3
            textBox3.Text = trackBar1.Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //creating an object for Form2 and showing it
            Form2 frm = new Form2();
            frm.Show();
            //calling the method AnirudhSpeak to speak the message
            AnirudhSpeak("For any help contact me; anirudh.mr@hotmail.com");
        }  
    }
}
