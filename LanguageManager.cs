using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace XtremePharmacyManager
{
    //wrapper class for languages
    public class Language :IDisposable
    {
        string display_name = "";
        string language_code = "";

        public Language() 
        {
            display_name = "Sample Language";
            language_code = "lang-LANG";
        }

        public Language(string DisplayName, string LanguageCode)
        {
            display_name = DisplayName;
            language_code = LanguageCode;
        }

        public string DisplayName {  get { return display_name; } }
        public string LanguageCode { get { return language_code; } }
        public void Dispose()
        {
            if(display_name != null)
            {
                display_name = "";
                display_name = null;
            }
            if(language_code != null)
            {
                language_code = "";
                language_code = null;
            }
        }
    }

    //wrapper for languages
    public class LanguageManager : IDisposable
    {
        static List<Language> languages;
        public List<Language> Languages { get { return languages; } }
        public LanguageManager()
        {
            languages = new List<Language>();
        }

        public static void LoadLanguages()
        {
            try
            {
                XmlDocument language_doc = new XmlDocument();
                XmlNode root_node = null;
                using (FileStream fs = new FileStream(Path.GetFullPath(Application.StartupPath + "/Language.xml"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    language_doc.Load(fs);
                    root_node = language_doc.GetElementsByTagName("Languages").Item(0);
                    foreach(XmlNode node in root_node.ChildNodes)
                    {
                        languages.Add(new Language(node.Attributes["LanguageName"].Value, node.Attributes["LanguageCode"].Value));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AddLanguage(string DisplayName,string LanguageCode)
        {
            try
            {
                XmlDocument language_doc = new XmlDocument();
                XmlNode root_node = null;
                using (FileStream fs = new FileStream(Path.GetFullPath(Application.StartupPath + "/Language.xml"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    language_doc.Load(fs);
                    root_node = language_doc.GetElementsByTagName("Languages").Item(0);
                    XmlElement new_language_node = language_doc.CreateElement("Language","Languages");
                    new_language_node.SetAttribute("LanguageName", DisplayName);
                    new_language_node.SetAttribute("LanguageCode", LanguageCode);
                    root_node.AppendChild(new_language_node);
                    language_doc.Save(fs);
                }
                LoadLanguages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AddLanguage(Language lang)
        {
            try
            {
                XmlDocument language_doc = new XmlDocument();
                XmlNode root_node = null;
                using (FileStream fs = new FileStream(Path.GetFullPath(Application.StartupPath + "/Language.xml"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    language_doc.Load(fs);
                    root_node = language_doc.GetElementsByTagName("Languages").Item(0);
                    XmlElement new_language_node = language_doc.CreateElement("Language", "Languages");
                    new_language_node.SetAttribute("LanguageName", lang.DisplayName);
                    new_language_node.SetAttribute("LanguageCode", lang.LanguageCode);
                    root_node.AppendChild(new_language_node);
                    language_doc.Save(fs);
                }
                LoadLanguages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            if(languages != null)
            {
                foreach(Language language in languages)
                {
                    language.Dispose();
                    languages.Remove(language);
                }
                languages.Clear();
                languages = null;
            }
        }
    }
}
