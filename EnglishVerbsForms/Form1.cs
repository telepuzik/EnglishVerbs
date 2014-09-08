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

namespace EnglishVerbsForms
{
    public partial class Form1 : Form
    {
        VerbsList currentVerb;
        List<VerbsList> verbsList;
        int currentVerbIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verbsList = LoadFile();

            if (verbsList != null) {
                fileInd.Text = "dictionary loaded";
                fileInd.ForeColor = System.Drawing.Color.Green;
                fileInd.Visible = true;

                GetNewVerb();
            }
        }

        private void GetNewVerb()
        {
            if (verbsList.Count != 0)
            {
                var randomIndex = new Random();
                currentVerbIndex = randomIndex.Next(0, verbsList.Count);

                currentVerb = verbsList[currentVerbIndex];
                verbsList.RemoveAt(currentVerbIndex);

                formone.Text = currentVerb.FormZero;
                formone.Visible = true;

                formonebox.Text = "";
                formtwobox.Text = "";
                formthreebox.Text = "";
                formfourbox.Text = "";
                formfivebox.Text = "";

                formonelabel.Visible = false;
                formtwolabel.Visible = false;
                formthreelabel.Visible = false;
                formfourlabel.Visible = false;
                formfivelabel.Visible = false;

                formonebox.Focus();
            }
            else {
                formone.Text = "FINISHED";
                formone.Visible = true;
                formone.ForeColor = System.Drawing.Color.Green;

                formonelabel.Visible = false;
                formtwolabel.Visible = false;
                formthreelabel.Visible = false;
                formfourlabel.Visible = false;
                formfivelabel.Visible = false;

                formonebox.Enabled = false;
                formtwobox.Enabled = false;
                formthreebox.Enabled = false;
                formfourbox.Enabled = false;
                formfivebox.Enabled = false;
            }

        }

        private List<VerbsList> LoadFile()
        {
            var reader = new StreamReader(File.OpenRead(@"\lib\list_verbs.csv"), System.Text.Encoding.Default);
            List<VerbsList> VerbsListValues = new List<VerbsList>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                var verbsLine = new VerbsList
                {
                    FormZero = values[0],
                    FormOne = values[1],
                    FormTwo = values[2],
                    FormThree = values[3],
                    FormFour = values[4],
                    FormFive = values[5]
                };

                VerbsListValues.Add(verbsLine);
            }

            return VerbsListValues;
        }

        private void formonebox_Leave(object sender, EventArgs e)
        {
            if (formonebox.Text != currentVerb.FormOne)
            {
                formonelabel.ForeColor = System.Drawing.Color.Red;
                formonelabel.Text = "incorrect! form:" + currentVerb.FormOne;
                formonelabel.Visible = true;
                formonebox.Focus();
            }
        }

        private void formonebox_TextChanged(object sender, EventArgs e)
        {
            if (formonebox.Text == currentVerb.FormOne)
            {
                formonelabel.ForeColor = System.Drawing.Color.Green;
                formonelabel.Text = "correct";
                formonelabel.Visible = true;

                formtwobox.Focus();
            }
        }

        private void formtwobox_Leave(object sender, EventArgs e)
        {
            if (formtwobox.Text != currentVerb.FormTwo)
            {
                formtwolabel.ForeColor = System.Drawing.Color.Red;
                formtwolabel.Text = "incorrect! form:" + currentVerb.FormTwo ;
                formtwolabel.Visible = true;
                formtwobox.Focus();
            }
        }

        private void formtwobox_TextChanged(object sender, EventArgs e)
        {
            if (formtwobox.Text == currentVerb.FormTwo)
            {
                formtwolabel.ForeColor = System.Drawing.Color.Green;
                formtwolabel.Text = "correct";
                formtwolabel.Visible = true;

                formthreebox.Focus();
            }
        }

        private void formthreebox_TextChanged(object sender, EventArgs e)
        {
            if (formthreebox.Text == currentVerb.FormThree)
            {
                formthreelabel.ForeColor = System.Drawing.Color.Green;
                formthreelabel.Text = "correct";
                formthreelabel.Visible = true;

                formfourbox.Focus();
            }
        }

        private void formthreebox_Leave(object sender, EventArgs e)
        {
            if (formthreebox.Text != currentVerb.FormThree)
            {
                formthreelabel.ForeColor = System.Drawing.Color.Red;
                formthreelabel.Text = "incorrect! form:" + currentVerb.FormThree;
                formthreelabel.Visible = true;
                formthreebox.Focus();
            }
        }

        private void formfourbox_TextChanged(object sender, EventArgs e)
        {
            if (formfourbox.Text == currentVerb.FormFour)
            {
                formfourlabel.ForeColor = System.Drawing.Color.Green;
                formfourlabel.Text = "correct";
                formfourlabel.Visible = true;

                formfivebox.Focus();
            }
        }

        private void formfourbox_Leave(object sender, EventArgs e)
        {
            if (formfourbox.Text != currentVerb.FormFour)
            {
                formfourlabel.ForeColor = System.Drawing.Color.Red;
                formfourlabel.Text = "incorrect! form:" + currentVerb.FormFour;
                formfourlabel.Visible = true;
                formfourbox.Focus();
            }
        }

        private void formfivebox_TextChanged(object sender, EventArgs e)
        {
            if (formfivebox.Text == currentVerb.FormFive)
            {
                formfivelabel.ForeColor = System.Drawing.Color.Green;
                formfivelabel.Text = "correct";
                formfivelabel.Visible = true;
                
                //formtwobox.Text = "";
                formonebox.Focus();

                GetNewVerb();
            }
        }

        private void formfivebox_Leave(object sender, EventArgs e)
        {
            if (formfivebox.Text != currentVerb.FormFive)
            {
                formfivelabel.ForeColor = System.Drawing.Color.Red;
                formfivelabel.Text = "incorrect! form:" + currentVerb.FormFive;
                formfivelabel.Visible = true;
                formfivebox.Focus();
            }
        }

        

        
    }
}
