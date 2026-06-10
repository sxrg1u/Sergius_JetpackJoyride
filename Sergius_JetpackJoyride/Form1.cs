using Timer = System.Windows.Forms.Timer;

namespace Sergius_JetpackJoyride;

public partial class Form1 : Form
{
    // --- GRÖSSE ---
    const int FormWidth = 800;
    const int FormHeight = 400;

    // --- CHARAKTER ---
    const int CharX = 100;
    const int CharWidth = 30;
    const int CharHeight = 40;
    Panel character = new Panel() { BackColor = Color.LimeGreen, Size = new Size(CharWidth, CharHeight) };

    // --- PHYSIK ---
    double charY;
    double velocityY = 0;
    const double Gravity = 0.5;
    const double JetpackForce = -0.8;
    const double MaxFallSpeed = 8;
    const double MaxRiseSpeed = -8;
    bool spaceHeld = false;

    // --- MUNITION ---
    const int BulletWidth = 6;
    const int BulletHeight = 14;
    const int BulletSpeed = 8;
    const int BulletSpawnInterval = 6;      // jeden 6. Tick eine neue Kugel
    int bulletTick = 0;
    List<Panel> bullets = new List<Panel>();

    // --- TIMER ---
    Timer tmrGame = new Timer() { Interval = 16, Enabled = true };

    public Form1()
    {
        Text = "Jetpack Joyride";
        BackColor = Color.DarkSlateBlue;
        ClientSize = new Size(FormWidth, FormHeight);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        charY = FormHeight / 2.0;
        character.Location = new Point(CharX, (int)charY);

        Controls.Add(character);

        KeyDown += Form1_KeyDown;
        KeyUp += Form1_KeyUp;

        tmrGame.Tick += TmrGame_Tick; ;
    }

    private void TmrGame_Tick(object? sender, EventArgs e)
    {
        if (spaceHeld)
            velocityY += JetpackForce;
        else
            velocityY += Gravity;

        velocityY = Math.Clamp(velocityY, MaxRiseSpeed, MaxFallSpeed);
        charY += velocityY;

        if (charY + CharHeight >= FormHeight)
        {
            charY = FormHeight - CharHeight;
            velocityY = 0;
        }

        if (charY <= 0)
        {
            charY = 0;
            velocityY = 0;
        }

        character.Location = new Point(CharX, (int)charY);

        // --- MUNITION SCHIESSEN ---
        if (spaceHeld)
        {
            bulletTick++;
            if (bulletTick >= BulletSpawnInterval)
            {
                bulletTick = 0;
                Panel bullet = new Panel()
                {
                    BackColor = Color.Yellow,
                    Size = new Size(BulletWidth, BulletHeight),
                    // Kugeln spawnen unten in der Mitte vom Charakter
                    Location = new Point(CharX + CharWidth / 2 - BulletWidth / 2,
                                         (int)charY + CharHeight)
                };
                bullets.Add(bullet);
                Controls.Add(bullet);
            }
        }
        else
        {
            bulletTick = BulletSpawnInterval; // sofort schiessen wenn Leertaste wieder gedrückt
        }

        // --- KUGELN BEWEGEN ---
        List<Panel> toRemove = new List<Panel>();
        foreach (Panel bullet in bullets)
        {
            bullet.Top += BulletSpeed;
            if (bullet.Top > FormHeight)
                toRemove.Add(bullet);
        }

        // --- KUGELN AUSSERHALB ENTFERNEN ---
        foreach (Panel bullet in toRemove)
        {
            Controls.Remove(bullet);
            bullets.Remove(bullet);
        }
    }

    private void Form1_KeyDown(object s, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
            spaceHeld = true;
    }

    private void Form1_KeyUp(object s, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
            spaceHeld = false;
    }
}
