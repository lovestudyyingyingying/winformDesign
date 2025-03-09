
namespace WinForm.MoveControl.Demo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVertialSame = new Sunny.UI.UIImageButton();
            this.btnSameMiddle = new Sunny.UI.UIImageButton();
            this.btnSameMax = new Sunny.UI.UIImageButton();
            this.btnHorSort = new Sunny.UI.UIImageButton();
            this.btnMiddleDist = new Sunny.UI.UIImageButton();
            this.btnLock = new Sunny.UI.UIImageButton();
            this.btnSave = new Sunny.UI.UIImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiNavMenu1 = new Sunny.UI.UINavMenu();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVertialSame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSameMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSameMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHorSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMiddleDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnVertialSame);
            this.panel2.Controls.Add(this.btnSameMiddle);
            this.panel2.Controls.Add(this.btnSameMax);
            this.panel2.Controls.Add(this.btnHorSort);
            this.panel2.Controls.Add(this.btnMiddleDist);
            this.panel2.Controls.Add(this.btnLock);
            this.panel2.Controls.Add(this.btnSave);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnVertialSame
            // 
            this.btnVertialSame.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnVertialSame, "btnVertialSame");
            this.btnVertialSame.Image = global::WinForm.MoveControl.Demo.Properties.Resources.水平居中对齐;
            this.btnVertialSame.Name = "btnVertialSame";
            this.btnVertialSame.TabStop = false;
            this.btnVertialSame.TagString = "居中对齐";
            this.btnVertialSame.Click += new System.EventHandler(this.btnVertialSame_Click);
            // 
            // btnSameMiddle
            // 
            this.btnSameMiddle.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSameMiddle, "btnSameMiddle");
            this.btnSameMiddle.Image = global::WinForm.MoveControl.Demo.Properties.Resources.水平对齐;
            this.btnSameMiddle.Name = "btnSameMiddle";
            this.btnSameMiddle.TabStop = false;
            this.btnSameMiddle.TagString = "中间对齐";
            this.btnSameMiddle.Click += new System.EventHandler(this.btnSameMiddle_Click);
            // 
            // btnSameMax
            // 
            this.btnSameMax.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSameMax, "btnSameMax");
            this.btnSameMax.Image = global::WinForm.MoveControl.Demo.Properties.Resources.等大__1_;
            this.btnSameMax.Name = "btnSameMax";
            this.btnSameMax.TabStop = false;
            this.btnSameMax.TagString = "使大小相同";
            this.btnSameMax.Click += new System.EventHandler(this.btnSameMax_Click);
            // 
            // btnHorSort
            // 
            this.btnHorSort.BackColor = System.Drawing.Color.Transparent;
            this.btnHorSort.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnHorSort, "btnHorSort");
            this.btnHorSort.Image = global::WinForm.MoveControl.Demo.Properties.Resources.水平均匀分布;
            this.btnHorSort.Name = "btnHorSort";
            this.btnHorSort.TabStop = false;
            this.btnHorSort.TagString = "水平均匀分布";
            this.btnHorSort.Click += new System.EventHandler(this.btnHorSort_Click);
            // 
            // btnMiddleDist
            // 
            this.btnMiddleDist.BackColor = System.Drawing.Color.Transparent;
            this.btnMiddleDist.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnMiddleDist, "btnMiddleDist");
            this.btnMiddleDist.Image = global::WinForm.MoveControl.Demo.Properties.Resources.居中均匀分布;
            this.btnMiddleDist.Name = "btnMiddleDist";
            this.btnMiddleDist.TabStop = false;
            this.btnMiddleDist.TagString = "居中均匀分布";
            this.btnMiddleDist.Click += new System.EventHandler(this.btnMiddleDist_Click);
            // 
            // btnLock
            // 
            this.btnLock.BackColor = System.Drawing.Color.Transparent;
            this.btnLock.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnLock, "btnLock");
            this.btnLock.Image = global::WinForm.MoveControl.Demo.Properties.Resources.禁用;
            this.btnLock.Name = "btnLock";
            this.btnLock.TabStop = false;
            this.btnLock.TagString = "启用";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::WinForm.MoveControl.Demo.Properties.Resources.save_3_fill;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabStop = false;
            this.btnSave.TagString = "保存";
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // uiNavMenu1
            // 
            this.uiNavMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(211)))));
            this.uiNavMenu1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.uiNavMenu1, "uiNavMenu1");
            this.uiNavMenu1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.uiNavMenu1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(211)))));
            this.uiNavMenu1.ForeColor = System.Drawing.Color.Black;
            this.uiNavMenu1.FullRowSelect = true;
            this.uiNavMenu1.HotTracking = true;
            this.uiNavMenu1.ItemHeight = 30;
            this.uiNavMenu1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavMenu1.Name = "uiNavMenu1";
            this.uiNavMenu1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("uiNavMenu1.Nodes")))});
            this.uiNavMenu1.ShowLines = false;
            this.uiNavMenu1.ShowPlusMinus = false;
            this.uiNavMenu1.ShowRootLines = false;
            this.uiNavMenu1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavMenu1.DoubleClick += new System.EventHandler(this.uiNavMenu1_DoubleClick);
            this.uiNavMenu1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiNavMenu1_MouseDown);
            this.uiNavMenu1.MouseLeave += new System.EventHandler(this.uiNavMenu1_MouseLeave);
            this.uiNavMenu1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiNavMenu1_MouseMove);
            this.uiNavMenu1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uiNavMenu1_MouseUp);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.propertyGrid1);
            resources.ApplyResources(this.uiPanel1, "uiPanel1");
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.propertyGrid1, "propertyGrid1");
            this.propertyGrid1.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(169)))), ((int)(((byte)(219)))));
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(169)))), ((int)(((byte)(219)))));
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.CloseAskString = "";
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.uiNavMenu1);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Opacity = 0.99D;
            this.ShowDragStretch = true;
            this.TitleFont = new System.Drawing.Font("Vladimir Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 856, 426);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnVertialSame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSameMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSameMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHorSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMiddleDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UIImageButton btnSameMax;
        private Sunny.UI.UIImageButton btnLock;
        private Sunny.UI.UIImageButton btnSave;
        private Sunny.UI.UIImageButton btnSameMiddle;
        private Sunny.UI.UIImageButton btnVertialSame;
        private Sunny.UI.UINavMenu uiNavMenu1;
        private Sunny.UI.UIImageButton btnMiddleDist;
        private Sunny.UI.UIImageButton btnHorSort;
        private Sunny.UI.UIPanel uiPanel1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}

