namespace WinForm.MoveControl.Demo.Content
{
    partial class FrmContent
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("button");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("label");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("number");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("控件", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.uiNavMenu1 = new Sunny.UI.UINavMenu();
            this.SuspendLayout();
            // 
            // uiNavMenu1
            // 
            this.uiNavMenu1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uiNavMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNavMenu1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.uiNavMenu1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.FullRowSelect = true;
            this.uiNavMenu1.HotTracking = true;
            this.uiNavMenu1.ItemHeight = 30;
            this.uiNavMenu1.Location = new System.Drawing.Point(0, 0);
            this.uiNavMenu1.Name = "uiNavMenu1";
            treeNode1.ImageIndex = 61451;
            treeNode1.Name = "button";
            treeNode1.Text = "button";
            treeNode2.Name = "label";
            treeNode2.Text = "label";
            treeNode3.Name = "number";
            treeNode3.Text = "number";
            treeNode4.Name = "控件";
            treeNode4.Text = "控件";
            this.uiNavMenu1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.uiNavMenu1.ShowLines = false;
            this.uiNavMenu1.ShowPlusMinus = false;
            this.uiNavMenu1.ShowRootLines = false;
            this.uiNavMenu1.Size = new System.Drawing.Size(143, 450);
            this.uiNavMenu1.TabIndex = 5;
            this.uiNavMenu1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // FrmContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(143, 450);
            this.Controls.Add(this.uiNavMenu1);
            this.Name = "FrmContent";
            this.Text = "FrmContent";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UINavMenu uiNavMenu1;
    }
}