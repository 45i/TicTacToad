using FontAwesome.Sharp.Material;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;


namespace TicTacToad
{

    /// <summary>
    /// The TicTacToad class inherits from Form class. It is the main class for a Tic Tac Toe game,
    /// containing essential variables for game like board, game status, player's turn and game icons. It also
    /// consists of methods to handle game logic, AI play, game state checks, 
    /// event handlers for button clicks, and form load.
    /// </summary>

    public partial class TicTacToad : Form
    {
        public PrivateFontCollection PrivateFont = new PrivateFontCollection();
        public GameIcon playerIcon = new GameIcon(FontAwesome.Sharp.MaterialIcons.Plus);
        public bool playerTurn = true;
        int turns = 0;
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
            try
            {
                if (clickedButton != null && clickedButton.IconChar == FontAwesome.Sharp.MaterialIcons.None && gameStarted)
                {
                    if (playerTurn)
                    {
                        turns++;

                        playerTurn = !playerTurn;
                        clickedButton.IconChar = playerIcon.Icon;
                        /*clickedButton.Rotation = (playerIcon.Icon == FontAwesome.Sharp.MaterialIcons.Plus) ? 45 : 0;*/
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
                            statusIcon.IconChar = FontAwesome.Sharp.MaterialIcons.Crown;
                            btnNewGame.Visible = true;
                            flowLayoutPanel1.Visible = true;
                            statusText.Text = "Player Wins!";
                            btnNewGame.Text = "Start A New Game";
                            btnNewGame.IconChar = FontAwesome.Sharp.MaterialIcons.Plus;
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
                            MaterialButton[] horizontalResult_AI, verticalResult_AI, leftDiagonalResult_AI, rightDiagonalResult_AI;
                            bool l_diag_AI, r_diag_AI, h_AI, v_AI;
                            bool[] temp_arr = PlayMove(clickedButton, out horizontalResult_AI, out verticalResult_AI, out leftDiagonalResult_AI, out rightDiagonalResult_AI, out l_diag_AI, out r_diag_AI, out h_AI, out v_AI);
                            l_diag_AI = temp_arr[0];
                            r_diag_AI = temp_arr[1];
                            h_AI = temp_arr[2];
                            v_AI = temp_arr[3];
                            if (l_diag_AI || r_diag_AI || h_AI || v_AI)
                            {
                                playingBoard.Enabled = false;
                                btnNewGame.Enabled = true;
                                statusIcon.IconChar = FontAwesome.Sharp.MaterialIcons.Crown;
                                btnNewGame.Visible = true;
                                flowLayoutPanel1.Visible = true;
                                statusText.Text = "AI Wins!";
                                btnNewGame.Text = "Start A New Game";
                                btnNewGame.IconChar = FontAwesome.Sharp.MaterialIcons.Plus;
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
                                turns++;
                            }
                            else
                            {
                                bool isEmpty = false;
                                foreach (MaterialButton button in playingBoard.Controls)
                                {
                                    if (button != null && button.IconChar == FontAwesome.Sharp.MaterialIcons.None)
                                    {
                                        isEmpty = true;
                                        break;
                                    }
                                }
                                if (!isEmpty)
                                {
                                    playingBoard.Enabled = false;
                                    btnNewGame.Enabled = true;
                                    statusIcon.IconChar = FontAwesome.Sharp.MaterialIcons.ShieldCross;
                                    btnNewGame.Visible = true;
                                    flowLayoutPanel1.Visible = true;
                                    statusText.Text = "It's A Draw!";
                                    btnNewGame.Text = "Start A New Game";
                                    btnNewGame.IconChar = FontAwesome.Sharp.MaterialIcons.Plus;
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
            catch (Exception ex)
            {
                MessageBox.Show("Error!", "Stupid Dev made a mistake!\n" + ex);
            }

        }

        private bool[] PlayMove(MaterialButton clickedButton, out MaterialButton[] horizontalResult_AI, out MaterialButton[] verticalResult_AI, out MaterialButton[] leftDiagonalResult_AI, out MaterialButton[] rightDiagonalResult_AI, out bool l_diag_AI, out bool r_diag_AI, out bool h_AI, out bool v_AI)
        {
            {
                clickedButton.IconChar = playerIcon.Icon;
                bool isOpen = false;
                foreach (MaterialButton mb in playingBoard.Controls)
                {
                    if (mb.IconChar == FontAwesome.Sharp.MaterialIcons.None)
                    {
                        isOpen = true;
                        break;
                    }
                }
                if (isOpen)
                {
                    playedButton = (true) ? callLookUp(clickedButton, playedButton, 2) : callAIPlay(clickedButton, playedButton);
                    playedButton = (playedButton != null) ? playedButton : callAIPlay(clickedButton, playedButton);
                    playedButton.IconChar = FontAwesome.Sharp.MaterialIcons.CircleOutline;
                    horizontalResult_AI = checkVisionHorizontal(playedButton);
                    verticalResult_AI = checkVisionVertical(playedButton);
                    leftDiagonalResult_AI = checkVisionDiagonal_Left(playedButton);
                    rightDiagonalResult_AI = checkVisionDiagonal_Right(playedButton);
                    l_diag_AI = checkFilledEntriesByIcon(leftDiagonalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline) == 3;
                    r_diag_AI = checkFilledEntriesByIcon(rightDiagonalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline) == 3;
                    h_AI = checkFilledEntriesByIcon(horizontalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline) == 3;
                    v_AI = checkFilledEntriesByIcon(verticalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline) == 3;
                    return new bool[] { l_diag_AI, r_diag_AI, h_AI, v_AI };
                }
                else
                {
                    horizontalResult_AI = null;
                    verticalResult_AI = null;
                    leftDiagonalResult_AI = null;
                    rightDiagonalResult_AI = null;
                    l_diag_AI = false;
                    r_diag_AI = false;
                    h_AI = false;
                    v_AI = false;
                    return new bool[] { false, false, false, false };
                }
            }
        }

        private MaterialButton callLookUp(MaterialButton clickedButton, MaterialButton playedButton, int v)
        {
            Dictionary<MaterialButton, ArrayList> checkedBTNS = new Dictionary<MaterialButton, ArrayList>();
            int highestScore = 0, highestScore_AI = 0, highestScore_Player = 0;
            MaterialButton toPlay = null;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (board[i, j].IconChar == FontAwesome.Sharp.MaterialIcons.None)
                    {
                        if (!checkedBTNS.ContainsKey(board[i, j]))
                            checkedBTNS[board[i, j]] = new ArrayList();
                        for (int h = 0; h < 3; h++)
                        {
                            for (int g = 0; g < 3; g++)
                            {
                                if (board[h, g].IconChar == FontAwesome.Sharp.MaterialIcons.None && board[i, j].IconChar == FontAwesome.Sharp.MaterialIcons.None && board[i, j] != board[h, g])
                                {
                                    board[i, j].IconChar = FontAwesome.Sharp.MaterialIcons.CircleOutline;
                                    Random random = new Random();

                                    int red = random.Next(256);
                                    int green = random.Next(256);
                                    int blue = random.Next(256);

                                    Color randomColor = Color.FromArgb(red, green, blue);
                                    board[h, g].BackColor = randomColor;
                                    board[i, j].BackColor = randomColor;
                                    board[h, g].IconChar = playerIcon.Icon;

                                    statusText.Visible = true;
                                    flowLayoutPanel1.Visible = true;
                                    statusText.Text = "Processing (" + h + "," + g + ") + (" + i + "," + j + ")";
                                    statusIcon.IconChar = FontAwesome.Sharp.MaterialIcons.Brain;
                                    if (checkBox1.Checked) Refresh();
                                    MaterialButton[] horizontalResult_AI, verticalResult_AI, leftDiagonalResult_AI, rightDiagonalResult_AI;
                                    int l_diag_AI, r_diag_AI, h_AI, v_AI;
                                    horizontalResult_AI = checkVisionHorizontal(board[i, j]);
                                    verticalResult_AI = checkVisionVertical(board[i, j]);
                                    leftDiagonalResult_AI = checkVisionDiagonal_Left(board[i, j]);
                                    rightDiagonalResult_AI = checkVisionDiagonal_Right(board[i, j]);
                                    l_diag_AI = checkFilledEntriesByIcon(leftDiagonalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline);
                                    int scaleFactor = 1;
                                    int h_Player = (checkFilledEntriesByIcon(checkVisionHorizontal(board[h, g]), FontAwesome.Sharp.MaterialIcons.Plus));
                                    r_diag_AI = checkFilledEntriesByIcon(rightDiagonalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline);
                                    int v_Player = (checkFilledEntriesByIcon(checkVisionVertical(board[h, g]), FontAwesome.Sharp.MaterialIcons.Plus));
                                    h_AI = checkFilledEntriesByIcon(horizontalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline);
                                    int l_diag_Player = (checkFilledEntriesByIcon(checkVisionDiagonal_Left(board[h, g]), FontAwesome.Sharp.MaterialIcons.Plus));
                                    v_AI = checkFilledEntriesByIcon(verticalResult_AI, FontAwesome.Sharp.MaterialIcons.CircleOutline);
                                    int r_diag_Player = (checkFilledEntriesByIcon(checkVisionDiagonal_Right(board[h, g]), FontAwesome.Sharp.MaterialIcons.Plus));
                                    board[h, g].BackColor = BackColor;
                                    board[i, j].IconChar = FontAwesome.Sharp.MaterialIcons.None;
                                    board[h, g].IconChar = FontAwesome.Sharp.MaterialIcons.None;
                                    checkedBTNS[board[i, j]].Add(board[h, g]);
                                    MaterialButton temp = board[i, j];
                                    if ((turns == 1 || turns == 2) ? (temp != btnTopCenter && temp != btnMiddleLeft && temp != btnMiddleRight && temp != btnDownCenter) : true)
                                    {
                                        if (h_AI == 3 || v_AI == 3 || l_diag_AI == 3 || r_diag_AI == 3)
                                        {
                                            toPlay = (board[i, j]);
                                            highestScore = Math.Max(Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)), Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player))) * ((v_Player == 3 || h_Player == 3 || l_diag_Player == 3 || r_diag_Player == 3) ? 3 : ((v_AI == 3 || h_AI == 3 || l_diag_AI == 3 || r_diag_AI == 3) ? 2 : 1));
                                            highestScore_AI = (Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)));
                                            highestScore_Player = Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player));

                                            goto Outer;
                                        }
                                        else if (h_Player > 2 || v_Player > 2 || l_diag_Player > 2 || r_diag_Player > 2)
                                        {
                                            toPlay = (board[h, g]);
                                            highestScore = Math.Max(Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)), Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player))) * ((v_Player == 3 || h_Player == 3 || l_diag_Player == 3 || r_diag_Player == 3) ? 3 : ((v_AI == 3 || h_AI == 3 || l_diag_AI == 3 || r_diag_AI == 3) ? 2 : 1));
                                            highestScore_AI = (Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)));
                                            highestScore_Player = Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player));

                                            goto Outer;
                                        }
                                        else if (Math.Max(Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)), Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player))) > highestScore)
                                        {
                                            toPlay = ((Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)) > Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player)))) ? board[i, j] : board[h, g];
                                            highestScore = Math.Max(Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)), Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player))) * ((v_Player == 3 || h_Player == 3 || l_diag_Player == 3 || r_diag_Player == 3) ? 3 : ((v_AI == 3 || h_AI == 3 || l_diag_AI == 3 || r_diag_AI == 3) ? 2 : 1));
                                            highestScore_AI = (Math.Max(Math.Max(l_diag_AI, r_diag_AI), Math.Max(h_AI, v_AI)));
                                            highestScore_Player = Math.Max(Math.Max(l_diag_Player, r_diag_Player), Math.Max(h_Player, v_Player));
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        Outer:
            statusText.Text = (highestScore > 0) ? ((highestScore_AI == highestScore_Player) ? "Predicting a draw..." : ((highestScore_Player > highestScore_AI) ? "Player " : "AI ") + "has a higher chance of winning!") : "LookUp Failed! Performing Default Prediction Algorithm";
            playerTurn = true;

            return (toPlay == null) ? callAIPlay(clickedButton, playedButton) : toPlay;
        }

        private bool isInList(MaterialButton materialButton, ArrayList arrayList)
        {
            foreach (MaterialButton item in arrayList)
            {
                if (item == materialButton)
                    return true;
            }
            return false;
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
                        if (button != null && button.IconChar == FontAwesome.Sharp.MaterialIcons.None)
                        {
                            button.IconChar = FontAwesome.Sharp.MaterialIcons.CircleOutline;
                            playedButton = button;
                            goto Outer; // Break out of the outer loop
                        }
                    }
                }
            }
        Outer:
            /*flowLayoutPanel1.Visible = false;*/
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

        /// <summary>
        /// Method arrangeLinesBasedOnPriorities for TicTacToad class.
        /// </summary>
        /// <param name="priorities">A list of integers indicating the priority of each material button array in the second parameter.</param>
        /// <param name="list">A list of arrays containing MaterialButtons. This list is sorted by priority indicated in the first parameter.</param>
        /// <returns>A list of sorted arrays of MaterialButtons.</returns>
        /// <remarks>
        /// This method sorts the provided list of arrays of MaterialButtons based on the provided list of priorities.
        /// The highest priority (highest integer number) will be the first in the list and the lowest priority (lowest integer number) 
        /// will be the last in the resultant list. If two arrays have the same priority, their order is unpredictable.
        /// This method uses the bubble-sort algorithm for sorting and can significantly affect performance when provided
        /// with a large number of arrays. 
        /// </remarks>

        private List<MaterialButton[]> arrangeLinesBasedOnPriorities(List<int> priorities, List<MaterialButton[]> list)
        {
            for (int i = 0; i < priorities.Count - 1; i++)
            {
                for (int j = 0; j < priorities.Count - 1 - i; j++)
                {
                    if (priorities[j] < priorities[j + 1])
                    {
                        // Swap priorities if they are in the wrong order
                        // ReSharper disable once SwapViaDeconstruction
                        MaterialButton[] temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        // ReSharper disable once SwapViaDeconstruction
                        int tempPrio = priorities[j];
                        priorities[j] = priorities[j + 1];
                        priorities[j + 1] = tempPrio;
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

        /// <summary>
        /// The 'generateLines' function is a method in the TicTacToad class that produces and returns a list of MaterialButton arrays; 
        /// The function first generates a list for storing arrays (each representing a 'line' in the game).
        /// Then, it calls upon other methods to retrieve vision checks (horizontally, vertically, left diagonally, right diagonally) for both player and AI. 
        /// Each successful vision check is added to the list as an array of MaterialButton elements. 
        /// This function is mainly for determining possible game winning lines in the current state of the game.
        /// </summary>
        /// <param name="player"> A MaterialButton object representing the player's last move in the game. </param>
        /// <param name="ai"> A MaterialButton object representing the AI's last move in the game. </param>
        /// <returns> It returns a list of MaterialButton arrays. Each array in the list represents a potentially successful line in the game. </returns>
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
        private int checkFilledEntriesByIcon(MaterialButton[] array, FontAwesome.Sharp.MaterialIcons checkAgainst)
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
                if (board[h, locY].IconChar != FontAwesome.Sharp.MaterialIcons.None)
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
                if (board[locX, h].IconChar != FontAwesome.Sharp.MaterialIcons.None)
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
                PrivateFont.AddFontFile(s);
                foreach (Control c in Controls)
                {
                    c.Font = new Font(PrivateFont.Families[0], c.Font.Size);

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
                c.Rotation = 45;
            }
            btnNewGame.Enabled = false;
            defaultColor = btnTopCenter.BackColor;

        }
        public class GameIcon
        {
            public FontAwesome.Sharp.MaterialIcons Icon { get; set; }  // Property named "icon"

            public GameIcon(FontAwesome.Sharp.MaterialIcons icon)
            {
                Icon = icon;  // Constructor to initialize the "icon" property
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Set the gameStarted flag to true
            gameStarted = true;

            // Change the icon and text of the btnNewGame button
            btnNewGame.IconChar = FontAwesome.Sharp.MaterialIcons.Check;
            btnNewGame.Text = "Game Started!";

            // Hide the btnNewGame button and the flowLayoutPanel1 control
            btnNewGame.Visible = false;
            flowLayoutPanel1.Visible = false;

            // Enable the playingBoard control
            playingBoard.Enabled = true;

            // Enable each button in the playingBoard control
            foreach (MaterialButton c in playingBoard.Controls)
            {
                c.Enabled = true;
                c.IconChar = FontAwesome.Sharp.MaterialIcons.None;
                c.IconColor = Color.White;
                /*c.Rotation = 0;*//**/
            }

            // Create an instance of the Random class
            Random random = new Random();

            // Get the row and column count of the 2D array
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            // Generate random row and column indices
            int randomRow = random.Next(rows);
            int randomColumn = random.Next(columns);

            MaterialButton[] elements = { board[0, 0], board[0, 2], board[2, 0], board[2, 2], board[1, 1] };

            // Retrieve the random element from the array
            MaterialButton randomElement = elements[random.Next(elements.Length)];
            playedButton = randomElement;
            turns = 0;

            // If the radioButton2 is checked, call the AIPlay function
            if (radioButton2.Checked)
            {
                playedButton = callAIPlay(randomElement, randomElement);
                MaterialButton[] horizontalResult_AI, verticalResult_AI, leftDiagonalResult_AI, rightDiagonalResult_AI;
                bool l_diag_AI, r_diag_AI, h_AI, v_AI;
                bool[] temp_arr = PlayMove(playedButton, out horizontalResult_AI, out verticalResult_AI, out leftDiagonalResult_AI, out rightDiagonalResult_AI, out l_diag_AI, out r_diag_AI, out h_AI, out v_AI);
                foreach (MaterialButton c in playingBoard.Controls)
                    c.IconChar = FontAwesome.Sharp.MaterialIcons.None;
                turns = 1;
                playedButton.IconChar = FontAwesome.Sharp.MaterialIcons.CircleOutline;
            }

            // Set the playerTurn flag to true
            playerTurn = true;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnNewGame.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
