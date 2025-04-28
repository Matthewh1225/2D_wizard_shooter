namespace _2D_shooter
{
    partial class GameScene
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScene));
            Player = new PictureBox();
            PlayerHealthBar = new ProgressBar();
            GameClock = new System.Windows.Forms.Timer(components);
            Moon = new PictureBox();
            EnemyHeaLthBAR = new ProgressBar();
            RoundTXT = new Label();
            printDialog1 = new PrintDialog();
            menuStrip1 = new MenuStrip();
            sepllsToolStripMenuItem = new ToolStripMenuItem();
            pinkSpellToolStripMenuItem = new ToolStripMenuItem();
            ShieldToolStripMenuItem = new ToolStripMenuItem();
            HealSpellToolStripMenuItem = new ToolStripMenuItem();
            TornadoSpellToolStripMenuItem = new ToolStripMenuItem();
            LightningSpellToolStripMenuItem = new ToolStripMenuItem();
            bindingSource1 = new BindingSource(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            fileToolStripMenuItem = new ToolStripMenuItem();
            EnemyClock = new System.Windows.Forms.Timer(components);
            playTextBox = new TextBox();
            playLabel = new Label();
            PlayButton = new Button();
            GmeOverTEXT = new Label();
            MenuCover = new PictureBox();
            ScoreText = new Label();
            MenuTitleText = new Label();
            GameBackgroundMusic = new AxWMPLib.AxWindowsMediaPlayer();
            SpellSwitchClick = new AxWMPLib.AxWindowsMediaPlayer();
            NoobDiffucltyButton = new Button();
            ConjurerDiffucltyButton = new Button();
            DifficultyText = new Label();
            GrandSorcererDifficultyButton = new Button();
            ManaBar = new ProgressBar();
            ManabarHack = new Label();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Moon).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MenuCover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GameBackgroundMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpellSwitchClick).BeginInit();
            SuspendLayout();
            // 
            // Player
            // 
            Player.BackColor = Color.Transparent;
            Player.Image = Properties.Resources.WizardFemale_right;
            Player.Location = new Point(311, 477);
            Player.Name = "Player";
            Player.Size = new Size(109, 162);
            Player.SizeMode = PictureBoxSizeMode.StretchImage;
            Player.TabIndex = 0;
            Player.TabStop = false;
            Player.Click += Player_Click;
            // 
            // PlayerHealthBar
            // 
            PlayerHealthBar.Location = new Point(311, 472);
            PlayerHealthBar.Name = "PlayerHealthBar";
            PlayerHealthBar.Size = new Size(100, 13);
            PlayerHealthBar.TabIndex = 1;
            PlayerHealthBar.Value = 100;
            PlayerHealthBar.Click += PlayerHealthBarEvent;
            // 
            // GameClock
            // 
            GameClock.Enabled = true;
            GameClock.Interval = 16;
            GameClock.Tick += GameClockEvent;
            // 
            // Moon
            // 
            Moon.BackColor = Color.Transparent;
            Moon.Image = Properties.Resources.moonFull_red;
            Moon.Location = new Point(981, 27);
            Moon.Name = "Moon";
            Moon.Size = new Size(131, 138);
            Moon.SizeMode = PictureBoxSizeMode.StretchImage;
            Moon.TabIndex = 2;
            Moon.TabStop = false;
            // 
            // EnemyHeaLthBAR
            // 
            EnemyHeaLthBAR.BackColor = Color.Red;
            EnemyHeaLthBAR.ForeColor = Color.Red;
            EnemyHeaLthBAR.Location = new Point(1091, 448);
            EnemyHeaLthBAR.Name = "EnemyHeaLthBAR";
            EnemyHeaLthBAR.Size = new Size(161, 23);
            EnemyHeaLthBAR.TabIndex = 3;
            EnemyHeaLthBAR.Value = 100;
            EnemyHeaLthBAR.Click += EnemyHealthbarEvent;
            // 
            // RoundTXT
            // 
            RoundTXT.BackColor = Color.Transparent;
            RoundTXT.Font = new Font("Segoe UI Symbol", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoundTXT.ForeColor = Color.Yellow;
            RoundTXT.Location = new Point(490, 0);
            RoundTXT.Name = "RoundTXT";
            RoundTXT.Size = new Size(281, 58);
            RoundTXT.TabIndex = 4;
            RoundTXT.Text = "Round";
            RoundTXT.Click += RoundTEXT;
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.Items.AddRange(new ToolStripItem[] { sepllsToolStripMenuItem, pinkSpellToolStripMenuItem, ShieldToolStripMenuItem, HealSpellToolStripMenuItem, TornadoSpellToolStripMenuItem, LightningSpellToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Margin = new Padding(0, 5, 0, 5);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(99, 681);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // sepllsToolStripMenuItem
            // 
            sepllsToolStripMenuItem.BackColor = Color.Transparent;
            sepllsToolStripMenuItem.BackgroundImageLayout = ImageLayout.Stretch;
            sepllsToolStripMenuItem.Font = new Font("Gabriola", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sepllsToolStripMenuItem.ForeColor = Color.Yellow;
            sepllsToolStripMenuItem.Margin = new Padding(0, 0, 0, 30);
            sepllsToolStripMenuItem.Name = "sepllsToolStripMenuItem";
            sepllsToolStripMenuItem.Padding = new Padding(4, 4, 4, 0);
            sepllsToolStripMenuItem.Size = new Size(92, 76);
            sepllsToolStripMenuItem.Text = "Spells";
            // 
            // pinkSpellToolStripMenuItem
            // 
            pinkSpellToolStripMenuItem.AutoSize = false;
            pinkSpellToolStripMenuItem.BackColor = Color.Fuchsia;
            pinkSpellToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pinkSpellToolStripMenuItem.ForeColor = Color.Black;
            pinkSpellToolStripMenuItem.Margin = new Padding(0, 0, 0, 30);
            pinkSpellToolStripMenuItem.Name = "pinkSpellToolStripMenuItem";
            pinkSpellToolStripMenuItem.Size = new Size(92, 80);
            pinkSpellToolStripMenuItem.Text = "PinkSpell";
            pinkSpellToolStripMenuItem.Click += PinkSpellEvent;
            // 
            // ShieldToolStripMenuItem
            // 
            ShieldToolStripMenuItem.AutoSize = false;
            ShieldToolStripMenuItem.BackColor = Color.Sienna;
            ShieldToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShieldToolStripMenuItem.Margin = new Padding(0, 0, 0, 30);
            ShieldToolStripMenuItem.Name = "ShieldToolStripMenuItem";
            ShieldToolStripMenuItem.Size = new Size(92, 80);
            ShieldToolStripMenuItem.Text = "ShieldSpell";
            ShieldToolStripMenuItem.Click += ShieldMenuClickEvent;
            // 
            // HealSpellToolStripMenuItem
            // 
            HealSpellToolStripMenuItem.AutoSize = false;
            HealSpellToolStripMenuItem.BackColor = Color.Lime;
            HealSpellToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HealSpellToolStripMenuItem.Margin = new Padding(0, 0, 0, 30);
            HealSpellToolStripMenuItem.Name = "HealSpellToolStripMenuItem";
            HealSpellToolStripMenuItem.Size = new Size(92, 80);
            HealSpellToolStripMenuItem.Text = "HealSpell";
            HealSpellToolStripMenuItem.Click += HealSpellEvent;
            // 
            // TornadoSpellToolStripMenuItem
            // 
            TornadoSpellToolStripMenuItem.AutoSize = false;
            TornadoSpellToolStripMenuItem.BackColor = Color.Gray;
            TornadoSpellToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TornadoSpellToolStripMenuItem.ForeColor = Color.Black;
            TornadoSpellToolStripMenuItem.Margin = new Padding(0, 0, 0, 30);
            TornadoSpellToolStripMenuItem.Name = "TornadoSpellToolStripMenuItem";
            TornadoSpellToolStripMenuItem.Size = new Size(92, 80);
            TornadoSpellToolStripMenuItem.Text = "Tornado";
            TornadoSpellToolStripMenuItem.Click += TornadoSpeelEvent;
            // 
            // LightningSpellToolStripMenuItem
            // 
            LightningSpellToolStripMenuItem.AutoSize = false;
            LightningSpellToolStripMenuItem.BackColor = Color.Cyan;
            LightningSpellToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LightningSpellToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
            LightningSpellToolStripMenuItem.Margin = new Padding(0, 0, 0, 30);
            LightningSpellToolStripMenuItem.Name = "LightningSpellToolStripMenuItem";
            LightningSpellToolStripMenuItem.Size = new Size(92, 80);
            LightningSpellToolStripMenuItem.Text = "Lightning";
            LightningSpellToolStripMenuItem.Click += LightningSpellEvent;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(32, 19);
            // 
            // EnemyClock
            // 
            EnemyClock.Enabled = true;
            EnemyClock.Tick += EnemyClockEvent;
            // 
            // playTextBox
            // 
            playTextBox.BackColor = SystemColors.AppWorkspace;
            playTextBox.Font = new Font("Gabriola", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playTextBox.ForeColor = Color.Black;
            playTextBox.Location = new Point(490, 268);
            playTextBox.Multiline = true;
            playTextBox.Name = "playTextBox";
            playTextBox.PlaceholderText = "type here...";
            playTextBox.Size = new Size(293, 61);
            playTextBox.TabIndex = 6;
            playTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // playLabel
            // 
            playLabel.BackColor = SystemColors.ButtonShadow;
            playLabel.FlatStyle = FlatStyle.Popup;
            playLabel.Font = new Font("Gabriola", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playLabel.ForeColor = Color.Black;
            playLabel.Location = new Point(437, 132);
            playLabel.Name = "playLabel";
            playLabel.Size = new Size(404, 121);
            playLabel.TabIndex = 7;
            playLabel.Text = "      Type \"PLAY or \"EXIT\" below,                 then press button";
            playLabel.Click += playLabel_Click;
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Green;
            PlayButton.Font = new Font("Gabriola", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayButton.ForeColor = SystemColors.ActiveCaptionText;
            PlayButton.Location = new Point(490, 332);
            PlayButton.Margin = new Padding(3, 3, 0, 0);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(293, 79);
            PlayButton.TabIndex = 8;
            PlayButton.Text = "PressToPlayOrExit";
            PlayButton.UseVisualStyleBackColor = false;
            PlayButton.Click += ButtonClickEvent;
            // 
            // GmeOverTEXT
            // 
            GmeOverTEXT.BackColor = Color.Transparent;
            GmeOverTEXT.Font = new Font("Yu Gothic", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GmeOverTEXT.ForeColor = Color.Firebrick;
            GmeOverTEXT.Location = new Point(547, 332);
            GmeOverTEXT.Name = "GmeOverTEXT";
            GmeOverTEXT.Size = new Size(10, 11);
            GmeOverTEXT.TabIndex = 9;
            GmeOverTEXT.Text = "0";
            // 
            // MenuCover
            // 
            MenuCover.BackColor = SystemColors.ControlDarkDark;
            MenuCover.BackgroundImage = Properties.Resources.MenuBackground;
            MenuCover.BackgroundImageLayout = ImageLayout.Stretch;
            MenuCover.Location = new Point(0, 0);
            MenuCover.Name = "MenuCover";
            MenuCover.Size = new Size(1265, 681);
            MenuCover.TabIndex = 10;
            MenuCover.TabStop = false;
            // 
            // ScoreText
            // 
            ScoreText.BackColor = Color.Transparent;
            ScoreText.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScoreText.ForeColor = Color.Yellow;
            ScoreText.Location = new Point(190, 0);
            ScoreText.Name = "ScoreText";
            ScoreText.Size = new Size(483, 253);
            ScoreText.TabIndex = 11;
            ScoreText.Text = "Score:";
            // 
            // MenuTitleText
            // 
            MenuTitleText.BackColor = SystemColors.ButtonShadow;
            MenuTitleText.FlatStyle = FlatStyle.Popup;
            MenuTitleText.Font = new Font("Gabriola", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MenuTitleText.Location = new Point(437, 116);
            MenuTitleText.Name = "MenuTitleText";
            MenuTitleText.Size = new Size(404, 149);
            MenuTitleText.TabIndex = 12;
            MenuTitleText.Text = "Spell Strike";
            // 
            // GameBackgroundMusic
            // 
            GameBackgroundMusic.Enabled = true;
            GameBackgroundMusic.Location = new Point(1215, 38);
            GameBackgroundMusic.Name = "GameBackgroundMusic";
            GameBackgroundMusic.OcxState = (AxHost.State)resources.GetObject("GameBackgroundMusic.OcxState");
            GameBackgroundMusic.Size = new Size(37, 35);
            GameBackgroundMusic.TabIndex = 13;
            // 
            // SpellSwitchClick
            // 
            SpellSwitchClick.Enabled = true;
            SpellSwitchClick.Location = new Point(1215, 79);
            SpellSwitchClick.Name = "SpellSwitchClick";
            SpellSwitchClick.OcxState = (AxHost.State)resources.GetObject("SpellSwitchClick.OcxState");
            SpellSwitchClick.Size = new Size(36, 30);
            SpellSwitchClick.TabIndex = 14;
            SpellSwitchClick.Tag = "";
            SpellSwitchClick.Visible = false;
            // 
            // NoobDiffucltyButton
            // 
            NoobDiffucltyButton.BackColor = Color.Green;
            NoobDiffucltyButton.Font = new Font("SimSun-ExtG", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoobDiffucltyButton.Location = new Point(168, 150);
            NoobDiffucltyButton.Name = "NoobDiffucltyButton";
            NoobDiffucltyButton.Size = new Size(155, 58);
            NoobDiffucltyButton.TabIndex = 15;
            NoobDiffucltyButton.Text = "Acolyte";
            NoobDiffucltyButton.UseVisualStyleBackColor = false;
            NoobDiffucltyButton.Click += NoobModeClick;
            // 
            // ConjurerDiffucltyButton
            // 
            ConjurerDiffucltyButton.BackColor = Color.DarkOrange;
            ConjurerDiffucltyButton.Font = new Font("SimSun-ExtB", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConjurerDiffucltyButton.Location = new Point(168, 232);
            ConjurerDiffucltyButton.Name = "ConjurerDiffucltyButton";
            ConjurerDiffucltyButton.Size = new Size(155, 58);
            ConjurerDiffucltyButton.TabIndex = 16;
            ConjurerDiffucltyButton.Text = "Conjurer";
            ConjurerDiffucltyButton.UseVisualStyleBackColor = false;
            ConjurerDiffucltyButton.Click += ConjurerDifficultyEvent;
            // 
            // DifficultyText
            // 
            DifficultyText.BackColor = SystemColors.ButtonShadow;
            DifficultyText.Font = new Font("Gabriola", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DifficultyText.ForeColor = Color.Yellow;
            DifficultyText.Location = new Point(102, 79);
            DifficultyText.Name = "DifficultyText";
            DifficultyText.Size = new Size(318, 54);
            DifficultyText.TabIndex = 17;
            DifficultyText.Text = "Cick to Choose Difficulty";
            DifficultyText.Click += label1_Click;
            // 
            // GrandSorcererDifficultyButton
            // 
            GrandSorcererDifficultyButton.BackColor = Color.Firebrick;
            GrandSorcererDifficultyButton.Font = new Font("Gabriola", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GrandSorcererDifficultyButton.ForeColor = SystemColors.InactiveCaptionText;
            GrandSorcererDifficultyButton.Location = new Point(168, 310);
            GrandSorcererDifficultyButton.Name = "GrandSorcererDifficultyButton";
            GrandSorcererDifficultyButton.Size = new Size(155, 58);
            GrandSorcererDifficultyButton.TabIndex = 18;
            GrandSorcererDifficultyButton.Text = "GrandSorcerer";
            GrandSorcererDifficultyButton.UseVisualStyleBackColor = false;
            GrandSorcererDifficultyButton.Click += GrandSorcererEvent;
            // 
            // ManaBar
            // 
            ManaBar.Location = new Point(311, 448);
            ManaBar.Name = "ManaBar";
            ManaBar.Size = new Size(100, 13);
            ManaBar.TabIndex = 19;
            ManaBar.Value = 100;
            ManaBar.Click += ManaBar_Click;
            // 
            // ManabarHack
            // 
            ManabarHack.BackColor = Color.DeepSkyBlue;
            ManabarHack.Location = new Point(311, 432);
            ManabarHack.Name = "ManabarHack";
            ManabarHack.Size = new Size(100, 13);
            ManabarHack.TabIndex = 20;
            // 
            // GameScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            BackgroundImage = Properties.Resources.Backgorundimage2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(GrandSorcererDifficultyButton);
            Controls.Add(DifficultyText);
            Controls.Add(ConjurerDiffucltyButton);
            Controls.Add(NoobDiffucltyButton);
            Controls.Add(MenuTitleText);
            Controls.Add(playLabel);
            Controls.Add(playTextBox);
            Controls.Add(PlayButton);
            Controls.Add(MenuCover);
            Controls.Add(GmeOverTEXT);
            Controls.Add(RoundTXT);
            Controls.Add(EnemyHeaLthBAR);
            Controls.Add(PlayerHealthBar);
            Controls.Add(Player);
            Controls.Add(Moon);
            Controls.Add(menuStrip1);
            Controls.Add(ScoreText);
            Controls.Add(GameBackgroundMusic);
            Controls.Add(SpellSwitchClick);
            Controls.Add(ManaBar);
            Controls.Add(ManabarHack);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "GameScene";
            Text = "  ";
            Load += GameScene_Load;
            KeyDown += keyisDown;
            KeyUp += keyisUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Moon).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)MenuCover).EndInit();
            ((System.ComponentModel.ISupportInitialize)GameBackgroundMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpellSwitchClick).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Player;
        private ProgressBar PlayerHealthBar;
        private System.Windows.Forms.Timer GameClock;
        private PictureBox Moon;
        private ProgressBar EnemyHeaLthBAR;
        private Label RoundTXT;
        private PrintDialog printDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem pinkSpellToolStripMenuItem;
        private ToolStripMenuItem TornadoSpellToolStripMenuItem;
        private ToolStripMenuItem LightningSpellToolStripMenuItem;
        private BindingSource bindingSource1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Timer EnemyClock;
        private TextBox playTextBox;
        private Label playLabel;
        private Button PlayButton;
        private Label GmeOverTEXT;
        private PictureBox MenuCover;
        private Label ScoreText;
        private ToolStripMenuItem sepllsToolStripMenuItem;
        private Label MenuTitleText;
        private ToolStripMenuItem ShieldToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer GameBackgroundMusic;
        private AxWMPLib.AxWindowsMediaPlayer SpellSwitchClick;
        private Button NoobDiffucltyButton;
        private Button ConjurerDiffucltyButton;
        private Label DifficultyText;
        private Button GrandSorcererDifficultyButton;
        private ProgressBar ManaBar;
        private Label ManabarHack;
        private ToolStripMenuItem HealSpellToolStripMenuItem;
    }
}
