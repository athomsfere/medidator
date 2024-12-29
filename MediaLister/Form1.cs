using Maroquio;
using MediaLister.classes;
using medidator.classes;
using Microsoft.VisualBasic.Devices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: System.Reflection.AssemblyVersion("0.0.*")]
namespace MediaLister
{
    public partial class medidator : Form
    {
        List<string> folderList = new List<string>();
        List<string> knownExtensions = new List<string>()
        {
            ".mkv",
            ".mp4",
            ".avi",
            ".mov",
            ".divx"
        };
        BindingList<MovieInfo> movies = new BindingList<MovieInfo>();
        SortableBindingList<MovieInfo> movieSource = new SortableBindingList<MovieInfo>();

        bool isAlive = false;
        List<Column> showColumns = new List<Column>();

        public medidator()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        internal void GetColumns()
        {
            var columns = new FileOperations().GetColumns();

            if (columns == null)
            {
                var columnController = new ColumnCreator();
                columns = columnController.GetDefaultColumns();
            }


            columns = columns.OrderBy(o => o.Position).ToList();

            int location = 0;


            foreach (var item in columns)
            {
                checkedListBox1.DisplayMember = "Description";
                checkedListBox1.ValueMember = "IsChecked";
                checkedListBox1.Items.Add(item, item.IsChecked);

                if (!item.IsChecked)
                {
                    this.movieInfoGrid.Columns.Remove(item.Name);
                }

                location++;
            }


            //checkedListBox1.
            checkedListBox1.Refresh();
            this.showColumns = columns;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var shouldUnzip = !FFLocator.hasProbe();

            if (shouldUnzip) {
                var hackers = new FFHacks();
                hackers.unzipMpeg();
                hackers.unzipProbe();

            }
            movieSource = new SortableBindingList<MovieInfo>(this.movies)
            {
                //DataGridViewColumnSortMode = DataGridViewColumnSortMode.Programmatic,
            };
            movieInfoGrid.DataSource = movieSource;


            GetColumns();
        }

        private bool testAliveCom(string filePath)
        {
            return new ShellProcessor().GetAllMediaProperties(filePath).Any();
        }

        private async void AddMoviesFromFolderSet(List<string> folders)
        {
            foreach (var folder in folders)
            {
                AddMovies(folder);
            }

        }

        private async Task addFolderAndMoviesAsync()
        {
            var timeToProcess = new System.Diagnostics.Stopwatch();
            timeToProcess.Start();

            timeElapseLabel.Text = "Processing...";
            timeElapseLabel.Visible = true;

            //folderList.ForEach(e =>
            //{
            //    AddMovies(e);
            //});

            //folderList.Add(folderName);
            //AddMovies(folderName);

            if (isRecursiveAdd.Checked)
            {
                //var allFolders = Directory.GetDirectories(folderName);
                var processorsAvailable = Environment.ProcessorCount;

                var firstFile = folderList.FirstOrDefault(f => Directory.GetFiles(f).ToList().Where(w => knownExtensions.Contains(Path.GetExtension(w))).Any());

                if (firstFile == null)
                {
                    MessageBox.Show("No movies found");
                    return;
                }

                var testFile = Directory.GetFiles(firstFile).ToList().Where(f => knownExtensions.Contains(Path.GetExtension(f).ToLower())).First();
                var isComLoaded = this.testAliveCom(testFile);


                var splitSize = folderList.Count / processorsAvailable;

                List<List<string>> splitFolders = folderList.Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / (splitSize > 0 ? splitSize : 1))
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();

                if (statusStrip1.InvokeRequired)
                {
                    this.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                    {
                        toolStripProgressBar1.Visible = false;
                    }));
                }

                var threads = new List<Task>();
                this.isAlive = true;
                foreach (var folderset in splitFolders)
                {
                    //var thread = new Task(() =>
                    //{
                    //    //while (isAlive)
                    //    //{
                    //    foreach (var folder in folderset)
                    //    {
                    //        AddMovies(folder);
                    //    }
                    //    //}

                    //});

                    Task thread = Task.Factory.StartNew(() => AddMoviesFromFolderSet(folderset));

                    threads.Add(thread);
                    //thread.Start();
                }

                await Task.WhenAll(threads);


                toolStripProgressBar1.Visible = false;
                timeElapseLabel.Text = $"Processed {movieSource.Count} files in: {timeToProcess.Elapsed}";
                timeToProcess.Stop();

            }



        }

        private void AddMovies(string folderName)
        {
            var files = Directory.GetFiles(folderName).ToList().Where(f => knownExtensions.Contains(Path.GetExtension(f).ToLower()));
            var attributes = "width,height,codec_long_name,codec_name,sample_aspect_ratio,sample_display_ratio,color_space,r_frame_rate,avg_frame_rate,bit_rate,max_bit_rate";
            foreach (var file in files)
            {

                var movieProperties = new ShellProcessor().GetAllMediaProperties(file);


                var movie = new MovieInfo();
                //{
                movie.ParentFolder = folderName;

                try
                {
                    movie.Duration = movieProperties["System.Media.Duration"].FormatForDisplay(PropertyDescriptionFormatOptions.None);
                }
                catch (System.IndexOutOfRangeException ioe)
                {
                    movie.Duration = "UNREAD";
                }

                movie.MovieName = movieProperties["System.ParsingName"].FormatForDisplay(PropertyDescriptionFormatOptions.None);
                //};

                var isMovieKind = movieProperties["System.KindText"].FormatForDisplay(PropertyDescriptionFormatOptions.None).ToLowerInvariant() == "video";

                var probe = Directory.GetFiles(@".\ff\").Where(w => w.Contains("ffprobe")).First();
                FileInfo fileInfo = new FileInfo(file);
                movie.FileSizeGB = FileInfoProcessor.GetGBFileSize(fileInfo.Length);

                var probeLocation = Path.GetFullPath(probe);

                string result;
                using (Process p = new Process())
                {
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.FileName = probeLocation;
                    p.StartInfo.Arguments = $"-v error -show_entries stream={attributes} -of json \"{file}\"";
                    p.Start();
                    p.WaitForExit();


                    using (StreamReader reader = p.StandardOutput)
                    {
                        result = reader.ReadToEnd();
                    }

                }


                var ffReadResult = JsonSerializer.Deserialize<FFResult>(result);
                //movie.Format = FormatProcessor.GetGuessedFormat(result);
                movie.Format = FormatProcessor.GetGuessedFormat(ffReadResult.streams);
                movie.Codecs = StreamProcessor.GetCodecs(ffReadResult.streams);
                movie.Resolution = $"{ffReadResult.streams[0].width} x {ffReadResult.streams[0].height}";
                // var resutls = 

                //this.movies.Add(movie);
                lock (movieSource)
                {
                    if (movieInfoGrid.InvokeRequired)
                    {
                        this.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            this.movieSource.Add(movie);

                        }));

                    }

                    else
                    {
                        this.movieSource.Add(movie);
                    }
                }


            }
        }

        private void addFolderForProcessing(string folder)
        {
            folderList.Add(folder);

            if (isRecursiveAdd.Checked)
            {
                var folders = Directory.GetDirectories(folder);

                foreach (var childFolder in folders)
                {
                    addFolderForProcessing(childFolder);
                }
            }

            if (listBox1.InvokeRequired)
            {
                this.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                {
                    listBox1.Items.Add(folder);

                }));
            }

            else
            {
                listBox1.Items.Add(folder);
            }

            toolStripProgressBar1.Visible = false;
        }

        private void addFolder_Click(object sender, EventArgs e)
        {

            //var foldersToAdd = new List<Directory>();
            using (var folderBrowser = new FolderBrowserDialog())
            {
                DialogResult results = folderBrowser.ShowDialog();

                if (results == DialogResult.OK)
                {
                    toolStripProgressBar1.Visible = true;

                    addFolderForProcessing(folderBrowser.SelectedPath);
                }
            }


        }

        private void isRecursiveAdd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAlive)
            {
                isAlive = false;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {

                movieInfoGrid.Columns.Remove(showColumns[e.Index].Name);
            }

            if (showColumns.Count < 1)
            {
                return;
            }

            if (e.NewValue == CheckState.Checked)
            {
                movieInfoGrid.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = showColumns[e.Index].Name,
                    HeaderText = showColumns[e.Index].Description,
                    Name = showColumns[e.Index].Name,
                });

                //   showColumns[e.Index].Name, showColumns[e.Index].Description);
            }

            showColumns[e.Index].IsChecked = e.NewValue == CheckState.Checked;
        }

        private void saveColumns_Click(object sender, EventArgs e)
        {
            var fileSaveSuccess = new FileOperations().TrySaveColumns(showColumns);


        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void scan_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;

            movies.Clear();
            movieSource.Clear();

            await addFolderAndMoviesAsync();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }


        private string sortColumn { get; set; }
        private bool isAsc = false;
        private void movieInfoGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = (sender as DataGridView).Columns[e.ColumnIndex];
            isAsc = !isAsc;
            movieInfoGrid.Sort(column, isAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);

            //MessageBox.Show(sender.ToString());
        }

        private void movieInfoGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    gridMenuStrip.Show(movieInfoGrid, new Point(e.X, e.Y));
            //}
        }

        private void gridMenuStrip_MouseClick(object sender, MouseEventArgs e)
        {
            var currentRow = ((sender as ContextMenuStrip).SourceControl as DataGridView).CurrentRow.DataBoundItem;

            //var selectedOption = (Button)((ContextMenuStrip)((ToolStripMenuItem)sender).).SourceControl;
            Button menuClicked = (Button)((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl;

            MessageBox.Show(e.Location.ToString());
        }

        private void movieInfoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
