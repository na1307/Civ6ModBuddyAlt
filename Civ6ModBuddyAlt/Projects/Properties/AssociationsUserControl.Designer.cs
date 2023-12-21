namespace Civ6ModBuddyAlt.Projects.Properties;

partial class AssociationsUserControl {
    /// <summary> 
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// 사용 중인 모든 리소스를 정리합니다.
    /// </summary>
    /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region 구성 요소 디자이너에서 생성한 코드

    /// <summary> 
    /// 디자이너 지원에 필요한 메서드입니다. 
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeSelectedDependencyButton = new System.Windows.Forms.Button();
            this.addDlcDependencyButton = new System.Windows.Forms.Button();
            this.addModDependencyButton = new System.Windows.Forms.Button();
            this.dependenciesDataGridView = new System.Windows.Forms.DataGridView();
            this.dependencyTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dependencyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.removeSelectedReferenceButton = new System.Windows.Forms.Button();
            this.addDlcReferenceButton = new System.Windows.Forms.Button();
            this.addModReferenceButton = new System.Windows.Forms.Button();
            this.referencesDataGridView = new System.Windows.Forms.DataGridView();
            this.columnReferencesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnReferencesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.removeSelectedBlockerButton = new System.Windows.Forms.Button();
            this.addDlcBlockerButton = new System.Windows.Forms.Button();
            this.addModBlockerButton = new System.Windows.Forms.Button();
            this.blockersDataGridView = new System.Windows.Forms.DataGridView();
            this.blocksTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blocksNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dependenciesDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.referencesDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blockersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "This section allows you to specify various associations that this mod will have w" +
    "ith other mods and content types in the game.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeSelectedDependencyButton);
            this.groupBox1.Controls.Add(this.addDlcDependencyButton);
            this.groupBox1.Controls.Add(this.addModDependencyButton);
            this.groupBox1.Controls.Add(this.dependenciesDataGridView);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dependencies";
            // 
            // removeSelectedDependencyButton
            // 
            this.removeSelectedDependencyButton.Location = new System.Drawing.Point(473, 114);
            this.removeSelectedDependencyButton.Name = "removeSelectedDependencyButton";
            this.removeSelectedDependencyButton.Size = new System.Drawing.Size(99, 23);
            this.removeSelectedDependencyButton.TabIndex = 4;
            this.removeSelectedDependencyButton.Text = "Remove";
            this.removeSelectedDependencyButton.UseVisualStyleBackColor = true;
            this.removeSelectedDependencyButton.Click += new System.EventHandler(this.removeSelectedDependencyButton_Click);
            // 
            // addDlcDependencyButton
            // 
            this.addDlcDependencyButton.Location = new System.Drawing.Point(473, 85);
            this.addDlcDependencyButton.Name = "addDlcDependencyButton";
            this.addDlcDependencyButton.Size = new System.Drawing.Size(99, 23);
            this.addDlcDependencyButton.TabIndex = 3;
            this.addDlcDependencyButton.Text = "Add DLC...";
            this.addDlcDependencyButton.UseVisualStyleBackColor = true;
            this.addDlcDependencyButton.Click += new System.EventHandler(this.addDlcDependencyButton_Click);
            // 
            // addModDependencyButton
            // 
            this.addModDependencyButton.Location = new System.Drawing.Point(473, 56);
            this.addModDependencyButton.Name = "addModDependencyButton";
            this.addModDependencyButton.Size = new System.Drawing.Size(99, 23);
            this.addModDependencyButton.TabIndex = 2;
            this.addModDependencyButton.Text = "Add Mod...";
            this.addModDependencyButton.UseVisualStyleBackColor = true;
            this.addModDependencyButton.Click += new System.EventHandler(this.addModDependencyButton_Click);
            // 
            // dependenciesDataGridView
            // 
            this.dependenciesDataGridView.AllowUserToAddRows = false;
            this.dependenciesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dependenciesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dependenciesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dependenciesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dependencyTypeColumn,
            this.dependencyNameColumn});
            this.dependenciesDataGridView.Location = new System.Drawing.Point(6, 56);
            this.dependenciesDataGridView.Name = "dependenciesDataGridView";
            this.dependenciesDataGridView.RowHeadersVisible = false;
            this.dependenciesDataGridView.RowTemplate.Height = 23;
            this.dependenciesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dependenciesDataGridView.Size = new System.Drawing.Size(461, 125);
            this.dependenciesDataGridView.TabIndex = 1;
            this.dependenciesDataGridView.SelectionChanged += new System.EventHandler(this.dependenciesDataGridView_SelectionChanged);
            // 
            // dependencyTypeColumn
            // 
            this.dependencyTypeColumn.DataPropertyName = "Type";
            this.dependencyTypeColumn.HeaderText = "Type";
            this.dependencyTypeColumn.Name = "dependencyTypeColumn";
            // 
            // dependencyNameColumn
            // 
            this.dependencyNameColumn.DataPropertyName = "Name";
            this.dependencyNameColumn.HeaderText = "Name";
            this.dependencyNameColumn.Name = "dependencyNameColumn";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(566, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "These associations are REQUIRED by the Mod and must exist in order for the mod to" +
    " be activated.   Any dependent mods are activated BEFORE this mod is activated.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeSelectedReferenceButton);
            this.groupBox2.Controls.Add(this.addDlcReferenceButton);
            this.groupBox2.Controls.Add(this.addModReferenceButton);
            this.groupBox2.Controls.Add(this.referencesDataGridView);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 199);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "References";
            // 
            // removeSelectedReferenceButton
            // 
            this.removeSelectedReferenceButton.Location = new System.Drawing.Point(473, 114);
            this.removeSelectedReferenceButton.Name = "removeSelectedReferenceButton";
            this.removeSelectedReferenceButton.Size = new System.Drawing.Size(99, 23);
            this.removeSelectedReferenceButton.TabIndex = 4;
            this.removeSelectedReferenceButton.Text = "Remove";
            this.removeSelectedReferenceButton.UseVisualStyleBackColor = true;
            this.removeSelectedReferenceButton.Click += new System.EventHandler(this.removeSelectedReferenceButton_Click);
            // 
            // addDlcReferenceButton
            // 
            this.addDlcReferenceButton.Location = new System.Drawing.Point(473, 85);
            this.addDlcReferenceButton.Name = "addDlcReferenceButton";
            this.addDlcReferenceButton.Size = new System.Drawing.Size(99, 23);
            this.addDlcReferenceButton.TabIndex = 3;
            this.addDlcReferenceButton.Text = "Add DLC...";
            this.addDlcReferenceButton.UseVisualStyleBackColor = true;
            this.addDlcReferenceButton.Click += new System.EventHandler(this.addDlcReferenceButton_Click);
            // 
            // addModReferenceButton
            // 
            this.addModReferenceButton.Location = new System.Drawing.Point(473, 56);
            this.addModReferenceButton.Name = "addModReferenceButton";
            this.addModReferenceButton.Size = new System.Drawing.Size(99, 23);
            this.addModReferenceButton.TabIndex = 2;
            this.addModReferenceButton.Text = "Add Mod...";
            this.addModReferenceButton.UseVisualStyleBackColor = true;
            this.addModReferenceButton.Click += new System.EventHandler(this.addModReferenceButton_Click);
            // 
            // referencesDataGridView
            // 
            this.referencesDataGridView.AllowUserToAddRows = false;
            this.referencesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.referencesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.referencesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnReferencesType,
            this.columnReferencesName});
            this.referencesDataGridView.Location = new System.Drawing.Point(6, 56);
            this.referencesDataGridView.Name = "referencesDataGridView";
            this.referencesDataGridView.RowHeadersVisible = false;
            this.referencesDataGridView.RowTemplate.Height = 23;
            this.referencesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.referencesDataGridView.Size = new System.Drawing.Size(461, 138);
            this.referencesDataGridView.TabIndex = 1;
            this.referencesDataGridView.SelectionChanged += new System.EventHandler(this.referencesDataGridView_SelectionChanged);
            // 
            // columnReferencesType
            // 
            this.columnReferencesType.DataPropertyName = "Type";
            this.columnReferencesType.HeaderText = "Type";
            this.columnReferencesType.Name = "columnReferencesType";
            // 
            // columnReferencesName
            // 
            this.columnReferencesName.DataPropertyName = "Name";
            this.columnReferencesName.HeaderText = "Name";
            this.columnReferencesName.Name = "columnReferencesName";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(566, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "These associations are OPTIONAL and do not need to exist for the mod to be activa" +
    "ted.  Any referenced mod that is enabled will be activated BEFORE this mod is ac" +
    "tivated.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.removeSelectedBlockerButton);
            this.groupBox3.Controls.Add(this.addDlcBlockerButton);
            this.groupBox3.Controls.Add(this.addModBlockerButton);
            this.groupBox3.Controls.Add(this.blockersDataGridView);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(3, 437);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 198);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blocks";
            // 
            // removeSelectedBlockerButton
            // 
            this.removeSelectedBlockerButton.Location = new System.Drawing.Point(474, 102);
            this.removeSelectedBlockerButton.Name = "removeSelectedBlockerButton";
            this.removeSelectedBlockerButton.Size = new System.Drawing.Size(99, 23);
            this.removeSelectedBlockerButton.TabIndex = 4;
            this.removeSelectedBlockerButton.Text = "Remove";
            this.removeSelectedBlockerButton.UseVisualStyleBackColor = true;
            this.removeSelectedBlockerButton.Click += new System.EventHandler(this.removeSelectedBlockerButton_Click);
            // 
            // addDlcBlockerButton
            // 
            this.addDlcBlockerButton.Location = new System.Drawing.Point(473, 72);
            this.addDlcBlockerButton.Name = "addDlcBlockerButton";
            this.addDlcBlockerButton.Size = new System.Drawing.Size(99, 23);
            this.addDlcBlockerButton.TabIndex = 3;
            this.addDlcBlockerButton.Text = "Add DLC..";
            this.addDlcBlockerButton.UseVisualStyleBackColor = true;
            this.addDlcBlockerButton.Click += new System.EventHandler(this.addDlcBlockerButton_Click);
            // 
            // addModBlockerButton
            // 
            this.addModBlockerButton.Location = new System.Drawing.Point(473, 43);
            this.addModBlockerButton.Name = "addModBlockerButton";
            this.addModBlockerButton.Size = new System.Drawing.Size(99, 23);
            this.addModBlockerButton.TabIndex = 2;
            this.addModBlockerButton.Text = "Add Mod...";
            this.addModBlockerButton.UseVisualStyleBackColor = true;
            this.addModBlockerButton.Click += new System.EventHandler(this.addModBlockerButton_Click);
            // 
            // blockersDataGridView
            // 
            this.blockersDataGridView.AllowUserToAddRows = false;
            this.blockersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blockersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blockersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.blocksTypeColumn,
            this.blocksNameColumn});
            this.blockersDataGridView.Location = new System.Drawing.Point(6, 45);
            this.blockersDataGridView.Name = "blockersDataGridView";
            this.blockersDataGridView.RowHeadersVisible = false;
            this.blockersDataGridView.RowTemplate.Height = 23;
            this.blockersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.blockersDataGridView.Size = new System.Drawing.Size(461, 147);
            this.blockersDataGridView.TabIndex = 1;
            this.blockersDataGridView.SelectionChanged += new System.EventHandler(this.blockersDataGridView_SelectionChanged);
            // 
            // blocksTypeColumn
            // 
            this.blocksTypeColumn.DataPropertyName = "Type";
            this.blocksTypeColumn.HeaderText = "Type";
            this.blocksTypeColumn.Name = "blocksTypeColumn";
            // 
            // blocksNameColumn
            // 
            this.blocksNameColumn.DataPropertyName = "Name";
            this.blocksNameColumn.HeaderText = "Name";
            this.blocksNameColumn.Name = "blocksNameColumn";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(566, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "These associations are mutually exclusive with the mod.  They must not be activat" +
    "ed in order for this mod to be used.";
            // 
            // AssociationsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "AssociationsUserControl";
            this.Size = new System.Drawing.Size(584, 663);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dependenciesDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.referencesDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blockersDataGridView)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataGridView dependenciesDataGridView;
    private System.Windows.Forms.Button addModDependencyButton;
    private System.Windows.Forms.Button removeSelectedDependencyButton;
    private System.Windows.Forms.Button addDlcDependencyButton;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DataGridView referencesDataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn dependencyTypeColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dependencyNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn columnReferencesType;
    private System.Windows.Forms.DataGridViewTextBoxColumn columnReferencesName;
    private System.Windows.Forms.Button addDlcReferenceButton;
    private System.Windows.Forms.Button addModReferenceButton;
    private System.Windows.Forms.Button removeSelectedReferenceButton;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.DataGridView blockersDataGridView;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.DataGridViewTextBoxColumn blocksTypeColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn blocksNameColumn;
    private System.Windows.Forms.Button addModBlockerButton;
    private System.Windows.Forms.Button addDlcBlockerButton;
    private System.Windows.Forms.Button removeSelectedBlockerButton;
}
