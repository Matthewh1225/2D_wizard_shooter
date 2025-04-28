
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices.Marshalling;
using _2D_shooter.Properties;
using Timer = System.Windows.Forms.Timer;

namespace _2D_shooter
{

    //types of player spells
    public enum SpellType
    {
        Pink,
        Sword,
        Heal,
        Shield,
        Tornado,
        Lightning
    }
    public partial class GameScene : Form
    {
        Random r = new Random();
        Enemy enemy;
        List<Spell> AllSpells = [];
        Timer playerImageResetTimer = new Timer();
        //bools for movement/difficulty/other checks
        bool movingLeft, movingRight, movingUp;
        bool easy = false, medium = true, hard = false;
        bool DrawPlayer = true;
        bool onGround = true;
        bool CanFire = true;

        //resource pths for sounds
        string ShootSound = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ShootSound.wav");
        string PathSwitch = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "switch25.wav");
        string PathMusic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Game Over.wav");
        string facing = "left";
        
        public int EnemyMaxShots = 10;
        public int Mana = 1000;
        int Round = 1;
        int Score = 0;   
        int PlayerHealth = 15000;
        int PlayerMaxHealth = 15000;

        //physics nums
        const int speed = 10;
        int Jump = -50;
        int Gravity = 5;
        int xSpeed = 0;
        int ySpeed = 0;
        //defult spell
        SpellType currentSpell = SpellType.Pink;
        public GameScene()
        {
            InitializeComponent();

            Round = 1;
     
            GameBackgroundMusic.URL = PathMusic;
            GameBackgroundMusic.settings.volume = 3;
            GameBackgroundMusic.settings.setMode("loop", true);
            GameBackgroundMusic.Hide();

            Player.Image = Properties.Resources.FemalewIZARD_LEFT;
            DrawPlayer = false;
            playerImageResetTimer.Interval = 500;
            playerImageResetTimer.Tick += ResetPlayerImage;
            //start a new round 
            NextRound();
        }
       
        private void GameClockEvent(object sender, EventArgs e)
        {

            int ManaAdd = 4;
            Mana = Math.Min(Mana + ManaAdd, 1000);

            // delta time for movment
            float ratio = (16f / (float)GameClock.Interval);
            CanFire = true;
            //reveal/hides the game screen menue on button press/dispose
            if (!playTextBox.IsDisposed)
            {
                CanFire = false;

                PlayerHealthBar.Hide();
                ManaBar.Hide();
                ManabarHack.Hide();
                enemy.Hide();
                EnemyHeaLthBAR.Hide();
            }
            else
            {//button sound
                SpellSwitchClick.URL = PathSwitch;

                DifficultyText.Dispose();
                NoobDiffucltyButton.Dispose();
                ConjurerDiffucltyButton.Dispose();
                GrandSorcererDifficultyButton.Dispose();

                PlayerHealthBar.Show();
                ManabarHack.Show();

                enemy.Show();
                EnemyHeaLthBAR.Show();
            }

            //ends the game if player dies
            if (PlayerHealth <= 0)
            {
                GameBackgroundMusic.Dispose();
                CanFire = false;
                DrawPlayer = false;
                GmeOverTEXT.BringToFront();
                GmeOverTEXT.Text = "You Died!";
                GmeOverTEXT.Size = new Size(500, 500);
            }
            //make sure im are not drawing the image every frame and directon
            if (DrawPlayer)
            {
                DrawPlayer = false;
                if (movingLeft)
                {
                   
                    Player.Image = Properties.Resources.FemalewIZARD_LEFT;

                }
                else if (movingRight)
                {
                    Player.Image = Properties.Resources.WizardFemale_right;

                }
            }
            //SHOW another spell button when score value is hit
            if (Score >= 1000)
            {
                ShieldToolStripMenuItem.Visible = true;
            }
            else
            {
                ShieldToolStripMenuItem.Visible = false;
            }
            if (Score >= 3000)
            {
                HealSpellToolStripMenuItem.Visible = true;
            }
            else
            {
                HealSpellToolStripMenuItem.Visible = false;
            }

            if (Score >= 6000)
            {
                TornadoSpellToolStripMenuItem.Visible = true;
            }
            else
            {
                TornadoSpellToolStripMenuItem.Visible = false;
            }

            if (Score >= 8000)
            {
                LightningSpellToolStripMenuItem.Visible = true;
            }
            else
            {
                LightningSpellToolStripMenuItem.Visible = false;
            }
            //stop playaer from going out of map
            var CurrentLocation = Player.Location;
            if (Player.Right > 1280)
            {
                xSpeed = Math.Min(xSpeed, 0);
            }
            if (Player.Left < 0)
            {
                xSpeed = Math.Max(xSpeed, 0);
            }
            //updates health/manbar and player,locaton and defines the ground
            Player.Location = new Point((int)(CurrentLocation.X + xSpeed / ratio), (int)(CurrentLocation.Y + ySpeed / ratio));
            PlayerHealthBar.Location = new Point(CurrentLocation.X, CurrentLocation.Y);
            ManaBar.Location = new Point(CurrentLocation.X, CurrentLocation.Y - 20);
            ManaBar.Value = Math.Min(Mana / 10, ManaBar.Maximum);
            ManabarHack.Location = new Point(CurrentLocation.X, CurrentLocation.Y - 20);
            ManabarHack.Size = new Size(Math.Min(Mana / 10, 100), 11);
            onGround = Player.Bottom > 650;

            if (onGround)
            {
                ySpeed = 0;
            }
            if (!onGround)
            {
                ySpeed += (int)((float)Gravity / ratio);
            }

            //destroy Spell if offscreen || if hits enemy
            AllSpells.RemoveAll(Spell => Spell.offScreen);
            foreach (Spell Spell in AllSpells)
            {
                if ((string?)enemy.Tag == "enemy" &&
                    (string?)Spell.SpellPicture.Tag == "Spell" &&
                    enemy.Bounds.IntersectsWith(Spell.SpellPicture.Bounds))
                {
                    using var hit = new SoundPlayer(
                    new MemoryStream(Properties.Resources.impactBell_heavy_004));
                    hit.Play();
                    Spell.DestroySpell();

                    enemy.EnemyHealth -= Spell.SpellDamage;

                    if (enemy.EnemyHealth <= 0)
                    {
                        Score += 420;
                        EnemyHeaLthBAR.Value = 0;

                        enemy.Dispose();
                        EnemyHeaLthBAR.Hide();
                        Round++;
                        NextRound();
                    }
                    else
                    {
                        Score += 50;

                        int pct = (enemy.EnemyHealth * 100) / enemy.MaxHealth;  
                        EnemyHeaLthBAR.Value = Math.Max(0, pct);                
                    }
                    break; 
                }
            }
            // Check for shield ON Spell collisions
            if (currentSpell == SpellType.Shield)
            {
                foreach (Spell playerSpell in AllSpells.ToList())
                {
                    if (playerSpell.offScreen) continue;

                    foreach (Spell enemySpell in enemy.Spells.ToList())
                    {
                        if (enemySpell.offScreen) continue;

                        if (playerSpell.SpellPicture.Bounds.IntersectsWith(enemySpell.SpellPicture.Bounds))
                        {
                            // Dispose Spells
                            enemySpell.DestroySpell();
                            enemy.Spells.Remove(enemySpell);
                        }
                    }
                }
            }
            // Remove all off-screen
            AllSpells.RemoveAll(Spell => Spell.offScreen);
            enemy.Spells.RemoveAll(Spell => Spell.offScreen); ;
            //updatescore
            ScoreText.Text = $"Score: {Score}";

            //if enemy Spell hits player, playe sound and destroy
            foreach (Spell Spell in enemy.Spells)
            {
                if (Spell.offScreen)
                {
                    continue;
                }
                if (Player.Bounds.IntersectsWith(Spell.SpellPicture.Bounds) && PlayerHealth > 0)
                {
                    var hit = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.impactBell_heavy_004));
                    hit.Play();
                    Spell.offScreen = true;
                    Spell.SpellPicture.Dispose();
                    if (PlayerHealth - Spell.SpellDamage < 0)
                    {
                        PlayerHealth = 0;
                    }
                    else
                    {
                        PlayerHealth -= Spell.SpellDamage;
                        PlayerHealthBar.Value = (PlayerHealth * 100) / PlayerMaxHealth;
                    }
                }
            }
            enemy.Spells.RemoveAll(Spell => Spell.offScreen);
        }
        //handle movement, direction and booleans for it
        private void keyisDown(object sender, KeyEventArgs e)
        {
            if (PlayerHealth > 0)
            {
                if (e.KeyCode == Keys.D)
                {
                    if (!movingRight)
                    {
                        movingLeft = false;
                        movingRight = true;
                        xSpeed = speed;
                        DrawPlayer = true;
                        facing = "right";
                    }
                }
                if (e.KeyCode == Keys.A)
                {
                    if (!movingLeft)
                    {
                        movingRight = false;
                        xSpeed = -speed;
                        facing = "left";
                        DrawPlayer = true;
                        movingLeft = true;
                    }
                }
                if (e.KeyCode == Keys.W && onGround)
                {
                    ySpeed = Jump;
                    movingUp = true;
                }
                if (e.KeyCode == Keys.Space)
                {
                    if (facing == "left")
                    {
                        Player.Image = Properties.Resources.WizardFemaleAttacking_Left;
                    }
                    else if (facing == "right")
                    {
                        Player.Image = Properties.Resources.WizardFemaleAttacking;
                    }

                    playerImageResetTimer.Start();
                    ShootEvent(sender, e);
                }
            }
        }
        //set speed and bool to false on keyup
        private void keyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && xSpeed > 0)
            {
                xSpeed = 0;
                movingRight = false;
            }
            if (e.KeyCode == Keys.A && xSpeed < 0)
            {
                xSpeed = 0;
                movingLeft = false;
            }
            if (e.KeyCode == Keys.W)
            {
                movingUp = false;
            }
        }
            //check mana spelltype and add to SpellList /heal
            void PlayerShoot(string direction, SpellType spell, int manaCost)
            {

                if (Mana < manaCost || AllSpells.Count >= 3) return;
            
                if (spell == SpellType.Heal)
                {
                    PlayerHealth = Math.Min(PlayerHealth + 2500, PlayerMaxHealth);
                    direction = "up";
                    Mana -= manaCost;
                    return;
                }

            var ShootSound = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.ShootSound));
            ShootSound.Play();



            Mana -= manaCost;
            AllSpells.Add(new Spell(this, spell, direction, Player, speed));
        }
        // for player "animation"
        private void ResetPlayerImage(object sender, EventArgs e)
        {
            if (facing == "left")
            {
                Player.Image = Properties.Resources.FemalewIZARD_LEFT;
            }
            else if (facing == "right")
            {
                Player.Image = Properties.Resources.WizardFemale_right;
            }

            playerImageResetTimer.Stop(); // Stop the timer
        }
        public void spawnEnemy(string EnemyType,int Hp)
        {

            if (EnemyType == "Dragon")
            {
                Point EnemeySpawnLocation = new Point(1020, 400);
                enemy = new Enemy(EnemeySpawnLocation, Properties.Resources.dragoncut, Hp, this, Properties.Resources.attack_dragon, new Size(150, 300), new Size(200, 300), "FireBall", EnemyMaxShots);
                enemy.Image = Properties.Resources.dragoncut;
                enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(enemy);
                enemy.BringToFront();
            }
            else if (EnemyType == "robot")
            {
                Point EnemeySpawnLocation = new Point(1100, 470);
                enemy = new Enemy(EnemeySpawnLocation, Properties.Resources.robot_sprite_facing_right, Hp, this, Properties.Resources.robot_shoot, new Size(100, 200), new Size(100, 200), "Lazer", EnemyMaxShots);
                enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(enemy);
                enemy.BringToFront();
            }
            else if (EnemyType == "Knight")
            {
                Point EnemeySpawnLocation = new Point(1100, 450);
                enemy = new Enemy(EnemeySpawnLocation, Properties.Resources.Dark_Knight, Hp, this, Properties.Resources.Dark_Knight_Attacking, new Size(100, 200), new Size(100, 200), "Arrow", EnemyMaxShots);
                enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(enemy);
                enemy.BringToFront();
            }
            else if (EnemyType == "Trump")
            {
                Point EnemeySpawnLocation = new Point(1100, 460);
                enemy = new Enemy(EnemeySpawnLocation, Properties.Resources.Trump, Hp, this, Properties.Resources.trumpAttack, new Size(100, 200), new Size(100, 200), "Money", EnemyMaxShots);
                enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(enemy);
                enemy.BringToFront();
            }
            EnemyHeaLthBAR.Top = enemy.Top - 30;
            EnemyHeaLthBAR.BringToFront();
        }
        public void NextRound()
        {
            const int StageCount = 4;
            int stage = ((Round - 1) % StageCount) + 1;      // 1-4 repeating using modulo loop
            int loop = (Round - 1) / StageCount; 
            //set new stage stats  and enemys
            string enemyType;
            int baseHp;
            Image newBg;
            Image moonImg;

            switch (stage)
            {
                case 1: 
                    enemyType = "Dragon";
                    baseHp = 20;
                    newBg = Properties.Resources.lavaBackgorund;
                    moonImg = Properties.Resources.moonFull_red;
                    break;

                case 2: 
                    enemyType = "robot";
                    baseHp = 40;
                    newBg = Properties.Resources.CyberCity;
                    moonImg = Properties.Resources.moon_half;
                    break;

                case 3: 
                    enemyType = "Knight";
                    baseHp = 60;
                    newBg = Properties.Resources.Castle;
                    moonImg = Properties.Resources.background_cloudA;
                    break;

                case 4: 
                default:
                    enemyType = "Trump";
                    baseHp = 100;
                    newBg = Properties.Resources.WhiteHOUSE;
                    moonImg = Properties.Resources.TelsaSpace;
                    break;
            }
            // scaled HP 50% per  loop
            int scaledHp = (int)(baseHp * (1f + 0.5f * loop));

            this.BackgroundImage = newBg;
            Moon.Image = moonImg;

            // wrap around when it moves off
            int newX = (Moon.Location.X <= -Moon.Width)? ClientSize.Width: Moon.Location.X - 20; Moon.Location = new Point(newX, Moon.Location.Y);

            RoundTXT.Text = $"Round : {Round}";

            EnemyHeaLthBAR.Maximum = 100;
            EnemyHeaLthBAR.Value = 100;
            EnemyHeaLthBAR.Show();


            spawnEnemy(enemyType, scaledHp);

            EnemyHeaLthBAR.Top = enemy.Top - 30;
        }

        //Empty
        private void GameScene_Load(object sender, EventArgs e)
        {

        }
        private void playLabel_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ManaBar_Click(object sender, EventArgs e)
        {

        }
        private void Player_Click(object sender, EventArgs e)
        {

        }
        private void EnemyHealthbarEvent(object sender, EventArgs e)
        {

        }
        private void RoundTEXT(object sender, EventArgs e)
        {
        }
        private void PlayerHealthBarEvent(object sender, EventArgs e)
        {
        }


        //SpellMenuLogcic to change color 
        private void PinkSpellEvent(object sender, EventArgs e)
        {
           
            currentSpell = SpellType.Pink;
            var Switch = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.switch25));
            Switch.Play();


            HealSpellToolStripMenuItem.BackColor = Color.LimeGreen;
            pinkSpellToolStripMenuItem.BackColor = Color.White;
            ShieldToolStripMenuItem.BackColor = Color.Sienna;
            LightningSpellToolStripMenuItem.BackColor = Color.Cyan;
            TornadoSpellToolStripMenuItem.BackColor = Color.Gray;
        }
        private void TornadoSpeelEvent(object sender, EventArgs e)
        {
            currentSpell = SpellType.Tornado;

            var Switch = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.switch25));
            Switch.Play();

            HealSpellToolStripMenuItem.BackColor = Color.LimeGreen;
            TornadoSpellToolStripMenuItem.BackColor = Color.White;
            ShieldToolStripMenuItem.BackColor = Color.Sienna;
            LightningSpellToolStripMenuItem.BackColor = Color.Cyan;
            pinkSpellToolStripMenuItem.BackColor = Color.Fuchsia;
        }
        private void LightningSpellEvent(object sender, EventArgs e)
        {
            currentSpell = SpellType.Lightning;
            var Switch = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.switch25));
            Switch.Play();

            HealSpellToolStripMenuItem.BackColor = Color.LimeGreen;
            LightningSpellToolStripMenuItem.BackColor = Color.WhiteSmoke;
            ShieldToolStripMenuItem.BackColor = Color.Sienna;
            TornadoSpellToolStripMenuItem.BackColor = Color.Gray;
            pinkSpellToolStripMenuItem.BackColor = Color.Fuchsia;
        }
        private void ShieldMenuClickEvent(object sender, EventArgs e)
        {
            currentSpell = SpellType.Shield;
            var Switch = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.switch25));
            Switch.Play();

            HealSpellToolStripMenuItem.BackColor = Color.LimeGreen;
            ShieldToolStripMenuItem.BackColor = Color.WhiteSmoke;
            LightningSpellToolStripMenuItem.BackColor = Color.Cyan;
            TornadoSpellToolStripMenuItem.BackColor = Color.Gray;
            pinkSpellToolStripMenuItem.BackColor = Color.Fuchsia;
        }
        private void HealSpellEvent(object sender, EventArgs e)
        {
            currentSpell = SpellType.Heal;

            var Switch = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.switch25));
            Switch.Play();

            HealSpellToolStripMenuItem.BackColor = Color.WhiteSmoke;
            ShieldToolStripMenuItem.BackColor = Color.Sienna;
            LightningSpellToolStripMenuItem.BackColor = Color.Cyan;
            TornadoSpellToolStripMenuItem.BackColor = Color.Gray;
            pinkSpellToolStripMenuItem.BackColor = Color.Fuchsia;
        }
        //define Manacost and call Shoot
        private void ShootEvent(object sender, EventArgs e)
        {
            int ManaCost = 0;
            if (currentSpell == SpellType.Pink)
            {
                ManaCost = 50;
            }
            else if (currentSpell == SpellType.Heal)
            {
                ManaCost = 750;
            }
            else if (currentSpell == SpellType.Sword)
            {
                ManaCost = 100;
            }
            else if (currentSpell == SpellType.Tornado)
            {
                ManaCost = 200;
            }
            else if (currentSpell == SpellType.Shield)
            {
                ManaCost = 400;
            }
            else if (currentSpell == SpellType.Lightning)
            {
                ManaCost = 500;

            }
            PlayerShoot(facing, currentSpell, ManaCost);
        }
        //set enemy firRate based on difficulty
        private void EnemyClockEvent(object sender, EventArgs e)
        {
            if (CanFire)
            {
                if (easy)
                {
                    if (r.Next(1, 15) > 1) return;
                }
                else if (medium)
                {
                    if (r.Next(1, 8) > 1) return;
                }
                else if (hard)
                {
                    if (r.Next(1, 4) > 1) return;
                }
                else
                {
                    if (r.Next(1, 15) > 1) return;

                }
                enemy.Enemyshoot();
            }
        }
        // play/Exit ButtonLogic
        private void ButtonClickEvent(object sender, EventArgs e)
        {
            var Switch = new SoundPlayer(new System.IO.MemoryStream(Properties.Resources.switch25));
            Switch.Play();

            if (playTextBox.Text.ToLower() == "play")
            {
                MenuTitleText.Dispose();
                MenuCover.Dispose();
                playTextBox.Clear();
                playLabel.Dispose();
                playTextBox.Dispose();
                PlayButton.Dispose();
            }
            if (playTextBox.Text.ToLower() == "exit")
            {
                Application.Exit();
            }
        }
       //difficulty button logic
        private void NoobModeClick(object sender, EventArgs e)
        {
            easy = true;
            medium = false;
            hard = false;
            ConjurerDiffucltyButton.BackColor = Color.DarkOrange;
            NoobDiffucltyButton.BackColor = Color.White;
            GrandSorcererDifficultyButton.BackColor = Color.Firebrick;

            SpellSwitchClick.URL = PathSwitch;
        }
        private void ConjurerDifficultyEvent(object sender, EventArgs e)
        {
            easy = false;
            medium = true;
            hard = false;
            ConjurerDiffucltyButton.BackColor = Color.White;
            GrandSorcererDifficultyButton.BackColor = Color.Firebrick;
            NoobDiffucltyButton.BackColor = Color.Green;
            SpellSwitchClick.URL = PathSwitch;
        }
        private void GrandSorcererEvent(object sender, EventArgs e)
        {
            easy = false;
            medium = false;
            hard = true;
            ConjurerDiffucltyButton.BackColor = Color.DarkOrange;
            GrandSorcererDifficultyButton.BackColor = Color.White;
            NoobDiffucltyButton.BackColor = Color.Green;
            SpellSwitchClick.URL = PathSwitch;
        }

    }
 
    class Spell
    {

        public int SpellDamage = 10;
        public bool offScreen=false;
        public string? direction;
        public int speed;

        //to track Spell
        public int SpellTop; 
        public int SpellLeft;

        public PictureBox SpellPicture = new();
        Timer SpellTimer = new();
        public Spell(Form form, SpellType spell, string dir, PictureBox player, int speed)
        {
            direction = dir;
            this.speed = speed;
            SpellLeft = player.Left + player.Width / 2;
            SpellTop = player.Top + (player.Height / 2 - 15);
            createPlayerSpell(form, spell);
        }
        void createPlayerSpell(Form form, SpellType spell)
        {   //use Enun and switch for changing spell type 
            switch (spell)
            {
                case SpellType.Pink:
                    {
                        SpellDamage = 5;
                        CreateSpell(form, Properties.Resources.laserPink_burst_New, new Size(30, 30));
                        break;
                    }
                case SpellType.Sword:
                    {
                        SpellDamage = 10;
                        CreateSpell(form, Properties.Resources.SwordThrow1, new Size(60, 30));
                        break;
                    }
                case SpellType.Heal:
                    {
                        SpellDamage = 0;
                        CreateSpell(form, Properties.Resources.HealOrbs1, new Size(70, 70));
                        break;
                    }
                case SpellType.Shield:
                    {
                        SpellDamage = 5;
                        CreateSpell(form, Properties.Resources.Shield1, new Size(80, 120));
                        break;
                    }
                case SpellType.Tornado:
                    {
                        SpellDamage = 25;
                        CreateSpell(form, Properties.Resources.TornadoAttack, new Size(40, 160));
                        break;
                    }
                case SpellType.Lightning:
                    {
                        SpellDamage = 50;
                        CreateSpell(form, Properties.Resources.lightningBolt1, new Size(300, 40));
                        break;
                    }
            }
        }

        // ENEMY Spells 
        public Spell(Form form, string enemyShot, string dir, PictureBox enemy, int speed)
        {
            direction = dir;
            this.speed = speed;
            SpellLeft = enemy.Left + enemy.Width / 2;
            SpellTop = enemy.Top + (enemy.Height / 2 - 15);
            createEnemySpell(form, enemyShot);
        }
        public void createEnemySpell(Form form, string type)
        {
            if (type == "FireBall")
            {
                SpellDamage = 150;
                CreateSpell(form, Properties.Resources.fire, new Size(50, 50));
            }
            else if (type == "Lazer")
            {
                SpellDamage = 300;
                CreateSpell(form, Properties.Resources.laserRed03, new Size(70, 30));
            }
            else if (type == "Arrow")
            {
                SpellDamage = 375;
                CreateSpell(form, Properties.Resources.arrow, new Size(80, 30));
            }
            else if (type == "Money")
            {
                SpellDamage = 600;
                CreateSpell(form, Properties.Resources.moneyStack, new Size(60, 60));
            }
        }
        //ckeck directon for spell and destroy if offscreen
        void SpellTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                SpellPicture.Left -= speed;
            }
            if (direction == "right")
            {
                SpellPicture.Left += speed;
            }
            if (direction == "up")
            {
                SpellPicture.Top -= speed;
            }
            if (SpellPicture.Left < 0 || SpellPicture.Right > 1300 || SpellPicture.Top < 0)
            {
                DestroySpell();
            }
        }
        //define the spell image/ spellstart timer
        void CreateSpell(Form form,Bitmap image,Size size ) 
        {
            form.Controls.Add(SpellPicture);

            SpellPicture.Image = image;
            SpellPicture.BackColor = Color.Transparent;
            SpellPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            SpellPicture.Size = size;
            SpellPicture.Tag = "Spell";
            SpellPicture.Left = SpellLeft;
            SpellPicture.Top = SpellTop;
            SpellPicture.BringToFront();   

            SpellTimer.Interval = speed;
            SpellTimer.Tick += new EventHandler(SpellTimerEvent);
            SpellTimer.Start();
        }
        //to destroy the spell 
        public void DestroySpell()
        {
            if (offScreen) return;
            offScreen = true;

            SpellTimer.Stop();
            SpellTimer.Tick -= SpellTimerEvent;
            SpellTimer.Dispose();

            SpellPicture.Dispose();
        }
    }
    //Enemy inherits picturebox
    class Enemy : PictureBox
    {
        
      Timer resetTimer = new();    
        //images for attack frames
         Bitmap origin;                        
         Bitmap attack;                       
         //scale if needed
         Size attackSize;
         Size originSize;

        public List<Spell> Spells = new();          
        public int EnemyHealth;
        public int MaxHealth;

         Form hostForm;
         string shotType;
         int SpellSpeed = 10;
         int maxShots;
        private bool EnemyCanFire => Spells.Count < maxShots;

        public Enemy(Point spawnLocation,Bitmap origin,int maxHp,Form form,Bitmap attack,Size attackSize,Size originSize, string shotType,int maxShots)
        {
            this.origin = origin;
            this.attack = attack;
            this.attackSize = attackSize;
            this.originSize = originSize;
            this.shotType = shotType;
            this.maxShots = maxShots;
            hostForm = form;

            Size = originSize;
            Image = origin;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
            Tag = "enemy";
            Location = spawnLocation;

            MaxHealth = maxHp;
            EnemyHealth = maxHp;
            //set frame reset to 3/4s
            resetTimer.Interval = 750;
            resetTimer.Tick += resetEnemyImage;
        }
        //for enmy attack frames
        private void resetEnemyImage(object? sender, EventArgs e)
        {
            Image = origin;
            Size = originSize;
            resetTimer.Stop();
        }

         //checks if is alive or in a firable state/add to list reset timer
        public void Enemyshoot()
        {
            if (EnemyHealth <= 0 || !EnemyCanFire) return;

            Spells.Add(new Spell(hostForm, shotType, "left", this, SpellSpeed));
            Image = attack;
            Size = attackSize;
            resetTimer.Start();
        }
    }
}



