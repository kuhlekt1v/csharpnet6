using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacktLibrary
{
    [System.Flags]
    public enum WondersOfTheAncientWorld : byte
    {

        None = 0B_0000_0000,                     // i.e. 0
        GreatPyramidOfGiza = 0B_0000_0001,  // i.e. 1
        HangingGardensOfBabylon = 0B_0000_0010,  // i.e. 2
        StatueOfZeusAtOlympia = 0B_0000_0100,    // i.e. 4
        TempleOfArtemisAtEphesus = 0B_0000_1000, // i.e. 8
        MausoleumAtHalicarnassus = 0B_0001_0000, // i.e. 16      
        ColossusOfRhodes = 0B_0010_0000,          // i.e. 32
        LighthouseOfAlexandria = 0B_0100_0000    // i.e. 64
    }
}
