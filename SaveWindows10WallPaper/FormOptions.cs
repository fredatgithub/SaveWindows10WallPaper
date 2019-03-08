/*
The MIT License(MIT)
Copyright(c) 2015 Freddy Juhel
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Windows.Forms;

namespace SaveWindows10WallPaper
{
  internal partial class FormOptions : Form
  {
    private readonly ConfigurationOptions _configurationOptions2;

    internal FormOptions(ConfigurationOptions configurationOptions)
    {
      if (configurationOptions == null)
      {
        //throw new ArgumentNullException(nameof(configurationOptions));
        _configurationOptions2 = new ConfigurationOptions();
      }
      else
      {
        _configurationOptions2 = configurationOptions;
      }

      InitializeComponent();
      checkBoxOption1.Checked = ConfigurationOptions2.Option1Name;
      checkBoxOption2.Checked = ConfigurationOptions2.Option2Name;
    }

    internal ConfigurationOptions ConfigurationOptions2
    {
      get { return _configurationOptions2; }
    }

    private void buttonOptionsOK_Click(object sender, EventArgs e)
    {
      ConfigurationOptions2.Option1Name = checkBoxOption1.Checked;
      ConfigurationOptions2.Option2Name = checkBoxOption2.Checked;
      Close();
    }

    private void buttonOptionsCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void FormOptions_Load(object sender, EventArgs e)
    {
      // take care of language
      //buttonOptionsCancel.Text = _languageDicoEn["Cancel"];
    }
  }
}