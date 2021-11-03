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
      foreach (string file in GetFilesFileteredBySize(new DirectoryInfo($@"{textBoxPath.Text}"), 100_000))
      {
        files.Add(file);
      }

      if (files.Count > 0)
      {
        DisplayPictures(files.Count, files);
        tabControlMain.SelectedIndex = 1;
        previousToolStripMenuItem.Enabled = false;
        suivantToolStripMenuItem.Enabled = true;
        ActiveForm.WindowState = FormWindowState.Maximized;
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
          HideOtherTabs(2);
          break;
        case 3:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          HideOtherTabs(3);
          break;
        case 4:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          HideOtherTabs(4);
          break;
        case 5:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          HideOtherTabs(5);
          break;
        case 6:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          HideOtherTabs(6);
          break;
        case 7:
          pictureBox1.ImageLocation = files[0];
          pictureBox2.ImageLocation = files[1];
          pictureBox3.ImageLocation = files[2];
          pictureBox4.ImageLocation = files[3];
          pictureBox5.ImageLocation = files[4];
          pictureBox6.ImageLocation = files[5];
          pictureBox7.ImageLocation = files[6];
          HideOtherTabs(7);
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
          HideOtherTabs(8);
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
          HideOtherTabs(9);
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
          HideOtherTabs(10);
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
          HideOtherTabs(11);
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
          HideOtherTabs(12);
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
          HideOtherTabs(13);
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
          HideOtherTabs(14);
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
          HideOtherTabs(15);
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
          HideOtherTabs(16);
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
          HideOtherTabs(17);
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
          HideOtherTabs(18);
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
          HideOtherTabs(19);
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
          HideOtherTabs(20);
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
          HideOtherTabs(21);
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
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = false;
          tabPagePic3.Visible = false;
          tabPagePic4.Visible = false;
          tabPagePic5.Visible = false;
          tabPagePic6.Visible = false;
          tabPagePic7.Visible = false;
          tabPagePic8.Visible = false;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 2:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = false;
          tabPagePic4.Visible = false;
          tabPagePic5.Visible = false;
          tabPagePic6.Visible = false;
          tabPagePic7.Visible = false;
          tabPagePic8.Visible = false;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 3:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = false;
          tabPagePic5.Visible = false;
          tabPagePic6.Visible = false;
          tabPagePic7.Visible = false;
          tabPagePic8.Visible = false;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 4:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = false;
          tabPagePic6.Visible = false;
          tabPagePic7.Visible = false;
          tabPagePic8.Visible = false;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 5:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = false;
          tabPagePic7.Visible = false;
          tabPagePic8.Visible = false;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 6:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = false;
          tabPagePic8.Visible = false;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 7:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = false;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 8:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = false;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 9:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = false;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 10:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = false;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 11:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = false;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 12:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = false;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 13:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = false;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 14:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = false;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 15:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = true;
          tabPagePic16.Visible = false;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 16:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = true;
          tabPagePic16.Visible = true;
          tabPagePic17.Visible = false;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 17:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = true;
          tabPagePic16.Visible = true;
          tabPagePic17.Visible = true;
          tabPagePic18.Visible = false;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 18:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = true;
          tabPagePic16.Visible = true;
          tabPagePic17.Visible = true;
          tabPagePic18.Visible = true;
          tabPagePic19.Visible = false;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 19:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = true;
          tabPagePic16.Visible = true;
          tabPagePic17.Visible = true;
          tabPagePic18.Visible = true;
          tabPagePic19.Visible = true;
          tabPagePic20.Visible = false;
          tabPagePic21.Visible = false;
          break;

        case 20:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = true;
          tabPagePic16.Visible = true;
          tabPagePic17.Visible = true;
          tabPagePic18.Visible = true;
          tabPagePic19.Visible = true;
          tabPagePic20.Visible = true;
          tabPagePic21.Visible = false;
          break;

        default:
          tabPagePic1.Visible = true;
          tabPagePic2.Visible = true;
          tabPagePic3.Visible = true;
          tabPagePic4.Visible = true;
          tabPagePic5.Visible = true;
          tabPagePic6.Visible = true;
          tabPagePic7.Visible = true;
          tabPagePic8.Visible = true;
          tabPagePic9.Visible = true;
          tabPagePic10.Visible = true;
          tabPagePic11.Visible = true;
          tabPagePic12.Visible = true;
          tabPagePic13.Visible = true;
          tabPagePic14.Visible = true;
          tabPagePic15.Visible = true;
          tabPagePic16.Visible = true;
          tabPagePic17.Visible = true;
          tabPagePic18.Visible = true;
          tabPagePic19.Visible = true;
          tabPagePic20.Visible = true;
          tabPagePic21.Visible = true;
          break;
      }
    }

    public static List<string> GetFilesFileteredBySize(DirectoryInfo directoryInfo, long sizeGreaterOrEqualTo)
    {
      List<string> result = new List<string>();
      try
      {
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
          if (fileInfo.Length >= sizeGreaterOrEqualTo)
          {
            result.Add(fileInfo.FullName);
          }
        }
      }
      catch (Exception)
      {
        result = new List<string>();
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
      previousToolStripMenuItem.Enabled = false;
      suivantToolStripMenuItem.Enabled = false;
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveSettings();
    }

    private void SaveSettings()
    {
      Properties.Settings.Default.textBoxPath = textBoxPath.Text;
      Properties.Settings.Default.Save();
    }

    private void ButtonGetPicturePath_Click(object sender, EventArgs e)
    {
      openFileDialog1.Filter = "All files|*.*";
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        textBoxPath.Text = openFileDialog1.FileName;
      }
    }

    private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveSettings();
      Application.Exit();
    }

    private void SuivantToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (tabControlMain.SelectedIndex <= 21)
      {
        tabControlMain.SelectedIndex++;
      }

      EnableDisableMenu();
    }

    private void PrécédentToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (tabControlMain.SelectedIndex > 1)
      {
        tabControlMain.SelectedIndex--;
      }

      EnableDisableMenu();
    }

    private void EnableDisableMenu()
    {
      suivantToolStripMenuItem.Enabled = tabControlMain.SelectedIndex != 21;
      previousToolStripMenuItem.Enabled = tabControlMain.SelectedIndex != 1;
    }
  }
}
