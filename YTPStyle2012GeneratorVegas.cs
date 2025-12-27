using System;
using System.IO;
using System.Windows.Forms;
using ScriptPortal.Vegas;

public class EntryPoint {
    public void FromVegas(Vegas vegas) {
        Application.EnableVisualStyles();
        Application.Run(new YTPForm(vegas));
    }
}

public class YTPForm : Form
{
    public string videoSource, audioSource, musicSource, photoSource, gifSource, mlgSource;
    public bool earRape, stutterLoop, sentenceMixing, spadinner, specialEffect, ytpHelper;

    private Vegas vegas;

    public YTPForm(Vegas vegasInstance)
    {
        vegas = vegasInstance;
        this.Text = "YTP Style 2012 Generator (VEGAS Pro 14)";

        var layout = new TableLayoutPanel { RowCount = 15, ColumnCount = 2, Dock = DockStyle.Fill, AutoSize = true };
        this.Controls.Add(layout);

        layout.Controls.Add(new Label { Text = "Video Source:" }, 0, 0);
        var videoBtn = new Button { Text = "Browse..." }; layout.Controls.Add(videoBtn, 1, 0);
        videoBtn.Click += (s, e) => { videoSource = PickFile(); };

        layout.Controls.Add(new Label { Text = "Audio Source:" }, 0, 1);
        var audioBtn = new Button { Text = "Browse..." }; layout.Controls.Add(audioBtn, 1, 1);
        audioBtn.Click += (s, e) => { audioSource = PickFile(); };

        layout.Controls.Add(new Label { Text = "Music Source:" }, 0, 2);
        var musicBtn = new Button { Text = "Browse..." }; layout.Controls.Add(musicBtn, 1, 2);
        musicBtn.Click += (s, e) => { musicSource = PickFile(); };

        layout.Controls.Add(new Label { Text = "Photo Source:" }, 0, 3);
        var photoBtn = new Button { Text = "Browse..." }; layout.Controls.Add(photoBtn, 1, 3);
        photoBtn.Click += (s, e) => { photoSource = PickFile(); };

        layout.Controls.Add(new Label { Text = "GIF Source:" }, 0, 4);
        var gifBtn = new Button { Text = "Browse..." }; layout.Controls.Add(gifBtn, 1, 4);
        gifBtn.Click += (s, e) => { gifSource = PickFile(); };

        layout.Controls.Add(new Label { Text = "MLG Source:" }, 0, 5);
        var mlgBtn = new Button { Text = "Browse..." }; layout.Controls.Add(mlgBtn, 1, 5);
        mlgBtn.Click += (s, e) => { mlgSource = PickFile(); };

        // Checkboxes
        var cbEarRape = new CheckBox { Text = "Ear Rape" }; layout.Controls.Add(cbEarRape, 0, 6);
        var cbStutter = new CheckBox { Text = "Stutter Loop" }; layout.Controls.Add(cbStutter, 0, 7);
        var cbSentMix = new CheckBox { Text = "Sentence Mixing" }; layout.Controls.Add(cbSentMix, 0, 8);
        var cbSpad = new CheckBox { Text = "Spadinner" }; layout.Controls.Add(cbSpad, 0, 9);
        var cbSpecEff = new CheckBox { Text = "Special Effect" }; layout.Controls.Add(cbSpecEff, 0, 10);
        var cbYtpHelper = new CheckBox { Text = "YTP Helper" }; layout.Controls.Add(cbYtpHelper, 0, 11);

        var genBtn = new Button { Text = "Generate" };
        layout.Controls.Add(genBtn, 0, 12);

        genBtn.Click += (sender, e) =>
        {
            earRape = cbEarRape.Checked;
            stutterLoop = cbStutter.Checked;
            sentenceMixing = cbSentMix.Checked;
            spadinner = cbSpad.Checked;
            specialEffect = cbSpecEff.Checked;
            ytpHelper = cbYtpHelper.Checked;

            // You would call your VEGAS manipulation logic here
            // Example: Insert the selected video track, apply 'ear rape' effects, etc.
            // For now, display a summary
            Summary();
        };
        this.AutoSize = true;
    }

    string PickFile()
    {
        var dlg = new OpenFileDialog();
        dlg.Filter = "All Files|*.*";
        if (dlg.ShowDialog() == DialogResult.OK)
            return dlg.FileName;
        return null;
    }

    void Summary()
    {
        string summary = $"Video: {videoSource}\nAudio: {audioSource}\nMusic: {musicSource}\nPhoto: {photoSource}\nGIF: {gifSource}\nMLG: {mlgSource}\n";
        summary += $"Ear Rape: {earRape}\nStutter Loop: {stutterLoop}\nSentence Mixing: {sentenceMixing}\nSpadinner: {spadinner}\nSpecial Effect: {specialEffect}\nYTP Helper: {ytpHelper}";
        MessageBox.Show(summary, "YTP Style 2012 Settings");
    }
}