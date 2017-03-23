using System;
using System.IO;
using System.Xml;

namespace Steam4Intermediate
{
    class Program
    {
        static void Main( string[] args )
        {
            XmlReaderSettings settings = new XmlReaderSettings();

            settings.ProhibitDtd = false;

            using ( XmlReader reader = XmlReader.Create( @"..\..\..\..\steamworks.xml", settings ) )
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load( reader );

                ParseXML( xmldoc );
            }
        }

        static void ParseXML( XmlDocument xmldoc )
        {
            Generator gen = new Generator();

            gen.ParseXMLDoc( xmldoc );
        }
    }
}
