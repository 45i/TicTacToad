using FontAwesome.Sharp;
using FontAwesome.Sharp.Material;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Effects;

namespace TicTacToad
{

    public partial class TicTacToad : Form
    {
        public PrivateFontCollection privateFont = new PrivateFontCollection();
        public GameIcon playerIcon = new GameIcon(MaterialIcons.Plus);
        public bool playerTurn = true;
        public MaterialButton[,] board;
        private bool gameStarted;
        MaterialButton playedButton = null;
        Color defaultColor = Color.AliceBlue;


        public TicTacToad()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void btnClick_Board(object sender, EventArgs e)
        {
            clickEvent((MaterialButton)sender);

        }

        private void clickEvent(MaterialButton clickedButton)
        {

            {
                if (clickedButton != null && clickedButton.IconChar == MaterialIcons.None && gameStarted)
                {
                    if (playerTurn)
                    {
                        playerTurn = !playerTurn;
                        clickedButton.IconChar = playerIcon.Icon;
                        clickedButton.Rotation = (playerIcon.Icon == MaterialIcons.Plus) ? 45 : 0;
                        int i = 0, j = 0;
                        for (; i < 3; i++)
                        {
                            for (; j < 3; j++)
                            {
                                if (board[i, j] != null && board[i, j] == clickedButton && board[i, j].IconChar != playerIcon.Icon)
                                {
                                    board[i, j].IconChar = playerIcon.Icon;
                                    break;
                                }

                            }
                        }
                        MaterialButton[] horizontalResult = checkVisionHorizontal(clickedButton);
                        MaterialButton[] verticalResult = checkVisionVertical(clickedButton);
                        MaterialButton[] leftDiagonalResult = checkVisionDiagonal_Left(clickedButton);
                        MaterialButton[] rightDiagonalResult = checkVisionDiagonal_Right(clickedButton);
                        bool l_diag = checkFilledEntriesByIcon(leftDiagonalResult, playerIcon.Icon) == 3;
                        bool r_diag = checkFilledEntriesByIcon(rightDiagonalResult, playerIcon.Icon) == 3;
                        bool h = checkFilledEntriesByIcon(horizontalResult, playerIcon.Icon) == 3;
                        bool v = checkFilledEntriesByIcon(verticalResult, playerIcon.Icon) == 3;
                        if (l_diag || r_diag || h || v)
                        {
                            playingBoard.Enabled = false;
                            btnNewGame.Enabled = true;
                            statusIcon.IconChar = MaterialIcons.Crown;
                            btnNewGame.Visible = true;
                            flowLayoutPanel1.Visible = true;
                            statusText.Text = "Player Wins!";
                            btnNewGame.Text = "Start A New Game";
                            btnNewGame.IconChar = MaterialIcons.Plus;
                            gameStarted = false;
                            btnNewGame.Enabled = false;
                            radioButton1.Checked = false;
                            radioButton2.Checked = false;
                            MaterialButton[] ar;
                            if (h)
                                ar = horizontalResult;
                            else if (v)
                                ar = verticalResult;
                            else if (l_diag)
                                ar = leftDiagonalResult;
                            else
                                ar = rightDiagonalResult;
                            foreach (MaterialButton mb in playingBoard.Controls)
                                mb.IconColor = Color.DarkSlateGray;
                            foreach (MaterialButton materialButton in ar)
                                materialButton.IconColor = Color.White;




                        }
                        else
                        {
                            playedButton = callAIPlay(clickedButton, playedButton);
                            MaterialButton[] horizontalResult_AI = checkVisionHorizontal(playedButton);
                            MaterialButton[] verticalResult_AI = checkVisionVertical(playedButton);
                            MaterialButton[] leftDiagonalResult_AI = checkVisionDiagonal_Left(playedButton);
                            MaterialButton[] rightDiagonalResult_AI = checkVisionDiagonal_Right(playedButton);
                            bool l_diag_AI = checkFilledEntriesByIcon(leftDiagonalResult_AI, MaterialIcons.CircleOutline) == 3;
                            bool r_diag_AI = checkFilledEntriesByIcon(rightDiagonalResult_AI, MaterialIcons.CircleOutline) == 3;
                            bool h_AI = checkFilledEntriesByIcon(horizontalResult_AI, MaterialIcons.CircleOutline) == 3;
                            bool v_AI = checkFilledEntriesByIcon(verticalResult_AI, MaterialIcons.CircleOutline) == 3;
                            if (l_diag_AI || r_diag_AI || h_AI || v_AI)
                            {
                                playingBoard.Enabled = false;
                                btnNewGame.Enabled = true;
                                statusIcon.IconChar = MaterialIcons.Crown;
                                btnNewGame.Visible = true;
                                flowLayoutPanel1.Visible = true;
                                statusText.Text = "AI Wins!";
                                btnNewGame.Text = "Start A New Game";
                                btnNewGame.IconChar = MaterialIcons.Plus;
                                gameStarted = false;
                                btnNewGame.Enabled = false;
                                radioButton1.Checked = false;
                                radioButton2.Checked = false;
                                MaterialButton[] ar;
                                if (h_AI)
                                    ar = horizontalResult_AI;
                                else if (v_AI)
                                    ar = verticalResult_AI;
                                else if (l_diag_AI)
                                    ar = leftDiagonalResult_AI;
                                else
                                    ar = rightDiagonalResult_AI;
                                foreach (MaterialButton mb in playingBoard.Controls)
                                    mb.IconColor = Color.DarkSlateGray;
                                foreach (MaterialButton materialButton in ar)
                                    materialButton.IconColor = Color.White;

                            }
                            else
                            {
                                bool isEmpty = false;
                                foreach (MaterialButton button in playingBoard.Controls)
                                {
                                    if (button != null && button.IconChar == MaterialIcons.None)
                                    {
                                        isEmpty = true;
                                        break;
                                    }
                                }
                                if (!isEmpty)
                                {
                                    playingBoard.Enabled = false;
                                    btnNewGame.Enabled = true;
                                    statusIcon.IconChar = MaterialIcons.ShieldCross;
                                    btnNewGame.Visible = true;
                                    flowLayoutPanel1.Visible = true;
                                    statusText.Text = "It's A Draw!";
                                    btnNewGame.Text = "Start A New Game";
                                    btnNewGame.IconChar = MaterialIcons.Plus;
                                    gameStarted = false;
                                    btnNewGame.Enabled = false;
                                    radioButton1.Checked = false;
                                    radioButton2.Checked = false;

                                }
                            }
                        }

                    }
                }
            }

        }



        private MaterialButton callAIPlay(MaterialButton player, MaterialButton ai)
        {
            MaterialButton playedButton = null;
            List<int> priorities = generatePriorities(player);
            List<MaterialButton[]> visionLines = arrangeLinesBasedOnPriorities(priorities, generateLines(player, ai));
            foreach (MaterialButton[] row in visionLines)
            {
                int count = 0;

                foreach (MaterialButton button in row)
                {
                    if (button != null && button.IconChar == playerIcon.Icon)
                    {
                        count++;
                    }
                }

                if (count <= 2)
                {
                    foreach (MaterialButton button in row)
                    {
                        if (button != null && button.IconChar == MaterialIcons.None)
                        {
                            button.IconChar = MaterialIcons.CircleOutline;
                            playedButton = button;
                            goto Outer; // Break out of the outer loop
                        }
                    }
                }
            }
        Outer:
            playerTurn = true;
            return playedButton;
        }

        private List<int> arrangePriorities(List<int> priorities)
        {
            for (int i = 0; i < priorities.Count - 1; i++)
            {
                for (int j = 0; j < priorities.Count - 1 - i; j++)
                {
                    if (priorities[j] < priorities[j + 1])
                    {
                        // Swap priorities if they are in the wrong order
                        int temp = priorities[j];
                        priorities[j] = priorities[j + 1];
                        priorities[j + 1] = temp;
                    }
                }
            }
            return priorities;
        }

        private List<MaterialButton[]> arrangeLinesBasedOnPriorities(List<int> priorities, List<MaterialButton[]> list)
        {
            for (int i = 0; i < priorities.Count - 1; i++)
            {
                for (int j = 0; j < priorities.Count - 1 - i; j++)
                {
                    if (priorities[j] < priorities[j + 1])
                    {
                        // Swap priorities if they are in the wrong order
                        MaterialButton[] temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        int temp_prio = priorities[j];
                        priorities[j] = priorities[j + 1];
                        priorities[j + 1] = temp_prio;
                    }
                }
            }
            return list;
        }

        private List<int> generatePriorities(MaterialButton player)
        {
            // Create a List<int> to store the result priorities
            List<int> priorities = new List<int>();

            // Retrieve and store the result of checking the horizontal vision for the player
            MaterialButton[] horizontalResult = checkVisionHorizontal(player);
            int horizontalPriority = checkFilledEntries(horizontalResult, player) * 1;
            priorities.Add(horizontalPriority);

            // Retrieve and store the result of checking the vertical vision for the player
            MaterialButton[] verticalResult = checkVisionVertical(player);
            int verticalPriority = checkFilledEntries(verticalResult, player) * 1;
            priorities.Add(verticalPriority);

            // Retrieve and store the result of checking the left diagonal vision for the player
            MaterialButton[] leftDiagonalResult = checkVisionDiagonal_Left(player);
            int leftDiagonalPriority = checkFilledEntries(leftDiagonalResult, player) + (int)Math.Round(2 * (1 / 3.0) * checkFilledEntries(leftDiagonalResult, player));
            priorities.Add(leftDiagonalPriority);

            // Retrieve and store the result of checking the right diagonal vision for the player
            MaterialButton[] rightDiagonalResult = checkVisionDiagonal_Right(player);
            int rightDiagonalPriority = checkFilledEntries(rightDiagonalResult, player) + (int)Math.Round(2 * (1 / 3.0) * checkFilledEntries(rightDiagonalResult, player));
            priorities.Add(rightDiagonalPriority);

            MaterialButton[] horizontalResult_AI = checkVisionHorizontal(playedButton);
            int horizontalPriority_AI = checkFilledEntries(horizontalResult_AI, playedButton) + (int)Math.Round(2.5 * (1 / 3.0) * checkFilledEntries(horizontalResult_AI, playedButton));
            priorities.Add(horizontalPriority_AI);

            // Retrieve and store the Result_AI of checking the vertical vision for the playedButton
            MaterialButton[] verticalResult_AI = checkVisionVertical(playedButton);
            int verticalPriority_AI = checkFilledEntries(verticalResult_AI, playedButton) + (int)Math.Round(2.5 * (1 / 3.0) * checkFilledEntries(verticalResult_AI, playedButton));
            priorities.Add(verticalPriority_AI);

            // Retrieve and store the Result_AI of checking the left diagonal vision for the playedButton
            MaterialButton[] leftDiagonalResult_AI = checkVisionDiagonal_Left(playedButton);
            int leftDiagonalPriority_AI = checkFilledEntries(leftDiagonalResult_AI, playedButton) + (int)Math.Round(3 * (1 / 3.0) * checkFilledEntries(leftDiagonalResult_AI, playedButton));
            priorities.Add(leftDiagonalPriority_AI);

            // Retrieve and store the Result_AI of checking the right diagonal vision for the playedButton
            MaterialButton[] rightDiagonalResult_AI = checkVisionDiagonal_Right(playedButton);
            int rightDiagonalPriority_AI = checkFilledEntries(rightDiagonalResult_AI, playedButton) + (int)Math.Round(3 * (1 / 3.0) * checkFilledEntries(rightDiagonalResult_AI, playedButton));
            priorities.Add(rightDiagonalPriority_AI);

            // Return the completed List<int> of priorities
            return priorities;
        }

        private List<MaterialButton[]> generateLines(MaterialButton player, MaterialButton ai)
        {
            // Create a List<ArrayList> to store the result lines
            List<MaterialButton[]> lines = new List<MaterialButton[]>();

            // Retrieve and store the result of checking the horizontal vision for the player
            MaterialButton[] horizontalResult = checkVisionHorizontal(player);
            lines.Add(horizontalResult);

            // Retrieve and store the result of checking the vertical vision for the player
            MaterialButton[] verticalResult = checkVisionVertical(player);
            lines.Add(verticalResult);

            // Retrieve and store the result of checking the left diagonal vision for the player
            MaterialButton[] leftDiagonalResult = checkVisionDiagonal_Left(player);
            lines.Add(leftDiagonalResult);

            // Retrieve and store the result of checking the right diagonal vision for the player
            MaterialButton[] rightDiagonalResult = checkVisionDiagonal_Right(player);
            lines.Add(rightDiagonalResult);

            MaterialButton[] horizontalResult_AI = checkVisionHorizontal(playedButton);
            lines.Add(horizontalResult_AI);

            // Retrieve and store the Result_AI of checking the vertical vision for the player
            MaterialButton[] verticalResult_AI = checkVisionVertical(playedButton);
            lines.Add(verticalResult_AI);

            // Retrieve and store the Result_AI of checking the left diagonal vision for the player
            MaterialButton[] leftDiagonalResult_AI = checkVisionDiagonal_Left(playedButton);
            lines.Add(leftDiagonalResult_AI);

            // Retrieve and store the Result_AI of checking the right diagonal vision for the player
            MaterialButton[] rightDiagonalResult_AI = checkVisionDiagonal_Right(playedButton);
            lines.Add(rightDiagonalResult_AI);

            // Return the completed List<ArrayList> of lines
            return lines;
        }

        private int checkFilledEntries(MaterialButton[] array, MaterialButton checkAgainst)
        {
            Random random = new Random();

            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            Color randomColor = Color.FromArgb(red, green, blue);
            foreach (MaterialButton g in playingBoard.Controls)
            {
                g.BackColor = defaultColor;
            }
            int c = 0;
            foreach (MaterialButton i in array)
            {
                if (i != null && i.IconChar == checkAgainst.IconChar)
                {
                    c++;
                    if (checkBox1.Checked) i.BackColor = randomColor;
                }
            }
            return c;
        }
        private int checkFilledEntriesByIcon(MaterialButton[] array, MaterialIcons checkAgainst)
        {
            Random random = new Random();

            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            Color randomColor = Color.FromArgb(red, green, blue);
            foreach (MaterialButton g in playingBoard.Controls)
            {
                g.BackColor = defaultColor;
            }
            int c = 0;
            foreach (MaterialButton i in array)
            {
                if (i != null && i.IconChar == checkAgainst)
                {
                    c++;
                    if (checkBox1.Checked) i.BackColor = randomColor;
                }
            }
            return c;
        }

        private MaterialButton[] checkVisionDiagonal_Right(MaterialButton player)
        {
            MaterialButton[] genList = new MaterialButton[3];
            int locX = 0, locY = 0, h = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((board[i, j] != null && board[i, j] == player))
                    {
                        locX = i;
                        locY = j;
                        break;
                    }

                }
            }
            for (int i = 0; i <= Math.Min(locX, 2 - locY); i++)
            {
                if (board[locX - i, locY + i] != null && board[locX - i, locY + i].IconChar == playerIcon.Icon)
                {
                    Random random = new Random();

                    int red = random.Next(256);
                    int green = random.Next(256);
                    int blue = random.Next(256);

                    Color randomColor = Color.FromArgb(red, green, blue);
                }
                genList[h] = board[locX - i, locY + i];

                h++;
            }
            for (int i = 1; i <= Math.Min(2 - locX, locY); i++)
            {
                if (board[locX + i, locY - i] != null && board[locX + i, locY - i].IconChar == playerIcon.Icon)
                {
                    Random random = new Random();

                    int red = random.Next(256);
                    int green = random.Next(256);
                    int blue = random.Next(256);

                    Color randomColor = Color.FromArgb(red, green, blue);
                }
                genList[h] = board[locX + i, locY - i];

                h++;
            }
            return genList;
        }


        private MaterialButton[] checkVisionDiagonal_Left(MaterialButton player)
        {
            MaterialButton[] genList = new MaterialButton[3];
            int locX = 0, locY = 0, h = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((board[i, j] != null && board[i, j] == player))
                    {
                        locX = i;
                        locY = j;
                        break;
                    }

                }
            }
            for (int i = 0; i <= Math.Min(locX, locY); i++)
            {
                Random random = new Random();


                int red = random.Next(256);
                int green = random.Next(256);
                int blue = random.Next(256);

                Color randomColor = Color.FromArgb(red, green, blue);


                genList[h] = board[locX - i, locY - i];
                genList[h].BackColor = randomColor;
                h++;

            }
            for (int i = 1; i <= 2 - Math.Max(locX, locY); i++)
            {
                Random random = new Random();


                int red = random.Next(256);
                int green = random.Next(256);
                int blue = random.Next(256);


                Color randomColor = Color.FromArgb(red, green, blue);

                genList[h] = board[locX + i, locY + i];
                genList[h].BackColor = randomColor;
                h++;

            }
            return genList;
        }

        private MaterialButton[] checkVisionVertical(MaterialButton player)
        {
            MaterialButton[] genList = new MaterialButton[3];
            int locX = 0, locY = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((board[i, j] != null && board[i, j] == player))
                    {
                        locX = i;
                        locY = j;
                        break;
                    }

                }
            }
            for (int h = 0, c = 0; h < 3; h++)
            {
                if (board[h, locY].IconChar != MaterialIcons.None)
                {
                    Random random = new Random();


                    int red = random.Next(256);
                    int green = random.Next(256);
                    int blue = random.Next(256);


                    Color randomColor = Color.FromArgb(red, green, blue);
                }
                genList[c] = board[h, locY];

                c++;
            }
            return genList;
        }

        private MaterialButton[] checkVisionHorizontal(MaterialButton player)
        {
            MaterialButton[] genList = new MaterialButton[3];
            int locX = 0, locY = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((board[i, j] != null && board[i, j] == player))
                    {
                        locX = i;
                        locY = j;
                        break;
                    }

                }
            }
            for (int h = 0, c = 0; h < 3; h++)
            {
                if (board[locX, h].IconChar != MaterialIcons.None)
                {
                    Random random = new Random();


                    int red = random.Next(256);
                    int green = random.Next(256);
                    int blue = random.Next(256);


                    Color randomColor = Color.FromArgb(red, green, blue);
                }
                genList[c] = board[locX, h];

                c++;
            }
            return genList;
        }

        private void TicTacToad_Load(object sender, EventArgs e)
        {
            try
            {
                string s = Application.StartupPath + "\\fonts\\SFPRODISPLAYBOLD.OTF";
                privateFont.AddFontFile(s);
                foreach (Control c in Controls)
                {
                    c.Font = new Font(privateFont.Families[0], c.Font.Size);

                }
            }
            catch (Exception)
            {

            }
            board = new MaterialButton[,]
            {
                { btnTopLeft, btnTopCenter, btnTopRight },
                { btnMiddleLeft, btnMiddleCenter, btnMiddleRight },
                { btnDownLeft, btnDownCenter, btnDownRight }
            };
            foreach (MaterialButton c in playingBoard.Controls)
            {
                c.Enabled = false;
            }
            btnNewGame.Enabled = false;
            defaultColor = btnTopCenter.BackColor;

        }
        public class GameIcon
        {
            public MaterialIcons Icon { get; set; }  // Property named "icon"

            public GameIcon(MaterialIcons icon)
            {
                Icon = icon;  // Constructor to initialize the "icon" property
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            gameStarted = true;
            btnNewGame.IconChar = MaterialIcons.Check;
            btnNewGame.Text = "Game Started!";
            btnNewGame.Visible = false;
            flowLayoutPanel1.Visible = false;
            playingBoard.Enabled = true;
            foreach (MaterialButton c in playingBoard.Controls)
            {
                c.Enabled = true;
                c.IconChar = MaterialIcons.None;
                c.IconColor = Color.White;
                c.Rotation = 0;
            }
            // Create an instance of the <link>Random</link> class
            Random random = new Random();

            // Get the row and column count of the 2D array
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            // Generate random row and column indices
            int randomRow = random.Next(rows);
            int randomColumn = random.Next(columns);


            // Retrieve the random element from the array
            MaterialButton randomElement = board[randomRow, randomColumn];
            playedButton = randomElement;
            if (radioButton2.Checked)
            {
                playedButton = callAIPlay(randomElement, randomElement);
            }

            playerTurn = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnNewGame.Enabled = true;
        }
    }
}
