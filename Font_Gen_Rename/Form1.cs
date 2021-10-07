using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Font_Gen_Rename
{
    public partial class Form1 : Form
    {
        private string default_title;

        public Form1()
        {
            InitializeComponent();
            default_title = this.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 確実にファイル／ディレクトリの名前を変更する
        /// </summary>
        /// <param name="sourceFilePath">変更元ファイルパス</param>
        /// <param name="outputFilePath">変更後ファイルパス</param>
        public static void Rename(string sourceFilePath, string outputFilePath)
        {
            var fileInfo = new FileInfo(sourceFilePath);

            if (fileInfo.Attributes.HasFlag(FileAttributes.Directory))
            {
                RenameDirectory(sourceFilePath, outputFilePath);
            }
            else
            {
                fileInfo.MoveTo(outputFilePath);
            }
        }

        /// <summary>
        /// 確実にディレクトリの名前を変更する
        /// </summary>
        /// <param name="sourceFilePath">変更元ファイルパス</param>
        /// <param name="outputFilePath">変更後ファイルパス</param>
        public static void RenameDirectory(string sourceFilePath, string outputFilePath)
        {
            //Directory.Moveはなぜか、大文字小文字だけの変更だとエラーする
            //なので、大文字小文字だけの変更の場合は一度別のファイル名に変更する
            if ((String.Compare(sourceFilePath, outputFilePath, true) == 0))
            {
                var tempPath = GetSafeTempName(outputFilePath);

                Directory.Move(sourceFilePath, tempPath);
                Directory.Move(tempPath, outputFilePath);
            }
            else
            {
                Directory.Move(sourceFilePath, outputFilePath);
            }
        }

        /// <summary>
        /// 指定したファイルパスが他のファイルパスとかぶらなくなるまで"_"を足して返す
        /// </summary>
        private static String GetSafeTempName(string outputFilePath)
        {
            outputFilePath += "_";
            while (File.Exists(outputFilePath))
            {
                outputFilePath += "_";
            }
            return outputFilePath;
        }

        /// <summary>
        /// 指定されたパス文字列から拡張子を削除して返します
        /// </summary>
        public static string GetPathWithoutExtension(string path)
        {
            var extension = Path.GetExtension(path);
            if (string.IsNullOrEmpty(extension))
            {
                return path;
            }
            return path.Replace(extension, string.Empty);
        }

        delegate void DelegateProcess();

        private Task Font_Gen_Rename_Files(String OutputPath)
        {
            string[] names = Directory.GetFiles(OutputPath, "*");
            int len = 0;
            string filename = "";

            int per = 0;
            int filecount = names.Length;

            foreach (string name in names)
            {
                if (name.Contains("unicode_page_"))
                {
                    filename = Path.GetFileName(name);
                    len = name.Length;
                    RenameDirectory(name, Path.GetDirectoryName(name) + "\\glyph_" + (GetPathWithoutExtension(filename.Substring(filename.Length - 6)).ToUpper() + ".png"));
                    
                    per++;
                }

                if (this.InvokeRequired)
                {
                    //別スレッドによるUI操作
                    this.Invoke((MethodInvoker)(() => this.Text = default_title + "：" + ((per / filecount) * 100).ToString() + "%"));
                }
                else
                {
                    //UIスレッドからのUI操作
                    this.Text = default_title + "：" + ((per / filecount) * 100).ToString() + "%";
                }
            }

            if (this.InvokeRequired)
            {
                //別スレッドによるUI操作
                this.Invoke((MethodInvoker)(() => this.Text = default_title));
            }
            else
            {
                //UIスレッドからのUI操作
                this.Text = default_title;
            }

            return null;

        }

        private Task Undo(String OutputPath)
        {
            string[] names = Directory.GetFiles(OutputPath, "*");
            int len = 0;
            string filename = "";

            int per = 0;
            int filecount = names.Length;

            foreach (string name in names)
            {
                if (name.Contains("glyph_"))
                {
                    filename = Path.GetFileName(name);
                    len = name.Length;

                    RenameDirectory(name, Path.GetDirectoryName(name) + "\\unicode_page_" + (GetPathWithoutExtension(filename.Substring(filename.Length - 6)).ToLower() + ".png"));

                    per++;

                }

                if (this.InvokeRequired)
                {
                    //別スレッドによるUI操作
                    this.Invoke((MethodInvoker)(() => this.Text = default_title + "：" + ((per / filecount) * 100).ToString() + "%"));
                }
                else
                {
                    //UIスレッドからのUI操作
                    this.Text = default_title + "：" + ((per / filecount) * 100).ToString() + "%";
                }

            }

            if (this.InvokeRequired)
            {
                //別スレッドによるUI操作
                this.Invoke((MethodInvoker)(() => this.Text = default_title));
            }
            else
            {
                //UIスレッドからのUI操作
                this.Text = default_title;
            }

            return null;

        }


        private async void FormOKButton_Click(object sender, EventArgs e)
        {
            string OutputPath = OutputPathBox.Text;

            try
            {
                await Task.Run(() => Font_Gen_Rename_Files(OutputPath));
            }
            catch
            {

            }
            Task.WaitAll();

        }

        private async void UndoRenameButton_Click(object sender, EventArgs e)
        {
            string OutputPath = OutputPathBox.Text;

            try
            {
                await Task.Run(() => Undo(OutputPath));
            }
            catch
            {

            }
            Task.WaitAll();
        }

        private void FormCancelButton_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
            Environment.Exit(1);
        }
    }
}
