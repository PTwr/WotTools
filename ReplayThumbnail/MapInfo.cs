using System.Collections.Generic;
using System.Linq;

namespace ReplayThumbnail
{
    public class MapInfo
    {
        public string Key { get; set; }
        public string Minimap { get; set; }

        public bool IsMatching(string filename)
        {
            return filename.ToLower().Contains(Key.ToLower());
        }

        public static List<MapInfo> Maps = new List<MapInfo>()
        {
            new MapInfo()
            {
                Key = "01_karelia",
                Minimap = "01_karelia.png",
            },
            new MapInfo()
            {
                Key = "02_malinovka",
                Minimap = "02_malinovka.png",
            },
            new MapInfo()
            {
                Key = "03_campania_big",
                Minimap = "03_campania_big.png",
            },
            new MapInfo()
            {
                Key = "04_himmelsdorf",
                Minimap = "04_himmelsdorf.png",
            },
            new MapInfo()
            {
                Key = "05_prohorovka",
                Minimap = "05_prohorovka.png",
            },
            new MapInfo()
            {
                Key = "06_ensk",
                Minimap = "06_ensk.png",
            },
            new MapInfo()
            {
                Key = "07_lakeville",
                Minimap = "07_lakeville.png",
            },
            new MapInfo()
            {
                Key = "08_ruinberg",
                Minimap = "08_ruinberg.png",
            },
            new MapInfo()
            {
                Key = "10_hills",
                Minimap = "10_hills.png",
            },
            new MapInfo()
            {
                Key = "11_murovanka",
                Minimap = "11_murovanka.png",
            },
            new MapInfo()
            {
                Key = "13_erlenberg",
                Minimap = "13_erlenberg.png",
            },
            new MapInfo()
            {
                Key = "14_siegfried_line",
                Minimap = "14_siegfried_line.png",
            },
            new MapInfo()
            {
                Key = "17_munchen",
                Minimap = "17_munchen.png",
            },
            new MapInfo()
            {
                Key = "18_cliff",
                Minimap = "18_cliff.png",
            },
            new MapInfo()
            {
                Key = "19_monastery",
                Minimap = "19_monastery.png",
            },
            new MapInfo()
            {
                Key = "23_westfeld",
                Minimap = "23_westfeld.png",
            },
            new MapInfo()
            {
                Key = "28_desert",
                Minimap = "28_desert.png",
            },
            new MapInfo()
            {
                Key = "29_el_hallouf",
                Minimap = "29_el_hallouf.png",
            },
            new MapInfo()
            {
                Key = "31_airfield",
                Minimap = "31_airfield.png",
            },
            new MapInfo()
            {
                Key = "33_fjord",
                Minimap = "33_fjord.png",
            },
            new MapInfo()
            {
                Key = "34_redshire",
                Minimap = "34_redshire.png",
            },
            new MapInfo()
            {
                Key = "35_steppes",
                Minimap = "35_steppes.png",
            },
            new MapInfo()
            {
                Key = "36_fishing_bay",
                Minimap = "36_fishing_bay.png",
            },
            new MapInfo()
            {
                Key = "37_caucasus",
                Minimap = "37_caucasus.png",
            },
            new MapInfo()
            {
                Key = "38_mannerheim_line",
                Minimap = "38_mannerheim_line.png",
            },
            new MapInfo()
            {
                Key = "44_north_america",
                Minimap = "44_north_america.png",
            },
            new MapInfo()
            {
                Key = "45_north_america",
                Minimap = "45_north_america.png",
            },
            new MapInfo()
            {
                Key = "47_canada_a",
                Minimap = "47_canada_a.png",
            },
            new MapInfo()
            {
                Key = "59_asia_great_wall",
                Minimap = "59_asia_great_wall.png",
            },
            new MapInfo()
            {
                Key = "60_asia_miao",
                Minimap = "60_asia_miao.png",
            },
            new MapInfo()
            {
                Key = "63_tundra",
                Minimap = "63_tundra.png",
            },
            new MapInfo()
            {
                Key = "83_kharkiv",
                Minimap = "83_kharkiv.png",
            },
            new MapInfo()
            {
                Key = "90_minsk",
                Minimap = "90_minsk.png",
            },
            new MapInfo()
            {
                Key = "95_lost_city_ctf",
                Minimap = "95_lost_city_ctf.png",
            },
            new MapInfo()
            {
                Key = "95_lost_city_ctf_h19",
                Minimap = "95_lost_city_ctf_h19.png",
            },
            new MapInfo()
            {
                Key = "99_poland",
                Minimap = "99_poland.png",
            },
            new MapInfo()
            {
                Key = "101_dday",
                Minimap = "101_dday.png",
            },
            new MapInfo()
            {
                Key = "105_germany",
                Minimap = "105_germany.png",
            },
            new MapInfo()
            {
                Key = "112_eiffel_tower_ctf",
                Minimap = "112_eiffel_tower_ctf.png",
            },
            new MapInfo()
            {
                Key = "114_czech",
                Minimap = "114_czech.png",
            },
            new MapInfo()
            {
                Key = "115_sweden",
                Minimap = "115_sweden.png",
            },
            new MapInfo()
            {
                Key = "208_bf_epic_normandy",
                Minimap = "208_bf_epic_normandy.png",
            },
        };
    }
}
