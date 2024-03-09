using System.Security.Cryptography;
using System.Windows.Media.Effects;

namespace Civ6ModBuddyAlt.Projects.Properties;

partial class ModInfoUserControl {
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.modIdTextBox = new System.Windows.Forms.TextBox();
            this.newGuidButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.versionUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.modNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.authorsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.specialThanksTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.teaserTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hotCheckBox = new System.Windows.Forms.CheckBox();
            this.multiCheckBox = new System.Windows.Forms.CheckBox();
            this.singleCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.affectsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // modIdTextBox
            // 
            this.modIdTextBox.Location = new System.Drawing.Point(131, 5);
            this.modIdTextBox.Name = "modIdTextBox";
            this.modIdTextBox.ReadOnly = true;
            this.modIdTextBox.Size = new System.Drawing.Size(331, 21);
            this.modIdTextBox.TabIndex = 0;
            // 
            // newGuidButton
            // 
            this.newGuidButton.Location = new System.Drawing.Point(468, 3);
            this.newGuidButton.Name = "newGuidButton";
            this.newGuidButton.Size = new System.Drawing.Size(44, 23);
            this.newGuidButton.TabIndex = 1;
            this.newGuidButton.Text = "New";
            this.newGuidButton.UseVisualStyleBackColor = true;
            this.newGuidButton.Click += new System.EventHandler(this.newGuidButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mod ID:";
            // 
            // versionUpDown
            // 
            this.versionUpDown.Location = new System.Drawing.Point(131, 32);
            this.versionUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.versionUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.versionUpDown.Name = "versionUpDown";
            this.versionUpDown.Size = new System.Drawing.Size(89, 21);
            this.versionUpDown.TabIndex = 3;
            this.versionUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.versionUpDown.ValueChanged += new System.EventHandler(this.versionUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Version:";
            // 
            // modNameTextBox
            // 
            this.modNameTextBox.Location = new System.Drawing.Point(131, 59);
            this.modNameTextBox.Name = "modNameTextBox";
            this.modNameTextBox.Size = new System.Drawing.Size(381, 21);
            this.modNameTextBox.TabIndex = 5;
            this.modNameTextBox.TextChanged += new System.EventHandler(this.modNameTextBox_TextChanged);
            this.modNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.modNameTextBox_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mod Name:";
            // 
            // authorsTextBox
            // 
            this.authorsTextBox.Location = new System.Drawing.Point(131, 86);
            this.authorsTextBox.Name = "authorsTextBox";
            this.authorsTextBox.Size = new System.Drawing.Size(381, 21);
            this.authorsTextBox.TabIndex = 7;
            this.authorsTextBox.TextChanged += new System.EventHandler(this.authorTextBox_TextChanged);
            this.authorsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.authorsTextBox_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Author(s):";
            // 
            // specialThanksTextBox
            // 
            this.specialThanksTextBox.Location = new System.Drawing.Point(131, 113);
            this.specialThanksTextBox.Name = "specialThanksTextBox";
            this.specialThanksTextBox.Size = new System.Drawing.Size(381, 21);
            this.specialThanksTextBox.TabIndex = 9;
            this.specialThanksTextBox.TextChanged += new System.EventHandler(this.specialThanksTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Special Thanks:";
            // 
            // teaserTextBox
            // 
            this.teaserTextBox.Location = new System.Drawing.Point(131, 140);
            this.teaserTextBox.MaxLength = 128;
            this.teaserTextBox.Name = "teaserTextBox";
            this.teaserTextBox.Size = new System.Drawing.Size(381, 21);
            this.teaserTextBox.TabIndex = 11;
            this.teaserTextBox.TextChanged += new System.EventHandler(this.teaserTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Teaser:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(131, 167);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descriptionTextBox.Size = new System.Drawing.Size(381, 154);
            this.descriptionTextBox.TabIndex = 13;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.descriptionTextBox_TextChanged);
            this.descriptionTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.descriptionTextBox_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "Description:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hotCheckBox);
            this.groupBox1.Controls.Add(this.multiCheckBox);
            this.groupBox1.Controls.Add(this.singleCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(62, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 76);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compatibility";
            // 
            // hotCheckBox
            // 
            this.hotCheckBox.AutoSize = true;
            this.hotCheckBox.Location = new System.Drawing.Point(213, 20);
            this.hotCheckBox.Name = "hotCheckBox";
            this.hotCheckBox.Size = new System.Drawing.Size(121, 16);
            this.hotCheckBox.TabIndex = 2;
            this.hotCheckBox.Text = "Supports HotSeat";
            this.hotCheckBox.UseVisualStyleBackColor = true;
            this.hotCheckBox.CheckedChanged += new System.EventHandler(this.hotCheckBox_CheckedChanged);
            // 
            // multiCheckBox
            // 
            this.multiCheckBox.AutoSize = true;
            this.multiCheckBox.Location = new System.Drawing.Point(6, 42);
            this.multiCheckBox.Name = "multiCheckBox";
            this.multiCheckBox.Size = new System.Drawing.Size(190, 16);
            this.multiCheckBox.TabIndex = 1;
            this.multiCheckBox.Text = "Supports Network Multiplayer";
            this.multiCheckBox.UseVisualStyleBackColor = true;
            this.multiCheckBox.CheckedChanged += new System.EventHandler(this.multiCheckBox_CheckedChanged);
            // 
            // singleCheckBox
            // 
            this.singleCheckBox.AutoSize = true;
            this.singleCheckBox.Location = new System.Drawing.Point(6, 20);
            this.singleCheckBox.Name = "singleCheckBox";
            this.singleCheckBox.Size = new System.Drawing.Size(153, 16);
            this.singleCheckBox.TabIndex = 0;
            this.singleCheckBox.Text = "Supports Single Player";
            this.singleCheckBox.UseVisualStyleBackColor = true;
            this.singleCheckBox.CheckedChanged += new System.EventHandler(this.singleCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.affectsCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(62, 409);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 69);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saved Games";
            // 
            // affectsCheckBox
            // 
            this.affectsCheckBox.AutoSize = true;
            this.affectsCheckBox.Location = new System.Drawing.Point(6, 20);
            this.affectsCheckBox.Name = "affectsCheckBox";
            this.affectsCheckBox.Size = new System.Drawing.Size(146, 16);
            this.affectsCheckBox.TabIndex = 0;
            this.affectsCheckBox.Text = "Affects Saved Games";
            this.affectsCheckBox.UseVisualStyleBackColor = true;
            this.affectsCheckBox.CheckedChanged += new System.EventHandler(this.affectsCheckBox_CheckedChanged);
            // 
            // ModInfoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.teaserTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.specialThanksTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.authorsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.versionUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newGuidButton);
            this.Controls.Add(this.modIdTextBox);
            this.Name = "ModInfoUserControl";
            this.Size = new System.Drawing.Size(515, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ErrorProvider errorProvider;
    private System.Windows.Forms.TextBox modIdTextBox;
    private System.Windows.Forms.Button newGuidButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown versionUpDown;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox modNameTextBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox authorsTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox specialThanksTextBox;
    private System.Windows.Forms.TextBox teaserTextBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox descriptionTextBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox singleCheckBox;
    private System.Windows.Forms.CheckBox multiCheckBox;
    private System.Windows.Forms.CheckBox hotCheckBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.CheckBox affectsCheckBox;
}
