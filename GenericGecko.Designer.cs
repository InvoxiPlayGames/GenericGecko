namespace GenericGecko
{
    partial class GenericGecko
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            consoleHolder = new Panel();
            console = new TextBox();
            buttonHolder = new Panel();
            statusText = new Label();
            bmButton = new Button();
            wlButton = new Button();
            progress = new ProgressBar();
            openFileDialog1 = new OpenFileDialog();
            consoleHolder.SuspendLayout();
            buttonHolder.SuspendLayout();
            SuspendLayout();
            // 
            // consoleHolder
            // 
            consoleHolder.BackColor = SystemColors.WindowText;
            consoleHolder.Controls.Add(console);
            consoleHolder.Dock = DockStyle.Fill;
            consoleHolder.ForeColor = SystemColors.Window;
            consoleHolder.Location = new Point(0, 0);
            consoleHolder.Name = "consoleHolder";
            consoleHolder.Size = new Size(655, 354);
            consoleHolder.TabIndex = 0;
            // 
            // console
            // 
            console.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            console.BackColor = SystemColors.WindowText;
            console.BorderStyle = BorderStyle.None;
            console.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point);
            console.ForeColor = SystemColors.Window;
            console.Location = new Point(12, 12);
            console.Multiline = true;
            console.Name = "console";
            console.ReadOnly = true;
            console.ScrollBars = ScrollBars.Vertical;
            console.Size = new Size(631, 336);
            console.TabIndex = 0;
            // 
            // buttonHolder
            // 
            buttonHolder.BackColor = SystemColors.ControlDarkDark;
            buttonHolder.Controls.Add(statusText);
            buttonHolder.Controls.Add(bmButton);
            buttonHolder.Controls.Add(wlButton);
            buttonHolder.Controls.Add(progress);
            buttonHolder.Dock = DockStyle.Bottom;
            buttonHolder.ForeColor = SystemColors.Control;
            buttonHolder.Location = new Point(0, 354);
            buttonHolder.Name = "buttonHolder";
            buttonHolder.Size = new Size(655, 47);
            buttonHolder.TabIndex = 1;
            // 
            // statusText
            // 
            statusText.AutoSize = true;
            statusText.Location = new Point(12, 16);
            statusText.Name = "statusText";
            statusText.Size = new Size(128, 15);
            statusText.TabIndex = 2;
            statusText.Text = "Connecting to Gecko...";
            // 
            // bmButton
            // 
            bmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bmButton.Enabled = false;
            bmButton.FlatStyle = FlatStyle.Popup;
            bmButton.Location = new Point(487, 12);
            bmButton.Name = "bmButton";
            bmButton.Size = new Size(75, 23);
            bmButton.TabIndex = 1;
            bmButton.Text = "BootMii";
            bmButton.UseVisualStyleBackColor = true;
            bmButton.Visible = false;
            bmButton.Click += bmButton_Click;
            // 
            // wlButton
            // 
            wlButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            wlButton.Enabled = false;
            wlButton.FlatStyle = FlatStyle.Popup;
            wlButton.Location = new Point(568, 12);
            wlButton.Name = "wlButton";
            wlButton.Size = new Size(75, 23);
            wlButton.TabIndex = 0;
            wlButton.Text = "Wiiload";
            wlButton.UseVisualStyleBackColor = true;
            wlButton.Click += wlButton_Click;
            // 
            // progress
            // 
            progress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            progress.Location = new Point(487, 12);
            progress.Name = "progress";
            progress.Size = new Size(156, 23);
            progress.TabIndex = 3;
            progress.Visible = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "DOL/ELF Executables|*.dol;*.elf|BIN Files|*.bin|All files|*";
            openFileDialog1.Title = "Select file to transfer";
            // 
            // GenericGecko
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 401);
            Controls.Add(consoleHolder);
            Controls.Add(buttonHolder);
            Name = "GenericGecko";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GenericGecko";
            Load += GenericGecko_Load;
            consoleHolder.ResumeLayout(false);
            consoleHolder.PerformLayout();
            buttonHolder.ResumeLayout(false);
            buttonHolder.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel consoleHolder;
        private TextBox console;
        private Panel buttonHolder;
        private Label statusText;
        private Button bmButton;
        private Button wlButton;
        private ProgressBar progress;
        private OpenFileDialog openFileDialog1;
    }
}