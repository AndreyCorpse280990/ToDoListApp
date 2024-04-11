using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            priorityComboBox.SelectedIndex = 0;
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            string description = descritionTextBox.Text;
            string priority = priorityComboBox.SelectedItem.ToString();
            int position = toDoListBox.Items.Count + 1;

            if (description != "")
            {
                string newItem = $"{position}. {description} - {priority}";
                toDoListBox.Items.Add(newItem);
                descritionTextBox.Clear();
                priorityComboBox.SelectedIndex = 0;
            } else {
                MessageBox.Show
                    (" введите описание  для нового дела.");
            }         
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if( toDoListBox.SelectedIndex != -1 )
            {

                int removeIndex = toDoListBox.SelectedIndex;
                toDoListBox.Items.RemoveAt(toDoListBox.SelectedIndex);

                for(int i = removeIndex; i < toDoListBox.Items.Count; i++)
                { 
                    string itemText = toDoListBox.Items[i].ToString();

                    toDoListBox.Items[i] = $"{ i + 1}. {itemText.Substring(itemText.IndexOf('.') + 2)}";
                }
            }
            else
            {
                MessageBox.Show("Выберите дело для удаления");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (toDoListBox.SelectedIndex != -1)
            {
                string description = descritionTextBox.Text;
                string priority = priorityComboBox.SelectedItem?.ToString();
                int selectedIndex = toDoListBox.SelectedIndex;

                if (description != "")
                {
                    string editItem = $"{selectedIndex + 1}. {description} - {priority}";
                    toDoListBox.Items[selectedIndex] = editItem;
                    descritionTextBox.Clear();
                    priorityComboBox.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Введите описание для редактируемого дела.");
                }
            }
            else
            {
                MessageBox.Show("Выберите дело для редактирования.");
            }
        }

    }


}

