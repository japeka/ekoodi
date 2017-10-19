namespace ski_jumping_points_calculator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHillName = new System.Windows.Forms.TextBox();
            this.txtJumperName = new System.Windows.Forms.TextBox();
            this.txtKPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBarEntryLevel = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblPlatformLevel = new System.Windows.Forms.Label();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.lblPlatformCompensation = new System.Windows.Forms.Label();
            this.lblWindCompensation = new System.Windows.Forms.Label();
            this.lblJumpPoints = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblStylesPointsWithout = new System.Windows.Forms.Label();
            this.lblStylesPointsWith = new System.Windows.Forms.Label();
            this.lblStylesPoints = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblJumpLength = new System.Windows.Forms.Label();
            this.lblKPoint = new System.Windows.Forms.Label();
            this.lblHillName = new System.Windows.Forms.Label();
            this.lblJumperName = new System.Windows.Forms.Label();
            this.btnSendJumperAway = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tBarEntryLevel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hill Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jumper Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtHillName
            // 
            this.txtHillName.AutoCompleteCustomSource.AddRange(new string[] {
            "Malinka",
            "Rukatunturi",
            "Tramplin Stork",
            "Hochfirstschanze",
            "Gross-Titlis-Schanze",
            "Schattenbergschanze",
            "Große Olympiaschanze",
            "Bergiselschanze",
            "Paul-Ausserleitner-Schanze",
            "Kulm",
            "Wielka Krokiew",
            "Mühlenkopfschanze",
            "Salpausselkä",
            "Holmenkollbakken",
            "Lysgårdsbakken",
            "Granåsen",
            "Vikersundbakken",
            "Letalnica bratov Gorišek"});
            this.txtHillName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtHillName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHillName.Location = new System.Drawing.Point(229, 107);
            this.txtHillName.Margin = new System.Windows.Forms.Padding(4);
            this.txtHillName.Name = "txtHillName";
            this.txtHillName.Size = new System.Drawing.Size(519, 30);
            this.txtHillName.TabIndex = 3;
            this.txtHillName.TextChanged += new System.EventHandler(this.txtHillName_TextChanged);
            this.txtHillName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.testEnterDown);
            // 
            // txtJumperName
            // 
            this.txtJumperName.Location = new System.Drawing.Point(229, 49);
            this.txtJumperName.Margin = new System.Windows.Forms.Padding(4);
            this.txtJumperName.Name = "txtJumperName";
            this.txtJumperName.Size = new System.Drawing.Size(519, 30);
            this.txtJumperName.TabIndex = 1;
            // 
            // txtKPoint
            // 
            this.txtKPoint.Location = new System.Drawing.Point(229, 162);
            this.txtKPoint.Margin = new System.Windows.Forms.Padding(4);
            this.txtKPoint.Name = "txtKPoint";
            this.txtKPoint.Size = new System.Drawing.Size(444, 30);
            this.txtKPoint.TabIndex = 4;
            this.txtKPoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.acceptNumber);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "K-Point for Hill:";
            // 
            // tBarEntryLevel
            // 
            this.tBarEntryLevel.Location = new System.Drawing.Point(222, 213);
            this.tBarEntryLevel.Margin = new System.Windows.Forms.Padding(4);
            this.tBarEntryLevel.Maximum = 5;
            this.tBarEntryLevel.Minimum = 1;
            this.tBarEntryLevel.Name = "tBarEntryLevel";
            this.tBarEntryLevel.Size = new System.Drawing.Size(404, 56);
            this.tBarEntryLevel.TabIndex = 6;
            this.tBarEntryLevel.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBarEntryLevel.Value = 3;
            this.tBarEntryLevel.Scroll += new System.EventHandler(this.tBarEntryLevel_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 225);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Platform level:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.lblPlatformLevel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tBarEntryLevel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtKPoint);
            this.groupBox1.Controls.Add(this.txtJumperName);
            this.groupBox1.Controls.Add(this.txtHillName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(72, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(877, 298);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Data";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(676, 225);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(24, 20);
            this.label29.TabIndex = 11;
            this.label29.Text = "m";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(685, 171);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 20);
            this.label27.TabIndex = 9;
            this.label27.Text = "m";
            // 
            // lblPlatformLevel
            // 
            this.lblPlatformLevel.AutoSize = true;
            this.lblPlatformLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatformLevel.Location = new System.Drawing.Point(634, 225);
            this.lblPlatformLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlatformLevel.Name = "lblPlatformLevel";
            this.lblPlatformLevel.Size = new System.Drawing.Size(19, 20);
            this.lblPlatformLevel.TabIndex = 8;
            this.lblPlatformLevel.Text = "0";
            this.lblPlatformLevel.Click += new System.EventHandler(this.label9_Click);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.BackColor = System.Drawing.Color.White;
            this.groupBoxResult.Controls.Add(this.label31);
            this.groupBoxResult.Controls.Add(this.label30);
            this.groupBoxResult.Controls.Add(this.label28);
            this.groupBoxResult.Controls.Add(this.label9);
            this.groupBoxResult.Controls.Add(this.label7);
            this.groupBoxResult.Controls.Add(this.label6);
            this.groupBoxResult.Controls.Add(this.label5);
            this.groupBoxResult.Controls.Add(this.lblTotalPoints);
            this.groupBoxResult.Controls.Add(this.lblPlatformCompensation);
            this.groupBoxResult.Controls.Add(this.lblWindCompensation);
            this.groupBoxResult.Controls.Add(this.lblJumpPoints);
            this.groupBoxResult.Controls.Add(this.label22);
            this.groupBoxResult.Controls.Add(this.label21);
            this.groupBoxResult.Controls.Add(this.label20);
            this.groupBoxResult.Controls.Add(this.label19);
            this.groupBoxResult.Controls.Add(this.lblStylesPointsWithout);
            this.groupBoxResult.Controls.Add(this.lblStylesPointsWith);
            this.groupBoxResult.Controls.Add(this.lblStylesPoints);
            this.groupBoxResult.Controls.Add(this.label15);
            this.groupBoxResult.Controls.Add(this.label14);
            this.groupBoxResult.Controls.Add(this.label13);
            this.groupBoxResult.Controls.Add(this.label12);
            this.groupBoxResult.Controls.Add(this.label11);
            this.groupBoxResult.Controls.Add(this.label10);
            this.groupBoxResult.Controls.Add(this.lblJumpLength);
            this.groupBoxResult.Controls.Add(this.lblKPoint);
            this.groupBoxResult.Controls.Add(this.lblHillName);
            this.groupBoxResult.Controls.Add(this.lblJumperName);
            this.groupBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxResult.Location = new System.Drawing.Point(74, 458);
            this.groupBoxResult.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxResult.Size = new System.Drawing.Size(877, 260);
            this.groupBoxResult.TabIndex = 5;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Output Data";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(357, 148);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(24, 25);
            this.label31.TabIndex = 28;
            this.label31.Text = "p";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(358, 183);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 25);
            this.label30.TabIndex = 27;
            this.label30.Text = "p";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(742, 115);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(24, 25);
            this.label28.TabIndex = 26;
            this.label28.Text = "p";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(789, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 42);
            this.label9.TabIndex = 25;
            this.label9.Text = "p";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(744, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 25);
            this.label7.TabIndex = 24;
            this.label7.Text = "p";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(741, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "m";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "m";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.AutoSize = true;
            this.lblTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.Location = new System.Drawing.Point(672, 180);
            this.lblTotalPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(123, 42);
            this.lblTotalPoints.TabIndex = 21;
            this.lblTotalPoints.Text = "_____";
            // 
            // lblPlatformCompensation
            // 
            this.lblPlatformCompensation.AutoSize = true;
            this.lblPlatformCompensation.Location = new System.Drawing.Point(272, 183);
            this.lblPlatformCompensation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlatformCompensation.Name = "lblPlatformCompensation";
            this.lblPlatformCompensation.Size = new System.Drawing.Size(72, 25);
            this.lblPlatformCompensation.TabIndex = 20;
            this.lblPlatformCompensation.Text = "_____";
            // 
            // lblWindCompensation
            // 
            this.lblWindCompensation.AutoSize = true;
            this.lblWindCompensation.Location = new System.Drawing.Point(270, 148);
            this.lblWindCompensation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWindCompensation.Name = "lblWindCompensation";
            this.lblWindCompensation.Size = new System.Drawing.Size(72, 25);
            this.lblWindCompensation.TabIndex = 19;
            this.lblWindCompensation.Text = "_____";
            // 
            // lblJumpPoints
            // 
            this.lblJumpPoints.AutoSize = true;
            this.lblJumpPoints.Location = new System.Drawing.Point(665, 80);
            this.lblJumpPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJumpPoints.Name = "lblJumpPoints";
            this.lblJumpPoints.Size = new System.Drawing.Size(72, 25);
            this.lblJumpPoints.TabIndex = 18;
            this.lblJumpPoints.Text = "_____";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(461, 80);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(176, 25);
            this.label22.TabIndex = 17;
            this.label22.Text = "Points For Jump:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(425, 178);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(234, 42);
            this.label21.TabIndex = 16;
            this.label21.Text = "Total points:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 183);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(243, 25);
            this.label20.TabIndex = 15;
            this.label20.Text = "Platform Compensation:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 148);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(214, 25);
            this.label19.TabIndex = 14;
            this.label19.Text = "Wind Compensation:";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // lblStylesPointsWithout
            // 
            this.lblStylesPointsWithout.AutoSize = true;
            this.lblStylesPointsWithout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStylesPointsWithout.ForeColor = System.Drawing.Color.Red;
            this.lblStylesPointsWithout.Location = new System.Drawing.Point(617, 149);
            this.lblStylesPointsWithout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStylesPointsWithout.Name = "lblStylesPointsWithout";
            this.lblStylesPointsWithout.Size = new System.Drawing.Size(66, 25);
            this.lblStylesPointsWithout.TabIndex = 13;
            this.lblStylesPointsWithout.Text = "__ __";
            this.lblStylesPointsWithout.Click += new System.EventHandler(this.label18_Click);
            // 
            // lblStylesPointsWith
            // 
            this.lblStylesPointsWith.AutoSize = true;
            this.lblStylesPointsWith.Location = new System.Drawing.Point(461, 148);
            this.lblStylesPointsWith.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStylesPointsWith.Name = "lblStylesPointsWith";
            this.lblStylesPointsWith.Size = new System.Drawing.Size(96, 25);
            this.lblStylesPointsWith.TabIndex = 12;
            this.lblStylesPointsWith.Text = "__ __ __";
            this.lblStylesPointsWith.Click += new System.EventHandler(this.label17_Click);
            // 
            // lblStylesPoints
            // 
            this.lblStylesPoints.AutoSize = true;
            this.lblStylesPoints.Location = new System.Drawing.Point(661, 115);
            this.lblStylesPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStylesPoints.Name = "lblStylesPoints";
            this.lblStylesPoints.Size = new System.Drawing.Size(72, 25);
            this.lblStylesPoints.TabIndex = 11;
            this.lblStylesPoints.Text = "_____";
            this.lblStylesPoints.Click += new System.EventHandler(this.label16_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(695, 69);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 25);
            this.label15.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(459, 115);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 25);
            this.label14.TabIndex = 8;
            this.label14.Text = "Jump Style:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(460, 45);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 25);
            this.label13.TabIndex = 7;
            this.label13.Text = "Jump Distance:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 113);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 25);
            this.label12.TabIndex = 6;
            this.label12.Text = "K-Point:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 25);
            this.label11.TabIndex = 5;
            this.label11.Text = "Hill Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 25);
            this.label10.TabIndex = 4;
            this.label10.Text = "Name:";
            // 
            // lblJumpLength
            // 
            this.lblJumpLength.AutoSize = true;
            this.lblJumpLength.Location = new System.Drawing.Point(665, 46);
            this.lblJumpLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJumpLength.Name = "lblJumpLength";
            this.lblJumpLength.Size = new System.Drawing.Size(72, 25);
            this.lblJumpLength.TabIndex = 3;
            this.lblJumpLength.Text = "_____";
            // 
            // lblKPoint
            // 
            this.lblKPoint.AutoSize = true;
            this.lblKPoint.Location = new System.Drawing.Point(100, 113);
            this.lblKPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKPoint.Name = "lblKPoint";
            this.lblKPoint.Size = new System.Drawing.Size(72, 25);
            this.lblKPoint.TabIndex = 2;
            this.lblKPoint.Text = "_____";
            // 
            // lblHillName
            // 
            this.lblHillName.AutoSize = true;
            this.lblHillName.Location = new System.Drawing.Point(121, 81);
            this.lblHillName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHillName.Name = "lblHillName";
            this.lblHillName.Size = new System.Drawing.Size(72, 25);
            this.lblHillName.TabIndex = 1;
            this.lblHillName.Text = "_____";
            // 
            // lblJumperName
            // 
            this.lblJumperName.AutoSize = true;
            this.lblJumperName.Location = new System.Drawing.Point(91, 44);
            this.lblJumperName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJumperName.Name = "lblJumperName";
            this.lblJumperName.Size = new System.Drawing.Size(72, 25);
            this.lblJumperName.TabIndex = 0;
            this.lblJumperName.Text = "_____";
            this.lblJumperName.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnSendJumperAway
            // 
            this.btnSendJumperAway.BackColor = System.Drawing.Color.LightBlue;
            this.btnSendJumperAway.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendJumperAway.Location = new System.Drawing.Point(194, 347);
            this.btnSendJumperAway.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendJumperAway.Name = "btnSendJumperAway";
            this.btnSendJumperAway.Size = new System.Drawing.Size(661, 87);
            this.btnSendJumperAway.TabIndex = 6;
            this.btnSendJumperAway.Text = "Send Jumper Away";
            this.btnSendJumperAway.UseVisualStyleBackColor = false;
            this.btnSendJumperAway.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1044, 788);
            this.Controls.Add(this.btnSendJumperAway);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Ski Jumping Points Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tBarEntryLevel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHillName;
        private System.Windows.Forms.TextBox txtJumperName;
        private System.Windows.Forms.TextBox txtKPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tBarEntryLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Label lblJumpLength;
        private System.Windows.Forms.Label lblKPoint;
        private System.Windows.Forms.Label lblHillName;
        private System.Windows.Forms.Label lblJumperName;
        private System.Windows.Forms.Label lblPlatformLevel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStylesPointsWith;
        private System.Windows.Forms.Label lblStylesPoints;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblStylesPointsWithout;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.Label lblPlatformCompensation;
        private System.Windows.Forms.Label lblWindCompensation;
        private System.Windows.Forms.Label lblJumpPoints;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnSendJumperAway;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
    }
}

