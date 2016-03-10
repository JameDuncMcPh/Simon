using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

/// <summary>
/// Created by Duncan McPherson
/// Febuary 29th 2016
/// This code runs the main game
/// </summary>


namespace Simon
{
    public partial class playScreen : UserControl
    {
        #region Variables
        //Lists
        List<int> computorList = new List<int>();

        //Random Numbers
        Random computorGeuss = new Random();

        //INT
        public static int round = 0;
        int postion = 0;

        //Brushes
        SolidBrush drawBrush0 = new SolidBrush(Color.Green);
        SolidBrush drawBrush1 = new SolidBrush(Color.Maroon);
        SolidBrush drawBrush2 = new SolidBrush(Color.DarkBlue);
        SolidBrush drawBrush3 = new SolidBrush(Color.Yellow);
        SolidBrush drawBrush4 = new SolidBrush(Color.GreenYellow);
        SolidBrush drawBrush5 = new SolidBrush(Color.Red);
        SolidBrush drawBrush6 = new SolidBrush(Color.Blue);
        SolidBrush drawBrush7 = new SolidBrush(Color.YellowGreen);

        //Arrays
        SolidBrush[] brushCan;
        SolidBrush[] brushCanHighlights;
        SoundPlayer[] recordPlayer;
        Button[] buttons;

        //Sounds
        SoundPlayer beepGreen = new SoundPlayer(Properties.Resources.Electronic_Chime_KevanGC_495939803);
        SoundPlayer beepRed = new SoundPlayer(Properties.Resources.Robot_blip_2_Marianne_Gagnon_299056732);
        SoundPlayer beepBlue = new SoundPlayer(Properties.Resources.A_Tone_His_Self_1266414414);
        SoundPlayer beepYellow = new SoundPlayer(Properties.Resources.Robot_blip_Marianne_Gagnon_120342607);
        #endregion

        public playScreen()
        {
            InitializeComponent();
            brushCan = new SolidBrush[] { drawBrush0, drawBrush1, drawBrush2, drawBrush3, };
            brushCanHighlights = new SolidBrush[] { drawBrush4, drawBrush5, drawBrush6, drawBrush7 };
            recordPlayer = new SoundPlayer[] { beepGreen, beepRed, beepBlue, beepYellow };
            buttons = new Button[] { greenButton, redButton, blueButton, yellowButton };
        }

        private void playScreen_Load(object sender, EventArgs e)
        {
            //Reset varialbes
            computorList.Clear();
            round = 0;

            //Give each buttton a  base colour and shape
            for (int j = 0; j < 4; j++)
            {
                buttons[j].BackColor = brushCan[j].Color;
            }

            //Set the graphics path and regions
            GraphicsPath cirlePath = new GraphicsPath();
            cirlePath.AddEllipse(5, 5, 200, 200);
            Region buttonRegion = new Region(cirlePath);

            buttonRegion.Exclude(new Rectangle(0, 0, 95, 5)); //remove top line
            buttonRegion.Exclude(new Rectangle(0, 95, 95, 5)); //remove bottom line
            buttonRegion.Exclude(new Rectangle(0, 0, 5, 95)); //remove left line
            buttonRegion.Exclude(new Rectangle(95, 0, 5, 100)); //remove right line

            //Setup the matrix and transformations
            Matrix transMatrix = new Matrix();
            transMatrix.RotateAt(90, new PointF(50, 50));

            //Set the green button
            greenButton.Region = buttonRegion;

            //Set the red button
            buttonRegion.Transform(transMatrix);
            redButton.Region = buttonRegion;

            //Set the yellow button
            buttonRegion.Transform(transMatrix);
            yellowButton.Region = buttonRegion;

            //Set the blue button
            buttonRegion.Transform(transMatrix);
            blueButton.Region = buttonRegion;

            Refresh();
            Thread.Sleep(1000);

            //start the computors turn
            computor_Turn();
        }

        private void computor_Turn()
        {
            //Clear the screen of colour
            for (int j = 0; j < 4; j++)
            {
                buttons[j].BackColor = brushCan[j].Color;
            }

            //Refresh and let the player get ready for the pattern
            cheaterLabel.Text = "WAIT";
            Refresh();
            Thread.Sleep(800);

            //Up the round and clear the previous computor and player list
            round++;
            computorList.Clear();
            postion = 0;

            //create new random pattern 
            for (int h = 0; h < round; h++)
            {
                computorList.Add(computorGeuss.Next(1, 5));
            }

            //highlight each button in the pattern and play its sound
            for (int i = 0; i < computorList.Count(); i++)
            {
                switch (computorList[i])
                {
                    case 1:
                        //shows the higlighted Green
                        greenButton.BackColor = brushCanHighlights[0].Color;
                        redButton.BackColor = brushCan[1].Color;
                        blueButton.BackColor = brushCan[2].Color;
                        yellowButton.BackColor = brushCan[3].Color;
                        recordPlayer[0].Play();
                        break;

                    case 2:
                        //shows the higlighted Red
                        greenButton.BackColor = brushCan[0].Color;
                        redButton.BackColor = brushCanHighlights[1].Color;
                        blueButton.BackColor = brushCan[2].Color;
                        yellowButton.BackColor = brushCan[3].Color;
                        recordPlayer[1].Play();
                        break;

                    case 3:
                        //shows the higlighted Blue
                        greenButton.BackColor = brushCan[0].Color;
                        redButton.BackColor = brushCan[1].Color;
                        blueButton.BackColor = brushCanHighlights[2].Color;
                        yellowButton.BackColor = brushCan[3].Color;
                        recordPlayer[2].Play();
                        break;

                    case 4:
                        //shows the higlighted Yellow
                        greenButton.BackColor = brushCan[0].Color;
                        redButton.BackColor = brushCan[1].Color;
                        blueButton.BackColor = brushCan[2].Color;
                        yellowButton.BackColor = brushCanHighlights[3].Color;
                        recordPlayer[3].Play();
                        break;

                    default:
                        break;
                }
                //Refresh and allow the pattern to be visible to players
                Refresh();
                Thread.Sleep(400);

                //Reset buttons so there is a distinction between buttons
                for (int j = 0; j < 4; j++)
                {
                    buttons[j].BackColor = brushCan[j].Color;
                }

                //Refresh and delay to show difference
                Refresh();
                Thread.Sleep(400);
            }
            //Hand the game back to the player and clear the guesses
            cheaterLabel.Text = "PLAY";
        }

        private void button_Press(object sender, EventArgs e)
        {
            Button button = sender as Button;

            int i = Array.IndexOf(buttons, button);

            recordPlayer[i].Play();
            button.BackColor = brushCanHighlights[i].Color;

            //Wait then turn the buttons back to normal
            Refresh();
            Thread.Sleep(100);
            for (int j = 0; j < 4; j++)
            {
                buttons[j].BackColor = brushCan[j].Color;
            }
            Refresh();

            //Check if it was wrong at the postion it is meant to be checked aganist
            if (computorList[postion] != (i + 1))
            {
                // f is the form that this control is on - ("this" is the current User Control)
                Form f = this.FindForm();
                f.Controls.Remove(this);

                //if there is a wrong press then game over
                GameOver go = new GameOver();
                f.Controls.Add(go);
            }

            if (postion + 1 == computorList.Count)
            {
                //else another turn starts
                computor_Turn();
            }
            else
            {
                postion++;
            }           
        }
    }
}

