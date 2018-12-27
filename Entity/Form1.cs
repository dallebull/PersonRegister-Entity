using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Entity
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            Populate();
        }




   
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (textBox1 != null & textBox2 != null) { 
            Student s = new Student();
            Database db = new Database();
            s.Firstname = textBox1.Text;
            s.Lastname = textBox2.Text;
            db.Students.Add(s);
            db.SaveChanges();
            Populate();
            }
            else
            {
                MessageBox.Show("Fill in both Fields");
            }
           
        }

        private void Populate()
        {

        if(listBox1 != null) { listBox1.Items.Clear();}
            using (Database db = new Database())
            {

                var studentNames = (from s in db.Students select s.Firstname + " " + s.Lastname);
                if (studentNames != null)
                {
                    listBox1.Items.AddRange(studentNames.ToArray());
                }

            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student();
                Database db = new Database();

            var select = listBox1.SelectedItem;
            var SelectedRow = select.ToString();

            String[] selectedRow= SelectedRow.Split( );
            string  firstName = selectedRow[0];
            string lastName = selectedRow[1];

                foreach (var student in db.Students)
                {
                   if (student.Firstname == firstName)
                    {
                        if (student.Lastname == lastName)
                        {
                            db.Students.Attach(student);
                            db.Students.Remove(student);
                            listBox1.Items.Remove(SelectedRow);
                           
                        }
                   }
                }
                db.SaveChanges();
            }
   
            catch (Exception)
            {
                MessageBox.Show("Nope");
            }
            Populate();
        }
    }
}
