namespace XtremePharmacyManager.Properties.DataSources
{
    partial class frmImageBinConverter
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
            this.lblLoadedImage = new System.Windows.Forms.Label();
            this.txtImageBytes = new System.Windows.Forms.TextBox();
            this.lblImageBytes = new System.Windows.Forms.Label();
            this.btnConvertImageToBinary = new System.Windows.Forms.Button();
            this.buttonConvertBinaryToImage = new System.Windows.Forms.Button();
            this.pbLoadedImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoadedImage
            // 
            this.lblLoadedImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoadedImage.AutoSize = true;
            this.lblLoadedImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadedImage.Location = new System.Drawing.Point(12, 45);
            this.lblLoadedImage.Name = "lblLoadedImage";
            this.lblLoadedImage.Size = new System.Drawing.Size(111, 16);
            this.lblLoadedImage.TabIndex = 3;
            this.lblLoadedImage.Text = "Loaded Image:";
            // 
            // txtImageBytes
            // 
            this.txtImageBytes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageBytes.Location = new System.Drawing.Point(331, 77);
            this.txtImageBytes.Multiline = true;
            this.txtImageBytes.Name = "txtImageBytes";
            this.txtImageBytes.Size = new System.Drawing.Size(230, 209);
            this.txtImageBytes.TabIndex = 34;
            // 
            // lblImageBytes
            // 
            this.lblImageBytes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageBytes.AutoSize = true;
            this.lblImageBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageBytes.Location = new System.Drawing.Point(328, 45);
            this.lblImageBytes.Name = "lblImageBytes";
            this.lblImageBytes.Size = new System.Drawing.Size(97, 16);
            this.lblImageBytes.TabIndex = 33;
            this.lblImageBytes.Text = "Image Bytes:";
            // 
            // btnConvertImageToBinary
            // 
            this.btnConvertImageToBinary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertImageToBinary.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertImageToBinary.Location = new System.Drawing.Point(331, 321);
            this.btnConvertImageToBinary.Name = "btnConvertImageToBinary";
            this.btnConvertImageToBinary.Size = new System.Drawing.Size(228, 47);
            this.btnConvertImageToBinary.TabIndex = 37;
            this.btnConvertImageToBinary.Text = "CONVERT IMAGE TO BINARY";
            this.btnConvertImageToBinary.UseVisualStyleBackColor = true;
            this.btnConvertImageToBinary.Click += new System.EventHandler(this.btnConvertImageToBinary_Click);
            // 
            // buttonConvertBinaryToImage
            // 
            this.buttonConvertBinaryToImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConvertBinaryToImage.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConvertBinaryToImage.Location = new System.Drawing.Point(331, 374);
            this.buttonConvertBinaryToImage.Name = "buttonConvertBinaryToImage";
            this.buttonConvertBinaryToImage.Size = new System.Drawing.Size(228, 47);
            this.buttonConvertBinaryToImage.TabIndex = 38;
            this.buttonConvertBinaryToImage.Text = "CONVERT BINARY TO IMAGE";
            this.buttonConvertBinaryToImage.UseVisualStyleBackColor = true;
            this.buttonConvertBinaryToImage.Click += new System.EventHandler(this.buttonConvertBinaryToImage_Click);
            // 
            // pbLoadedImage
            // 
            this.pbLoadedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbLoadedImage.Location = new System.Drawing.Point(15, 77);
            this.pbLoadedImage.Name = "pbLoadedImage";
            this.pbLoadedImage.Size = new System.Drawing.Size(211, 209);
            this.pbLoadedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadedImage.TabIndex = 39;
            this.pbLoadedImage.TabStop = false;
            // 
            // frmImageBinConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 450);
            this.Controls.Add(this.pbLoadedImage);
            this.Controls.Add(this.buttonConvertBinaryToImage);
            this.Controls.Add(this.btnConvertImageToBinary);
            this.Controls.Add(this.txtImageBytes);
            this.Controls.Add(this.lblImageBytes);
            this.Controls.Add(this.lblLoadedImage);
            this.MaximizeBox = false;
            this.Name = "frmImageBinConverter";
            this.Text = "Convert Image To Binary and Vice Versa";
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLoadedImage;
        private System.Windows.Forms.TextBox txtImageBytes;
        private System.Windows.Forms.Label lblImageBytes;
        private System.Windows.Forms.Button btnConvertImageToBinary;
        private System.Windows.Forms.Button buttonConvertBinaryToImage;
        private System.Windows.Forms.PictureBox pbLoadedImage;
    }
}