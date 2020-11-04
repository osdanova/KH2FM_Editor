using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle
{
    class BattleFile : BarFile
    {
        public BattleFile(String name, List<byte> raw) : base(name, raw)
        {
        }
    }
}
