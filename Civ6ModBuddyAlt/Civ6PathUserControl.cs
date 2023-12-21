using System;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt;

public partial class Civ6PathUserControl : UserControl {
    internal Civ6PathOptionPage optionsPage;

    public Civ6PathUserControl(Civ6PathOptionPage optionPage) {
        InitializeComponent();
        optionsPage = optionPage;
    }

    public void Initialize() {
        textBox1.Text = optionsPage.UserPath;
        textBox2.Text = optionsPage.GamePath;
        textBox3.Text = optionsPage.ToolsPath;
        textBox4.Text = optionsPage.AssetsPath;
    }

    private void textBox1_TextChanged(object sender, EventArgs e) {
        optionsPage.UserPath = textBox1.Text;
    }

    private void button1_Click(object sender, EventArgs e) {
        folderBrowserDialog1.SelectedPath = textBox1.Text;

        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) textBox1.Text = folderBrowserDialog1.SelectedPath;
    }

    private void textBox2_TextChanged(object sender, EventArgs e) {
        optionsPage.GamePath = textBox2.Text;
    }

    private void button2_Click(object sender, EventArgs e) {
        folderBrowserDialog1.SelectedPath = textBox2.Text;

        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) textBox2.Text = folderBrowserDialog1.SelectedPath;
    }

    private void textBox3_TextChanged(object sender, EventArgs e) {
        optionsPage.ToolsPath = textBox3.Text;
    }

    private void button3_Click(object sender, EventArgs e) {
        folderBrowserDialog1.SelectedPath = textBox3.Text;

        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) textBox3.Text = folderBrowserDialog1.SelectedPath;
    }

    private void textBox4_TextChanged(object sender, EventArgs e) {
        optionsPage.AssetsPath = textBox4.Text;
    }

    private void button4_Click(object sender, EventArgs e) {
        folderBrowserDialog1.SelectedPath = textBox4.Text;

        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) textBox4.Text = folderBrowserDialog1.SelectedPath;
    }
}
