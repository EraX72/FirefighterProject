namespace FirefighterProject.View
{
    partial class MainView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDash = new System.Windows.Forms.Button();
            this.btnAddIncident = new System.Windows.Forms.Button();
            this.btnViewIncidentDetails = new System.Windows.Forms.Button();
            this.pblUpper = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewIncidents = new System.Windows.Forms.DataGridView();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncidents)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.pbLogo);
            this.pnlLeft.Controls.Add(this.btnDelete);
            this.pnlLeft.Controls.Add(this.btnUpdate);
            this.pnlLeft.Controls.Add(this.btnAdd);
            this.pnlLeft.Controls.Add(this.btnDash);
            this.pnlLeft.Controls.Add(this.btnAddIncident);
            this.pnlLeft.Controls.Add(this.btnViewIncidentDetails);
            this.pnlLeft.Location = new System.Drawing.Point(1, -2);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(358, 649);
            this.pnlLeft.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.Image = global::FirefighterProject.Properties.Resources.fmLogo;
            this.pbLogo.Location = new System.Drawing.Point(72, 64);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(215, 162);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 12;
            this.pbLogo.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(72, 498);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(215, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.IndianRed;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(72, 458);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(215, 34);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.IndianRed;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(72, 418);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(215, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnDash
            // 
            this.btnDash.BackColor = System.Drawing.Color.IndianRed;
            this.btnDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDash.ForeColor = System.Drawing.Color.White;
            this.btnDash.Location = new System.Drawing.Point(72, 376);
            this.btnDash.Name = "btnDash";
            this.btnDash.Size = new System.Drawing.Size(215, 36);
            this.btnDash.TabIndex = 2;
            this.btnDash.Text = "DASHBOARD";
            this.btnDash.UseVisualStyleBackColor = false;
            this.btnDash.Click += new System.EventHandler(this.btnDash_Click_1);
            // 
            // btnAddIncident
            // 
            this.btnAddIncident.BackColor = System.Drawing.Color.IndianRed;
            this.btnAddIncident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIncident.ForeColor = System.Drawing.Color.White;
            this.btnAddIncident.Location = new System.Drawing.Point(72, 288);
            this.btnAddIncident.Name = "btnAddIncident";
            this.btnAddIncident.Size = new System.Drawing.Size(215, 41);
            this.btnAddIncident.TabIndex = 7;
            this.btnAddIncident.Text = "ADD INCIDENT";
            this.btnAddIncident.UseVisualStyleBackColor = false;
            this.btnAddIncident.Click += new System.EventHandler(this.btnAddIncident_Click);
            // 
            // btnViewIncidentDetails
            // 
            this.btnViewIncidentDetails.BackColor = System.Drawing.Color.IndianRed;
            this.btnViewIncidentDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewIncidentDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewIncidentDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewIncidentDetails.Location = new System.Drawing.Point(72, 335);
            this.btnViewIncidentDetails.Name = "btnViewIncidentDetails";
            this.btnViewIncidentDetails.Size = new System.Drawing.Size(215, 35);
            this.btnViewIncidentDetails.TabIndex = 8;
            this.btnViewIncidentDetails.Text = "VIEW INCIDENT DETAILS";
            this.btnViewIncidentDetails.UseVisualStyleBackColor = false;
            this.btnViewIncidentDetails.Click += new System.EventHandler(this.btnViewIncidentDetails_Click);
            // 
            // pblUpper
            // 
            this.pblUpper.BackColor = System.Drawing.Color.RosyBrown;
            this.pblUpper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblUpper.Location = new System.Drawing.Point(0, 0);
            this.pblUpper.Name = "pblUpper";
            this.pblUpper.Size = new System.Drawing.Size(1307, 40);
            this.pblUpper.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(448, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(703, 381);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewIncidents
            // 
            this.dataGridViewIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncidents.Location = new System.Drawing.Point(448, 433);
            this.dataGridViewIncidents.Name = "dataGridViewIncidents";
            this.dataGridViewIncidents.Size = new System.Drawing.Size(703, 221);
            this.dataGridViewIncidents.TabIndex = 9;
            this.dataGridViewIncidents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIncidents_CellContentClick);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1307, 666);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridViewIncidents);
            this.Controls.Add(this.pblUpper);
            this.Controls.Add(this.pnlLeft);
            this.Name = "MainView";
            this.Text = "MainView";
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncidents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pblUpper;
        private System.Windows.Forms.Button btnDash;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddIncident;
        private System.Windows.Forms.Button btnViewIncidentDetails;
        private System.Windows.Forms.DataGridView dataGridViewIncidents;
    }
}