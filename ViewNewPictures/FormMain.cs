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
        tabControlMain.SelectedIndex = 1;
      }
      else
      {
        MessageBox.Show($"No picture were found.");
      }
    }

    private void DisplayPictures(int numberOfPictures, List<string> files)
    {
      switch (numberOfPictures)
      {
        case 1:
          pictureBox1.ImageLocation = files[0];
          HideOtherTabs(1);
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
        case 13:
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
          pictureBox13.ImageLocation = files[12];
          break;
        case 14:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          break;
        case 15:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          pictureBox15.ImageLocation = files[14];
          break;
        case 16:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          pictureBox15.ImageLocation = files[14];
          pictureBox16.ImageLocation = files[15];
          break;
        case 17:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          pictureBox15.ImageLocation = files[14];
          pictureBox16.ImageLocation = files[15];
          pictureBox17.ImageLocation = files[16];
          break;
        case 18:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          pictureBox15.ImageLocation = files[14];
          pictureBox16.ImageLocation = files[15];
          pictureBox17.ImageLocation = files[16];
          pictureBox18.ImageLocation = files[17];
          break;
        case 19:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          pictureBox15.ImageLocation = files[14];
          pictureBox16.ImageLocation = files[15];
          pictureBox17.ImageLocation = files[16];
          pictureBox18.ImageLocation = files[17];
          pictureBox19.ImageLocation = files[18];
          break;
        case 20:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          pictureBox15.ImageLocation = files[14];
          pictureBox16.ImageLocation = files[15];
          pictureBox17.ImageLocation = files[16];
          pictureBox18.ImageLocation = files[17];
          pictureBox19.ImageLocation = files[18];
          pictureBox20.ImageLocation = files[19];
          break;
        case 21:
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
          pictureBox13.ImageLocation = files[12];
          pictureBox14.ImageLocation = files[13];
          pictureBox15.ImageLocation = files[14];
          pictureBox16.ImageLocation = files[15];
          pictureBox17.ImageLocation = files[16];
          pictureBox18.ImageLocation = files[17];
          pictureBox19.ImageLocation = files[18];
          pictureBox20.ImageLocation = files[19];
          pictureBox21.ImageLocation = files[20];
          break;

        default:
          MessageBox.Show($"There are {files.Count} pictures found.");
          break;
      }
    }

    private void HideOtherTabs(int tabNumber)
    {
      switch (tabNumber)
      {
        case 1:

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
