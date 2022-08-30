
namespace FormUDPHolePunching
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblNetType = new System.Windows.Forms.Label();
            this.LblLocalEndPoint = new System.Windows.Forms.Label();
            this.LblRemoteEndPoint = new System.Windows.Forms.Label();
            this.BtnStartSender = new System.Windows.Forms.Button();
            this.TxtbxConnectionLocalIPValue = new System.Windows.Forms.TextBox();
            this.NudConnectionLocalPortValue = new System.Windows.Forms.NumericUpDown();
            this.NudConnectionRemotePortValue = new System.Windows.Forms.NumericUpDown();
            this.TxtbxConnectionRemoteIPValue = new System.Windows.Forms.TextBox();
            this.LblConnectionLocalEndPoint = new System.Windows.Forms.Label();
            this.LblConnectionRemoteEndPoint = new System.Windows.Forms.Label();
            this.TxtbxNetTypeValue = new System.Windows.Forms.TextBox();
            this.TxtbxLocalEndPointValue = new System.Windows.Forms.TextBox();
            this.TxtbxRemoteEndPointValue = new System.Windows.Forms.TextBox();
            this.BtnStopSender = new System.Windows.Forms.Button();
            this.TxtbxLog = new System.Windows.Forms.TextBox();
            this.BtnStartListener = new System.Windows.Forms.Button();
            this.BtnStopListener = new System.Windows.Forms.Button();
            this.LblListenerEndPoint = new System.Windows.Forms.Label();
            this.NudListenerPort = new System.Windows.Forms.NumericUpDown();
            this.TxtbxListenerIP = new System.Windows.Forms.TextBox();
            this.TxtbxScanRemoteIPValue = new System.Windows.Forms.TextBox();
            this.BtnStartScan = new System.Windows.Forms.Button();
            this.BtnStopScan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudConnectionLocalPortValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudConnectionRemotePortValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudListenerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // LblNetType
            // 
            this.LblNetType.AutoSize = true;
            this.LblNetType.Location = new System.Drawing.Point(12, 9);
            this.LblNetType.Name = "LblNetType";
            this.LblNetType.Size = new System.Drawing.Size(54, 13);
            this.LblNetType.TabIndex = 0;
            this.LblNetType.Text = "Net Type:";
            // 
            // LblLocalEndPoint
            // 
            this.LblLocalEndPoint.AutoSize = true;
            this.LblLocalEndPoint.Location = new System.Drawing.Point(12, 35);
            this.LblLocalEndPoint.Name = "LblLocalEndPoint";
            this.LblLocalEndPoint.Size = new System.Drawing.Size(82, 13);
            this.LblLocalEndPoint.TabIndex = 2;
            this.LblLocalEndPoint.Text = "Local EndPoint:";
            // 
            // LblRemoteEndPoint
            // 
            this.LblRemoteEndPoint.AutoSize = true;
            this.LblRemoteEndPoint.Location = new System.Drawing.Point(12, 62);
            this.LblRemoteEndPoint.Name = "LblRemoteEndPoint";
            this.LblRemoteEndPoint.Size = new System.Drawing.Size(93, 13);
            this.LblRemoteEndPoint.TabIndex = 4;
            this.LblRemoteEndPoint.Text = "Remote EndPoint:";
            // 
            // BtnStartSender
            // 
            this.BtnStartSender.Location = new System.Drawing.Point(12, 239);
            this.BtnStartSender.Name = "BtnStartSender";
            this.BtnStartSender.Size = new System.Drawing.Size(163, 37);
            this.BtnStartSender.TabIndex = 6;
            this.BtnStartSender.Text = "Start Sender";
            this.BtnStartSender.UseVisualStyleBackColor = true;
            this.BtnStartSender.Click += new System.EventHandler(this.BtnStartConnection_Click);
            // 
            // TxtbxConnectionLocalIPValue
            // 
            this.TxtbxConnectionLocalIPValue.Location = new System.Drawing.Point(15, 174);
            this.TxtbxConnectionLocalIPValue.Name = "TxtbxConnectionLocalIPValue";
            this.TxtbxConnectionLocalIPValue.Size = new System.Drawing.Size(163, 20);
            this.TxtbxConnectionLocalIPValue.TabIndex = 7;
            // 
            // NudConnectionLocalPortValue
            // 
            this.NudConnectionLocalPortValue.Location = new System.Drawing.Point(181, 174);
            this.NudConnectionLocalPortValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NudConnectionLocalPortValue.Name = "NudConnectionLocalPortValue";
            this.NudConnectionLocalPortValue.Size = new System.Drawing.Size(69, 20);
            this.NudConnectionLocalPortValue.TabIndex = 9;
            // 
            // NudConnectionRemotePortValue
            // 
            this.NudConnectionRemotePortValue.Location = new System.Drawing.Point(181, 213);
            this.NudConnectionRemotePortValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NudConnectionRemotePortValue.Name = "NudConnectionRemotePortValue";
            this.NudConnectionRemotePortValue.Size = new System.Drawing.Size(69, 20);
            this.NudConnectionRemotePortValue.TabIndex = 11;
            // 
            // TxtbxConnectionRemoteIPValue
            // 
            this.TxtbxConnectionRemoteIPValue.Location = new System.Drawing.Point(12, 213);
            this.TxtbxConnectionRemoteIPValue.Name = "TxtbxConnectionRemoteIPValue";
            this.TxtbxConnectionRemoteIPValue.Size = new System.Drawing.Size(163, 20);
            this.TxtbxConnectionRemoteIPValue.TabIndex = 10;
            // 
            // LblConnectionLocalEndPoint
            // 
            this.LblConnectionLocalEndPoint.AutoSize = true;
            this.LblConnectionLocalEndPoint.Location = new System.Drawing.Point(12, 158);
            this.LblConnectionLocalEndPoint.Name = "LblConnectionLocalEndPoint";
            this.LblConnectionLocalEndPoint.Size = new System.Drawing.Size(82, 13);
            this.LblConnectionLocalEndPoint.TabIndex = 12;
            this.LblConnectionLocalEndPoint.Text = "Local EndPoint:";
            // 
            // LblConnectionRemoteEndPoint
            // 
            this.LblConnectionRemoteEndPoint.AutoSize = true;
            this.LblConnectionRemoteEndPoint.Location = new System.Drawing.Point(12, 197);
            this.LblConnectionRemoteEndPoint.Name = "LblConnectionRemoteEndPoint";
            this.LblConnectionRemoteEndPoint.Size = new System.Drawing.Size(93, 13);
            this.LblConnectionRemoteEndPoint.TabIndex = 13;
            this.LblConnectionRemoteEndPoint.Text = "Remote EndPoint:";
            // 
            // TxtbxNetTypeValue
            // 
            this.TxtbxNetTypeValue.Location = new System.Drawing.Point(72, 6);
            this.TxtbxNetTypeValue.Name = "TxtbxNetTypeValue";
            this.TxtbxNetTypeValue.ReadOnly = true;
            this.TxtbxNetTypeValue.Size = new System.Drawing.Size(181, 20);
            this.TxtbxNetTypeValue.TabIndex = 14;
            // 
            // TxtbxLocalEndPointValue
            // 
            this.TxtbxLocalEndPointValue.Location = new System.Drawing.Point(100, 32);
            this.TxtbxLocalEndPointValue.Name = "TxtbxLocalEndPointValue";
            this.TxtbxLocalEndPointValue.ReadOnly = true;
            this.TxtbxLocalEndPointValue.Size = new System.Drawing.Size(153, 20);
            this.TxtbxLocalEndPointValue.TabIndex = 15;
            // 
            // TxtbxRemoteEndPointValue
            // 
            this.TxtbxRemoteEndPointValue.Location = new System.Drawing.Point(110, 59);
            this.TxtbxRemoteEndPointValue.Name = "TxtbxRemoteEndPointValue";
            this.TxtbxRemoteEndPointValue.ReadOnly = true;
            this.TxtbxRemoteEndPointValue.Size = new System.Drawing.Size(143, 20);
            this.TxtbxRemoteEndPointValue.TabIndex = 16;
            // 
            // BtnStopSender
            // 
            this.BtnStopSender.Location = new System.Drawing.Point(181, 240);
            this.BtnStopSender.Name = "BtnStopSender";
            this.BtnStopSender.Size = new System.Drawing.Size(69, 36);
            this.BtnStopSender.TabIndex = 17;
            this.BtnStopSender.Text = "Stop";
            this.BtnStopSender.UseVisualStyleBackColor = true;
            this.BtnStopSender.Click += new System.EventHandler(this.BtnStopConnection_Click);
            // 
            // TxtbxLog
            // 
            this.TxtbxLog.Location = new System.Drawing.Point(260, 6);
            this.TxtbxLog.Multiline = true;
            this.TxtbxLog.Name = "TxtbxLog";
            this.TxtbxLog.Size = new System.Drawing.Size(366, 520);
            this.TxtbxLog.TabIndex = 18;
            // 
            // BtnStartListener
            // 
            this.BtnStartListener.Location = new System.Drawing.Point(12, 489);
            this.BtnStartListener.Name = "BtnStartListener";
            this.BtnStartListener.Size = new System.Drawing.Size(163, 37);
            this.BtnStartListener.TabIndex = 19;
            this.BtnStartListener.Text = "Start Listener";
            this.BtnStartListener.UseVisualStyleBackColor = true;
            this.BtnStartListener.Click += new System.EventHandler(this.BtnStartListener_Click);
            // 
            // BtnStopListener
            // 
            this.BtnStopListener.Location = new System.Drawing.Point(181, 489);
            this.BtnStopListener.Name = "BtnStopListener";
            this.BtnStopListener.Size = new System.Drawing.Size(69, 36);
            this.BtnStopListener.TabIndex = 20;
            this.BtnStopListener.Text = "Stop";
            this.BtnStopListener.UseVisualStyleBackColor = true;
            this.BtnStopListener.Click += new System.EventHandler(this.BtnStopListener_Click);
            // 
            // LblListenerEndPoint
            // 
            this.LblListenerEndPoint.AutoSize = true;
            this.LblListenerEndPoint.Location = new System.Drawing.Point(12, 447);
            this.LblListenerEndPoint.Name = "LblListenerEndPoint";
            this.LblListenerEndPoint.Size = new System.Drawing.Size(93, 13);
            this.LblListenerEndPoint.TabIndex = 23;
            this.LblListenerEndPoint.Text = "Listener EndPoint:";
            // 
            // NudListenerPort
            // 
            this.NudListenerPort.Location = new System.Drawing.Point(181, 463);
            this.NudListenerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NudListenerPort.Name = "NudListenerPort";
            this.NudListenerPort.Size = new System.Drawing.Size(69, 20);
            this.NudListenerPort.TabIndex = 22;
            // 
            // TxtbxListenerIP
            // 
            this.TxtbxListenerIP.Location = new System.Drawing.Point(15, 463);
            this.TxtbxListenerIP.Name = "TxtbxListenerIP";
            this.TxtbxListenerIP.Size = new System.Drawing.Size(163, 20);
            this.TxtbxListenerIP.TabIndex = 21;
            // 
            // TxtbxScanRemoteIPValue
            // 
            this.TxtbxScanRemoteIPValue.Location = new System.Drawing.Point(12, 353);
            this.TxtbxScanRemoteIPValue.Name = "TxtbxScanRemoteIPValue";
            this.TxtbxScanRemoteIPValue.Size = new System.Drawing.Size(238, 20);
            this.TxtbxScanRemoteIPValue.TabIndex = 25;
            // 
            // BtnStartScan
            // 
            this.BtnStartScan.Location = new System.Drawing.Point(12, 379);
            this.BtnStartScan.Name = "BtnStartScan";
            this.BtnStartScan.Size = new System.Drawing.Size(163, 37);
            this.BtnStartScan.TabIndex = 24;
            this.BtnStartScan.Text = "Start Sender";
            this.BtnStartScan.UseVisualStyleBackColor = true;
            this.BtnStartScan.Click += new System.EventHandler(this.BtnStartScan_Click);
            // 
            // BtnStopScan
            // 
            this.BtnStopScan.Location = new System.Drawing.Point(181, 379);
            this.BtnStopScan.Name = "BtnStopScan";
            this.BtnStopScan.Size = new System.Drawing.Size(69, 36);
            this.BtnStopScan.TabIndex = 26;
            this.BtnStopScan.Text = "Stop";
            this.BtnStopScan.UseVisualStyleBackColor = true;
            this.BtnStopScan.Click += new System.EventHandler(this.BtnStopScan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 538);
            this.Controls.Add(this.BtnStopScan);
            this.Controls.Add(this.TxtbxScanRemoteIPValue);
            this.Controls.Add(this.BtnStartScan);
            this.Controls.Add(this.LblListenerEndPoint);
            this.Controls.Add(this.NudListenerPort);
            this.Controls.Add(this.TxtbxListenerIP);
            this.Controls.Add(this.BtnStopListener);
            this.Controls.Add(this.BtnStartListener);
            this.Controls.Add(this.TxtbxLog);
            this.Controls.Add(this.BtnStopSender);
            this.Controls.Add(this.TxtbxRemoteEndPointValue);
            this.Controls.Add(this.TxtbxLocalEndPointValue);
            this.Controls.Add(this.TxtbxNetTypeValue);
            this.Controls.Add(this.LblConnectionRemoteEndPoint);
            this.Controls.Add(this.LblConnectionLocalEndPoint);
            this.Controls.Add(this.NudConnectionRemotePortValue);
            this.Controls.Add(this.TxtbxConnectionRemoteIPValue);
            this.Controls.Add(this.NudConnectionLocalPortValue);
            this.Controls.Add(this.TxtbxConnectionLocalIPValue);
            this.Controls.Add(this.BtnStartSender);
            this.Controls.Add(this.LblRemoteEndPoint);
            this.Controls.Add(this.LblLocalEndPoint);
            this.Controls.Add(this.LblNetType);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NudConnectionLocalPortValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudConnectionRemotePortValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudListenerPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNetType;
        private System.Windows.Forms.Label LblLocalEndPoint;
        private System.Windows.Forms.Label LblRemoteEndPoint;
        private System.Windows.Forms.Button BtnStartSender;
        private System.Windows.Forms.TextBox TxtbxConnectionLocalIPValue;
        private System.Windows.Forms.NumericUpDown NudConnectionLocalPortValue;
        private System.Windows.Forms.NumericUpDown NudConnectionRemotePortValue;
        private System.Windows.Forms.TextBox TxtbxConnectionRemoteIPValue;
        private System.Windows.Forms.Label LblConnectionLocalEndPoint;
        private System.Windows.Forms.Label LblConnectionRemoteEndPoint;
        private System.Windows.Forms.TextBox TxtbxNetTypeValue;
        private System.Windows.Forms.TextBox TxtbxLocalEndPointValue;
        private System.Windows.Forms.TextBox TxtbxRemoteEndPointValue;
        private System.Windows.Forms.Button BtnStopSender;
        private System.Windows.Forms.TextBox TxtbxLog;
        private System.Windows.Forms.Button BtnStartListener;
        private System.Windows.Forms.Button BtnStopListener;
        private System.Windows.Forms.Label LblListenerEndPoint;
        private System.Windows.Forms.NumericUpDown NudListenerPort;
        private System.Windows.Forms.TextBox TxtbxListenerIP;
        private System.Windows.Forms.TextBox TxtbxScanRemoteIPValue;
        private System.Windows.Forms.Button BtnStartScan;
        private System.Windows.Forms.Button BtnStopScan;
    }
}

