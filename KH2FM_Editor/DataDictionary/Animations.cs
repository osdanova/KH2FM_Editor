using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class Animations
    {
        // 2 Bytes
        public static Dictionary<ushort, String> soraAnimations = new Dictionary<ushort, string>() {
{ 604 , "Attack1" },
{ 608 , "Attack 1 aoe" },
{ 612 , "Attack 2" },
{ 616 , "Finisher aoe" },
{ 620 , "Finisher single" },
{ 644 , "Upper Slash" },
{ 648 , "Slapshot" },
{ 652 , "Dodge Slash" },
{ 656 , "Sliding Dash" },
{ 660 , "Guard Break" },
{ 664 , "Explosion" },
{ 668 , "Finishing Leap" },
{ 676 , "Flash Step" },
{ 680 , "Vicinity Break" },
{ 684 , "Counterguard" },
{ 688 , "Retaliating Slash" },
{ 692 , "Guard" },
{ 724 , "Aerial attack 1" },
{ 728 , "Aerial attack 2" },
{ 732 , "Aerial finisher single" },
{ 736 , "Aerial finisher aoe" },
{ 764 , "Aerial Sweep" },
{ 768 , "Aerial Spiral" },
{ 772 , "Horizontal Slash" },
{ 776 , "Aerial Finish" },
{ 784 , "Aerial Dive" },
{ 788 , "Magnet Burst" }
        };

        public static String getSoraAnimation(ushort id)
        {
            if (soraAnimations.ContainsKey(id)) return soraAnimations[id];
            return "";
        }
    }
}
