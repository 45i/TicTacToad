namespace TicTacToad
{
    partial class TicTacToad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playingBoard = new System.Windows.Forms.TableLayoutPanel();
            this.btnDownLeft = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnDownCenter = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnDownRight = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnMiddleLeft = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnMiddleCenter = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnTopRight = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnMiddleRight = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnTopLeft = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnTopCenter = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnMinimise = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnClose = new FontAwesome.Sharp.Material.MaterialButton();
            this.logoX = new FontAwesome.Sharp.Material.MaterialButton();
            this.logoO = new FontAwesome.Sharp.Material.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewGame = new FontAwesome.Sharp.Material.MaterialButton();
            this.statusText = new System.Windows.Forms.Label();
            this.statusIcon = new FontAwesome.Sharp.Material.MaterialButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.playingBoard.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playingBoard
            // 
            this.playingBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playingBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(36)))));
            this.playingBoard.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.playingBoard.ColumnCount = 3;
            this.playingBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playingBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playingBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playingBoard.Controls.Add(this.btnDownLeft, 0, 2);
            this.playingBoard.Controls.Add(this.btnDownCenter, 0, 2);
            this.playingBoard.Controls.Add(this.btnDownRight, 0, 2);
            this.playingBoard.Controls.Add(this.btnMiddleLeft, 0, 1);
            this.playingBoard.Controls.Add(this.btnMiddleCenter, 1, 1);
            this.playingBoard.Controls.Add(this.btnTopRight, 2, 0);
            this.playingBoard.Controls.Add(this.btnMiddleRight, 2, 1);
            this.playingBoard.Controls.Add(this.btnTopLeft, 0, 0);
            this.playingBoard.Controls.Add(this.btnTopCenter, 1, 0);
            this.playingBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playingBoard.Location = new System.Drawing.Point(26, 26);
            this.playingBoard.Name = "playingBoard";
            this.playingBoard.RowCount = 3;
            this.playingBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playingBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playingBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playingBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playingBoard.Size = new System.Drawing.Size(370, 399);
            this.playingBoard.TabIndex = 0;
            // 
            // btnDownLeft
            // 
            this.btnDownLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownLeft.FlatAppearance.BorderSize = 0;
            this.btnDownLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownLeft.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnDownLeft.IconColor = System.Drawing.Color.White;
            this.btnDownLeft.Location = new System.Drawing.Point(4, 268);
            this.btnDownLeft.Name = "btnDownLeft";
            this.btnDownLeft.Size = new System.Drawing.Size(116, 127);
            this.btnDownLeft.TabIndex = 11;
            this.btnDownLeft.UseVisualStyleBackColor = true;
            this.btnDownLeft.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnDownCenter
            // 
            this.btnDownCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownCenter.FlatAppearance.BorderSize = 0;
            this.btnDownCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownCenter.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnDownCenter.IconColor = System.Drawing.Color.White;
            this.btnDownCenter.Location = new System.Drawing.Point(127, 268);
            this.btnDownCenter.Name = "btnDownCenter";
            this.btnDownCenter.Size = new System.Drawing.Size(116, 127);
            this.btnDownCenter.TabIndex = 6;
            this.btnDownCenter.UseVisualStyleBackColor = true;
            this.btnDownCenter.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnDownRight
            // 
            this.btnDownRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownRight.FlatAppearance.BorderSize = 0;
            this.btnDownRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownRight.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnDownRight.IconColor = System.Drawing.Color.White;
            this.btnDownRight.Location = new System.Drawing.Point(250, 268);
            this.btnDownRight.Name = "btnDownRight";
            this.btnDownRight.Size = new System.Drawing.Size(116, 127);
            this.btnDownRight.TabIndex = 4;
            this.btnDownRight.UseVisualStyleBackColor = true;
            this.btnDownRight.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnMiddleLeft
            // 
            this.btnMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMiddleLeft.FlatAppearance.BorderSize = 0;
            this.btnMiddleLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiddleLeft.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnMiddleLeft.IconColor = System.Drawing.Color.White;
            this.btnMiddleLeft.Location = new System.Drawing.Point(4, 136);
            this.btnMiddleLeft.Name = "btnMiddleLeft";
            this.btnMiddleLeft.Size = new System.Drawing.Size(116, 125);
            this.btnMiddleLeft.TabIndex = 3;
            this.btnMiddleLeft.UseVisualStyleBackColor = true;
            this.btnMiddleLeft.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnMiddleCenter
            // 
            this.btnMiddleCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMiddleCenter.FlatAppearance.BorderSize = 0;
            this.btnMiddleCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiddleCenter.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnMiddleCenter.IconColor = System.Drawing.Color.White;
            this.btnMiddleCenter.Location = new System.Drawing.Point(127, 136);
            this.btnMiddleCenter.Name = "btnMiddleCenter";
            this.btnMiddleCenter.Size = new System.Drawing.Size(116, 125);
            this.btnMiddleCenter.TabIndex = 2;
            this.btnMiddleCenter.UseVisualStyleBackColor = true;
            this.btnMiddleCenter.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnTopRight
            // 
            this.btnTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTopRight.FlatAppearance.BorderSize = 0;
            this.btnTopRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopRight.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnTopRight.IconColor = System.Drawing.Color.White;
            this.btnTopRight.Location = new System.Drawing.Point(250, 4);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(116, 125);
            this.btnTopRight.TabIndex = 7;
            this.btnTopRight.UseVisualStyleBackColor = true;
            this.btnTopRight.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnMiddleRight
            // 
            this.btnMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMiddleRight.FlatAppearance.BorderSize = 0;
            this.btnMiddleRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiddleRight.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnMiddleRight.IconColor = System.Drawing.Color.White;
            this.btnMiddleRight.Location = new System.Drawing.Point(250, 136);
            this.btnMiddleRight.Name = "btnMiddleRight";
            this.btnMiddleRight.Size = new System.Drawing.Size(116, 125);
            this.btnMiddleRight.TabIndex = 8;
            this.btnMiddleRight.UseVisualStyleBackColor = true;
            this.btnMiddleRight.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTopLeft.FlatAppearance.BorderSize = 0;
            this.btnTopLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopLeft.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnTopLeft.IconColor = System.Drawing.Color.White;
            this.btnTopLeft.Location = new System.Drawing.Point(4, 4);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(116, 125);
            this.btnTopLeft.TabIndex = 9;
            this.btnTopLeft.UseVisualStyleBackColor = true;
            this.btnTopLeft.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnTopCenter
            // 
            this.btnTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTopCenter.FlatAppearance.BorderSize = 0;
            this.btnTopCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopCenter.IconChar = FontAwesome.Sharp.MaterialIcons.None;
            this.btnTopCenter.IconColor = System.Drawing.Color.White;
            this.btnTopCenter.Location = new System.Drawing.Point(127, 4);
            this.btnTopCenter.Name = "btnTopCenter";
            this.btnTopCenter.Size = new System.Drawing.Size(116, 125);
            this.btnTopCenter.TabIndex = 10;
            this.btnTopCenter.UseVisualStyleBackColor = true;
            this.btnTopCenter.Click += new System.EventHandler(this.btnClick_Board);
            // 
            // btnMinimise
            // 
            this.btnMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimise.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimise.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnMinimise.FlatAppearance.BorderSize = 0;
            this.btnMinimise.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnMinimise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnMinimise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimise.IconChar = FontAwesome.Sharp.MaterialIcons.Minus;
            this.btnMinimise.IconColor = System.Drawing.Color.White;
            this.btnMinimise.Location = new System.Drawing.Point(548, 2);
            this.btnMinimise.Name = "btnMinimise";
            this.btnMinimise.Size = new System.Drawing.Size(117, 50);
            this.btnMinimise.TabIndex = 1;
            this.btnMinimise.UseVisualStyleBackColor = false;
            this.btnMinimise.Click += new System.EventHandler(this.btnMinimise_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.MaterialIcons.Plus;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(671, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Rotation = 45D;
            this.btnClose.Size = new System.Drawing.Size(117, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // logoX
            // 
            this.logoX.BackColor = System.Drawing.Color.Transparent;
            this.logoX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoX.FlatAppearance.BorderSize = 0;
            this.logoX.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoX.IconChar = FontAwesome.Sharp.MaterialIcons.Plus;
            this.logoX.IconColor = System.Drawing.Color.White;
            this.logoX.Location = new System.Drawing.Point(3, 2);
            this.logoX.Name = "logoX";
            this.logoX.Rotation = 45D;
            this.logoX.Size = new System.Drawing.Size(36, 22);
            this.logoX.TabIndex = 3;
            this.logoX.UseVisualStyleBackColor = false;
            // 
            // logoO
            // 
            this.logoO.BackColor = System.Drawing.Color.Transparent;
            this.logoO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoO.FlatAppearance.BorderSize = 0;
            this.logoO.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(15)))));
            this.logoO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoO.IconChar = FontAwesome.Sharp.MaterialIcons.CircleOutline;
            this.logoO.IconColor = System.Drawing.Color.White;
            this.logoO.IconSize = 32;
            this.logoO.Location = new System.Drawing.Point(33, 2);
            this.logoO.Name = "logoO";
            this.logoO.Rotation = 45D;
            this.logoO.Size = new System.Drawing.Size(36, 22);
            this.logoO.TabIndex = 4;
            this.logoO.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TicTacToad";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.BackColor = System.Drawing.Color.Transparent;
            this.btnNewGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.btnNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.btnNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnNewGame.IconChar = FontAwesome.Sharp.MaterialIcons.PencilPlus;
            this.btnNewGame.IconColor = System.Drawing.Color.LimeGreen;
            this.btnNewGame.IconSize = 96;
            this.btnNewGame.Location = new System.Drawing.Point(439, 129);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(354, 143);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "Start New Game";
            this.btnNewGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // statusText
            // 
            this.statusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.ForeColor = System.Drawing.Color.White;
            this.statusText.Location = new System.Drawing.Point(45, 0);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(113, 28);
            this.statusText.TabIndex = 8;
            this.statusText.Text = "Wins!";
            this.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusIcon
            // 
            this.statusIcon.BackColor = System.Drawing.Color.Transparent;
            this.statusIcon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.statusIcon.FlatAppearance.BorderSize = 0;
            this.statusIcon.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.statusIcon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.statusIcon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
            this.statusIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusIcon.IconChar = FontAwesome.Sharp.MaterialIcons.CircleOutline;
            this.statusIcon.IconColor = System.Drawing.Color.White;
            this.statusIcon.IconSize = 32;
            this.statusIcon.Location = new System.Drawing.Point(3, 3);
            this.statusIcon.Name = "statusIcon";
            this.statusIcon.Size = new System.Drawing.Size(36, 22);
            this.statusIcon.TabIndex = 7;
            this.statusIcon.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.statusIcon);
            this.flowLayoutPanel1.Controls.Add(this.statusText);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(548, 79);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 44);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(525, 347);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Player";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton2.AutoSize = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(642, 347);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(69, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Computer";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(552, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "First Play";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(492, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 86);
            this.label3.TabIndex = 13;
            // 
            // checkBox1
            // 
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Location = new System.Drawing.Point(525, 421);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(181, 24);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Enable Debug Mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // TicTacToad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoO);
            this.Controls.Add(this.logoX);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimise);
            this.Controls.Add(this.playingBoard);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TicTacToad";
            this.Text = "TicTacToad";
            this.Load += new System.EventHandler(this.TicTacToad_Load);
            this.playingBoard.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel playingBoard;
        private FontAwesome.Sharp.Material.MaterialButton btnMinimise;
        private FontAwesome.Sharp.Material.MaterialButton btnClose;
        private FontAwesome.Sharp.Material.MaterialButton btnDownLeft;
        private FontAwesome.Sharp.Material.MaterialButton btnDownCenter;
        private FontAwesome.Sharp.Material.MaterialButton btnDownRight;
        private FontAwesome.Sharp.Material.MaterialButton btnMiddleLeft;
        private FontAwesome.Sharp.Material.MaterialButton btnMiddleCenter;
        private FontAwesome.Sharp.Material.MaterialButton btnTopRight;
        private FontAwesome.Sharp.Material.MaterialButton btnMiddleRight;
        private FontAwesome.Sharp.Material.MaterialButton btnTopLeft;
        private FontAwesome.Sharp.Material.MaterialButton btnTopCenter;
        private FontAwesome.Sharp.Material.MaterialButton logoX;
        private FontAwesome.Sharp.Material.MaterialButton logoO;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.Material.MaterialButton btnNewGame;
        private System.Windows.Forms.Label statusText;
        private FontAwesome.Sharp.Material.MaterialButton statusIcon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

