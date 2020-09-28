using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Les1SMSWebForm.NETFrameworkCSharp.Controllers
{
    public class TNegenSMSController : Controller
    {
        static T9ViewModel t9ViewModel = new T9ViewModel();
        // GET: TNegenSMS
        public ActionResult Index()
        {
            return View("Index", t9ViewModel.disPlayObject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VoegAdresToe(DisplayObject abc) {
            t9ViewModel.disPlayObject.DebugText = "Submit is gedaan"+abc.PersoonNaam;
            string invoertekst = abc.PersoonNaam;
            string filePath = @"C:\_CStest\meedoen.html";
            string test = System.IO.File.ReadAllText(filePath);
//            var x = test.Split("\n");
            string[] lijnen = System.IO.File.ReadAllLines(filePath);
            System.IO.File.WriteAllText(filePath, test+"\n"+invoertekst);
            return View("Index", t9ViewModel.disPlayObject);
        }
        public ActionResult KlikKnop(string textWaarde)
        {
            t9ViewModel.klikKnop(textWaarde);
            return View("Index", t9ViewModel.disPlayObject);
        }
        public ActionResult BackSpace()
        {
            t9ViewModel.verwijderKarakter();
            return View("Index", t9ViewModel.disPlayObject);
        }
    }

    class T9ViewModel {
        public DisplayObject disPlayObject = new DisplayObject();

        string vorigeKnop = "";
        int counter = 0;
        DateTime tijdStipVorigeKlik = DateTime.Now;

        public void klikKnop(string textWaarde) {
            TimeSpan verschil = DateTime.Now.Subtract(tijdStipVorigeKlik);
            tijdStipVorigeKlik = DateTime.Now;
            disPlayObject.DebugText = tijdStipVorigeKlik.ToString();
            if (vorigeKnop.Equals(textWaarde))
            {
                if (verschil.TotalSeconds < 1.0)
                {
                    counter++;
                    disPlayObject.DisplayText = disPlayObject.DisplayText.Substring(0, disPlayObject.DisplayText.Length - 1);
                    if (counter > textWaarde.Length - 1) 
                    {
                        counter = 0;
                    }
                    disPlayObject.DisplayText += textWaarde[counter];
                }
                else 
                { 
                    disPlayObject.DisplayText += textWaarde[0];
                    counter = 0;
                }
            }
            else
            {
                disPlayObject.DisplayText += textWaarde[0];
                vorigeKnop = textWaarde;
                counter = 0;
            }
            
        }
        public void verwijderKarakter() {
            disPlayObject.DisplayText = disPlayObject.DisplayText.Substring(0, disPlayObject.DisplayText.Length - 1);
        }
    }

    public class DisplayObject {
        public string DisplayText = "";
        public string DebugText = "";
        public string PersoonNaam { get; set; }
        public string PersoonTelefoonNummer { get; set; }
    }
}