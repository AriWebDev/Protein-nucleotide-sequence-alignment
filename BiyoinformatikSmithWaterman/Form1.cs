using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiyoinformatikSmithWaterman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 10;
        }

        string seq1, seq2, seq1_length, seq2_length;

        private void buttonSmithWaterman_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Refresh();

            textBoxSeq1.Text = String.Empty;
            textBoxSeq2.Text = String.Empty;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            StreamReader sr = new StreamReader(@"C:\Users\BiyoinformatikSmithWaterman\SmithWatermanText\seq1.txt");
            seq1_length = sr.ReadLine();
            seq1 = sr.ReadToEnd().Replace("\n", "").Replace("\r", "");

            StreamReader sr2 = new StreamReader(@"C:\Users\BiyoinformatikSmithWaterman\SmithWatermanText\seq2.txt");
            seq2_length = sr2.ReadLine();
            seq2 = sr2.ReadToEnd().Replace("\n", "").Replace("\r", "");

            //int s1_length = int.Parse(seq1_length);
            //int s2_length = int.Parse(seq2_length);

            textBoxSeq1.ScrollBars = ScrollBars.Both;
            textBoxSeq1.WordWrap = false;
            textBoxSeq2.ScrollBars = ScrollBars.Both;
            textBoxSeq2.WordWrap = false;

            string s1 = seq1.ToUpper();
            string s2 = seq2.ToUpper();
            int match = Convert.ToInt32(textBoxMatch.Text);
            int miss = Convert.ToInt32(textBoxMiss.Text);
            int gap = Convert.ToInt32(textBoxGap.Text);

            //char[] temp = new char[s1_length];
            //char[] temp2 = new char[s2_length];

            char[] temp = new char[s1.Length];
            char[] temp2 = new char[s2.Length];

            temp = s1.ToCharArray();
            temp2 = s2.ToCharArray();
            dataGridView.ColumnCount = temp.Length + 1;
            dataGridView.RowCount = temp2.Length + 1;
            dataGridView.Columns[0].Name = "m";
            dataGridView.Rows[0].HeaderCell.Value = "n";
            for (int i = 0; i < temp.Length; i++)
            {
                dataGridView.Columns[i + 1].Name = temp[i].ToString();
            }
            for (int j = 0; j < temp2.Length; j++)
            {
                dataGridView.Rows[j + 1].HeaderCell.Value = temp2[j].ToString();
            }

            int a;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView[i, 0].Value = 0;
            }
            for (int j = 0; j < dataGridView.Rows.Count; j++)
            {
                dataGridView[0, j].Value = 0;
            }

            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 1; j < dataGridView.Rows.Count; j++)
                {
                    if (dataGridView.Columns[i].Name.ToString() == dataGridView.Rows[j].HeaderCell.Value.ToString())
                    {
                        a = Math.Max(int.Parse(dataGridView[i - 1, j].Value.ToString()) + gap,
                        Math.Max(int.Parse(dataGridView[i, j - 1].Value.ToString()) + gap, int.Parse(dataGridView[i - 1, j - 1].Value.ToString()) + match));
                        if (a > 0)
                        {
                            dataGridView[i, j].Value = a;
                        }
                        else
                        {
                            dataGridView[i, j].Value = 0;
                        }
                    }
                    else
                    {
                        a = Math.Max(int.Parse(dataGridView[i - 1, j].Value.ToString()) + gap,
                        Math.Max(int.Parse(dataGridView[i, j - 1].Value.ToString()) + gap, int.Parse(dataGridView[i - 1, j - 1].Value.ToString()) + miss));
                        if (a > 0)
                        {
                            dataGridView[i, j].Value = a;
                        }
                        else
                        {
                            dataGridView[i, j].Value = 0;
                        }

                    }
                }
            }
            int max = int.Parse(dataGridView[0, 0].Value.ToString());

            StringBuilder Seq1Alignment = new StringBuilder();
            StringBuilder Seq2Alignment = new StringBuilder();
            List<string> Seq1List = new List<string>();
            List<string> Seq2List = new List<string>();
            List<int> scoreList = new List<int>();

            s1 = "-" + s1;
            s2 = "-" + s2;
            int score = 0;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if (int.Parse(dataGridView[i, j].Value.ToString()) > max)
                    {
                        max = int.Parse(dataGridView[i, j].Value.ToString());
                    }
                }
            }

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if (int.Parse(dataGridView[i, j].Value.ToString()) == max)
                    {
                        int x = i;
                        int y = j;
                        while (true)
                        {
                            int temp_score = 0;

                            while (int.Parse(dataGridView[x, y].Value.ToString()) != 0)
                            {
                                if (dataGridView.Columns[x].Name.ToString() == dataGridView.Rows[y].HeaderCell.Value.ToString())
                                {
                                    Seq1Alignment.Insert(0, s1[x]);
                                    Seq2Alignment.Insert(0, s2[y]);
                                    dataGridView[x, y].Style.BackColor = Color.Red;
                                    temp_score += match;
                                    x--;
                                    y--;
                                }
                                else
                                {
                                    if (int.Parse(dataGridView[x, y].Value.ToString()) == (int.Parse(dataGridView[x, y - 1].Value.ToString()) + gap)) // çapraz max ise
                                    {
                                        Seq1Alignment.Insert(0, "-");
                                        Seq2Alignment.Insert(0, s2[y]);
                                        dataGridView[x, y].Style.BackColor = Color.Red;
                                        temp_score += gap;
                                        y--;
                                    }
                                    else if (int.Parse(dataGridView[x, y].Value.ToString()) == (int.Parse(dataGridView[x - 1, y - 1].Value.ToString()) + miss)) //sol max ise
                                    {
                                        Seq1Alignment.Insert(0, s1[x]);
                                        Seq2Alignment.Insert(0, s2[y]);
                                        dataGridView[x, y].Style.BackColor = Color.Red;
                                        temp_score += miss;
                                        x--;
                                        y--;
                                    }
                                    else if (int.Parse(dataGridView[x, y].Value.ToString()) == (int.Parse(dataGridView[x - 1, y].Value.ToString()) + gap)) //yukarı max ise
                                    {
                                        Seq1Alignment.Insert(0, s1[x]);
                                        Seq2Alignment.Insert(0, "-");
                                        dataGridView[x, y].Style.BackColor = Color.Red;
                                        temp_score += gap;
                                        x--;
                                    }
                                }
                            }
                            scoreList.Add(temp_score);
                            Seq1List.Add(Seq1Alignment.ToString());
                            Seq2List.Add(Seq2Alignment.ToString());

                            Seq1Alignment.Length = 0;
                            Seq2Alignment.Length = 0;

                            if (temp_score >= score)
                            {
                                score = temp_score;
                            }
                            else
                            {
                                continue;
                            }
                            if (int.Parse(dataGridView[x, y].Value.ToString()) == 0)
                            {
                                dataGridView[x, y].Style.BackColor = Color.Red;
                                break;
                            }
                        }
                    }
                    else continue;
                }
            }
            int count = 0;
            for (int i = 0; i < scoreList.Count; i++)
            {
                if (scoreList[i] == score)
                {
                    count++;
                    if (count > 1)
                    {
                        textBoxSeq1.Text += Seq1List[i].ToString() + "          ";
                        textBoxSeq2.Text += Seq2List[i].ToString() + "          ";
                    }
                    else
                    {
                        textBoxSeq1.Text += Seq1List[i].ToString() + "          ";
                        textBoxSeq2.Text += Seq2List[i].ToString() + "          ";
                    }
                }
            }
            textBoxScore.Text = score.ToString();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            labelRunTime.Text = ("RunTime " + elapsedTime);
        }

        private void buttonNeedlemanWunsch_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Refresh();

            textBoxSeq1.Text = String.Empty;
            textBoxSeq2.Text = String.Empty;

            StreamReader sr = new StreamReader(@"C:\Users\BiyoinformatikSmithWaterman\SmithWatermanText\seq1.txt");
            seq1_length = sr.ReadLine();
            seq1 = sr.ReadToEnd().Replace("\n", "").Replace("\r", "");

            StreamReader sr2 = new StreamReader(@"C:\Users\BiyoinformatikSmithWaterman\SmithWatermanText\seq2.txt");
            seq2_length = sr2.ReadLine();
            seq2 = sr2.ReadToEnd().Replace("\n", "").Replace("\r", "");

            int s1_length = int.Parse(seq1_length);
            int s2_length = int.Parse(seq2_length);

            textBoxSeq1.ScrollBars = ScrollBars.Both;
            textBoxSeq1.WordWrap = false;
            textBoxSeq2.ScrollBars = ScrollBars.Both;
            textBoxSeq2.WordWrap = false;

            string s1 = seq1.ToUpper();
            string s2 = seq2.ToUpper();
            int match = Convert.ToInt32(textBoxMatch.Text);
            int missmatch = Convert.ToInt32(textBoxMiss.Text);
            int gap = Convert.ToInt32(textBoxGap.Text);

            char[] columnNames = new char[s1.Length];
            char[] rowNames = new char[s2.Length];

            columnNames = s1.ToCharArray();
            rowNames = s2.ToCharArray();
            dataGridView.ColumnCount = columnNames.Length + 1;
            dataGridView.RowCount = rowNames.Length + 1;
            dataGridView.Columns[0].Name = "m";
            dataGridView.Rows[0].HeaderCell.Value = "n";

            for (int i = 0; i < columnNames.Length; i++)
            {
                dataGridView.Columns[i + 1].Name = columnNames[i].ToString();
            }
            for (int j = 0; j < rowNames.Length; j++)
            {
                dataGridView.Rows[j + 1].HeaderCell.Value = rowNames[j].ToString();
            }

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if (i - 1 < 0 && j - 1 >= 0)
                    {
                        dataGridView[i, j].Value = int.Parse(dataGridView[i, j - 1].Value.ToString()) + gap;
                    }
                    else if (j - 1 < 0 && i - 1 >= 0)
                    {
                        dataGridView[i, j].Value = int.Parse(dataGridView[i - 1, j].Value.ToString()) + gap;
                    }
                    else if (j - 1 < 0 && i - 1 < 0)
                    {
                        dataGridView[i, j].Value = 0;
                    }

                }
            }

            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                for (int j = 1; j < dataGridView.Rows.Count; j++)
                {
                    if (dataGridView.Columns[i].Name.ToString() == dataGridView.Rows[j].HeaderCell.Value.ToString())
                    {
                        dataGridView[i, j].Value = Math.Max(int.Parse(dataGridView[i - 1, j].Value.ToString()) + gap,
                        Math.Max(int.Parse(dataGridView[i, j - 1].Value.ToString()) + gap, int.Parse(dataGridView[i - 1, j - 1].Value.ToString()) + match));
                    }
                    else
                    {
                        dataGridView[i, j].Value = Math.Max(int.Parse(dataGridView[i - 1, j].Value.ToString()) + gap,
                        Math.Max(int.Parse(dataGridView[i, j - 1].Value.ToString()) + gap, int.Parse(dataGridView[i - 1, j - 1].Value.ToString()) + missmatch));
                    }
                }
            }

            //Hizalama (Alignment)

            int a = dataGridView.Columns.Count - 1;
            int b = dataGridView.Rows.Count - 1;

            StringBuilder S1Alignment = new StringBuilder();
            StringBuilder S2Alignment = new StringBuilder();

            s1 = "-" + s1;
            s2 = "-" + s2;
            while (a > -1 && b > -1)
            {
                while (a != 0 && b != 0)
                {
                    if (dataGridView.Columns[a].Name.ToString() == dataGridView.Rows[b].HeaderCell.Value.ToString())
                    {
                        S1Alignment.Insert(0, s1[a]);
                        S2Alignment.Insert(0, s2[b]);
                        dataGridView[a, b].Style.BackColor = Color.Red;
                        a--;
                        b--;
                    }
                    else
                    {
                        if (int.Parse(dataGridView[a, b].Value.ToString()) == (int.Parse(dataGridView[a, b - 1].Value.ToString()) + gap))
                        {
                            S1Alignment.Insert(0, "-");
                            S2Alignment.Insert(0, s2[b]);
                            dataGridView[a, b].Style.BackColor = Color.Red;
                            b--;
                        }
                        else if (int.Parse(dataGridView[a, b].Value.ToString()) == (int.Parse(dataGridView[a - 1, b - 1].Value.ToString()) + missmatch))
                        {
                            S1Alignment.Insert(0, s1[a]);
                            S2Alignment.Insert(0, s2[b]);
                            dataGridView[a, b].Style.BackColor = Color.Red;
                            a--;
                            b--;
                        }
                        else if (int.Parse(dataGridView[a, b].Value.ToString()) == (int.Parse(dataGridView[a - 1, b].Value.ToString()) + gap))
                        {
                            S1Alignment.Insert(0, s1[a]);
                            S2Alignment.Insert(0, "-");
                            dataGridView[a, b].Style.BackColor = Color.Red;
                            a--;
                        }
                    }
                }

                if (a - 1 < 0 && b - 1 >= 0)
                {
                    if (int.Parse(dataGridView[a, b].Value.ToString()) == gap)
                    {
                        S1Alignment.Insert(0, "-");
                        S2Alignment.Insert(0, s2[b]);
                        dataGridView[a, b].Style.BackColor = Color.Red;
                        b--;
                    }
                }
                else if (b - 1 < 0 && a - 1 >= 0)
                {
                    if (int.Parse(dataGridView[a, b].Value.ToString()) == gap)
                    {
                        S1Alignment.Insert(0, s1[a]);
                        S2Alignment.Insert(0, "-");
                        dataGridView[a, b].Style.BackColor = Color.Red;
                        a--;
                    }
                }
                dataGridView[a, b].Style.BackColor = Color.Red;
                a--;
                b--;
            }

            textBoxSeq1.Text = S1Alignment.ToString();
            textBoxSeq2.Text = S2Alignment.ToString();

            //Score hesaplama

            char[] arr1 = new char[S1Alignment.Length];
            char[] arr2 = new char[S2Alignment.Length];
            arr1 = S1Alignment.ToString().ToCharArray();
            arr2 = S2Alignment.ToString().ToCharArray();

            int x = arr1.Length - 1;
            int y = arr2.Length - 1;
            int score = 0;

            while (x > -1 && y > -1)
            {
                if (arr1[x] == arr2[y])
                {
                    score += match;
                    x--;
                    y--;
                }
                else if (arr1[x] != arr2[y])
                {
                    if (arr1[x] == '-' || arr2[y] == '-')
                    {
                        score += gap;
                        x--;
                        y--;
                    }
                    else
                    {
                        score += missmatch;
                        x--;
                        y--;
                    }
                }
            }
            textBoxScore.Text = score.ToString();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            labelRunTime.Text = ("RunTime " + elapsedTime);
        }
    }
}
