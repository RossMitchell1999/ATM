using System;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
/// <summary>
/// Uses threads to run an animation independently of controls
/// </summary>
public class Program : Form
{
    private Panel controlPanel, screen;
    Button[,] btn = new Button[3,4];
    Button[,] opbtn = new Button[2,4];
    private Button enterButton, clearButton, cancelButton, blankoneButton;
    private Thread ATM_1_t, ATM_2_t;
    private Color backColor = Color.White;

    public Program()
    {
        Form secondForm = new Form();
        //secondForm.SetScreen();
        //secondForm.SetupKeypad();
        ClientSize = new Size(600, 600);
        setScreen();
        SetupKeyPad();
    }

    private void SetupKeyPad()
    {
        controlPanel = new Panel();
        controlPanel.Bounds = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
        controlPanel.BackColor = Color.White;
        this.Controls.Add(controlPanel);
        // Buttons
        enterButton = new Button();
        enterButton.Text = "Enter";
        enterButton.BackColor = Color.Green;
        enterButton.Bounds = new Rectangle(415, 450, 85, 50);
        enterButton.Click += new EventHandler(enterButton_Click);
        controlPanel.Controls.Add(enterButton);
        clearButton = new Button();
        clearButton.Text = "Clear";
        clearButton.BackColor = Color.Yellow;
        clearButton.Bounds = new Rectangle(415, enterButton.Bounds.Y - enterButton.Height - 25, 85, 50);
        clearButton.Click += new EventHandler(clearButton_Click);
        controlPanel.Controls.Add(clearButton);
        cancelButton = new Button();
        cancelButton.Text = "Quit";
        cancelButton.BackColor = Color.Red;
        cancelButton.Bounds = new Rectangle(415, clearButton.Bounds.Y - clearButton.Height - 25, 85, 50);
        cancelButton.Click += new EventHandler(cancelButton_Click);
        controlPanel.Controls.Add(cancelButton);
        blankoneButton = new Button();
        blankoneButton.Bounds = new Rectangle(415, enterButton.Bounds.Y + enterButton.Height + 25, 85, 50);
        blankoneButton.BackColor = Color.Gray;
        controlPanel.Controls.Add(blankoneButton);

        int count = 1;
        for (int x = 0; x < btn.GetLength(0); x++)         // Loop for x
        {
            for (int y = 0; y < btn.GetLength(1); y++)     // Loop for y
            {
                btn[x, y] = new Button();
                btn[x, y].SetBounds(100 + (100 * x), 300 + (75 * y), 85, 50);
                btn[x, y].BackColor = Color.Gray;
                if (y != 3)
                {
                    btn[x, y].Text = Convert.ToString(count);
                }
                else if (x == 1)
                {
                    btn[x, y].Text = Convert.ToString(0);
                }
                btn[x, y].Click += new EventHandler(this.btnEvent_Click);
                controlPanel.Controls.Add(btn[x, y]);
                count = count + 3;
            }
            count = count - 11;
        }
        int side = 5;
        for (int x = 0; x < opbtn.GetLength(0); x++)         // Loop for x
        {
            for (int y = 0; y < opbtn.GetLength(1); y++)     // Loop for y
            {
                opbtn[x, y] = new Button();
                opbtn[x, y].SetBounds(side+(100 * x), (75 * y), 85, 50);
                opbtn[x, y].BackColor = Color.Gray;
                opbtn[x, y].Click += new EventHandler(this.opbtnEvent_Click);
                controlPanel.Controls.Add(opbtn[x, y]);
            }
            side = side + 405;
        }
    }

    void setScreen()
    {
        screen = new Panel();
        screen.Bounds = new Rectangle(100, 0, 400, 275);
        screen.BackColor = Color.Black;
        this.Controls.Add(screen);
    }
    private void clearButton_Click(object sender, EventArgs args)
    {
        
    }
    private void enterButton_Click(object sender, EventArgs args)
    {
        
    }
    private void cancelButton_Click(object sender, EventArgs args)
    {
        
    }
    void btnEvent_Click(object sender, EventArgs e)
    {
        Console.WriteLine(((Button)sender).Text);    // SAME handler as before
    }
    void opbtnEvent_Click(object sender, EventArgs e)
    {
        Console.WriteLine(((Button)sender).Text);    // SAME handler as before
    }

    // Main - this code always at the end
    public static void Main()
    {
        Application.Run(new Program());

    }
}
