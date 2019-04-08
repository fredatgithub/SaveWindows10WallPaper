#define DEBUG
using SaveWindows10WallPaper.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SaveWindows10WallPaper
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    public readonly Dictionary<string, string> _languageDicoEn = new Dictionary<string, string>();
    public readonly Dictionary<string, string> _languageDicoFr = new Dictionary<string, string>();
    private string _currentLanguage = "english";
    private ConfigurationOptions _configurationOptions = new ConfigurationOptions();

    private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveWindowValue();
      Application.Exit();
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBoxApplication aboutBoxApplication = new AboutBoxApplication();
      aboutBoxApplication.ShowDialog();
    }

    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      LoadSettingsAtStartup();
    }

    private void LoadSettingsAtStartup()
    {
      DisplayTitle();
      GetWindowValue();
      LoadLanguages();
      SetLanguage(Settings.Default.LastLanguageUsed);
    }

    private void LoadConfigurationOptions()
    {
      _configurationOptions.Option1Name = Settings.Default.Option1Name;
      _configurationOptions.Option2Name = Settings.Default.Option2Name;
    }

    private void SaveConfigurationOptions()
    {
      _configurationOptions.Option1Name = Settings.Default.Option1Name;
      _configurationOptions.Option2Name = Settings.Default.Option2Name;
    }

    private void LoadLanguages()
    {
      if (!File.Exists(Settings.Default.LanguageFileName))
      {
        CreateLanguageFile();
      }

      // read the translation file and feed the language
      XDocument xDoc;
      try
      {
        xDoc = XDocument.Load(Settings.Default.LanguageFileName);
      }
      catch (Exception exception)
      {
        MessageBox.Show(Resources.Error_while_loading_the + Punctuation.OneSpace +
          Settings.Default.LanguageFileName + Punctuation.OneSpace + Resources.XML_file +
          Punctuation.OneSpace + exception.Message);
        CreateLanguageFile();
        return;
      }
      var result = from node in xDoc.Descendants("term")
                   where node.HasElements
                   let xElementName = node.Element("name")
                   where xElementName != null
                   let xElementEnglish = node.Element("englishValue")
                   where xElementEnglish != null
                   let xElementFrench = node.Element("frenchValue")
                   where xElementFrench != null
                   select new
                   {
                     name = xElementName.Value,
                     englishValue = xElementEnglish.Value,
                     frenchValue = xElementFrench.Value
                   };
      foreach (var i in result)
      {
        if (!_languageDicoEn.ContainsKey(i.name))
        {
          _languageDicoEn.Add(i.name, i.englishValue);
        }
#if DEBUG
        else
        {
          MessageBox.Show(Resources.Your_XML_file_has_duplicate_like + Punctuation.Colon +
            Punctuation.OneSpace + i.name);
        }
#endif
        if (!_languageDicoFr.ContainsKey(i.name))
        {
          _languageDicoFr.Add(i.name, i.frenchValue);
        }
#if DEBUG
        else
        {
          MessageBox.Show(Resources.Your_XML_file_has_duplicate_like + Punctuation.Colon +
            Punctuation.OneSpace + i.name);
        }
#endif
      }
    }

    private static void CreateLanguageFile()
    {
      List<string> minimumVersion = new List<string>
      {
        "<?xml version=\"1.0\" encoding=\"utf-8\" ?>",
        "<terms>",
         "<term>",
        "<name>MenuFile</name>",
        "<englishValue>File</englishValue>",
        "<frenchValue>Fichier</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileNew</name>",
        "<englishValue>New</englishValue>",
        "<frenchValue>Nouveau</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileOpen</name>",
        "<englishValue>Open</englishValue>",
        "<frenchValue>Ouvrir</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileSave</name>",
        "<englishValue>Save</englishValue>",
        "<frenchValue>Enregistrer</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileSaveAs</name>",
        "<englishValue>Save as ...</englishValue>",
        "<frenchValue>Enregistrer sous ...</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFilePrint</name>",
        "<englishValue>Print ...</englishValue>",
        "<frenchValue>Imprimer ...</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenufilePageSetup</name>",
          "<englishValue>Page setup</englishValue>",
          "<frenchValue>Aperçu avant impression</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenufileQuit</name>",
          "<englishValue>Quit</englishValue>",
          "<frenchValue>Quitter</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEdit</name>",
          "<englishValue>Edit</englishValue>",
          "<frenchValue>Edition</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditCancel</name>",
          "<englishValue>Cancel</englishValue>",
          "<frenchValue>Annuler</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditRedo</name>",
          "<englishValue>Redo</englishValue>",
          "<frenchValue>Rétablir</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditCut</name>",
          "<englishValue>Cut</englishValue>",
          "<frenchValue>Couper</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditCopy</name>",
          "<englishValue>Copy</englishValue>",
          "<frenchValue>Copier</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditPaste</name>",
          "<englishValue>Paste</englishValue>",
          "<frenchValue>Coller</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditSelectAll</name>",
          "<englishValue>Select All</englishValue>",
          "<frenchValue>Sélectionner tout</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuTools</name>",
          "<englishValue>Tools</englishValue>",
          "<frenchValue>Outils</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuToolsCustomize</name>",
          "<englishValue>Customize ...</englishValue>",
          "<frenchValue>Personaliser ...</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuToolsOptions</name>",
          "<englishValue>Options</englishValue>",
          "<frenchValue>Options</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuLanguage</name>",
          "<englishValue>Language</englishValue>",
          "<frenchValue>Langage</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuLanguageEnglish</name>",
          "<englishValue>English</englishValue>",
          "<frenchValue>Anglais</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuLanguageFrench</name>",
          "<englishValue>French</englishValue>",
          "<frenchValue>Français</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelp</name>",
          "<englishValue>Help</englishValue>",
          "<frenchValue>Aide</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpSummary</name>",
          "<englishValue>Summary</englishValue>",
          "<frenchValue>Sommaire</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpIndex</name>",
          "<englishValue>Index</englishValue>",
          "<frenchValue>Index</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpSearch</name>",
          "<englishValue>Search</englishValue>",
          "<frenchValue>Rechercher</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpAbout</name>",
          "<englishValue>About</englishValue>",
          "<frenchValue>A propos de ...</frenchValue>",
        "</term>",
        "</terms>"
      };
      StreamWriter sw = new StreamWriter(Settings.Default.LanguageFileName);
      foreach (string item in minimumVersion)
      {
        sw.WriteLine(item);
      }

      sw.Close();
    }

    private void GetWindowValue()
    {
      Width = Settings.Default.WindowWidth;
      Height = Settings.Default.WindowHeight;
      Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
      Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
      SetDisplayOption(Settings.Default.DisplayToolStripMenuItem);
      textBoxDestinationPath.Text = Settings.Default.textBoxDestinationPath == "" ? GetPicturePath() : Settings.Default.textBoxDestinationPath;
      LoadConfigurationOptions();
    }

    private string GetPicturePath()
    {
      return "my pictures path";
    }

    private void SaveWindowValue()
    {
      Settings.Default.WindowHeight = Height;
      Settings.Default.WindowWidth = Width;
      Settings.Default.WindowLeft = Left;
      Settings.Default.WindowTop = Top;
      Settings.Default.LastLanguageUsed = frenchToolStripMenuItem.Checked ? "French" : "English";
      Settings.Default.DisplayToolStripMenuItem = GetDisplayOption();
      Settings.Default.textBoxDestinationPath = textBoxDestinationPath.Text;
      SaveConfigurationOptions();
      Settings.Default.Save();
    }

    private string GetDisplayOption()
    {
      if (SmallToolStripMenuItem.Checked)
      {
        return "Small";
      }

      if (MediumToolStripMenuItem.Checked)
      {
        return "Medium";
      }

      return LargeToolStripMenuItem.Checked ? "Large" : string.Empty;
    }

    private void SetDisplayOption(string option)
    {
      UncheckAllOptions();
      switch (option.ToLower())
      {
        case "small":
          SmallToolStripMenuItem.Checked = true;
          break;
        case "medium":
          MediumToolStripMenuItem.Checked = true;
          break;
        case "large":
          LargeToolStripMenuItem.Checked = true;
          break;
        default:
          SmallToolStripMenuItem.Checked = true;
          break;
      }
    }

    private void UncheckAllOptions()
    {
      SmallToolStripMenuItem.Checked = false;
      MediumToolStripMenuItem.Checked = false;
      LargeToolStripMenuItem.Checked = false;
    }

    private void FormMainFormClosing(object sender, FormClosingEventArgs e)
    {
      SaveWindowValue();
    }

    private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _currentLanguage = Language.French.ToString();
      SetLanguage(Language.French.ToString());
      AdjustAllControls();
    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _currentLanguage = Language.English.ToString();
      SetLanguage(Language.English.ToString());
      AdjustAllControls();
    }

    private void SetLanguage(string myLanguage)
    {
      switch (myLanguage)
      {
        case "English":
          frenchToolStripMenuItem.Checked = false;
          englishToolStripMenuItem.Checked = true;
          fileToolStripMenuItem.Text = _languageDicoEn["MenuFile"];
          newToolStripMenuItem.Text = _languageDicoEn["MenuFileNew"];
          openToolStripMenuItem.Text = _languageDicoEn["MenuFileOpen"];
          saveToolStripMenuItem.Text = _languageDicoEn["MenuFileSave"];
          saveasToolStripMenuItem.Text = _languageDicoEn["MenuFileSaveAs"];
          printPreviewToolStripMenuItem.Text = _languageDicoEn["MenuFilePrint"];
          printPreviewToolStripMenuItem.Text = _languageDicoEn["MenufilePageSetup"];
          quitToolStripMenuItem.Text = _languageDicoEn["MenufileQuit"];
          editToolStripMenuItem.Text = _languageDicoEn["MenuEdit"];
          cancelToolStripMenuItem.Text = _languageDicoEn["MenuEditCancel"];
          redoToolStripMenuItem.Text = _languageDicoEn["MenuEditRedo"];
          cutToolStripMenuItem.Text = _languageDicoEn["MenuEditCut"];
          copyToolStripMenuItem.Text = _languageDicoEn["MenuEditCopy"];
          pasteToolStripMenuItem.Text = _languageDicoEn["MenuEditPaste"];
          selectAllToolStripMenuItem.Text = _languageDicoEn["MenuEditSelectAll"];
          toolsToolStripMenuItem.Text = _languageDicoEn["MenuTools"];
          personalizeToolStripMenuItem.Text = _languageDicoEn["MenuToolsCustomize"];
          optionsToolStripMenuItem.Text = _languageDicoEn["MenuToolsOptions"];
          languagetoolStripMenuItem.Text = _languageDicoEn["MenuLanguage"];
          englishToolStripMenuItem.Text = _languageDicoEn["MenuLanguageEnglish"];
          frenchToolStripMenuItem.Text = _languageDicoEn["MenuLanguageFrench"];
          helpToolStripMenuItem.Text = _languageDicoEn["MenuHelp"];
          summaryToolStripMenuItem.Text = _languageDicoEn["MenuHelpSummary"];
          indexToolStripMenuItem.Text = _languageDicoEn["MenuHelpIndex"];
          searchToolStripMenuItem.Text = _languageDicoEn["MenuHelpSearch"];
          aboutToolStripMenuItem.Text = _languageDicoEn["MenuHelpAbout"];
          DisplayToolStripMenuItem.Text = _languageDicoEn["Display"];
          SmallToolStripMenuItem.Text = _languageDicoEn["Small"];
          MediumToolStripMenuItem.Text = _languageDicoEn["Medium"];
          LargeToolStripMenuItem.Text = _languageDicoEn["Large"];


          _currentLanguage = "English";
          break;
        case "French":
          frenchToolStripMenuItem.Checked = true;
          englishToolStripMenuItem.Checked = false;
          fileToolStripMenuItem.Text = _languageDicoFr["MenuFile"];
          newToolStripMenuItem.Text = _languageDicoFr["MenuFileNew"];
          openToolStripMenuItem.Text = _languageDicoFr["MenuFileOpen"];
          saveToolStripMenuItem.Text = _languageDicoFr["MenuFileSave"];
          saveasToolStripMenuItem.Text = _languageDicoFr["MenuFileSaveAs"];
          printPreviewToolStripMenuItem.Text = _languageDicoFr["MenuFilePrint"];
          printPreviewToolStripMenuItem.Text = _languageDicoFr["MenufilePageSetup"];
          quitToolStripMenuItem.Text = _languageDicoFr["MenufileQuit"];
          editToolStripMenuItem.Text = _languageDicoFr["MenuEdit"];
          cancelToolStripMenuItem.Text = _languageDicoFr["MenuEditCancel"];
          redoToolStripMenuItem.Text = _languageDicoFr["MenuEditRedo"];
          cutToolStripMenuItem.Text = _languageDicoFr["MenuEditCut"];
          copyToolStripMenuItem.Text = _languageDicoFr["MenuEditCopy"];
          pasteToolStripMenuItem.Text = _languageDicoFr["MenuEditPaste"];
          selectAllToolStripMenuItem.Text = _languageDicoFr["MenuEditSelectAll"];
          toolsToolStripMenuItem.Text = _languageDicoFr["MenuTools"];
          personalizeToolStripMenuItem.Text = _languageDicoFr["MenuToolsCustomize"];
          optionsToolStripMenuItem.Text = _languageDicoFr["MenuToolsOptions"];
          languagetoolStripMenuItem.Text = _languageDicoFr["MenuLanguage"];
          englishToolStripMenuItem.Text = _languageDicoFr["MenuLanguageEnglish"];
          frenchToolStripMenuItem.Text = _languageDicoFr["MenuLanguageFrench"];
          helpToolStripMenuItem.Text = _languageDicoFr["MenuHelp"];
          summaryToolStripMenuItem.Text = _languageDicoFr["MenuHelpSummary"];
          indexToolStripMenuItem.Text = _languageDicoFr["MenuHelpIndex"];
          searchToolStripMenuItem.Text = _languageDicoFr["MenuHelpSearch"];
          aboutToolStripMenuItem.Text = _languageDicoFr["MenuHelpAbout"];
          DisplayToolStripMenuItem.Text = _languageDicoFr["Display"];
          SmallToolStripMenuItem.Text = _languageDicoFr["Small"];
          MediumToolStripMenuItem.Text = _languageDicoFr["Medium"];
          LargeToolStripMenuItem.Text = _languageDicoFr["Large"];

          _currentLanguage = "French";
          break;
        default:
          SetLanguage("English");
          break;
      }
    }

    private void cutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { }); // add your controls in the List
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        CutToClipboard(tb);
      }
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { }); // add your controls in the List
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        CopyToClipboard(tb);
      }
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { }); // add your controls in the List
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        PasteFromClipboard(tb);
      }
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { }); // add your controls in the List
      TextBox control = focusedControl as TextBox;
      if (control != null) control.SelectAll();
    }

    private void CutToClipboard(TextBoxBase tb, string errorMessage = "nothing")
    {
      if (tb != ActiveControl) return;
      if (tb.Text == string.Empty)
      {
        DisplayMessage(Translate("ThereIs") + Punctuation.OneSpace +
          Translate(errorMessage) + Punctuation.OneSpace +
          Translate("ToCut") + Punctuation.OneSpace, Translate(errorMessage),
          MessageBoxButtons.OK);
        return;
      }

      if (tb.SelectedText == string.Empty)
      {
        DisplayMessage(Translate("NoTextHasBeenSelected"),
          Translate(errorMessage), MessageBoxButtons.OK);
        return;
      }

      Clipboard.SetText(tb.SelectedText);
      tb.SelectedText = string.Empty;
    }

    private void CopyToClipboard(TextBoxBase tb, string message = "nothing")
    {
      if (tb != ActiveControl) return;
      if (tb.Text == string.Empty)
      {
        DisplayMessage(Translate("ThereIsNothingToCopy") + Punctuation.OneSpace,
          Translate(message), MessageBoxButtons.OK);
        return;
      }

      if (tb.SelectedText == string.Empty)
      {
        DisplayMessage(Translate("NoTextHasBeenSelected"),
          Translate(message), MessageBoxButtons.OK);
        return;
      }

      Clipboard.SetText(tb.SelectedText);
    }

    private void PasteFromClipboard(TextBoxBase tb)
    {
      if (tb != ActiveControl) return;
      var selectionIndex = tb.SelectionStart;
      tb.SelectedText = Clipboard.GetText();
      tb.SelectionStart = selectionIndex + Clipboard.GetText().Length;
    }

    private void DisplayMessage(string message, string title, MessageBoxButtons buttons)
    {
      MessageBox.Show(this, message, title, buttons);
    }

    private string Translate(string index)
    {
      string result = string.Empty;
      switch (_currentLanguage.ToLower())
      {
        case "english":
          result = _languageDicoEn.ContainsKey(index) ? _languageDicoEn[index] :
           "the term: \"" + index + "\" has not been translated yet.\nPlease tell the developer to translate this term";
          break;
        case "french":
          result = _languageDicoFr.ContainsKey(index) ? _languageDicoFr[index] :
            "the term: \"" + index + "\" has not been translated yet.\nPlease tell the developer to translate this term";
          break;
      }

      return result;
    }

    private static Control FindFocusedControl(Control container)
    {
      foreach (Control childControl in container.Controls.Cast<Control>().Where(childControl => childControl.Focused))
      {
        return childControl;
      }

      return (from Control childControl in container.Controls
              select FindFocusedControl(childControl)).FirstOrDefault(maybeFocusedControl => maybeFocusedControl != null);
    }

    private static Control FindFocusedControl(List<Control> container)
    {
      return container.FirstOrDefault(control => control.Focused);
    }

    private static Control FindFocusedControl(params Control[] container)
    {
      return container.FirstOrDefault(control => control.Focused);
    }

    private static Control FindFocusedControl(IEnumerable<Control> container)
    {
      return container.FirstOrDefault(control => control.Focused);
    }

    private static string PeekDirectory()
    {
      string result = string.Empty;
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        result = fbd.SelectedPath;
      }

      return result;
    }

    private string PeekFile()
    {
      string result = string.Empty;
      OpenFileDialog fd = new OpenFileDialog();
      if (fd.ShowDialog() == DialogResult.OK)
      {
        result = fd.SafeFileName;
      }

      return result;
    }

    private void SmallToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UncheckAllOptions();
      SmallToolStripMenuItem.Checked = true;
      AdjustAllControls();
    }

    private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UncheckAllOptions();
      MediumToolStripMenuItem.Checked = true;
      AdjustAllControls();
    }

    private void LargeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UncheckAllOptions();
      LargeToolStripMenuItem.Checked = true;
      AdjustAllControls();
    }

    private static void AdjustControls(params Control[] listOfControls)
    {
      if (listOfControls.Length == 0)
      {
        return;
      }

      int position = listOfControls[0].Width + 33; // 33 is the initial padding
      bool isFirstControl = true;
      foreach (Control control in listOfControls)
      {
        if (isFirstControl)
        {
          isFirstControl = false;
        }
        else
        {
          control.Left = position + 10;
          position += control.Width;
        }
      }
    }

    private void AdjustAllControls()
    {
      AdjustControls(); // insert here all labels, textboxes and buttons, one method per line of controls
    }

    private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormOptions frmOptions = new FormOptions(_configurationOptions);

      if (frmOptions.ShowDialog() == DialogResult.OK)
      {
        _configurationOptions = frmOptions.ConfigurationOptions2;
      }
    }

    private static void SetButtonEnabled(Button button, params Control[] controls)
    {
      bool result = true;
      foreach (Control ctrl in controls)
      {
        if (ctrl.GetType() == typeof(TextBox))
        {
          if (((TextBox)ctrl).Text == string.Empty)
          {
            result = false;
            break;
          }
        }

        if (ctrl.GetType() == typeof(ListView))
        {
          if (((ListView)ctrl).Items.Count == 0)
          {
            result = false;
            break;
          }
        }

        if (ctrl.GetType() == typeof(ComboBox))
        {
          if (((ComboBox)ctrl).SelectedIndex == -1)
          {
            result = false;
            break;
          }
        }
      }

      button.Enabled = result;
    }

    private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        // do something
      }
    }

    private void ButtonCopy_Click(object sender, EventArgs e)
    {
      if (listBoxExistingPicture.Items.Count == 0)
      {
        return;
      }

      foreach (var item in listBoxExistingPicture.SelectedItems)
      {
        listBoxToBeCopied.Items.Add(item.ToString());
      }
    }

    private void ButtonCommit_Click(object sender, EventArgs e)
    {
      if (listBoxToBeCopied.Items.Count == 0)
      {
        return;
      }

      int counter = 0;
      try
      {
        bool overwirte = false;
        for (int i = 0; i < listBoxToBeCopied.Items.Count; i++)
        {
          string source = listBoxToBeCopied.Items[i].ToString();
          string destination = Path.Combine(textBoxDestinationPath.Text, source) + ".jpg";
          File.Copy(source, destination, overwirte);
          counter++;
        }
      }
      catch (Exception)
      {
        // do nothing and continue to next file
      }

      MessageBox.Show($"{counter} image{Plural(counter)} {Plural(counter, "have")} been copied to the picture folder.");
    }

    private void ButtonGetDestinationPath_Click(object sender, EventArgs e)
    {
      string path = ChooseDirectory();
      if (path != string.Empty)
      {
        textBoxDestinationPath.Text = path;
      }
    }

    public static string ChooseDirectory()
    {
      string result = string.Empty;
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        result = fbd.SelectedPath;
      }

      return result;
    }

    private void ButtonLoadPictures_Click(object sender, EventArgs e)
    {
      listBoxExistingPicture.Items.Clear();
      string userName = Environment.UserName;
      foreach (string file in GetFilesFileteredBySize(new DirectoryInfo($@"C:\Users\{userName}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets"), 100000))
      {
        listBoxExistingPicture.Items.Add(file);
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

    private void ButtonSelectAll_Click(object sender, EventArgs e)
    {
      if (listBoxExistingPicture.Items.Count == 0)
      {
        return;
      }

      for (int i = 0; i < listBoxExistingPicture.Items.Count; i++)
      {
        listBoxExistingPicture.SelectedIndex = i;
      }
    }

    private void ButtonRenameFileName_Click(object sender, EventArgs e)
    {
      List<string> backupFiles = new List<string>();
      foreach (var item in listBoxToBeCopied.Items)
      {
        backupFiles.Add($"{item}.jpg");
      }

      listBoxToBeCopied.Items.Clear();
      foreach (string file in backupFiles)
      {
        listBoxToBeCopied.Items.Add(file);
      }
    }

    private void ButtonView_Click(object sender, EventArgs e)
    {
      string userName = Environment.UserName;
      string imagePath = $@"C:\Users\{userName}\Pictures";
      if (Directory.Exists($@"C:\Users\{userName}\Pictures\fond_ecran"))
      {
        imagePath = $@"C:\Users\{userName}\Pictures\fond_ecran";
      }

      StartProcess("Explorer.exe", imagePath, true, false);
    }

    public static void StartProcess(string dosScript, string arguments = "", bool useShellExecute = true, bool createNoWindow = false)
    {
      Process task = new Process
      {
        StartInfo =
        {
          UseShellExecute = useShellExecute,
          FileName = dosScript,
          Arguments = arguments,
          CreateNoWindow = createNoWindow
        }
      };

      task.Start();
    }

    public static string Plural(int number, string irregularNoun = "")
    {
      switch (irregularNoun)
      {
        case "":
          return number > 1 ? "s" : string.Empty;
        case "al":
          return number > 1 ? "aux" : "al";
        case "au":
          return number > 1 ? "aux" : "au";
        case "eau":
          return number > 1 ? "eaux" : "eau";
        case "eu":
          return number > 1 ? "eux" : "eu";
        case "landau":
          return number > 1 ? "landaus" : "landau";
        case "sarrau":
          return number > 1 ? "sarraus" : "sarrau";
        case "bleu":
          return number > 1 ? "bleus" : "bleu";
        case "émeu":
          return number > 1 ? "émeus" : "émeu";
        case "lieu":
          return number > 1 ? "lieux" : "lieu";
        case "pneu":
          return number > 1 ? "pneus" : "pneu";
        case "aval":
          return number > 1 ? "avals" : "aval";
        case "bal":
          return number > 1 ? "bals" : "bal";
        case "chacal":
          return number > 1 ? "chacals" : "chacal";
        case "carnaval":
          return number > 1 ? "carnavals" : "carnaval";
        case "festival":
          return number > 1 ? "festivals" : "festival";
        case "récital":
          return number > 1 ? "récitals" : "récital";
        case "régal":
          return number > 1 ? "régals" : "régal";
        case "cal":
          return number > 1 ? "cals" : "cal";
        case "serval":
          return number > 1 ? "servals" : "serval";
        case "choral":
          return number > 1 ? "chorals" : "choral";
        case "narval":
          return number > 1 ? "narvals" : "narval";
        case "bail":
          return number > 1 ? "baux" : "bail";
        case "corail":
          return number > 1 ? "coraux" : "corail";
        case "émail":
          return number > 1 ? "émaux" : "émail";
        case "soupirail":
          return number > 1 ? "soupiraux" : "soupirail";
        case "travail":
          return number > 1 ? "travaux" : "travail";
        case "vantail":
          return number > 1 ? "vantaux" : "vantail";
        case "vitrail":
          return number > 1 ? "vitraux" : "vitrail";
        case "bijou":
          return number > 1 ? "bijoux" : "bijou";
        case "caillou":
          return number > 1 ? "cailloux" : "caillou";
        case "chou":
          return number > 1 ? "choux" : "chou";
        case "genou":
          return number > 1 ? "genoux" : "genou";
        case "hibou":
          return number > 1 ? "hiboux" : "hibou";
        case "joujou":
          return number > 1 ? "joujoux" : "joujou";
        case "pou":
          return number > 1 ? "poux" : "pou";
        case "est":
          return number > 1 ? "sont" : "est";

        // English
        case " is":
          return number > 1 ? "s are" : " is"; // with a space before
        case "is":
          return number > 1 ? "are" : "is"; // without a space before
        case "are":
          return number > 1 ? "are" : "is"; // without a space before
        case "has":
          return number > 1 ? "have" : "has";
        case "have":
          return number > 1 ? "have" : "has";
        case "The":
          return "The"; // CAPITAL, useful because of French plural
        case "the":
          return "the"; // lower case, useful because of French plural
        default:
          return number > 1 ? "s" : string.Empty;
      }
    }

    private void ButtonViewSource_Click(object sender, EventArgs e)
    {
      string userName = Environment.UserName;
      string imagePath = $@"C:\Users\{userName}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
      if (!Directory.Exists(imagePath))
      {
        MessageBox.Show($@"The directory C:\Users\{userName}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets does not appear to exit, are you on a Windows 10 PC ?");
        return;
      }

      StartProcess("Explorer.exe", imagePath, true, false);
    }
  }
}
