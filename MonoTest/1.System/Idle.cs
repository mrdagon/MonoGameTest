/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//対戦相手
public class Idle
{
    public Deck デッキレシピ;
    public List<int> 報酬ID = new List<int>(7);
    public List<int> 報酬数 = new List<int>(7);

    public bool is対戦可 = false;
    public List<bool> 成績 = new List<bool>(7);

}
