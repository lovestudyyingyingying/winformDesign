namespace WinForm.MoveControl.Demo.Content
{
    partial class FrmToolBar
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVertialSame = new System.Windows.Forms.Button();
            this.btnSameMiddle = new System.Windows.Forms.Button();
            this.btnSameMax = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnVertialSame);
            this.panel2.Controls.Add(this.btnSameMiddle);
            this.panel2.Controls.Add(this.btnSameMax);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 28);
            this.panel2.TabIndex = 9;
            // 
            // btnVertialSame
            // 
            this.btnVertialSame.Location = new System.Drawing.Point(49, 1);
            this.btnVertialSame.Name = "btnVertialSame";
            this.btnVertialSame.Size = new System.Drawing.Size(85, 23);
            this.btnVertialSame.TabIndex = 7;
            this.btnVertialSame.Text = "中心垂直对齐";
            this.btnVertialSame.UseVisualStyleBackColor = true;
            // 
            // btnSameMiddle
            // 
            this.btnSameMiddle.Location = new System.Drawing.Point(140, 1);
            this.btnSameMiddle.Name = "btnSameMiddle";
            this.btnSameMiddle.Size = new System.Drawing.Size(85, 23);
            this.btnSameMiddle.TabIndex = 7;
            this.btnSameMiddle.Text = "中心水平对齐";
            this.btnSameMiddle.UseVisualStyleBackColor = true;
            // 
            // btnSameMax
            // 
            this.btnSameMax.Location = new System.Drawing.Point(231, 1);
            this.btnSameMax.Name = "btnSameMax";
            this.btnSameMax.Size = new System.Drawing.Size(75, 23);
            this.btnSameMax.TabIndex = 7;
            this.btnSameMax.Text = "等大";
            this.btnSameMax.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(393, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "启用";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(312, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FrmToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 28);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmToolBar";
            this.TabText = "FrmToolBar";
            this.Text = "FrmToolBar";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVertialSame;
        private System.Windows.Forms.Button btnSameMiddle;
        private System.Windows.Forms.Button btnSameMax;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}