﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FiveMApi.api;
using FlashForgeUI.ui.main.util;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class PrinterSelectionWindow : Form
    {

        public FlashForgePrinter SelectedPrinter { get; private set; }
        public string CheckCode { get; private set; }
        private MainMenu _mainMenu;

        public PrinterSelectionWindow(MainMenu mainMenu, List<FlashForgePrinter> printers)
        {
            _mainMenu = mainMenu;
            InitializeComponent();
            LoadPrinters(printers);
            
            Shown += (s, e) =>
            {
                if (mainMenu.Config.AlwaysOnTop)
                {
                    mainMenu.UiHelper.SetOnTop(Handle);
                }
            };
            
            // the "default" NightControlBox just closes the application when exit is clicked..??
            FormClosing += (s, e) => 
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            };
        }

        private void LoadPrinters(List<FlashForgePrinter> printers)
        {
            foreach (var printer in printers)
            {
                var listItem = new ListViewItem(printer.Name);
                listItem.SubItems.Add(printer.IPAddress.ToString());
                listItem.SubItems.Add(printer.SerialNumber);
                listItem.Tag = printer;
                listViewPrinters.Items.Add(listItem);
            }
        }

        private void listViewPrinters_ItemActivate(object sender, EventArgs e)
        {
            if (listViewPrinters.SelectedItems.Count <= 0) return;
            var selectedItem = listViewPrinters.SelectedItems[0];
            var printer = (FlashForgePrinter)selectedItem.Tag;

            using (var inputForm = new PrinterPairingWindow(_mainMenu))
            {
                var result = inputForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CheckCode = inputForm.CheckCode;
                    SelectedPrinter = printer;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Check code was not entered. Please select a printer and enter the check code.",
                        "Check Code Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}