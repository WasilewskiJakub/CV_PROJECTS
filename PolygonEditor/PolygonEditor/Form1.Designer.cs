
namespace PolygonEditor
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DetailsBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.PolCouunt = new System.Windows.Forms.Label();
            this.CountPolyg = new System.Windows.Forms.Label();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.ColorButt = new System.Windows.Forms.Button();
            this.EdStyle = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Bresen = new System.Windows.Forms.RadioButton();
            this.Sysline = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.CreateAction = new System.Windows.Forms.RadioButton();
            this.EditAction = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveVert = new System.Windows.Forms.Button();
            this.ColorVert = new System.Windows.Forms.Button();
            this.EdgeBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.RemEdge = new System.Windows.Forms.Button();
            this.Splitedge = new System.Windows.Forms.Button();
            this.SaveLen = new System.Windows.Forms.Button();
            this.perpendicular = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.Selpolyg = new System.Windows.Forms.CheckBox();
            this.RemovePoly = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.FirstRow = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.DetailsBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.EdStyle.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.EdgeBox.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.FirstRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Canvas, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1199, 693);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(186, 3);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1010, 687);
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddVertex);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Moving);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisabelMoving);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.DetailsBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.EdStyle, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.EdgeBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(183, 693);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // DetailsBox
            // 
            this.DetailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailsBox.Controls.Add(this.tableLayoutPanel3);
            this.DetailsBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DetailsBox.Location = new System.Drawing.Point(0, 0);
            this.DetailsBox.Margin = new System.Windows.Forms.Padding(0);
            this.DetailsBox.Name = "DetailsBox";
            this.DetailsBox.Padding = new System.Windows.Forms.Padding(1);
            this.DetailsBox.Size = new System.Drawing.Size(183, 69);
            this.DetailsBox.TabIndex = 0;
            this.DetailsBox.TabStop = false;
            this.DetailsBox.Text = "Details";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.PolCouunt, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.CountPolyg, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.ColorLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.ColorButt, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(181, 52);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // PolCouunt
            // 
            this.PolCouunt.AutoSize = true;
            this.PolCouunt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PolCouunt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PolCouunt.Location = new System.Drawing.Point(3, 3);
            this.PolCouunt.Margin = new System.Windows.Forms.Padding(3);
            this.PolCouunt.Name = "PolCouunt";
            this.PolCouunt.Padding = new System.Windows.Forms.Padding(1);
            this.PolCouunt.Size = new System.Drawing.Size(120, 20);
            this.PolCouunt.TabIndex = 0;
            this.PolCouunt.Text = "Polygon Count:";
            this.PolCouunt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CountPolyg
            // 
            this.CountPolyg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CountPolyg.AutoSize = true;
            this.CountPolyg.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountPolyg.Location = new System.Drawing.Point(131, 5);
            this.CountPolyg.Margin = new System.Windows.Forms.Padding(5);
            this.CountPolyg.Name = "CountPolyg";
            this.CountPolyg.Size = new System.Drawing.Size(45, 16);
            this.CountPolyg.TabIndex = 1;
            this.CountPolyg.Text = "0";
            this.CountPolyg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorLabel
            // 
            this.ColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.ColorLabel.Location = new System.Drawing.Point(136, 31);
            this.ColorLabel.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(35, 16);
            this.ColorLabel.TabIndex = 2;
            this.ColorLabel.Click += new System.EventHandler(this.ColorLabel_Click);
            // 
            // ColorButt
            // 
            this.ColorButt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorButt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ColorButt.Location = new System.Drawing.Point(0, 26);
            this.ColorButt.Margin = new System.Windows.Forms.Padding(0);
            this.ColorButt.Name = "ColorButt";
            this.ColorButt.Size = new System.Drawing.Size(126, 26);
            this.ColorButt.TabIndex = 3;
            this.ColorButt.Text = "Choose Color";
            this.ColorButt.UseVisualStyleBackColor = true;
            this.ColorButt.Click += new System.EventHandler(this.ColorButt_Click);
            // 
            // EdStyle
            // 
            this.EdStyle.Controls.Add(this.tableLayoutPanel4);
            this.EdStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdStyle.Location = new System.Drawing.Point(0, 69);
            this.EdStyle.Margin = new System.Windows.Forms.Padding(0);
            this.EdStyle.Name = "EdStyle";
            this.EdStyle.Padding = new System.Windows.Forms.Padding(0);
            this.EdStyle.Size = new System.Drawing.Size(183, 62);
            this.EdStyle.TabIndex = 1;
            this.EdStyle.TabStop = false;
            this.EdStyle.Text = "Edge Style";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.Bresen, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Sysline, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 15);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(183, 47);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // Bresen
            // 
            this.Bresen.AutoSize = true;
            this.Bresen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bresen.Location = new System.Drawing.Point(20, 0);
            this.Bresen.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Bresen.Name = "Bresen";
            this.Bresen.Size = new System.Drawing.Size(163, 23);
            this.Bresen.TabIndex = 0;
            this.Bresen.Text = "Bresenham";
            this.Bresen.UseVisualStyleBackColor = true;
            this.Bresen.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Sysline
            // 
            this.Sysline.AutoSize = true;
            this.Sysline.Checked = true;
            this.Sysline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sysline.Location = new System.Drawing.Point(20, 23);
            this.Sysline.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Sysline.Name = "Sysline";
            this.Sysline.Size = new System.Drawing.Size(163, 24);
            this.Sysline.TabIndex = 1;
            this.Sysline.TabStop = true;
            this.Sysline.Text = "System Line";
            this.Sysline.UseVisualStyleBackColor = true;
            this.Sysline.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Location = new System.Drawing.Point(0, 131);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(183, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.CreateAction, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.EditAction, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 15);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(183, 47);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // CreateAction
            // 
            this.CreateAction.AutoSize = true;
            this.CreateAction.Checked = true;
            this.CreateAction.Location = new System.Drawing.Point(20, 0);
            this.CreateAction.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.CreateAction.Name = "CreateAction";
            this.CreateAction.Size = new System.Drawing.Size(58, 17);
            this.CreateAction.TabIndex = 0;
            this.CreateAction.TabStop = true;
            this.CreateAction.Text = "Create";
            this.CreateAction.UseVisualStyleBackColor = true;
            this.CreateAction.Click += new System.EventHandler(this.ChoseCreate);
            // 
            // EditAction
            // 
            this.EditAction.AutoSize = true;
            this.EditAction.Location = new System.Drawing.Point(20, 23);
            this.EditAction.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.EditAction.Name = "EditAction";
            this.EditAction.Size = new System.Drawing.Size(45, 17);
            this.EditAction.TabIndex = 1;
            this.EditAction.Text = "Edit";
            this.EditAction.UseVisualStyleBackColor = true;
            this.EditAction.Click += new System.EventHandler(this.ChooseEdit);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 193);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(183, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Vertex";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.RemoveVert, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.ColorVert, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 15);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(183, 40);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // RemoveVert
            // 
            this.RemoveVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveVert.Location = new System.Drawing.Point(1, 1);
            this.RemoveVert.Margin = new System.Windows.Forms.Padding(1);
            this.RemoveVert.Name = "RemoveVert";
            this.RemoveVert.Size = new System.Drawing.Size(89, 38);
            this.RemoveVert.TabIndex = 0;
            this.RemoveVert.Text = "Remove";
            this.RemoveVert.UseVisualStyleBackColor = true;
            this.RemoveVert.Click += new System.EventHandler(this.RemoveVert_Click);
            // 
            // ColorVert
            // 
            this.ColorVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorVert.Location = new System.Drawing.Point(92, 1);
            this.ColorVert.Margin = new System.Windows.Forms.Padding(1);
            this.ColorVert.Name = "ColorVert";
            this.ColorVert.Size = new System.Drawing.Size(90, 38);
            this.ColorVert.TabIndex = 1;
            this.ColorVert.Text = "Color";
            this.ColorVert.UseVisualStyleBackColor = true;
            this.ColorVert.Click += new System.EventHandler(this.ColorVert_Click);
            // 
            // EdgeBox
            // 
            this.EdgeBox.Controls.Add(this.tableLayoutPanel7);
            this.EdgeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdgeBox.Location = new System.Drawing.Point(0, 248);
            this.EdgeBox.Margin = new System.Windows.Forms.Padding(0);
            this.EdgeBox.Name = "EdgeBox";
            this.EdgeBox.Padding = new System.Windows.Forms.Padding(0);
            this.EdgeBox.Size = new System.Drawing.Size(183, 69);
            this.EdgeBox.TabIndex = 4;
            this.EdgeBox.TabStop = false;
            this.EdgeBox.Text = "Edge";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.RemEdge, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.Splitedge, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.SaveLen, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.perpendicular, 1, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 15);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(183, 54);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // RemEdge
            // 
            this.RemEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemEdge.Location = new System.Drawing.Point(1, 1);
            this.RemEdge.Margin = new System.Windows.Forms.Padding(1);
            this.RemEdge.Name = "RemEdge";
            this.RemEdge.Size = new System.Drawing.Size(89, 25);
            this.RemEdge.TabIndex = 0;
            this.RemEdge.Text = "Remove";
            this.RemEdge.UseVisualStyleBackColor = true;
            this.RemEdge.Click += new System.EventHandler(this.RemoveEdge);
            // 
            // Splitedge
            // 
            this.Splitedge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitedge.Location = new System.Drawing.Point(92, 1);
            this.Splitedge.Margin = new System.Windows.Forms.Padding(1);
            this.Splitedge.Name = "Splitedge";
            this.Splitedge.Size = new System.Drawing.Size(90, 25);
            this.Splitedge.TabIndex = 1;
            this.Splitedge.Text = "Split";
            this.Splitedge.UseVisualStyleBackColor = true;
            this.Splitedge.Click += new System.EventHandler(this.SplitEdge);
            // 
            // SaveLen
            // 
            this.SaveLen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveLen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveLen.ForeColor = System.Drawing.Color.DarkRed;
            this.SaveLen.Location = new System.Drawing.Point(1, 28);
            this.SaveLen.Margin = new System.Windows.Forms.Padding(1);
            this.SaveLen.Name = "SaveLen";
            this.SaveLen.Size = new System.Drawing.Size(89, 25);
            this.SaveLen.TabIndex = 2;
            this.SaveLen.Text = "Length";
            this.SaveLen.UseVisualStyleBackColor = true;
            this.SaveLen.Click += new System.EventHandler(this.SetLength);
            // 
            // perpendicular
            // 
            this.perpendicular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perpendicular.ForeColor = System.Drawing.Color.Navy;
            this.perpendicular.Location = new System.Drawing.Point(92, 28);
            this.perpendicular.Margin = new System.Windows.Forms.Padding(1);
            this.perpendicular.Name = "perpendicular";
            this.perpendicular.Size = new System.Drawing.Size(90, 25);
            this.perpendicular.TabIndex = 3;
            this.perpendicular.Text = "Perpendicular";
            this.perpendicular.UseVisualStyleBackColor = true;
            this.perpendicular.Click += new System.EventHandler(this.MakePerpe);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 317);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(183, 69);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Polygon";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.Selpolyg, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.RemovePoly, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 15);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(183, 54);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // Selpolyg
            // 
            this.Selpolyg.AutoSize = true;
            this.Selpolyg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Selpolyg.Location = new System.Drawing.Point(20, 0);
            this.Selpolyg.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Selpolyg.Name = "Selpolyg";
            this.Selpolyg.Size = new System.Drawing.Size(163, 27);
            this.Selpolyg.TabIndex = 1;
            this.Selpolyg.Text = "Select Polygon";
            this.Selpolyg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Selpolyg.UseVisualStyleBackColor = true;
            this.Selpolyg.Click += new System.EventHandler(this.SelPol_CLick);
            // 
            // RemovePoly
            // 
            this.RemovePoly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemovePoly.Location = new System.Drawing.Point(2, 29);
            this.RemovePoly.Margin = new System.Windows.Forms.Padding(2);
            this.RemovePoly.Name = "RemovePoly";
            this.RemovePoly.Size = new System.Drawing.Size(179, 23);
            this.RemovePoly.TabIndex = 2;
            this.RemovePoly.Text = "Remove";
            this.RemovePoly.UseVisualStyleBackColor = true;
            this.RemovePoly.Click += new System.EventHandler(this.RemovePolygon);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 389);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(177, 301);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Length Relation Details";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.Info, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(171, 280);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Polygon";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.Location = new System.Drawing.Point(3, 28);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(165, 252);
            this.Info.TabIndex = 1;
            this.Info.Text = "label2";
            // 
            // FirstRow
            // 
            this.FirstRow.ColumnCount = 2;
            this.FirstRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.FirstRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.FirstRow.Controls.Add(this.textBox1, 0, 0);
            this.FirstRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstRow.Location = new System.Drawing.Point(3, 3);
            this.FirstRow.Name = "FirstRow";
            this.FirstRow.RowCount = 1;
            this.FirstRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FirstRow.Size = new System.Drawing.Size(170, 42);
            this.FirstRow.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 23);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 693);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 732);
            this.Name = "Form1";
            this.Text = "Polygon Editor";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.DetailsBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.EdStyle.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.EdgeBox.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.FirstRow.ResumeLayout(false);
            this.FirstRow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel FirstRow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox DetailsBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label PolCouunt;
        private System.Windows.Forms.Label CountPolyg;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Button ColorButt;
        private System.Windows.Forms.GroupBox EdStyle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton Bresen;
        private System.Windows.Forms.RadioButton Sysline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RadioButton CreateAction;
        private System.Windows.Forms.RadioButton EditAction;
        private System.Windows.Forms.RadioButton n;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button RemoveVert;
        private System.Windows.Forms.Button ColorVert;
        private System.Windows.Forms.GroupBox EdgeBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button RemEdge;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SaveLen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Splitedge;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.CheckBox Selpolyg;
        private System.Windows.Forms.Button RemovePoly;
        private System.Windows.Forms.Button perpendicular;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Info;
    }
}

