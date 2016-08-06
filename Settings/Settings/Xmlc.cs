using System;
using System.Collections.Generic;
using System.Xml;

namespace Settings
{
    class Xmlc
    {
        /// <summary>
        /// Parses xml to game list
        /// </summary>
        /// <param name="xml">Steam game xml</param>
        /// <returns>Returns list of Config.Game</returns>
        public static List<Config.Game> ParseXML(string xml)
        {
            var gameList = new List<Config.Game>();
            
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            var nodes = xmlDoc.SelectNodes("/gamesList/games/game");
            if (nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    string appName = node.SelectSingleNode("name").InnerText;
                    int appId = Convert.ToInt32(node.SelectSingleNode("appID").InnerText);

                    gameList.Add(new Config.Game()
                    {
                        name = appName,
                        id = appId
                    });
                }
            }

            return gameList;
        }
    }
}
