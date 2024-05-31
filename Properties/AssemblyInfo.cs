using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("XtremePharmacyManager")]
[assembly: AssemblyDescription("A robust pharmacy management program with SQL Server-based database and Entity model, regular and bulk operations" +
                              "and role-based access control anywhere in the form. Its login system is tightly bound to the database's login system and even if" +
                              "you login with a system administrator account which is not recommended if you aren't in the user list of the database you won't be" +
                              "even connected and logged in there. About the database, if you add new users be sure to open your favourite SQL database editor that supports" +
    "SQL Server and add a login and a database user in the database itself and assign the user to the role according to what you put in the table, more about that in the documentation." +
    "There are extensible options for localisation, user account and resource customisation and login saving(but not" +
                              "deleting) and localisation. I hadn't done this myself however, for some things I had to use ChatGPT and the world wide web to learn and" +
                              "apply them so I am using this as open source with the MIT license. Enjoy using it and customising it. If you want to build another program" +
                              "out of it, however, please, at least put my name in the credits as well and I hope you make a better version of it. RadoTheMadMan out!\r\n")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("XtremePharmacyManager")]
[assembly: AssemblyCopyright("Copyright © 2024 Radoslav Dimitrov/RadoTheMadMan")]
[assembly: AssemblyTrademark("Copyright © 2024 Radoslav Dimitrov/RadoTheMadMan\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("4945c02a-7526-4327-9269-bd1d23e2cff4")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
