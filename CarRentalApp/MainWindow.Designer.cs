﻿namespace CarRentalApp
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageVehicleListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRentalRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRentalRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRentalRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageVehicleListingToolStripMenuItem,
            this.manageRentalRecordsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1257, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageVehicleListingToolStripMenuItem
            // 
            this.manageVehicleListingToolStripMenuItem.Name = "manageVehicleListingToolStripMenuItem";
            this.manageVehicleListingToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.manageVehicleListingToolStripMenuItem.Text = "Manage Vehicle Listing";
            this.manageVehicleListingToolStripMenuItem.Click += new System.EventHandler(this.manageVehicleListingToolStripMenuItem_Click);
            // 
            // manageRentalRecordsToolStripMenuItem
            // 
            this.manageRentalRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRentalRecordToolStripMenuItem,
            this.viewArchiveToolStripMenuItem,
            this.editRentalRecordToolStripMenuItem});
            this.manageRentalRecordsToolStripMenuItem.Name = "manageRentalRecordsToolStripMenuItem";
            this.manageRentalRecordsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.manageRentalRecordsToolStripMenuItem.Text = "Manage Rental Records";
            // 
            // addRentalRecordToolStripMenuItem
            // 
            this.addRentalRecordToolStripMenuItem.Name = "addRentalRecordToolStripMenuItem";
            this.addRentalRecordToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addRentalRecordToolStripMenuItem.Text = "Add Rental Record";
            this.addRentalRecordToolStripMenuItem.Click += new System.EventHandler(this.addRentalRecordToolStripMenuItem_Click);
            // 
            // viewArchiveToolStripMenuItem
            // 
            this.viewArchiveToolStripMenuItem.Name = "viewArchiveToolStripMenuItem";
            this.viewArchiveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viewArchiveToolStripMenuItem.Text = "View Archive";
            // 
            // editRentalRecordToolStripMenuItem
            // 
            this.editRentalRecordToolStripMenuItem.Name = "editRentalRecordToolStripMenuItem";
            this.editRentalRecordToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.editRentalRecordToolStripMenuItem.Text = "Edit Rental Record";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 726);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "Car Rental Management System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageVehicleListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRentalRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRentalRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRentalRecordToolStripMenuItem;
    }
}