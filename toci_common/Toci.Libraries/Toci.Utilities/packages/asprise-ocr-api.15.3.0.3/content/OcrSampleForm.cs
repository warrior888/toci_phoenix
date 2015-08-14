using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using System.Reflection;

using asprise_ocr_api;

// Sample application of Asprise OCR C#/VB.NET SDK. Visit http://asprise.com/product/ocr for more details.
namespace asprise_ocr_api
{
    /// <summary>
    /// In your Program.cs Main: Application.Run(new asprise_ocr_api.OcrSampleForm());
    /// </summary>
    public partial class OcrSampleForm : Form
    {
        /** Constructor */
        public OcrSampleForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            asprise_init();
        }

        private AspriseOCR ocr;
        private String currentLang = "eng";

        private Dictionary<string, string> formSettings;
        private string formSettingFileName = "ocr-form.properties";
        static string PROP_NAME_LANG = "lang";
        static string PROP_NAME_LAST_IMG = "last_img";
        static string PROP_NAME_TEXT_LAYOUT = "text_layout";
        static string PROP_NAME_DATA_CAPTURE = "data_capture";
        static string PROP_NAME_AUTO_ROTATE = "auto_rotate";
        static string PROP_NAME_WORD_LEVEL = "word_level";
        static string PROP_NAME_OUTPUT_FORMAT = "output_format";
        static string PROP_NAME_HIGHLIGHT_PDF = "highlight_pdf";
        static string PROP_NAME_RECOGNIZE_TEXT = "recognize_text";
        static string PROP_NAME_RECOGNIZE_BARCODE = "recognize_barcode";

        private void asprise_init()
        {
            formSettings = readDynamicSettings(formSettingFileName);

            bool browsed = false;
            int count = 0;

            // Let user browse the ocr dll if it is not found in PATH.
            while (true)
            {
                string dllFilePath = AspriseOCR.loadDll();
                if (dllFilePath == null)
                {
                    log("OCR dll (" + AspriseOCR.getOcrDllName() + ") is not found in PATH.");
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.RestoreDirectory = true;
                    fileDialog.Title = "Please select " + AspriseOCR.getOcrDllName();
                    fileDialog.FileName = AspriseOCR.getOcrDllName();
                    if (fileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        log("User browsed dll: " + fileDialog.FileName);
                        AspriseOCR.addToSystemPath(Path.GetDirectoryName(fileDialog.FileName));
                        browsed = true;
                    }
                    count ++;
                    if (count == 2)
                    {
                        showMessageBox("OCR DLL not found. ", "Error");
                        break;
                    }
                }
                else
                {
                    log("OCR dll found: " + dllFilePath);
                    if (browsed)
                    {
                        log("Please consider copy " + AspriseOCR.getOcrDllName() + " to directory: " +
                            Directory.GetCurrentDirectory());
                    }

                    log(AspriseOCR.GetLibraryVersion());

                    try
                    {
                        log("Starting OCR engine ...");
                        AspriseOCR.SetUp();
                        setupLangDropdown();
                        ocr = new AspriseOCR();
                        ocr.StartEngine(currentLang, AspriseOCR.SPEED_FASTEST);
                        log("OCR engine started successfully.");
                   }
                    catch (Exception e)
                    {
                        log("ERROR: Failed to start OCR engine: " + e);
                        log(e.StackTrace);
                    }
                    break;
                }
            }

            // user preference
            textImage.Text = formSettings.Keys.Contains(PROP_NAME_LAST_IMG) ? formSettings[PROP_NAME_LAST_IMG] : "";
            selectComboValue(comboTextLayout, formSettings.ContainsKey(PROP_NAME_TEXT_LAYOUT) ? formSettings[PROP_NAME_TEXT_LAYOUT] : "auto");
            if (formSettings.ContainsKey(PROP_NAME_DATA_CAPTURE))
            {
                checkDetectTables.Checked = "true".Equals(formSettings[PROP_NAME_DATA_CAPTURE].ToLower());
            }
            if (formSettings.ContainsKey(PROP_NAME_AUTO_ROTATE))
            {
                checkAutoRotatePages.Checked = "true".Equals(formSettings[PROP_NAME_AUTO_ROTATE].ToLower());
            }
            if (formSettings.ContainsKey(PROP_NAME_WORD_LEVEL))
            {
                checkWordLevel.Checked = "true".Equals(formSettings[PROP_NAME_WORD_LEVEL].ToLower());
            }
            if (formSettings.ContainsKey(PROP_NAME_RECOGNIZE_TEXT))
            {
                checkRecognizeText.Checked = "true".Equals(formSettings[PROP_NAME_RECOGNIZE_TEXT].ToLower());
            }
            if (formSettings.ContainsKey(PROP_NAME_RECOGNIZE_BARCODE))
            {
                checkRecognizeBarcodes.Checked = "true".Equals(formSettings[PROP_NAME_RECOGNIZE_BARCODE].ToLower());
            }
            if (formSettings.ContainsKey(PROP_NAME_HIGHLIGHT_PDF))
            {
                checkPdfHighlightText.Checked = "true".Equals(formSettings[PROP_NAME_HIGHLIGHT_PDF].ToLower());
            }
            string outputFormat = formSettings.ContainsKey(PROP_NAME_OUTPUT_FORMAT) ? formSettings[PROP_NAME_OUTPUT_FORMAT] : "xml";
            radioOutputPdf.Checked = "pdf".Equals(outputFormat);
            radioOutputText.Checked = "text".Equals(outputFormat);
            radioOutputXml.Checked = "xml".Equals(outputFormat);
        }

        void setupLangDropdown()
        {
            string langsStr = AspriseOCR.ListSupportedLangs();
            string[] langs = langsStr.Split(new char[] {',', ';'});
            comboLang.Items.Clear();
            foreach(string lang in langs)
            {
                comboLang.Items.Add(lang);
            }

            String lastLang = formSettings.ContainsKey(PROP_NAME_LANG) ? formSettings[PROP_NAME_LANG] : "eng";
            if (lastLang == null || lastLang.Length == 0)
            {
                lastLang = "eng"; // default
            }
            selectComboValue(comboLang, lastLang);
        }

        static bool selectComboValue(ComboBox combo, string value)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i].ToString().Equals(value))
                {
                    combo.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void showMessageBox(string message, string title)
        {
            if (this.InvokeRequired)
            {
                delegate_showMessageBox delegatedMethod = showMessageBox;
                Invoke(delegatedMethod, message, title);
                return;
            }

            MessageBox.Show(this, message, title, MessageBoxButtons.OK);
        }
        delegate void delegate_showMessageBox(string message, string title);

        private void saveSettings()
        {
            if (this.InvokeRequired)
            {
                delegate_saveSettings delegatedMethod = saveSettings;
                Invoke(delegatedMethod);
                return;
            }

            formSettings[PROP_NAME_LANG] = currentLang;
            formSettings[PROP_NAME_LAST_IMG] = textImage.Text;
            formSettings[PROP_NAME_TEXT_LAYOUT] = comboTextLayout.Text;
            formSettings[PROP_NAME_DATA_CAPTURE] = checkDetectTables.Checked ? "true" : "false";
            formSettings[PROP_NAME_AUTO_ROTATE] = checkAutoRotatePages.Checked ? "true" : "false";
            formSettings[PROP_NAME_WORD_LEVEL] = checkWordLevel.Checked ? "true" : "false";
            formSettings[PROP_NAME_RECOGNIZE_TEXT] = checkRecognizeText.Checked ? "true" : "false";
            formSettings[PROP_NAME_RECOGNIZE_BARCODE] = checkRecognizeBarcodes.Checked ? "true" : "false";
            formSettings[PROP_NAME_HIGHLIGHT_PDF] = checkPdfHighlightText.Checked ? "true" : "false";
            formSettings[PROP_NAME_OUTPUT_FORMAT] = radioOutputPdf.Checked ? "pdf" : (radioOutputText.Checked ? "text" : "xml");
            saveDynamicSettings(formSettings, formSettingFileName);
        }

        delegate void delegate_saveSettings();

        private void log(string s, bool clear = false)
        {
            if (textbox.InvokeRequired)
            {
                delegate_log delegatedMethod = log;
                Invoke(delegatedMethod, s, clear);
                return;
            }

            if (clear)
            {
                textbox.Text = "";
            }

            if (textbox.Text.Length > 1)
            {
                textbox.Text += "\r\n";
            }
            textbox.Text += s.Replace("\n", "\r\n"); // to properly display in textbox
        }
        delegate void delegate_log(string s, bool clear = false);

/**        private Color _Color1 = Color.White;
        private Color _Color2 = Color.LightBlue;
        private float _ColorAngle = 60f;

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Getting the graphics object
            Graphics g = pevent.Graphics;

            // Creating the rectangle for the gradient
            Rectangle rBackground = new Rectangle(0, 0,
                                      this.Width, this.Height);

            // Creating the lineargradient
            System.Drawing.Drawing2D.LinearGradientBrush bBackground
                = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground,
                                                  _Color1, _Color2, _ColorAngle);

            // Draw the gradient onto the form
            g.FillRectangle(bBackground, rBackground);

            // Disposing of the resources held by the brush
            bBackground.Dispose();
        }
 */

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // settings
            if (!AspriseOCR.isEmpty(textImage.Text))
            {
                try
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(textImage.Text.Trim());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            dialog.Title = "Please select OCR input image";
            dialog.Filter = "Image Files(*.BMP;*.GIF;*.JPG;*PNG;*TIF;*TIFF;*.PDF)|*.BMP;*.GIF;*.JPG;*PNG;*TIF;*TIFF;*.PDF|All files (*.*)|*.*";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                textImage.Text = dialog.FileName;
            }
        }

        private Thread threadOcr;

        private String langOnUI;
        private void buttonOcr_Click(object sender, EventArgs e)
        {
            if (threadOcr != null && threadOcr.IsAlive)
            {
                showMessageBox("OCR in progress, please wait ...", "Info");
                return;
            }

            langOnUI = comboLang.Text;
            if (langOnUI == null || langOnUI.Trim().Length == 0)
            {
                showMessageBox("Please select language first.", "Error");
                return;
            }
            
            threadOcr = new Thread(this.doOcr);
            threadOcr.Start();
        }

        void updateUI()
        {
            checkPdfHighlightText.Enabled = radioOutputPdf.Checked;
        }

        void doOcr()
        {
            if (textImage.Text.Trim().Length == 0)
            {
                showMessageBox("Please select an input image first.", "Error");
                return;
            }

            if (!File.Exists(textImage.Text.Trim()))
            {
                showMessageBox("Image file does not exist: " + textImage.Text, "Error");
                return;
            }

            if (! langOnUI.Equals(currentLang))
            {
                ocr.StopEngine();
                currentLang = null;

                ocr = new AspriseOCR();
                ocr.StartEngine(langOnUI, AspriseOCR.SPEED_FASTEST);
                currentLang = langOnUI;
            }

            if (ocr == null || !ocr.IsEngineRunning)
            {
                showMessageBox("OCR engine is not running", "Error");
                return;
            }

            if (!checkRecognizeText.Checked && !checkRecognizeBarcodes.Checked)
            {
                showMessageBox("Please check at least one of 'Text', 'Barcodes'", "Warn");
                return;
            }

            string recognizeType = AspriseOCR.RECOGNIZE_TYPE_ALL;
            if (!checkRecognizeText.Checked)
            {
                recognizeType = AspriseOCR.RECOGNIZE_TYPE_BARCODE;
            }
            if (!checkRecognizeBarcodes.Checked)
            {
                recognizeType = AspriseOCR.RECOGNIZE_TYPE_TEXT;
            }

            string outputFormat = AspriseOCR.OUTPUT_FORMAT_PLAINTEXT;
            if (radioOutputXml.Checked)
            {
                outputFormat = AspriseOCR.OUTPUT_FORMAT_XML;
            }
            if (radioOutputPdf.Checked)
            {
                outputFormat = AspriseOCR.OUTPUT_FORMAT_PDF;
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(AspriseOCR.PROP_OUTPUT_SEPARATE_WORDS, checkWordLevel.Checked ? "true" : "false");
            dict.Add(AspriseOCR.PROP_PAGE_TYPE, comboTextLayout.SelectedText);
            dict.Add(AspriseOCR.PROP_TABLE_SKIP_DETECTION, checkDetectTables.Checked ? "false" : "true");
            dict.Add(AspriseOCR.PROP_IMG_PREPROCESS_TYPE, checkAutoRotatePages.Checked ? AspriseOCR.PROP_IMG_PREPROCESS_TYPE_DEFAULT_WITH_ORIENTATION_DETECTION : AspriseOCR.PROP_IMG_PREPROCESS_TYPE_DEFAULT);
            
            string pdfOutputFile = null;
            if (outputFormat.Equals(AspriseOCR.OUTPUT_FORMAT_PDF))
            {
                pdfOutputFile = Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString("O").Replace(':', '-') + ".pdf");
                dict.Add(AspriseOCR.PROP_PDF_OUTPUT_FILE, pdfOutputFile);
                dict.Add(AspriseOCR.PROP_PDF_OUTPUT_TEXT_VISIBLE, checkPdfHighlightText.Checked ? "true" : "false");
                dict.Add(AspriseOCR.PROP_PDF_OUTPUT_IMAGE_FORCE_BW, "true");
            }

            log("OCR in progress, please stand by ...", true);
            DateTime timeStart = DateTime.Now;
            // Performs the actual recognition
            string s = ocr.Recognize(textImage.Text.Trim(), -1, -1, -1, -1, -1, recognizeType, outputFormat, dict);
            DateTime timeEnd = DateTime.Now;

            // open pdf file
            if (outputFormat.Equals(AspriseOCR.OUTPUT_FORMAT_PDF))
            {
                if (s != null && s.Trim().Length > 0)
                {
                    log(s + "\nPDF file: " + pdfOutputFile, true);
                }
                else
                {
                    log("PDF file created: " + pdfOutputFile, true);
                    try
                    {
                        System.Diagnostics.Process.Start(@pdfOutputFile);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                log("For illustration purpose, text has been rendered in color instead of transparent.");
            }
            else if (outputFormat.Equals(AspriseOCR.OUTPUT_FORMAT_XML))
            {
                log("", true);
                try
                {
                    string xmlOutputFile = Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString("O").Replace(':', '-') + ".xml");
                    File.WriteAllText(xmlOutputFile, s, Encoding.UTF8);
                    AspriseOCR.saveAocrXslTo(Directory.GetCurrentDirectory(), false);
                    if (File.Exists(xmlOutputFile))
                    {
                        log("You may view the XML file using IE or Firefox: " + xmlOutputFile, true);
                        System.Diagnostics.Process.Start(@xmlOutputFile);
                    }
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
                log(s, false);
            }
            else
            {
                log(s, true);
            }

            // user preference
            saveSettings();
        }

        private void linkMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://asprise.com/product/ocr");
        }

        private void textImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioOutputText_CheckedChanged(object sender, EventArgs e)
        {
            updateUI();
        }

        private void radioOutputXml_CheckedChanged(object sender, EventArgs e)
        {
            updateUI();
        }

        private void radioOutputPdf_CheckedChanged(object sender, EventArgs e)
        {
            updateUI();
        }

        private static string getDynamicSettingsPath(string fileSimpleName) {
            String appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (appData == null || appData.Length == 0)
            {
                appData = Directory.GetCurrentDirectory();
            }
            if (!appData.EndsWith("/") && !appData.EndsWith("\\"))
            {
                appData += "\\";
            }
            string path = appData + fileSimpleName;
            return path;
        }

        private static void saveDynamicSettings(Dictionary<string, string> properties, string fileSimpleName)
        {
            string path = getDynamicSettingsPath(fileSimpleName);

            System.IO.StreamWriter file = new System.IO.StreamWriter(path, false, Encoding.UTF8);

            foreach(String prop in properties.Keys.ToArray()) {
                file.WriteLine(prop + "=" + properties[prop]);
            }

            file.Close();
        }
        private static Dictionary<string, string> readDynamicSettings(string fileSimpleName)
        {
            string path = getDynamicSettingsPath(fileSimpleName);

            Dictionary<string, string> properties = new Dictionary<string, string>();
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                if (lines != null)
                {
                    foreach(string line in lines) {
                        int equalPos = line.IndexOf('=');
                        if(equalPos <= 0) {
                            continue;
                        }
                        properties.Add(line.Substring(0, equalPos).Trim(), line.Length == equalPos + 1 ? "" : line.Substring(equalPos+1).Trim());
                    }
                }
            }
            return properties;
        }

    }
}
