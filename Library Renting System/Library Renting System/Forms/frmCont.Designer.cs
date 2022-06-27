
namespace Library_Renting_System.Forms
{
    partial class frmCont
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
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.telefonLbl = new System.Windows.Forms.Label();
            this.txtPrenume = new System.Windows.Forms.TextBox();
            this.prenumeLbl = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.lnumeLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.titleAccount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTelefon
            // 
            this.txtTelefon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefon.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelefon.Location = new System.Drawing.Point(255, 236);
            this.txtTelefon.Multiline = true;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(216, 28);
            this.txtTelefon.TabIndex = 22;
            // 
            // telefonLbl
            // 
            this.telefonLbl.AutoSize = true;
            this.telefonLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.telefonLbl.Location = new System.Drawing.Point(109, 241);
            this.telefonLbl.Name = "telefonLbl";
            this.telefonLbl.Size = new System.Drawing.Size(91, 15);
            this.telefonLbl.TabIndex = 21;
            this.telefonLbl.Text = "Phone Number";
            // 
            // txtPrenume
            // 
            this.txtPrenume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtPrenume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrenume.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrenume.Location = new System.Drawing.Point(255, 193);
            this.txtPrenume.Multiline = true;
            this.txtPrenume.Name = "txtPrenume";
            this.txtPrenume.Size = new System.Drawing.Size(216, 28);
            this.txtPrenume.TabIndex = 24;
            // 
            // prenumeLbl
            // 
            this.prenumeLbl.AutoSize = true;
            this.prenumeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prenumeLbl.Location = new System.Drawing.Point(109, 206);
            this.prenumeLbl.Name = "prenumeLbl";
            this.prenumeLbl.Size = new System.Drawing.Size(67, 15);
            this.prenumeLbl.TabIndex = 23;
            this.prenumeLbl.Text = "Last Name";
            this.prenumeLbl.Click += new System.EventHandler(this.prenumeLbl_Click);
            // 
            // txtNume
            // 
            this.txtNume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtNume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNume.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNume.Location = new System.Drawing.Point(255, 139);
            this.txtNume.Multiline = true;
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(216, 28);
            this.txtNume.TabIndex = 26;
            // 
            // lnumeLbl
            // 
            this.lnumeLbl.AutoSize = true;
            this.lnumeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnumeLbl.Location = new System.Drawing.Point(109, 152);
            this.lnumeLbl.Name = "lnumeLbl";
            this.lnumeLbl.Size = new System.Drawing.Size(67, 15);
            this.lnumeLbl.TabIndex = 25;
            this.lnumeLbl.Text = "First Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(151, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 35);
            this.button1.TabIndex = 28;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.White;
            this.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.clearBtn.Location = new System.Drawing.Point(426, 301);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(216, 35);
            this.clearBtn.TabIndex = 27;
            this.clearBtn.Text = "RESET";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // titleAccount
            // 
            this.titleAccount.AutoSize = true;
            this.titleAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleAccount.ForeColor = System.Drawing.Color.Black;
            this.titleAccount.Location = new System.Drawing.Point(342, 40);
            this.titleAccount.Name = "titleAccount";
            this.titleAccount.Size = new System.Drawing.Size(144, 16);
            this.titleAccount.TabIndex = 29;
            this.titleAccount.Text = "ACCOUNT SETTINGS";
            // 
            // frmCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleAccount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.lnumeLbl);
            this.Controls.Add(this.txtPrenume);
            this.Controls.Add(this.prenumeLbl);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.telefonLbl);
            this.Name = "frmCont";
            this.Text = "Account Section";
            this.Load += new System.EventHandler(this.frmCont_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label telefonLbl;
        private System.Windows.Forms.TextBox txtPrenume;
        private System.Windows.Forms.Label prenumeLbl;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label lnumeLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label titleAccount;
    }
}