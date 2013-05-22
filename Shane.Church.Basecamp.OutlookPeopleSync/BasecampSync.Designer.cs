namespace Shane.Church.Basecamp.OutlookPeopleSync
{
	partial class BasecampSync
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasecampSync));
			this.progressBarSync = new System.Windows.Forms.ProgressBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelProgress = new System.Windows.Forms.Label();
			this.backgroundWorkerSync = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressBarSync
			// 
			this.progressBarSync.Dock = System.Windows.Forms.DockStyle.Top;
			this.progressBarSync.Location = new System.Drawing.Point(0, 40);
			this.progressBarSync.Name = "progressBarSync";
			this.progressBarSync.Size = new System.Drawing.Size(380, 23);
			this.progressBarSync.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = global::Shane.Church.Basecamp.OutlookPeopleSync.Properties.Resources.update2_00;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(380, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 81);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(380, 51);
			this.panel1.TabIndex = 2;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(293, 21);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelProgress
			// 
			this.labelProgress.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelProgress.Location = new System.Drawing.Point(0, 63);
			this.labelProgress.Name = "labelProgress";
			this.labelProgress.Size = new System.Drawing.Size(380, 18);
			this.labelProgress.TabIndex = 3;
			this.labelProgress.Text = "Processing...";
			this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// backgroundWorkerSync
			// 
			this.backgroundWorkerSync.WorkerReportsProgress = true;
			this.backgroundWorkerSync.WorkerSupportsCancellation = true;
			this.backgroundWorkerSync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSync_DoWork);
			this.backgroundWorkerSync.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSync_ProgressChanged);
			this.backgroundWorkerSync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSync_RunWorkerCompleted);
			// 
			// BasecampSync
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(380, 132);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.labelProgress);
			this.Controls.Add(this.progressBarSync);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BasecampSync";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Basecamp Sync Progress";
			this.Load += new System.EventHandler(this.BasecampSync_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBarSync;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelProgress;
		private System.ComponentModel.BackgroundWorker backgroundWorkerSync;
	}
}