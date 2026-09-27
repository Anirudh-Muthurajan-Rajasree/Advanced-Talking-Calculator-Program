using System;
using System.Drawing;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Xml.Schema;

namespace AnirudhMaths1
{
    public partial class Form1 : Form
    {
        //creating the variables for colour
        int R = 0;
        int G = 0;
        int B = 0;
        int A_B_selection = 0;
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
            A_B_selection = 1;
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

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = comboBox2.SelectedIndex;
            if (a <= 0) //English
            {
                label1.Text = "Anirudh M.R Calculator Program";
                label5.Text = "History";
                label7.Text = "Speed";
                button1.Text = " Add";
                button2.Text = "    Subtract";
                button3.Text = "    Multiply";
                button4.Text = "   Divide";
                button5.Text = "Copy";
                button6.Text = "Notepad";
                button7.Text = "Exit";
                button8.Text = "Clear";
                button9.Text = "Speak";
                button10.Text = "Help";
            }

            if (a == 1) //Hindi
            {
                label1.Text = "अनिरुद्ध एम.आर. कैलकुलेटर प्रोग्राम"; //Anirudh M.R Calculator Program
                label5.Text = "इतिहास"; //History
                label7.Text = "तेज़ी"; //Speed
                button1.Text = "जोड़ना"; //Add
                button2.Text = " घटाना"; //Subtract
                button3.Text = "गुणा";  //Multiply
                button4.Text = "   विभाजित";  //Divide
                button5.Text = "कॉपी"; //Copy
                button6.Text = "नोटपैड"; //Notepad
                button7.Text = "  बाहर निकलना"; //Exit
                button8.Text = "स्पष्ट"; //Clear
                button9.Text = "बोलना"; //Speak
                button10.Text = "मदद"; //Help
            }

            if (a == 2) //Kannada
            {
                label1.Text = "ಅನಿರುದ್ಧ್ ಎಂ.ಆರ್ ಕ್ಯಾಲ್ಕುಲೇಟರ್ ಪ್ರೋಗ್ರಾಮ್"; //Anirudh M.R Calculator Program
                label5.Text = "ಇತಿಹಾಸ"; //History
                label7.Text = "ವೇಗ"; //Speed
                button1.Text = "ಸೇರಿಸು"; //Add
                button2.Text = "ಕಡಿತ"; //Subtract
                button3.Text = "ಗುಣಿಸು";  //Multiply
                button4.Text = "ಭಾಗಿಸು";  //Divide
                button5.Text = "  ನಕಲಿಸಿ"; //Copy
                button6.Text = "  ನೋಟ್ಪ್ಯಾಡ್"; //Notepad
                button7.Text = "     ನಿರ್ಗಮಿಸು"; //Exit
                button8.Text = " ಸ್ಪಷ್ಟ"; //Clear
                button9.Text = "       ಮಾತನಾಡಿ"; //Speak
                button10.Text = "     ಸಹಾಯ"; //Help

            }
            if (a == 3)//Tamil
            {
                label1.Text = "அனிருத் எம்.ஆர் கால்குலேட்டர் திட்டம்"; //Anirudh M.R Calculator Program
                label5.Text = "வரலாறு"; //History
                label7.Text = "வேகம்"; //Speed
                button1.Text = "சேர்க்க"; //Add
                button2.Text = "   கழித்தல்"; //Subtract
                button3.Text = "   பெருக்க";  //Multiply
                button4.Text = "பகிர்";  //Divide
                button5.Text = "நகல்"; //Copy
                button6.Text = "நோட்பேட்"; //Notepad
                button7.Text = "       வெளியேறு"; //Exit
                button8.Text = "   தெளிவான"; //Clear
                button9.Text = "பேசு"; //Speak
                button10.Text = " உதவி"; //Help               
            }
            if (a == 4)  //Spanish
            {
                label1.Text = "Anirudh M.R Programa de calculadora"; //Anirudh M.R Calculator Program
                label5.Text = "Historia"; //History
                label7.Text = "Velocidad"; //Speed
                button1.Text = "Agregar"; //Add
                button2.Text = "Sustraer"; //Subtract
                button3.Text = "    Multiplicar";  //Multiply
                button4.Text = "Dividir";  //Divide
                button5.Text = "  Copiar"; //Copy
                button6.Text = "     Bloc de notas"; //Notepad
                button7.Text = "Salir"; //Exit
                button8.Text = "Claro"; //Clear
                button9.Text = "Hablar"; //Speak
                button10.Text = "    Ayuda"; //Help}
            }
            if (a == 5) //French
            {
                label1.Text = "Anirudh M.R Programme de calculatrice"; //Anirudh M.R Calculator Program
                label5.Text = "Histoire"; //History
                label7.Text = "Vitesse"; //Speed
                button1.Text = "Ajouter"; //Add
                button2.Text = "   Soustraire"; //Subtract
                button3.Text = "  Multiplier";  //Multiply
                button4.Text = "Diviser";  //Divide
                button5.Text = "  Copier"; //Copy
                button6.Text = "Bloc-notes"; //Notepad
                button7.Text = "Sortie"; //Exit
                button8.Text = "Clair"; //Clear
                button9.Text = "Parler"; //Speak
                button10.Text = "Aide"; //Help
            }
            if (a == 6) //German
            {
                label6.Text = "Anirudh M.R Rechnerprogramm"; //Anirudh M.R Calculator Program
                label6.Text = "Geschichte"; //History
                label7.Text = "Geschwindigkeit"; //Speed
                button1.Text = " Hinzufügen"; //Add
                button2.Text = "   Subtrahieren"; //Subtract
                button3.Text = "    Multiplizieren";  //Multiply
                button4.Text = "Teilen";  //Divide
                button5.Text = "   Kopieren"; //Copy
                button6.Text = "Notizblock"; //Notepad
                button7.Text = " Ausfahrt"; //Exit
                button8.Text = "Klar"; //Clear
                button9.Text = "Sprechen"; //Speak
                button10.Text = "Hilfe"; //Help
            }

            if (a == 7) //Italian
            {
                label1.Text = "Anirudh M.R Programma di calcolatrice"; //Anirudh M.R Calculator Program
                label5.Text = "Storia"; //History
                label7.Text = "Velocità"; //Speed
                button1.Text = " Aggiungere"; //Add
                button2.Text = "Sottrarre"; //Subtract
                button3.Text = " Moltiplicare";  //Multiply
                button4.Text = "Dividere";  //Divide
                button5.Text = " Copiare"; //Copy
                button6.Text = "Blocco note"; //Notepad
                button7.Text = "Uscita"; //Exit
                button8.Text = "Chiaro"; //Clear
                button9.Text = "Parlare"; //Speak
                button10.Text = "Aiuto"; //Help
            }
            if (a == 8) //Chinese
            {
                label1.Text = "阿尼鲁德 先.生 计算器程序"; //Anirudh M.R Calculator Program
                label5.Text = "历史"; //History
                label7.Text = "速度"; //Speed
                button1.Text = "添加"; //Add
                button2.Text = "减去"; //Subtract
                button3.Text = "乘以";  //Multiply
                button4.Text = "除以";  //Divide
                button5.Text = "复制"; //Copy
                button6.Text = "记事本"; //Notepad
                button7.Text = "出口"; //Exit
                button8.Text = "清楚"; //Clear
                button9.Text = "说话"; //Speak
                button10.Text = "帮助"; //Help
            }
            if (a == 9) //Japanese
            {
                label1.Text = "アニルド 氏 電卓プログラム"; //Anirudh M.R Calculator Program
                label5.Text = "歴史"; //History
                label7.Text = "速度"; //Speed
                button1.Text = "追加"; //Add
                button2.Text = "減算"; //Subtract
                button3.Text = "乗算";  //Multiply
                button4.Text = "除算";  //Divide
                button5.Text = "コピー"; //Copy
                button6.Text = "メモ帳"; //Notepad
                button7.Text = "出口"; //Exit
                button8.Text = "クリア"; //Clear
                button9.Text = "話す"; //Speak
                button10.Text = "助けて"; //Help
            }
            if (a == 10) //Russian
            {
                label1.Text = "Анирруд М.Р. Программа калькулятора"; //Anirudh M.R Calculator Program
                label5.Text = "История"; //History
                label7.Text = "Скорость"; //Speed
                button1.Text = "Добавить"; //Add
                button2.Text = "Вычесть"; //Subtract
                button3.Text = "Умножить";  //Multiply
                button4.Text = "Разделить";  //Divide
                button5.Text = "     Копировать"; //Copy
                button6.Text = "Блокнот"; //Notepad
                button7.Text = "Выход"; //Exit
                button8.Text = "Очистить"; //Clear
                button9.Text = "      Говорить"; //Speak
                button10.Text = "     Помощь"; //Help
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            A_B_selection = 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            A_B_selection = 2;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            A_B_selection = 1;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            A_B_selection = 2;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            //Adding the value of 1 to textbox.1 or 2 
            if (A_B_selection == 1)  textBox1.Text += "1";
            if (A_B_selection == 2)  textBox2.Text += "1";
         }

        private void button12_Click(object sender, EventArgs e)
        {
            //Adding the value of 2 to textbox.1 or 2 
            if (A_B_selection == 1) textBox1.Text += "2";
            if (A_B_selection == 2) textBox2.Text += "2";
        }            

        private void button13_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "3";
            if (A_B_selection == 2) textBox2.Text += "3";   
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "4";
            if (A_B_selection == 2) textBox2.Text += "4";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "5";
            if (A_B_selection == 2) textBox2.Text += "5";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "6";
            if (A_B_selection == 2) textBox2.Text += "6";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "7";
            if (A_B_selection == 2) textBox2.Text += "7";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "8";
            if (A_B_selection == 2) textBox2.Text += "8";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "9";
            if (A_B_selection == 2) textBox2.Text += "9";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += "0";
            if (A_B_selection == 2) textBox2.Text += "0";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (A_B_selection == 1) textBox1.Text += ".";
            if (A_B_selection == 2) textBox2.Text += ".";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Single A;
            //taking the value out of textbox.1
            Single.TryParse(textBox1.Text, out A);
            //taking the value out of textbox.2
            //Single.TryParse(textBox2.Text, out B);
            //creating a variable for the answer
            Single C;
            //performing addition
            C = A * A;
            //creating a variable to store the answer in string format
            string answer;
            //storing the answer in string format
            answer = A.ToString() + "² = " + C.ToString();
            //displaying the answer in label.4
            label4.Text = "Ans = " + C.ToString();
            //displaying the answer in richtextbox.1
            richTextBox1.AppendText(answer + "\n");
            //storing the answer in string format with different format
            answer = A.ToString() + " square  = " + C.ToString();
            //calling the method AnirudhSpeak to speak the answer
            AnirudhSpeak(answer);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Single A;
            //taking the value out of textbox.1
            Single.TryParse(textBox1.Text, out A);
            //taking the value out of textbox.2
            //Single.TryParse(textBox2.Text, out B);
            //creating a variable for the answer
            Single C;
            //performing addition
            C = A * A * A;
            //creating a variable to store the answer in string format
            string answer;
            //storing the answer in string format
            answer = A.ToString() + "³ = " + C.ToString();
            //displaying the answer in label.4
            label4.Text = "Ans = " + C.ToString();
            //displaying the answer in richtextbox.1
            richTextBox1.AppendText(answer + "\n");
            //storing the answer in string format with different format
            answer = A.ToString() + " cube  = " + C.ToString();
            //calling the method AnirudhSpeak to speak the answer
            AnirudhSpeak(answer);
        }
    }
}

