using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Project {
    public enum GoodsType
    {
        Hero,
        Equip,
    }

    public class Goods
    {
        public GoodsType Type;
        public int ID;
        public int Count;
        private static Regex goodsRegex = new Regex(@"^(?<type>\d+),(?<id>\d+),(?<count>\d+)$");

        public Goods(GoodsType type, int id, int count)
        {
            Type = type;
            ID = id;
            Count = count;

        }

        public Goods(int type, int id, int count)
        {
            Type = (GoodsType)type;
            ID = id;
            Count = count;

        }

        public static Goods Parse(string str)
        {

            if (!goodsRegex.IsMatch(str))
            {
                return null;
            }

            Match goodsMatch = goodsRegex.Match(str);

            GoodsType type = (GoodsType)int.Parse(goodsMatch.Groups["type"].Value);
            int id = int.Parse(goodsMatch.Groups["id"].Value);
            int count = int.Parse(goodsMatch.Groups["count"].Value);

            return new Goods(type, id, count);
        }
    }

}

