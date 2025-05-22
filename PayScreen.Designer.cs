namespace ergasia_alilepidrasi
{
    partial class PayScreen
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
            this.cash_radio = new System.Windows.Forms.RadioButton();
            this.card_radio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hol_name_textbox = new System.Windows.Forms.TextBox();
            this.card_num_textbox = new System.Windows.Forms.TextBox();
            this.cvv_textbox = new System.Windows.Forms.TextBox();
            this.hol_name_label = new System.Windows.Forms.Label();
            this.card_num_label = new System.Windows.Forms.Label();
            this.cvv_label = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.order_button = new System.Windows.Forms.Button();
            this.card_network_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cash_radio
            // 
            this.cash_radio.AutoSize = true;
            this.cash_radio.Location = new System.Drawing.Point(404, 32);
            this.cash_radio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cash_radio.Name = "cash_radio";
            this.cash_radio.Size = new System.Drawing.Size(59, 21);
            this.cash_radio.TabIndex = 0;
            this.cash_radio.TabStop = true;
            this.cash_radio.Tag = "unchecked";
            this.cash_radio.Text = "cash";
            this.cash_radio.UseVisualStyleBackColor = true;
            this.cash_radio.CheckedChanged += new System.EventHandler(this.cash_radio_CheckedChanged);
            // 
            // card_radio
            // 
            this.card_radio.AutoSize = true;
            this.card_radio.Location = new System.Drawing.Point(36, 32);
            this.card_radio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card_radio.Name = "card_radio";
            this.card_radio.Size = new System.Drawing.Size(57, 21);
            this.card_radio.TabIndex = 1;
            this.card_radio.TabStop = true;
            this.card_radio.Tag = "unchecked";
            this.card_radio.Text = "card";
            this.card_radio.UseVisualStyleBackColor = true;
            this.card_radio.CheckedChanged += new System.EventHandler(this.card_radio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.card_radio);
            this.groupBox1.Controls.Add(this.cash_radio);
            this.groupBox1.Location = new System.Drawing.Point(121, 76);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(497, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick Payment Nethod";
            // 
            // hol_name_textbox
            // 
            this.hol_name_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hol_name_textbox.Location = new System.Drawing.Point(159, 167);
            this.hol_name_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hol_name_textbox.Name = "hol_name_textbox";
            this.hol_name_textbox.Size = new System.Drawing.Size(179, 22);
            this.hol_name_textbox.TabIndex = 3;
            this.hol_name_textbox.TextChanged += new System.EventHandler(this.hol_name_textbox_TextChanged);
            // 
            // card_num_textbox
            // 
            this.card_num_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.card_num_textbox.Location = new System.Drawing.Point(159, 193);
            this.card_num_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card_num_textbox.Name = "card_num_textbox";
            this.card_num_textbox.Size = new System.Drawing.Size(179, 22);
            this.card_num_textbox.TabIndex = 4;
            this.card_num_textbox.TextChanged += new System.EventHandler(this.card_num_textbox_TextChanged);
            // 
            // cvv_textbox
            // 
            this.cvv_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cvv_textbox.Location = new System.Drawing.Point(159, 219);
            this.cvv_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cvv_textbox.Name = "cvv_textbox";
            this.cvv_textbox.Size = new System.Drawing.Size(48, 22);
            this.cvv_textbox.TabIndex = 5;
            this.cvv_textbox.TextChanged += new System.EventHandler(this.cvv_textbox_TextChanged);
            // 
            // hol_name_label
            // 
            this.hol_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hol_name_label.AutoSize = true;
            this.hol_name_label.Location = new System.Drawing.Point(63, 172);
            this.hol_name_label.Name = "hol_name_label";
            this.hol_name_label.Size = new System.Drawing.Size(91, 17);
            this.hol_name_label.TabIndex = 6;
            this.hol_name_label.Text = "Holder Name";
            // 
            // card_num_label
            // 
            this.card_num_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.card_num_label.AutoSize = true;
            this.card_num_label.Location = new System.Drawing.Point(61, 198);
            this.card_num_label.Name = "card_num_label";
            this.card_num_label.Size = new System.Drawing.Size(92, 17);
            this.card_num_label.TabIndex = 7;
            this.card_num_label.Text = "Card Number";
            // 
            // cvv_label
            // 
            this.cvv_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cvv_label.AutoSize = true;
            this.cvv_label.Location = new System.Drawing.Point(108, 224);
            this.cvv_label.Name = "cvv_label";
            this.cvv_label.Size = new System.Drawing.Size(35, 17);
            this.cvv_label.TabIndex = 8;
            this.cvv_label.Text = "CVV";
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancel_button.Location = new System.Drawing.Point(577, 299);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(72, 30);
            this.cancel_button.TabIndex = 9;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            this.cancel_button.MouseLeave += new System.EventHandler(this.cancel_button_MouseLeave);
            this.cancel_button.MouseHover += new System.EventHandler(this.cancel_button_MouseHover);
            // 
            // order_button
            // 
            this.order_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.order_button.Location = new System.Drawing.Point(556, 262);
            this.order_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.order_button.Name = "order_button";
            this.order_button.Size = new System.Drawing.Size(93, 25);
            this.order_button.TabIndex = 10;
            this.order_button.Text = "Finish Order";
            this.order_button.UseVisualStyleBackColor = true;
            this.order_button.Click += new System.EventHandler(this.order_button_Click);
            this.order_button.MouseLeave += new System.EventHandler(this.order_button_MouseLeave);
            this.order_button.MouseHover += new System.EventHandler(this.order_button_MouseHover);
            // 
            // card_network_label
            // 
            this.card_network_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.card_network_label.AutoSize = true;
            this.card_network_label.Location = new System.Drawing.Point(341, 198);
            this.card_network_label.Name = "card_network_label";
            this.card_network_label.Size = new System.Drawing.Size(44, 17);
            this.card_network_label.TabIndex = 11;
            this.card_network_label.Text = "Other";
            this.card_network_label.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 311);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "You must pay: ";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(595, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "Show Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // PayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 359);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.card_network_label);
            this.Controls.Add(this.order_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.cvv_label);
            this.Controls.Add(this.card_num_label);
            this.Controls.Add(this.hol_name_label);
            this.Controls.Add(this.cvv_textbox);
            this.Controls.Add(this.card_num_textbox);
            this.Controls.Add(this.hol_name_textbox);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PayScreen";
            this.Text = "PayScreen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton cash_radio;
        private System.Windows.Forms.RadioButton card_radio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox hol_name_textbox;
        private System.Windows.Forms.TextBox card_num_textbox;
        private System.Windows.Forms.TextBox cvv_textbox;
        private System.Windows.Forms.Label hol_name_label;
        private System.Windows.Forms.Label card_num_label;
        private System.Windows.Forms.Label cvv_label;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button order_button;
        private System.Windows.Forms.Label card_network_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}