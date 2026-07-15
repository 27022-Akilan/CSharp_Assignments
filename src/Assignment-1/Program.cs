using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using System.Xml.Linq;
using Assignment1;
using Assignment1.Models;
using Assignment1.Service;
using Assignment1.View;
using Microsoft.VisualBasic.FileIO;

namespace Assignments
{
    /// <summary>
    /// this is the entry point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// hdjhj
        /// </summary>
        /// <param name="args">default</param>
        public static void Main(string[] args)
        {
            ViewContact viewContact = new ViewContact();
            viewContact.ViewContacts();
        }
    }
}