using System;
using System.Collections.Generic;
using FontAwesome.Sharp.Material;
using TicTacToad;

namespace TicTacToad
{
    public class NeuralNetworkAI
    {
        private double[] weights;
        private Random random;

        public NeuralNetworkAI()
        {
            random = new Random();
            weights = new double[9];
            InitializeWeights();
        }

        private void InitializeWeights()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = random.NextDouble();
            }
        }

        public MaterialButton GetNextMove(MaterialButton[,] board, FontAwesome.Sharp.MaterialIcons aiIcon, FontAwesome.Sharp.MaterialIcons playerIcon)
        {
            double bestScore = double.MinValue;
            MaterialButton bestMove = null;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j].IconChar == FontAwesome.Sharp.MaterialIcons.None)
                    {
                        board[i, j].IconChar = aiIcon;
                        double score = EvaluateBoard(board, aiIcon, playerIcon);
                        board[i, j].IconChar = FontAwesome.Sharp.MaterialIcons.None;

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = board[i, j];
                        }
                    }
                }
            }

            return bestMove;
        }

        private double EvaluateBoard(MaterialButton[,] board, FontAwesome.Sharp.MaterialIcons aiIcon, FontAwesome.Sharp.MaterialIcons playerIcon)
        {
            double score = 0.0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j].IconChar == aiIcon)
                    {
                        score += weights[i * 3 + j];
                    }
                    else if (board[i, j].IconChar == playerIcon)
                    {
                        score -= weights[i * 3 + j];
                    }
                }
            }

            return score;
        }

        public void UpdateWeights(MaterialButton[,] board, FontAwesome.Sharp.MaterialIcons aiIcon, FontAwesome.Sharp.MaterialIcons playerIcon, bool aiWon)
        {
            double reward = aiWon ? 1.0 : -1.0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j].IconChar == aiIcon)
                    {
                        weights[i * 3 + j] += reward;
                    }
                    else if (board[i, j].IconChar == playerIcon)
                    {
                        weights[i * 3 + j] -= reward;
                    }
                }
            }
        }
    }
}
