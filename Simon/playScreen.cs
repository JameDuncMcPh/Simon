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


namespace Simon
{
    public partial class playScreen : UserControl
    {
        #region Variables
        //Lists
        List<int> computorList = new List<int>();
        List<int> playerList = new List<int>();

        //Random Numbers
        Random computorGeuss = new Random();

        //INT
        public static int round = 0;

        //Brushes
        SolidBrush drawBrush0 = new SolidBrush(Color.Maroon);
        SolidBrush drawBrush1 = new SolidBrush(Color.Green);
        SolidBrush drawBrush2 = new SolidBrush(Color.DarkBlue);
        SolidBrush drawBrush3 = new SolidBrush(Color.Yellow);
        SolidBrush drawBrush4 = new SolidBrush(Color.Red);
        SolidBrush drawBrush5 = new SolidBrush(Color.GreenYellow);
        SolidBrush drawBrush6 = new SolidBrush(Color.Blue);
        SolidBrush drawBrush7 = new SolidBrush(Color.YellowGreen);

        //Arrays
        SolidBrush[] brushCan;
        SoundPlayer[] recordPlayer;

        //Sounds
        SoundPlayer beepGreen = new SoundPlayer(Properties.Resources.Electronic_Chime_KevanGC_495939803);
        SoundPlayer beepRed = new SoundPlayer(Properties.Resources.Robot_blip_2_Marianne_Gagnon_299056732);
        SoundPlayer beepBlue = new SoundPlayer(Properties.Resources.A_Tone_His_Self_1266414414);
        SoundPlayer beepYellow = new SoundPlayer(Properties.Resources.Robot_blip_Marianne_Gagnon_120342607);
        #endregion

        public playScreen()
        {
            InitializeComponent();
            brushCan = new SolidBrush[] { drawBrush0, drawBrush1, drawBrush2,
                drawBrush3, drawBrush4, drawBrush5, drawBrush6, drawBrush7 };
            recordPlayer = new SoundPlayer[] { beepRed, beepGreen, beepBlue, beepYellow};
        }

        private void playScreen_Load(object sender, EventArgs e)
        {
            //Reset varialbes
            computorList.Clear();
            playerList.Clear();
            round = 0;

            //Give each buttton a  base colour and shape
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;

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
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;

            //Refresh and let the player get ready for the pattern
            cheaterLabel.Text = "WAIT";
            Refresh();
            Thread.Sleep(800);

            //Up the round and clear the previous computor and player list
            round++;           
            playerList.Clear();
            computorList.Clear();

            //create new random pattern 
            for (int h = 0; h < round; h++)
            {
                computorList.Add(computorGeuss.Next(1,5));
            }

            //highlight each button in the pattern and play its sound
            for (int i = 0; i < computorList.Count(); i++)
            {
                switch (computorList[i])
                {
                    case 1:
                        //shows the higlighted Green
                        greenButton.BackColor = brushCan[5].Color;
                        redButton.BackColor = brushCan[0].Color;
                        blueButton.BackColor = brushCan[2].Color;
                        yellowButton.BackColor = brushCan[3].Color;
                        recordPlayer[1].Play();
                        break;

                    case 2:
                        //shows the higlighted Red
                        greenButton.BackColor = brushCan[1].Color;
                        redButton.BackColor = brushCan[4].Color;
                        blueButton.BackColor = brushCan[2].Color;
                        yellowButton.BackColor = brushCan[3].Color;
                        recordPlayer[0].Play();
                        break;

                    case 3:
                        //shows the higlighted Blue
                        greenButton.BackColor = brushCan[1].Color;
                        redButton.BackColor = brushCan[0].Color;
                        blueButton.BackColor = brushCan[6].Color;
                        yellowButton.BackColor = brushCan[3].Color;
                        recordPlayer[2].Play();
                        break;

                    case 4:
                        //shows the higlighted Yellow
                        greenButton.BackColor = brushCan[1].Color;
                        redButton.BackColor = brushCan[0].Color;
                        blueButton.BackColor = brushCan[2].Color;
                        yellowButton.BackColor = brushCan[7].Color;
                        recordPlayer[3].Play();
                        break;

                    default:
                        break;
                }
                //Refresh and allow the pattern to be visible to players
                Refresh();
                Thread.Sleep(400);

                //Reset buttons so there is a distinction between buttons
                greenButton.BackColor = brushCan[1].Color;
                redButton.BackColor = brushCan[0].Color;
                blueButton.BackColor = brushCan[2].Color;
                yellowButton.BackColor = brushCan[3].Color;

                //Refresh and delay to show difference
                Refresh();
                Thread.Sleep(400);
            }
            //Hand the game back to the player
            cheaterLabel.Text = "PLAY";
        }

        private void player_Turn()
        {
            //for each press in the player array check to see if it dosn't match the corrosponding colour
            for (int i = 0; i < playerList.Count; i++)
            {
                if (computorList[i] != playerList[i])
                {
                    // f is the form that this control is on - ("this" is the current User Control)
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    //if there is a wrong press then game over
                    GameOver go = new GameOver();
                    f.Controls.Add(go);
                }
                else if (i == (playerList.Count - 1) && playerList.Count == computorList.Count)
                {
                    //else another turn starts
                    computor_Turn();
                }
            }
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            //add the colour to the pattern
            playerList.Add(1);

            //show the pressed button as highlighted and play its sound
            greenButton.BackColor = brushCan[5].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;
            Refresh();
            recordPlayer[1].Play();

            //Wait then turn the buttons back to normal
            Thread.Sleep(100);
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;

            //Check if it was wrong
            player_Turn();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            //add the colour to the pattern
            playerList.Add(2);

            //show the pressed button as highlighted and play its sound
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[4].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;
            recordPlayer[0].Play();
            Refresh();

            //Wait then turn the buttons back to normal
            Thread.Sleep(80);
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;

            //Check if it was wrong
            player_Turn();
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            //add the colour to the pattern
            playerList.Add(3);

            //show the pressed button as highlighted and play its sound
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[6].Color;
            yellowButton.BackColor = brushCan[3].Color;
            recordPlayer[2].Play();
            Refresh();

            //Wait then turn the buttons back to normal
            Thread.Sleep(80);
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;

            //Check if it was wrong
            player_Turn();
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            //add the colour to the pattern
            playerList.Add(4);

            //show the pressed button as highlighted and play its sound
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[7].Color;
            recordPlayer[3].Play();
            Refresh();

            //Wait then turn the buttons back to normal
            Thread.Sleep(80);
            greenButton.BackColor = brushCan[1].Color;
            redButton.BackColor = brushCan[0].Color;
            blueButton.BackColor = brushCan[2].Color;
            yellowButton.BackColor = brushCan[3].Color;

            //Check if it was wrong
            player_Turn();
        }
    }
}
