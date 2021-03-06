﻿using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string fullname;
        private string username;

        public User()
        {
        }

        public int Id { get; set; }
        
        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
            }
        }
        
        public string FullName
        {
            get { return this.fullname; }
            set
            {
                if (this.fullname == value) { return; }
                this.fullname = value;
                Notify("FullName");
            }
        }

        public override string ToString()
        {
            return this.FullName;
        }

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
