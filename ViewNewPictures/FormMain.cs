using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ViewNewPictures
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void ButtonGetPictures_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(textBoxPath.Text))
      {
        return;
      }

      // get all pictures above 1 MO
      List<string> files = new List<string>();
      foreach (string file in GetFilesFileteredBySize(new DirectoryInfo($@"{textBoxPath.Text}"), 100000))
      {
        files.Add(file);
      }

      if (files.Count > 0)
      {
        DisplayPictures(files.Count, files);
      }
    }

    private void DisplayPictures(int numberOfPictures, List<string> files)
    {
      switch (numberOfPictures)
      {
        case 1:
          pictureBox1.ImageLocation = files[0];
          break;
        case 2:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          break;
        case 3:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          break;
        case 4:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          break;
        case 5:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          break;
        case 6:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          break;
        case 7:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          pictureBox7.ImageLocation = files[6];
          break;
        case 8:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          pictureBox7.ImageLocation = files[6];
          pictureBox8.ImageLocation = files[7];
          break;
        case 9:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          pictureBox7.ImageLocation = files[6];
          pictureBox8.ImageLocation = files[7];
          pictureBox9.ImageLocation = files[8];
          break;
        case 10:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          pictureBox7.ImageLocation = files[6];
          pictureBox8.ImageLocation = files[7];
          pictureBox9.ImageLocation = files[8];
          pictureBox10.ImageLocation = files[9];
          break;
        case 11:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          pictureBox7.ImageLocation = files[6];
          pictureBox8.ImageLocation = files[7];
          pictureBox9.ImageLocation = files[8];
          pictureBox10.ImageLocation = files[9];
          pictureBox11.ImageLocation = files[10];
          break;
        case 12:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          pictureBox7.ImageLocation = files[6];
          pictureBox8.ImageLocation = files[7];
          pictureBox9.ImageLocation = files[8];
          pictureBox10.ImageLocation = files[9];
          pictureBox11.ImageLocation = files[10];
          pictureBox12.ImageLocation = files[11];
          break;

        default:
          break;
      }
    }

    public static List<string> GetFilesFileteredBySize(DirectoryInfo directoryInfo, long sizeGreaterOrEqualTo)
    {
      List<string> result = new List<string>();
      foreach (FileInfo fileInfo in directoryInfo.GetFiles())
      {
        if (fileInfo.Length >= sizeGreaterOrEqualTo)
        {
          result.Add(fileInfo.FullName);
        }
      }

      return result;
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      LoadSettings();
    }

    private void LoadSettings()
    {
      textBoxPath.Text = Properties.Settings.Default.textBoxPath;

    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveSettings();
    }

    private void SaveSettings()
    {
      Properties.Settings.Default.textBoxPath = textBoxPath.Text;
    }

    private void ButtonGetPicturePath_Click(object sender, EventArgs e)
    {
      openFileDialog1.Filter = "All files|*.*";
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        textBoxPath.Text = openFileDialog1.FileName;
      }
    }
  }
}
