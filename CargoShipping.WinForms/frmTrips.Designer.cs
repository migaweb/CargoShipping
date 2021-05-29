
namespace CargoShipping.WinForms
{
  partial class frmTrips
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
      this.label1 = new System.Windows.Forms.Label();
      this.txtTripNumber = new System.Windows.Forms.TextBox();
      this.btnSearchByTripNumber = new System.Windows.Forms.Button();
      this.gvTrips = new System.Windows.Forms.DataGridView();
      this.listPorts = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSearchByPort = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.gvTrips)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(2, 61);
      this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(92, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Trip Number";
      // 
      // txtTripNumber
      // 
      this.txtTripNumber.Location = new System.Drawing.Point(99, 61);
      this.txtTripNumber.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
      this.txtTripNumber.Name = "txtTripNumber";
      this.txtTripNumber.Size = new System.Drawing.Size(193, 27);
      this.txtTripNumber.TabIndex = 1;
      // 
      // btnSearchByTripNumber
      // 
      this.btnSearchByTripNumber.Location = new System.Drawing.Point(293, 61);
      this.btnSearchByTripNumber.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
      this.btnSearchByTripNumber.Name = "btnSearchByTripNumber";
      this.btnSearchByTripNumber.Size = new System.Drawing.Size(82, 23);
      this.btnSearchByTripNumber.TabIndex = 2;
      this.btnSearchByTripNumber.Text = "Search";
      this.btnSearchByTripNumber.UseVisualStyleBackColor = true;
      this.btnSearchByTripNumber.Click += new System.EventHandler(this.btnSearchByTripNumber_Click);
      // 
      // gvTrips
      // 
      this.gvTrips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvTrips.Location = new System.Drawing.Point(6, 107);
      this.gvTrips.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
      this.gvTrips.Name = "gvTrips";
      this.gvTrips.RowHeadersWidth = 102;
      this.gvTrips.RowTemplate.Height = 49;
      this.gvTrips.Size = new System.Drawing.Size(1331, 398);
      this.gvTrips.TabIndex = 3;
      this.gvTrips.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gvTrips_CellPainting);
      this.gvTrips.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvTrips_DataBindingComplete);
      // 
      // listPorts
      // 
      this.listPorts.FormattingEnabled = true;
      this.listPorts.Location = new System.Drawing.Point(99, 24);
      this.listPorts.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
      this.listPorts.Name = "listPorts";
      this.listPorts.Size = new System.Drawing.Size(193, 28);
      this.listPorts.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(2, 24);
      this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 20);
      this.label2.TabIndex = 0;
      this.label2.Text = "Ports";
      // 
      // btnSearchByPort
      // 
      this.btnSearchByPort.Location = new System.Drawing.Point(293, 25);
      this.btnSearchByPort.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
      this.btnSearchByPort.Name = "btnSearchByPort";
      this.btnSearchByPort.Size = new System.Drawing.Size(82, 23);
      this.btnSearchByPort.TabIndex = 5;
      this.btnSearchByPort.Text = "Search";
      this.btnSearchByPort.UseVisualStyleBackColor = true;
      this.btnSearchByPort.Click += new System.EventHandler(this.btnSearchByPort_Click);
      // 
      // frmTrips
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1347, 515);
      this.Controls.Add(this.btnSearchByPort);
      this.Controls.Add(this.listPorts);
      this.Controls.Add(this.gvTrips);
      this.Controls.Add(this.btnSearchByTripNumber);
      this.Controls.Add(this.txtTripNumber);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
      this.Name = "frmTrips";
      this.Text = "Trips";
      this.Load += new System.EventHandler(this.frmTrips_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gvTrips)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtTripNumber;
    private System.Windows.Forms.Button btnSearchByTripNumber;
    private System.Windows.Forms.DataGridView gvTrips;
    private System.Windows.Forms.ComboBox listPorts;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSearchByPort;
  }
}

